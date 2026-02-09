using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public class NationalNo : ValueObject
    {
        public string Number { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public NationalNo(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException("number");
            

        }
    }
}
