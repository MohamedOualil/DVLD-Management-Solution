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
        event EventHandler? OnLoadDashboardClicked;
        event EventHandler OnLoadApplicationsClicked;
        event EventHandler? OnNewApplicationRequested;
        event EventHandler? OnAccountSettingsClicked;
        event EventHandler? OnTestAppointmentsClicked;
        event EventHandler? OnRenewLicenseClicked;
        event EventHandler? OnReplaceLicenseClicked;
        event EventHandler? OnDetainReleaseClicked;
        event EventHandler? OnInternationalLicenseClicked;
        event EventHandler? OnPeopleDirectoryClicked;
        event EventHandler? OnDriversDirectoryClicked;
        event EventHandler? OnUsersManagementClicked;
        event EventHandler? OnServiceFeesClicked;
        event EventHandler? OnAuditLogsClicked;
        event EventHandler? OnLogoutClicked;
        event EventHandler? OnBackClicked;
        event EventHandler? OnForwardClicked;
        event EventHandler? OnRefreshClicked;

        void SetCurrentUserProfile(string displayName, string roleText, string initials);
        void ApplyRolePermissions(bool isAdmin);
        void UpdateNavigationButtons(bool canGoBack, bool canGoForward);
        void SyncActivePage(Type presenterType);
    }
}
