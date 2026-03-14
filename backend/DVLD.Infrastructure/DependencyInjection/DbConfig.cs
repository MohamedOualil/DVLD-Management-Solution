using DVLD.Application.Abstractions;
using DVLD.Application.Persons.CreatePerson;
using DVLD.Application.Persons.UpdatePerson;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using DVLD.Infrastructure.Repositorys;
using DVLD.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DVLD.Application.Abstractions.Data;
using DVLD.Application.LocalLicenseApplications.CreateApplication;
using DVLD.Application.Tests.ScheduleTest;
using DVLD.Application.Tests.TakeTest;
using DVLD.Application.Licenses.DetainedDrivingLicense;
using DVLD.Application.InternationalDrivingLicenses.IssueInternationalLicense;
using DVLD.Application.Licenses.IssueLicenseFirstTime;
using DVLD.Application.Licenses.ReleaseDeatinedDrivingLicense;
using DVLD.Application.Licenses.RenewLicenseApplication;
using DVLD.Application.Licenses.ReplacementLicense;
using DVLD.Application.Drivers.GetListOfDrivers;
using DVLD.Application.Users.GetUsersList;
using DVLD.Application.Users.AddUser;
using DVLD.Application.LocalLicenseApplications.GetAllLocalApplications;
using DVLD.Application.Licenses.GetLocalDrivingLicenseHistory;

namespace DVLD.Infrastructure.DependencyInjection
{
    public static class DbConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(connectionString));
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
            // Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationTypesRepository, ApplicationTypesRepositorys>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped<ILicenseClassesRepository, LicenseClassesRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
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
            services.AddScoped<IValidate<CreateTestAppointmentCommand>, CreateTestAppointmentCommandValidator>();
            services.AddScoped<IValidate<TakeTestCommand>, TakeTestCommandValidator>();
            services.AddScoped<IValidate<DetainedDrivingLicenseCommand>, DetainedDrivingLicenseValidator>();
            services.AddScoped<IValidate<GetListOfDriversQuery>, GetListOfDriversValidator>();
            services.AddScoped<IValidate<IssueLicenseFirstTimeCommand>, IssueLicenseFirstTimeCommandValidator>();
            services.AddScoped<IValidate<IssueInternationalLicenseCommand>, IssueInternationalLicenseCommandValidator>();
            services.AddScoped<IValidate<ReleaseDeatinedDrivingLicenseCommand>, ReleaseDeatinedDrivingLicenseValidator>();
            services.AddScoped<IValidate<RenewLicenseApplicationCommand>, RenewLicenseApplicationValidator>();
            services.AddScoped<IValidate<ReplacementLicenseCommand>, ReplacementLicenseCommandValidater>();
            services.AddScoped<IValidate<GetListOfUsersQuery>, GetListOfUsersQueryValidator>();
            services.AddScoped<IValidate<AddUserCommand>, AddUserCommandValidator>();
            services.AddScoped<IValidate<GetAllLocalApplicationsQuery>, GetAllLocalApplicationsQueryValidator>();
            services.AddScoped<IValidate<GetLocalDrivingLicenseHistoryQuery>,GetLocalDrivingLicenseHistoryValidator>();




            // UnitOfWork
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
