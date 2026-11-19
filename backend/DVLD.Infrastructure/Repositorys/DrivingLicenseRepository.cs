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
    internal sealed class DrivingLicenseRepository : BaseRepository<DrivingLicense>, ILicenseRepository
    {

        private readonly AppDbContext _context;
        public DrivingLicenseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public override async Task<DrivingLicense?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Licenses
                .Include(l => l.Application)
                .Include(l => l.Driver)
                .Include(l => l.LicenseClass)
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        }

        public override async Task<DrivingLicense?> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id, CancellationToken.None);
        }

    }
}
