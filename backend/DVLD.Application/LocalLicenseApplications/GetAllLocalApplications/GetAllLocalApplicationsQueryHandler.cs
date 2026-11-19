using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.LocalLicenseApplications.GetAllLocalApplications
{
    internal sealed class GetAllLocalApplicationsQueryHandler
        : IQueryHandler<GetAllLocalApplicationsQuery, PagedList<GetAllLocalApplicationsResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IValidate<GetAllLocalApplicationsQuery> _validator;

        public GetAllLocalApplicationsQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetAllLocalApplicationsQuery> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<Result<PagedList<GetAllLocalApplicationsResponse>>> Handle(
            GetAllLocalApplicationsQuery request,
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetAllLocalApplicationsResponse>>.Failure(validation.Errors);

            string? searchTerm = request.SearchTerm?.Trim();
            bool hasSearchTerm = !string.IsNullOrWhiteSpace(searchTerm);
            int? searchId = hasSearchTerm && int.TryParse(searchTerm, out int parsedId) ? parsedId : null;

            var query = _dbContext.LocalDrivingLicenseApplications.AsNoTracking();

            if (hasSearchTerm)
            {
                query = query.Where(x =>
                    (searchId.HasValue && x.Id == searchId.Value) ||
                    (x.Application.Person.FullName.FirstName + " " + x.Application.Person.FullName.LastName).Contains(searchTerm!) ||
                    x.Application.Person.NationalNo.Number.StartsWith(searchTerm!));
            }

            if (request.StatusId.HasValue)
            {
                var status = (ApplicationStatusEnum)request.StatusId.Value;
                query = query.Where(s => s.Application.Status == status);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(l => l.Application.ApplicationDate)
                .ThenByDescending(l => l.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(l => new GetAllLocalApplicationsResponse
                {
                    LocalApplicationId = l.Id,
                    ApplicationId = l.ApplicationId,
                    PersonId = l.Application.PersonId,
                    IssuedLicenseId = _dbContext.Licenses
                        .Where(lic => lic.ApplicationId == l.ApplicationId && lic.LicenseClassId == l.LicenseClassId)
                        .Select(lic => (int?)lic.Id)
                        .FirstOrDefault(),
                    DrivingClass = l.LicenseClass.ClassName,
                    ApplicationDate = l.Application.ApplicationDate,
                    NationalNo = l.Application.Person.NationalNo.Number,
                    PassedTest = l.TestAppointments.Count(d => d.Test != null && d.Test.TestResult == TestResult.Success),
                    StatusId = (int)l.Application.Status,
                    FullName = l.Application.Person.FullName.FirstName + " " + l.Application.Person.FullName.LastName,
                })
                .ToListAsync(cancellationToken);

            var pageResult = new PagedList<GetAllLocalApplicationsResponse>(
                items: items,
                totalCount: totalCount,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize);

            return Result<PagedList<GetAllLocalApplicationsResponse>>.Success(pageResult);
        }
    }
}
