#nullable enable
using DVLD.WinForms.Features.Applications.DetainedLicenses;
using DVLD.WinForms.Features.Applications.InternationalLicenses;
using DVLD.WinForms.Features.Applications.LocalApplications;
using System;

namespace DVLD.WinForms.Features.Applications
{
    public interface IApplicationsView
    {
        event EventHandler? OnLoadDataRequested;
        event EventHandler<int>? TabSelectionChanged;
        event EventHandler? IssueLicenseRequested;
        event EventHandler? InternationalLicenseRequested;
        event EventHandler? RenewLicenseRequested;
        event EventHandler? ReplaceLicenseRequested;

        ILocalApplicationsTabView LocalApplicationsView { get; }
        IInternationalLicensesTabView InternationalLicensesView { get; }
        IDetainedLicensesTabView DetainedLicensesView { get; }
    }
}
