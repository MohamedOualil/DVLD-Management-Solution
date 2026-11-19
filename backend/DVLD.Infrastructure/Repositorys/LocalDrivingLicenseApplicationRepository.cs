using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class LocalDrivingLicenseApplicationRepository
        : BaseRepository<LocalDrivingLicenseApplication>, ILocalDrivingLicenseApplicationRepository
    {
        public LocalDrivingLicenseApplicationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<LocalDrivingLicenseApplication?> GetWithDetailsAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.LocalDrivingLicenseApplications
                .AsSplitQuery()
                .Include(a => a.Application)
                    .ThenInclude(a => a.Person)
                .Include(a => a.LicenseClass)
                .Include(t => t.TestAppointments)
                    .ThenInclude(ts => ts.Test)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
