using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace DVLD.Application.Licenses.GetLocalDrivingLicenseHistory
{
    internal sealed class GetLocalDrivingLicenseHistoryQueryHandler : IQueryHandler<GetLocalDrivingLicenseHistoryQuery, PagedList<GetLocalDrivingLicenseHistoryResponse>>
    {

        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetLocalDrivingLicenseHistoryQuery> _validator;

        public GetLocalDrivingLicenseHistoryQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetLocalDrivingLicenseHistoryQuery> validate)
        {
            _dbContext = dbContext;
            _validator = validate;
        }
        public async Task<Result<PagedList<GetLocalDrivingLicenseHistoryResponse>>> Handle(GetLocalDrivingLicenseHistoryQuery request, CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetLocalDrivingLicenseHistoryResponse>>.Failure(validation.Errors);

            string? nationNo = string.IsNullOrWhiteSpace(request.NationalNo) ? null : request.NationalNo;

            var query = _dbContext.Licenses.AsNoTracking();

            if (nationNo is not null)
            {
                query = query.Where(i => i.Application.Person.NationalNo.Number.StartsWith(nationNo));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                 .OrderBy(l => l.IssueDate)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(l => new GetLocalDrivingLicenseHistoryResponse
                 {
                     IssueDate = l.IssueDate,
                     ExpirationDate = l.ExpirationDate,
                     IsActive = l.IsActive,
                     LicenseId = l.Id,
                     ClassName = l.LicenseClass.ClassName,
                     LocalId = _dbContext.LocalDrivingLicenseApplications
                                .Where(a => a.ApplicationId == l.ApplicationId)
                                .Select(a => a.Id)
                                .FirstOrDefault()
                 })
                 .ToListAsync(cancellationToken);


            PagedList<GetLocalDrivingLicenseHistoryResponse> pageResutl = new PagedList<GetLocalDrivingLicenseHistoryResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetLocalDrivingLicenseHistoryResponse>>.Success(pageResutl);
        }
    }
}
