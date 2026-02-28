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
    public class Applications : Entity
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public ApplicationTypeEnum ApplicationTypeId { get; private set; }
        public ApplicationTypes ApplicationType { get; private set; }
        public ApplicationStatusEnum Status { get; private set; } = ApplicationStatusEnum.New;
        public DateTime LastStatusDate { get; private set; }
        public Money PaidFees { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        public int? LastUpdatedByUserId { get; private set; }
        public User? LastUpdatedBy { get; private set; }


        private Applications()
        {

        }

        private Applications(Person person, ApplicationTypes applicationTypes
            , Money paidFees, int createdById)
        {
            PersonId = person.Id;
            Person = person;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = (ApplicationTypeEnum)applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatusEnum.New;
            LastStatusDate = DateTime.UtcNow;
            CreatedByUserId = createdById;

            PaidFees = paidFees;

        }
        private Applications(int personId, ApplicationTypes applicationTypes
            , Money paidFees, int createdById)
        {
            PersonId = personId;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = (ApplicationTypeEnum) applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatusEnum.Completed;
            LastStatusDate = DateTime.UtcNow;
            CreatedByUserId = createdById;

            PaidFees = paidFees;

        }

        public static Applications CreateApplication(int personId, ApplicationTypes applicationTypes,
            int createdById)
        {


            return new Applications(personId, applicationTypes, applicationTypes.ApplicationFees, createdById);
        }

        public static Result<Applications> CreateLocalApplication(Person person, ApplicationTypes applicationTypes,
            int createdById)
        {
            if (applicationTypes.Id != (int) Enums.ApplicationTypeEnum.NewLocalDrivingLicenseService)
                return Result<Applications>.Failure(DomainErrors.erApplications.InvalidApplicationType);


            return Result<Applications>.Success(new Applications(
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

        public  Applications LicenseApplication(ApplicationTypes applicationType
            , int createdById)
        {
            return new Applications(this.PersonId, applicationType, applicationType.ApplicationFees, createdById);
        }

     

            
    }
}
