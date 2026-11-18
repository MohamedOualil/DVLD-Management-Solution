#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.RenewLicense
{
    public partial class RenewLicenseControl : UserControl, IRenewLicenseView
    {
        public event EventHandler<int>? FindLicenseRequested;
        public event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        public event EventHandler? RenewRequested;
        public event EventHandler? ResetRequested;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes => txtNotes.Text.Trim();

        public RenewLicenseControl()
        {
            InitializeComponent();

            licenseLookup.LicenseSearchRequested += (_, id) => FindLicenseRequested?.Invoke(this, id);
            licenseLookup.ViewLicenseCardRequested += (_, license) => ViewLicenseCardRequested?.Invoke(this, license);
            pageActionFooter.PrimaryActionRequested += (_, _) => RenewRequested?.Invoke(this, EventArgs.Empty);
            pageActionFooter.SecondaryActionRequested += (_, _) => ResetRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetSearching(bool isSearching) => licenseLookup.SetSearching(isSearching);

        public void SetSubmitting(bool isSubmitting)
        {
            txtNotes.Enabled = !isSubmitting;
            pageActionFooter.SetBusy(isSubmitting, "Renewing…");
        }

        public void DisplayLicense(GetLicenseResponse license)
        {
            licenseLookup.Bind(license);
        }

        public void SetEligibility(bool eligible, string title, string description, HeaderBadgeTone tone)
        {
            statusBanner.SetBanner(title, description, tone);
            txtNotes.Enabled = eligible;
            pageActionFooter.SetState(
                eligible,
                eligible ? "Eligible for renewal — click Renew License to issue a renewed credential." : description,
                isWarningOrError: !eligible);
        }

        public void DisplayRenewalSummary(
            DateTime applicationDate,
            DateTime newExpirationDate,
            decimal appFee,
            decimal licenseFee,
            string createdBy,
            int? newLicenseId = null)
        {
            var culture = CultureInfo.CurrentCulture;
            lblApplicationDate.Text = applicationDate.ToString("dd MMM yyyy", culture);
            lblNewExpirationDate.Text = newExpirationDate.ToString("dd MMM yyyy", culture);
            lblTotalFees.Text = (appFee + licenseFee).ToString("C2", culture);
            lblFeesBreakdown.Text = $"App: {appFee.ToString("C2", culture)} + License: {licenseFee.ToString("C2", culture)}";
            lblCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy) ? "—" : createdBy;

            if (newLicenseId is > 0)
            {
                lblNewLicensePill.Text = $"New ID: #{newLicenseId}";
                lblNewLicensePill.FillColor = UITheme.SuccessBg;
                lblNewLicensePill.BorderColor = UITheme.SuccessBorder;
                lblNewLicensePill.ForeColor = UITheme.SuccessText;
            }
            else
            {
                lblNewLicensePill.Text = "New ID: Pending";
                lblNewLicensePill.FillColor = UITheme.InputSurface;
                lblNewLicensePill.BorderColor = UITheme.SubtleBorder;
                lblNewLicensePill.ForeColor = UITheme.NeutralText;
            }
        }

        public void ResetView()
        {
            licenseLookup.Reset();
            txtNotes.Clear();
            txtNotes.Enabled = false;
            lblApplicationDate.Text = "—";
            lblNewExpirationDate.Text = "—";
            lblTotalFees.Text = "$27.00";
            lblFeesBreakdown.Text = "App: $7.00 + License: $20.00";
            lblCreatedBy.Text = "—";
            lblNewLicensePill.Text = "New ID: Pending";
            statusBanner.SetBanner(
                "Awaiting License Selection",
                "Search by License ID on the left to load driver eligibility and renewal terms.",
                HeaderBadgeTone.Info);
            pageActionFooter.SetState(false, "Find an expired local license to enable renewal.");
            licenseLookup.FocusSearchInput();
        }

        public void DisplayMessage(string message) =>
            MessageBox.Show(this, message, "Renew Driving Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
