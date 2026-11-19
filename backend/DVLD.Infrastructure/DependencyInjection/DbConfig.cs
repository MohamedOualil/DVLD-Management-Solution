using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Authentication;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Authentication;
using DVLD.Infrastructure.Data;
using DVLD.Infrastructure.Repositorys;
using DVLD.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DVLD.Infrastructure.DependencyInjection
{
    public static class DbConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' is missing or empty.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<AppDbContext>());

            // Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationTypesRepository, ApplicationTypesRepositorys>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped<ILicenseClassesRepository, LicenseClassesRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ILicenseRepository, DrivingLicenseRepository>();
            services.AddScoped<IDetainedLicenseRepository, DetainedLicenseRepository>();
            services.AddScoped<ILocalDrivingLicenseApplicationRepository, LocalDrivingLicenseApplicationRepository>();
            services.AddScoped<ITestAppointmentRepository, TestAppointmentRepository>();
            services.AddScoped<ITestTypesRepository, TestTypesRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IInternationalLicenseRepository, InternationalLicenseRepository>();
            services.AddScoped<IUserSessionRepository, UserSessionRepository>();

            // Services
            services.AddMemoryCache();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddSingleton<IUserAccessInvalidator, MemoryUserAccessInvalidator>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
