using DVLD.WinForms.Features.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public partial class ListTestAppointmentsControl : UserControl, IListTestAppointmentsView
    {
        public event EventHandler CreateAppointmentRequested;
        public ListTestAppointmentsControl()
        {
            InitializeComponent();
        }

        private void CreateAppointmentButton_Click(object sender, EventArgs e)
        {
            CreateAppointmentRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayTestAppointments(IEnumerable<TestAppointmentsRespondDto> testAppointments)
        {
            TestAppointmentsDataGridView.Rows.Clear();

            foreach (var app in testAppointments)
            {

                int rowIndex = TestAppointmentsDataGridView.Rows.Add();

                TestAppointmentsDataGridView.Rows[rowIndex].Cells["TestAppointmentId"].Value = app.TestAppointmentId;
                TestAppointmentsDataGridView.Rows[rowIndex].Cells["AppointmentDate"].Value = app.AppointmentDate;
                TestAppointmentsDataGridView.Rows[rowIndex].Cells["PaidFees"].Value = app.PaidFees;
                TestAppointmentsDataGridView.Rows[rowIndex].Cells["TestResult"].Value = app.TestResult;
                TestAppointmentsDataGridView.Rows[rowIndex].Cells["TestStatus"].Value = app.TestStatus;
            }


        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }
    }
}
