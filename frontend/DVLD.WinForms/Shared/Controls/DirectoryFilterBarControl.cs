#nullable enable
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class DirectoryFilterBarControl : UserControl
    {
        private static readonly Image RefreshIcon = Properties.Resources.icons8_renew_48;
        private static readonly Image AddIcon = Properties.Resources.icons8_add_properties_24;

        public event EventHandler? SearchChanged;
        public event EventHandler? FilterChanged;
        public event EventHandler? PrimaryActionClicked;

        public DirectoryFilterBarControl()
        {
            InitializeComponent();
            ApplyVectorIcons();
            txtSearch.TextChanged += (_, _) => SearchChanged?.Invoke(this, EventArgs.Empty);
            cmbFilter.SelectedIndexChanged += (_, _) => FilterChanged?.Invoke(this, EventArgs.Empty);
            btnPrimaryAction.Click += (_, _) => PrimaryActionClicked?.Invoke(this, EventArgs.Empty);
            filterCard.SizeChanged += (_, _) => UpdateToolbarLayout();
            SizeChanged += (_, _) => UpdateToolbarLayout();
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string SearchText
        {
            get => txtSearch.Text.Trim();
            set => txtSearch.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("Search records...")]
        public string SearchPlaceholder
        {
            get => txtSearch.PlaceholderText;
            set => txtSearch.PlaceholderText = value ?? "Search records...";
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedFilterIndex
        {
            get => cmbFilter.SelectedIndex;
            set
            {
                if (value >= 0 && value < cmbFilter.Items.Count)
                    cmbFilter.SelectedIndex = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedFilterText => cmbFilter.SelectedItem?.ToString() ?? string.Empty;

        [Category("Appearance")]
        [DefaultValue("0 records")]
        public string CountText
        {
            get => lblCountBadge.Text;
            set => lblCountBadge.Text = string.IsNullOrWhiteSpace(value) ? "0 records" : value;
        }

        [Category("Appearance")]
        [DefaultValue("+ Add Record")]
        public string PrimaryButtonText
        {
            get => btnPrimaryAction.Text;
            set => ApplyPrimaryButtonAppearance(value);
        }

        private void ApplyVectorIcons()
        {
            txtSearch.IconLeft = Properties.Resources.icons8_search_32;
            txtSearch.IconLeftSize = new Size(16, 16);
            txtSearch.TextOffset = new Point(0, 0);

            ApplyPrimaryButtonAppearance(btnPrimaryAction.Text);
        }

        private void ApplyPrimaryButtonAppearance(string? value)
        {
            string raw = value?.Trim() ?? string.Empty;
            bool isRefresh = raw.Contains("Refresh", StringComparison.OrdinalIgnoreCase) ||
                             raw.StartsWith("↻", StringComparison.Ordinal);

            btnPrimaryAction.Image = isRefresh ? RefreshIcon : AddIcon;
            btnPrimaryAction.ImageSize = new Size(15, 15);
            btnPrimaryAction.ImageOffset = new Point(-2, 0);
            btnPrimaryAction.Text = NormalizePrimaryButtonText(raw);
        }

        private static string NormalizePrimaryButtonText(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Add Record";

            string trimmed = value.Trim();
            if (trimmed.StartsWith("+", StringComparison.Ordinal) || trimmed.StartsWith("↻", StringComparison.Ordinal))
                trimmed = trimmed.TrimStart('+', '↻').TrimStart();

            return string.IsNullOrWhiteSpace(trimmed) ? "Add Record" : trimmed;
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowPrimaryButton
        {
            get => btnPrimaryAction.Visible;
            set
            {
                btnPrimaryAction.Visible = value;
                UpdateToolbarLayout();
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowFilterCombo
        {
            get => cmbFilter.Visible;
            set
            {
                cmbFilter.Visible = value;
                UpdateToolbarLayout();
            }
        }

        public void SetFilterItems(params string[] items)
        {
            cmbFilter.Items.Clear();
            if (items is { Length: > 0 })
            {
                cmbFilter.Items.AddRange(items);
                cmbFilter.SelectedIndex = 0;
            }
        }

        private void UpdateToolbarLayout()
        {
            int rightEdge = filterCard.ClientSize.Width - 16;

            if (btnPrimaryAction.Visible)
            {
                btnPrimaryAction.Location = new Point(rightEdge - btnPrimaryAction.Width, btnPrimaryAction.Top);
                rightEdge = btnPrimaryAction.Left - 12;
            }

            lblCountBadge.Location = new Point(rightEdge - lblCountBadge.Width, lblCountBadge.Top);
            rightEdge = lblCountBadge.Left - 12;

            if (cmbFilter.Visible)
            {
                cmbFilter.Location = new Point(rightEdge - cmbFilter.Width, cmbFilter.Top);
                rightEdge = cmbFilter.Left - 12;
            }

            int searchWidth = Math.Max(160, rightEdge - txtSearch.Left);
            txtSearch.Size = new Size(searchWidth, txtSearch.Height);
        }
    }
}
