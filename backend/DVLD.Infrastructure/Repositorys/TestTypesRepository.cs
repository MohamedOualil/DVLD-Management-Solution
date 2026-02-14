using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    public class TestTypesRepository : ITestTypesRepository
    {
        public Task<int> AddAsync(TestTypes entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TestTypes> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TestTypes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TestTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}
