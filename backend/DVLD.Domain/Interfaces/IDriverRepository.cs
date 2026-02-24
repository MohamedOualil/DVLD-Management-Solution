using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Interfaces
{
    public interface IDriverRepository : IBaseRepository<Driver,int>
    {
        Task<Driver?> GetByPersonIdAsync(int id, CancellationToken cancellationToken);
    }
}
