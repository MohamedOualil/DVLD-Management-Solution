#nullable enable
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Helpers
{
    /// <summary>
    /// Adds a rounded outer border and Escape-key close behavior to borderless modal dialogs.
    /// </summary>
    public static class ModalDialogShellHelper
    {
        // Cached border pen shared across all modal dialogs so Paint events don't allocate a Pen.
        private static readonly Pen ShellBorderPen = new(UITheme.OuterModalBorder, 2f);

        /// <summary>
        /// Wires Escape-key dismissal and rounded shell border painting onto <paramref name="form"/>
        /// and any edge-docked child controls that overlap the dialog border.
        /// </summary>
        public static void Attach(
            Form form,
            float borderRadius = 12f,
            Action? onEscape = null,
            params Control[] paintedChildren)
        {
            ArgumentNullException.ThrowIfNull(form);

            form.KeyPreview = true;
            form.KeyDown += (_, e) =>
            {
                if (e.KeyCode != Keys.Escape)
                    return;

                if (onEscape is not null)
                    onEscape();
                else
                    form.Close();

                e.Handled = true;
            };

            // Paints the form's outer rounded border translated into the sender control's coordinates.
            void PaintShellBorder(object? sender, PaintEventArgs e)
            {
                if (sender is not Control control || form.ClientSize.Width < 4 || form.ClientSize.Height < 4)
                    return;

                int offsetX = 0;
                int offsetY = 0;
                for (Control? current = control; current != null && current != form; current = current.Parent)
                {
                    offsetX += current.Left;
                    offsetY += current.Top;
                }

                GraphicsState state = e.Graphics.Save();
                try
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TranslateTransform(-offsetX, -offsetY);

                    using GraphicsPath path = CreateRoundedRectPath(
                        new RectangleF(1f, 1f, form.ClientSize.Width - 2f, form.ClientSize.Height - 2f),
                        borderRadius);
                    e.Graphics.DrawPath(ShellBorderPen, path);
                }
                finally
                {
                    e.Graphics.Restore(state);
                }
            }

            form.Paint += PaintShellBorder;
            foreach (Control child in paintedChildren)
            {
                if (child is not null)
                    child.Paint += PaintShellBorder;
            }

            form.Resize += (_, _) =>
            {
                form.Invalidate();
                foreach (Control child in paintedChildren)
                {
                    child?.Invalidate();
                }
            };
        }

        private static GraphicsPath CreateRoundedRectPath(RectangleF bounds, float radius)
        {
            float diameter = Math.Max(2f, radius * 2f);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180f, 90f);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270f, 90f);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0f, 90f);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90f, 90f);
            path.CloseFigure();

            return path;
        }
    }
}
