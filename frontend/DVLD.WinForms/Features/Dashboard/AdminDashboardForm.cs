using DVLD.WinForms.Features.Administration.AuditLogs;
using DVLD.WinForms.Features.Administration.ServiceFees;
using DVLD.WinForms.Features.Administration.Users;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Drivers;
using DVLD.WinForms.Features.Licenses.DetainRelease;
using DVLD.WinForms.Features.Licenses.InternationalPermit;
using DVLD.WinForms.Features.Licenses.LicenseHistory;
using DVLD.WinForms.Features.Licenses.RenewLicense;
using DVLD.WinForms.Features.Licenses.ReplaceLicense;
using DVLD.WinForms.Features.Persons.ManagePeople;
using DVLD.WinForms.Features.Settings;
using DVLD.WinForms.Features.Tests.RecordTestResult;
using DVLD.WinForms.Features.Tests.ScheduleTest;
using DVLD.WinForms.Features.Tests.Appointments;
using DVLD.WinForms.Features.Tests.Appointments.ManageTestAppointments;
using DVLD.WinForms.Shared.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Dashboard
{
    public partial class AdminDashboardForm : Form, IAdminDashboardView
    {
        private const int NavIconSize = 20;
        private string _avatarInitials = "AA";

        public event EventHandler? OnLoadDashboardClicked;
        public event EventHandler? OnLoadApplicationsClicked;
        public event EventHandler? OnNewApplicationRequested;
        public event EventHandler? OnAccountSettingsClicked;
        public event EventHandler? OnTestAppointmentsClicked;
        public event EventHandler? OnRenewLicenseClicked;
        public event EventHandler? OnReplaceLicenseClicked;
        public event EventHandler? OnDetainReleaseClicked;
        public event EventHandler? OnInternationalLicenseClicked;
        public event EventHandler? OnPeopleDirectoryClicked;
        public event EventHandler? OnDriversDirectoryClicked;
        public event EventHandler? OnUsersManagementClicked;
        public event EventHandler? OnServiceFeesClicked;
        public event EventHandler? OnAuditLogsClicked;
        public event EventHandler? OnLogoutClicked;
        public event EventHandler? OnBackClicked;
        public event EventHandler? OnForwardClicked;
        public event EventHandler? OnRefreshClicked;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control MainContentPanel => this.MainPanal;

        private readonly AdminDashboardPresenter _presenter;
        private Guna2Button? _activeSidebarButton;

        public AdminDashboardForm(AdminDashboardPresenter presenter)
        {
            InitializeComponent();
            InitializeInteractiveChrome();

            _presenter = presenter;
            _presenter.SetView(this);

            KeyPreview = true;
            KeyDown += AdminDashboardForm_KeyDown;

            txtGlobalSearch.KeyDown += (_, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                e.SuppressKeyPress = true;
                ApplicationsButton_Click(this, EventArgs.Empty);
            };
        }

        private void AdminDashboardForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.K)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtGlobalSearch.Focus();
            }
        }

        private void InitializeInteractiveChrome()
        {
            var navButtons = new[]
            {
                btnDashboard, ApplicationsButton, btnTestAppointments,
                btnRenewLicense, btnReplaceLicense, btnDetainRelease, btnInternationalLicense,
                btnDriversPeople, btnDrivers,
                btnUsers, btnServiceFees, btnAuditLogs
            };

            foreach (var button in navButtons)
            {
                button.Paint += SidebarNavButton_Paint;
                button.ImageSize = new Size(NavIconSize, NavIconSize);
            }

            pictureBox1.Image = Properties.Resources.icons8_steering_wheel_48;

            guna2GradientButton1.ImageSize = new Size(18, 18);
            guna2GradientButton1.ImageOffset = new Point(0, 0);
            guna2GradientButton1.TextOffset = new Point(10, 0);

            txtGlobalSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtGlobalSearch.IconLeftSize = new Size(16, 16);
            txtGlobalSearch.TextOffset = new Point(0, 0);

            btnLogout.Text = string.Empty;
            btnLogout.Image = Properties.Resources.icons8_logout_32;
            btnLogout.ImageSize = new Size(16, 16);
            btnLogout.ImageAlign = HorizontalAlignment.Center;
            btnLogout.TextAlign = HorizontalAlignment.Center;

            pnlUserProfile.MouseEnter += (_, _) => pnlUserProfile.FillColor = UITheme.SidebarSurfaceRaised;
            pnlUserProfile.MouseLeave += (_, _) => pnlUserProfile.FillColor = Color.FromArgb(23, 35, 56);

            _avatarInitials = string.IsNullOrWhiteSpace(btnUserAvatar.Text) ? "AA" : btnUserAvatar.Text.Trim();
            btnUserAvatar.Text = string.Empty;
            btnUserAvatar.Paint += (_, e) => TextRenderer.DrawText(
                e.Graphics,
                _avatarInitials,
                btnUserAvatar.Font,
                btnUserAvatar.ClientRectangle,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
        }

        private void SidebarNavButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Guna2Button button || !ReferenceEquals(button, _activeSidebarButton))
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(UITheme.NavIndicator);
            using var path = new GraphicsPath();
            var bar = new Rectangle(3, 6, 3, Math.Max(10, button.Height - 12));
            path.AddArc(bar.X, bar.Y, 3, 3, 180, 90);
            path.AddArc(bar.Right - 3, bar.Y, 3, 3, 270, 90);
            path.AddArc(bar.Right - 3, bar.Bottom - 3, 3, 3, 0, 90);
            path.AddArc(bar.X, bar.Bottom - 3, 3, 3, 90, 90);
            path.CloseFigure();
            e.Graphics.FillPath(brush, path);
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            btnDashboard_Click(this, EventArgs.Empty);
        }

        // --- Sidebar Navigation Click Events ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDashboard, "DVLD  /  OPERATIONS", "Dashboard");
            OnLoadDashboardClicked?.Invoke(this, EventArgs.Empty);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(ApplicationsButton, "DVLD  /  OPERATIONS", "New Application");
            OnNewApplicationRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ApplicationsButton_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(ApplicationsButton, "DVLD  /  OPERATIONS", "Applications");
            OnLoadApplicationsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnTestAppointments_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnTestAppointments, "DVLD  /  OPERATIONS", "Test Appointments");
            OnTestAppointmentsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnRenewLicense, "DVLD  /  LICENSE SERVICES", "Renew License");
            OnRenewLicenseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnReplaceLicense, "DVLD  /  LICENSE SERVICES", "Replace License");
            OnReplaceLicenseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDetainRelease_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDetainRelease, "DVLD  /  LICENSE SERVICES", "Detain & Release");
            OnDetainReleaseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnInternationalLicense_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnInternationalLicense, "DVLD  /  LICENSE SERVICES", "International Permit");
            OnInternationalLicenseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDriversPeople_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDriversPeople, "DVLD  /  DIRECTORIES", "People");
            OnPeopleDirectoryClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDrivers, "DVLD  /  DIRECTORIES", "Drivers");
            OnDriversDirectoryClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnUsers, "DVLD  /  ADMINISTRATION", "Users Management");
            OnUsersManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnServiceFees_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnServiceFees, "DVLD  /  ADMINISTRATION", "Service Fees & Types");
            OnServiceFeesClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnAuditLogs, "DVLD  /  ADMINISTRATION", "Audit Logs");
            OnAuditLogsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pnlUserProfile_Click(object sender, EventArgs e)
        {
            lblPageSubtitle.Text = "DVLD  /  ACCOUNT";
            lblPageTitle.Text = "Settings";
            ResetAllSidebarButtons();
            OnAccountSettingsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            OnLogoutClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- Top Bar History Navigation (Back / Next / Refresh) ---

        private void btnNavBack_Click(object sender, EventArgs e)
        {
            OnBackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNavForward_Click(object sender, EventArgs e)
        {
            OnForwardClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNavRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetCurrentUserProfile(string displayName, string roleText, string initials)
        {
            lblCurrentUserName.Text = displayName;
            lblCurrentUserRole.Text = roleText;
            _avatarInitials = string.IsNullOrWhiteSpace(initials) ? "AA" : initials.Trim();
            btnUserAvatar.Text = string.Empty;
            btnUserAvatar.Invalidate();
        }

        public void ApplyRolePermissions(bool isAdmin)
        {
            lblNavSection4.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
            btnServiceFees.Visible = isAdmin;
            btnAuditLogs.Visible = isAdmin;
        }

        public void UpdateNavigationButtons(bool canGoBack, bool canGoForward)
        {
            btnNavBack.Enabled = canGoBack;
            btnNavForward.Enabled = canGoForward;
            btnNavBack.Invalidate();
            btnNavForward.Invalidate();
        }

        public void SyncActivePage(Type presenterType)
        {
            if (presenterType == typeof(DashboardPresenter))
            {
                SelectNavigationButton(btnDashboard, "DVLD  /  OPERATIONS", "Dashboard");
            }
            else if (presenterType == typeof(ApplicationsPresenter))
            {
                SelectNavigationButton(ApplicationsButton, "DVLD  /  OPERATIONS", "Applications");
            }
            else if (presenterType == typeof(ManageTestAppointmentsPresenter) ||
                     presenterType == typeof(ListTestAppointmentsPresenter) ||
                     presenterType == typeof(ScheduleTestPresenter) ||
                     presenterType == typeof(RecordTestResultPresenter))
            {
                SelectNavigationButton(btnTestAppointments, "DVLD  /  OPERATIONS", "Test Appointments");
            }
            else if (presenterType == typeof(RenewLicensePresenter))
            {
                SelectNavigationButton(btnRenewLicense, "DVLD  /  LICENSE SERVICES", "Renew License");
            }
            else if (presenterType == typeof(ReplaceLicensePresenter))
            {
                SelectNavigationButton(btnReplaceLicense, "DVLD  /  LICENSE SERVICES", "Replace License");
            }
            else if (presenterType == typeof(DetainReleaseLicensePresenter))
            {
                SelectNavigationButton(btnDetainRelease, "DVLD  /  LICENSE SERVICES", "Detain & Release");
            }
            else if (presenterType == typeof(InternationalPermitPresenter))
            {
                SelectNavigationButton(btnInternationalLicense, "DVLD  /  LICENSE SERVICES", "International Permit");
            }
            else if (presenterType == typeof(PeoplePresenter))
            {
                SelectNavigationButton(btnDriversPeople, "DVLD  /  DIRECTORIES", "People");
            }
            else if (presenterType == typeof(DriversPresenter) ||
                     presenterType == typeof(LicenseHistoryPresenter))
            {
                SelectNavigationButton(btnDrivers, "DVLD  /  DIRECTORIES", "Drivers");
            }
            else if (presenterType == typeof(UsersPresenter))
            {
                SelectNavigationButton(btnUsers, "DVLD  /  ADMINISTRATION", "Users Management");
            }
            else if (presenterType == typeof(SettingsPresenter))
            {
                lblPageSubtitle.Text = "DVLD  /  ACCOUNT";
                lblPageTitle.Text = "Settings";
                ResetAllSidebarButtons();
            }
            else if (presenterType == typeof(ServiceFeesPresenter))
            {
                SelectNavigationButton(btnServiceFees, "DVLD  /  ADMINISTRATION", "Service Fees & Types");
            }
            else if (presenterType == typeof(AuditLogsPresenter))
            {
                SelectNavigationButton(btnAuditLogs, "DVLD  /  ADMINISTRATION", "Audit Logs");
            }
        }

        // --- Crisp Vector Icon Painting (`<`, `>`, and `↻` with dot) ---

        private void btnNavBack_Paint(object sender, PaintEventArgs e)
        {
            DrawChevronIcon(e.Graphics, btnNavBack.ClientRectangle, isLeft: true, btnNavBack.Enabled);
        }

        private void btnNavForward_Paint(object sender, PaintEventArgs e)
        {
            DrawChevronIcon(e.Graphics, btnNavForward.ClientRectangle, isLeft: false, btnNavForward.Enabled);
        }

        private void btnNavRefresh_Paint(object sender, PaintEventArgs e)
        {
            DrawRefreshIcon(e.Graphics, btnNavRefresh.ClientRectangle);
        }

        private static void DrawChevronIcon(Graphics g, Rectangle bounds, bool isLeft, bool enabled)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color iconColor = enabled
                ? Color.FromArgb(30, 41, 59)    // Active slate
                : Color.FromArgb(186, 198, 213); // Muted disabled gray

            using var pen = new Pen(iconColor, 2.0f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            float cx = bounds.Width / 2f;
            float cy = bounds.Height / 2f;
            float dx = 3.0f;
            float dy = 5.5f;

            if (isLeft)
            {
                g.DrawLines(pen, new[]
                {
                    new PointF(cx + dx, cy - dy),
                    new PointF(cx - dx, cy),
                    new PointF(cx + dx, cy + dy)
                });
            }
            else
            {
                g.DrawLines(pen, new[]
                {
                    new PointF(cx - dx, cy - dy),
                    new PointF(cx + dx, cy),
                    new PointF(cx - dx, cy + dy)
                });
            }
        }

        private static void DrawRefreshIcon(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color iconColor = Color.FromArgb(30, 41, 59);

            using var pen = new Pen(iconColor, 1.85f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
            using var brush = new SolidBrush(iconColor);

            float cx = bounds.Width / 2f;
            float cy = bounds.Height / 2f;
            float r = 6.2f;
            var arcRect = new RectangleF(cx - r, cy - r, r * 2, r * 2);

            // Circular arc with a small gap on the bottom-right, matching the reference icon
            g.DrawArc(pen, arcRect, 45f, 300f);

            // Solid dot at the end of the arc (around 345 degrees / 3 o'clock)
            double angleRad = -15.0 * Math.PI / 180.0;
            float dotX = cx + (float)(r * Math.Cos(angleRad));
            float dotY = cy + (float)(r * Math.Sin(angleRad));
            float dotRadius = 2.2f;
            g.FillEllipse(brush, dotX - dotRadius, dotY - dotRadius, dotRadius * 2, dotRadius * 2);
        }

        // --- Simple UI Helper Methods ---

        private void SelectNavigationButton(Guna2Button selectedButton, string sectionText, string pageTitle)
        {
            // 1. Update top header text
            lblPageSubtitle.Text = sectionText;
            lblPageTitle.Text = pageTitle;

            // 2. Reset all sidebar buttons to default (inactive) style
            ResetAllSidebarButtons();

            // 3. Highlight the clicked button as active with Arctic Teal fill + live left indicator
            _activeSidebarButton = selectedButton;
            selectedButton.FillColor = UITheme.NavItemActiveFill;
            selectedButton.ForeColor = UITheme.NavItemActiveFore;
            selectedButton.Invalidate();
        }

        private void ResetAllSidebarButtons()
        {
            _activeSidebarButton = null;
            ResetButtonStyle(btnDashboard);
            ResetButtonStyle(ApplicationsButton);
            ResetButtonStyle(btnTestAppointments);
            ResetButtonStyle(btnRenewLicense);
            ResetButtonStyle(btnReplaceLicense);
            ResetButtonStyle(btnDetainRelease);
            ResetButtonStyle(btnInternationalLicense);
            ResetButtonStyle(btnDriversPeople);
            ResetButtonStyle(btnDrivers);
            ResetButtonStyle(btnUsers);
            ResetButtonStyle(btnServiceFees);
            ResetButtonStyle(btnAuditLogs);
        }

        private void ResetButtonStyle(Guna2Button button)
        {
            button.FillColor = Color.Transparent;
            button.ForeColor = UITheme.NavItemMuted;
            button.Invalidate();
        }
    }
}
