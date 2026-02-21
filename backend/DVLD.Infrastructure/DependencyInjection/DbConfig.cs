using DVLD.Application.Abstractions;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.UpdatePerson;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using DVLD.Infrastructure.Data.Interceptors;
using DVLD.Infrastructure.Repositorys;
using DVLD.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.LocalLicenseApplications.CreateApplication;

namespace DVLD.Infrastructure.DependencyInjection
{
    public static class DbConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Register IDateTimeProvider first — interceptor depends on it
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // Register interceptor — must be scoped so EF Core can inject it per request
            services.AddScoped<AuditInterceptor>();

            // Register DbContext — pull interceptor from DI so it gets IDateTimeProvider
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString)
                       .AddInterceptors(sp.GetRequiredService<AuditInterceptor>());
            });

            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
            // Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationTypesRepository, ApplicationTypesRepositorys>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped<ILicenseClassesRepository, LicenseClassesRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<ICountiesRepository, CountiesRepository>();
            services.AddScoped<IDetainedLicenseRepository, DetainedLicenseRepository>();
            services.AddScoped<ILocalDrivingLicenseApplicationRepository, LocalDrivingLicenseApplicationRepository>();
            services.AddScoped<ITestAppointmentRepository, TestAppointmentRepository>();
            services.AddScoped<ITestTypesRepository, TestTypesRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IInternationalLicenseRepository, InternationalLicenseRepository>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

            // Validators
            services.AddScoped<IValidate<CreatePersonCommand>, CreatePersonCommandValidator>();
            services.AddScoped<IValidate<UpdatePersonCommand>, UpdatePersonCommandValidator>();
            services.AddScoped<IValidate<LocalDrivingLicenseApplicationCommand>, LocalDrivingLicenseApplicationCommandValidator>();

            // UnitOfWork
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
