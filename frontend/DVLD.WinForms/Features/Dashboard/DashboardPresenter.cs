using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Settings;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Dashboard
{
    public class DashboardPresenter : BasePresenter<IDashboardView>
    {
        private readonly IApplicationsService _applicationsService;
        private readonly ISettingsService _settingsService;
        private bool _disposed;

        public DashboardPresenter(
            IDashboardView view,
            IApplicationsService applicationsService,
            ISettingsService settingsService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _applicationsService = applicationsService;
            _settingsService = settingsService;

            View.OnViewLoaded += View_OnViewLoaded;
            View.OnViewAllApplicationsClicked += View_OnViewAllApplicationsClicked;
            View.OnOpenApplicationDetailsRequested += View_OnOpenApplicationDetailsRequested;
        }

        private async void View_OnViewLoaded(object? sender, EventArgs e)
        {
            if (_disposed) return;

            string displayName = string.IsNullOrWhiteSpace(_session.Username)
                ? "Administrator"
                : _session.Username;
            string roleText = _session.IsAdmin ? "Administrator" : _session.Role.ToString();
            string dateText = DateTime.Now.ToString("ddd, MMM dd, yyyy");

            View.SetWelcomeHeader(displayName, roleText, dateText);

            await LoadOverviewDataAsync();
        }

        private async Task LoadOverviewDataAsync()
        {
            if (_disposed) return;

            View.SetLoadingState(true);

            int totalApplications = 0;
            int pendingApplications = 0;
            int completedApplications = 0;
            int cancelledApplications = 0;
            int activeUsers = 1;

            int awaitingVision = 0;
            int awaitingWritten = 0;
            int awaitingStreet = 0;
            int readyToIssue = 0;
            string topLicenseClass = "—";

            try
            {
                var recentTask = _applicationsService.GetAllLocalApplicationsAsync(1, 50, string.Empty, 0);
                var pendingTask = _applicationsService.GetAllLocalApplicationsAsync(1, 1, string.Empty, (int)ApplicationStatusEnum.New);
                var completedTask = _applicationsService.GetAllLocalApplicationsAsync(1, 1, string.Empty, (int)ApplicationStatusEnum.Completed);
                var cancelledTask = _applicationsService.GetAllLocalApplicationsAsync(1, 1, string.Empty, (int)ApplicationStatusEnum.Cancelled);
                var usersTask = _settingsService.GetUsersListAsync(1, 1, null, true);

                await Task.WhenAll(recentTask, pendingTask, completedTask, cancelledTask, usersTask);

                if (_disposed) return;

                var recentResponse = recentTask.Result;
                if (recentResponse.IsSuccess && recentResponse.Data != null)
                {
                    totalApplications = recentResponse.Data.TotalCount;
                    var items = recentResponse.Data.Items ?? Array.Empty<GetAllLocalApplicationsResponse>();
                    View.DisplayRecentApplications(items.Take(8));

                    var activeApps = items.Where(a => a.StatusId == (int)ApplicationStatusEnum.New).ToList();
                    awaitingVision = activeApps.Count(a => a.PassedTest == 0);
                    awaitingWritten = activeApps.Count(a => a.PassedTest == 1);
                    awaitingStreet = activeApps.Count(a => a.PassedTest == 2);
                    readyToIssue = activeApps.Count(a => a.PassedTest >= 3);

                    topLicenseClass = ExtractTopLicenseClass(items);
                }
                else
                {
                    View.DisplayRecentApplications(Array.Empty<GetAllLocalApplicationsResponse>());
                }

                var pendingResponse = pendingTask.Result;
                if (pendingResponse.IsSuccess && pendingResponse.Data != null)
                    pendingApplications = pendingResponse.Data.TotalCount;

                var completedResponse = completedTask.Result;
                if (completedResponse.IsSuccess && completedResponse.Data != null)
                    completedApplications = completedResponse.Data.TotalCount;

                var cancelledResponse = cancelledTask.Result;
                if (cancelledResponse.IsSuccess && cancelledResponse.Data != null)
                    cancelledApplications = cancelledResponse.Data.TotalCount;

                var usersResponse = usersTask.Result;
                if (usersResponse.IsSuccess && usersResponse.Data != null)
                    activeUsers = usersResponse.Data.TotalCount;
            }
            catch
            {
                if (!_disposed)
                    View.DisplayRecentApplications(Array.Empty<GetAllLocalApplicationsResponse>());
            }
            finally
            {
                if (!_disposed)
                {
                    string completionRateText = totalApplications > 0
                        ? $"{(int)Math.Round(completedApplications * 100.0 / totalApplications)}% ({completedApplications}/{totalApplications})"
                        : "0%";

                    View.SetKpiMetrics(totalApplications, pendingApplications, completedApplications, activeUsers);
                    View.SetPipelineOverview(awaitingVision, awaitingWritten, awaitingStreet, readyToIssue);
                    View.SetDepartmentOverview(cancelledApplications, completionRateText, topLicenseClass);
                    View.SetLoadingState(false);
                }
            }
        }

        private static string ExtractTopLicenseClass(IReadOnlyCollection<GetAllLocalApplicationsResponse> items)
        {
            var top = items
                .Where(a => !string.IsNullOrWhiteSpace(a.DrivingClass))
                .GroupBy(a => a.DrivingClass.Trim())
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(top))
                return "—";

            const string classPrefix = "Class ";
            if (top.StartsWith(classPrefix, StringComparison.OrdinalIgnoreCase))
            {
                int dashIndex = top.IndexOf(" - ", StringComparison.Ordinal);
                if (dashIndex > 0 && dashIndex + 3 < top.Length)
                    return top[(dashIndex + 3)..].Trim();
            }

            return top;
        }

        private void View_OnViewAllApplicationsClicked(object? sender, EventArgs e)
        {
            if (_disposed) return;

            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }

        private void View_OnOpenApplicationDetailsRequested(object? sender, int localApplicationId)
        {
            if (_disposed || localApplicationId <= 0) return;

            _navigationService.NavigateTo<ApplicationDetailPresenter, IApplicationDetailView>(async presenter =>
            {
                await presenter.LoadApplicationDetails(localApplicationId, StatusMode.ViewMode);
            });
        }

        public override void Dispose()
        {
            _disposed = true;
            View.OnViewLoaded -= View_OnViewLoaded;
            View.OnViewAllApplicationsClicked -= View_OnViewAllApplicationsClicked;
            View.OnOpenApplicationDetailsRequested -= View_OnOpenApplicationDetailsRequested;
        }
    }
}
