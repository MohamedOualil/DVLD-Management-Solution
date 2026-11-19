using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Driver?> GetByPersonIdAsync(int id, CancellationToken cancellationToken)
        {
            return await DbContext.Drivers.FirstOrDefaultAsync(
                t => t.PersonId == id,
                cancellationToken);
        }
    }
}
