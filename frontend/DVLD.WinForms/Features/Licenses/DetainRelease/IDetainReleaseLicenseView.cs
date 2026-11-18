#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using System;

namespace DVLD.WinForms.Features.Licenses.DetainRelease
{
    public interface IDetainReleaseLicenseView
    {
        event EventHandler<int>? FindLicenseRequested;
        event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        event EventHandler? SubmitRequested;
        event EventHandler? ResetRequested;

        string FineAmountText { get; }
        string Notes { get; }

        void SetSearching(bool isSearching);
        void SetSubmitting(bool isSubmitting);
        void DisplayLicense(GetLicenseResponse license);
        void ConfigureDetainMode(DateTime detainDate, string createdBy, int? detainId = null);
        void ConfigureReleaseMode(DateTime actionDate, decimal releaseAppFee, string createdBy, int? releaseApplicationId = null);
        void SetEligibility(bool canSubmit, string primaryActionText, string title, string description, HeaderBadgeTone tone);
        void ResetView();
        void DisplayMessage(string message);
    }
}
