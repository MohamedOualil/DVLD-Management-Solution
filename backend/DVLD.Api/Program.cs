using DVLD.Api.Common;
using DVLD.Api.Services;
using DVLD.Application;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
using DVLD.Contracts.Auth;
using DVLD.Infrastructure.DependencyInjection;
using DVLD.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));

var jwtSettings = builder.Configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
if (jwtSettings is null ||
    string.IsNullOrWhiteSpace(jwtSettings.SecretKey) ||
    Encoding.UTF8.GetByteCount(jwtSettings.SecretKey) < 32 ||
    string.IsNullOrWhiteSpace(jwtSettings.Issuer) ||
    string.IsNullOrWhiteSpace(jwtSettings.Audience) ||
    jwtSettings.ExpiresInMinutes <= 0 ||
    jwtSettings.RefreshTokenExpiresInDays <= 0)
{
    throw new InvalidOperationException(
        "JwtSettings is invalid or incomplete. Configure SecretKey (at least 32 bytes), Issuer, Audience, ExpiresInMinutes > 0, and RefreshTokenExpiresInDays > 0.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var userIdClaim = context.Principal?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdClaim, out int userId))
                {
                    var invalidator = context.HttpContext.RequestServices
                        .GetRequiredService<IUserAccessInvalidator>();

                    var iatTicksClaim = context.Principal?.FindFirstValue("iat_ticks");
                    DateTime issuedAtUtc = long.TryParse(iatTicksClaim, out long ticks)
                        ? new DateTime(ticks, DateTimeKind.Utc)
                        : context.SecurityToken.ValidFrom;

                    if (invalidator.IsTokenInvalidated(userId, issuedAtUtc))
                    {
                        context.Fail("This session has been revoked.");
                    }
                }

                return Task.CompletedTask;
            },
            OnChallenge = async context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    Title = "Unauthorized",
                    Status = StatusCodes.Status401Unauthorized,
                    Errors =
                    [
                        new ErrorDetail
                        {
                            Code = "Auth.Unauthorized",
                            Message = "Authentication is required or your session token has expired."
                        }
                    ]
                });
            },
            OnForbidden = async context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    Title = "Forbidden",
                    Status = StatusCodes.Status403Forbidden,
                    Errors =
                    [
                        new ErrorDetail
                        {
                            Code = "Auth.Forbidden",
                            Message = "You do not have permission to perform this action."
                        }
                    ]
                });
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, token) =>
    {
        var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var path = context.HttpContext.Request.Path.ToString();
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

        logger.LogWarning(
            "[RATE-LIMIT] Request rejected (429 TooManyRequests). Path={Path}, IP={IP}",
            path, ip);

        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsJsonAsync(new ErrorResponse
        {
            Title = "Too Many Requests",
            Status = StatusCodes.Status429TooManyRequests,
            Errors =
            [
                new ErrorDetail
                {
                    Code = "RateLimit.Exceeded",
                    Message = "Too many requests. Please try again later."
                }
            ]
        }, token);
    };

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: ip,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 2
            });
    });

    options.AddPolicy("AuthLimiter", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetSlidingWindowLimiter(
            partitionKey: ip,
            factory: _ => new SlidingWindowRateLimiterOptions
            {
                PermitLimit = 20,
                Window = TimeSpan.FromMinutes(1),
                SegmentsPerWindow = 4,
                QueueLimit = 0
            });
    });

    options.AddPolicy("UserLimiter", httpContext =>
    {
        var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";
        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: userId,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 60,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 2
            });
    });

    options.AddPolicy("PublicLimiter", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: ip,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 20,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            });
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(kvp => kvp.Value?.Errors.Count > 0)
            .SelectMany(kvp => kvp.Value!.Errors.Select(err => new ErrorDetail
            {
                Code = $"Validation.{kvp.Key}",
                Message = string.IsNullOrWhiteSpace(err.ErrorMessage)
                    ? "The submitted value is invalid."
                    : err.ErrorMessage
            }))
            .ToList();

        return new BadRequestObjectResult(new ErrorResponse
        {
            Title = "Bad Request",
            Status = StatusCodes.Status400BadRequest,
            Errors = errors
        });
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();

builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DVLDApiPolicy", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7261",
                "http://localhost:5244")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DVLDApiPolicy");

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
    {
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var path = context.Request.Path.ToString();

        app.Logger.LogWarning(
            "[SECURITY] Unauthorized access attempt (401). Path={Path}, IP={IP}",
            path, ip);
    }
    else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var path = context.Request.Path.ToString();

        app.Logger.LogWarning(
            "[SECURITY] Forbidden access attempt (403). UserId={UserId}, Path={Path}, IP={IP}",
            userId, path, ip);
    }
});

app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();

app.MapHealthChecks("/health").AllowAnonymous();
app.MapControllers();

app.Run();
