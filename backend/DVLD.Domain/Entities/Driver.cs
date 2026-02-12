using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class Driver : Entity<int>
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }


        private Driver()
        {
            
        }

        private Driver(Person person, User createdBy )
        {
            PersonId = person.Id;
            Person = person;
            CreatedByUserId = createdBy.Id;
            CreatedBy = createdBy;
            
        }

        public static Result<Driver> Create(Person person, User createdBy)
        {
            if (person == null)
                return Result<Driver>.Failure("Person Info is required.");

            if (createdBy == null)
                return Result<Driver>.Failure("User  is required.");

            return Result<Driver>.Success(new Driver(person, createdBy));

        }
    }
}
