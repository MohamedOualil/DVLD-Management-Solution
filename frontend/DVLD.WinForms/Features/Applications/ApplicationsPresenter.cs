using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Dashboard;
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
        }

        public async Task LoadDataAsync()
        {
            var applications = await _applicationsService.GetAllLocalApplicationsAsync(1, 10,string.Empty,1);
            if (!applications.IsSuccess)
            {

            }

            //if (applications.Data.TotalCount == 0)
            //{

            //}

            _view.DisplayLocalApplications(applications.Data.Items);
        }
    }
}
