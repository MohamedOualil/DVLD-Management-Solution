using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class DetainedLicenseRepository : IDetainedLicenseRepository
    {
        public Task<int> AddAsync(DetainedLicense entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetainedLicense> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DetainedLicense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(DetainedLicense entity)
        {
            throw new NotImplementedException();
        }
    }
}
