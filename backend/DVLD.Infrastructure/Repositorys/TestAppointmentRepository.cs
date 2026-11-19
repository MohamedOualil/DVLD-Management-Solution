using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class TestAppointmentRepository : BaseRepository<TestAppointment>, ITestAppointmentRepository
    {
        public TestAppointmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<TestAppointment?> GetByIdWithApplicationAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.TestAppointments
                .Include(ta => ta.LocalDrivingLicense)
                    .ThenInclude(l => l.Application)
                .FirstOrDefaultAsync(ta => ta.Id == id, cancellationToken);
        }
    }
}
