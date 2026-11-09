using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Auth;
using System;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Dashboard
{
    public class AdminDashboardPresenter(
        IAuthService authService,
        AppSession session,
        INavigationService navigationService,
        IRefreshTokenService refreshTokenService)
    {
        private IAdminDashboardView? _view;
        private readonly IAuthService _authService = authService;
        private readonly AppSession _session = session;
        private readonly INavigationService _navigationService = navigationService;
        private readonly IRefreshTokenService _refreshTokenService = refreshTokenService;

        public void SetView(IAdminDashboardView view)
        {
            _view = view;
            _view.OnLoadApplicationsClicked += (s, e) => LoadApplicationsControl();
            _navigationService.SetMainContentPanel(_view.MainContentPanel);

            _refreshTokenService.OnSessionExpired += HandleSessionExpired;

            if (_view is Form dashboardForm)
            {
                dashboardForm.FormClosed += (s, e) =>
                {
                    _refreshTokenService.OnSessionExpired -= HandleSessionExpired;
                };
            }
        }

        private void HandleSessionExpired(object? sender, EventArgs e)
        {
            if (_view is not Form dashboardForm || dashboardForm.IsDisposed)
                return;

            if (dashboardForm.InvokeRequired)
            {
                dashboardForm.BeginInvoke(new Action(() => ShowSessionExpiredAndClose(dashboardForm)));
            }
            else
            {
                ShowSessionExpiredAndClose(dashboardForm);
            }
        }

        private void ShowSessionExpiredAndClose(Form dashboardForm)
        {
            if (dashboardForm.IsDisposed)
                return;

            MessageBox.Show(
                dashboardForm,
                "Your session has expired. Please log in again.",
                "Session Expired",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            _navigationService.CloseCurrentForm(dashboardForm);
        }

        public void LoadApplicationsControl()
        {
            _navigationService.NavigateTo<ApplicationsPresenter, IApplicationsView>();
        }
    }
}
