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

        private License(Applications applications,Driver driver,LicenseClasses licenseClass, string? note,
            IssueReason issueReason,int createdBy)
        {
            ApplicationId = applications.Id;
            Applications = applications;
            DriverId = driver.Id;
            Driver = driver;
            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
            IssueDate = DateTime.UtcNow;
            ExpirationDate = DateTime.Today.AddYears(licenseClass.DefaultValidityLength);
            Notes = note;
            PaidFees = licenseClass.ClassFees;
            IsActive = true;
            IsDetained = false;
            IssueReason = issueReason;
            CreatedByUserId = createdBy;


        }


        //public static License IssueLicense(Applications applications, Driver driver, LicenseClasses licenseClasses, 
        //    string note,IssueReason issueReason, User createdBy)
        //{

        //    return new License
        //                    (applications, driver, licenseClasses,note,issueReason,createdBy);

        //}


        public static License IssueLicenseFirstTime(Applications applications, Driver driver,LicenseClasses licenseClasses,
            string note,int createdBy)
        {
            return new License(
                applications, 
                driver, 
                licenseClasses,
                note,
                IssueReason.FirstTime, 
                createdBy);
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
