using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.Interfaces
{
    public interface ITestAppointmentRepository : IBaseRepository<TestAppointment>
    {
        Task<TestAppointment?> GetByIdWithApplicationAsync(int id, CancellationToken cancellationToken = default);
    }
}
