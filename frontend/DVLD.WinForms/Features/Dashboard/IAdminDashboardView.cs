using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Dashboard
{
    public interface IAdminDashboardView
    {
        Control MainContentPanel { get; }
        event EventHandler OnLoadApplicationsClicked;
        event EventHandler? OnLogoutClicked;
        event EventHandler? OnBackClicked;
        event EventHandler? OnForwardClicked;
        event EventHandler? OnRefreshClicked;

        void UpdateNavigationButtons(bool canGoBack, bool canGoForward);
        void SyncActivePage(Type presenterType);
    }
}
