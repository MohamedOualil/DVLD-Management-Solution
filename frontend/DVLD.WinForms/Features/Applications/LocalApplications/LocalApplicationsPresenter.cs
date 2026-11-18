#nullable enable
using DVLD.Contracts.Enums;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Applications.IssueDrivingLicence;
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Features.Licenses.LicenseHistory;
using DVLD.WinForms.Features.Tests.Appointments;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.LocalApplications
{
    public class LocalApplicationsPresenter : BasePresenter<ILocalApplicationsTabView>
    {
        private const int PageSize = 10;

        private readonly IApplicationsService _applicationsService;
        private readonly ILicensesService _licensesService;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int _loadVersion;
        private bool _loadingLicence;
        private bool _disposed;

        public LocalApplicationsPresenter(
            ILocalApplicationsTabView view,
            IApplicationsService applicationsService,
            ILicensesService licensesService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _applicationsService = applicationsService;
            _licensesService = licensesService;

            View.SearchOrFilterChanged += OnSearchOrFilterChanged;
            View.PageRequested += OnPageRequested;
            View.OpeningActionMenu += OnOpeningActionMenu;
            View.ApplicationDetailsRequested += OnApplicationDetailsRequested;
            View.CancelApplicationRequested += OnCancelApplicationRequested;
            View.DeleteApplicationRequested += OnDeleteApplicationRequested;
            View.ScheduleTestRequested += OnScheduleTestRequested;
            View.IssueDrivingLicenceRequested += OnIssueDrivingLicenceRequested;
            View.ShowLicenceRequested += OnShowLicenceRequested;
            View.LicenseHistoryRequested += OnLicenseHistoryRequested;
        }

        public async Task LoadAsync(int? requestedPage = null)
        {
            if (_disposed) return;

            int pageToLoad = requestedPage ?? _currentPage;
            int thisLoad = ++_loadVersion;
            string searchTerm = View.SearchTerm;
            int statusId = View.StatusFilterId;
            View.SetPaginationLoading(true);

            try
            {
                while (true)
                {
                    var applications = await _applicationsService.GetAllLocalApplicationsAsync(
                        pageToLoad, PageSize, searchTerm, statusId);

                    if (_disposed || thisLoad != _loadVersion)
                        return;

                    if (!applications.IsSuccess || applications.Data is null)
                    {
                        View.DisplayMessage(applications.Error?.AllMessages ?? "Could not load applications.");
                        return;
                    }

                    var data = applications.Data;
                    int availablePages = Math.Max(1, data.TotalPages);
                    if (pageToLoad > availablePages)
                    {
                        pageToLoad = availablePages;
                        continue;
                    }

                    _currentPage = pageToLoad;
                    _totalPages = availablePages;
                    View.DisplayLocalApplications(data.Items);
                    View.DisplayPagination(_currentPage, _totalPages, data.TotalCount);

                    if (data.TotalCount == 0)
                        View.DisplayMessage("No applications found.");

                    return;
                }
            }
            catch
            {
                if (!_disposed && thisLoad == _loadVersion)
                    View.DisplayMessage("Could not load applications. Please try again.");
            }
            finally
            {
                if (!_disposed && thisLoad == _loadVersion)
                    View.SetPaginationLoading(false);
            }
        }

        private async void OnSearchOrFilterChanged(object? sender, EventArgs e)
        {
            await LoadAsync(1);
        }

        private async void OnPageRequested(object? sender, int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > _totalPages)
                return;

            await LoadAsync(pageNumber);
        }

        private void OnOpeningActionMenu(object? sender, ApplicationMenuEventArgs e)
        {
            View.IsEditOptionEnabled = false;
            View.IsDeleteOptionEnabled = false;
            View.IsCancelOptionEnabled = false;
            View.IsScheduleTestOptionEnabled = false;
            View.IsIssueLicenseOptionEnabled = false;
            View.IsShowLicenceOptionEnabled = false;
            View.IsScheduleVisionTestEnabled = false;
            View.IsScheduleWrittenTestEnabled = false;
            View.IsScheduleStreetTestEnabled = false;

            switch (e.Status)
            {
                case ApplicationStatusEnum.Cancelled:
                    break;

                case ApplicationStatusEnum.Completed:
                    View.IsShowLicenceOptionEnabled = true;
                    break;

                case ApplicationStatusEnum.New:
                    View.IsEditOptionEnabled = true;
                    View.IsDeleteOptionEnabled = true;
                    View.IsCancelOptionEnabled = true;
                    View.IsScheduleTestOptionEnabled = true;
                    ApplyTestMenuPermissions(e.PassedTests);
                    break;
            }
        }

        private void ApplyTestMenuPermissions(PassedTestEnum passedTests)
        {
            switch (passedTests)
            {
                case PassedTestEnum.NoTestPass:
                    View.IsScheduleVisionTestEnabled = true;
                    break;
                case PassedTestEnum.VisionPass:
                    View.IsScheduleWrittenTestEnabled = true;
                    break;
                case PassedTestEnum.VisionWritingPass:
                    View.IsScheduleStreetTestEnabled = true;
                    break;
                case PassedTestEnum.PassAllTest:
                    View.IsIssueLicenseOptionEnabled = true;
                    break;
            }
        }

        private void OnApplicationDetailsRequested(object? sender, PageModeEventArgs e)
        {
            _navigationService.NavigateTo<ApplicationDetailPresenter, IApplicationDetailView>(async presenter =>
            {
                await presenter.LoadApplicationDetails(e.Id, e.Mode);
            });
        }

        private async void OnCancelApplicationRequested(object? sender, int applicationId)
        {
            if (_disposed || applicationId <= 0) return;

            var result = await _applicationsService.CancelApplication(applicationId);
            if (!_disposed && result.IsSuccess)
                await LoadAsync();
        }

        private async void OnDeleteApplicationRequested(object? sender, int localId)
        {
            if (_disposed || localId <= 0) return;

            var confirm = MessageBox.Show(
                $"Delete local driving license application #{localId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            var result = await _applicationsService.DeleteApplication(localId);
            if (_disposed) return;

            if (result.IsSuccess)
                await LoadAsync();
            else
                View.DisplayMessage(result.Error?.AllMessages ?? "Unable to delete the application.");
        }

        private void OnScheduleTestRequested(object? sender, ScheduleTestEventArgs e)
        {
            _navigationService.NavigateTo<ListTestAppointmentsPresenter, IListTestAppointmentsView>(async presenter =>
            {
                await presenter.LoadTestAppointementsAsync(e.LocalApplicationId, e.TestTypeEnum);
            });
        }

        private void OnIssueDrivingLicenceRequested(object? sender, int localApplicationId)
        {
            _navigationService.NavigateTo<IssueDrivingLicencePresenter, IIssueDrivingLicenceView>(async presenter =>
            {
                await presenter.LoadAsync(localApplicationId);
            });
        }

        private async void OnShowLicenceRequested(object? sender, int localApplicationId)
        {
            if (_disposed || _loadingLicence || localApplicationId <= 0)
                return;

            _loadingLicence = true;
            try
            {
                var response = await _licensesService.GetLicenseByLocalApplicationIdAsync(localApplicationId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                    _navigationService.ShowDialog<LicenseCardForm>(form => form.DisplayLicense(response.Data));
                else
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load licence details.");
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load licence details. Please try again.");
            }
            finally
            {
                _loadingLicence = false;
            }
        }

        private async void OnLicenseHistoryRequested(object? sender, int localApplicationId)
        {
            if (_disposed || _loadingLicence || localApplicationId <= 0)
                return;

            _loadingLicence = true;
            try
            {
                var response = await _applicationsService.GetApplicationDetails(localApplicationId);
                if (_disposed) return;

                if (!response.IsSuccess || response.Data is null || response.Data.PersonId <= 0)
                {
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to resolve applicant details for license history.");
                    return;
                }

                int personId = response.Data.PersonId;
                _navigationService.NavigateTo<LicenseHistoryPresenter, ILicenseHistoryView>(async presenter =>
                {
                    await presenter.LoadAsync(personId);
                });
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to open license history. Please try again.");
            }
            finally
            {
                _loadingLicence = false;
            }
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            ++_loadVersion;

            View.SearchOrFilterChanged -= OnSearchOrFilterChanged;
            View.PageRequested -= OnPageRequested;
            View.OpeningActionMenu -= OnOpeningActionMenu;
            View.ApplicationDetailsRequested -= OnApplicationDetailsRequested;
            View.CancelApplicationRequested -= OnCancelApplicationRequested;
            View.DeleteApplicationRequested -= OnDeleteApplicationRequested;
            View.ScheduleTestRequested -= OnScheduleTestRequested;
            View.IssueDrivingLicenceRequested -= OnIssueDrivingLicenceRequested;
            View.ShowLicenceRequested -= OnShowLicenceRequested;
            View.LicenseHistoryRequested -= OnLicenseHistoryRequested;
        }
    }
}
