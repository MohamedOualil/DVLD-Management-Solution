using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class License : Entity<int>
    {
        public int ApplicationId { get;private set; }
        public Applications Applications { get; private set; }

        public int DriverId { get; private set; }
        public Driver Driver { get; private set; }

        public int LicenseClassId { get; private set; }
        public LicenseClasses LicenseClass { get; private set; }

        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string ?Notes { get; private set; }
        public Money PaidFees { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDetained { get; private set; } = false;
        public IssueReason IssueReason { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        private License()
        {
            
        }

        private License(Applications applications,Driver driver,LicenseClasses licenseClasses,string? note,
            IssueReason issueReason,User createdBy)
        {
            ApplicationId = applications.Id;
            Applications = applications;
            DriverId = driver.Id;
            Driver = driver;
            LicenseClassId = licenseClasses.Id;
            LicenseClass = licenseClasses;
            IssueDate = DateTime.UtcNow;
            ExpirationDate = DateTime.Today.AddYears(licenseClasses.DefaultValidityLength);
            Notes = note;
            PaidFees = licenseClasses.ClassFees;
            IsActive = true;
            IsDetained = false;
            IssueReason = issueReason;
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;

        }


        public static Result<License> IssueLicense(Applications applications, Driver driver, LicenseClasses licenseClasses, 
            string note,IssueReason issueReason, User createdBy)
        {
            if (applications == null)
                return Result<License>.Failure("Application is required.");

            if (driver == null)
                return Result<License>.Failure("Driver is required.");

            if (licenseClasses == null)
                return Result<License>.Failure("License Classe is required.");

            if (createdBy == null)
                return Result<License>.Failure("Creator user is required.");

            return Result<License>.Success(new License
                            (applications, driver, licenseClasses,note,issueReason,createdBy));

        }


        public void Activate()
        {
            IsActive = true;

        }

        public void Deactivate()
        {
            IsActive = false;

        }

        public void MarkAsDetained() => IsDetained = true;
        public void MarkAsReleased() => IsDetained = false;
    }
}
