using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications
{
    public class ApplicationsPresenter : BasePresenter<IApplicationsView>
    {

        private readonly IApplicationsService _applicationsService ;


        public ApplicationsPresenter(
            IApplicationsView view, 
            IApplicationsService service,
            AppSession appSession,
            INavigationService navigationService) 
            : base(view,appSession,navigationService)
        {
            _applicationsService = service;

            View.OnLoadDataRequested += View_OnLoadDataRequested; ;
            View.OnSearchChangeRequested += View_OnLoadDataRequested;
            View.OnOpeningLocalAppActionMenu += _view_OnOpeningLocalAppActionMenu;
            View.OnApplicationDetailsRequested += View_OnApplicationDetailsRequested;

            View.OnCancelApplication += View_OnCancelApplication;
            View.OnDeleteApplication += View_OnDeleteApplication;
            View.IssueLicenseRequested += View_IssueLicenseRequested;
        }

        private void View_IssueLicenseRequested(object? sender, EventArgs e)
        {
            _navigationService.NavigateTo<NewLocalDrivingLicensePresenter, INewLocalDrivingLicenseView>(presenter =>
            {
                presenter.LoadPersonInfoStep();
            });
        }

        private void View_OnDeleteApplication(object? sender, int e)
        {
            throw new NotImplementedException();
        }

        private async Task DeleteApplication(int localId)
        {
            ApiResponse result =
                await _applicationsService.DeleteApplication(localId);

            if (result.IsSuccess)
            {
                await LoadDataAsync();
            }
        }

        private async void View_OnCancelApplication(object? sender, int e)
        {
            await CancelApplication(e);
        }

        private async Task CancelApplication(int applicationId)
        {
            ApiResponse result =
                await _applicationsService.CancelApplication(applicationId, _session.UserId);

            if (result.IsSuccess)
            {
                await LoadDataAsync();
            }
        }

        private async void View_OnLoadDataRequested(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void View_OnApplicationDetailsRequested(object? sender, PageModeEventArgs e)
        {
            _navigationService.NavigateTo<ApplicationDetailPresenter, IApplicationDetailView>(presenter =>
            {
                presenter.LoadApplicationDetails(e.Id,e.Mode);
            });
        }

        private void _view_OnOpeningLocalAppActionMenu(object? sender, ApplicationMenuEventArgs e)
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
                case Shared.Enums.ApplicationStatusEnum.Cancelled:
                    break;

                case Shared.Enums.ApplicationStatusEnum.Completed:
                    View.IsShowLicenceOptionEnabled = true;
                    break;

                case Shared.Enums.ApplicationStatusEnum.New:
                    View.IsEditOptionEnabled = true;
                    View.IsDeleteOptionEnabled = true;
                    View.IsCancelOptionEnabled = true;
                    View.IsScheduleTestOptionEnabled = true;
                    HandleTestMenuPermissions(e.PassedTests);
                    break;
            }

        }

        private void HandleTestMenuPermissions(PassedTestEnum passedTests)
        {
            switch (passedTests)
            {
                case Shared.Enums.PassedTestEnum.NoTestPass:
                    View.IsScheduleVisionTestEnabled = true;
                    break;

                case Shared.Enums.PassedTestEnum.VisionPass:
                    View.IsScheduleWrittenTestEnabled = true;
                    break;

                case Shared.Enums.PassedTestEnum.VisionWritingPass:
                    View.IsScheduleStreetTestEnabled = true;
                    break;

                case Shared.Enums.PassedTestEnum.PassAllTest:
                    View.IsIssueLicenseOptionEnabled = true;
                    break;
            }
        }

        private async Task LoadDataAsync()
        {

            var applications = await _applicationsService.GetAllLocalApplicationsAsync(1, 10,
                                                        View.SearchTerm,
                                                        View.cbStatusId);
            if (!applications.IsSuccess)
            {
                return;
            }

            if (applications.Data.TotalCount == 0)
            {
                View.DisplayMessage(applications.Error.AllMessages);
                return;
            }

            View.DisplayLocalApplications(applications.Data.Items);
        }

        public override void Dispose()
        {
            View.OnLoadDataRequested -= View_OnLoadDataRequested; ;
            View.OnSearchChangeRequested -= View_OnLoadDataRequested;
            View.OnOpeningLocalAppActionMenu -= _view_OnOpeningLocalAppActionMenu;
            View.OnApplicationDetailsRequested -= View_OnApplicationDetailsRequested;
        }
    }
}
