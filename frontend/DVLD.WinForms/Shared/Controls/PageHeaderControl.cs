#nullable enable
using DVLD.Contracts.Enums;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public enum HeaderBadgeTone
    {
        Neutral,
        Info,
        Success,
        Warning,
        Danger
    }

    public partial class PageHeaderControl : UserControl
    {
        private HeaderBadgeTone _badgeTone = HeaderBadgeTone.Info;
        private bool _badgeVisible = true;
        private bool _showBackButton = true;

        public event EventHandler? BackRequested;

        public PageHeaderControl()
        {
            InitializeComponent();
            btnBack.Click += (_, _) => BackRequested?.Invoke(this, EventArgs.Empty);
            headerCard.SizeChanged += (_, _) => UpdateBadgeAndButtonLayout();
            SizeChanged += (_, _) => UpdateBadgeAndButtonLayout();
            Layout += (_, _) => UpdateBadgeAndButtonLayout();
            UpdateBadgeAndButtonLayout();
        }

        [Category("Appearance")]
        [DefaultValue("Page Header Title")]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = string.IsNullOrWhiteSpace(value) ? "—" : value;
        }

        [Category("Appearance")]
        [DefaultValue("Manage and review details for this record")]
        public string Subtitle
        {
            get => lblSubtitle.Text;
            set => lblSubtitle.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("DV")]
        public string IconText
        {
            get => lblIconText.Text;
            set => lblIconText.Text = string.IsNullOrWhiteSpace(value) ? "DV" : value.Trim();
        }

        [Category("Appearance")]
        [DefaultValue("● Active Record")]
        public string BadgeText
        {
            get => statusBadge.Text;
            set => statusBadge.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool BadgeVisible
        {
            get => _badgeVisible;
            set
            {
                _badgeVisible = value;
                statusBadge.Visible = value;
                UpdateBadgeAndButtonLayout();
            }
        }

        [Category("Appearance")]
        [DefaultValue(HeaderBadgeTone.Info)]
        public HeaderBadgeTone BadgeTone
        {
            get => _badgeTone;
            set
            {
                _badgeTone = value;
                ApplyBadgeTone(value);
            }
        }

        [Category("Appearance")]
        [DefaultValue("← Back")]
        public string BackButtonText
        {
            get => btnBack.Text;
            set => btnBack.Text = string.IsNullOrWhiteSpace(value) ? "← Back" : value;
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowBackButton
        {
            get => _showBackButton;
            set
            {
                _showBackButton = value;
                btnBack.Visible = value;
                UpdateBadgeAndButtonLayout();
            }
        }

        public void Configure(
            string title,
            string subtitle,
            string? badgeText = null,
            HeaderBadgeTone tone = HeaderBadgeTone.Info,
            bool showBackButton = true,
            string? iconText = null)
        {
            Title = title;
            Subtitle = subtitle;
            ShowBackButton = showBackButton;

            if (!string.IsNullOrWhiteSpace(iconText))
                IconText = iconText;

            if (string.IsNullOrWhiteSpace(badgeText))
            {
                BadgeVisible = false;
            }
            else
            {
                BadgeText = badgeText;
                BadgeTone = tone;
                BadgeVisible = true;
            }
        }

        public void SetApplicationStatus(ApplicationStatusEnum status)
        {
            switch (status)
            {
                case ApplicationStatusEnum.Completed:
                    BadgeText = "● Completed";
                    BadgeTone = HeaderBadgeTone.Success;
                    break;
                case ApplicationStatusEnum.Cancelled:
                    BadgeText = "● Cancelled";
                    BadgeTone = HeaderBadgeTone.Danger;
                    break;
                case ApplicationStatusEnum.New:
                default:
                    BadgeText = "● New Application";
                    BadgeTone = HeaderBadgeTone.Info;
                    break;
            }

            BadgeVisible = true;
        }

        private void ApplyBadgeTone(HeaderBadgeTone tone)
        {
            var (fill, border, fore) = UITheme.GetBadgeColors(tone);

            statusBadge.FillColor = fill;
            statusBadge.BorderColor = border;
            statusBadge.ForeColor = fore;
            statusBadge.HoverState.FillColor = fill;
            statusBadge.HoverState.BorderColor = border;
            statusBadge.HoverState.ForeColor = fore;
            statusBadge.PressedColor = fill;
        }

        private void UpdateBadgeAndButtonLayout()
        {
            int rightEdge = headerCard.ClientSize.Width - 16;
            if (_showBackButton)
            {
                btnBack.Location = new Point(rightEdge - btnBack.Width, btnBack.Top);
                rightEdge = btnBack.Left - 10;
            }

            if (_badgeVisible)
            {
                statusBadge.Location = new Point(rightEdge - statusBadge.Width, statusBadge.Top);
                rightEdge = statusBadge.Left - 12;
            }

            int titleWidth = Math.Max(120, rightEdge - lblTitle.Left);
            lblTitle.Size = new Size(titleWidth, lblTitle.Height);
            lblSubtitle.Size = new Size(titleWidth, lblSubtitle.Height);
            statusBadge.BringToFront();
            btnBack.BringToFront();
        }
    }
}
