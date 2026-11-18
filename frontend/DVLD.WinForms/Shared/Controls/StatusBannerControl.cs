#nullable enable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class StatusBannerControl : UserControl
    {
        private HeaderBadgeTone _tone = HeaderBadgeTone.Info;

        public StatusBannerControl()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        [DefaultValue("Status Notice")]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = string.IsNullOrWhiteSpace(value) ? "Status Notice" : value;
        }

        [Category("Appearance")]
        [DefaultValue("Information and eligibility details appear here.")]
        public string Description
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue(HeaderBadgeTone.Info)]
        public HeaderBadgeTone Tone
        {
            get => _tone;
            set
            {
                _tone = value;
                ApplyTone(value);
            }
        }

        public void SetBanner(string title, string description, HeaderBadgeTone tone = HeaderBadgeTone.Info)
        {
            Title = title;
            Description = description;
            Tone = tone;
        }

        public void SetMessage(string message, HeaderBadgeTone tone = HeaderBadgeTone.Info, string? title = null)
        {
            string resolvedTitle = !string.IsNullOrWhiteSpace(title)
                ? title
                : tone switch
                {
                    HeaderBadgeTone.Success => "Ready to Proceed",
                    HeaderBadgeTone.Warning => "Attention Required",
                    HeaderBadgeTone.Danger => "Action Restricted",
                    HeaderBadgeTone.Neutral => "Information",
                    _ => "Status Update"
                };

            SetBanner(resolvedTitle, message ?? string.Empty, tone);
        }

        private void ApplyTone(HeaderBadgeTone tone)
        {
            var (cardFill, cardBorder, badgeFill, iconText, titleColor, descColor) = tone switch
            {
                HeaderBadgeTone.Success => (
                    Color.FromArgb(240, 253, 244),
                    Color.FromArgb(187, 247, 208),
                    Color.FromArgb(220, 252, 231),
                    "✓",
                    Color.FromArgb(22, 101, 52),
                    Color.FromArgb(22, 101, 52)),
                HeaderBadgeTone.Warning => (
                    Color.FromArgb(255, 251, 235),
                    Color.FromArgb(253, 230, 138),
                    Color.FromArgb(254, 243, 199),
                    "!",
                    Color.FromArgb(180, 83, 9),
                    Color.FromArgb(180, 83, 9)),
                HeaderBadgeTone.Danger => (
                    Color.FromArgb(254, 242, 242),
                    Color.FromArgb(254, 202, 202),
                    Color.FromArgb(254, 226, 226),
                    "✕",
                    Color.FromArgb(185, 28, 28),
                    Color.FromArgb(185, 28, 28)),
                HeaderBadgeTone.Neutral => (
                    Color.FromArgb(248, 250, 252),
                    Color.FromArgb(226, 232, 240),
                    Color.FromArgb(241, 245, 249),
                    "•",
                    Color.FromArgb(71, 85, 105),
                    Color.FromArgb(71, 85, 105)),
                _ => (
                    Color.FromArgb(240, 253, 250),
                    Color.FromArgb(153, 246, 228),
                    Color.FromArgb(204, 251, 241),
                    "i",
                    Color.FromArgb(15, 118, 110),
                    Color.FromArgb(51, 65, 85))
            };

            bannerCard.FillColor = cardFill;
            bannerCard.BorderColor = cardBorder;
            iconBadge.FillColor = badgeFill;
            lblIcon.Text = iconText;
            lblIcon.ForeColor = titleColor;
            lblTitle.ForeColor = titleColor;
            lblDescription.ForeColor = descColor;
        }
    }
}
