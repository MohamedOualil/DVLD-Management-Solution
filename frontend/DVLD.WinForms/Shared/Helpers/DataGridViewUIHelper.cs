using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Shared.Helpers
{
    public static class DataGridViewUIHelper
    {
        public static void DrawStatusBadge(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            string statusText = e.Value?.ToString() ?? "";
            Color bgColor, textColor;

            // Set colors based on status
            if (statusText == "Completed")
            {
                bgColor = Color.FromArgb(220, 252, 231); // Very Light Green
                textColor = Color.FromArgb(22, 163, 74); // Dark Green
            }
            else if (statusText == "New")
            {
                bgColor = Color.FromArgb(254, 249, 195); // Very Light Yellow
                textColor = Color.FromArgb(202, 138, 4);  // Dark Yellow/Orange
            }
            else
            {
                bgColor = Color.FromArgb(219, 234, 254); // Light Blue
                textColor = Color.FromArgb(37, 99, 235); // Blue
            }

            int pillHeight = 24;
            int pillWidth = 90;
            int y = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
            int x = e.CellBounds.X + 10;

            Rectangle pillRect = new Rectangle(x, y, pillWidth, pillHeight);

            // Draw pill background
            using (GraphicsPath path = GetRoundedPath(pillRect, 10))
            using (SolidBrush bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillPath(bgBrush, path);
            }

            // Draw little dot
            using (SolidBrush dotBrush = new SolidBrush(textColor))
            {
                e.Graphics.FillEllipse(dotBrush, x + 8, y + 9, 6, 6);
            }

            // Draw text
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (Font statusFont = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            {
                e.Graphics.DrawString(statusText, statusFont, textBrush, x + 20, y + 4);
            }
        }

        // --- 2. THE AVATAR & NAME DRAWER ---
        public static void DrawAvatarAndName(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            string fullName = e.Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(fullName)) return;

            // Extract Initials (e.g., "John Doe" -> "JD")
            var names = fullName.Split(' ');
            string initials = names[0][0].ToString();
            if (names.Length > 1) initials += names[1][0].ToString();

            int circleSize = 30;
            int y = e.CellBounds.Y + (e.CellBounds.Height - circleSize) / 2;
            int x = e.CellBounds.X + 10;

            // Draw Avatar Circle
            using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(224, 231, 255)))
            {
                e.Graphics.FillEllipse(circleBrush, x, y, circleSize, circleSize);
            }

            // Draw Initials
            using (SolidBrush initialBrush = new SolidBrush(Color.FromArgb(79, 70, 229)))
            using (Font initialFont = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            {
                SizeF textSize = e.Graphics.MeasureString(initials, initialFont);
                float textX = x + (circleSize - textSize.Width) / 2;
                float textY = y + (circleSize - textSize.Height) / 2;
                e.Graphics.DrawString(initials, initialFont, initialBrush, textX, textY);
            }

            // Draw Full Name
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
            using (Font nameFont = new Font("Segoe UI", 10f, FontStyle.Bold))
            {
                e.Graphics.DrawString(fullName, nameFont, textBrush, x + circleSize + 10, y + 5);
            }
        }

        // --- PRIVATE HELPER FOR SHAPES ---
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


        // --- 3. THE PROGRESS BAR DRAWER ---
        public static void DrawProgressBar(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            // 1. Safely grab the text. If it's completely null, stop drawing.
            string progressText = e.Value?.ToString();
            if (string.IsNullOrWhiteSpace(progressText)) return;

            // 2. Setup colors
            Color textColor = Color.FromArgb(15, 23, 42);     // Dark text
            Color trackColor = Color.FromArgb(226, 232, 240); // Light gray background track
            Color fillColor = Color.FromArgb(16, 185, 129);   // Vibrant Green fill

            // 3. Draw the Text first
            int x = e.CellBounds.X + 10;

            using (Font textFont = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                // Measure text so we can perfectly center it vertically
                SizeF textSize = e.Graphics.MeasureString(progressText, textFont);
                float textY = e.CellBounds.Y + (e.CellBounds.Height - textSize.Height) / 2;

                e.Graphics.DrawString(progressText, textFont, textBrush, x, textY);

                // Move our X coordinate so we draw the bar AFTER the text
                x += (int)textSize.Width + 15;
            }

            // 4. Safely parse the numbers (even if the data is weird)
            int passed = 0;
            int total = 3; // Default to out of 3

            if (progressText.Contains("/"))
            {
                string[] parts = progressText.Split('/');
                int.TryParse(parts[0].Trim(), out passed);
                int.TryParse(parts[1].Trim(), out total);
            }
            else
            {
                // If the data is just a flat number like "2", use that
                int.TryParse(progressText, out passed);
            }

            // Calculate percentage (protect against divide by zero)
            float percentage = total > 0 ? (float)passed / total : 0;
            percentage = Math.Max(0, Math.Min(1, percentage)); // Lock between 0 and 1

            // 5. Draw the Bar using Thick Pens with Rounded Caps
            int barWidth = 60; // Total width of the progress bar
            int barThickness = 6; // Height of the bar
            int barY = e.CellBounds.Y + (e.CellBounds.Height / 2); // Center line

            using (Pen trackPen = new Pen(trackColor, barThickness) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            using (Pen fillPen = new Pen(fillColor, barThickness) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                // Draw the gray track
                e.Graphics.DrawLine(trackPen, x, barY, x + barWidth, barY);

                // Draw the green fill if they passed at least 1 test
                if (percentage > 0)
                {
                    int fillWidth = (int)(barWidth * percentage);

                    // Prevent drawing a zero-length line which can leave an ugly artifact
                    if (fillWidth > 0)
                    {
                        e.Graphics.DrawLine(fillPen, x, barY, x + fillWidth, barY);
                    }
                }
            }
        }
    }
}

