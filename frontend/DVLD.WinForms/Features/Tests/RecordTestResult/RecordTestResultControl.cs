#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Shared.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Tests.RecordTestResult
{
    public partial class RecordTestResultControl : UserControl, IRecordTestResultView
    {
        private bool _canRecord;

        public event EventHandler? SaveRequested;
        public event EventHandler? HasChangesRequested;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool? Passed => PassRadioButton.Checked ? true : FailRadioButton.Checked ? false : null;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Notes => NotesTextBox.Text.Trim();

        public RecordTestResultControl()
        {
            InitializeComponent();
            PassRadioButton.CheckedChanged += OutcomeRadio_CheckedChanged;
            FailRadioButton.CheckedChanged += OutcomeRadio_CheckedChanged;
            pageActionFooter.PrimaryActionRequested += (_, _) => SaveRequested?.Invoke(this, EventArgs.Empty);
            SetRecordingAvailability(false, "Loading appointment information…");
        }

        private void OutcomeRadio_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender == PassRadioButton && PassRadioButton.Checked)
                FailRadioButton.Checked = false;
            else if (sender == FailRadioButton && FailRadioButton.Checked)
                PassRadioButton.Checked = false;

            passOptionBox.BorderThickness = PassRadioButton.Checked ? 2 : 1;
            passOptionBox.BorderColor = PassRadioButton.Checked
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(187, 247, 208);

            failOptionBox.BorderThickness = FailRadioButton.Checked ? 2 : 1;
            failOptionBox.BorderColor = FailRadioButton.Checked
                ? Color.FromArgb(220, 38, 38)
                : Color.FromArgb(254, 202, 202);
        }

        public void DisplayApplication(LocalApplicationResponse application)
        {
            ArgumentNullException.ThrowIfNull(application);
            applicantBanner.Bind(application);
        }

        public void DisplayAppointment(TestAppointmentsRespond appointment, TestTypeEnum type, int attempt)
        {
            ArgumentNullException.ThrowIfNull(appointment);

            string name = type switch
            {
                TestTypeEnum.VisionTest => "Vision Test",
                TestTypeEnum.WrittenTest => "Written Test",
                TestTypeEnum.StreetTest => "Street Test",
                _ => "Test"
            };

            string status = appointment.TestStatus == "Locked" ? "Completed" : "Scheduled";

            pageHeader.Configure(
                $"Record {name} Result",
                $"Appointment #{appointment.TestAppointmentId} · Attempt {attempt}",
                $"● {status}",
                status == "Completed" ? HeaderBadgeTone.Success : HeaderBadgeTone.Info,
                showBackButton: false,
                iconText: "TR");

            lblTestName.Text = name;
            lblAppointmentTestType.Text = name;
            lblAppointmentId.Text = $"#{appointment.TestAppointmentId}";
            lblAppointmentDate.Text = DateTime.SpecifyKind(appointment.AppointmentDate, DateTimeKind.Utc)
                .ToLocalTime()
                .ToString("dd MMM yyyy, HH:mm");
            lblAttempt.Text = attempt.ToString();
            lblPaidFees.Text = appointment.PaidFees.ToString("C");
            lblAppointmentStatus.Text = status;
            lblAppointmentStatus.ForeColor = status == "Completed"
                ? Color.FromArgb(21, 128, 61)
                : Color.FromArgb(13, 148, 136);

            PassRadioButton.Checked = false;
            FailRadioButton.Checked = false;
            NotesTextBox.Clear();
        }

        public void SetRecordingAvailability(bool allowed, string message)
        {
            _canRecord = allowed;
            statusBanner.SetMessage(
                message,
                allowed ? HeaderBadgeTone.Info : HeaderBadgeTone.Warning,
                allowed ? "Ready to Record Outcome" : "Recording Restricted");
            SetSaving(false);
        }

        public void SetSaving(bool saving)
        {
            PassRadioButton.Enabled = _canRecord && !saving;
            FailRadioButton.Enabled = _canRecord && !saving;
            NotesTextBox.Enabled = _canRecord && !saving;

            pageActionFooter.SetBusy(saving, "Saving…");
            if (!saving)
            {
                pageActionFooter.SetState(
                    _canRecord,
                    _canRecord
                        ? "Select Pass or Fail, add optional notes, then save the test result."
                        : statusBanner.Description,
                    isWarningOrError: !_canRecord);
            }
        }

        public void DisplayMessage(string message) => MessageBox.Show(
            this,
            message,
            "Record test result",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void NotesTextBox_TextChanged(object? sender, EventArgs e)
        {
            HasChangesRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
