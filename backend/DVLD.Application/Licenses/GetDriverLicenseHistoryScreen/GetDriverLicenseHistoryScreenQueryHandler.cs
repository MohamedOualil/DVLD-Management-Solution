using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Common;
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Licenses;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Licenses.GetDriverLicenseHistoryScreen
{
    internal sealed class GetDriverLicenseHistoryScreenQueryHandler
        : IQueryHandler<GetDriverLicenseHistoryScreenQuery, DriverLicenseHistoryScreenResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetDriverLicenseHistoryScreenQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<DriverLicenseHistoryScreenResponse>> Handle(
            GetDriverLicenseHistoryScreenQuery request,
            CancellationToken cancellationToken)
        {
            if (request.PersonId <= 0)
                return Result<DriverLicenseHistoryScreenResponse>.Failure(DomainErrors.erPerson.InvalidId);

            int localPage = request.LocalPageNumber ?? request.PageNumber;
            int localSize = request.LocalPageSize ?? request.PageSize;
            int intlPage = request.InternationalPageNumber ?? request.PageNumber;
            int intlSize = request.InternationalPageSize ?? request.PageSize;

            Result localPagination = QueryProjectionHelpers.ValidatePagination(localPage, localSize);
            if (localPagination.IsFailure)
                return Result<DriverLicenseHistoryScreenResponse>.Failure(localPagination.Errors);

            Result intlPagination = QueryProjectionHelpers.ValidatePagination(intlPage, intlSize);
            if (intlPagination.IsFailure)
                return Result<DriverLicenseHistoryScreenResponse>.Failure(intlPagination.Errors);

            var person = await QueryProjectionHelpers.GetPersonResponseAsync(
                _dbContext,
                request.PersonId,
                cancellationToken);

            if (person is null)
                return Result<DriverLicenseHistoryScreenResponse>.Failure(DomainErrors.erPerson.NotFound);

            var localQuery = _dbContext.Licenses
                .AsNoTracking()
                .Where(l => l.Application.PersonId == request.PersonId);

            int localTotal = await localQuery.CountAsync(cancellationToken);
            var localItems = await localQuery
                .OrderByDescending(l => l.IssueDate)
                .ThenByDescending(l => l.Id)
                .Skip((localPage - 1) * localSize)
                .Take(localSize)
                .Select(l => new GetLocalDrivingLicenseHistoryResponse
                {
                    LicenseId = l.Id,
                    ClassName = l.LicenseClass.ClassName,
                    IssueDate = l.IssueDate,
                    ExpirationDate = l.ExpirationDate,
                    IsActive = l.IsActive,
                    LocalId = _dbContext.LocalDrivingLicenseApplications
                        .Where(a => a.ApplicationId == l.ApplicationId)
                        .Select(a => a.Id)
                        .FirstOrDefault()
                })
                .ToListAsync(cancellationToken);

            var intlQuery = _dbContext.InternationalLicenses
                .AsNoTracking()
                .Where(i => i.Application.PersonId == request.PersonId);

            int intlTotal = await intlQuery.CountAsync(cancellationToken);
            var intlItems = await intlQuery
                .OrderByDescending(i => i.IssueDate)
                .ThenByDescending(i => i.Id)
                .Skip((intlPage - 1) * intlSize)
                .Take(intlSize)
                .Select(i => new GetInternationalDrivingLicenseHistoryResponse
                {
                    InternationalLicenseId = i.Id,
                    ApplicationId = i.ApplicationId,
                    LicenseId = i.IssuedUsingLocalLicenseId,
                    IssueDate = i.IssueDate,
                    ExpirationDate = i.ExpirationDate,
                    IsActive = i.IsActive
                })
                .ToListAsync(cancellationToken);

            var response = new DriverLicenseHistoryScreenResponse
            {
                Person = person,
                LocalLicenses = new PagedList<GetLocalDrivingLicenseHistoryResponse>(
                    localItems, localTotal, localPage, localSize),
                InternationalLicenses = new PagedList<GetInternationalDrivingLicenseHistoryResponse>(
                    intlItems, intlTotal, intlPage, intlSize)
            };

            return Result<DriverLicenseHistoryScreenResponse>.Success(response);
        }
    }
}
