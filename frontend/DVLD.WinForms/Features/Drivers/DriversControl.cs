#nullable enable
using DVLD.Contracts.Drivers;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Drivers
{
    public partial class DriversControl : UserControl, IDriversView
    {
        private readonly List<DriversListResponse> _allRows = [];

        public event EventHandler? LoadRequested;
        public event EventHandler<int>? PageRequested;
        public event EventHandler<int>? ViewPersonRequested;
        public event EventHandler<int>? ViewLicenseHistoryRequested;

        public DriversControl()
        {
            InitializeComponent();
            filterBar.SetFilterItems("All Drivers", "With Active Licenses", "No Active Licenses");

            filterBar.SearchChanged += (_, _) => ApplyFilter();
            filterBar.FilterChanged += (_, _) => ApplyFilter();
            filterBar.PrimaryActionClicked += (_, _) => LoadRequested?.Invoke(this, EventArgs.Empty);
            paginationBar.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
            driversGrid.CellContentClick += OnGridCellContentClick;
            driversGrid.CellDoubleClick += OnGridCellDoubleClick;
            driversGrid.CellPainting += OnGridCellPainting;
            driversGrid.CellMouseEnter += OnGridCellMouseEnter;
            driversGrid.CellMouseLeave += OnGridCellMouseLeave;
            driversGrid.MouseLeave += (_, _) => ClearHoverRow();
        }

        private void DriversControl_Load(object? sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayDrivers(IEnumerable<DriversListResponse> drivers)
        {
            _allRows.Clear();
            if (drivers is not null)
                _allRows.AddRange(drivers);

            ApplyFilter();
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            paginationBar.DisplayPagination(pageNumber, totalPages, totalCount, driversGrid.Rows.Count, "drivers");
            filterBar.CountText = $"{totalCount} {(totalCount == 1 ? "driver" : "drivers")}";
        }

        public void SetLoading(bool isLoading)
        {
            paginationBar.SetLoading(isLoading);
            UseWaitCursor = isLoading;
        }

        public void DisplayMessage(string message)
        {
            if (_allRows.Count == 0)
            {
                lblEmptyState.Text = message;
                lblEmptyState.Visible = true;
            }
            else
            {
                MessageBox.Show(this, message, "Drivers Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ApplyFilter()
        {
            string term = filterBar.SearchText;
            int filter = filterBar.SelectedFilterIndex; // 0=All, 1=Active > 0, 2=Active == 0

            var filtered = _allRows.Where(d =>
            {
                if (filter == 1 && d.ActiveLicenses <= 0)
                    return false;
                if (filter == 2 && d.ActiveLicenses > 0)
                    return false;

                if (string.IsNullOrWhiteSpace(term))
                    return true;

                return d.FullName.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || d.NationNo.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || d.DriverId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase)
                    || d.PersonId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            driversGrid.Rows.Clear();
            foreach (var driver in filtered)
            {
                int rowIndex = driversGrid.Rows.Add();
                var row = driversGrid.Rows[rowIndex];
                row.Cells["DriverId"].Value = driver.DriverId;
                row.Cells["PersonId"].Value = driver.PersonId;
                row.Cells["NationalNo"].Value = driver.NationNo;
                row.Cells["FullName"].Value = driver.FullName;
                row.Cells["CreateDate"].Value = driver.CreateDate;
                row.Cells["ActiveLicenses"].Value = driver.ActiveLicenses;
                row.Cells["ActiveLicenses"].Style.ForeColor = driver.ActiveLicenses > 0
                    ? Color.FromArgb(21, 128, 61)
                    : Color.FromArgb(148, 163, 184);
            }

            lblEmptyState.Text = filtered.Count == 0
                ? (_allRows.Count == 0 ? "No drivers registered yet." : "No drivers match the current search filter.")
                : string.Empty;
            lblEmptyState.Visible = filtered.Count == 0;
            driversGrid.ClearSelection();
        }

        private void OnGridCellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string colName = driversGrid.Columns[e.ColumnIndex].Name;
            if (colName != "ViewPerson" && colName != "ViewHistory")
                return;

            if (!int.TryParse(driversGrid.Rows[e.RowIndex].Cells["PersonId"].Value?.ToString(), out int personId) || personId <= 0)
                return;

            if (colName == "ViewPerson")
                ViewPersonRequested?.Invoke(this, personId);
            else
                ViewLicenseHistoryRequested?.Invoke(this, personId);
        }

        private int _hoveredRowIndex = -1;

        private void OnGridCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics is null)
                return;

            string colName = driversGrid.Columns[e.ColumnIndex].Name;
            if (colName == "FullName")
            {
                DataGridViewUIHelper.DrawAvatarAndName(e);
                return;
            }

            if (colName == "ActiveLicenses")
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

                _ = int.TryParse(e.Value?.ToString(), out int count);
                bool hasActive = count > 0;
                Color bgColor = hasActive ? UITheme.SuccessBg : UITheme.NeutralBg;
                Color fgColor = hasActive ? UITheme.SuccessText : UITheme.NeutralText;
                string label = hasActive ? $"{count} active" : "0 active";

                var state = e.Graphics.Save();
                try
                {
                    e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    using var font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
                    int measured = TextRenderer.MeasureText(label, font).Width;
                    int pillHeight = 24;
                    int pillWidth = Math.Min(Math.Max(24, e.CellBounds.Width - 16), Math.Max(74, measured + 26));
                    int x = e.CellBounds.X + 10;
                    int y = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                    var pillRect = new Rectangle(x, y, pillWidth, pillHeight);

                    using (var path = CreatePillPath(pillRect, 11))
                    using (var bgBrush = new SolidBrush(bgColor))
                        e.Graphics.FillPath(bgBrush, path);

                    using (var dotBrush = new SolidBrush(fgColor))
                        e.Graphics.FillEllipse(dotBrush, x + 8, y + 9, 6, 6);

                    TextRenderer.DrawText(
                        e.Graphics,
                        label,
                        font,
                        new Rectangle(x + 20, y, Math.Max(0, pillWidth - 24), pillHeight),
                        fgColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
                }
                finally
                {
                    e.Graphics.Restore(state);
                }
            }
        }

        private void OnGridCellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= driversGrid.Rows.Count)
                return;

            if (_hoveredRowIndex != e.RowIndex)
            {
                ClearHoverRow();
                _hoveredRowIndex = e.RowIndex;
                driversGrid.Rows[_hoveredRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 250);
            }

            driversGrid.Cursor = Cursors.Hand;
        }

        private void OnGridCellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _hoveredRowIndex)
                ClearHoverRow();
        }

        private void ClearHoverRow()
        {
            if (_hoveredRowIndex >= 0 && _hoveredRowIndex < driversGrid.Rows.Count)
                driversGrid.Rows[_hoveredRowIndex].DefaultCellStyle.BackColor = Color.Empty;

            _hoveredRowIndex = -1;
            driversGrid.Cursor = Cursors.Default;
        }

        private static GraphicsPath CreatePillPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void OnGridCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (int.TryParse(driversGrid.Rows[e.RowIndex].Cells["PersonId"].Value?.ToString(), out int personId) && personId > 0)
                ViewLicenseHistoryRequested?.Invoke(this, personId);
        }
    }
}
