using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD.WinForms.Shared.Enums;

namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    /// <summary>
    /// Presentation-only control that renders a driving license as a card.
    /// It only knows how to display values; it does not call any API or service.
    /// </summary>
    public partial class LicenseCardControl : UserControl
    {
        public LicenseCardControl()
        {
            InitializeComponent();
        }

        // ---- Header ----
        public string ClassName { set => lblClassName.Text = value; }
        public string ClassDescription { set => lblClassDesc.Text = value; }

        // ---- Holder ----
        public string FullName { set => lblFullName.Text = value; }
        public string LicenseNo { set => lblLicenseNo.Text = value; }
        public string NationalNo { set => lblNationalNo.Text = value; }
        public string Gender { set => lblGender.Text = value; }
        public string DateOfBirth { set => lblDateOfBirth.Text = value; }
        public string IssueDate { set => lblIssueDate.Text = value; }
        public string ExpirationDate { set => lblExpirationDate.Text = value; }
        public string IssueReason { set => lblIssueReason.Text = value; }
        public string DriverId { set => lblDriverId.Text = value; }
        public string LicenseClass { set => lblLicenseClass.Text = value; }
        public string Notes { set => lblNotes.Text = value; }
        public string ExpiresIn { set => lblExpires.Text = value; }

        /// <summary>Optional absolute or relative path to the holder photo.</summary>
        public string ImagePath
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    pbPhoto.ImageLocation = value;
                else
                {
                    pbPhoto.ImageLocation = null;
                    pbPhoto.Image = Properties.Resources.DefaultAvatar;
                }
            }
        }

        /// <summary>
        /// Sets the status pill text and colour, plus the "detained" indicator dot.
        /// Kept purely visual: Active = green, Expired = amber, Detained = red, anything else = gray.
        /// </summary>
        public string Status
        {
            set
            {
                string status = value ?? string.Empty;
                statusPill.Text = status;

                Color color;
                if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                    color = Color.FromArgb(22, 163, 74);
                else if (status.Equals("Expired", StringComparison.OrdinalIgnoreCase))
                    color = Color.FromArgb(217, 119, 6);
                else if (status.Equals("Detained", StringComparison.OrdinalIgnoreCase))
                    color = Color.FromArgb(220, 38, 38);
                else
                    color = Color.FromArgb(100, 116, 139);

                statusPill.FillColor = color;

                bool detained = status.Equals("Detained", StringComparison.OrdinalIgnoreCase);
                lblDetainedText.Text = detained ? "Detained" : "Not Detained";
                lblDetainedDot.ForeColor = detained
                    ? Color.FromArgb(220, 38, 38)
                    : Color.FromArgb(22, 163, 74);
            }
        }

        public void LicenseInitialized(LicenseDto licenseDto)
        {
            ArgumentNullException.ThrowIfNull(licenseDto);

            ClassName = licenseDto.ClassName;
            ClassDescription = string.Empty;
            LicenseClass = licenseDto.ClassName;
            FullName = licenseDto.FullName;
            LicenseNo = licenseDto.LicenseId.ToString();
            NationalNo = licenseDto.NationalNo;
            DriverId = licenseDto.DriverId.ToString();
            Gender = licenseDto.Gender switch
            {
                (int)GenderEnum.Male => "Male",
                (int)GenderEnum.Female => "Female",
                _ => "Unknown"
            };
            DateOfBirth = licenseDto.DateOfBirth.ToString("dd/MM/yyyy");
            IssueDate = licenseDto.IssueDate.ToString("dd/MM/yyyy");
            ExpirationDate = licenseDto.ExpirationDate.ToString("dd/MM/yyyy");
            IssueReason = licenseDto.IssueReason switch
            {
                1 => "First Time",
                2 => "Renewal",
                3 => "Damaged Replacement",
                4 => "Lost Replacement",
                _ => "Unknown"
            };
            Notes = string.IsNullOrWhiteSpace(licenseDto.Notes) ? "No notes." : licenseDto.Notes;
            ImagePath = licenseDto.ImagePath ?? string.Empty;

            int daysRemaining = (licenseDto.ExpirationDate.Date - System.DateTime.Today).Days;
            Status = licenseDto.IsDetained ? "Detained"
                : daysRemaining < 0 ? "Expired"
                : licenseDto.IsActive ? "Active" : "Inactive";
            ExpiresIn = daysRemaining < 0 ? "Expired"
                : daysRemaining == 0 ? "Expires today"
                : daysRemaining == 1 ? "Expires in 1 day"
                : $"Expires in {daysRemaining} days";
        }
    }
}
