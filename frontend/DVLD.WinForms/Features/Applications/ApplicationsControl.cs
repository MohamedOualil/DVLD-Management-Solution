using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using DVLD.WinForms.Shared.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications
{
    public partial class ApplicationsControl : UserControl, IApplicationsView
    {


        public event EventHandler OnLoadDataRequested;
        public event EventHandler OnSearchChangeRequested;
        public event EventHandler<ApplicationMenuEventArgs> OnOpeningLocalAppActionMenu;
        public event EventHandler<int> OnCancelApplication;
        public event EventHandler<int> OnDeleteApplication;
        public event EventHandler IssueLicenseRequested;

        public event EventHandler<PageModeEventArgs> OnApplicationDetailsRequested;

        public event EventHandler<ScheduleTestEventArgs> OnScheduleTestRequested;

        public ApplicationsControl()
        {
            InitializeComponent();
            //LocalDataGridView.AutoGenerateColumns = false;
            LoadStatusComboBox();
            LocalAppActionMenu.DropShadowEnabled = true;

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

        public void DisplayLocalApplications(IEnumerable<LocalApplicationsDto> localApplications)
        {
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

        private void ApplicationsControl_Load(object sender, EventArgs e)
        {
            OnLoadDataRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LocalDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Ignore headers or empty rows
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null) return;

            // Turn on Anti-Aliasing for smooth circles and edges
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Delegate to our Helper Class based on YOUR specific column names!
            if (LocalDataGridView.Columns[e.ColumnIndex].Name == "Status")
            {
                DataGridViewUIHelper.DrawStatusBadge(e);
            }
            else if (LocalDataGridView.Columns[e.ColumnIndex].Name == "FullName")
            {
                DataGridViewUIHelper.DrawAvatarAndName(e);
            }

            else if (LocalDataGridView.Columns[e.ColumnIndex].Name == "PassedTest")
            {
                DataGridViewUIHelper.DrawProgressBar(e);
            }
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
                                SelectedRow("LocalId"),
                                StatusMode.ViewMode));
        }

        private void EditApplication_Click(object sender, EventArgs e)
        {
            OnApplicationDetailsRequested?.Invoke(sender,
                    new PageModeEventArgs(
                                SelectedRow("LocalId"),
                                StatusMode.EditMode));
        }

        private void CancelApplication_Click(object sender, EventArgs e)
        {
            OnCancelApplication?.Invoke(sender, SelectedRow("ApplicationId"));
        }

        private void DeleteApplication_Click(object sender, EventArgs e)
        {
            OnDeleteApplication?.Invoke(sender, SelectedRow("LocalId"));
        }

        private void ScheduleVisionTest_Click(object sender, EventArgs e)
        {
            OnScheduleTestRequested?.Invoke(sender,
                new ScheduleTestEventArgs(
                                    SelectedRow("LocalId"),
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
                                    SelectedRow("LocalId"),
                                    TestTypeEnum.WrittenTest));
        }

        private void ScheduleStreetTest_Click(object sender, EventArgs e)
        {
            OnScheduleTestRequested?.Invoke(sender,
                new ScheduleTestEventArgs(
                                    SelectedRow("LocalId"),
                                    TestTypeEnum.StreetTest));
        }
    }
}
