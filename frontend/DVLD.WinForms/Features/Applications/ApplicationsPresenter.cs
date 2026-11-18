#nullable enable
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication;
using DVLD.WinForms.Features.Applications.DetainedLicenses;
using DVLD.WinForms.Features.Applications.InternationalLicenses;
using DVLD.WinForms.Features.Applications.LocalApplications;
using DVLD.WinForms.Features.Licenses.InternationalPermit;
using DVLD.WinForms.Features.Licenses.RenewLicense;
using DVLD.WinForms.Features.Licenses.ReplaceLicense;
using DVLD.WinForms.Shared;
using System;

namespace DVLD.WinForms.Features.Applications
{
    public class ApplicationsPresenter : BasePresenter<IApplicationsView>
    {
        private readonly LocalApplicationsPresenter _localPresenter;
        private readonly InternationalLicensesPresenter _internationalPresenter;
        private readonly DetainedLicensesPresenter _detainedPresenter;
        private bool _disposed;

        public ApplicationsPresenter(
            IApplicationsView view,
            LocalApplicationsPresenter localPresenter,
            InternationalLicensesPresenter internationalPresenter,
            DetainedLicensesPresenter detainedPresenter,
            AppSession appSession,
            INavigationService navigationService)
            : base(view, appSession, navigationService)
        {
            _localPresenter = localPresenter;
            _internationalPresenter = internationalPresenter;
            _detainedPresenter = detainedPresenter;

            View.OnLoadDataRequested += OnLoadDataRequested;
            View.TabSelectionChanged += OnTabSelectionChanged;
            View.IssueLicenseRequested += OnIssueLicenseRequested;
            View.InternationalLicenseRequested += OnInternationalLicenseRequested;
            View.RenewLicenseRequested += OnRenewLicenseRequested;
            View.ReplaceLicenseRequested += OnReplaceLicenseRequested;
        }

        private async void OnLoadDataRequested(object? sender, EventArgs e)
        {
            await _localPresenter.LoadAsync(1);
        }

        private async void OnTabSelectionChanged(object? sender, int tabIndex)
        {
            if (_disposed) return;

            switch (tabIndex)
            {
                case 0:
                    await _localPresenter.LoadAsync();
                    break;
                case 1:
                    await _internationalPresenter.EnsureLoadedAsync();
                    break;
                case 2:
                    await _detainedPresenter.EnsureLoadedAsync();
                    break;
            }
        }

        private void OnIssueLicenseRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;
            _navigationService.NavigateTo<NewLocalDrivingLicensePresenter, INewLocalDrivingLicenseView>(presenter =>
            {
                presenter.LoadPersonInfoStep();
            });
        }

        private void OnInternationalLicenseRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;
            _navigationService.NavigateTo<InternationalPermitPresenter, IInternationalPermitView>();
        }

        private void OnRenewLicenseRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;
            _navigationService.NavigateTo<RenewLicensePresenter, IRenewLicenseView>();
        }

        private void OnReplaceLicenseRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;
            _navigationService.NavigateTo<ReplaceLicensePresenter, IReplaceLicenseView>();
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            View.OnLoadDataRequested -= OnLoadDataRequested;
            View.TabSelectionChanged -= OnTabSelectionChanged;
            View.IssueLicenseRequested -= OnIssueLicenseRequested;
            View.InternationalLicenseRequested -= OnInternationalLicenseRequested;
            View.RenewLicenseRequested -= OnRenewLicenseRequested;
            View.ReplaceLicenseRequested -= OnReplaceLicenseRequested;

            _localPresenter.Dispose();
            _internationalPresenter.Dispose();
            _detainedPresenter.Dispose();
        }
    }
}
