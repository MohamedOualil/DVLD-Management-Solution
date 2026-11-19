using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Administration.GetServiceFees
{
    internal sealed class GetServiceFeesQueryHandler
        : IQueryHandler<GetServiceFeesQuery, List<ServiceFeeItemDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetServiceFeesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<ServiceFeeItemDto>>> Handle(
            GetServiceFeesQuery request,
            CancellationToken cancellationToken)
        {
            var items = new List<ServiceFeeItemDto>();

            if (request.Category is null or FeeCategory.ApplicationService)
            {
                var appTypes = await _dbContext.ApplicationTypes
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Select(a => new
                    {
                        a.Id,
                        a.ApplicationTypeTitle,
                        Fees = a.ApplicationFees.Amount
                    })
                    .ToListAsync(cancellationToken);

                items.AddRange(appTypes.Select(a => new ServiceFeeItemDto
                {
                    Id = a.Id,
                    Category = FeeCategory.ApplicationService,
                    Title = a.ApplicationTypeTitle,
                    Description = GetApplicationServiceDescription(a.Id),
                    Fees = a.Fees
                }));
            }

            if (request.Category is null or FeeCategory.TestExam)
            {
                var testTypes = await _dbContext.TestTypes
                    .AsNoTracking()
                    .OrderBy(t => t.Id)
                    .Select(t => new ServiceFeeItemDto
                    {
                        Id = t.Id,
                        Category = FeeCategory.TestExam,
                        Title = t.TestTypeTitle,
                        Description = t.TestTypeDescrption,
                        Fees = t.TestFees.Amount
                    })
                    .ToListAsync(cancellationToken);

                items.AddRange(testTypes);
            }

            return Result<List<ServiceFeeItemDto>>.Success(items);
        }

        internal static string GetApplicationServiceDescription(int id) => id switch
        {
            (int)ApplicationTypeEnum.NewLocalDrivingLicenseService =>
                "Initial application processing fee for a local driving license class.",
            (int)ApplicationTypeEnum.RenewDrivingLicenseService =>
                "Administrative fee for renewing an expired local driving license.",
            (int)ApplicationTypeEnum.Replacement_for_a_LostDrivingLicense =>
                "Issuing a duplicate credential after a reported loss.",
            (int)ApplicationTypeEnum.Replacement_for_a_DamagedDrivingLicense =>
                "Reprinting an unreadable or physically damaged license card.",
            (int)ApplicationTypeEnum.ReleaseDetainedDrivingLicsense =>
                "Clearance application fee required when releasing a detained license.",
            (int)ApplicationTypeEnum.NewInternationalLicense =>
                "Issuance of an international driving permit linked to an active Class 3 license.",
            (int)ApplicationTypeEnum.RetakeTest =>
                "Additional service fee charged when rescheduling a previously failed examination.",
            _ => "DVLD application service fee."
        };
    }
}
