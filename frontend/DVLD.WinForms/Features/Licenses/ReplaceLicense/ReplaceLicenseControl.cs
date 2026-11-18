#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.ReplaceLicense
{
    public partial class ReplaceLicenseControl : UserControl, IReplaceLicenseView
    {
        public event EventHandler<int>? FindLicenseRequested;
        public event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;
        public event EventHandler? ReplacementTypeChanged;
        public event EventHandler? ReplaceRequested;
        public event EventHandler? ResetRequested;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReplacmentTypeEnum SelectedReplacementType =>
            rbLost.Checked ? ReplacmentTypeEnum.Lost : ReplacmentTypeEnum.Demaged;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes => txtNotes.Text.Trim();

        public ReplaceLicenseControl()
        {
            InitializeComponent();

            licenseLookup.LicenseSearchRequested += (_, id) => FindLicenseRequested?.Invoke(this, id);
            licenseLookup.ViewLicenseCardRequested += (_, license) => ViewLicenseCardRequested?.Invoke(this, license);
            pageActionFooter.PrimaryActionRequested += (_, _) => ReplaceRequested?.Invoke(this, EventArgs.Empty);
            pageActionFooter.SecondaryActionRequested += (_, _) => ResetRequested?.Invoke(this, EventArgs.Empty);

            rbDamaged.CheckedChanged += OnReasonRadioChanged;
            rbLost.CheckedChanged += OnReasonRadioChanged;
        }

        private void OnReasonRadioChanged(object? sender, EventArgs e)
        {
            if (sender == rbDamaged && rbDamaged.Checked)
                rbLost.Checked = false;
            else if (sender == rbLost && rbLost.Checked)
                rbDamaged.Checked = false;

            ApplyReasonOptionVisuals();
            ReplacementTypeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ApplyReasonOptionVisuals()
        {
            bool damagedSelected = rbDamaged.Checked;
            damagedBox.BorderThickness = damagedSelected ? 2 : 1;
            damagedBox.BorderColor = damagedSelected ? UITheme.PrimaryBlue : UITheme.SubtleBorder;
            damagedBox.FillColor = damagedSelected ? UITheme.InfoBg : UITheme.InputSurface;
            rbDamaged.ForeColor = damagedSelected ? UITheme.InfoText : UITheme.BodyInk;

            bool lostSelected = rbLost.Checked;
            lostBox.BorderThickness = lostSelected ? 2 : 1;
            lostBox.BorderColor = lostSelected ? UITheme.PrimaryBlue : UITheme.SubtleBorder;
            lostBox.FillColor = lostSelected ? UITheme.InfoBg : UITheme.InputSurface;
            rbLost.ForeColor = lostSelected ? UITheme.InfoText : UITheme.BodyInk;
        }

        public void SetSearching(bool isSearching) => licenseLookup.SetSearching(isSearching);

        public void SetSubmitting(bool isSubmitting)
        {
            rbDamaged.Enabled = !isSubmitting;
            rbLost.Enabled = !isSubmitting;
            txtNotes.Enabled = !isSubmitting;
            pageActionFooter.SetBusy(isSubmitting, "Issuing…");
        }

        public void DisplayLicense(GetLicenseResponse license) => licenseLookup.Bind(license);

        public void SetEligibility(bool eligible, string title, string description, HeaderBadgeTone tone)
        {
            statusBanner.SetBanner(title, description, tone);
            txtNotes.Enabled = eligible;
            pageActionFooter.SetState(
                eligible,
                eligible ? "Select Damaged or Lost reason and click Issue Replacement." : description,
                isWarningOrError: !eligible);
        }

        public void DisplayReplacementSummary(
            DateTime applicationDate,
            int? oldLicenseId,
            decimal fee,
            string createdBy,
            int? newLicenseId = null)
        {
            var culture = CultureInfo.CurrentCulture;
            lblApplicationDate.Text = applicationDate.ToString("dd MMM yyyy", culture);
            lblReplacementFee.Text = fee.ToString("C2", culture);
            lblCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy) ? "—" : createdBy;

            if (newLicenseId is > 0)
            {
                lblNewLicensePill.Text = $"New ID: #{newLicenseId}";
                lblNewLicensePill.FillColor = UITheme.SuccessBg;
                lblNewLicensePill.BorderColor = UITheme.SuccessBorder;
                lblNewLicensePill.ForeColor = UITheme.SuccessText;
            }
            else if (oldLicenseId is > 0)
            {
                lblNewLicensePill.Text = $"Replacing #{oldLicenseId}";
                lblNewLicensePill.FillColor = UITheme.InfoBg;
                lblNewLicensePill.BorderColor = UITheme.InfoBorder;
                lblNewLicensePill.ForeColor = UITheme.InfoText;
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
            rbDamaged.Checked = true;
            ApplyReasonOptionVisuals();
            txtNotes.Clear();
            txtNotes.Enabled = false;
            DisplayReplacementSummary(DateTime.Today, null, 5.00m, "—");
            statusBanner.SetBanner(
                "Awaiting License Selection",
                "Search for an active, non-detained local driving licence to process replacement.",
                HeaderBadgeTone.Info);
            pageActionFooter.SetState(false, "Find an active local license to issue a replacement.");
            licenseLookup.FocusSearchInput();
        }

        public void DisplayMessage(string message) =>
            MessageBox.Show(this, message, "Replace Driving Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
