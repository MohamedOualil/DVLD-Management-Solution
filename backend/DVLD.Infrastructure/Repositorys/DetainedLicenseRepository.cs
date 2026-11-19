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
    internal sealed class DetainedLicenseRepository : BaseRepository<DetainedLicense>, IDetainedLicenseRepository
    {
        private readonly AppDbContext _context;
        public DetainedLicenseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<DetainedLicense?> GetActiveByLicenseIdAsync(int licenseId, CancellationToken cancellationToken = default)
        {
            return await _context.DetainedLicenses
                .Include(d => d.License)
                    .ThenInclude(l => l.Driver)
                .FirstOrDefaultAsync(d => d.LicenseId == licenseId && !d.IsReleased, cancellationToken);
        }
    }
}
