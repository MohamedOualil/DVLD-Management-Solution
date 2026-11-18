#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class ApplicationInfoControl : UserControl
    {
        public event Action<int>? OnLicenseClassSelected;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ApplicationId
        {
            set
            {
                lblApplicationID.Text = string.IsNullOrWhiteSpace(value)
                    ? "Assigned after saving"
                    : value.Trim();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            ApplicationId = string.Empty;
        }

        public void LoadApplicantData(ApplicantSummaryRespond applicant, string createdBy)
        {
            ArgumentNullException.ThrowIfNull(applicant);

            var culture = CultureInfo.CurrentCulture;

            applicantBanner.Bind(applicant, licenseClassName: "Select a licence class");
            lblFees.Text = applicant.PaidFees.ToString("C2", culture);
            lblCreateby.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "—"
                : createdBy.Trim();
            lblApplicationDate.Text = DateTime.Now.ToString("dd MMM yyyy", culture);
            ApplicationId = string.Empty;
        }

        private void LicenseRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not Guna2RadioButton selectedRadio || !selectedRadio.Checked)
                return;

            if (!TryGetLicenseClassId(selectedRadio, out int classId))
                return;

            string classLabel = selectedRadio.Text.Trim();
            categoryFooter.Text = $"✓ Selected: {classLabel}";
            applicantBanner.LicenseClassName = classLabel;

            OnLicenseClassSelected?.Invoke(classId);
        }

        private static bool TryGetLicenseClassId(Guna2RadioButton? radio, out int classId)
        {
            classId = 0;

            return radio is not null
                && int.TryParse(radio.Tag?.ToString(), out classId)
                && Enum.IsDefined(typeof(LicenseClassEnum), classId);
        }
    }
}
