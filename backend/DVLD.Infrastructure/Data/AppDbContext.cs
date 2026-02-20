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
        public DbSet<License> Licenses => Set<License>();
        public DbSet<Applications> Applications => Set<Applications>();
        public DbSet<ApplicationTypes> ApplicationTypes => Set<ApplicationTypes>();
        public DbSet<LicenseClasses> LicenseClasses => Set<LicenseClasses>();
        public DbSet<Counties> Counties => Set<Counties>();
        public DbSet<DetainedLicense> DetainedLicenses => Set<DetainedLicense>();
        public DbSet<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications => Set<LocalDrivingLicenseApplication>();
        public DbSet<TestAppointment> TestAppointments => Set<TestAppointment>();
        public DbSet<TestTypes> TestTypes => Set<TestTypes>();
        public DbSet<Test> Tests => Set<Test>();
        public DbSet<InternationalLicense> InternationalLicenses => Set<InternationalLicense>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // AuditInterceptor handles CreatedAt and UpdatedAt automatically
            // No manual field-setting needed here
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
