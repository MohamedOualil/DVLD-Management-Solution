#nullable enable
using DVLD.WinForms.Shared.Controls;
using System;
using System.Drawing;

namespace DVLD.WinForms.Shared.Helpers
{
    public static class UITheme
    {
        // Canvas
        public static readonly Color PageCanvas = Color.FromArgb(243, 247, 249);
        public static readonly Color PageCanvasAlt = Color.FromArgb(243, 247, 249);

        // Surfaces & Borders
        public static readonly Color CardSurface = Color.White;
        public static readonly Color InputSurface = Color.FromArgb(248, 250, 252);
        public static readonly Color CardBorder = Color.FromArgb(220, 230, 238);
        public static readonly Color SubtleBorder = Color.FromArgb(226, 232, 240);
        public static readonly Color OuterModalBorder = Color.FromArgb(30, 41, 59);

        // Accents & Dark Headers (Arctic Teal)
        public static readonly Color PrimaryBlue = Color.FromArgb(13, 148, 136);
        public static readonly Color PrimaryBlueHover = Color.FromArgb(15, 118, 110);
        public static readonly Color AccentCyan = Color.FromArgb(2, 132, 199);
        public static readonly Color TealMint = Color.FromArgb(45, 212, 191);
        public static readonly Color DarkHeader = Color.FromArgb(15, 23, 42);
        public static readonly Color DeepNavy = Color.FromArgb(15, 118, 110);

        // Typography
        public static readonly Color HeadingInk = Color.FromArgb(15, 23, 42);
        public static readonly Color BodyInk = Color.FromArgb(51, 65, 85);
        public static readonly Color LabelInk = Color.FromArgb(71, 85, 105);
        public static readonly Color MutedInk = Color.FromArgb(100, 116, 139);
        public static readonly Color PlaceholderInk = Color.FromArgb(148, 163, 184);

        // Dark Sidebar Navigation (Graphite Slate #0F172A)
        public static readonly Color SidebarSurface = Color.FromArgb(15, 23, 42);
        public static readonly Color SidebarSurfaceRaised = Color.FromArgb(23, 35, 56);
        public static readonly Color SidebarBorder = Color.FromArgb(36, 52, 77);
        public static readonly Color NavItemMuted = Color.FromArgb(148, 163, 184);
        public static readonly Color NavItemHoverFill = Color.FromArgb(23, 42, 61);
        public static readonly Color NavItemHoverFore = Color.White;
        public static readonly Color NavItemActiveFill = Color.FromArgb(19, 78, 74);
        public static readonly Color NavItemActiveFore = Color.FromArgb(204, 251, 241);
        public static readonly Color NavIndicator = Color.FromArgb(45, 212, 191);

        // Semantic Status Pills
        public static readonly Color SuccessBg = Color.FromArgb(220, 252, 231);
        public static readonly Color SuccessBorder = Color.FromArgb(187, 247, 208);
        public static readonly Color SuccessText = Color.FromArgb(22, 101, 52);

        public static readonly Color WarningBg = Color.FromArgb(254, 243, 199);
        public static readonly Color WarningBorder = Color.FromArgb(253, 230, 138);
        public static readonly Color WarningText = Color.FromArgb(180, 83, 9);

        public static readonly Color DangerBg = Color.FromArgb(254, 226, 226);
        public static readonly Color DangerBorder = Color.FromArgb(254, 202, 202);
        public static readonly Color DangerText = Color.FromArgb(185, 28, 28);

        public static readonly Color NeutralBg = Color.FromArgb(241, 245, 249);
        public static readonly Color NeutralBorder = Color.FromArgb(226, 232, 240);
        public static readonly Color NeutralText = Color.FromArgb(71, 85, 105);

        public static readonly Color InfoBg = Color.FromArgb(204, 251, 241);
        public static readonly Color InfoBorder = Color.FromArgb(153, 246, 228);
        public static readonly Color InfoText = Color.FromArgb(15, 118, 110);

        public static (Color Fill, Color Border, Color Fore) GetBadgeColors(HeaderBadgeTone tone) => tone switch
        {
            HeaderBadgeTone.Success => (SuccessBg, SuccessBorder, SuccessText),
            HeaderBadgeTone.Warning => (WarningBg, WarningBorder, WarningText),
            HeaderBadgeTone.Danger => (DangerBg, DangerBorder, DangerText),
            HeaderBadgeTone.Neutral => (NeutralBg, NeutralBorder, NeutralText),
            _ => (InfoBg, InfoBorder, InfoText)
        };

        public static (Color Fill, Color Fore) ResolveStatusPillColors(string? statusText)
        {
            string normalized = statusText?.Trim() ?? string.Empty;

            if (normalized.Equals("Completed", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Active", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Released", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Ready to Issue", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Passed", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Success", StringComparison.OrdinalIgnoreCase))
            {
                return (SuccessBg, SuccessText);
            }

            if (normalized.Equals("New", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Scheduled", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Vision Test", StringComparison.OrdinalIgnoreCase))
            {
                return (InfoBg, InfoText);
            }

            if (normalized.Equals("Written Test", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Street Test", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Warning", StringComparison.OrdinalIgnoreCase))
            {
                return (WarningBg, WarningText);
            }

            if (normalized.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Canceled", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Detained", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Expired", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Failed", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Failure", StringComparison.OrdinalIgnoreCase))
            {
                return (DangerBg, DangerText);
            }

            return (NeutralBg, NeutralText);
        }
    }
}
