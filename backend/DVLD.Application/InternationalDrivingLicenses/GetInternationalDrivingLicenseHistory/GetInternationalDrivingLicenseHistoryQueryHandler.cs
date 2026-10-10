using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DVLD.Application.Licenses.GetInternationalDrivingLicenseHistory
{
    internal sealed class GetInternationalDrivingLicenseHistoryQueryHandler : IQueryHandler<GetInternationalDrivingLicenseHistoryQuery, PagedList<GetInternationalDrivingLicenseHistoryResponse>>
    {
        

        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetInternationalDrivingLicenseHistoryQuery> _validator;

        public GetInternationalDrivingLicenseHistoryQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetInternationalDrivingLicenseHistoryQuery> validate)
        {
            _validator = validate;
            _dbContext = dbContext;
        }
        public async Task<Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>>> Handle(
            GetInternationalDrivingLicenseHistoryQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>>.Failure(validation.Errors);

            string? nationNo = string.IsNullOrWhiteSpace(request.NationalNo) ? null : request.NationalNo;

            var query = _dbContext.InternationalLicenses.AsNoTracking();


            if (nationNo is not null)
            {
                query = query.Where(i => i.Application.Person.NationalNo.Number.StartsWith(nationNo));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                 .OrderBy(i => i.IssueDate)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(l => new GetInternationalDrivingLicenseHistoryResponse
                 {
                     InternationalLicenseId = l.Id,
                     IssueDate = l.IssueDate,
                     ExpirationDate = l.ExpirationDate,
                     ApplicationId = l.ApplicationId,
                     IsActive = l.IsActive,
                     LicenseId = l.IssuedUsingLocalLicenseId,
                 })
                 .ToListAsync(cancellationToken);


            PagedList<GetInternationalDrivingLicenseHistoryResponse> pageResutl = 
                                        new  PagedList<GetInternationalDrivingLicenseHistoryResponse>(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount);

            return Result<PagedList<GetInternationalDrivingLicenseHistoryResponse>>.Success(pageResutl);
        }
    }
}
