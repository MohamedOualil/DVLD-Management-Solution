using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Common;
using DVLD.Contracts.InternationalLicenses;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.InternationalDrivingLicenses.GetAllInternationalLicenses
{
    internal sealed class GetAllInternationalLicensesQueryHandler
        : IQueryHandler<GetAllInternationalLicensesQuery, PagedList<InternationalLicenseListItemDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllInternationalLicensesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<PagedList<InternationalLicenseListItemDto>>> Handle(
            GetAllInternationalLicensesQuery request,
            CancellationToken cancellationToken)
        {
            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                return Result<PagedList<InternationalLicenseListItemDto>>.Failure(pagination.Errors);

            var now = DateTime.UtcNow;
            var query = _dbContext.InternationalLicenses.AsNoTracking();

            if (request.StatusFilter == 1)
            {
                query = query.Where(i => i.IsActive && i.ExpirationDate > now);
            }
            else if (request.StatusFilter == 2)
            {
                query = query.Where(i => !i.IsActive || i.ExpirationDate <= now);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string term = request.SearchTerm.Trim();
                int? searchId = int.TryParse(term, out int parsedId) ? parsedId : null;
                query = query.Where(i =>
                    (searchId.HasValue && (
                        i.Id == searchId.Value ||
                        i.ApplicationId == searchId.Value ||
                        i.IssuedUsingLocalLicenseId == searchId.Value ||
                        i.DriverId == searchId.Value)) ||
                    i.Application.Person.NationalNo.Number.Contains(term) ||
                    (i.Application.Person.FullName.FirstName + " " + i.Application.Person.FullName.LastName).Contains(term));
            }

            int totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(i => i.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new InternationalLicenseListItemDto
                {
                    InternationalLicenseId = i.Id,
                    ApplicationId = i.ApplicationId,
                    DriverId = i.DriverId,
                    LocalLicenseId = i.IssuedUsingLocalLicenseId,
                    PersonId = i.Application.PersonId,
                    FullName = i.Application.Person.FullName.FirstName + " " + i.Application.Person.FullName.LastName,
                    NationalNo = i.Application.Person.NationalNo.Number,
                    IssueDate = i.IssueDate,
                    ExpirationDate = i.ExpirationDate,
                    IsActive = i.IsActive
                })
                .ToListAsync(cancellationToken);

            return Result<PagedList<InternationalLicenseListItemDto>>.Success(
                new PagedList<InternationalLicenseListItemDto>(items, totalCount, request.PageNumber, request.PageSize));
        }
    }
}
