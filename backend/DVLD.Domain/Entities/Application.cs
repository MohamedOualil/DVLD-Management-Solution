using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    public class Application : Entity
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; } = null!;
        public DateTime ApplicationDate { get; private set; }
        public int ApplicationTypeId { get; private set; }
        public ApplicationTypeEnum ApplicationTypeEnum => (ApplicationTypeEnum)ApplicationTypeId;
        public ApplicationType ApplicationType { get; private set; } = null!;
        public ApplicationStatusEnum Status { get; private set; } = ApplicationStatusEnum.New;
        public DateTime? LastStatusDate { get; private set; }
        public Money PaidFees { get; private set; } = null!;

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; } = null!;

        public int? LastUpdatedByUserId { get; private set; }
        public User? LastUpdatedBy { get; private set; }

        private Application() { }

        private Application(
            Person person,
            ApplicationType applicationTypes,
            Money paidFees,
            int createdById)
        {
            PersonId = person.Id;
            Person = person;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatusEnum.New;
            LastStatusDate = ApplicationDate;
            CreatedByUserId = createdById;
            PaidFees = paidFees with { };
        }

        private Application(
            int personId,
            ApplicationType applicationTypes,
            Money paidFees,
            int createdById)
        {
            PersonId = personId;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatusEnum.Completed;
            LastStatusDate = ApplicationDate;
            CreatedByUserId = createdById;
            PaidFees = paidFees with { };
        }

        public static Application CreateApplication(
            int personId,
            ApplicationType applicationTypes,
            int createdById)
        {
            return new Application(personId, applicationTypes, applicationTypes.ApplicationFees, createdById);
        }

        public static Result<Application> CreateLocalApplication(
            Person person,
            ApplicationType applicationTypes,
            int? createdById)
        {
            if (applicationTypes.Id != (int)ApplicationTypeEnum.NewLocalDrivingLicenseService)
                return Result<Application>.Failure(DomainErrors.erApplications.InvalidApplicationType);

            if (!createdById.HasValue || createdById.Value <= 0)
                return Result<Application>.Failure(DomainErrors.erUser.InvalidId);

            return Result<Application>.Success(new Application(
                person, applicationTypes, applicationTypes.ApplicationFees, createdById.Value));
        }

        public Result CancelApplication(int? cancelledByUserId)
        {
            if (Status == ApplicationStatusEnum.Cancelled)
                return Result.Failure(DomainErrors.erApplications.ApplicationAlreadyCancelled);
            if (Status == ApplicationStatusEnum.Completed)
                return Result.Failure(DomainErrors.erApplications.ApplicationIsCompleted);

            Status = ApplicationStatusEnum.Cancelled;
            LastStatusDate = DateTime.UtcNow;
            LastUpdatedByUserId = cancelledByUserId;

            return Result.Success();
        }

        public Result MakeComplete(int updatedBy)
        {
            if (Status == ApplicationStatusEnum.Cancelled)
                return Result.Failure(DomainErrors.erApplications.ApplicationAlreadyCancelled);
            if (Status == ApplicationStatusEnum.Completed)
                return Result.Failure(DomainErrors.erApplications.ApplicationIsCompleted);

            Status = ApplicationStatusEnum.Completed;
            LastStatusDate = DateTime.UtcNow;
            LastUpdatedByUserId = updatedBy;

            return Result.Success();
        }

        public Application LicenseApplication(ApplicationType applicationType, int createdById)
        {
            return new Application(PersonId, applicationType, applicationType.ApplicationFees, createdById);
        }
    }
}
