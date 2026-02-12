using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class LicenseClassesRepository : ILicenseClassesRepository
    {
        public Task<int> AddAsync(LicenseClasses entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LicenseClasses> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LicenseClasses>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LicenseClasses entity)
        {
            throw new NotImplementedException();
        }
    }
}
