using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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


        public Task<IEnumerable<InternationalLicense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasActiveLicenseForLocalLicenseAsync(
            int localLicenseId,
            CancellationToken cancellationToken = default)
        {
            return await _context.InternationalLicenses
                .AnyAsync(x => x.IssuedUsingLocalLicenseId == localLicenseId && x.IsActive, cancellationToken);
        }
    }
}
