using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    public class DetainedLicense : Entity
    {
        public int LicenseId { get; private set; }
        public DrivingLicense License { get; private set; } = null!;
        public DateTime DetainDate { get; private set; }
        public Money FineFees { get; private set; } = null!;
        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; } = null!;
        public bool IsReleased { get; private set; } = false;
        public DateTime? ReleaseDate { get; private set; }

        public int? ReleasedByUserId { get; private set; }
        public User? ReleasedBy { get; private set; }

        public int? ReleaseApplicationId { get; private set; }
        public Application? ReleaseApplication { get; private set; }

        private DetainedLicense() { }

        private DetainedLicense(DrivingLicense license, Money fineFees, int createdBy)
        {
            LicenseId = license.Id;
            License = license;
            CreatedByUserId = createdBy;
            IsReleased = false;
            DetainDate = DateTime.UtcNow;
            FineFees = fineFees with { };

            license.MarkAsDetained();
        }

        public static DetainedLicense Detain(DrivingLicense license, Money fineFees, int createdBy)
        {
            return new DetainedLicense(license, fineFees, createdBy);
        }

        private void _ReleaseLicense(Application releaseApplication, int releaseBy)
        {
            IsReleased = true;
            var now = DateTime.UtcNow;
            ReleaseDate = now >= DetainDate ? now : DetainDate;
            ReleaseApplication = releaseApplication;
            ReleasedByUserId = releaseBy;

            License.MarkAsReleased();
        }

        public Result ReleaseDrivingLicense(int releaseBy, ApplicationType applicationType)
        {
            if (License is null || License.Driver is null)
                return Result.Failure(DomainErrors.erLicense.NotFound);

            if (!License.IsActive)
                return Result.Failure(DomainErrors.erLicense.LicenseNotActive);

            if (IsReleased)
                return Result.Failure(DomainErrors.erDetainedLicense.LicenseAlreadyReleased);

            if (applicationType.Id != (int)ApplicationTypeEnum.ReleaseDetainedDrivingLicsense)
                return Result.Failure(DomainErrors.erApplications.InvalidApplicationType);

            Application application = Application.CreateApplication(
                License.Driver.PersonId,
                applicationType,
                releaseBy);

            _ReleaseLicense(application, releaseBy);

            return Result.Success();
        }
    }
}
