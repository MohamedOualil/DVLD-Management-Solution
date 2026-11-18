#nullable enable
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Helpers
{
    /// <summary>
    /// Custom cell painters for DataGridView columns (status pills, circular initials, progress bars).
    /// All fonts, brushes, and pens are cached statically so scrolling stays fast without GDI+ allocations.
    /// </summary>
    public static class DataGridViewUIHelper
    {
        private static readonly Font BadgeFont = new("Segoe UI", 8.5f, FontStyle.Bold);
        private static readonly Font CellBoldFont = new("Segoe UI", 9.5f, FontStyle.Bold);
        private static readonly SolidBrush AvatarCircleBrush = new(UITheme.InfoBg);
        private static readonly Pen ProgressTrackPen = new(UITheme.SubtleBorder, 6f)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };
        private static readonly Pen ProgressFillPen = new(Color.FromArgb(16, 185, 129), 6f)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        // --- 1. STATUS PILL BADGE DRAWER ---
        public static void DrawStatusBadge(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Graphics is null)
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

            string rawText = e.Value?.ToString() ?? string.Empty;
            string statusText = rawText.TrimStart('●', '○', '•', ' ').Trim();
            if (string.IsNullOrEmpty(statusText))
                statusText = "—";

            var (bgColor, textColor) = UITheme.ResolveStatusPillColors(statusText);

            var state = e.Graphics.Save();
            try
            {
                e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                const int pillHeight = 24;
                int measuredWidth = TextRenderer.MeasureText(e.Graphics, statusText, BadgeFont).Width;
                int pillWidth = Math.Max(78, measuredWidth + 28);
                pillWidth = Math.Min(Math.Max(24, e.CellBounds.Width - 16), pillWidth);
                int y = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                int x = e.CellBounds.X + 10;

                Rectangle pillRect = new Rectangle(x, y, pillWidth, pillHeight);

                using (GraphicsPath path = GetRoundedPath(pillRect, 10))
                using (SolidBrush bgBrush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(bgBrush, path);
                }

                using (SolidBrush dotBrush = new SolidBrush(textColor))
                {
                    e.Graphics.FillEllipse(dotBrush, x + 8, y + 9, 6, 6);
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    statusText,
                    BadgeFont,
                    new Rectangle(x + 20, y, Math.Max(0, pillWidth - 24), pillHeight),
                    textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
            }
            finally
            {
                e.Graphics.Restore(state);
            }
        }

        // --- 2. AVATAR CIRCLE & FULL NAME DRAWER ---
        public static void DrawAvatarAndName(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Graphics is null)
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

            string fullName = e.Value?.ToString() ?? string.Empty;
            string initials = ExtractInitials(fullName);
            if (initials.Length == 0) return;

            var state = e.Graphics.Save();
            try
            {
                e.Graphics.SetClip(e.CellBounds, CombineMode.Intersect);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                const int circleSize = 30;
                int y = e.CellBounds.Y + (e.CellBounds.Height - circleSize) / 2;
                int x = e.CellBounds.X + 10;

                // Draw tinted avatar circle using the cached background brush
                e.Graphics.FillEllipse(AvatarCircleBrush, x, y, circleSize, circleSize);

                // Draw initials centered inside the circle
                TextRenderer.DrawText(
                    e.Graphics,
                    initials,
                    BadgeFont,
                    new Rectangle(x, y, circleSize, circleSize),
                    UITheme.InfoText,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);

                // Draw full name beside the avatar circle
                TextRenderer.DrawText(
                    e.Graphics,
                    fullName,
                    CellBoldFont,
                    new Rectangle(x + circleSize + 10, e.CellBounds.Y, Math.Max(0, e.CellBounds.Width - circleSize - 24), e.CellBounds.Height),
                    UITheme.HeadingInk,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
            }
            finally
            {
                e.Graphics.Restore(state);
            }
        }

        // Scans the name span directly to extract first and last initials without allocating a string array.
        private static string ExtractInitials(string fullName)
        {
            ReadOnlySpan<char> span = fullName.AsSpan();

            int firstStart = 0;
            while (firstStart < span.Length && span[firstStart] == ' ')
                firstStart++;

            if (firstStart >= span.Length)
                return string.Empty;

            int lastEnd = span.Length - 1;
            while (lastEnd > firstStart && span[lastEnd] == ' ')
                lastEnd--;

            int lastStart = lastEnd;
            while (lastStart > firstStart && span[lastStart - 1] != ' ')
                lastStart--;

            char first = char.ToUpperInvariant(span[firstStart]);
            if (firstStart == lastStart)
                return first.ToString();

            char last = char.ToUpperInvariant(span[lastStart]);
            return string.Create(2, (first, last), static (dst, state) =>
            {
                dst[0] = state.first;
                dst[1] = state.last;
            });
        }

        // --- PRIVATE HELPER FOR ROUNDED SHAPES ---
        private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // --- 3. TEST PROGRESS BAR DRAWER ---
        public static void DrawProgressBar(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Graphics is null)
                return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            // Grab the cell text (e.g. "2/3"); stop early if empty
            string? progressText = e.Value?.ToString();
            if (string.IsNullOrWhiteSpace(progressText)) return;

            // Measure and draw the label text first using the cached bold font
            int x = e.CellBounds.X + 10;
            Size textSize = TextRenderer.MeasureText(e.Graphics, progressText, CellBoldFont, Size.Empty, TextFormatFlags.NoPrefix);
            TextRenderer.DrawText(
                e.Graphics,
                progressText,
                CellBoldFont,
                new Rectangle(x, e.CellBounds.Y, textSize.Width, e.CellBounds.Height),
                UITheme.HeadingInk,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPrefix);

            // Advance X so the progress bar renders after the label
            x += textSize.Width + 15;

            // Parse "passed/total" using spans to avoid splitting into temporary strings
            int passed = 0;
            int total = 3;

            ReadOnlySpan<char> span = progressText.AsSpan();
            int slashIndex = span.IndexOf('/');
            if (slashIndex >= 0)
            {
                int.TryParse(span[..slashIndex].Trim(), out passed);
                int.TryParse(span[(slashIndex + 1)..].Trim(), out total);
            }
            else
            {
                int.TryParse(span.Trim(), out passed);
            }

            float percentage = total > 0 ? (float)passed / total : 0f;
            percentage = Math.Clamp(percentage, 0f, 1f);

            // Draw the gray background track and green progress fill using cached pens
            const int barWidth = 60;
            int barY = e.CellBounds.Y + (e.CellBounds.Height / 2);

            GraphicsState state = e.Graphics.Save();
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(ProgressTrackPen, x, barY, x + barWidth, barY);

                if (percentage > 0f)
                {
                    int fillWidth = (int)(barWidth * percentage);
                    if (fillWidth > 0)
                    {
                        e.Graphics.DrawLine(ProgressFillPen, x, barY, x + fillWidth, barY);
                    }
                }
            }
            finally
            {
                e.Graphics.Restore(state);
            }
        }
    }
}

