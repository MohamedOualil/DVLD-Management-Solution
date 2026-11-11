using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Dashboard
{
    public partial class AdminDashboardForm : Form, IAdminDashboardView
    {
        public event EventHandler? OnLoadApplicationsClicked;
        public event EventHandler? OnLogoutClicked;

        public Control MainContentPanel => this.MainPanal;

        private readonly AdminDashboardPresenter _presenter;

        public AdminDashboardForm(AdminDashboardPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            _presenter.SetView(this);
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            ApplicationsButton_Click(this, EventArgs.Empty);
        }

        // --- Sidebar Navigation Click Events ---

        private void ApplicationsButton_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(ApplicationsButton, "DVLD  /  OPERATIONS", "Applications");
            OnLoadApplicationsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnTestAppointments_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnTestAppointments, "DVLD  /  OPERATIONS", "Test Appointments");
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnRenewLicense, "DVLD  /  LICENSE SERVICES", "Renew License");
        }

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnReplaceLicense, "DVLD  /  LICENSE SERVICES", "Replace License");
        }

        private void btnDetainRelease_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDetainRelease, "DVLD  /  LICENSE SERVICES", "Detain & Release");
        }

        private void btnInternationalLicense_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnInternationalLicense, "DVLD  /  LICENSE SERVICES", "International Permit");
        }

        private void btnDriversPeople_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDriversPeople, "DVLD  /  DIRECTORIES", "People & Drivers");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            OnLogoutClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- Simple UI Helper Methods ---

        private void SelectNavigationButton(Guna2Button selectedButton, string sectionText, string pageTitle)
        {
            // 1. Update top header text
            lblPageSubtitle.Text = sectionText;
            lblPageTitle.Text = pageTitle;

            // 2. Reset all sidebar buttons to default (inactive) style
            ResetButtonStyle(ApplicationsButton);
            ResetButtonStyle(btnTestAppointments);
            ResetButtonStyle(btnRenewLicense);
            ResetButtonStyle(btnReplaceLicense);
            ResetButtonStyle(btnDetainRelease);
            ResetButtonStyle(btnInternationalLicense);
            ResetButtonStyle(btnDriversPeople);

            // 3. Highlight the clicked button as active
            selectedButton.FillColor = Color.FromArgb(23, 37, 68);
            selectedButton.ForeColor = Color.White;
        }

        private void ResetButtonStyle(Guna2Button button)
        {
            button.FillColor = Color.Transparent;
            button.ForeColor = Color.FromArgb(148, 163, 184);
        }
    }
}
