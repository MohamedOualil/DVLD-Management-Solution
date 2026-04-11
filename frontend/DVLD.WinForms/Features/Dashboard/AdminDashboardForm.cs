using DVLD.WinForms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Dashboard
{
    public partial class AdminDashboardForm : Form , IAdminDashboardView
    {
        public event EventHandler ?OnLoadApplicationsClicked; 
        public event EventHandler ?OnLogoutClicked;

        public Control MainContentPanel => this.MainPanal;

        private AdminDashboardPresenter _presenter;
        public AdminDashboardForm(AdminDashboardPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            _presenter.SetView(this);
        }

        private void ApplicationsButton_Click(object sender, EventArgs e)
        {
            OnLoadApplicationsClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
