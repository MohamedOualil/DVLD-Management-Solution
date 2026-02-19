using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class ApplicationsRepository : Repositories<Applications,int> , IApplicationsRepository
    {

        private readonly AppDbContext _context;
        public ApplicationsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }


        public Task<bool> DeleteAsync(int id)
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
