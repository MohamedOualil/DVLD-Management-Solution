using DVLD.Contracts.LocalLicenseApplications;
using System.Collections.Generic;

namespace DVLD.Contracts.Dashboard
{
    public sealed record DashboardOverviewResponse
    {
        // 4 Top KPI Cards
        public int TotalApplications { get; init; }
        public int PendingApplications { get; init; }
        public int CompletedApplications { get; init; }
        public int ActiveSystemOperators { get; init; }

        // Examination Pipeline Overview Card
        public int AwaitingVisionCount { get; init; }
        public int AwaitingWrittenCount { get; init; }
        public int AwaitingStreetCount { get; init; }
        public int ReadyToIssueCount { get; init; }

        // Department Overview Card
        public int CancelledApplications { get; init; }
        public double CompletionRatePercent { get; init; }
        public string TopLicenseClassName { get; init; } = string.Empty;

        // Top Recent Applications Table
        public IReadOnlyList<GetAllLocalApplicationsResponse> RecentApplications { get; init; } = [];
    }
}
