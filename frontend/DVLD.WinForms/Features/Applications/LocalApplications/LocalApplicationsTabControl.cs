#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications.LocalApplications
{
    public partial class LocalApplicationsTabControl : UserControl, ILocalApplicationsTabView
    {
        private int _displayedPage = 1;
        private int _displayedTotalPages = 1;
        private int _totalRecordCount;

        public event EventHandler? SearchOrFilterChanged;
        public event EventHandler<int>? PageRequested;
        public event EventHandler<ApplicationMenuEventArgs>? OpeningActionMenu;
        public event EventHandler<PageModeEventArgs>? ApplicationDetailsRequested;
        public event EventHandler<int>? CancelApplicationRequested;
        public event EventHandler<int>? DeleteApplicationRequested;
        public event EventHandler<ScheduleTestEventArgs>? ScheduleTestRequested;
        public event EventHandler<int>? IssueDrivingLicenceRequested;
        public event EventHandler<int>? ShowLicenceRequested;
        public event EventHandler<int>? LicenseHistoryRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => txtSearch.Text;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StatusFilterId => cbStatus.SelectedIndex;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEditOptionEnabled { set => EditApplication.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCancelOptionEnabled { set => CancelApplication.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDeleteOptionEnabled { set => DeleteApplication.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIssueLicenseOptionEnabled { set => IssueDrivingLicence.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsScheduleTestOptionEnabled { set => ScheduleTest.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsShowLicenceOptionEnabled { set => ShowLicence.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsScheduleVisionTestEnabled { set => ScheduleVisionTest.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsScheduleWrittenTestEnabled { set => ScheduleWrittenTest.Enabled = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsScheduleStreetTestEnabled { set => ScheduleStreetTest.Enabled = value; }

        public LocalApplicationsTabControl()
        {
            InitializeComponent();
            ApplicationsUIHelper.Configure(
                LocalDataGridView,
                paginationFooter,
                LocalAppActionMenu,
                CancelApplication,
                DeleteApplication);

            ApplyActionMenuIcons();
            LoadStatusComboBox();
            WireEvents();
        }

        private void ApplyActionMenuIcons()
        {
            txtSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtSearch.IconLeftSize = new Size(16, 16);
            txtSearch.TextOffset = new Point(0, 0);
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            cbStatus.SelectedIndexChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            paginationFooter.PageRequested += (_, page) => PageRequested?.Invoke(this, page);

            LocalDataGridView.CellMouseDown += OnGridCellMouseDown;
            LocalDataGridView.CellDoubleClick += OnGridCellDoubleClick;
            LocalDataGridView.RowsAdded += (_, _) => UpdateLoadedRecordCount();
            LocalDataGridView.RowsRemoved += (_, _) => UpdateLoadedRecordCount();

            LocalAppActionMenu.Opening += OnActionMenuOpening;
            ShowApplication.Click += (_, _) => RaiseDetails(StatusMode.ViewMode);
            EditApplication.Click += (_, _) => RaiseDetails(StatusMode.EditMode);
            CancelApplication.Click += (_, _) => RaiseIdEvent(CancelApplicationRequested);
            DeleteApplication.Click += (_, _) => RaiseIdEvent(DeleteApplicationRequested);
            ScheduleVisionTest.Click += (_, _) => RaiseScheduleTest(TestTypeEnum.VisionTest);
            ScheduleWrittenTest.Click += (_, _) => RaiseScheduleTest(TestTypeEnum.WrittenTest);
            ScheduleStreetTest.Click += (_, _) => RaiseScheduleTest(TestTypeEnum.StreetTest);
            IssueDrivingLicence.Click += (_, _) => RaiseIdEvent(IssueDrivingLicenceRequested);
            ShowLicence.Click += (_, _) => RaiseValidatedIdEvent(ShowLicenceRequested);
            LicenceHistory.Click += (_, _) => RaiseValidatedIdEvent(LicenseHistoryRequested);
        }

        public void DisplayLocalApplications(IEnumerable<GetAllLocalApplicationsResponse> localApplications)
        {
            lblMessage.Visible = false;
            LocalDataGridView.Rows.Clear();

            foreach (var app in localApplications)
            {
                int rowIndex = LocalDataGridView.Rows.Add();
                var row = LocalDataGridView.Rows[rowIndex];
                row.Cells["LocalID"].Value = app.LocalApplicationId;
                row.Cells["NationalNo"].Value = app.NationalNo;
                row.Cells["FullName"].Value = app.FullName;
                row.Cells["Status"].Value = app.StatusName;
                row.Cells["StatusId"].Value = app.StatusId;
                row.Cells["ApplicationDate"].Value = app.ApplicationDate;
                row.Cells["DrivingClass"].Value = app.DrivingClass;
                row.Cells["PassedTest"].Value = $"{app.PassedTest}/3";
                row.Cells["PassedTestId"].Value = app.PassedTest;
            }
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            _displayedPage = Math.Max(1, pageNumber);
            _displayedTotalPages = Math.Max(1, totalPages);
            _totalRecordCount = Math.Max(0, totalCount);
            paginationFooter.DisplayPagination(
                _displayedPage,
                _displayedTotalPages,
                _totalRecordCount,
                LocalDataGridView.Rows.Count,
                "applications");
        }

        public void SetPaginationLoading(bool isLoading)
        {
            paginationFooter.SetLoading(isLoading);
        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }

        private void LoadStatusComboBox()
        {
            var statuses = new List<ComboBoxItem>
            {
                new ComboBoxItem { Id = 0, Text = "All Statuses" },
                new ComboBoxItem { Id = 1, Text = "New" },
                new ComboBoxItem { Id = 2, Text = "Cancelled" },
                new ComboBoxItem { Id = 3, Text = "Completed" }
            };
            cbStatus.DataSource = statuses;
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Id";
            cbStatus.SelectedIndex = 0;
        }

        private void UpdateLoadedRecordCount()
        {
            int visibleCount = LocalDataGridView.Rows.Count;
            paginationFooter.DisplayPagination(
                _displayedPage,
                _displayedTotalPages,
                Math.Max(_totalRecordCount, visibleCount),
                visibleCount,
                "applications");

            if (visibleCount > 0)
                lblMessage.Visible = false;
        }

        private void OnGridCellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                LocalDataGridView.CurrentCell = LocalDataGridView.Rows[e.RowIndex].Cells["LocalID"];
        }

        private void OnGridCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                RaiseDetails(StatusMode.ViewMode);
        }

        private void OnActionMenuOpening(object? sender, CancelEventArgs e)
        {
            if (LocalDataGridView.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            var row = LocalDataGridView.SelectedRows[0];
            _ = int.TryParse(row.Cells["StatusId"].Value?.ToString(), out int status);
            _ = int.TryParse(row.Cells["PassedTestId"].Value?.ToString(), out int passedTestId);

            OpeningActionMenu?.Invoke(this, new ApplicationMenuEventArgs(
                (ApplicationStatusEnum)status,
                (PassedTestEnum)passedTestId));
        }

        private int SelectedLocalId()
        {
            if (LocalDataGridView.SelectedRows.Count == 0)
                return 0;

            var value = LocalDataGridView.SelectedRows[0].Cells["LocalID"].Value?.ToString();
            return int.TryParse(value, out int id) ? id : 0;
        }

        private void RaiseDetails(StatusMode mode)
        {
            int id = SelectedLocalId();
            if (id > 0)
                ApplicationDetailsRequested?.Invoke(this, new PageModeEventArgs(id, mode));
        }

        private void RaiseIdEvent(EventHandler<int>? handler)
        {
            int id = SelectedLocalId();
            if (id > 0)
                handler?.Invoke(this, id);
        }

        private void RaiseValidatedIdEvent(EventHandler<int>? handler)
        {
            if (LocalDataGridView.SelectedRows.Count == 0)
                return;

            int id = SelectedLocalId();
            if (id <= 0)
            {
                DisplayMessage("Select a valid local driving licence application.");
                return;
            }

            handler?.Invoke(this, id);
        }

        private void RaiseScheduleTest(TestTypeEnum testType)
        {
            int id = SelectedLocalId();
            if (id > 0)
                ScheduleTestRequested?.Invoke(this, new ScheduleTestEventArgs(id, testType));
        }
    }
}
