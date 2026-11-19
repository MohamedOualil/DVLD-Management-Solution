using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class InternationalLicenseRepository
        : BaseRepository<InternationalLicense>, IInternationalLicenseRepository
    {
        public InternationalLicenseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<bool> HasActiveLicenseForDriverAsync(
            int driverId,
            CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            return await DbContext.InternationalLicenses
                .AnyAsync(x => x.DriverId == driverId && x.IsActive && x.ExpirationDate > now, cancellationToken);
        }
    }
}
