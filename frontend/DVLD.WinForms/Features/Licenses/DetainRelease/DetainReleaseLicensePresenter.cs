#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Globalization;

namespace DVLD.WinForms.Features.Licenses.DetainRelease
{
    public class DetainReleaseLicensePresenter : BasePresenter<IDetainReleaseLicenseView>
    {
        private const decimal ReleaseApplicationFee = 15.00m;

        private readonly ILicensesService _licensesService;
        private GetLicenseResponse? _currentLicense;
        private bool _canSubmit;
        private bool _isReleaseMode;
        private bool _disposed;

        public DetainReleaseLicensePresenter(
            IDetainReleaseLicenseView view,
            ILicensesService licensesService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _licensesService = licensesService;

            View.FindLicenseRequested += OnFindLicenseRequested;
            View.ViewLicenseCardRequested += OnViewLicenseCardRequested;
            View.SubmitRequested += OnSubmitRequested;
            View.ResetRequested += OnResetRequested;

            View.ResetView();
        }

        public async Task LoadLicenseAsync(int licenseId)
        {
            if (_disposed || licenseId <= 0) return;

            _currentLicense = null;
            _canSubmit = false;
            _isReleaseMode = false;
            View.SetSearching(true);

            try
            {
                var response = await _licensesService.GetLicenseAsync(licenseId);
                if (_disposed) return;

                if (!response.IsSuccess || response.Data is null)
                {
                    View.SetEligibility(
                        false,
                        "Detain License",
                        "License Not Found",
                        response.Error?.AllMessages ?? $"No local driving license found with ID #{licenseId}.",
                        HeaderBadgeTone.Danger);
                    return;
                }

                var license = response.Data;
                _currentLicense = license;
                View.DisplayLicense(license);

                if (license.IsDetained)
                {
                    _isReleaseMode = true;
                    _canSubmit = true;
                    View.ConfigureReleaseMode(DateTime.Today, ReleaseApplicationFee, _session.Username);
                    View.SetEligibility(
                        true,
                        "Release License",
                        "License Currently Detained",
                        $"License #{license.LicenseId} is detained. Click Release License to lift the hold.",
                        HeaderBadgeTone.Warning);
                }
                else if (!license.IsActive)
                {
                    View.ConfigureDetainMode(DateTime.Today, _session.Username);
                    View.SetEligibility(
                        false,
                        "Detain License",
                        "License Inactive",
                        "Inactive licences cannot be placed into detention.",
                        HeaderBadgeTone.Danger);
                }
                else
                {
                    _isReleaseMode = false;
                    _canSubmit = true;
                    View.ConfigureDetainMode(DateTime.Today, _session.Username);
                    View.SetEligibility(
                        true,
                        "Detain License",
                        "License Active & Clear",
                        "Enter a fine amount and optional notes, then click Detain License.",
                        HeaderBadgeTone.Success);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(false, "Detain License", "Connection Error", "Unable to retrieve license details.", HeaderBadgeTone.Danger);
            }
            finally
            {
                if (!_disposed)
                    View.SetSearching(false);
            }
        }

        private async void OnFindLicenseRequested(object? sender, int licenseId)
        {
            await LoadLicenseAsync(licenseId);
        }

        private void OnViewLicenseCardRequested(object? sender, GetLicenseResponse license)
        {
            if (!_disposed)
                _navigationService.ShowDialog<LicenseCardForm>(form => form.DisplayLicense(license));
        }

        private async void OnSubmitRequested(object? sender, EventArgs e)
        {
            if (_disposed || !_canSubmit || _currentLicense is null)
                return;

            decimal fineAmount = 0m;
            if (!_isReleaseMode)
            {
                if (!decimal.TryParse(View.FineAmountText, NumberStyles.Number, CultureInfo.InvariantCulture, out fineAmount) &&
                    !decimal.TryParse(View.FineAmountText, out fineAmount))
                {
                    View.DisplayMessage("Enter a valid numeric fine amount before detaining this licence.");
                    return;
                }

                if (fineAmount < 0)
                {
                    View.DisplayMessage("Fine amount cannot be negative.");
                    return;
                }
            }

            View.SetSubmitting(true);
            try
            {
                if (_isReleaseMode)
                {
                    var response = await _licensesService.ReleaseDetainedLicenseAsync(_currentLicense.LicenseId, View.Notes);
                    if (_disposed) return;

                    if (response.IsSuccess && response.Data > 0)
                    {
                        _canSubmit = false;
                        View.ConfigureReleaseMode(DateTime.Today, ReleaseApplicationFee, _session.Username, response.Data);
                        View.SetEligibility(false, "Release License", "Detention Released", $"License #{_currentLicense.LicenseId} has been released (Application #{response.Data}).", HeaderBadgeTone.Success);
                        View.DisplayMessage($"License #{_currentLicense.LicenseId} released successfully.");
                    }
                    else
                    {
                        View.SetEligibility(true, "Release License", "Release Failed", response.Error?.AllMessages ?? "Unable to release detained license.", HeaderBadgeTone.Danger);
                    }
                }
                else
                {
                    var response = await _licensesService.DetainLicenseAsync(_currentLicense.LicenseId, fineAmount, View.Notes);
                    if (_disposed) return;

                    if (response.IsSuccess && response.Data > 0)
                    {
                        _canSubmit = false;
                        View.ConfigureDetainMode(DateTime.Today, _session.Username, response.Data);
                        View.SetEligibility(false, "Detain License", "License Detained", $"License #{_currentLicense.LicenseId} has been detained (Detain ID #{response.Data}).", HeaderBadgeTone.Warning);
                        View.DisplayMessage($"License #{_currentLicense.LicenseId} detained successfully (Detain ID #{response.Data}).");
                    }
                    else
                    {
                        View.SetEligibility(true, "Detain License", "Detention Failed", response.Error?.AllMessages ?? "Unable to detain license.", HeaderBadgeTone.Danger);
                    }
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(true, _isReleaseMode ? "Release License" : "Detain License", "Connection Error", "Unable to complete operation with the server.", HeaderBadgeTone.Danger);
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
            _canSubmit = false;
            _isReleaseMode = false;
            View.ResetView();
        }

        public override void Dispose()
        {
            _disposed = true;
            View.FindLicenseRequested -= OnFindLicenseRequested;
            View.ViewLicenseCardRequested -= OnViewLicenseCardRequested;
            View.SubmitRequested -= OnSubmitRequested;
            View.ResetRequested -= OnResetRequested;
        }
    }
}
