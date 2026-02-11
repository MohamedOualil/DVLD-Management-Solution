using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class ApplicationTypesRepositorys : IApplicationTypesRepository
    {
        public Task<int> AddAsync(IApplicationTypesRepository entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IApplicationTypesRepository> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IApplicationTypesRepository>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IApplicationTypesRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
