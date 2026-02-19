using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class TestTypesRepository : Repositories<TestTypes,TestType> ,ITestTypesRepository
    {
        private readonly AppDbContext _context;
        public TestTypesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }


        public Task<bool> DeleteAsync(TestType id)
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
