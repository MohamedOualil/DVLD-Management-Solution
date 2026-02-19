using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Interfaces
{
    public interface IApplicationTypesRepository : IBaseRepository<ApplicationTypes,ApplicationType>
    {
    }
}
