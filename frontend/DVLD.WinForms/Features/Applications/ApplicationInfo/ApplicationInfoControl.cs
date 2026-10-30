using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.WinForms.Shared.Enums;
using Guna.UI2.WinForms;

namespace DVLD.WinForms.Features.Applications.ApplicationInfo
{
    public partial class ApplicationInfoControl : UserControl
    {
        public event Action<int> OnLicenseClassSelected;


        public string ApplicationId
        {
            set
            {
                lblApplicationID.Text = string.IsNullOrWhiteSpace(value)
                    ? "Assigned after saving"
                    : value.Trim();
            }
        }

        public int? SelectedLicenseClassId
        {
            get
            {
                var selectedRadio = gbContainer.Controls
                    .OfType<Guna2RadioButton>()
                    .FirstOrDefault(radio => radio.Checked);

                return TryGetLicenseClassId(selectedRadio, out int classId)
                    ? classId
                    : null;
            }
        }
        public ApplicationInfoControl()
        {
            InitializeComponent();

            pbPhoto.InitialImage = Properties.Resources.DefaultAvatar;
            pbPhoto.ErrorImage = Properties.Resources.DefaultAvatar;
            pbPhoto.WaitOnLoad = false;

            ApplicationId = string.Empty;
        }

        public void LoadApplicantData(ApplicantSummaryDto applicant,string createdBy)
        {
 
            ArgumentNullException.ThrowIfNull(applicant);

            var culture = CultureInfo.CurrentCulture;

            lblFullName.Text = applicant.FullName;
            NationalNoButton.Text = applicant.NationalNo;

            lblAge.Text = $"{applicant.Age} years";

            lblDateOfBirth.Text = applicant.DateOfBirth
                .ToString("dd MMM yyyy", culture);

            lblFees.Text = applicant.PaidFees.ToString("C2", culture);

            lblCreateby.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "—"
                : createdBy.Trim();

            lblApplicationDate.Text = DateTime.Now
                .ToString("dd MMM yyyy", culture);

            ApplicationId = string.Empty;

            LoadApplicantPhoto(applicant.ImagePath);
        }

        private void LoadApplicantPhoto(string? imagePath)
        {
            pbPhoto.CancelAsync();
            pbPhoto.ImageLocation = null;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;

            if (!string.IsNullOrWhiteSpace(imagePath))
                pbPhoto.ImageLocation = imagePath.Trim();
        }

        private void LicenseRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (sender is not Guna2RadioButton selectedRadio ||
                !selectedRadio.Checked)
            {
                return;
            }

            if (!TryGetLicenseClassId(selectedRadio, out int classId))
                return;

            categoryFooter.Text =
                $"Selected: {selectedRadio.Text.Trim()}";

            OnLicenseClassSelected?.Invoke(classId);
        }

        private static bool TryGetLicenseClassId(
            Guna2RadioButton? radio,
            out int classId)
        {
            classId = 0;

            return radio is not null
                && int.TryParse(radio.Tag?.ToString(), out classId)
                && Enum.IsDefined(typeof(LicenseClassEnum), classId);
        }
    }
}
