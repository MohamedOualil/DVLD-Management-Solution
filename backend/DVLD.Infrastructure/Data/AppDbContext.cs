using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Data
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DrivingLicense> Licenses => Set<DrivingLicense>();
        public DbSet<Domain.Entities.Application> Applications => base.Set<Domain.Entities.Application>();
        public DbSet<ApplicationType> ApplicationTypes => Set<ApplicationType>();
        public DbSet<LicenseClass> LicenseClasses => Set<LicenseClass>();
        public DbSet<Country> Counties => Set<Country>();
        public DbSet<DetainedLicense> DetainedLicenses => Set<DetainedLicense>();
        public DbSet<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications => Set<LocalDrivingLicenseApplication>();
        public DbSet<TestAppointment> TestAppointments => Set<TestAppointment>();
        public DbSet<TestType> TestTypes => Set<TestType>();
        public DbSet<Test> Tests => Set<Test>();
        public DbSet<InternationalLicense> InternationalLicenses => Set<InternationalLicense>();

        public DbSet<UserSession> UserSession => Set<UserSession>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                int result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Concurrency exception occurred.", ex);
            }
            
        }
    }
}
