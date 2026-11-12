using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Helpers
{
    public sealed class ModernContextMenuRenderer : ToolStripProfessionalRenderer
    {
        private static readonly Color MenuBackColor = Color.White;
        private static readonly Color MenuBorderColor = Color.FromArgb(226, 232, 240);
        private static readonly Color HoverBackColor = Color.FromArgb(239, 246, 255);
        private static readonly Color HoverTextColor = Color.FromArgb(29, 78, 216);
        private static readonly Color DestructiveTextColor = Color.FromArgb(220, 38, 38);
        private static readonly Color DestructiveHoverBackColor = Color.FromArgb(254, 242, 242);
        private static readonly Color NormalTextColor = Color.FromArgb(30, 41, 59);
        private static readonly Color DisabledTextColor = Color.FromArgb(148, 163, 184);
        private static readonly Color SeparatorColor = Color.FromArgb(241, 245, 249);
        private static readonly Color ArrowColor = Color.FromArgb(100, 116, 139);

        private const int CornerRadius = 10;

        public ModernContextMenuRenderer() : base(new CleanColorTable())
        {
            RoundedEdges = false;
        }

        public static void Apply(ContextMenuStrip menu)
        {
            menu.Renderer = new ModernContextMenuRenderer();
            menu.ShowImageMargin = true;
            menu.ShowCheckMargin = false;
            menu.BackColor = MenuBackColor;
            menu.Padding = new Padding(4, 6, 4, 6);
            menu.DropShadowEnabled = true;

            StyleMenuItems(menu.Items);

            menu.Opening += (_, _) => ApplyRoundedRegion(menu);
            menu.Resize += (_, _) => ApplyRoundedRegion(menu);
        }

        private static void StyleMenuItems(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.AutoSize = false;
                    menuItem.Height = 36;
                    menuItem.Width = 264;
                    menuItem.Padding = new Padding(4, 0, 8, 0);
                    menuItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    menuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit;

                    if (menuItem.HasDropDownItems && menuItem.DropDown is ToolStripDropDownMenu dropDown)
                    {
                        dropDown.Renderer = new ModernContextMenuRenderer();
                        dropDown.ShowImageMargin = true;
                        dropDown.ShowCheckMargin = false;
                        dropDown.BackColor = MenuBackColor;
                        dropDown.Padding = new Padding(4, 6, 4, 6);
                        dropDown.DropShadowEnabled = true;
                        dropDown.Opened += (_, _) => ApplyRoundedRegion(dropDown);
                        StyleMenuItems(menuItem.DropDownItems);
                    }
                }
                else if (item is ToolStripSeparator sep)
                {
                    sep.AutoSize = false;
                    sep.Height = 9;
                }
            }
        }

        private static void ApplyRoundedRegion(Control control)
        {
            if (control.Width <= 0 || control.Height <= 0) return;
            using var path = CreateRoundedRect(new Rectangle(0, 0, control.Width, control.Height), CornerRadius);
            control.Region = new Region(path);
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
            using var brush = new SolidBrush(MenuBackColor);
            e.Graphics.FillRectangle(brush, rect);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // Intentionally left empty to remove the legacy gray left column.
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using var path = CreateRoundedRect(rect, CornerRadius);
            using var pen = new Pen(MenuBorderColor, 1f);
            e.Graphics.DrawPath(pen, path);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Enabled || !e.Item.Selected)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var pillBounds = new Rectangle(4, 2, e.Item.Width - 8, e.Item.Height - 4);
            bool isDestructive = string.Equals(e.Item.Tag?.ToString(), "destructive", StringComparison.OrdinalIgnoreCase);

            using var path = CreateRoundedRect(pillBounds, 7);
            using var brush = new SolidBrush(isDestructive ? DestructiveHoverBackColor : HoverBackColor);
            e.Graphics.FillPath(brush, path);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            bool isDestructive = string.Equals(e.Item.Tag?.ToString(), "destructive", StringComparison.OrdinalIgnoreCase);

            Color textColor;
            if (!e.Item.Enabled)
            {
                textColor = DisabledTextColor;
            }
            else if (isDestructive)
            {
                textColor = DestructiveTextColor;
            }
            else if (e.Item.Selected)
            {
                textColor = HoverTextColor;
            }
            else
            {
                textColor = NormalTextColor;
            }

            var textRect = new Rectangle(
                38,
                0,
                Math.Max(0, e.Item.Width - 58),
                e.Item.Height);

            TextRenderer.DrawText(
                e.Graphics,
                e.Text,
                e.TextFont,
                textRect,
                textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (e.Image == null) return;

            const int iconSize = 18;
            int x = 12;
            int y = (e.Item.Height - iconSize) / 2;
            var destRect = new Rectangle(x, y, iconSize, iconSize);

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (e.Item.Enabled)
            {
                e.Graphics.DrawImage(e.Image, destRect);
            }
            else
            {
                using var attributes = new ImageAttributes();
                var matrix = new ColorMatrix { Matrix33 = 0.35f };
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                e.Graphics.DrawImage(
                    e.Image,
                    destRect,
                    0, 0, e.Image.Width, e.Image.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item is null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color color = !e.Item.Enabled
                ? DisabledTextColor
                : (e.Item.Selected ? HoverTextColor : ArrowColor);

            using var pen = new Pen(color, 1.75f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            float cx = e.Item.Width - 16f;
            float cy = e.Item.Height / 2f;
            e.Graphics.DrawLines(pen, new[]
            {
                new PointF(cx - 2.5f, cy - 4f),
                new PointF(cx + 2f, cy),
                new PointF(cx - 2.5f, cy + 4f)
            });
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            int y = e.Item.Height / 2;
            using var pen = new Pen(SeparatorColor, 1f);
            e.Graphics.DrawLine(pen, 12, y, e.Item.Width - 12, y);
        }

        private static GraphicsPath CreateRoundedRect(Rectangle bounds, int radius)
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

        private sealed class CleanColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground => MenuBackColor;
            public override Color ImageMarginGradientBegin => MenuBackColor;
            public override Color ImageMarginGradientMiddle => MenuBackColor;
            public override Color ImageMarginGradientEnd => MenuBackColor;
            public override Color MenuBorder => MenuBorderColor;
            public override Color MenuItemBorder => Color.Transparent;
        }
    }
}
