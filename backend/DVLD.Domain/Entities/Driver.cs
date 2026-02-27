using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class Driver : Entity
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }

        public int CreatedByUserId { get; private set; }
        public User CreatedBy { get; private set; }


        private Driver()
        {
            
        }

        public Driver(int personId, int createdById )
        {
            PersonId = personId;

            CreatedByUserId = createdById;
 
            
        }

        
    }
}
