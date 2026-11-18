using DVLD.Contracts.LocalLicenseApplications;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Dashboard
{
    public interface IDashboardView
    {
        event EventHandler? OnViewLoaded;
        event EventHandler? OnViewAllApplicationsClicked;
        event EventHandler<int>? OnOpenApplicationDetailsRequested;

        void SetWelcomeHeader(string displayName, string roleText, string currentDateText);
        void SetKpiMetrics(int totalApplications, int pendingApplications, int completedApplications, int activeUsers);
        void SetPipelineOverview(int awaitingVision, int awaitingWritten, int awaitingStreet, int readyToIssue);
        void SetDepartmentOverview(int cancelledApplications, string completionRateText, string topLicenseClass);
        void DisplayRecentApplications(IEnumerable<GetAllLocalApplicationsResponse> applications);
        void SetLoadingState(bool isLoading);
    }
}
