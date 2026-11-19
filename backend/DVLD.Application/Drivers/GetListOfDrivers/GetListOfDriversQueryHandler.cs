using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Common;
using DVLD.Contracts.Drivers;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Drivers.GetListOfDrivers
{
    internal sealed class GetListOfDriversQueryHandler
        : IQueryHandler<GetListOfDriversQuery, PagedList<DriversListResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetListOfDriversQuery> _validator;

        public GetListOfDriversQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetListOfDriversQuery> validate)
        {
            _validator = validate;
            _dbContext = dbContext;
        }

        public async Task<Result<PagedList<DriversListResponse>>> Handle(
            GetListOfDriversQuery request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<DriversListResponse>>.Failure(validation.Errors);

            string? nationNo = string.IsNullOrWhiteSpace(request.NationNo) ? null : request.NationNo.Trim();
            string? fullName = string.IsNullOrWhiteSpace(request.Name) ? null : request.Name.Trim();

            var query = _dbContext.Drivers.AsNoTracking();

            if (request.PersonId.HasValue)
            {
                query = query.Where(d => d.PersonId == request.PersonId.Value);
            }

            if (request.DriverId.HasValue)
            {
                query = query.Where(d => d.Id == request.DriverId.Value);
            }

            if (fullName is not null)
            {
                query = query.Where(d =>
                    (d.Person.FullName.FirstName + " " + d.Person.FullName.LastName).StartsWith(fullName));
            }

            if (nationNo is not null)
            {
                query = query.Where(d => d.Person.NationalNo.Number.StartsWith(nationNo));
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string term = request.SearchTerm.Trim();
                int? searchId = int.TryParse(term, out int parsedId) ? parsedId : null;
                query = query.Where(d =>
                    (searchId.HasValue && (d.Id == searchId.Value || d.PersonId == searchId.Value)) ||
                    d.Person.NationalNo.Number.Contains(term) ||
                    (d.Person.FullName.FirstName + " " + d.Person.FullName.LastName).Contains(term));
            }

            if (request.ActiveFilter == 1)
            {
                query = query.Where(d => d.Licenses.Any(l => l.IsActive));
            }
            else if (request.ActiveFilter == 2)
            {
                query = query.Where(d => !d.Licenses.Any(l => l.IsActive));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(d => d.CreateAt)
                .ThenBy(d => d.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(d => new DriversListResponse
                {
                    DriverId = d.Id,
                    CreateDate = d.CreateAt,
                    FullName = d.Person.FullName.FirstName + " " + d.Person.FullName.LastName,
                    NationNo = d.Person.NationalNo.Number,
                    PersonId = d.PersonId,
                    ActiveLicenses = d.Licenses.Count(l => l.IsActive)
                })
                .ToListAsync(cancellationToken);

            var pageResult = new PagedList<DriversListResponse>(
                items,
                totalCount,
                request.PageNumber,
                request.PageSize);

            return Result<PagedList<DriversListResponse>>.Success(pageResult);
        }
    }
}
