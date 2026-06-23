using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; }
        DbSet<Country> Countries { get; }
        DbSet<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; }
        DbSet<User> Users {  get; }
        DbSet<Driver> Drivers {  get; }
        DbSet<DrivingLicense> Licenses {  get; }
        DbSet<Domain.Entities.Application> Applications {  get; }
        DbSet<ApplicationType> ApplicationTypes {  get; }
        DbSet<LicenseClass> LicenseClasses {  get; }
        DbSet<DetainedLicense> DetainedLicenses {  get; }

        DbSet<TestAppointment> TestAppointments {  get; }
        DbSet<TestType> TestTypes {  get; }
        DbSet<Test> Tests {  get; }
        DbSet<InternationalLicense> InternationalLicenses { get; }


        DbSet<UserSession> UserSession {  get; }
    }
}
