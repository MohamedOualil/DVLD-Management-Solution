using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using DVLD.WinForms.Shared.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private ApplicationsPresenter _presenter;

        public event EventHandler OnLoadDataRequested;
        public event EventHandler OnSearchChangeRequested;
        public event EventHandler<ApplicationMenuEventArgs> OnOpeningLocalAppActionMenu;
        public ApplicationsControl(ApplicationsPresenter presenter)
        {
            InitializeComponent();
            LoadStatusComboBox();
            _presenter = presenter;
            _presenter.SetView(this);
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

                LocalDataGridView.Rows[rowIndex].Cells["LocalId"].Value = app.LocalApplicationId;
                LocalDataGridView.Rows[rowIndex].Cells["NationalNo"].Value = app.NationalNo;
                LocalDataGridView.Rows[rowIndex].Cells["FullName"].Value = app.FullName;
                LocalDataGridView.Rows[rowIndex].Cells["Status"].Value = app.StatusName;
                LocalDataGridView.Rows[rowIndex].Cells["StatusId"].Value = app.StatusId;
                LocalDataGridView.Rows[rowIndex].Cells["ApplicationDate"].Value = app.ApplicationDate;
                LocalDataGridView.Rows[rowIndex].Cells["DrivingClass"].Value = app.DrivingClass;
                LocalDataGridView.Rows[rowIndex].Cells["PassedTest"].Value = $"{app.PassedTest}/3";
                LocalDataGridView.Rows[rowIndex].Cells["PassedTestId"].Value = app.PassedTest;
            }

            int rowIndex2 = LocalDataGridView.Rows.Add();

            LocalDataGridView.Rows[rowIndex2].Cells["LocalId"].Value = 4;
            LocalDataGridView.Rows[rowIndex2].Cells["NationalNo"].Value = "fgdgdg452";
            LocalDataGridView.Rows[rowIndex2].Cells["FullName"].Value = "ibrahim ahmed";
            LocalDataGridView.Rows[rowIndex2].Cells["Status"].Value = "New";
            LocalDataGridView.Rows[rowIndex2].Cells["StatusId"].Value = 3;
            LocalDataGridView.Rows[rowIndex2].Cells["ApplicationDate"].Value = DateTime.Now ;
            LocalDataGridView.Rows[rowIndex2].Cells["DrivingClass"].Value = "MY calss";
            LocalDataGridView.Rows[rowIndex2].Cells["PassedTest"].Value = $"3/3";
            LocalDataGridView.Rows[rowIndex2].Cells["PassedTestId"].Value = 3;


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
            if (row.Cells["PassedTestId"].Value!= null)
            {
                int.TryParse(row.Cells["PassedTestId"].Value.ToString(), out PassedTestId);
            }


            OnOpeningLocalAppActionMenu?.Invoke(this, new ApplicationMenuEventArgs
                                        ((ApplicationStatusEnum)status, (PassedTestEnum)PassedTestId));

        }
    }
}
