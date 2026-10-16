using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Test_Appointments;
using DVLD.WinForms.Shared.Enums;
namespace DVLD.WinForms.Features.Test.RecordTestResult
{
    public partial class RecordTestResultControl : UserControl , IRecordTestResultView
    {
        private bool _canRecord;
        public event EventHandler? SaveRequested;
        public event EventHandler? CancelRequested;
        public bool? Passed => PassRadioButton.Checked ? true : FailRadioButton.Checked ? false : null;
        public string Notes => NotesTextBox.Text.Trim();

        public RecordTestResultControl()
        {
            InitializeComponent();
            SaveResultButton.Click += (_, _) => SaveRequested?.Invoke(this, EventArgs.Empty);
            CancelButton.Click += (_, _) => CancelRequested?.Invoke(this, EventArgs.Empty);
            BackButton.Click += (_, _) => CancelRequested?.Invoke(this, EventArgs.Empty);
            SetRecordingAvailability(false, "Loading appointment information…");
        }

        public void DisplayApplication(ApplicationDetailDto application)
        {
            lblFullName.Text = application.FullName;
            lblNationalNo.Text = $"National number: {application.NationalNo}";
            lblLocalApplicationId.Text = $"#{application.LocalId}";
            lblLicenseClass.Text = application.LicenseClassName;
        }

        public void DisplayAppointment(TestAppointmentsRespondDto appointment,TestTypeEnum type, int attempt)
        {
            string name = type switch
            {
                TestTypeEnum.VisionTest => "Vision Test",
                TestTypeEnum.WrittenTest => "Written Test",
                TestTypeEnum.StreetTest => "Street Test",
                _ => "Test"
            };
            lblTestName.Text = name;
            lblAppointmentTestType.Text = name;
            lblAppointmentId.Text = $"#{appointment.TestAppointmentId}";
            lblAppointmentDate.Text = DateTime.SpecifyKind(appointment.AppointmentDate,
                DateTimeKind.Utc).ToLocalTime().ToString("dd/MM/yyyy HH:mm");
            lblAttempt.Text = attempt.ToString();
            lblPaidFees.Text = appointment.PaidFees.ToString("C");
            lblAppointmentStatus.Text = appointment.TestStatus == "Locked" ? "Completed" : "Scheduled";
            PassRadioButton.Checked = false;
            FailRadioButton.Checked = false;
            NotesTextBox.Clear();
        }

        public void SetRecordingAvailability(bool allowed, string message)
        {
            _canRecord = allowed;
            infoBanner.Text = message;
            SetSaving(false);
        }

        public void SetSaving(bool saving)
        {
            SaveResultButton.Enabled = _canRecord && !saving;
            PassRadioButton.Enabled = _canRecord && !saving;
            FailRadioButton.Enabled = _canRecord && !saving;
            NotesTextBox.Enabled = _canRecord && !saving;
            CancelButton.Enabled = !saving;
            BackButton.Enabled = !saving;
            SaveResultButton.Text = saving ? "Saving…" : "Save result";
        }

        public void DisplayMessage(string message) => MessageBox.Show(this, message,
            "Record test result", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

