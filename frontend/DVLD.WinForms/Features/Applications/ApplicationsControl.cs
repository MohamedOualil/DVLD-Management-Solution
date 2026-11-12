using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications
{
    public partial class ApplicationsControl : UserControl, IApplicationsView
    {
        public event EventHandler OnLoadDataRequested;
        public event EventHandler OnSearchChangeRequested;
        public event EventHandler<int> OnPageRequested;
        public event EventHandler<ApplicationMenuEventArgs> OnOpeningLocalAppActionMenu;
        public event EventHandler<int> OnCancelApplication;
        public event EventHandler<int> OnDeleteApplication;
        public event EventHandler IssueLicenseRequested;
        public event EventHandler<int> IssueDrivingLicenceRequested;
        public event EventHandler<int>? ShowLicenceRequested;

        public event EventHandler<PageModeEventArgs> OnApplicationDetailsRequested;
        public event EventHandler<ScheduleTestEventArgs> OnScheduleTestRequested;

        private int displayedPage = 1;
        private int displayedTotalPages = 1;
        private bool paginationLoading;

        public ApplicationsControl()
        {
            InitializeComponent();
            ApplicationsUIHelper.Configure(
                LocalDataGridView,
                paginationFooter,
                LocalAppActionMenu,
                CancelApplication,
                DeleteApplication);
            InitializeViewEvents();
            LoadStatusComboBox();
        }

        private void InitializeViewEvents()
        {
            previousPageButton.Click += (_, _) => OnPageRequested?.Invoke(this, displayedPage - 1);
            nextPageButton.Click += (_, _) => OnPageRequested?.Invoke(this, displayedPage + 1);

            LocalDataGridView.CellMouseDown += SelectContextRow;
            LocalDataGridView.CellDoubleClick += OpenRowOnDoubleClick;
            LocalDataGridView.RowsAdded += (_, _) => UpdateLoadedRecordCount();
            LocalDataGridView.RowsRemoved += (_, _) => UpdateLoadedRecordCount();
        }

        public string SearchTerm => this.txtSearch.Text;
        public int cbStatusId => this.cbStatus.SelectedIndex;

        public bool IsEditOptionEnabled { set => EditApplication.Enabled = value; }
        public bool IsCancelOptionEnabled { set => CancelApplication.Enabled = value; }
        public bool IsDeleteOptionEnabled { set => DeleteApplication.Enabled = value; }
        public bool IsIssueLicenseOptionEnabled { set => IssueDrivingLicence.Enabled = value; }
        public bool IsScheduleTestOptionEnabled { set => ScheduleTest.Enabled = value; }
        public bool IsShowLicenceOptionEnabled { set => ShowLicence.Enabled = value; }

        public bool IsScheduleVisionTestEnabled { set => ScheduleVisionTest.Enabled = value; }
        public bool IsScheduleWrittenTestEnabled { set => ScheduleWrittenTest.Enabled = value; }
        public bool IsScheduleStreetTestEnabled { set => ScheduleStreetTest.Enabled = value; }

        public void DisplayLocalApplications(IEnumerable<GetAllLocalApplicationsResponse> localApplications)
        {
            lblMessage.Visible = false;
            LocalDataGridView.Rows.Clear();

            foreach (var app in localApplications)
            {
                int rowIndex = LocalDataGridView.Rows.Add();

                LocalDataGridView.Rows[rowIndex].Cells["LocalID"].Value = app.LocalApplicationId;
                LocalDataGridView.Rows[rowIndex].Cells["NationalNo"].Value = app.NationalNo;
                LocalDataGridView.Rows[rowIndex].Cells["FullName"].Value = app.FullName;
                LocalDataGridView.Rows[rowIndex].Cells["Status"].Value = app.StatusName;
                LocalDataGridView.Rows[rowIndex].Cells["StatusId"].Value = app.StatusId;
                LocalDataGridView.Rows[rowIndex].Cells["ApplicationDate"].Value = app.ApplicationDate;
                LocalDataGridView.Rows[rowIndex].Cells["DrivingClass"].Value = app.DrivingClass;
                LocalDataGridView.Rows[rowIndex].Cells["PassedTest"].Value = $"{app.PassedTest}/3";
                LocalDataGridView.Rows[rowIndex].Cells["PassedTestId"].Value = app.PassedTest;
            }
        }

        private void UpdateLoadedRecordCount()
        {
            recordsLabel.Text = $"Showing {LocalDataGridView.Rows.Count} records";
            if (LocalDataGridView.Rows.Count > 0)
                lblMessage.Visible = false;
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            displayedPage = pageNumber;
            displayedTotalPages = Math.Max(1, totalPages);
            currentPageButton.Text = displayedPage.ToString();
            recordsLabel.Text = $"Showing {LocalDataGridView.Rows.Count} of {totalCount} records";
            SetPaginationLoading(paginationLoading);
        }

        public void SetPaginationLoading(bool isLoading)
        {
            paginationLoading = isLoading;
            previousPageButton.Enabled = !isLoading && displayedPage > 1;
            nextPageButton.Enabled = !isLoading && displayedPage < displayedTotalPages;
        }

        private void ApplicationsControl_Load(object sender, EventArgs e)
        {
            OnLoadDataRequested?.Invoke(this, EventArgs.Empty);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OnSearchChangeRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSearchChangeRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }

        private void SelectContextRow(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                LocalDataGridView.CurrentCell = LocalDataGridView.Rows[e.RowIndex].Cells["LocalID"];
        }

        private void OpenRowOnDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ShowApplication_Click(sender ?? this, EventArgs.Empty);
        }

        // --- Context Menu Handlers ---

        private void LocalAppActionMenu_Opening(object sender, CancelEventArgs e)
        {
            if (LocalDataGridView.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }
            DataGridViewRow row = LocalDataGridView.SelectedRows[0];

            int status = 0;
            if (row.Cells["StatusId"].Value != null)
            {
                int.TryParse(row.Cells["StatusId"].Value.ToString(), out status);
            }

            int PassedTestId = 0;
            if (row.Cells["PassedTestId"].Value != null)
            {
                int.TryParse(row.Cells["PassedTestId"].Value.ToString(), out PassedTestId);
            }

            OnOpeningLocalAppActionMenu?.Invoke(this, new ApplicationMenuEventArgs
                                        ((ApplicationStatusEnum)status, (PassedTestEnum)PassedTestId));
        }

        private int SelectedRow(string column)
        {
            DataGridViewRow row = LocalDataGridView.SelectedRows[0];

            int id = 0;
            if (row.Cells[column].Value != null)
            {
                int.TryParse(row.Cells[column].Value.ToString(), out id);
            }

            return id;
        }

        private void ShowApplication_Click(object sender, EventArgs e)
        {
            OnApplicationDetailsRequested?.Invoke(sender,
                    new PageModeEventArgs(
                                SelectedRow("LocalID"),
                                StatusMode.ViewMode));
        }

        private void EditApplication_Click(object sender, EventArgs e)
        {
            OnApplicationDetailsRequested?.Invoke(sender,
                    new PageModeEventArgs(
                                SelectedRow("LocalID"),
                                StatusMode.EditMode));
        }

        private void CancelApplication_Click(object sender, EventArgs e)
        {
            OnCancelApplication?.Invoke(sender, SelectedRow("LocalID"));
        }

        private void DeleteApplication_Click(object sender, EventArgs e)
        {
            OnDeleteApplication?.Invoke(sender, SelectedRow("LocalID"));
        }

        private void ScheduleVisionTest_Click(object sender, EventArgs e)
        {
            OnScheduleTestRequested?.Invoke(sender,
                new ScheduleTestEventArgs(
                                    SelectedRow("LocalID"),
                                    TestTypeEnum.VisionTest));
        }

        private void IssueLicenseButton_Click(object sender, EventArgs e)
        {
            IssueLicenseRequested?.Invoke(sender, EventArgs.Empty);
        }

        private void ScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            OnScheduleTestRequested?.Invoke(sender,
                new ScheduleTestEventArgs(
                                    SelectedRow("LocalID"),
                                    TestTypeEnum.WrittenTest));
        }

        private void ScheduleStreetTest_Click(object sender, EventArgs e)
        {
            OnScheduleTestRequested?.Invoke(sender,
                new ScheduleTestEventArgs(
                                    SelectedRow("LocalID"),
                                    TestTypeEnum.StreetTest));
        }

        private void IssueDrivingLicence_Click(object sender, EventArgs e)
        {
            IssueDrivingLicenceRequested?.Invoke(sender, SelectedRow("LocalID"));
        }

        private void ShowLicence_Click(object sender, EventArgs e)
        {
            if (LocalDataGridView.SelectedRows.Count == 0)
                return;

            int localApplicationId = SelectedRow("LocalID");
            if (localApplicationId <= 0)
            {
                DisplayMessage("Select a valid local driving licence application.");
                return;
            }

            ShowLicenceRequested?.Invoke(this, localApplicationId);
        }
    }
}
