using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Domain.Enums;
using DVLD.Domain.ValueObjects;

namespace DVLD.Domain.Entities
{
    public class Application : Entity
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public int ApplicationTypeId { get; private set; }
        public ApplicationTypeEnum ApplicationTypeEnum => (ApplicationTypeEnum)ApplicationTypeId;
        public ApplicationType ApplicationType { get; private set; }
        public ApplicationStatusEnum Status { get; private set; } = ApplicationStatusEnum.New;
        public DateTime? LastStatusDate { get; private set; }
        public Money PaidFees { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        public int? LastUpdatedByUserId { get; private set; }
        public User? LastUpdatedBy { get; private set; }


        private Application() {}

        private Application(Person person, ApplicationType applicationTypes
            , Money paidFees, int createdById)
        {
            PersonId = person.Id;
            Person = person;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatusEnum.New;
            LastStatusDate = DateTime.UtcNow;
            CreatedByUserId = createdById;

            PaidFees = paidFees;

        }
        private Application(int personId, ApplicationType applicationTypes
            , Money paidFees, int createdById)
        {
            PersonId = personId;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatusEnum.Completed;
            LastStatusDate = DateTime.UtcNow;
            CreatedByUserId = createdById;

            PaidFees = paidFees;

        }

        public static Application CreateApplication(int personId, ApplicationType applicationTypes,
            int createdById)
        {
            return new Application(personId, applicationTypes, applicationTypes.ApplicationFees, createdById);
        }

        public static Result<Application> CreateLocalApplication(Person person, ApplicationType applicationTypes,
            int createdById)
        {
            if (applicationTypes.Id != (int) Enums.ApplicationTypeEnum.NewLocalDrivingLicenseService)
                return Result<Application>.Failure(DomainErrors.erApplications.InvalidApplicationType);


            return Result<Application>.Success(new Application(
                person, applicationTypes, applicationTypes.ApplicationFees, createdById));
        }

        public Result CancelApplication(User CancelBy)
        {
            if (Status == ApplicationStatusEnum.Cancelled)
                return Result.Failure(DomainErrors.erApplications.ApplicationAlreadyCancelled);
            if (Status == ApplicationStatusEnum.Completed)
                return Result.Failure(DomainErrors.erApplications.ApplicationIsCompleted);

            Status = ApplicationStatusEnum.Cancelled;
            LastStatusDate = DateTime.UtcNow;
            LastUpdatedBy = CancelBy;
            LastUpdatedByUserId = CancelBy.Id;

            return Result.Success();
        }

        public void MakeComplete(int updatedBy)
        {
            Status = ApplicationStatusEnum.Completed;
            LastStatusDate = DateTime.UtcNow;
            LastUpdatedByUserId = updatedBy;

        }

        public  Application LicenseApplication(ApplicationType applicationType
            , int createdById)
        {
            return new Application(this.PersonId, applicationType, applicationType.ApplicationFees, createdById);
        }

     

            
    }
}
