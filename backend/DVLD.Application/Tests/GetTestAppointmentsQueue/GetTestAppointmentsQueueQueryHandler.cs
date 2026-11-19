using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Tests.GetTestAppointmentsQueue
{
    internal sealed class GetTestAppointmentsQueueQueryHandler
        : IQueryHandler<GetTestAppointmentsQueueQuery, ManageTestAppointmentsQueueResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetTestAppointmentsQueueQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ManageTestAppointmentsQueueResponse>> Handle(
            GetTestAppointmentsQueueQuery request,
            CancellationToken cancellationToken)
        {
            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                return Result<ManageTestAppointmentsQueueResponse>.Failure(pagination.Errors);

            var activeStageCounts = await _dbContext.LocalDrivingLicenseApplications
                .AsNoTracking()
                .Where(l => l.Application.Status == ApplicationStatusEnum.New)
                .Select(l => new
                {
                    PassedCount = l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success)
                })
                .GroupBy(x => x.PassedCount)
                .Select(g => new { PassedCount = g.Key, Count = g.Count() })
                .ToListAsync(cancellationToken);

            int visionCount = activeStageCounts.Where(s => s.PassedCount == 0).Sum(s => s.Count);
            int writtenCount = activeStageCounts.Where(s => s.PassedCount == 1).Sum(s => s.Count);
            int streetCount = activeStageCounts.Where(s => s.PassedCount == 2).Sum(s => s.Count);

            var query = _dbContext.LocalDrivingLicenseApplications.AsNoTracking();

            if (request.StatusFilter is >= 1 and <= 3)
            {
                var status = (ApplicationStatusEnum)request.StatusFilter;
                query = query.Where(l => l.Application.Status == status);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string term = request.SearchTerm.Trim();
                int? searchId = int.TryParse(term, out int parsedId) ? parsedId : null;
                query = query.Where(l =>
                    (searchId.HasValue && l.Id == searchId.Value) ||
                    l.Application.Person.NationalNo.Number.Contains(term) ||
                    (l.Application.Person.FullName.FirstName + " " + l.Application.Person.FullName.LastName).Contains(term));
            }

            query = request.StageFilter switch
            {
                1 => query.Where(l => l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success) == 0),
                2 => query.Where(l => l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success) == 1),
                3 => query.Where(l => l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success) == 2),
                4 => query.Where(l => l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success) >= 3),
                _ => query
            };

            int totalCount = await query.CountAsync(cancellationToken);

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
                    NationalNo = l.Application.Person.NationalNo.Number,
                    FullName = l.Application.Person.FullName.FirstName + " " + l.Application.Person.FullName.LastName,
                    ApplicationDate = l.Application.ApplicationDate,
                    PassedTest = l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success),
                    StatusId = (int)l.Application.Status
                })
                .ToListAsync(cancellationToken);

            var response = new ManageTestAppointmentsQueueResponse
            {
                TotalActiveExamsCount = visionCount + writtenCount + streetCount,
                VisionQueueCount = visionCount,
                WrittenQueueCount = writtenCount,
                StreetQueueCount = streetCount,
                Applications = new PagedList<GetAllLocalApplicationsResponse>(
                    items, totalCount, request.PageNumber, request.PageSize)
            };

            return Result<ManageTestAppointmentsQueueResponse>.Success(response);
        }
    }
}
