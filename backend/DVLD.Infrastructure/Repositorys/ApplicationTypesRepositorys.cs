using DVLD.Domain.Common;
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
    internal sealed class ApplicationTypesRepositorys : Repositories<ApplicationTypes, ApplicationType> ,IApplicationTypesRepository
        
    {
        private readonly AppDbContext _context;
        public ApplicationTypesRepositorys(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public Task<bool> DeleteAsync(ApplicationType id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationTypes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ApplicationTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}
