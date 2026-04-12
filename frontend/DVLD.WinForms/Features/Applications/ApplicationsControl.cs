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
        public ApplicationsControl(ApplicationsPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this);
            LocalAppActionMenu.DropShadowEnabled = true;

        }

        //public Panel LocalApplicationsPanel => this.LocalApplicationsTab;
        //public Panel InternationalLicensesPanel => this.InternationalLicensesTab;
        //public Panel DetainedLicensesPanel => this.DetainedLicensesTab;

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
                LocalDataGridView.Rows[rowIndex].Cells["ApplicationDate"].Value = app.ApplicationDate;
                LocalDataGridView.Rows[rowIndex].Cells["DrivingClass"].Value = app.DrivingClass;
                LocalDataGridView.Rows[rowIndex].Cells["PassedTest"].Value = $"{app.PassedTest}/3";
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

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
