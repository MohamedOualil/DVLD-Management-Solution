#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using System;

namespace DVLD.WinForms.Features.Licenses.InternationalPermit
{
    public interface IInternationalPermitView
    {
        event EventHandler<int>? FindLicenseRequested;
        event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        event EventHandler? IssuePermitRequested;
        event EventHandler? ResetRequested;

        void SetSearching(bool isSearching);
        void SetSubmitting(bool isSubmitting);
        void DisplayLicense(GetLicenseResponse license);
        void SetEligibility(bool eligible, string title, string description, HeaderBadgeTone tone);
        void DisplayPermitSummary(int? localLicenseId, int? driverId, DateTime issueDate, DateTime expiryDate, decimal fee, string createdBy, int? internationalLicenseId = null);
        void ResetView();
        void DisplayMessage(string message);
    }
}
