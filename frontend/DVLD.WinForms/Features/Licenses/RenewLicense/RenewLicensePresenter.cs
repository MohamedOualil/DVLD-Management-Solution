#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Licenses.RenewLicense
{
    public class RenewLicensePresenter : BasePresenter<IRenewLicenseView>
    {
        private const decimal RenewalApplicationFee = 7.00m;
        private const decimal DefaultLicenseFee = 20.00m;

        private readonly ILicensesService _licensesService;
        private GetLicenseResponse? _currentLicense;
        private bool _eligible;
        private bool _disposed;

        public RenewLicensePresenter(
            IRenewLicenseView view,
            ILicensesService licensesService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _licensesService = licensesService;

            View.FindLicenseRequested += OnFindLicenseRequested;
            View.ViewLicenseCardRequested += OnViewLicenseCardRequested;
            View.RenewRequested += OnRenewRequested;
            View.ResetRequested += OnResetRequested;

            View.ResetView();
            View.DisplayRenewalSummary(DateTime.Today, DateTime.Today.AddYears(10), RenewalApplicationFee, DefaultLicenseFee, _session.Username);
        }

        private async void OnFindLicenseRequested(object? sender, int licenseId)
        {
            if (_disposed) return;

            _currentLicense = null;
            _eligible = false;
            View.SetSearching(true);

            try
            {
                var response = await _licensesService.GetLicenseAsync(licenseId);
                if (_disposed) return;

                if (!response.IsSuccess || response.Data is null)
                {
                    View.SetEligibility(
                        false,
                        "License Not Found",
                        response.Error?.AllMessages ?? $"No local driving license found with ID #{licenseId}.",
                        HeaderBadgeTone.Danger);
                    return;
                }

                var license = response.Data;
                _currentLicense = license;
                View.DisplayLicense(license);
                View.DisplayRenewalSummary(DateTime.Today, DateTime.Today.AddYears(10), RenewalApplicationFee, DefaultLicenseFee, _session.Username);

                if (!license.IsActive)
                {
                    View.SetEligibility(false, "License Inactive", "Only active licences can be renewed.", HeaderBadgeTone.Danger);
                }
                else if (license.IsDetained)
                {
                    View.SetEligibility(false, "License Detained", "Release this detained licence before attempting a renewal.", HeaderBadgeTone.Warning);
                }
                else if (license.ExpirationDate.Date > DateTime.Today)
                {
                    View.SetEligibility(
                        false,
                        "Not Expired Yet",
                        $"License #{license.LicenseId} is still valid until {license.ExpirationDate:dd MMM yyyy}.",
                        HeaderBadgeTone.Warning);
                }
                else
                {
                    _eligible = true;
                    View.SetEligibility(
                        true,
                        "Eligible for Renewal",
                        $"License #{license.LicenseId} expired on {license.ExpirationDate:dd MMM yyyy} and is cleared for renewal.",
                        HeaderBadgeTone.Success);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(false, "Connection Error", "Unable to retrieve license details. Check your API connection.", HeaderBadgeTone.Danger);
            }
            finally
            {
                if (!_disposed)
                    View.SetSearching(false);
            }
        }

        private void OnViewLicenseCardRequested(object? sender, GetLicenseResponse license)
        {
            if (!_disposed)
                _navigationService.ShowDialog<LicenseCardForm>(form => form.DisplayLicense(license));
        }

        private async void OnRenewRequested(object? sender, EventArgs e)
        {
            if (_disposed || !_eligible || _currentLicense is null)
                return;

            View.SetSubmitting(true);
            try
            {
                var response = await _licensesService.RenewLicenseAsync(_currentLicense.LicenseId, View.Notes);
                if (_disposed) return;

                if (response.IsSuccess && response.Data > 0)
                {
                    _eligible = false;
                    View.DisplayRenewalSummary(DateTime.Today, DateTime.Today.AddYears(10), RenewalApplicationFee, DefaultLicenseFee, _session.Username, response.Data);
                    View.SetEligibility(false, "License Renewed Successfully", $"New License #{response.Data} has been issued and old license #{_currentLicense.LicenseId} deactivated.", HeaderBadgeTone.Success);
                    View.DisplayMessage($"License renewed successfully! New License ID: #{response.Data}");
                }
                else
                {
                    View.SetEligibility(true, "Renewal Not Completed", response.Error?.AllMessages ?? "Unable to renew license with the server.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(true, "Renewal Error", "Unable to reach the renewal endpoint. Please try again.", HeaderBadgeTone.Danger);
            }
            finally
            {
                if (!_disposed)
                    View.SetSubmitting(false);
            }
        }

        private void OnResetRequested(object? sender, EventArgs e)
        {
            _currentLicense = null;
            _eligible = false;
            View.ResetView();
            View.DisplayRenewalSummary(DateTime.Today, DateTime.Today.AddYears(10), RenewalApplicationFee, DefaultLicenseFee, _session.Username);
        }

        public override void Dispose()
        {
            _disposed = true;
            View.FindLicenseRequested -= OnFindLicenseRequested;
            View.ViewLicenseCardRequested -= OnViewLicenseCardRequested;
            View.RenewRequested -= OnRenewRequested;
            View.ResetRequested -= OnResetRequested;
        }
    }
}
