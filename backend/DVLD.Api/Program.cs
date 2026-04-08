using DVLD.Application;
using DVLD.Infrastructure.DependencyInjection;
using DVLD.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddApplication();
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

app.MapControllers();

app.Run();


