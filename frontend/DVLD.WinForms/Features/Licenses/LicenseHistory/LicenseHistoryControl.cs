#nullable enable
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Licenses;
using DVLD.Contracts.Persons;
using DVLD.WinForms.Features.Persons.Detail;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Licenses.LicenseHistory;

public partial class LicenseHistoryControl : UserControl, ILicenseHistoryView
{
    private static readonly Color Ink = UITheme.HeadingInk;
    private static readonly Color SecondaryInk = UITheme.MutedInk;
    private static readonly Color PrimaryBlue = UITheme.PrimaryBlue;
    private static readonly Color SoftBlueBack = Color.FromArgb(240, 253, 250);
    private static readonly Color SoftBlueBorder = UITheme.InfoBorder;
    private static readonly Color Outline = UITheme.SubtleBorder;
    private static readonly Color RowHover = UITheme.InputSurface;
    private static readonly Font TabActiveFont = new("Segoe UI Semibold", 9F, FontStyle.Bold);
    private static readonly Font TabInactiveFont = new("Segoe UI Semibold", 9F, FontStyle.Regular);

    private readonly GridCellFonts _cellFonts = new();
    private int _hoveredLocalRow = -1;
    private int _hoveredLocalCol = -1;
    private int _hoveredIntlRow = -1;
    private int _hoveredIntlCol = -1;

    public event EventHandler<int>? ViewLocalLicenseRequested;
    public event EventHandler<int>? ViewInternationalLicenseRequested;
    public event EventHandler<int>? LocalPageRequested;
    public event EventHandler<int>? InternationalPageRequested;
    public event EventHandler? CloseRequested;

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PersonDetailControl PersonCard => personDetails;

    public LicenseHistoryControl()
    {
        InitializeComponent();
        ConfigureStyling();
        WireEvents();
        SwitchTab(showLocal: true);
        RefreshEmptyStates();
    }

    private void ConfigureStyling()
    {
        using var iconPath = new GraphicsPath();
        iconPath.AddEllipse(0, 0, hintIcon.Width, hintIcon.Height);
        hintIcon.Region = new Region(iconPath);

        txtFilterHistory.IconLeft = Properties.Resources.icons8_search_32;
        txtFilterHistory.IconLeftSize = new Size(16, 16);
        txtFilterHistory.TextOffset = new Point(0, 0);

        historyToolbar.Paint += PaintToolbarBottomBorder;
    }

    private void WireEvents()
    {
        ConfigureGridInteractions(localGrid, isLocal: true);
        ConfigureGridInteractions(internationalGrid, isLocal: false);

        btnLocalTab.Click += (_, _) => SwitchTab(showLocal: true);
        btnInternationalTab.Click += (_, _) => SwitchTab(showLocal: false);
        txtFilterHistory.TextChanged += (_, _) => ApplyFilter();

        localPaginationBar.PageRequested += (_, page) => LocalPageRequested?.Invoke(this, page);
        internationalPaginationBar.PageRequested += (_, page) => InternationalPageRequested?.Invoke(this, page);
        pageHeader.BackRequested += (_, _) => CloseRequested?.Invoke(this, EventArgs.Empty);

        Disposed += (_, _) => _cellFonts.Dispose();
    }

    private void SwitchTab(bool showLocal)
    {
        localTab.Visible = showLocal;
        internationalTab.Visible = !showLocal;

        if (showLocal)
            localTab.BringToFront();
        else
            internationalTab.BringToFront();

        StyleTabButton(btnLocalTab, isActive: showLocal);
        StyleTabButton(btnInternationalTab, isActive: !showLocal);
        ApplyFilter();
    }

    private static void StyleTabButton(
        Guna.UI2.WinForms.Guna2Button button,
        bool isActive)
    {
        if (isActive)
        {
            button.FillColor = PrimaryBlue;
            button.ForeColor = Color.White;
            button.HoverState.FillColor = UITheme.PrimaryBlueHover;
            button.HoverState.ForeColor = Color.White;
            button.Font = TabActiveFont;
        }
        else
        {
            button.FillColor = Color.Transparent;
            button.ForeColor = SecondaryInk;
            button.HoverState.FillColor = UITheme.InputSurface;
            button.HoverState.ForeColor = Ink;
            button.Font = TabInactiveFont;
        }
    }

    private void ConfigureGridInteractions(DataGridView grid, bool isLocal)
    {
        grid.CellPainting += (_, e) => PaintHistoryCell(grid, e, isLocal);

        grid.CellMouseEnter += (_, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;

            if (isLocal)
            {
                _hoveredLocalRow = e.RowIndex;
                _hoveredLocalCol = e.ColumnIndex;
            }
            else
            {
                _hoveredIntlRow = e.RowIndex;
                _hoveredIntlCol = e.ColumnIndex;
            }

            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = RowHover;
            string colName = e.ColumnIndex >= 0 ? grid.Columns[e.ColumnIndex].Name : string.Empty;
            grid.Cursor = colName == "ViewLicense" ? Cursors.Hand : Cursors.Default;
            grid.InvalidateRow(e.RowIndex);
        };

        grid.CellMouseLeave += (_, e) =>
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;

            if (isLocal)
            {
                _hoveredLocalRow = -1;
                _hoveredLocalCol = -1;
            }
            else
            {
                _hoveredIntlRow = -1;
                _hoveredIntlCol = -1;
            }

            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            grid.Cursor = Cursors.Default;
            grid.InvalidateRow(e.RowIndex);
        };

        grid.CellClick += (_, e) => HandleActionCellTrigger(grid, e, isLocal);
        grid.CellDoubleClick += (_, e) => RaiseViewLicense(grid, e.RowIndex, isLocal);
        grid.RowsAdded += (_, _) => RefreshEmptyStates();
        grid.RowsRemoved += (_, _) => RefreshEmptyStates();
    }

    public void DisplayPerson(PersonResponse person)
    {
        ArgumentNullException.ThrowIfNull(person);

        personDetails.PersonInitialized(person);

        pageHeader.BadgeText = "● Driver Loaded";
        pageHeader.BadgeTone = HeaderBadgeTone.Info;

        standingPanel.FillColor = SoftBlueBack;
        standingPanel.BorderColor = SoftBlueBorder;
        lblStandingTitle.ForeColor = UITheme.InfoText;
        lblStandingTitle.Text = "● Driver Profile Loaded";
        lblStandingDesc.ForeColor = UITheme.BodyInk;
        lblStandingDesc.Text = "Review local and international credentials in the tabs below";
    }

    public void DisplayLocalLicenses(IEnumerable<GetLocalDrivingLicenseHistoryResponse> licenses)
    {
        ArgumentNullException.ThrowIfNull(licenses);

        localGrid.DataSource = null;
        localGrid.Rows.Clear();

        foreach (var item in licenses)
        {
            int rowIndex = localGrid.Rows.Add();
            var row = localGrid.Rows[rowIndex];
            row.Cells["LicenseId"].Value = item.LicenseId;
            row.Cells["LocalApplicationId"].Value = item.LocalId;
            row.Cells["LicenseClass"].Value = item.ClassName;
            row.Cells["IssueDate"].Value = item.IssueDate;
            row.Cells["ExpirationDate"].Value = item.ExpirationDate;
            row.Cells["LicenseStatus"].Value = ResolveStatusLabel(item.IsActive, item.ExpirationDate);
        }

        localGrid.ClearSelection();
        RefreshEmptyStates();
        ApplyFilter();
    }

    public void DisplayInternationalLicenses(IEnumerable<GetInternationalDrivingLicenseHistoryResponse> licenses)
    {
        ArgumentNullException.ThrowIfNull(licenses);

        internationalGrid.DataSource = null;
        internationalGrid.Rows.Clear();

        foreach (var item in licenses)
        {
            int rowIndex = internationalGrid.Rows.Add();
            var row = internationalGrid.Rows[rowIndex];
            row.Cells["LicenseId"].Value = item.InternationalLicenseId;
            row.Cells["ApplicationId"].Value = item.ApplicationId;
            row.Cells["LocalLicenseId"].Value = item.LicenseId;
            row.Cells["IssueDate"].Value = item.IssueDate;
            row.Cells["ExpirationDate"].Value = item.ExpirationDate;
            row.Cells["LicenseStatus"].Value = ResolveStatusLabel(item.IsActive, item.ExpirationDate);
        }

        internationalGrid.ClearSelection();
        RefreshEmptyStates();
        ApplyFilter();
    }

    public void DisplayLocalPagination(int pageNumber, int totalPages, int totalCount)
    {
        localPaginationBar.DisplayPagination(
            pageNumber,
            totalPages,
            totalCount,
            localGrid.Rows.Count,
            "local licenses");
    }

    public void DisplayInternationalPagination(int pageNumber, int totalPages, int totalCount)
    {
        internationalPaginationBar.DisplayPagination(
            pageNumber,
            totalPages,
            totalCount,
            internationalGrid.Rows.Count,
            "international permits");
    }

    public void DisplayMessage(string message)
    {
        MessageBox.Show(this, message, "Driver License History", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void RefreshEmptyStates()
    {
        int localCount = localGrid.Rows.Count;
        int intlCount = internationalGrid.Rows.Count;

        localCountValue.Text = localCount.ToString();
        internationalCountValue.Text = intlCount.ToString();

        localMessage.Visible = localCount == 0;
        internationalMessage.Visible = intlCount == 0;

        if (localGrid.DataSource is null)
        {
            localPaginationBar.DisplayPagination(
                localPaginationBar.CurrentPage,
                localPaginationBar.TotalPages,
                Math.Max(localPaginationBar.TotalCount, localCount),
                localCount,
                "local licenses");
        }

        if (internationalGrid.DataSource is null)
        {
            internationalPaginationBar.DisplayPagination(
                internationalPaginationBar.CurrentPage,
                internationalPaginationBar.TotalPages,
                Math.Max(internationalPaginationBar.TotalCount, intlCount),
                intlCount,
                "international permits");
        }

        UpdateDriverActivityBadge();
    }

    private void UpdateDriverActivityBadge()
    {
        bool hasAnyRecords = localGrid.Rows.Count > 0 || internationalGrid.Rows.Count > 0;
        if (!hasAnyRecords)
            return;

        bool hasActive = HasActiveRow(localGrid) || HasActiveRow(internationalGrid);
        if (hasActive)
        {
            pageHeader.BadgeText = "● Active Driver";
            pageHeader.BadgeTone = HeaderBadgeTone.Success;

            standingPanel.FillColor = UITheme.SuccessBg;
            standingPanel.BorderColor = UITheme.SuccessBorder;
            lblStandingTitle.ForeColor = UITheme.SuccessText;
            lblStandingTitle.Text = "● Driver Standing: Active";
            lblStandingDesc.ForeColor = UITheme.SuccessText;
            lblStandingDesc.Text = "Driver holds at least one active license or permit";
        }
        else
        {
            pageHeader.BadgeText = "○ No Active License";
            pageHeader.BadgeTone = HeaderBadgeTone.Neutral;

            standingPanel.FillColor = UITheme.InputSurface;
            standingPanel.BorderColor = Outline;
            lblStandingTitle.ForeColor = UITheme.NeutralText;
            lblStandingTitle.Text = "○ Driver Standing: Inactive";
            lblStandingDesc.ForeColor = SecondaryInk;
            lblStandingDesc.Text = "No active licenses found in current credential history";
        }
    }

    private static bool HasActiveRow(DataGridView grid)
    {
        foreach (DataGridViewRow row in grid.Rows)
        {
            string status = ResolveStatusLabel(
                row.Cells["LicenseStatus"].Value,
                row.Cells["ExpirationDate"].Value);
            if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    private void ApplyFilter()
    {
        string term = txtFilterHistory.Text.Trim();
        FilterGrid(localGrid, localMessage, "No local driving licenses match your filter.", "No local driving licenses found for this driver.", term);
        FilterGrid(internationalGrid, internationalMessage, "No international permits match your filter.", "No international driving permits found for this driver.", term);
    }

    private static void FilterGrid(
        DataGridView grid,
        Label emptyLabel,
        string filteredEmptyText,
        string defaultEmptyText,
        string term)
    {
        if (grid.Rows.Count == 0)
        {
            emptyLabel.Text = defaultEmptyText;
            emptyLabel.Visible = true;
            return;
        }

        CurrencyManager? cm = null;
        if (grid.DataSource is not null && grid.BindingContext is not null)
        {
            cm = grid.BindingContext[grid.DataSource] as CurrencyManager;
            cm?.SuspendBinding();
        }

        int visibleCount = 0;
        foreach (DataGridViewRow row in grid.Rows)
        {
            if (string.IsNullOrEmpty(term))
            {
                row.Visible = true;
                visibleCount++;
                continue;
            }

            bool matched = false;
            foreach (DataGridViewCell cell in row.Cells)
            {
                string formatted = cell.FormattedValue?.ToString() ?? cell.Value?.ToString() ?? string.Empty;
                if (formatted.Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    matched = true;
                    break;
                }
            }

            row.Visible = matched;
            if (matched)
                visibleCount++;
        }

        cm?.ResumeBinding();

        emptyLabel.Text = visibleCount == 0 && !string.IsNullOrEmpty(term)
            ? filteredEmptyText
            : defaultEmptyText;
        emptyLabel.Visible = visibleCount == 0;
    }

    private void HandleActionCellTrigger(DataGridView grid, DataGridViewCellEventArgs e, bool isLocal)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        if (grid.Columns[e.ColumnIndex].Name != "ViewLicense")
            return;

        RaiseViewLicense(grid, e.RowIndex, isLocal);
    }

    private void RaiseViewLicense(DataGridView grid, int rowIndex, bool isLocal)
    {
        if (rowIndex < 0 || rowIndex >= grid.Rows.Count)
            return;

        var idObj = grid.Rows[rowIndex].Cells["LicenseId"].Value;
        if (idObj is null || !int.TryParse(idObj.ToString(), out int licenseId))
            return;

        if (isLocal)
            ViewLocalLicenseRequested?.Invoke(this, licenseId);
        else
            ViewInternationalLicenseRequested?.Invoke(this, licenseId);
    }

    private void PaintHistoryCell(DataGridView grid, DataGridViewCellPaintingEventArgs e, bool isLocal)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics is null)
            return;

        string column = grid.Columns[e.ColumnIndex].Name;
        if (column is not ("LicenseId" or "LocalApplicationId" or "ApplicationId" or "LocalLicenseId" or "LicenseClass" or "LicenseStatus" or "ViewLicense"))
            return;

        e.Handled = true;
        e.PaintBackground(e.CellBounds, true);
        e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

        var state = e.Graphics.Save();
        e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        int x = e.CellBounds.X + 12;
        int middle = e.CellBounds.Y + e.CellBounds.Height / 2;

        switch (column)
        {
            case "LicenseId":
                PaintIdText(e.Graphics, e.CellBounds, x, e.Value, isPrimary: true);
                break;

            case "LocalApplicationId":
            case "ApplicationId":
            case "LocalLicenseId":
                PaintIdText(e.Graphics, e.CellBounds, x, e.Value, isPrimary: false);
                break;

            case "LicenseClass":
                PaintClassBadge(e.Graphics, e.CellBounds, x, middle, e.Value?.ToString() ?? string.Empty);
                break;

            case "LicenseStatus":
                object? expiryVal = grid.Rows[e.RowIndex].Cells["ExpirationDate"].Value;
                string statusText = ResolveStatusLabel(e.Value, expiryVal);
                PaintStatusPill(e.Graphics, e.CellBounds, x, middle, statusText);
                break;

            case "ViewLicense":
                bool isHovered = isLocal
                    ? (_hoveredLocalRow == e.RowIndex && _hoveredLocalCol == e.ColumnIndex)
                    : (_hoveredIntlRow == e.RowIndex && _hoveredIntlCol == e.ColumnIndex);
                PaintActionPill(e.Graphics, e.CellBounds, middle, isHovered);
                break;
        }

        e.Graphics.Restore(state);
    }

    private void PaintIdText(Graphics g, Rectangle cell, int x, object? value, bool isPrimary)
    {
        string text = value is null ? "—" : $"#{value}";
        var bounds = new Rectangle(x, cell.Y, Math.Max(0, cell.Width - 16), cell.Height);
        TextRenderer.DrawText(
            g,
            text,
            isPrimary ? _cellFonts.BoldId : _cellFonts.SecondaryId,
            bounds,
            isPrimary ? Ink : SecondaryInk,
            TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
    }

    private void PaintClassBadge(Graphics g, Rectangle cell, int x, int middle, string className)
    {
        if (string.IsNullOrWhiteSpace(className))
            return;

        var tagRect = new Rectangle(x, middle - 5, 10, 10);
        using (var path = RoundedRect(tagRect, 3))
        using (var brush = new SolidBrush(PrimaryBlue))
            g.FillPath(brush, path);

        var textBounds = new Rectangle(x + 18, cell.Y, Math.Max(0, cell.Width - 26), cell.Height);
        TextRenderer.DrawText(
            g,
            className,
            _cellFonts.ClassName,
            textBounds,
            Ink,
            TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
    }

    private void PaintStatusPill(Graphics g, Rectangle cell, int x, int middle, string status)
    {
        var (back, fore) = UITheme.ResolveStatusPillColors(status);

        int width = Math.Min(cell.Width - 18, TextRenderer.MeasureText(status, _cellFonts.Badge).Width + 30);
        if (width <= 24)
            return;

        var pill = new Rectangle(x, middle - 12, width, 24);
        using (var path = RoundedRect(pill, 12))
        using (var brush = new SolidBrush(back))
            g.FillPath(brush, path);

        using (var dotBrush = new SolidBrush(fore))
            g.FillEllipse(dotBrush, pill.X + 10, middle - 3, 6, 6);

        TextRenderer.DrawText(
            g,
            status,
            _cellFonts.Badge,
            new Rectangle(pill.X + 20, pill.Y, pill.Width - 22, pill.Height),
            fore,
            TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
    }

    private void PaintActionPill(Graphics g, Rectangle cell, int middle, bool isHovered)
    {
        const string label = "View Card ↗";
        int pillWidth = Math.Min(cell.Width - 16, 94);
        if (pillWidth < 50)
            return;

        int pillX = cell.X + Math.Max(8, (cell.Width - pillWidth) / 2);
        var pill = new Rectangle(pillX, middle - 14, pillWidth, 28);

        Color fill = isHovered ? PrimaryBlue : SoftBlueBack;
        Color border = isHovered ? PrimaryBlue : SoftBlueBorder;
        Color fore = isHovered ? Color.White : PrimaryBlue;

        using (var path = RoundedRect(pill, 7))
        using (var brush = new SolidBrush(fill))
        using (var pen = new Pen(border, 1))
        {
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }

        TextRenderer.DrawText(
            g,
            label,
            _cellFonts.Action,
            pill,
            fore,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
    }

    private static string ResolveStatusLabel(object? statusValue, object? expiryValue)
    {
        bool isExpired = expiryValue is DateTime dt && dt.Date < DateTime.Today;

        if (statusValue is bool isActive)
        {
            if (isExpired && !isActive)
                return "Expired";
            return isActive ? "Active" : "Inactive";
        }

        string text = statusValue?.ToString() ?? string.Empty;
        if (bool.TryParse(text, out bool parsedBool))
        {
            if (isExpired && !parsedBool)
                return "Expired";
            return parsedBool ? "Active" : "Inactive";
        }

        return string.IsNullOrWhiteSpace(text) ? "Inactive" : text;
    }

    private static void PaintToolbarBottomBorder(object? sender, PaintEventArgs e)
    {
        if (sender is not Control toolbar)
            return;
        using var pen = new Pen(Outline);
        e.Graphics.DrawLine(pen, 0, toolbar.Height - 1, toolbar.Width, toolbar.Height - 1);
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

    private sealed class GridCellFonts : IDisposable
    {
        public Font BoldId { get; } = new("Segoe UI Semibold", 9.25F, FontStyle.Bold);
        public Font SecondaryId { get; } = new("Segoe UI", 9.25F);
        public Font ClassName { get; } = new("Segoe UI Semibold", 9.25F, FontStyle.Bold);
        public Font Badge { get; } = new("Segoe UI Semibold", 8.25F, FontStyle.Bold);
        public Font Action { get; } = new("Segoe UI Semibold", 8.25F, FontStyle.Bold);

        public void Dispose()
        {
            BoldId.Dispose();
            SecondaryId.Dispose();
            ClassName.Dispose();
            Badge.Dispose();
            Action.Dispose();
        }
    }
}
