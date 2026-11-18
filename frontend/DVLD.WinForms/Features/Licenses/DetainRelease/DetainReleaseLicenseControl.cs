#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.DetainRelease
{
    public partial class DetainReleaseLicenseControl : UserControl, IDetainReleaseLicenseView
    {
        public event EventHandler<int>? FindLicenseRequested;
        public event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        public event EventHandler? SubmitRequested;
        public event EventHandler? ResetRequested;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FineAmountText => txtFineAmount.Text.Trim();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes => txtReasonNotes.Text.Trim();

        public DetainReleaseLicenseControl()
        {
            InitializeComponent();

            licenseLookup.LicenseSearchRequested += (_, id) => FindLicenseRequested?.Invoke(this, id);
            licenseLookup.ViewLicenseCardRequested += (_, license) => ViewLicenseCardRequested?.Invoke(this, license);
            pageActionFooter.PrimaryActionRequested += (_, _) => SubmitRequested?.Invoke(this, EventArgs.Empty);
            pageActionFooter.SecondaryActionRequested += (_, _) => ResetRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetSearching(bool isSearching) => licenseLookup.SetSearching(isSearching);

        public void SetSubmitting(bool isSubmitting)
        {
            txtFineAmount.Enabled = !isSubmitting;
            txtReasonNotes.Enabled = !isSubmitting;
            pageActionFooter.SetBusy(isSubmitting, "Processing…");
        }

        public void DisplayLicense(GetLicenseResponse license) => licenseLookup.Bind(license);

        public void ConfigureDetainMode(DateTime detainDate, string createdBy, int? detainId = null)
        {
            lblDateCaption.Text = "DETAIN DATE";
            lblActionDate.Text = detainDate.ToString("dd MMM yyyy", CultureInfo.CurrentCulture);
            lblReleaseFee.Text = "N/A (Detaining)";
            lblCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy) ? "—" : createdBy;
            txtFineAmount.Enabled = true;
            txtReasonNotes.Enabled = true;

            lblModePill.Text = detainId is > 0 ? $"Detain ID #{detainId}" : "● Detain Mode";
            lblModePill.FillColor = UITheme.WarningBg;
            lblModePill.BorderColor = UITheme.WarningBorder;
            lblModePill.ForeColor = UITheme.WarningText;
            pageActionFooter.PrimaryButtonText = "Detain License";
        }

        public void ConfigureReleaseMode(DateTime actionDate, decimal releaseAppFee, string createdBy, int? releaseApplicationId = null)
        {
            var culture = CultureInfo.CurrentCulture;
            lblDateCaption.Text = "RELEASE DATE";
            lblActionDate.Text = actionDate.ToString("dd MMM yyyy", culture);
            lblReleaseFee.Text = releaseAppFee.ToString("C2", culture);
            lblCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy) ? "—" : createdBy;
            txtFineAmount.Enabled = false;
            txtReasonNotes.Enabled = true;

            lblModePill.Text = releaseApplicationId is > 0 ? $"Released App #{releaseApplicationId}" : "● Release Mode";
            lblModePill.FillColor = UITheme.SuccessBg;
            lblModePill.BorderColor = UITheme.SuccessBorder;
            lblModePill.ForeColor = UITheme.SuccessText;
            pageActionFooter.PrimaryButtonText = "Release License";
        }

        public void SetEligibility(bool canSubmit, string primaryActionText, string title, string description, HeaderBadgeTone tone)
        {
            pageActionFooter.PrimaryButtonText = primaryActionText;
            statusBanner.SetBanner(title, description, tone);
            pageActionFooter.SetState(canSubmit, description, isWarningOrError: !canSubmit);
        }

        public void ResetView()
        {
            licenseLookup.Reset();
            txtFineAmount.Clear();
            txtFineAmount.Enabled = false;
            txtReasonNotes.Clear();
            txtReasonNotes.Enabled = false;
            lblActionDate.Text = "—";
            lblReleaseFee.Text = "$15.00";
            lblCreatedBy.Text = "—";
            lblModePill.Text = "○ Mode: Auto";
            lblModePill.FillColor = UITheme.InputSurface;
            lblModePill.BorderColor = UITheme.SubtleBorder;
            lblModePill.ForeColor = UITheme.NeutralText;
            statusBanner.SetBanner(
                "Awaiting License Selection",
                "Search for a licence on the left to automatically switch between Detain and Release mode.",
                HeaderBadgeTone.Info);
            pageActionFooter.PrimaryButtonText = "Detain License";
            pageActionFooter.SetState(false, "Find a local license to detain or release it.");
            licenseLookup.FocusSearchInput();
        }

        public void DisplayMessage(string message) =>
            MessageBox.Show(this, message, "Detain & Release Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
