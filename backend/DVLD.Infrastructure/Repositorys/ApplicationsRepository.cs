using DVLD.Contracts.Enums;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Infrastructure.Repositorys
{
    internal sealed class ApplicationsRepository : BaseRepository<Domain.Entities.Application>, IApplicationsRepository
    {
        public ApplicationsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<bool> ActiveApplicationExistsAsync(
            int personId,
            ApplicationTypeEnum applicationTypeEnum,
            CancellationToken cancellationToken = default)
        {
            int typeId = (int)applicationTypeEnum;
            return DbContext.Applications.AnyAsync(
                a => a.PersonId == personId &&
                     a.ApplicationTypeId == typeId &&
                     a.Status == ApplicationStatusEnum.New,
                cancellationToken);
        }
    }
}
