#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Licenses.ReplaceLicense
{
    public class ReplaceLicensePresenter : BasePresenter<IReplaceLicenseView>
    {
        private const decimal DamagedReplacementFee = 5.00m;
        private const decimal LostReplacementFee = 10.00m;

        private readonly ILicensesService _licensesService;
        private GetLicenseResponse? _currentLicense;
        private bool _eligible;
        private bool _disposed;

        public ReplaceLicensePresenter(
            IReplaceLicenseView view,
            ILicensesService licensesService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _licensesService = licensesService;

            View.FindLicenseRequested += OnFindLicenseRequested;
            View.ViewLicenseCardRequested += OnViewLicenseCardRequested;
            View.ReplacementTypeChanged += OnReplacementTypeChanged;
            View.ReplaceRequested += OnReplaceRequested;
            View.ResetRequested += OnResetRequested;

            View.ResetView();
            View.DisplayReplacementSummary(DateTime.Today, null, CurrentFee(), _session.Username);
        }

        private decimal CurrentFee() => View.SelectedReplacementType == ReplacmentTypeEnum.Lost
            ? LostReplacementFee
            : DamagedReplacementFee;

        private void OnReplacementTypeChanged(object? sender, EventArgs e)
        {
            if (!_disposed)
                View.DisplayReplacementSummary(DateTime.Today, _currentLicense?.LicenseId, CurrentFee(), _session.Username);
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
                View.DisplayReplacementSummary(DateTime.Today, license.LicenseId, CurrentFee(), _session.Username);

                if (!license.IsActive)
                {
                    View.SetEligibility(false, "License Inactive", "Inactive licenses cannot be replaced.", HeaderBadgeTone.Danger);
                }
                else if (license.IsDetained)
                {
                    View.SetEligibility(false, "License Detained", "Release this detained licence before issuing a replacement.", HeaderBadgeTone.Warning);
                }
                else if (license.ExpirationDate.Date < DateTime.Today)
                {
                    View.SetEligibility(false, "License Expired", "Expired licenses must be renewed rather than replaced.", HeaderBadgeTone.Warning);
                }
                else
                {
                    _eligible = true;
                    View.SetEligibility(
                        true,
                        "Eligible for Replacement",
                        $"License #{license.LicenseId} is active and ready for replacement.",
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

        private async void OnReplaceRequested(object? sender, EventArgs e)
        {
            if (_disposed || !_eligible || _currentLicense is null)
                return;

            View.SetSubmitting(true);
            try
            {
                var response = await _licensesService.ReplaceLicenseAsync(
                    _currentLicense.LicenseId,
                    View.SelectedReplacementType,
                    View.Notes);

                if (_disposed) return;

                if (response.IsSuccess && response.Data > 0)
                {
                    _eligible = false;
                    View.DisplayReplacementSummary(DateTime.Today, _currentLicense.LicenseId, CurrentFee(), _session.Username, response.Data);
                    View.SetEligibility(
                        false,
                        "Replacement License Issued",
                        $"New License #{response.Data} issued and old license #{_currentLicense.LicenseId} deactivated.",
                        HeaderBadgeTone.Success);
                    View.DisplayMessage($"Replacement license issued! New License ID: #{response.Data}");
                }
                else
                {
                    View.SetEligibility(true, "Replacement Not Completed", response.Error?.AllMessages ?? "Unable to issue replacement license.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetEligibility(true, "Replacement Error", "Unable to reach the replacement endpoint. Please try again.", HeaderBadgeTone.Danger);
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
            View.DisplayReplacementSummary(DateTime.Today, null, CurrentFee(), _session.Username);
        }

        public override void Dispose()
        {
            _disposed = true;
            View.FindLicenseRequested -= OnFindLicenseRequested;
            View.ViewLicenseCardRequested -= OnViewLicenseCardRequested;
            View.ReplacementTypeChanged -= OnReplacementTypeChanged;
            View.ReplaceRequested -= OnReplaceRequested;
            View.ResetRequested -= OnResetRequested;
        }
    }
}
