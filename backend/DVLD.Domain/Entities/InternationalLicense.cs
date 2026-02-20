using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class InternationalLicense : Entity<int>
    {
        public int ApplicationId { get; private set; }
        public Applications Application { get; private set; }
        public int DriverId { get; private set; }
        public Driver Driver { get; private set; }

        public int IssuedUsingLocalLicenseId { get; private set; }
        public License LocalLicense {  get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        
        public bool IsActive { get; private set; } = true;
        public bool IsDetained { get; private set; } = false;
        public IssueReason IssueReason { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        private InternationalLicense() { }
        

        private InternationalLicense(Applications applications, Driver driver, License license,IssueReason issueReason, User createdBy)
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
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;

        }


        public static Result<InternationalLicense> IssueLicense(Applications applications, Driver driver,License license, 
            IssueReason issueReason, User createdBy)
        {
            //if (applications == null)
            //    return Result<InternationalLicense>.Failure("Application is required.");

            //if (applications.ApplicationTypeId != ApplicationType.NewInternationalLicense)
            //    return Result<InternationalLicense>.Failure("Invalid application type for release.");

            //if (license == null)
            //    return Result<InternationalLicense>.Failure("License is required.");

            //if (license.IsDetained)
            //    return Result<InternationalLicense>.Failure("License is detained.");

            //if (!license.IsActive)
            //    return Result<InternationalLicense>.Failure("License is  not active.");

            //if (driver == null)
            //    return Result<InternationalLicense>.Failure("Driver is required.");

            //if (createdBy == null)
            //    return Result<InternationalLicense>.Failure("Creator user is required.");


            return Result<InternationalLicense>.Success(new InternationalLicense
                            (applications, driver, license, issueReason, createdBy));

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
