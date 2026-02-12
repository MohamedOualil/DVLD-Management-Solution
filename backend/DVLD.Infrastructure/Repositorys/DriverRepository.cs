using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class DriverRepository : IDriverRepository
    {
        public Task<int> AddAsync(Driver entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Driver>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Driver entity)
        {
            throw new NotImplementedException();
        }
    }
}
