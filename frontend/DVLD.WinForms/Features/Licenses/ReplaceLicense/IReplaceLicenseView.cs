#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using System;

namespace DVLD.WinForms.Features.Licenses.ReplaceLicense
{
    public interface IReplaceLicenseView
    {
        event EventHandler<int>? FindLicenseRequested;
        event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        event EventHandler? ReplacementTypeChanged;
        event EventHandler? ReplaceRequested;
        event EventHandler? ResetRequested;

        ReplacmentTypeEnum SelectedReplacementType { get; }
        string Notes { get; }

        void SetSearching(bool isSearching);
        void SetSubmitting(bool isSubmitting);
        void DisplayLicense(GetLicenseResponse license);
        void SetEligibility(bool eligible, string title, string description, HeaderBadgeTone tone);
        void DisplayReplacementSummary(DateTime applicationDate, int? oldLicenseId, decimal fee, string createdBy, int? newLicenseId = null);
        void ResetView();
        void DisplayMessage(string message);
    }
}
