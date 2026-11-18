#nullable enable
using DVLD.WinForms.Shared.Controls;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Tests.ScheduleTest
{
    public partial class ScheduleTestControl : UserControl, IScheduleTestView
    {
        public event EventHandler? SaveRequested;

        public ScheduleTestControl()
        {
            InitializeComponent();
            tpAppointmentDate.Format = DateTimePickerFormat.Custom;
            tpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            tpAppointmentDate.Value = DateTime.Now.AddDays(1);

            pageActionFooter.PrimaryActionRequested += (_, _) => SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime AppointmentDate =>
            DateTime.SpecifyKind(
                tpAppointmentDate.Value,
                DateTimeKind.Local).ToUniversalTime();

        public void DisplayTestInfo(SchelduleTestDto testInfo)
        {
            ArgumentNullException.ThrowIfNull(testInfo);

            pageHeader.Configure(
                $"Schedule {testInfo.TestName}",
                $"Select an appointment slot for Local Application #{testInfo.LocalId}",
                testInfo.TrialsCount > 0 ? $"● Retake #{testInfo.TrialsCount + 1}" : "● First Attempt",
                testInfo.TrialsCount > 0 ? HeaderBadgeTone.Warning : HeaderBadgeTone.Info,
                showBackButton: false,
                iconText: "ST");

            applicantBanner.FullName = testInfo.FullName;
            applicantBanner.NationalNo = testInfo.NationalNo;
            applicantBanner.LocalApplicationId = testInfo.LocalId.ToString();
            applicantBanner.LicenseClassName = testInfo.LicenseClassName;
            applicantBanner.ImagePath = testInfo.PersonImagePath ?? string.Empty;
            applicantBanner.DateOfBirthText = testInfo.DateOfBirth == default
                ? $"{testInfo.Age} yrs"
                : $"{testInfo.DateOfBirth.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)} • {testInfo.Age} yrs";

            applicationMetadataCard.LocalApplicationId = testInfo.LocalId.ToString();
            applicationMetadataCard.ApplicationId = "—";
            applicationMetadataCard.ApplicationType = testInfo.ApplicationType;
            applicationMetadataCard.PaidFeesText = testInfo.TestFees.ToString("C");
            applicationMetadataCard.ApplicationDateText = DateTime.Today.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            applicationMetadataCard.StatusDateText = "Active";
            applicationMetadataCard.CreatedBy = "Examination Desk";
            applicationMetadataCard.SelectLicenseClassByName(testInfo.LicenseClassName);

            lblTestName.Text = testInfo.TestName;
            lblFees.Text = testInfo.TestFees.ToString("C");
            lblTrail.Text = testInfo.TrialsCount == 1
                ? "1 prior attempt"
                : $"{testInfo.TrialsCount} prior attempts";
        }

        public void SetSaving(bool isSaving)
        {
            tpAppointmentDate.Enabled = !isSaving;
            pageActionFooter.SetBusy(isSaving, "Saving…");
            if (!isSaving)
                pageActionFooter.PrimaryButtonEnabled = true;
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
    }
}
