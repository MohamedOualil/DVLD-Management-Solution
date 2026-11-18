#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.Contracts.Tests;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Tests.Appointments
{
    public partial class ListTestAppointmentsControl : UserControl, IListTestAppointmentsView
    {
        private static readonly Image EnabledPlusIcon = Properties.Resources.icons8_add_properties_24;
        private static readonly Image DisabledPlusIcon = Properties.Resources.icons8_plus_teal_32;

        private string _testName = "Test";
        private int _hoveredRowIndex = -1;

        public event EventHandler? CreateAppointmentRequested;
        public event EventHandler<int>? RecordResultRequested;

        public ListTestAppointmentsControl()
        {
            InitializeComponent();
            CreateAppointmentButton.Image = CreateAppointmentButton.Enabled ? EnabledPlusIcon : DisabledPlusIcon;
            CreateAppointmentButton.ImageSize = new Size(15, 15);
            CreateAppointmentButton.ImageOffset = new Point(-2, 0);
            CreateAppointmentButton.Text = "New Appointment";

            TestAppointmentsDataGridView.CellPainting += OnGridCellPainting;
            TestAppointmentsDataGridView.CellMouseEnter += OnGridCellMouseEnter;
            TestAppointmentsDataGridView.CellMouseLeave += OnGridCellMouseLeave;
            TestAppointmentsDataGridView.MouseLeave += (_, _) => ClearHoverRow();
        }

        private void CreateAppointmentButton_Click(object? sender, EventArgs e) =>
            CreateAppointmentRequested?.Invoke(this, EventArgs.Empty);

        public void DisplayApplication(LocalApplicationResponse application, TestTypeEnum testType)
        {
            ArgumentNullException.ThrowIfNull(application);

            _testName = testType switch
            {
                TestTypeEnum.VisionTest => "Vision Test",
                TestTypeEnum.WrittenTest => "Written Test",
                TestTypeEnum.StreetTest => "Street Test",
                _ => "Test"
            };

            string icon = testType switch
            {
                TestTypeEnum.VisionTest => "VT",
                TestTypeEnum.WrittenTest => "WT",
                TestTypeEnum.StreetTest => "ST",
                _ => "TA"
            };

            pageHeader.Configure(
                $"{_testName} Appointments",
                $"Manage and review {_testName.ToLowerInvariant()} appointments for Local Application #{application.LocalId}",
                $"● {application.Status}",
                ResolveStatusTone(application.Status),
                showBackButton: false,
                iconText: icon);

            applicantBanner.Bind(application);
        }

        public void DisplayProgress(TestRoadmapResponse roadmap)
        {
            testRoadmapControl.Bind(roadmap);
        }

        public void DisplayTestAppointments(IEnumerable<TestAppointmentsRespond> testAppointments)
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

                int index = TestAppointmentsDataGridView.Rows.Add(
                    appointment.TestAppointmentId,
                    localDate,
                    status,
                    appointment.PaidFees,
                    result,
                    status == "Scheduled" ? "Record result" : "View details");

                var row = TestAppointmentsDataGridView.Rows[index];

                row.Cells["TestStatus"].Style.ForeColor = status == "Scheduled"
                    ? Color.FromArgb(13, 148, 136)
                    : Color.FromArgb(100, 116, 139);

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
                TestAppointmentsDataGridView.Columns[e.ColumnIndex].Name != "Details")
            {
                return;
            }

            var row = TestAppointmentsDataGridView.Rows[e.RowIndex];
            if (string.Equals(row.Cells["TestStatus"].Value?.ToString(), "Scheduled", StringComparison.Ordinal))
            {
                RecordResultRequested?.Invoke(this, Convert.ToInt32(row.Cells["TestAppointmentId"].Value));
                return;
            }

            MessageBox.Show(
                this,
                $"Appointment #{row.Cells["TestAppointmentId"].Value}\n" +
                $"Test: {_testName}\n" +
                $"Date: {row.Cells["AppointmentDate"].FormattedValue}\n" +
                $"Status: {row.Cells["TestStatus"].Value}\n" +
                $"Paid fees: {row.Cells["PaidFees"].FormattedValue}\n" +
                $"Result: {row.Cells["TestResult"].Value}",
                "Appointment details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void SetSchedulingAvailability(bool allowed, string message)
        {
            CreateAppointmentButton.Enabled = allowed;
            CreateAppointmentButton.Image = allowed ? EnabledPlusIcon : DisabledPlusIcon;
            statusBanner.SetMessage(
                message,
                allowed ? HeaderBadgeTone.Success : HeaderBadgeTone.Warning,
                allowed ? "Eligible to Schedule" : "Scheduling Restricted");
        }

        public void DisplayMessage(string message) =>
            statusBanner.SetMessage(message, HeaderBadgeTone.Info, "Appointment Status");

        private static HeaderBadgeTone ResolveStatusTone(string status) => status.Trim() switch
        {
            var s when s.Equals("Completed", StringComparison.OrdinalIgnoreCase) => HeaderBadgeTone.Success,
            var s when s.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) => HeaderBadgeTone.Danger,
            _ => HeaderBadgeTone.Info
        };

        private void OnGridCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string colName = TestAppointmentsDataGridView.Columns[e.ColumnIndex].Name;
            if (colName == "TestStatus" || colName == "TestResult")
            {
                DataGridViewUIHelper.DrawStatusBadge(e);
            }
        }

        private void OnGridCellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= TestAppointmentsDataGridView.Rows.Count)
                return;

            if (_hoveredRowIndex != e.RowIndex)
            {
                ClearHoverRow();
                _hoveredRowIndex = e.RowIndex;
                TestAppointmentsDataGridView.Rows[_hoveredRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 250);
            }

            bool isAction = e.ColumnIndex >= 0 && TestAppointmentsDataGridView.Columns[e.ColumnIndex].Name == "Details";
            TestAppointmentsDataGridView.Cursor = isAction ? Cursors.Hand : Cursors.Default;
        }

        private void OnGridCellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _hoveredRowIndex)
                ClearHoverRow();
        }

        private void ClearHoverRow()
        {
            if (_hoveredRowIndex >= 0 && _hoveredRowIndex < TestAppointmentsDataGridView.Rows.Count)
                TestAppointmentsDataGridView.Rows[_hoveredRowIndex].DefaultCellStyle.BackColor = Color.Empty;

            _hoveredRowIndex = -1;
            TestAppointmentsDataGridView.Cursor = Cursors.Default;
        }
    }
}
