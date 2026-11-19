using DVLD.Domain.Common;
using DVLD.Domain.Entities;

namespace DVLD.Domain.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<bool> NationalNoExistsAsync(string nationalNo, CancellationToken cancellationToken = default);
        Task<bool> EmailExistsAsync(string normalizedEmail, int? excludePersonId = null, CancellationToken cancellationToken = default);
        Task<bool> CountryExistsAsync(int countryId, CancellationToken cancellationToken = default);
        Task<bool> HasLinkedRecordsAsync(int personId, CancellationToken cancellationToken = default);
    }
}
