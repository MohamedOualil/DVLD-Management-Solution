#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;

namespace DVLD.WinForms.Features.Licenses.InternationalPermit
{
    public class InternationalPermitPresenter : BasePresenter<IInternationalPermitView>
    {
        private const decimal InternationalPermitFee = 50.00m;

        private readonly ILicensesService _licensesService;
        private GetLicenseResponse? _currentLicense;
        private bool _eligible;
        private bool _disposed;

        public InternationalPermitPresenter(
            IInternationalPermitView view,
            ILicensesService licensesService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _licensesService = licensesService;

            View.FindLicenseRequested += OnFindLicenseRequested;
            View.ViewLicenseCardRequested += OnViewLicenseCardRequested;
            View.IssuePermitRequested += OnIssuePermitRequested;
            View.ResetRequested += OnResetRequested;

            View.ResetView();
            View.DisplayPermitSummary(null, null, DateTime.Today, DateTime.Today.AddYears(1), InternationalPermitFee, _session.Username);
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
                View.DisplayPermitSummary(
                    license.LicenseId,
                    license.DriverId,
                    DateTime.Today,
                    DateTime.Today.AddYears(1),
                    InternationalPermitFee,
                    _session.Username);

                bool isOrdinaryClass =
                    license.ClassName.Contains("Ordinary", StringComparison.OrdinalIgnoreCase) ||
                    license.ClassName.Contains("Class 3", StringComparison.OrdinalIgnoreCase);

                if (!license.IsActive)
                {
                    View.SetEligibility(false, "License Inactive", "Only an active local driving licence can back an International Permit.", HeaderBadgeTone.Danger);
                }
                else if (license.IsDetained)
                {
                    View.SetEligibility(false, "License Detained", "Release the detained local licence before applying for an International Permit.", HeaderBadgeTone.Warning);
                }
                else if (license.ExpirationDate.Date < DateTime.Today)
                {
                    View.SetEligibility(false, "License Expired", "Renew the expired local licence before issuing an International Permit.", HeaderBadgeTone.Warning);
                }
                else if (!isOrdinaryClass)
                {
                    View.SetEligibility(
                        false,
                        "Incompatible Licence Class",
                        $"Class 3 (Ordinary Driving License) is required; loaded class is \"{license.ClassName}\".",
                        HeaderBadgeTone.Warning);
                }
                else
                {
                    _eligible = true;
                    View.SetEligibility(
                        true,
                        "Eligible for International Permit",
                        $"Local Class 3 Licence #{license.LicenseId} is active and qualified for international issuance.",
                        HeaderBadgeTone.Success);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(false, "Connection Error", "Unable to verify local licence details.", HeaderBadgeTone.Danger);
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

        private async void OnIssuePermitRequested(object? sender, EventArgs e)
        {
            if (_disposed || !_eligible || _currentLicense is null)
                return;

            View.SetSubmitting(true);
            try
            {
                var response = await _licensesService.IssueInternationalLicenseAsync(_currentLicense.LicenseId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data > 0)
                {
                    _eligible = false;
                    View.DisplayPermitSummary(
                        _currentLicense.LicenseId,
                        _currentLicense.DriverId,
                        DateTime.Today,
                        DateTime.Today.AddYears(1),
                        InternationalPermitFee,
                        _session.Username,
                        response.Data);

                    View.SetEligibility(
                        false,
                        "International Permit Issued",
                        $"International Driving Permit #{response.Data} issued successfully for Driver #{_currentLicense.DriverId}.",
                        HeaderBadgeTone.Success);
                    View.DisplayMessage($"International Driving Permit #{response.Data} issued successfully!");
                }
                else
                {
                    View.SetEligibility(true, "Issuance Failed", response.Error?.AllMessages ?? "Unable to issue International Permit.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(true, "Connection Error", "Unable to reach the international licence endpoint.", HeaderBadgeTone.Danger);
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
            View.DisplayPermitSummary(null, null, DateTime.Today, DateTime.Today.AddYears(1), InternationalPermitFee, _session.Username);
        }

        public override void Dispose()
        {
            _disposed = true;
            View.FindLicenseRequested -= OnFindLicenseRequested;
            View.ViewLicenseCardRequested -= OnViewLicenseCardRequested;
            View.IssuePermitRequested -= OnIssuePermitRequested;
            View.ResetRequested -= OnResetRequested;
        }
    }
}
