using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class LocalDrivingLicenseApplicationRepository : ILocalDrivingLicenseApplicationRepository
    {
        public Task<int> AddAsync(LocalDrivingLicenseApplication entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LocalDrivingLicenseApplication> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LocalDrivingLicenseApplication>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LocalDrivingLicenseApplication entity)
        {
            throw new NotImplementedException();
        }
    }
}
