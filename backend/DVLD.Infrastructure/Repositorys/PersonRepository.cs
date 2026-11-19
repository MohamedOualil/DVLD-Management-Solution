using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<bool> NationalNoExistsAsync(string nationalNo, CancellationToken cancellationToken = default)
        {
            string normalized = nationalNo.Trim().ToUpperInvariant();
            return DbContext.Persons.AnyAsync(p => p.NationalNo.Number == normalized, cancellationToken);
        }

        public Task<bool> EmailExistsAsync(
            string normalizedEmail,
            int? excludePersonId = null,
            CancellationToken cancellationToken = default)
        {
            return DbContext.Persons.AnyAsync(
                p => p.Email != null &&
                     p.Email.Value == normalizedEmail &&
                     (!excludePersonId.HasValue || p.Id != excludePersonId.Value),
                cancellationToken);
        }

        public Task<bool> CountryExistsAsync(int countryId, CancellationToken cancellationToken = default)
        {
            return DbContext.Countries.AnyAsync(c => c.Id == countryId, cancellationToken);
        }

        public async Task<bool> HasLinkedRecordsAsync(int personId, CancellationToken cancellationToken = default)
        {
            if (await DbContext.Users.AnyAsync(u => u.PersonId == personId, cancellationToken))
                return true;

            if (await DbContext.Drivers.AnyAsync(d => d.PersonId == personId, cancellationToken))
                return true;

            return await DbContext.Applications.AnyAsync(a => a.PersonId == personId, cancellationToken);
        }
    }
}
