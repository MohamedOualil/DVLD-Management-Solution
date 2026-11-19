using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.Interfaces
{
    public interface IApplicationsRepository : IBaseRepository<Application>
    {
        Task<bool> ActiveApplicationExistsAsync(
            int personId,
            ApplicationTypeEnum applicationTypeEnum,
            CancellationToken cancellationToken = default);
    }
}
