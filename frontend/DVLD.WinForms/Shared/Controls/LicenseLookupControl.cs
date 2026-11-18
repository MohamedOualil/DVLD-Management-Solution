#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class LicenseLookupControl : UserControl
    {
        private GetLicenseResponse? _selectedLicense;
        private bool _searching;

        public event EventHandler<int>? LicenseSearchRequested;
        public event EventHandler<GetLicenseResponse>? ViewLicenseCardRequested;

        public LicenseLookupControl()
        {
            InitializeComponent();
            txtLicenseId.IconLeft = Properties.Resources.icons8_search_32;
            txtLicenseId.IconLeftSize = new Size(16, 16);
            txtLicenseId.TextOffset = new Point(0, 0);

            btnFindLicense.Image = Properties.Resources.icons8_search_white_32;
            btnFindLicense.ImageSize = new Size(15, 15);
            btnFindLicense.ImageOffset = new Point(-2, 0);

            btnFindLicense.Click += (_, _) => TriggerSearch();
            btnViewCard.Click += (_, _) =>
            {
                if (_selectedLicense is not null)
                    ViewLicenseCardRequested?.Invoke(this, _selectedLicense);
            };

            txtLicenseId.KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    TriggerSearch();
                }
            };
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchLicenseId
        {
            get => txtLicenseId.Text.Trim();
            set => txtLicenseId.Text = value ?? string.Empty;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GetLicenseResponse? SelectedLicense => _selectedLicense;

        public void SetSearching(bool isSearching)
        {
            _searching = isSearching;
            txtLicenseId.Enabled = !isSearching;
            btnFindLicense.Enabled = !isSearching;
            btnFindLicense.Text = isSearching ? "Searching…" : "Find License";
        }

        public void FocusSearchInput()
        {
            txtLicenseId.Focus();
            txtLicenseId.SelectAll();
        }

        public void Bind(GetLicenseResponse license)
        {
            ArgumentNullException.ThrowIfNull(license);

            _selectedLicense = license;
            txtLicenseId.Text = license.LicenseId.ToString();

            var culture = CultureInfo.InvariantCulture;
            lblHolderName.Text = license.FullName;
            lblLicenseId.Text = $"#{license.LicenseId}";
            lblNationalNo.Text = license.NationalNo;
            lblDriverId.Text = $"#{license.DriverId}";
            lblClassName.Text = license.ClassName;
            lblIssueDate.Text = license.IssueDate == default ? "—" : license.IssueDate.ToString("dd MMM yyyy", culture);
            lblExpiryDate.Text = license.ExpirationDate == default ? "—" : license.ExpirationDate.ToString("dd MMM yyyy", culture);
            lblIssueReason.Text = license.IssueReason switch
            {
                IssueReasonEnum.FirstTime => "First Time",
                IssueReasonEnum.Renew => "Renewal",
                IssueReasonEnum.DamagedReplacement => "Damaged Replacement",
                IssueReasonEnum.LostReplacement => "Lost Replacement",
                _ => "Standard"
            };

            lblDetainedStatus.Text = license.IsDetained ? "Yes — Detained" : "No";
            lblDetainedStatus.ForeColor = license.IsDetained
                ? Color.FromArgb(185, 28, 28)
                : Color.FromArgb(21, 128, 61);

            bool isExpired = license.ExpirationDate.Date < DateTime.Today;
            if (license.IsDetained)
            {
                ApplyStatusPill("● Detained", Color.FromArgb(254, 242, 242), Color.FromArgb(254, 202, 202), Color.FromArgb(185, 28, 28));
            }
            else if (isExpired)
            {
                ApplyStatusPill("● Expired", Color.FromArgb(255, 251, 235), Color.FromArgb(253, 230, 138), Color.FromArgb(180, 83, 9));
            }
            else if (license.IsActive)
            {
                ApplyStatusPill("● Active", Color.FromArgb(240, 253, 244), Color.FromArgb(187, 247, 208), Color.FromArgb(21, 128, 61));
            }
            else
            {
                ApplyStatusPill("○ Inactive", Color.FromArgb(241, 245, 249), Color.FromArgb(226, 232, 240), Color.FromArgb(71, 85, 105));
            }

            lblLookupHint.Text = string.IsNullOrWhiteSpace(license.Notes)
                ? "Click View Card ↗ to inspect the complete driving licence card."
                : $"Notes: {license.Notes}";
            btnViewCard.Enabled = true;
        }

        public void Reset()
        {
            _selectedLicense = null;
            lblHolderName.Text = "Awaiting License Search";
            lblLicenseId.Text = "—";
            lblNationalNo.Text = "—";
            lblDriverId.Text = "—";
            lblClassName.Text = "—";
            lblIssueReason.Text = "—";
            lblIssueDate.Text = "—";
            lblExpiryDate.Text = "—";
            lblDetainedStatus.Text = "—";
            lblDetainedStatus.ForeColor = Color.FromArgb(51, 65, 85);
            lblLookupHint.Text = "Enter a local license ID above and click Find License to load validity details.";

            ApplyStatusPill("○ Not Loaded", Color.FromArgb(248, 250, 252), Color.FromArgb(226, 232, 240), Color.FromArgb(71, 85, 105));
            btnViewCard.Enabled = false;
        }

        private void TriggerSearch()
        {
            if (_searching)
                return;

            if (!int.TryParse(txtLicenseId.Text.Trim(), out int licenseId) || licenseId <= 0)
            {
                lblLookupHint.Text = "Enter a valid positive License ID number (e.g., 1024).";
                lblLookupHint.ForeColor = Color.FromArgb(185, 28, 28);
                txtLicenseId.Focus();
                return;
            }

            lblLookupHint.ForeColor = Color.FromArgb(100, 116, 139);
            LicenseSearchRequested?.Invoke(this, licenseId);
        }

        private void ApplyStatusPill(string text, Color fill, Color border, Color fore)
        {
            statusPill.Text = text;
            statusPill.FillColor = fill;
            statusPill.BorderColor = border;
            statusPill.ForeColor = fore;
            statusPill.HoverState.FillColor = fill;
            statusPill.HoverState.BorderColor = border;
            statusPill.HoverState.ForeColor = fore;
            statusPill.PressedColor = fill;
        }

    }
}
