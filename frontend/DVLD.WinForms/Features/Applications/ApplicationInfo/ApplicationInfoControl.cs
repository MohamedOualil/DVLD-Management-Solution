using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.ApplicationInfo
{
    public partial class ApplicationInfoControl : UserControl
    {
        public event Action<int> OnLicenseClassSelected;
        public ApplicationInfoControl()
        {
            InitializeComponent();
        }

        public void LoadApplicantData(ApplicantSummaryDto applicant,string createdBy)
        {
            lblAge.Text = applicant.Age.ToString() + " Years";
            lblFullName.Text = applicant.FullName;
            lblDateOfBirth.Text = applicant.DateOfBirth.ToString("MMM dd, yyyy");
            lblFees.Text = applicant.PaidFees.ToString("C");
            lblApplicationID.Text = "#";
            lblApplicationDate.Text = DateTime.UtcNow.ToString("MMM dd, yyyy");
            NationalNoButton.Text = applicant.NationalNo;

            lblCreateby.Text = createdBy;
        }

        private void LicenseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Guna2RadioButton selectedRadio && selectedRadio.Checked)
            {
 
                if (selectedRadio.Tag != null)
                {
                    int licenseClassId = Convert.ToInt32(selectedRadio.Tag);

                    OnLicenseClassSelected?.Invoke(licenseClassId);
                }
            }
        }
    }
}
