using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.Interfaces
{
    public interface IInternationalLicenseRepository : IBaseRepository<InternationalLicense>
    {
        Task<bool> HasActiveLicenseForDriverAsync(
            int driverId,
            CancellationToken cancellationToken = default);
    }
}
