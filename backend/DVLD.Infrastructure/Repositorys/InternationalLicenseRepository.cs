using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class InternationalLicenseRepository : IInternationalLicenseRepository
    {
        public Task<int> AddAsync(InternationalLicense entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InternationalLicense> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InternationalLicense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(InternationalLicense entity)
        {
            throw new NotImplementedException();
        }
    }
}
