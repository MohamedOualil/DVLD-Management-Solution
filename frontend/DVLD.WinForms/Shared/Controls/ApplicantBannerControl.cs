#nullable enable
using DVLD.Contracts.LocalLicenseApplications;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class ApplicantBannerControl : UserControl
    {
        private int _personId;
        private string _imagePath = string.Empty;

        public event EventHandler<int>? ViewPersonRequested;

        public ApplicantBannerControl()
        {
            InitializeComponent();
            btnViewPersonCard.Click += (_, _) =>
            {
                if (_personId > 0)
                    ViewPersonRequested?.Invoke(this, _personId);
            };
            bannerCard.SizeChanged += (_, _) => UpdateLicenseClassBoxWidth();
            SizeChanged += (_, _) => UpdateLicenseClassBoxWidth();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PersonId
        {
            get => _personId;
            set
            {
                _personId = value;
                btnViewPersonCard.Enabled = value > 0;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullName
        {
            get => lblFullName.Text;
            set => lblFullName.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NationalNo
        {
            get => lblNationalNo.Text;
            set => lblNationalNo.Text = string.IsNullOrWhiteSpace(value) ? "ID: —" : $"ID: {value.Trim()}";
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DateOfBirthText
        {
            get => lblDobAndAge.Text;
            set => lblDobAndAge.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LocalApplicationId
        {
            get => lblLocalAppId.Text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    lblLocalAppId.Text = "—";
                    return;
                }

                string trimmed = value.Trim();
                lblLocalAppId.Text = trimmed.StartsWith('#') ? trimmed : $"#{trimmed}";
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LicenseClassName
        {
            get => lblLicenseClass.Text;
            set => lblLicenseClass.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value ?? string.Empty;
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

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowViewPersonButton
        {
            get => btnViewPersonCard.Visible;
            set
            {
                btnViewPersonCard.Visible = value;
                UpdateLicenseClassBoxWidth();
            }
        }

        public void Bind(LocalApplicationResponse application)
        {
            ArgumentNullException.ThrowIfNull(application);

            PersonId = application.PersonId;
            FullName = application.FullName;
            NationalNo = application.NationalNo;
            DateOfBirthText = FormatBirthSummary(application.DateOfBirth, application.Age);
            LocalApplicationId = application.LocalId > 0 ? application.LocalId.ToString() : "—";
            LicenseClassName = application.LicenseClassName;
            ImagePath = application.PersonImagePath ?? string.Empty;
        }

        public void Bind(ApplicantSummaryRespond applicant, int? localApplicationId = null, string? licenseClassName = null)
        {
            ArgumentNullException.ThrowIfNull(applicant);

            PersonId = applicant.PersonId;
            FullName = applicant.FullName;
            NationalNo = applicant.NationalNo;
            DateOfBirthText = FormatBirthSummary(applicant.DateOfBirth, applicant.Age);
            LocalApplicationId = localApplicationId is > 0 ? localApplicationId.Value.ToString() : "Pending";
            LicenseClassName = string.IsNullOrWhiteSpace(licenseClassName) ? "Select below" : licenseClassName;
            ImagePath = applicant.ImagePath ?? string.Empty;
        }

        public void Reset()
        {
            PersonId = 0;
            FullName = "—";
            NationalNo = string.Empty;
            DateOfBirthText = "—";
            LocalApplicationId = string.Empty;
            LicenseClassName = "—";
            ImagePath = string.Empty;
        }

        private static string FormatBirthSummary(DateTime dateOfBirth, int age)
        {
            if (dateOfBirth == default)
                return age > 0 ? $"{age} yrs" : "—";

            string dob = dateOfBirth.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            return age > 0 ? $"{dob} • {age} yrs" : dob;
        }

        private void UpdateLicenseClassBoxWidth()
        {
            int rightLimit = btnViewPersonCard.Visible
                ? btnViewPersonCard.Left - 14
                : bannerCard.ClientSize.Width - 16;

            int newWidth = Math.Max(180, rightLimit - licenseClassBox.Left);
            licenseClassBox.Size = new Size(newWidth, licenseClassBox.Height);
        }
    }
}
