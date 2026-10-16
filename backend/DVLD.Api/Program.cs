using DVLD.Api.Authorization;
using DVLD.Api.Services;
using DVLD.Application;
using DVLD.Application.Abstractions;
using DVLD.Infrastructure.DependencyInjection;
using DVLD.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));

var jwtSettings = builder.Configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,


        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings!.Issuer,

        ValidAudience = jwtSettings.Audience,

        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
    };
    });

builder.Services.AddAuthorization();

builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("PersonOwnershipPolicy", policy =>
    {
        policy.Requirements.Add(new PersonOwnershipRequirement());
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, PersonOwnershipHandler>();



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

            new string[] {}
        }
    });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsync("Too many login attempts. Please try again later.", token);
    };

    // THE GLOBAL LIMITER (System Stability)
    // This applies to EVERY request automatically. Max 100 requests per minute per IP.
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

    // ADVANCED AUTH LIMITER (Sliding Window for Login/Refresh)
    options.AddPolicy("AuthLimiter", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        // Sliding Window stops hackers from sending 5 requests at 12:00:59 and 5 more at 12:01:00
        return RateLimitPartition.GetSlidingWindowLimiter(
            partitionKey: ip,
            factory: _ => new SlidingWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromMinutes(1),
                SegmentsPerWindow = 4, // It checks the limit every 15 seconds for smoother throttling
                QueueLimit = 0
            });
    });

    // PER-USER LIMITER (For Authenticated Endpoints)
    options.AddPolicy("UserLimiter", httpContext =>
    {
        // Extract the logged-in User's ID from their JWT token claims
        var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: userId, // We limit by USER ID, not IP!
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 60, // 60 safe requests per minute per user
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 2
            });
    });

    // PUBLIC ENDPOINT LIMITER
    options.AddPolicy("PublicLimiter", httpContext =>
    {
        // Because they aren't logged in, we MUST limit them by IP
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: ip,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 20, // Strict limit for heavy database lists
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            });
    });


});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddPolicy("DVLDApiPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7261",
                            "http://localhost:5244")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DVLDApiPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    await next();

    // Catch anyone who gets a 403 Forbidden response
    if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
    {
        var userId = context.User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier) ?? "anonymous";
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var path = context.Request.Path.ToString();

        // Log the security threat
        app.Logger.LogWarning(
            "Forbidden access attempt. UserId={UserId}, Path={Path}, IP={IP}",
            userId, path, ip);
    }
});

app.MapControllers();

app.Run();


