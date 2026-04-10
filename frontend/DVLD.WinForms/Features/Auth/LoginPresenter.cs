using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public class LoginPresenter
    {
        private  ILoginView _view;
        private readonly IAuthService _authService;
        private readonly AppSession _session;
        private readonly INavigationService _navigationService;

        public LoginPresenter(IAuthService authService, AppSession session,INavigationService navigationService)
        {
            _authService = authService;
            _session = session;
            _navigationService = navigationService;
        }
        public void SetView(ILoginView view)
        {
            _view = view;

            _view.OnLogin += async (s, e) => await LoginAsync();
        }
        public async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(_view.Username) || 
                string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowError("Please enter both username and password.");
                return;
            }

            _view.ShowLoading(true);

            ApiResponse<LoginResponseDto> result = await _authService.LoginAsync(
                _view.Username, _view.Password);

            _view.ShowLoading(false);

            if (!result.IsSuccess || result.Data is null)
            {
                _view.ShowError(result.Error.AllMessages);
                return;
            }

            _session.CurrentToken = result.Data.Token;
            _session.Role = result.Data.Role;
            _session.PersonId = result.Data.PersonId;
            _session.UserId = result.Data.UserId;
            _session.Username = result.Data.Username;

            _navigationService.HideCurrentForm((System.Windows.Forms.Form)_view);
            _navigationService.ShowForm<AdminDashboardForm>();


        }
    }
}
