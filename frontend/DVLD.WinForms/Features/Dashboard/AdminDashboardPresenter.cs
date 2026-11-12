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
            _view.OnAccountSettingsClicked += (s, e) => OpenAccountSettings();

            _view.OnBackClicked += (s, e) => _navigationService.GoBack();
            _view.OnForwardClicked += (s, e) => _navigationService.GoForward();
            _view.OnRefreshClicked += (s, e) => _navigationService.Refresh();

            _navigationService.HistoryChanged += HandleHistoryChanged;
            _navigationService.SetMainContentPanel(_view.MainContentPanel);

            _view.OnLogoutClicked += _view_OnLogoutClicked;

            _refreshTokenService.OnSessionExpired += HandleSessionExpired;

            InitializeCurrentUserBadge();

            if (_view is Form dashboardForm)
            {
                dashboardForm.FormClosed += (s, e) =>
                {
                    _navigationService.HistoryChanged -= HandleHistoryChanged;
                    _refreshTokenService.OnSessionExpired -= HandleSessionExpired;
                };
            }
        }

        private void InitializeCurrentUserBadge()
        {
            if (_view == null) return;

            string displayName = string.IsNullOrWhiteSpace(_session.Username)
                ? "Adam Admin"
                : _session.Username;

            string roleText = _session.IsAdmin ? "● Administrator" : $"● {_session.Role}";

            var parts = displayName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string initials = parts.Length switch
            {
                0 => "AD",
                1 => parts[0].Length >= 2 ? parts[0][..2].ToUpperInvariant() : parts[0].ToUpperInvariant(),
                _ => $"{parts[0][0]}{parts[^1][0]}".ToUpperInvariant()
            };

            _view.SetCurrentUserProfile(displayName, roleText, initials);
        }

        private void OpenAccountSettings()
        {
            _navigationService.NavigateTo<SettingsPresenter, ISettingsView>();
        }

        private void HandleHistoryChanged(object? sender, EventArgs e)
        {
            if (_view == null) return;

            _view.UpdateNavigationButtons(_navigationService.CanGoBack, _navigationService.CanGoForward);

            if (_navigationService.CurrentPresenterType is { } presenterType)
            {
                _view.SyncActivePage(presenterType);
            }
        }

        private void _view_OnLogoutClicked(object? sender, EventArgs e)
        {
            if (_view is not Form dashboardForm || dashboardForm.IsDisposed)
                return;

            var confirm = MessageBox.Show(
                dashboardForm,
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            _session.Logout();

            _navigationService.CloseCurrentForm(dashboardForm);
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
