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
    internal sealed class LicenseRepository : Repositories<License,int>, ILicenseRepository
    {

        private readonly AppDbContext _context;
        public LicenseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<License>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(License entity)
        {
            throw new NotImplementedException();
        }
    }
}
