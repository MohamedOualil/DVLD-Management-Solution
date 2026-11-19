using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Dashboard;
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Dashboard.GetDashboardOverview
{
    internal sealed class GetDashboardOverviewQueryHandler : IQueryHandler<GetDashboardOverviewQuery, DashboardOverviewResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetDashboardOverviewQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<DashboardOverviewResponse>> Handle(
            GetDashboardOverviewQuery request,
            CancellationToken cancellationToken)
        {
            var localApps = _dbContext.LocalDrivingLicenseApplications.AsNoTracking();

            var statusCounts = await localApps
                .GroupBy(l => l.Application.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync(cancellationToken);

            int pendingApplications = statusCounts
                .Where(s => s.Status == ApplicationStatusEnum.New)
                .Sum(s => s.Count);

            int completedApplications = statusCounts
                .Where(s => s.Status == ApplicationStatusEnum.Completed)
                .Sum(s => s.Count);

            int cancelledApplications = statusCounts
                .Where(s => s.Status == ApplicationStatusEnum.Cancelled)
                .Sum(s => s.Count);

            int totalApplications = pendingApplications + completedApplications + cancelledApplications;

            int activeSystemOperators = await _dbContext.Users
                .AsNoTracking()
                .CountAsync(u => u.IsActive, cancellationToken);

            var activeStageCounts = await localApps
                .Where(l => l.Application.Status == ApplicationStatusEnum.New)
                .Select(l => new
                {
                    PassedCount = l.TestAppointments.Count(t => t.Test != null && t.Test.TestResult == TestResult.Success)
                })
                .GroupBy(x => x.PassedCount)
                .Select(g => new { PassedCount = g.Key, Count = g.Count() })
                .ToListAsync(cancellationToken);

            int awaitingVisionCount = activeStageCounts.Where(s => s.PassedCount == 0).Sum(s => s.Count);
            int awaitingWrittenCount = activeStageCounts.Where(s => s.PassedCount == 1).Sum(s => s.Count);
            int awaitingStreetCount = activeStageCounts.Where(s => s.PassedCount == 2).Sum(s => s.Count);
            int readyToIssueCount = activeStageCounts.Where(s => s.PassedCount >= 3).Sum(s => s.Count);

            string topLicenseClassName = await localApps
                .GroupBy(l => l.LicenseClass.ClassName)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync(cancellationToken) ?? "N/A";

            double completionRatePercent = totalApplications > 0
                ? Math.Round(completedApplications * 100.0 / totalApplications, 1)
                : 0.0;

            var recentApplications = await localApps
                .OrderByDescending(l => l.Application.ApplicationDate)
                .ThenByDescending(l => l.Id)
                .Take(8)
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

            var response = new DashboardOverviewResponse
            {
                TotalApplications = totalApplications,
                PendingApplications = pendingApplications,
                CompletedApplications = completedApplications,
                ActiveSystemOperators = activeSystemOperators,
                AwaitingVisionCount = awaitingVisionCount,
                AwaitingWrittenCount = awaitingWrittenCount,
                AwaitingStreetCount = awaitingStreetCount,
                ReadyToIssueCount = readyToIssueCount,
                CancelledApplications = cancelledApplications,
                CompletionRatePercent = completionRatePercent,
                TopLicenseClassName = topLicenseClassName,
                RecentApplications = recentApplications
            };

            return Result<DashboardOverviewResponse>.Success(response);
        }
    }
}
