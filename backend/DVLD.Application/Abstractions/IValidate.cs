using DVLD.Application.Persons.CreatePerson;
using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions
{
    public interface IValidate<T> where T : class
    {
        public Result Validate(T request);
    }
}
