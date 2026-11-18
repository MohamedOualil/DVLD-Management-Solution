using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Dashboard
{
    public partial class DashboardControl : UserControl, IDashboardView
    {
        public event EventHandler? OnViewLoaded;
        public event EventHandler? OnViewAllApplicationsClicked;
        public event EventHandler<int>? OnOpenApplicationDetailsRequested;

        private static readonly Color Ink = Color.FromArgb(15, 23, 42);
        private static readonly Color SecondaryInk = Color.FromArgb(100, 116, 139);
        private static readonly Color BodyInk = Color.FromArgb(51, 65, 85);
        private static readonly Color RowHover = Color.FromArgb(248, 250, 252);

        private static readonly (Color Back, Color Fore)[] AvatarPalette =
        {
            (Color.FromArgb(204, 251, 241), Color.FromArgb(15, 118, 110)),
            (Color.FromArgb(220, 252, 231), Color.FromArgb(21, 128, 61)),
            (Color.FromArgb(243, 232, 255), Color.FromArgb(126, 34, 206)),
            (Color.FromArgb(255, 237, 213), Color.FromArgb(194, 65, 12)),
            (Color.FromArgb(252, 231, 243), Color.FromArgb(190, 24, 93)),
            (Color.FromArgb(204, 251, 241), Color.FromArgb(15, 118, 110)),
        };

        private readonly Font _avatarFont = new Font("Segoe UI Semibold", 8F);
        private readonly Font _nameFont = new Font("Segoe UI Semibold", 9F);
        private readonly Font _badgeFont = new Font("Segoe UI Semibold", 8F);
        private readonly Font _progressFont = new Font("Segoe UI Semibold", 8.75F);

        public DashboardControl()
        {
            DoubleBuffered = true;
            InitializeComponent();
            InitializeDashboardAccents();
            ConfigureGridFormatting();
        }

        private void InitializeDashboardAccents()
        {
            pnlWelcomeBanner.Paint += (_, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(Color.FromArgb(20, 184, 166));
                e.Graphics.FillRectangle(brush, 16, pnlWelcomeBanner.Height - 3, Math.Max(0, pnlWelcomeBanner.Width - 32), 3);
            };

            AttachKpiAccent(cardKpiTotal, Color.FromArgb(13, 148, 136), Color.FromArgb(153, 246, 228));
            AttachKpiAccent(cardKpiPending, Color.FromArgb(217, 119, 6), Color.FromArgb(253, 230, 138));
            AttachKpiAccent(cardKpiCompleted, Color.FromArgb(5, 150, 105), Color.FromArgb(167, 243, 208));
            AttachKpiAccent(cardKpiUsers, Color.FromArgb(2, 132, 199), Color.FromArgb(186, 230, 253));
        }

        private static void AttachKpiAccent(Guna.UI2.WinForms.Guna2Panel card, Color stripeColor, Color hoverBorderColor)
        {
            Color restBorder = card.BorderColor;
            card.Paint += (_, e) =>
            {
                using var brush = new SolidBrush(stripeColor);
                e.Graphics.FillRectangle(brush, 18, 1, Math.Max(0, card.Width - 36), 3);
            };

            void OnEnter(object? s, EventArgs e) => card.BorderColor = hoverBorderColor;
            void OnLeave(object? s, EventArgs e)
            {
                if (!card.ClientRectangle.Contains(card.PointToClient(Cursor.Position)))
                    card.BorderColor = restBorder;
            }

            card.MouseEnter += OnEnter;
            card.MouseLeave += OnLeave;
            foreach (Control child in card.Controls)
            {
                child.MouseEnter += OnEnter;
                child.MouseLeave += OnLeave;
            }
        }

        private void ConfigureGridFormatting()
        {
            colLocalId.DefaultCellStyle.Format = "\\#0";
            colLocalId.DefaultCellStyle.ForeColor = SecondaryInk;

            colApplicationDate.DefaultCellStyle.Format = "MMM dd, yyyy";
            colApplicationDate.DefaultCellStyle.ForeColor = SecondaryInk;

            dgvRecentApps.CellPainting += DgvRecentApps_CellPainting;
            dgvRecentApps.CellMouseEnter += DgvRecentApps_CellMouseEnter;
            dgvRecentApps.CellMouseLeave += DgvRecentApps_CellMouseLeave;
            Disposed += (_, _) =>
            {
                _avatarFont.Dispose();
                _nameFont.Dispose();
                _badgeFont.Dispose();
                _progressFont.Dispose();
            };
        }

        private void DashboardControl_Load(object? sender, EventArgs e)
        {
            OnViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void btnViewAllApps_Click(object? sender, EventArgs e)
            => OnViewAllApplicationsClicked?.Invoke(this, EventArgs.Empty);

        private void dgvRecentApps_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRecentApps.Rows.Count)
                return;

            var value = dgvRecentApps.Rows[e.RowIndex].Cells["colLocalId"].Value;
            if (value != null && int.TryParse(value.ToString(), out int localId) && localId > 0)
            {
                OnOpenApplicationDetailsRequested?.Invoke(this, localId);
            }
        }

        // --- IDashboardView Implementation ---

        public void SetWelcomeHeader(string displayName, string roleText, string currentDateText)
        {
            string safeName = string.IsNullOrWhiteSpace(displayName) ? "Administrator" : displayName.Trim();
            lblWelcomeTitle.Text = $"Welcome back, {safeName}";
            lblWelcomeSubtitle.Text = "Live overview of driving license applications, examination stages, and daily operations.";
            lblRoleBadge.Text = $"● {roleText}";
            lblDateBadge.Text = currentDateText;
        }

        public void SetKpiMetrics(int totalApplications, int pendingApplications, int completedApplications, int activeUsers)
        {
            lblKpiValTotal.Text = totalApplications.ToString("N0");
            lblKpiValPending.Text = pendingApplications.ToString("N0");
            lblKpiValCompleted.Text = completedApplications.ToString("N0");
            lblKpiValUsers.Text = activeUsers.ToString("N0");
        }

        public void SetPipelineOverview(int awaitingVision, int awaitingWritten, int awaitingStreet, int readyToIssue)
        {
            lblVisionCount.Text = $"{awaitingVision:N0} waiting";
            lblWrittenCount.Text = $"{awaitingWritten:N0} waiting";
            lblStreetCount.Text = $"{awaitingStreet:N0} waiting";
            lblReadyIssueCount.Text = $"{readyToIssue:N0} ready";
        }

        public void SetDepartmentOverview(int cancelledApplications, string completionRateText, string topLicenseClass)
        {
            lblCompletionRate.Text = string.IsNullOrWhiteSpace(completionRateText) ? "0%" : completionRateText;
            lblCancelledCount.Text = $"{cancelledApplications:N0} cancelled";
            lblTopClass.Text = string.IsNullOrWhiteSpace(topLicenseClass) ? "—" : topLicenseClass;
        }

        public void DisplayRecentApplications(IEnumerable<GetAllLocalApplicationsResponse> applications)
        {
            dgvRecentApps.Rows.Clear();

            foreach (var app in applications)
            {
                int rowIndex = dgvRecentApps.Rows.Add();
                var row = dgvRecentApps.Rows[rowIndex];
                row.Cells["colLocalId"].Value = app.LocalApplicationId;
                row.Cells["colFullName"].Value = app.FullName;
                row.Cells["colDrivingClass"].Value = app.DrivingClass;
                row.Cells["colApplicationDate"].Value = app.ApplicationDate;
                row.Cells["colStatus"].Value = app.StatusName;
                row.Cells["colPassedTest"].Value = $"{app.PassedTest}/3";
                row.Cells["colPassedTestId"].Value = app.PassedTest;
            }

            if (dgvRecentApps.Rows.Count == 0)
            {
                lblRecentEmpty.Text = "No recent applications found.";
                lblRecentEmpty.Visible = true;
                CenterEmptyLabel();
            }
            else
            {
                lblRecentEmpty.Visible = false;
                dgvRecentApps.ClearSelection();
            }
        }

        public void SetLoadingState(bool isLoading)
        {
            if (isLoading && dgvRecentApps.Rows.Count == 0)
            {
                lblRecentEmpty.Text = "Loading recent applications...";
                lblRecentEmpty.Visible = true;
                CenterEmptyLabel();
            }
            else if (!isLoading && dgvRecentApps.Rows.Count > 0)
            {
                lblRecentEmpty.Visible = false;
            }
        }

        private void CenterEmptyLabel()
        {
            lblRecentEmpty.Location = new Point(
                Math.Max(0, (pnlRecentGridWrap.ClientSize.Width - lblRecentEmpty.Width) / 2),
                Math.Max(0, (pnlRecentGridWrap.ClientSize.Height - lblRecentEmpty.Height) / 2));
        }

        // --- Grid Hover & Custom Cell Painting ---

        private void DgvRecentApps_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRecentApps.Rows.Count) return;
            dgvRecentApps.Rows[e.RowIndex].DefaultCellStyle.BackColor = RowHover;
            dgvRecentApps.Cursor = Cursors.Hand;
        }

        private void DgvRecentApps_CellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRecentApps.Rows.Count) return;
            dgvRecentApps.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            dgvRecentApps.Cursor = Cursors.Default;
        }

        private void DgvRecentApps_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics is null || e.Value is null)
                return;

            string column = dgvRecentApps.Columns[e.ColumnIndex].Name;
            if (column != "colFullName" && column != "colStatus" && column != "colPassedTest")
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

            var state = e.Graphics.Save();
            e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int x = e.CellBounds.X + 10;
            int middle = e.CellBounds.Y + e.CellBounds.Height / 2;
            string text = e.Value.ToString() ?? string.Empty;

            if (column == "colFullName")
            {
                PaintApplicantCell(e.Graphics, e.CellBounds, x, middle, text);
            }
            else if (column == "colStatus")
            {
                PaintStatusPill(e.Graphics, e.CellBounds, x, middle, text);
            }
            else if (column == "colPassedTest")
            {
                int.TryParse(dgvRecentApps.Rows[e.RowIndex].Cells["colPassedTestId"].Value?.ToString(), out int passed);
                Color badgeColor = passed >= 3 ? Color.FromArgb(21, 128, 61) : BodyInk;
                TextRenderer.DrawText(e.Graphics, text, _progressFont,
                    new Rectangle(x, e.CellBounds.Y, Math.Max(0, e.CellBounds.Width - 14), e.CellBounds.Height),
                    badgeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
            }

            e.Graphics.Restore(state);
        }

        private void PaintApplicantCell(Graphics g, Rectangle cell, int x, int middle, string name)
        {
            const int size = 28;
            var (back, fore) = AvatarPalette[Math.Abs(name.GetHashCode()) % AvatarPalette.Length];
            var circle = new Rectangle(x, middle - size / 2, size, size);

            using (var brush = new SolidBrush(back))
                g.FillEllipse(brush, circle);

            TextRenderer.DrawText(g, Initials(name), _avatarFont, circle, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);

            var textBounds = new Rectangle(circle.Right + 8, cell.Y, Math.Max(0, cell.Right - circle.Right - 12), cell.Height);
            TextRenderer.DrawText(g, name, _nameFont, textBounds, Ink,
                TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private void PaintStatusPill(Graphics g, Rectangle cell, int x, int middle, string text)
        {
            var (back, fore) = UITheme.ResolveStatusPillColors(text);

            int width = Math.Min(cell.Width - 14, TextRenderer.MeasureText(text, _badgeFont).Width + 26);
            if (width <= 20) return;

            var pill = new Rectangle(x, middle - 11, width, 22);
            using (var path = RoundedRect(pill, 11))
            using (var brush = new SolidBrush(back))
                g.FillPath(brush, path);

            using (var dot = new SolidBrush(fore))
                g.FillEllipse(dot, pill.X + 8, middle - 3, 6, 6);

            TextRenderer.DrawText(g, text, _badgeFont,
                new Rectangle(pill.X + 18, pill.Y, pill.Width - 20, pill.Height), fore,
                TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private static string Initials(string name)
        {
            var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "?";
            if (parts.Length == 1) return parts[0][..1].ToUpperInvariant();
            return (parts[0][..1] + parts[^1][..1]).ToUpperInvariant();
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Top, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
