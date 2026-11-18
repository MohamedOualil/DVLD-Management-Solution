#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.InternationalPermit
{
    public partial class InternationalPermitControl : UserControl, IInternationalPermitView
    {
        public event EventHandler<int>? FindLicenseRequested;
        public event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        public event EventHandler? IssuePermitRequested;
        public event EventHandler? ResetRequested;

        public InternationalPermitControl()
        {
            InitializeComponent();

            licenseLookup.LicenseSearchRequested += (_, id) => FindLicenseRequested?.Invoke(this, id);
            licenseLookup.ViewLicenseCardRequested += (_, license) => ViewLicenseCardRequested?.Invoke(this, license);
            pageActionFooter.PrimaryActionRequested += (_, _) => IssuePermitRequested?.Invoke(this, EventArgs.Empty);
            pageActionFooter.SecondaryActionRequested += (_, _) => ResetRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetSearching(bool isSearching) => licenseLookup.SetSearching(isSearching);

        public void SetSubmitting(bool isSubmitting) => pageActionFooter.SetBusy(isSubmitting, "Issuing…");

        public void DisplayLicense(GetLicenseResponse license) => licenseLookup.Bind(license);

        public void SetEligibility(bool eligible, string title, string description, HeaderBadgeTone tone)
        {
            statusBanner.SetBanner(title, description, tone);
            pageActionFooter.SetState(
                eligible,
                eligible ? "Local licence verified — click Issue International Permit to submit." : description,
                isWarningOrError: !eligible);
        }

        public void DisplayPermitSummary(
            int? localLicenseId,
            int? driverId,
            DateTime issueDate,
            DateTime expiryDate,
            decimal fee,
            string createdBy,
            int? internationalLicenseId = null)
        {
            var culture = CultureInfo.CurrentCulture;
            lblLocalLicenseId.Text = localLicenseId is > 0 ? $"#{localLicenseId}" : "—";
            lblDriverId.Text = driverId is > 0 ? $"#{driverId}" : "—";
            lblIssueDate.Text = issueDate.ToString("dd MMM yyyy", culture);
            lblExpirationDate.Text = expiryDate.ToString("dd MMM yyyy", culture);
            lblApplicationFee.Text = fee.ToString("C2", culture);
            lblCreatedByInline.Text = string.IsNullOrWhiteSpace(createdBy) ? "Officer: —" : $"Officer: {createdBy}";

            if (internationalLicenseId is > 0)
            {
                lblPermitIdPill.Text = $"Permit #{internationalLicenseId}";
                lblPermitIdPill.FillColor = UITheme.SuccessBg;
                lblPermitIdPill.BorderColor = UITheme.SuccessBorder;
                lblPermitIdPill.ForeColor = UITheme.SuccessText;
            }
            else
            {
                lblPermitIdPill.Text = "Permit: Pending";
                lblPermitIdPill.FillColor = UITheme.InputSurface;
                lblPermitIdPill.BorderColor = UITheme.SubtleBorder;
                lblPermitIdPill.ForeColor = UITheme.NeutralText;
            }
        }

        public void ResetView()
        {
            licenseLookup.Reset();
            DisplayPermitSummary(null, null, DateTime.Today, DateTime.Today.AddYears(1), 50.00m, "—");
            statusBanner.SetBanner(
                "Awaiting Local License Lookup",
                "Search for an active Class 3 (Ordinary) local driving licence to verify eligibility.",
                HeaderBadgeTone.Info);
            pageActionFooter.SetState(false, "Find an eligible Class 3 local license to issue an international permit.");
            licenseLookup.FocusSearchInput();
        }

        public void DisplayMessage(string message) =>
            MessageBox.Show(this, message, "International Driving Permit", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
