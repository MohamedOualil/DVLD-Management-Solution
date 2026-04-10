using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public enum ErrorType
    {
        None = 0,
        BadRequest = 1,
        NotFound = 2,
        Unauthorized = 3,
        Conflict = 4,
    }
}
