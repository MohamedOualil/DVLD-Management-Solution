using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications
{
    public class ApplicationsPresenter(IApplicationsService applicationsService, AppSession session, INavigationService navigationService)
    {
        private IApplicationsView? _view;
        private readonly IApplicationsService _applicationsService = applicationsService;
        private readonly AppSession _session = session;
        private readonly INavigationService _navigationService = navigationService;

        public void SetView(IApplicationsView view)
        {
            _view = view;
            _view.OnLoadDataRequested += async (s, e) => await LoadDataAsync();
            _view.OnSearchChangeRequested += async (s, e) => await LoadDataAsync();
            _view.OnOpeningLocalAppActionMenu += _view_OnOpeningLocalAppActionMenu;
        }

        private void _view_OnOpeningLocalAppActionMenu(object? sender, ApplicationMenuEventArgs e)
        {
            _view.IsEditOptionEnabled = false;
            _view.IsDeleteOptionEnabled = false;
            _view.IsCancelOptionEnabled = false;
            _view.IsScheduleTestOptionEnabled = false;
            _view.IsIssueLicenseOptionEnabled = false;
            _view.IsShowLicenceOptionEnabled = false;

            _view.IsScheduleVisionTestEnabled = false;
            _view.IsScheduleWrittenTestEnabled = false;
            _view.IsScheduleStreetTestEnabled = false;


            switch (e.Status)
            {
                case Shared.Enums.ApplicationStatusEnum.Cancelled:
                    break;

                case Shared.Enums.ApplicationStatusEnum.Completed:
                    _view.IsShowLicenceOptionEnabled = true;
                    break;

                case Shared.Enums.ApplicationStatusEnum.New:
                    _view.IsEditOptionEnabled = true;
                    _view.IsDeleteOptionEnabled = true;
                    _view.IsCancelOptionEnabled = true;
                    _view.IsScheduleTestOptionEnabled = true;
                    HandleTestMenuPermissions(e.PassedTests);
                    break;
            }

        }

        private void HandleTestMenuPermissions(PassedTestEnum passedTests)
        {
            switch (passedTests)
            {
                case Shared.Enums.PassedTestEnum.NoTestPass:
                    _view.IsScheduleVisionTestEnabled = true;
                    break;

                case Shared.Enums.PassedTestEnum.VisionPass:
                    _view.IsScheduleWrittenTestEnabled = true;
                    break;

                case Shared.Enums.PassedTestEnum.VisionWritingPass:
                    _view.IsScheduleStreetTestEnabled = true;
                    break;

                case Shared.Enums.PassedTestEnum.PassAllTest:
                    _view.IsIssueLicenseOptionEnabled = true;
                    break;
            }
        }

        private async Task LoadDataAsync()
        {

            var applications = await _applicationsService.GetAllLocalApplicationsAsync(1, 10,
                                                        _view.SearchTerm,
                                                        _view.cbStatusId);
            if (!applications.IsSuccess)
            {
                return;
            }

            if (applications.Data.TotalCount == 0)
            {
                _view.DisplayMessage(applications.Error.AllMessages);
                return;
            }

            _view.DisplayLocalApplications(applications.Data.Items);
        }

       
    }
}
