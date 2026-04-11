using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.WinForms.Features.Applications;

namespace DVLD.WinForms.Features.Dashboard
{
    public class AdminDashboardPresenter(IAuthService authService, AppSession session, INavigationService navigationService)
    {
        private IAdminDashboardView? _view;
        private readonly IAuthService _authService = authService;
        private readonly AppSession _session = session;
        private readonly INavigationService _navigationService = navigationService;

        public void SetView(IAdminDashboardView view)
        {
            _view = view;
            _view.OnLoadApplicationsClicked += (s,e) => LoadApplicationsControl();
        }

        public void LoadApplicationsControl()
        {
            _navigationService.NavigateTo<ApplicationsControl>();
        }
    }
}
