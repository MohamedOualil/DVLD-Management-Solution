using DVLD.Domain.Common;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static DVLD.Domain.Common.DomainErrors;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Domain.Entities
{
    public class DrivingLicense : Entity<int>
    {
        public int ApplicationId { get;private set; }
        public Applications Application { get; private set; }

        public int DriverId { get; private set; }
        public Driver Driver { get; private set; }

        public LicenseClassEnum LicenseClassId { get; private set; }
        public LicenseClasses LicenseClass { get; private set; }

        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string ?Notes { get; private set; }
        public Money PaidFees { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDetained { get; private set; } = false;
        public IssueReasonEnum IssueReason { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        private DrivingLicense()
        {
            
        }

        private DrivingLicense(Applications applications,Driver driver,LicenseClasses licenseClass, string? note,
            IssueReasonEnum issueReason,int createdBy)
        {
            ApplicationId = applications.Id;
            Application = applications;
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


        public static DrivingLicense IssueLicenseFirstTime(Applications applications, Driver driver,LicenseClasses licenseClasses,
            string note,int createdBy)
        {
            return new DrivingLicense(
                applications, 
                driver, 
                licenseClasses,
                note,
                IssueReasonEnum.FirstTime, 
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

        public Result<DrivingLicense> Replace(
            int createdBy,
            ApplicationTypes applicationType,
            string? notes)
        {

            IssueReasonEnum issueReason = IssueReasonEnum.LostReplacement;
            switch (applicationType.Id)
            {
                case ApplicationType.Replacement_for_a_DamagedDrivingLicense:
                   issueReason = IssueReasonEnum.DamagedReplacement;
                    break;
                case ApplicationType.Replacement_for_a_LostDrivingLicense:
                    issueReason = IssueReasonEnum.LostReplacement;
                    break;
                default:
                    return Result<DrivingLicense>.Failure(DomainErrors.erApplications.InvalidApplicationType);
            }

            
            DrivingLicense newDrivingLicense = _NewDrivingLicense(
                                                 notes, 
                                                 createdBy, 
                                                 issueReason, 
                                                 applicationType);
            this.Deactivate();

            return Result<DrivingLicense>.Success(newDrivingLicense);

        }

   

        private DrivingLicense _NewDrivingLicense(string? notes,
            int createdBy,
            IssueReasonEnum issueReason,
            ApplicationTypes applicationType)
        {
            var application = this.Application.LicenseApplication(
                applicationType,
                createdBy);

            DrivingLicense license = new DrivingLicense(
                application,
                this.Driver,
                this.LicenseClass,
                notes,
                issueReason,
                createdBy);

            return license;
        }

        public Result<InternationalLicense> IssueInternationalLicense(
            int createdBy,
            ApplicationTypes applicationTypes)
        {
            if (!this.IsActive)
                return Result<InternationalLicense>.Failure(DomainErrors.erLicense.LicenseNotActive);
            if (this.LicenseClassId != LicenseClassEnum.OrdinaryDrivingLicense)
                return Result<InternationalLicense>.Failure(DomainErrors.erLicense.ApplicationTypeNotAllowed);

            var newApplication = this.Application.LicenseApplication(applicationTypes,createdBy);

            InternationalLicense internationalLicense = InternationalLicense.IssueLicense(
                newApplication,
                this.Driver,
                this,
                IssueReasonEnum.FirstTime,
                createdBy);

            return Result<InternationalLicense>.Success(internationalLicense);

        }

        public Result<DrivingLicense> RenewLicense(int createdBy ,ApplicationTypes applicationType,string? notes)
        {
            if (!this.IsActive)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseNotActive);
            if (this.ExpirationDate < DateTime.UtcNow)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseNotExpired);

            var newLicense = _NewDrivingLicense(notes, createdBy,IssueReasonEnum.Renew,applicationType);

            this.Deactivate();

            return Result<DrivingLicense>.Success(newLicense);


        }

       
    }
}
