using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Common;
using DVLD.Contracts.Licenses;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Licenses.GetAllDetainedLicenses
{
    internal sealed class GetAllDetainedLicensesQueryHandler
        : IQueryHandler<GetAllDetainedLicensesQuery, PagedList<DetainedLicenseListItemDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllDetainedLicensesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<PagedList<DetainedLicenseListItemDto>>> Handle(
            GetAllDetainedLicensesQuery request,
            CancellationToken cancellationToken)
        {
            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                return Result<PagedList<DetainedLicenseListItemDto>>.Failure(pagination.Errors);

            var query = _dbContext.DetainedLicenses.AsNoTracking();

            if (request.ReleaseStatus == 1)
            {
                query = query.Where(d => !d.IsReleased);
            }
            else if (request.ReleaseStatus == 2)
            {
                query = query.Where(d => d.IsReleased);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string term = request.SearchTerm.Trim();
                int? searchId = int.TryParse(term, out int parsedId) ? parsedId : null;
                query = query.Where(d =>
                    (searchId.HasValue && (d.Id == searchId.Value || d.LicenseId == searchId.Value)) ||
                    d.License.Application.Person.NationalNo.Number.Contains(term) ||
                    (d.License.Application.Person.FullName.FirstName + " " + d.License.Application.Person.FullName.LastName).Contains(term));
            }

            int totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(d => d.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(d => new DetainedLicenseListItemDto
                {
                    DetainId = d.Id,
                    LicenseId = d.LicenseId,
                    PersonId = d.License.Application.PersonId,
                    FullName = d.License.Application.Person.FullName.FirstName + " " + d.License.Application.Person.FullName.LastName,
                    NationalNo = d.License.Application.Person.NationalNo.Number,
                    DetainDate = d.DetainDate,
                    FineFees = d.FineFees.Amount,
                    IsReleased = d.IsReleased,
                    ReleaseDate = d.ReleaseDate,
                    ReleaseApplicationId = d.ReleaseApplicationId
                })
                .ToListAsync(cancellationToken);

            return Result<PagedList<DetainedLicenseListItemDto>>.Success(
                new PagedList<DetainedLicenseListItemDto>(items, totalCount, request.PageNumber, request.PageSize));
        }
    }
}
