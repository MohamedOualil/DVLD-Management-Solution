using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.ReferenceData;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.ReferenceData.GetLicenseClasses
{
    internal sealed class GetLicenseClassesQueryHandler : IQueryHandler<GetLicenseClassesQuery, List<LicenseClassDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetLicenseClassesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<LicenseClassDto>>> Handle(
            GetLicenseClassesQuery request,
            CancellationToken cancellationToken)
        {
            var classes = await _dbContext.LicenseClasses
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .Select(c => new LicenseClassDto(
                    c.Id,
                    c.ClassName,
                    c.ClassDescription,
                    c.MinimumAllowedAge,
                    c.DefaultValidityLength,
                    c.ClassFees.Amount))
                .ToListAsync(cancellationToken);

            return Result<List<LicenseClassDto>>.Success(classes);
        }
    }
}
