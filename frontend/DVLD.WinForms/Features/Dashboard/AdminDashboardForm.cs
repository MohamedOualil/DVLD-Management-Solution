using DVLD.WinForms.Features.Applications;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Dashboard
{
    public partial class AdminDashboardForm : Form, IAdminDashboardView
    {
        public event EventHandler? OnLoadApplicationsClicked;
        public event EventHandler? OnAccountSettingsClicked;
        public event EventHandler? OnLogoutClicked;
        public event EventHandler? OnBackClicked;
        public event EventHandler? OnForwardClicked;
        public event EventHandler? OnRefreshClicked;

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
            SelectNavigationButton(btnDriversPeople, "DVLD  /  DIRECTORIES", "People");
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnDrivers, "DVLD  /  DIRECTORIES", "Drivers");
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnUsers, "DVLD  /  ADMINISTRATION", "Settings");
            OnAccountSettingsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnServiceFees_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnServiceFees, "DVLD  /  ADMINISTRATION", "Service Fees & Types");
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            SelectNavigationButton(btnAuditLogs, "DVLD  /  ADMINISTRATION", "Audit Logs");
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
            btnUserAvatar.Text = initials;
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
            if (presenterType == typeof(ApplicationsPresenter))
            {
                SelectNavigationButton(ApplicationsButton, "DVLD  /  OPERATIONS", "Applications");
            }
            else if (presenterType == typeof(SettingsPresenter))
            {
                lblPageSubtitle.Text = "DVLD  /  ACCOUNT";
                lblPageTitle.Text = "Settings";
                ResetAllSidebarButtons();
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

            // 3. Highlight the clicked button as active
            selectedButton.FillColor = Color.FromArgb(23, 37, 68);
            selectedButton.ForeColor = Color.White;
        }

        private void ResetAllSidebarButtons()
        {
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
            button.ForeColor = Color.FromArgb(148, 163, 184);
        }
    }
}
