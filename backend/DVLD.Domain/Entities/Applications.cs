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
    public class Applications : Entity<int>
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public ApplicationType ApplicationTypeId { get; private set; }
        public ApplicationTypes ApplicationType { get; private set; }
        public ApplicationStatus Status { get; private set; } = ApplicationStatus.New;
        public DateTime LastStatusDate { get; private set; }
        public Money PaidFees { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }

        public int? LastUpdatedByUserId { get; private set; }
        public User LastUpdatedBy { get; private set; }


        private Applications()
        {
            
        }

        private Applications(Person person, ApplicationTypes applicationTypes
            ,Money paidFees,User createdBy )
        {
            PersonId = person.Id;
            Person = person;
            ApplicationDate = DateTime.UtcNow;
            ApplicationTypeId = applicationTypes.Id;
            ApplicationType = applicationTypes;
            Status = ApplicationStatus.New;
            LastStatusDate = DateTime.UtcNow;
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;
            PaidFees = paidFees;
            
        }

        public static Result<Applications> ApplyApplication(Person person, ApplicationTypes applicationTypes, Money paidFees,
            User createdBy)
        {
            //if (person == null)
            //    return Result<Applications>.Failure("Person Info is required.");
            //if (applicationTypes == null)
            //    return Result<Applications>.Failure("Application Types  is required.");

            //if (paidFees == null)
            //    return Result<Applications>.Failure("Paid Fees is required.");

            //if (createdBy == null)
            //    return Result<Applications>.Failure("User  is required.");


            return Result<Applications>.Success(new Applications(person,applicationTypes,paidFees,createdBy));
        }



    }
}
