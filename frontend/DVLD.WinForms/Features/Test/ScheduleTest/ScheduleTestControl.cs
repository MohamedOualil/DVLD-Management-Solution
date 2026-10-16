using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    public partial class ScheduleTestControl : UserControl, IScheduleTestView
    {
        public event EventHandler? CancelRequested;
        public ScheduleTestControl()
        {
            InitializeComponent();
            tpAppointmentDate.Format = DateTimePickerFormat.Custom;
            tpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            tpAppointmentDate.Value = DateTime.Now.AddDays(1);
        }

        public event EventHandler? SaveRequested;

        public DateTime AppointmentDate =>
            DateTime.SpecifyKind(
                tpAppointmentDate.Value,
                DateTimeKind.Local).ToUniversalTime();


        public void DisplayTestInfo(SchelduleTestDto testInfo)
        {
            lblAge.Text = testInfo.Age.ToString();
            lblApplicationType.Text = testInfo.ApplicationType.ToString();
            lblLicenseClass.Text = testInfo.LicenseClassName.ToString();
            lblLocalApplicationID.Text = testInfo.LocalId.ToString();
            lblFullName.Text = testInfo.FullName.ToString();
            lblDateOfBirth.Text = testInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblFees.Text = testInfo.TestFees.ToString("C");
            lblTrail.Text = testInfo.TrialsCount.ToString();
            lblTestName.Text = testInfo.TestName.ToString();
            NationalNoButton.Text = testInfo.NationalNo;

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetSaving(bool isSaving)
        {
            SaveButton.Enabled = !isSaving;
            tpAppointmentDate.Enabled = !isSaving;
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(
                this,
                message,
                "Schedule Test",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
