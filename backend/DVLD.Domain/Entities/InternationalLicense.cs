using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class InternationalLicense : Entity
    {
        public int ApplicationId { get; private set; }
        public Applications Application { get; private set; }
        public int DriverId { get; private set; }
        public Driver Driver { get; private set; }

        public int IssuedUsingLocalLicenseId { get; private set; }
        public DrivingLicense LocalLicense {  get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        
        public bool IsActive { get; private set; } = true;
        public bool IsDetained { get; private set; } = false;
        public IssueReasonEnum IssueReason { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        private InternationalLicense() { }
        

        private InternationalLicense(
            Applications applications, 
            Driver driver, 
            DrivingLicense license,
            IssueReasonEnum issueReason, 
            int createdBy)
        {
            ApplicationId = applications.Id;
            Application = applications;
            LocalLicense = license;
            IssuedUsingLocalLicenseId = license.Id;
            DriverId = driver.Id;
            Driver = driver;
            IssueDate = DateTime.UtcNow;
            ExpirationDate = IssueDate.AddYears(3);
            IsActive = true;
            IsDetained = false;
            IssueReason = issueReason;
            CreatedByUserId = createdBy;

        }


        public static InternationalLicense IssueLicense(Applications applications, Driver driver,DrivingLicense license, 
            IssueReasonEnum issueReason, int createdBy)
        {

            return new InternationalLicense
                            (applications, driver, license, issueReason, createdBy);

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
