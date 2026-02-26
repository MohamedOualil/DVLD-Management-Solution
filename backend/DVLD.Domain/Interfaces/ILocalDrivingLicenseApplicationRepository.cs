using DVLD.Domain.Common;
using DVLD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Interfaces
{
    public interface ILocalDrivingLicenseApplicationRepository : IBaseRepository<LocalDrivingLicenseApplication, int>
    {
        Task<LocalDrivingLicenseApplication?> GetWithDetailsAsync(
            int id, 
            CancellationToken cancellationToken = default);

       
    }
}
