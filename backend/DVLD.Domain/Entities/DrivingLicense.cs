using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    public class DrivingLicense : Entity
    {
        public int ApplicationId { get; private set; }
        public Application Application { get; private set; } = null!;

        public int DriverId { get; private set; }
        public Driver Driver { get; private set; } = null!;

        public int LicenseClassId { get; private set; }
        public LicenseClassEnum LicenseClassEnum => (LicenseClassEnum)LicenseClassId;
        public LicenseClass LicenseClass { get; private set; } = null!;

        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string? Notes { get; private set; }
        public Money PaidFees { get; private set; } = null!;
        public bool IsActive { get; private set; } = true;
        public bool IsDetained { get; private set; } = false;
        public IssueReasonEnum IssueReason { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; } = null!;

        private DrivingLicense() { }

        private DrivingLicense(
            Application application,
            Driver driver,
            LicenseClass licenseClass,
            DateTime issueDate,
            DateTime expirationDate,
            Money paidFees,
            string? note,
            IssueReasonEnum issueReason,
            int createdBy)
        {
            ApplicationId = application.Id;
            Application = application;
            DriverId = driver.Id;
            Driver = driver;
            LicenseClassId = licenseClass.Id;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = string.IsNullOrWhiteSpace(note) ? null : note.Trim();
            PaidFees = paidFees with { };
            IsActive = true;
            IsDetained = false;
            IssueReason = issueReason;
            CreatedByUserId = createdBy;
        }

        public static DrivingLicense IssueLicenseFirstTime(
            Application applications,
            Driver driver,
            LicenseClass licenseClass,
            string? note,
            int createdBy)
        {
            var issueDate = DateTime.UtcNow;
            var expirationDate = issueDate.AddYears(licenseClass.DefaultValidityLength);

            return new DrivingLicense(
                applications,
                driver,
                licenseClass,
                issueDate,
                expirationDate,
                licenseClass.ClassFees,
                note,
                IssueReasonEnum.FirstTime,
                createdBy);
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
        public void MarkAsDetained() => IsDetained = true;
        public void MarkAsReleased() => IsDetained = false;

        public Result<DrivingLicense> Replace(
            int createdBy,
            ApplicationType applicationType,
            string? notes)
        {
            if (!IsActive)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseNotActive);
            if (IsDetained)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseIsDetained);
            if (ExpirationDate <= DateTime.UtcNow)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseExpired);

            IssueReasonEnum issueReason;
            switch (applicationType.Id)
            {
                case (int)ApplicationTypeEnum.Replacement_for_a_DamagedDrivingLicense:
                    issueReason = IssueReasonEnum.DamagedReplacement;
                    break;
                case (int)ApplicationTypeEnum.Replacement_for_a_LostDrivingLicense:
                    issueReason = IssueReasonEnum.LostReplacement;
                    break;
                default:
                    return Result<DrivingLicense>.Failure(DomainErrors.erApplications.InvalidApplicationType);
            }

            var newApplication = Application.LicenseApplication(applicationType, createdBy);
            var zeroFees = Money.Create(0).Value!;

            var newLicense = new DrivingLicense(
                newApplication,
                Driver,
                LicenseClass,
                DateTime.UtcNow,
                ExpirationDate,
                zeroFees,
                notes,
                issueReason,
                createdBy);

            Deactivate();

            return Result<DrivingLicense>.Success(newLicense);
        }

        public Result<InternationalLicense> IssueInternationalLicense(
            int createdBy,
            ApplicationType applicationTypes)
        {
            if (!IsActive)
                return Result<InternationalLicense>.Failure(DomainErrors.erInternationalLicense.LocalLicenseNotActive);
            if (ExpirationDate <= DateTime.UtcNow)
                return Result<InternationalLicense>.Failure(DomainErrors.erInternationalLicense.LocalLicenseExpired);
            if (IsDetained)
                return Result<InternationalLicense>.Failure(DomainErrors.erInternationalLicense.LocalLicenseDetained);
            if (LicenseClassEnum != LicenseClassEnum.OrdinaryDrivingLicense)
                return Result<InternationalLicense>.Failure(DomainErrors.erLicense.ApplicationTypeNotAllowed);

            var newApplication = Application.LicenseApplication(applicationTypes, createdBy);

            var internationalLicense = InternationalLicense.IssueLicense(
                newApplication,
                Driver,
                this,
                IssueReasonEnum.FirstTime,
                createdBy);

            return Result<InternationalLicense>.Success(internationalLicense);
        }

        public Result<DrivingLicense> RenewLicense(
            int createdBy,
            ApplicationType applicationType,
            string? notes)
        {
            if (!IsActive)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseNotActive);
            if (IsDetained)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseIsDetained);
            if (ExpirationDate > DateTime.UtcNow)
                return Result<DrivingLicense>.Failure(DomainErrors.erLicense.LicenseNotExpired);

            var newApplication = Application.LicenseApplication(applicationType, createdBy);
            var issueDate = DateTime.UtcNow;
            var expirationDate = issueDate.AddYears(LicenseClass.DefaultValidityLength);

            var newLicense = new DrivingLicense(
                newApplication,
                Driver,
                LicenseClass,
                issueDate,
                expirationDate,
                LicenseClass.ClassFees,
                notes,
                IssueReasonEnum.Renew,
                createdBy);

            Deactivate();

            return Result<DrivingLicense>.Success(newLicense);
        }

        public Result<DetainedLicense> DetainedDrivingLicense(decimal fees, int createdBy)
        {
            if (!IsActive)
                return Result<DetainedLicense>.Failure(DomainErrors.erLicense.LicenseNotActive);
            if (ExpirationDate <= DateTime.UtcNow)
                return Result<DetainedLicense>.Failure(DomainErrors.erLicense.LicenseExpired);
            if (IsDetained)
                return Result<DetainedLicense>.Failure(DomainErrors.erDetainedLicense.LicenseAlreadyDetained);

            Result<Money> moneyResult = Money.Create(fees);
            if (moneyResult.IsFailure)
                return Result<DetainedLicense>.Failure(moneyResult.Errors);

            DetainedLicense detain = DetainedLicense.Detain(this, moneyResult.Value!, createdBy);
            return Result<DetainedLicense>.Success(detain);
        }
    }
}
