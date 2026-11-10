using DVLD.Contracts.Auth;
using DVLD.Contracts.Enums;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Dashboard;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public class LoginPresenter
    {
        private ILoginView? _view;
        private readonly IAuthService _authService;
        private readonly AppSession _session;
        private readonly INavigationService _navigationService;
        private readonly IRememberMeService _rememberMeService;

        public LoginPresenter(
            IAuthService authService,
            AppSession session,
            INavigationService navigationService,
            IRememberMeService? rememberMeService = null)
        {
            _authService = authService;
            _session = session;
            _navigationService = navigationService;
            _rememberMeService = rememberMeService ?? new RememberMeService();
        }

        public void SetView(ILoginView view)
        {
            _view = view;

            _view.OnLogin += async (s, e) => await LoginAsync();
            _view.OnViewLoaded += (s, e) => LoadRememberedCredentials();

            LoadRememberedCredentials();
        }

        public void LoadRememberedCredentials()
        {
            if (_view == null)
            {
                return;
            }

            var credentials = _rememberMeService.GetStoredCredentials();
            if (credentials.HasValue && !string.IsNullOrWhiteSpace(credentials.Value.Username))
            {
                _view.Username = credentials.Value.Username;
                _view.Password = credentials.Value.Password;
                _view.RememberMe = true;
            }
            else
            {
                _view.Username = string.Empty;
                _view.Password = string.Empty;
                _view.RememberMe = false;
            }
        }

        public async Task LoginAsync()
        {
            if (_view == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Username) ||
                string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowError("Please enter both username and password.");
                return;
            }

            _view.ShowLoading(true);

            ApiResponse<LoginResponse> result = await _authService.LoginAsync(
                _view.Username, _view.Password);

            _view.ShowLoading(false);

            if (!result.IsSuccess || result.Data is null)
            {
                _view.ShowError(result.Error?.AllMessages ?? "Login failed.");
                return;
            }

            if (_view.RememberMe)
            {
                _rememberMeService.SaveCredentials(_view.Username, _view.Password);
            }
            else
            {
                _rememberMeService.ClearCredentials();
            }

            _session.UpdateTokens(result.Data.Token);
            _session.Role = result.Data.Role;
            _session.PersonId = result.Data.PersonId;
            _session.UserId = result.Data.UserId;
            _session.Username = result.Data.Username;

            var loginForm = (System.Windows.Forms.Form)_view;
            _navigationService.HideCurrentForm(loginForm);
            _navigationService.ShowForm<AdminDashboardForm>();

            if (!_session.IsLoggedIn && !loginForm.IsDisposed)
            {
                LoadRememberedCredentials();
                loginForm.Show();
            }
            else if (!loginForm.IsDisposed)
            {
                _navigationService.CloseCurrentForm(loginForm);
            }
        }
    }
}
