using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Dashboard;

namespace DVLD.Application.Dashboard.GetDashboardOverview
{
    public sealed record GetDashboardOverviewQuery() : IQuery<DashboardOverviewResponse>;
}
