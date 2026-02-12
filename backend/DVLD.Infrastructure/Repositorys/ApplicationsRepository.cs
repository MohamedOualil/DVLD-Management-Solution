using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        public Task<int> AddAsync(Applications entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Applications> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Applications>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Applications entity)
        {
            throw new NotImplementedException();
        }
    }
}
