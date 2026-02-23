using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class LocalDrivingLicenseApplicationRepository : Repositories<LocalDrivingLicenseApplication,int>, ILocalDrivingLicenseApplicationRepository
    {

        private readonly AppDbContext _context;
        public LocalDrivingLicenseApplicationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<LocalDrivingLicenseApplication?> GetWithDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.LocalDrivingLicenseApplications
                .Include(a => a.Application)
                .Include(t => t.TestAppointments)
                    .ThenInclude(ts => ts.Test)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }


        public Task<IEnumerable<LocalDrivingLicenseApplication>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(LocalDrivingLicenseApplication entity)
        {
            throw new NotImplementedException();
        }
    }
}
