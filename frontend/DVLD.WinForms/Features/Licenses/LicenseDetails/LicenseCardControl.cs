#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    public partial class LicenseCardControl : UserControl
    {
        private static readonly Image MaleGenderBitmap = Properties.Resources.MaleIcon;
        private static readonly Image FemaleGenderBitmap = Properties.Resources.FemaleIcon;

        public LicenseCardControl()
        {
            InitializeComponent();
        }

        // ---- Header ----
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ClassName
        {
            set => lblClassName.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ClassDescription
        {
            set => lblClassDesc.Text = string.IsNullOrWhiteSpace(value)
                ? "Official Driving License Credential"
                : value;
        }

        // ---- Holder ----
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullName
        {
            set => lblFullName.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LicenseNo
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    lblLicenseNo.Text = "#----";
                    return;
                }

                string trimmed = value.Trim();
                lblLicenseNo.Text = trimmed.StartsWith('#') ? trimmed : $"#{trimmed}";
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NationalNo
        {
            set => lblNationalNo.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Gender
        {
            set
            {
                string display = string.IsNullOrWhiteSpace(value) ? "—" : value;
                lblGender.Text = display;

                if (display.Equals("Male", StringComparison.OrdinalIgnoreCase))
                    GenderIcon.Image = MaleGenderBitmap;
                else if (display.Equals("Female", StringComparison.OrdinalIgnoreCase))
                    GenderIcon.Image = FemaleGenderBitmap;
                else
                    GenderIcon.Image = null;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DateOfBirth
        {
            set => lblDateOfBirth.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IssueDate
        {
            set => lblIssueDate.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ExpirationDate
        {
            set => lblExpirationDate.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IssueReason
        {
            set => lblIssueReason.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DriverId
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    lblDriverId.Text = "#----";
                    return;
                }

                string trimmed = value.Trim();
                lblDriverId.Text = trimmed.StartsWith('#') ? trimmed : $"#{trimmed}";
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LicenseClass
        {
            set => lblLicenseClass.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes
        {
            set => lblNotes.Text = string.IsNullOrWhiteSpace(value)
                ? "No restrictions or special notes recorded."
                : value;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ExpiresIn
        {
            set => lblExpires.Text = string.IsNullOrWhiteSpace(value) ? "Validity: —" : value;
        }

        // ---- Image ----
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImagePath
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && File.Exists(value))
                {
                    pbPhoto.ImageLocation = value;
                }
                else
                {
                    pbPhoto.ImageLocation = null;
                    pbPhoto.Image = Properties.Resources.DefaultAvatar;
                }
            }
        }

        // ---- Status ----
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status
        {
            set
            {
                string status = value?.Trim() ?? string.Empty;

                if (status.Equals("Detained", StringComparison.OrdinalIgnoreCase))
                {
                    ApplyStatusStyle(
                        pillFill: UITheme.DangerBg,
                        pillFore: UITheme.DangerText,
                        pillText: "● Detained",
                        detainedFill: UITheme.DangerBg,
                        detainedBorder: Color.FromArgb(252, 165, 165),
                        detainedDotColor: UITheme.DangerText,
                        detainedFore: Color.FromArgb(153, 27, 27),
                        detainedText: "Hold / Detained");
                    return;
                }

                if (status.Equals("Expired", StringComparison.OrdinalIgnoreCase) ||
                    status.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
                {
                    bool isExpired = status.Equals("Expired", StringComparison.OrdinalIgnoreCase);
                    ApplyStatusStyle(
                        pillFill: UITheme.WarningBg,
                        pillFore: UITheme.WarningText,
                        pillText: isExpired ? "● Expired" : "● Inactive",
                        detainedFill: UITheme.NeutralBg,
                        detainedBorder: UITheme.NeutralBorder,
                        detainedDotColor: UITheme.SuccessText,
                        detainedFore: UITheme.NeutralText,
                        detainedText: "Clear Record");
                    return;
                }

                ApplyStatusStyle(
                    pillFill: UITheme.SuccessBg,
                    pillFore: UITheme.SuccessText,
                    pillText: string.IsNullOrEmpty(status) ? "● Active" : $"● {status}",
                    detainedFill: UITheme.NeutralBg,
                    detainedBorder: UITheme.NeutralBorder,
                    detainedDotColor: UITheme.SuccessText,
                    detainedFore: UITheme.NeutralText,
                    detainedText: "Clear Record");
            }
        }

        private void ApplyStatusStyle(
            Color pillFill,
            Color pillFore,
            string pillText,
            Color detainedFill,
            Color detainedBorder,
            Color detainedDotColor,
            Color detainedFore,
            string detainedText)
        {
            statusPill.FillColor = pillFill;
            lblStatusText.ForeColor = pillFore;
            lblStatusText.Text = pillText;

            detainedPill.FillColor = detainedFill;
            detainedPill.BorderColor = detainedBorder;
            lblDetainedDot.ForeColor = detainedDotColor;
            lblDetainedText.ForeColor = detainedFore;
            lblDetainedText.Text = detainedText;
        }

        public void LicenseInitialized(GetLicenseResponse licenseDto)
        {
            ArgumentNullException.ThrowIfNull(licenseDto);

            ClassName = licenseDto.ClassName;
            ClassDescription = "Official Driving License Credential";
            FullName = licenseDto.FullName;
            LicenseNo = licenseDto.LicenseId.ToString();
            DriverId = licenseDto.DriverId.ToString();
            NationalNo = licenseDto.NationalNo;
            DateOfBirth = licenseDto.DateOfBirth.ToString("dd MMM yyyy");
            IssueDate = licenseDto.IssueDate.ToString("dd MMM yyyy");
            ExpirationDate = licenseDto.ExpirationDate.ToString("dd MMM yyyy");
            LicenseClass = licenseDto.ClassName;
            Notes = licenseDto.Notes ?? string.Empty;
            ImagePath = licenseDto.ImagePath ?? string.Empty;

            Gender = licenseDto.Gender switch
            {
                (int)DVLD.Contracts.Enums.Gender.Male => "Male",
                (int)DVLD.Contracts.Enums.Gender.Female => "Female",
                _ => "—"
            };

            IssueReason = licenseDto.IssueReason switch
            {
                IssueReasonEnum.FirstTime => "First Time",
                IssueReasonEnum.Renew => "Renewal",
                IssueReasonEnum.DamagedReplacement => "Damaged Replacement",
                IssueReasonEnum.LostReplacement => "Lost Replacement",
                _ => licenseDto.IssueReason.ToString()
            };

            bool isDateExpired = licenseDto.ExpirationDate.Date < DateTime.Today;
            lblExpirationDate.ForeColor = isDateExpired
                ? UITheme.WarningText
                : UITheme.HeadingInk;

            if (licenseDto.IsDetained)
            {
                Status = "Detained";
                ExpiresIn = "Credential currently detained";
                lblExpires.ForeColor = UITheme.DangerText;
                return;
            }

            if (isDateExpired || !licenseDto.IsActive)
            {
                Status = isDateExpired ? "Expired" : "Inactive";
                ExpiresIn = isDateExpired
                    ? $"Expired on {licenseDto.ExpirationDate:dd MMM yyyy}"
                    : "Inactive credential";
                lblExpires.ForeColor = UITheme.WarningText;
                return;
            }

            Status = "Active";
            lblExpires.ForeColor = UITheme.SuccessText;
            int daysLeft = (licenseDto.ExpirationDate.Date - DateTime.Today).Days;
            ExpiresIn = daysLeft > 365
                ? $"Valid  •  {daysLeft / 365} yr {(daysLeft % 365) / 30} mo left"
                : daysLeft > 0
                    ? $"Valid  •  {daysLeft} days left"
                    : "Expires today";
        }
    }
}
