#nullable enable
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    public partial class LicenseCardForm : Form
    {
        public LicenseCardForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            CancelButton = closeButton;
            closeButton.Click += (_, _) => Close();

            ModalDialogShellHelper.Attach(
                this,
                borderRadius: 11f,
                onEscape: Close,
                headerPanel,
                headerAccentBar,
                headerDivider,
                bodyPanel,
                footerPanel,
                footerDivider);
        }

        public void DisplayLicense(GetLicenseResponse licenseDto)
        {
            ArgumentNullException.ThrowIfNull(licenseDto);

            licenseCardControl1.LicenseInitialized(licenseDto);
            subtitleLabel.Text = $"License #{licenseDto.LicenseId}  •  Driver ID #{licenseDto.DriverId}  •  National No: {licenseDto.NationalNo}";

            if (licenseDto.IsDetained)
            {
                ApplyRecordStatus(
                    fill: UITheme.DangerBg,
                    border: Color.FromArgb(252, 165, 165),
                    fore: UITheme.DangerText,
                    text: "● Detained License");
                return;
            }

            if (licenseDto.ExpirationDate.Date < DateTime.Today || !licenseDto.IsActive)
            {
                bool isExpired = licenseDto.ExpirationDate.Date < DateTime.Today;
                ApplyRecordStatus(
                    fill: UITheme.WarningBg,
                    border: UITheme.WarningBorder,
                    fore: UITheme.WarningText,
                    text: isExpired ? "● Expired License" : "● Inactive License");
                return;
            }

            ApplyRecordStatus(
                fill: UITheme.SuccessBg,
                border: UITheme.SuccessBorder,
                fore: UITheme.SuccessText,
                text: "● Active License");
        }

        private void ApplyRecordStatus(Color fill, Color border, Color fore, string text)
        {
            recordStatusBadge.FillColor = fill;
            recordStatusBadge.BorderColor = border;
            lblRecordStatus.ForeColor = fore;
            lblRecordStatus.Text = text;
        }
    }
}
