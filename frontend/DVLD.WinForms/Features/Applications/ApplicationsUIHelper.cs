using DVLD.WinForms.Shared.Helpers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Applications
{
    internal static class ApplicationsUIHelper
    {
        private static readonly Color Ink = Color.FromArgb(15, 23, 42);
        private static readonly Color SecondaryInk = Color.FromArgb(100, 116, 139);
        private static readonly Color BodyInk = Color.FromArgb(51, 65, 85);
        private static readonly Color PrimaryBlue = Color.FromArgb(37, 99, 235);
        private static readonly Color Outline = Color.FromArgb(226, 232, 240);
        private static readonly Color RowHover = Color.FromArgb(248, 250, 252);

        private const int ContentInset = 16;

        private static readonly (Color Back, Color Fore)[] AvatarPalette =
        {
            (Color.FromArgb(219, 234, 254), Color.FromArgb(29, 78, 216)),
            (Color.FromArgb(220, 252, 231), Color.FromArgb(21, 128, 61)),
            (Color.FromArgb(243, 232, 255), Color.FromArgb(126, 34, 206)),
            (Color.FromArgb(255, 237, 213), Color.FromArgb(194, 65, 12)),
            (Color.FromArgb(252, 231, 243), Color.FromArgb(190, 24, 93)),
            (Color.FromArgb(204, 251, 241), Color.FromArgb(15, 118, 110)),
        };

        public static void Configure(
            DataGridView grid,
            Control paginationFooter,
            ContextMenuStrip actionMenu,
            params ToolStripItem[] destructiveItems)
        {
            ConfigureGrid(grid);
            ConfigurePaginationFooter(paginationFooter);
            ConfigureActionMenu(actionMenu, destructiveItems);
        }

        private static void ConfigureActionMenu(ContextMenuStrip actionMenu, ToolStripItem[] destructiveItems)
        {
            foreach (var item in destructiveItems)
                item.Tag = "destructive";

            ModernContextMenuRenderer.Apply(actionMenu);
        }

        private static void ConfigurePaginationFooter(Control paginationFooter)
        {
            paginationFooter.Paint += (_, e) =>
            {
                using var pen = new Pen(Outline);
                e.Graphics.DrawLine(pen, 0, 0, paginationFooter.Width, 0);
            };
        }

        private static void ConfigureGrid(DataGridView grid)
        {
            if (grid.Columns["LocalID"] is { } localIdCol)
            {
                localIdCol.DefaultCellStyle.Format = "\\#0";
                localIdCol.DefaultCellStyle.ForeColor = SecondaryInk;
            }

            if (grid.Columns["ApplicationDate"] is { } dateCol)
            {
                dateCol.DefaultCellStyle.Format = "MMM dd, yyyy";
                dateCol.DefaultCellStyle.ForeColor = SecondaryInk;
            }

            if (grid.Columns["NationalNo"] is { } nationalNoCol)
            {
                nationalNoCol.DefaultCellStyle.ForeColor = SecondaryInk;
            }

            var fonts = new CellFonts();

            grid.CellPainting += (_, e) => PaintApplicationCell(grid, fonts, e);
            grid.CellMouseEnter += (_, e) => HighlightRow(grid, e);
            grid.CellMouseLeave += (_, e) => ClearRowHighlight(grid, e);
            grid.Disposed += (_, _) => fonts.Dispose();
        }

        private static void HighlightRow(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;
            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = RowHover;
            grid.Cursor = Cursors.Hand;
        }

        private static void ClearRowHighlight(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;
            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            grid.Cursor = Cursors.Default;
        }

        private static void PaintApplicationCell(DataGridView grid, CellFonts fonts, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics is null || e.Value is null)
                return;

            string column = grid.Columns[e.ColumnIndex].Name;
            if (column != "Status" && column != "PassedTest" && column != "FullName")
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

            var state = e.Graphics.Save();
            e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int x = e.CellBounds.X + ContentInset;
            int middle = e.CellBounds.Y + e.CellBounds.Height / 2;
            string text = e.Value.ToString() ?? string.Empty;

            switch (column)
            {
                case "FullName":
                    PaintApplicant(e.Graphics, fonts, e.CellBounds, x, middle, text);
                    break;

                case "Status":
                    PaintStatusPill(e.Graphics, fonts, e.CellBounds, x, middle, text);
                    break;

                default:
                    int.TryParse(grid.Rows[e.RowIndex].Cells["PassedTestId"].Value?.ToString(), out int passed);
                    PaintProgress(e.Graphics, fonts, e.CellBounds, x, middle, text, passed);
                    break;
            }

            e.Graphics.Restore(state);
        }

        private static void PaintApplicant(Graphics g, CellFonts fonts, Rectangle cell, int x, int middle, string name)
        {
            const int size = 34;
            var (back, fore) = AvatarPalette[Math.Abs(name.GetHashCode()) % AvatarPalette.Length];
            var circle = new Rectangle(x, middle - size / 2, size, size);

            using (var brush = new SolidBrush(back))
                g.FillEllipse(brush, circle);

            TextRenderer.DrawText(g, Initials(name), fonts.Avatar, circle, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);

            var textBounds = new Rectangle(circle.Right + 10, cell.Y, Math.Max(0, cell.Right - circle.Right - 18), cell.Height);
            TextRenderer.DrawText(g, name, fonts.Name, textBounds, Ink,
                TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private static void PaintStatusPill(Graphics g, CellFonts fonts, Rectangle cell, int x, int middle, string text)
        {
            Color back = Color.FromArgb(219, 234, 254);
            Color fore = Color.FromArgb(29, 78, 216); // New
            if (text == "Completed")
            {
                back = Color.FromArgb(220, 252, 231);
                fore = Color.FromArgb(21, 128, 61);
            }
            else if (text == "Cancelled")
            {
                back = Color.FromArgb(254, 226, 226);
                fore = Color.FromArgb(185, 28, 28);
            }

            int width = Math.Min(cell.Width - ContentInset - 8,
                TextRenderer.MeasureText(text, fonts.Badge).Width + 30);
            if (width <= 20) return;

            var pill = new Rectangle(x, middle - 12, width, 24);
            using (var path = RoundedRect(pill, 12))
            using (var brush = new SolidBrush(back))
                g.FillPath(brush, path);

            using (var dot = new SolidBrush(fore))
                g.FillEllipse(dot, pill.X + 10, middle - 3, 6, 6);

            TextRenderer.DrawText(g, text, fonts.Badge,
                new Rectangle(pill.X + 20, pill.Y, pill.Width - 22, pill.Height), fore,
                TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private static void PaintProgress(Graphics g, CellFonts fonts, Rectangle cell, int x, int middle, string text, int passed)
        {
            Color active = passed >= 3 ? Color.FromArgb(34, 197, 94) : PrimaryBlue;
            for (int i = 0; i < 3; i++)
            {
                var segment = new Rectangle(x + i * 18, middle - 3, 14, 6);
                using var path = RoundedRect(segment, 3);
                using var brush = new SolidBrush(i < passed ? active : Color.FromArgb(226, 232, 240));
                g.FillPath(brush, path);
            }

            TextRenderer.DrawText(g, text, fonts.Progress,
                new Rectangle(x + 62, cell.Y, Math.Max(0, cell.Width - ContentInset - 62), cell.Height), BodyInk,
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

        private sealed class CellFonts : IDisposable
        {
            public Font Name { get; } = new Font("Segoe UI Semibold", 9.5F);
            public Font Badge { get; } = new Font("Segoe UI Semibold", 8.25F);
            public Font Progress { get; } = new Font("Segoe UI Semibold", 9F);
            public Font Avatar { get; } = new Font("Segoe UI Semibold", 8.5F);

            public void Dispose()
            {
                Name.Dispose();
                Badge.Dispose();
                Progress.Dispose();
                Avatar.Dispose();
            }
        }
    }
}
