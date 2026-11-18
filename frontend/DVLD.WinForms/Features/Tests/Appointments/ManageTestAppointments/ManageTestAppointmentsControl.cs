#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Shared.Events;
using DVLD.WinForms.Shared.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Tests.Appointments.ManageTestAppointments
{
    public partial class ManageTestAppointmentsControl : UserControl, IManageTestAppointmentsView
    {
        private bool _suppressFilterEvents;

        public event EventHandler? LoadRequested;
        public event EventHandler<int>? PageRequested;
        public event EventHandler? FilterChanged;
        public event EventHandler<ScheduleTestEventArgs>? ManageAppointmentsRequested;
        public event EventHandler<int>? ViewApplicationDetailsRequested;
        public event EventHandler<int>? ViewLicenseHistoryRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => txtSearch.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StageFilterIndex => cbStageFilter.SelectedIndex;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StatusFilterIndex => cbStatusFilter.SelectedIndex;

        public ManageTestAppointmentsControl()
        {
            InitializeComponent();
            ApplicationsUIHelper.Configure(
                AppointmentsQueueGrid,
                paginationFooter,
                QueueActionMenu);

            ApplyVectorIcons();

            _suppressFilterEvents = true;
            cbStageFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 1; // Default to active 'New' exam queue
            _suppressFilterEvents = false;
            ApplyStagePillStyles(0);

            txtSearch.TextChanged += (_, _) => RaiseFilterChanged();
            cbStageFilter.SelectedIndexChanged += (_, _) =>
            {
                ApplyStagePillStyles(cbStageFilter.SelectedIndex);
                RaiseFilterChanged();
            };
            cbStatusFilter.SelectedIndexChanged += (_, _) => RaiseFilterChanged();

            btnStageAll.Click += (_, _) => SelectStageFromPill(0);
            btnStageVision.Click += (_, _) => SelectStageFromPill(1);
            btnStageWritten.Click += (_, _) => SelectStageFromPill(2);
            btnStageStreet.Click += (_, _) => SelectStageFromPill(3);

            btnManageSelected.Click += (_, _) => OpenCurrentStageForSelectedRow();
            AppointmentsQueueGrid.SelectionChanged += (_, _) => UpdateSelectionButtonState();
            AppointmentsQueueGrid.CellDoubleClick += (_, e) =>
            {
                if (e.RowIndex >= 0)
                    OpenCurrentStageForSelectedRow();
            };
            AppointmentsQueueGrid.CellMouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < AppointmentsQueueGrid.Rows.Count)
                    AppointmentsQueueGrid.CurrentCell = AppointmentsQueueGrid.Rows[e.RowIndex].Cells["LocalID"];
            };

            QueueActionMenu.Opening += (_, _) => ConfigureActionMenuForSelectedRow();
            menuOpenNextTest.Click += (_, _) => OpenCurrentStageForSelectedRow();
            menuVisionAppointments.Click += (_, _) => RaiseForSelectedRow(TestTypeEnum.VisionTest);
            menuWrittenAppointments.Click += (_, _) => RaiseForSelectedRow(TestTypeEnum.WrittenTest);
            menuStreetAppointments.Click += (_, _) => RaiseForSelectedRow(TestTypeEnum.StreetTest);
            menuShowApplication.Click += (_, _) => RaiseIdEvent(ViewApplicationDetailsRequested);
            menuLicenceHistory.Click += (_, _) => RaiseIdEvent(ViewLicenseHistoryRequested);

            paginationFooter.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
        }

        private void ManageTestAppointmentsControl_Load(object? sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayApplications(IEnumerable<GetAllLocalApplicationsResponse> items)
        {
            AppointmentsQueueGrid.Rows.Clear();
            var list = items?.ToList() ?? [];

            foreach (var app in list)
            {
                int rowIndex = AppointmentsQueueGrid.Rows.Add();
                var row = AppointmentsQueueGrid.Rows[rowIndex];
                row.Cells["LocalID"].Value = app.LocalApplicationId;
                row.Cells["FullName"].Value = app.FullName;
                row.Cells["NationalNo"].Value = app.NationalNo;
                row.Cells["DrivingClass"].Value = app.DrivingClass;
                row.Cells["ApplicationDate"].Value = app.ApplicationDate;
                row.Cells["ExamStage"].Value = ResolveStageLabel(app.StatusId, app.PassedTest);
                row.Cells["PassedTest"].Value = $"{app.PassedTest}/3";
                row.Cells["PassedTestId"].Value = app.PassedTest;
                row.Cells["StatusId"].Value = app.StatusId;
            }

            lblEmptyState.Visible = AppointmentsQueueGrid.Rows.Count == 0;
            UpdateSelectionButtonState();
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            paginationFooter.DisplayPagination(
                pageNumber,
                totalPages,
                totalCount,
                AppointmentsQueueGrid.Rows.Count,
                "exam applications");
        }

        public void SetLoading(bool isLoading)
        {
            paginationFooter.SetLoading(isLoading);
            UseWaitCursor = isLoading;
        }

        public void SetKpiSummary(int totalActiveExams, int visionQueue, int writtenQueue, int streetQueue)
        {
            btnStageAll.Text = $"All Active Exams ({totalActiveExams})";
            btnStageVision.Text = $"Vision Test Queue ({visionQueue})";
            btnStageWritten.Text = $"Written Test Queue ({writtenQueue})";
            btnStageStreet.Text = $"Street Test Queue ({streetQueue})";
        }

        public void DisplayMessage(string message)
        {
            if (AppointmentsQueueGrid.Rows.Count == 0)
            {
                lblEmptyState.Text = message;
                lblEmptyState.Visible = true;
            }
            else
            {
                MessageBox.Show(this, message, "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SelectStageFromPill(int index)
        {
            _suppressFilterEvents = true;
            try
            {
                cbStageFilter.SelectedIndex = index;
                if (cbStatusFilter.SelectedIndex != 1)
                    cbStatusFilter.SelectedIndex = 1;
            }
            finally
            {
                _suppressFilterEvents = false;
            }

            ApplyStagePillStyles(index);
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void RaiseFilterChanged()
        {
            if (!_suppressFilterEvents)
                FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ApplyStagePillStyles(int activeIndex)
        {
            StylePillButton(btnStageAll, activeIndex == 0);
            StylePillButton(btnStageVision, activeIndex == 1);
            StylePillButton(btnStageWritten, activeIndex == 2);
            StylePillButton(btnStageStreet, activeIndex == 3);
        }

        private void ApplyVectorIcons()
        {
            txtSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtSearch.IconLeftSize = new Size(16, 16);
            txtSearch.TextOffset = new Point(0, 0);

            btnStageAll.Image = Properties.Resources.icons8_services_32;
            btnStageVision.Image = Properties.Resources.icons8_view_30;
            btnStageWritten.Image = Properties.Resources.icons8_note_48;
            btnStageStreet.Image = Properties.Resources.icons8_car_48;

            menuOpenNextTest.Image = Properties.Resources.icons8_test_30;
            menuVisionAppointments.Image = Properties.Resources.icons8_view_30;
            menuWrittenAppointments.Image = Properties.Resources.icons8_note_48;
            menuStreetAppointments.Image = Properties.Resources.icons8_car_48;
            menuShowApplication.Image = Properties.Resources.icons8_view_30;
            menuLicenceHistory.Image = Properties.Resources.icons8_history_48;
        }

        private static void StylePillButton(Guna2Button button, bool active)
        {
            if (active)
            {
                button.FillColor = Color.FromArgb(13, 148, 136);
                button.BorderColor = Color.FromArgb(13, 148, 136);
                button.ForeColor = Color.White;
            }
            else
            {
                button.FillColor = Color.White;
                button.BorderColor = Color.FromArgb(226, 232, 240);
                button.ForeColor = Color.FromArgb(51, 65, 85);
            }

            button.ImageSize = new Size(15, 15);
            button.ImageOffset = new Point(-2, 0);
        }

        private void UpdateSelectionButtonState()
        {
            if (AppointmentsQueueGrid.SelectedRows.Count == 0)
            {
                btnManageSelected.Enabled = false;
                btnManageSelected.Text = "Schedule / Manage Test ↗";
                return;
            }

            var row = AppointmentsQueueGrid.SelectedRows[0];
            _ = int.TryParse(row.Cells["PassedTestId"].Value?.ToString(), out int passed);
            _ = int.TryParse(row.Cells["StatusId"].Value?.ToString(), out int statusId);

            if (statusId == (int)ApplicationStatusEnum.Cancelled)
            {
                btnManageSelected.Enabled = false;
                btnManageSelected.Text = "Application Cancelled";
                return;
            }

            btnManageSelected.Enabled = true;
            btnManageSelected.Text = passed switch
            {
                0 => "Open Vision Appointments ↗",
                1 => "Open Written Appointments ↗",
                2 => "Open Street Appointments ↗",
                _ => "Inspect Street Appointments ↗"
            };
        }

        private void ConfigureActionMenuForSelectedRow()
        {
            if (AppointmentsQueueGrid.SelectedRows.Count == 0)
            {
                menuOpenNextTest.Enabled = false;
                menuVisionAppointments.Enabled = false;
                menuWrittenAppointments.Enabled = false;
                menuStreetAppointments.Enabled = false;
                return;
            }

            var row = AppointmentsQueueGrid.SelectedRows[0];
            _ = int.TryParse(row.Cells["PassedTestId"].Value?.ToString(), out int passed);
            _ = int.TryParse(row.Cells["StatusId"].Value?.ToString(), out int statusId);
            bool notCancelled = statusId != (int)ApplicationStatusEnum.Cancelled;

            menuOpenNextTest.Enabled = notCancelled;
            menuVisionAppointments.Enabled = notCancelled;
            menuWrittenAppointments.Enabled = notCancelled && passed >= 1;
            menuStreetAppointments.Enabled = notCancelled && passed >= 2;
        }

        private void OpenCurrentStageForSelectedRow()
        {
            if (AppointmentsQueueGrid.SelectedRows.Count == 0)
                return;

            var row = AppointmentsQueueGrid.SelectedRows[0];
            if (!int.TryParse(row.Cells["LocalID"].Value?.ToString(), out int localId) || localId <= 0)
                return;

            _ = int.TryParse(row.Cells["PassedTestId"].Value?.ToString(), out int passed);
            var testType = passed switch
            {
                0 => TestTypeEnum.VisionTest,
                1 => TestTypeEnum.WrittenTest,
                _ => TestTypeEnum.StreetTest
            };

            ManageAppointmentsRequested?.Invoke(this, new ScheduleTestEventArgs(localId, testType));
        }

        private void RaiseForSelectedRow(TestTypeEnum testType)
        {
            if (AppointmentsQueueGrid.SelectedRows.Count == 0)
                return;

            if (int.TryParse(AppointmentsQueueGrid.SelectedRows[0].Cells["LocalID"].Value?.ToString(), out int localId) && localId > 0)
                ManageAppointmentsRequested?.Invoke(this, new ScheduleTestEventArgs(localId, testType));
        }

        private void RaiseIdEvent(EventHandler<int>? handler)
        {
            if (AppointmentsQueueGrid.SelectedRows.Count == 0)
                return;

            if (int.TryParse(AppointmentsQueueGrid.SelectedRows[0].Cells["LocalID"].Value?.ToString(), out int localId) && localId > 0)
                handler?.Invoke(this, localId);
        }

        private static string ResolveStageLabel(int statusId, int passedTests)
        {
            if (statusId == (int)ApplicationStatusEnum.Cancelled)
                return "Cancelled";
            if (statusId == (int)ApplicationStatusEnum.Completed || passedTests >= 3)
                return "Ready to Issue";

            return passedTests switch
            {
                0 => "Vision Test",
                1 => "Written Test",
                2 => "Street Test",
                _ => "Ready to Issue"
            };
        }
    }
}
