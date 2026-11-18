#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using System;

namespace DVLD.WinForms.Features.Licenses.RenewLicense
{
    public interface IRenewLicenseView
    {
        event EventHandler<int>? FindLicenseRequested;
        event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        event EventHandler? RenewRequested;
        event EventHandler? ResetRequested;

        string Notes { get; }

        void SetSearching(bool isSearching);
        void SetSubmitting(bool isSubmitting);
        void DisplayLicense(GetLicenseResponse license);
        void SetEligibility(bool eligible, string title, string description, HeaderBadgeTone tone);
        void DisplayRenewalSummary(DateTime applicationDate, DateTime newExpirationDate, decimal appFee, decimal licenseFee, string createdBy, int? newLicenseId = null);
        void ResetView();
        void DisplayMessage(string message);
    }
}
