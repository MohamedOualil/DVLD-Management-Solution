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
    internal sealed class InternationalLicenseRepository : Repositories<InternationalLicense,int>, IInternationalLicenseRepository
    {
        private readonly AppDbContext _context;
        public InternationalLicenseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<InternationalLicense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(InternationalLicense entity)
        {
            throw new NotImplementedException();
        }
    }
}
