using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Test.TestTrackingRoadmap;
using DVLD.WinForms.Shared.Enums;

namespace DVLD.WinForms.Features.Test_Appointments
{
    public partial class ListTestAppointmentsControl : UserControl, IListTestAppointmentsView
    {
        private string _testName = "Test";
        public event EventHandler? CreateAppointmentRequested;
        public event EventHandler? BackRequested;
        public event EventHandler<int>? RecordResultRequested;

        public ListTestAppointmentsControl()
        {
            InitializeComponent();
        }

        private void CreateAppointmentButton_Click(object? sender, EventArgs e) =>
            CreateAppointmentRequested?.Invoke(this, EventArgs.Empty);

        private void BackButton_Click(object? sender, EventArgs e) =>
            BackRequested?.Invoke(this, EventArgs.Empty);

        public void DisplayApplication(ApplicationDetailDto application, TestTypeEnum testType)
        {
            _testName = testType switch
            {
                TestTypeEnum.VisionTest => "Vision Test",
                TestTypeEnum.WrittenTest => "Written Test",
                TestTypeEnum.StreetTest => "Street Test",
                _ => "Test"
            };
            lblPageTitle.Text = $"{_testName} Appointments";

            lblFullName.Text = application.FullName;

            var names = application.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            avatar.Text = names.Length == 0 ? "DV"
                : $"{names[0][0]}{(names.Length > 1 ? names[^1][0].ToString() : "")}".ToUpperInvariant();

            lblNationalNo.Text = $"National No: {application.NationalNo}";
            lblApplicationId.Text = $"#{application.LocalId}";
            lblLicenseClass.Text = application.LicenseClassName;
            lblApplicationStatus.Text = application.Status;
        }

        public void DisplayProgress(TestResultsRoadmapDto roadmap)
        {
            DisplayStep(lblVisionProgress, "1  Vision", roadmap.VisionTest);
            DisplayStep(lblWrittenProgress, "2  Written", roadmap.WrittenTest);
            DisplayStep(lblStreetProgress, "3  Street", roadmap.StreetTest);
        }

        private static void DisplayStep(Label label, string title, TestCardDto test)
        {
            string status = test.Status switch
            {
                "Pending" when test.Attempt == "Not Scheduled" => "Not started",
                "Pending" when int.TryParse(test.Attempt, out int attempts) && attempts > 1 => "Retake scheduled",
                "Pending" => "Scheduled",
                "Locked" => "Not started",
                "Passed" => "Passed",
                "Failed" => "Failed — retake required",
                _ => "Unavailable"
            };
            label.Text = $"{title}\r\n{status}";
            label.ForeColor = test.Status switch
            {
                "Passed" => Color.FromArgb(21, 128, 61),
                "Failed" => Color.FromArgb(185, 28, 28),
                "Pending" when test.Attempt != "Not Scheduled" => Color.FromArgb(37, 99, 235),
                _ => Color.FromArgb(100, 116, 139)
            };
            label.BackColor = test.Status == "Passed"
                ? Color.FromArgb(240, 253, 244) : Color.FromArgb(248, 250, 252);
        }

        public void DisplayTestAppointments(IEnumerable<TestAppointmentsRespondDto> testAppointments)
        {
            TestAppointmentsDataGridView.Rows.Clear();
            foreach (var appointment in testAppointments.OrderBy(a => a.AppointmentDate))
            {
                string result = appointment.TestResult switch
                {
                    "Success" => "Passed",
                    "Failure" => "Failed",
                    "Not Taken" => "Not taken",
                    _ => appointment.TestResult
                };
                string status = appointment.TestStatus == "Locked" ? "Completed" : "Scheduled";

                DateTime localDate = DateTime.SpecifyKind(appointment.AppointmentDate, DateTimeKind.Utc).ToLocalTime();

                int index = TestAppointmentsDataGridView.Rows.Add(appointment.TestAppointmentId,
                    localDate, status, appointment.PaidFees, result,
                    status == "Scheduled" ? "Record result" : "View details");

                var row = TestAppointmentsDataGridView.Rows[index];

                row.Cells["TestStatus"].Style.ForeColor = status == "Scheduled"
                    ? Color.FromArgb(37, 99, 235) : Color.FromArgb(100, 116, 139);

                row.Cells["TestResult"].Style.ForeColor = result switch
                {
                    "Passed" => Color.FromArgb(21, 128, 61),
                    "Failed" => Color.FromArgb(185, 28, 28),
                    _ => Color.FromArgb(100, 116, 139)
                };
            }
            int count = TestAppointmentsDataGridView.Rows.Count;
            lblAppointmentCount.Text = $"{count} appointment{(count == 1 ? "" : "s")} · {_testName}";
            TestAppointmentsDataGridView.ClearSelection();
        }

        private void AppointmentDetails_Click(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                TestAppointmentsDataGridView.Columns[e.ColumnIndex].Name != "Details") return;
            var row = TestAppointmentsDataGridView.Rows[e.RowIndex];
            if (string.Equals(row.Cells["TestStatus"].Value?.ToString(), "Scheduled", StringComparison.Ordinal))
            {
                RecordResultRequested?.Invoke(this, Convert.ToInt32(row.Cells["TestAppointmentId"].Value));
                return;
            }
            MessageBox.Show(this,
                $"Appointment #{row.Cells["TestAppointmentId"].Value}\n" +
                $"Test: {_testName}\n" +
                $"Date: {row.Cells["AppointmentDate"].FormattedValue}\n" +
                $"Status: {row.Cells["TestStatus"].Value}\n" +
                $"Paid fees: {row.Cells["PaidFees"].FormattedValue}\n" +
                $"Result: {row.Cells["TestResult"].Value}",
                "Appointment details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetSchedulingAvailability(bool allowed, string message)
        {
            CreateAppointmentButton.Enabled = allowed;
            DisplayMessage(message);
        }

        public void DisplayMessage(string message) => lblMessage.Text = message;
    }
}
