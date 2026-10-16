using System.Drawing.Drawing2D;
using Guna.UI2.WinForms;

namespace DVLD.WinForms.Features.Applications
{
    public partial class ApplicationsControl
    {
        private static readonly Color Ink = Color.FromArgb(12, 29, 60);
        private static readonly Color SecondaryInk = Color.FromArgb(64, 87, 120);
        private static readonly Color PrimaryBlue = Color.FromArgb(0, 91, 255);
        private static readonly Color Outline = Color.FromArgb(220, 229, 239);
        private Label recordsLabel;
        private Panel paginationFooter;
        private Guna2Button previousPageButton;
        private Guna2Button currentPageButton;
        private Guna2Button nextPageButton;
        private int displayedPage = 1;
        private int displayedTotalPages = 1;
        private bool paginationLoading;
        private readonly Font progressFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        private readonly Font annotationFont = new Font("Segoe UI", 8F);

        private void InitializeAppearance()
        {
            // Keep the original buttons, wrappers, tabs, filters, grid columns, and colors.
            guna2ShadowPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            paginationFooter = CreatePaginationFooter();
            LocalApplicationsTab.Controls.Add(paginationFooter);
            LocalDataGridView.CellPainting += PaintApplicationCell;
            LocalDataGridView.CellMouseDown += SelectContextRow;
            LocalDataGridView.RowsAdded += (_, _) => UpdateLoadedRecordCount();
            LocalDataGridView.RowsRemoved += (_, _) => UpdateLoadedRecordCount();
            LocalApplicationsTab.Resize += (_, _) => LayoutOriginalApplicationList();
            LayoutOriginalApplicationList();
            Disposed += (_, _) => { progressFont.Dispose(); annotationFont.Dispose(); };
        }

        private void LayoutOriginalApplicationList()
        {
            const int footerHeight = 44;
            paginationFooter.SetBounds(3,
                Math.Max(78, LocalApplicationsTab.ClientSize.Height - footerHeight - 3),
                Math.Max(0, LocalApplicationsTab.ClientSize.Width - 6), footerHeight);
            LocalDataGridView.SetBounds(3, 78,
                Math.Max(0, LocalApplicationsTab.ClientSize.Width - 6),
                Math.Max(0, paginationFooter.Top - 78));
        }

        private Panel CreatePaginationFooter()
        {
            var footer = new Panel { BackColor = Color.White, Margin = Padding.Empty };
            footer.Paint += (_, e) =>
            {
                using var pen = new Pen(Outline);
                e.Graphics.DrawLine(pen, 0, 0, footer.Width, 0);
            };
            recordsLabel = new Label
            {
                Text = "Showing 0 records", AutoSize = true, ForeColor = SecondaryInk,
                Font = new Font("Segoe UI", 8.5F), Location = new Point(16, 14)
            };
            var pages = new FlowLayoutPanel
            {
                Size = new Size(110, 34), Location = new Point(0, 5),
                WrapContents = false, Margin = Padding.Empty
            };
            // Navigation stays disabled until the view/presenter supplies pagination metadata.
            previousPageButton = CreatePageButton("‹", false);
            currentPageButton = CreatePageButton(displayedPage.ToString(), true);
            nextPageButton = CreatePageButton("›", false);
            previousPageButton.Click += (_, _) => OnPageRequested?.Invoke(this, displayedPage - 1);
            nextPageButton.Click += (_, _) => OnPageRequested?.Invoke(this, displayedPage + 1);
            pages.Controls.AddRange(new Control[]
            {
                previousPageButton, currentPageButton, nextPageButton
            });
            footer.Controls.Add(recordsLabel);
            footer.Controls.Add(pages);
            footer.Resize += (_, _) => pages.Left = Math.Max(0, footer.ClientSize.Width - pages.Width - 12);
            return footer;
        }

        private static Guna2Button CreatePageButton(string text, bool current)
        {
            var fill = current ? PrimaryBlue : Color.White;
            return new Guna2Button
            {
                Text = text, Size = new Size(30, 30), Margin = new Padding(0, 0, 6, 0),
                BorderRadius = 6, BorderThickness = 1, BorderColor = current ? PrimaryBlue : Outline,
                FillColor = fill, ForeColor = current ? Color.White : SecondaryInk,
                Font = new Font("Segoe UI", 9F), Enabled = false,
                DisabledState =
                {
                    FillColor = fill, BorderColor = current ? PrimaryBlue : Outline,
                    ForeColor = current ? Color.White : Color.FromArgb(167, 184, 207)
                }
            };
        }

        private void UpdateLoadedRecordCount()
        {
            recordsLabel.Text = $"Showing {LocalDataGridView.Rows.Count} records";
            if (LocalDataGridView.Rows.Count > 0)
                lblMessage.Visible = false;
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            displayedPage = pageNumber;
            displayedTotalPages = Math.Max(1, totalPages);
            currentPageButton.Text = displayedPage.ToString();
            recordsLabel.Text = $"Showing {LocalDataGridView.Rows.Count} of {totalCount} records";
            SetPaginationLoading(paginationLoading);
        }

        public void SetPaginationLoading(bool isLoading)
        {
            paginationLoading = isLoading;
            previousPageButton.Enabled = !isLoading && displayedPage > 1;
            nextPageButton.Enabled = !isLoading && displayedPage < displayedTotalPages;
        }

        private void SelectContextRow(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                LocalDataGridView.CurrentCell = LocalDataGridView.Rows[e.RowIndex].Cells["LocalID"];
        }

        private void PaintApplicationCell(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics is null || e.Value is null)
                return;
            string column = LocalDataGridView.Columns[e.ColumnIndex].Name;
            if (column != "Status" && column != "PassedTest")
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);
            var state = e.Graphics.Save();
            e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int x = e.CellBounds.X + 7;
            int middle = e.CellBounds.Y + e.CellBounds.Height / 2;
            const TextFormatFlags flags = TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis;

            if (column == "Status")
            {
                string text = e.Value.ToString() ?? "";
                Color fill = Color.FromArgb(227, 239, 255), foreground = PrimaryBlue;
                if (text == "Completed")
                {
                    fill = Color.FromArgb(221, 248, 234);
                    foreground = Color.FromArgb(0, 139, 80);
                }
                else if (text == "Cancelled")
                {
                    fill = Color.FromArgb(255, 242, 216);
                    foreground = Color.FromArgb(168, 106, 0);
                }
                int width = Math.Min(e.CellBounds.Width - 12,
                    TextRenderer.MeasureText(text, annotationFont).Width + 22);
                if (width > 14)
                {
                    using var brush = new SolidBrush(fill);
                    using var path = RoundedBadge(new Rectangle(x, middle - 12, width, 24));
                    e.Graphics.FillPath(brush, path);
                    using var dot = new SolidBrush(foreground);
                    e.Graphics.FillEllipse(dot, x + 7, middle - 2, 5, 5);
                    TextRenderer.DrawText(e.Graphics, text, annotationFont,
                        new Rectangle(x + 17, middle - 9, width - 19, 19), foreground, flags);
                }
            }
            else
            {
                int.TryParse(LocalDataGridView.Rows[e.RowIndex].Cells["PassedTestId"].Value?.ToString(), out int passed);
                for (int i = 0; i < 3; i++)
                {
                    using var brush = new SolidBrush(i < passed ? PrimaryBlue : Color.FromArgb(167, 184, 207));
                    e.Graphics.FillRectangle(brush, x + i * 13, middle - 2, 10, 4);
                }
                TextRenderer.DrawText(e.Graphics, e.Value.ToString() ?? "", progressFont,
                    new Rectangle(x + 43, middle - 10, Math.Max(0, e.CellBounds.Width - 50), 22), Ink, flags);
            }
            e.Graphics.Restore(state);
        }

        private static GraphicsPath RoundedBadge(Rectangle bounds)
        {
            var path = new GraphicsPath();
            const int diameter = 8;
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
