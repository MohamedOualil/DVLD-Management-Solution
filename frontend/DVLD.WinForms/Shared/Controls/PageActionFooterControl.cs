#nullable enable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.WinForms.Shared.Controls
{
    public partial class PageActionFooterControl : UserControl
    {
        private string _idlePrimaryText = "Save Changes";
        private bool _isBusy;
        private bool _showSecondaryButton = true;

        public event EventHandler? PrimaryActionRequested;
        public event EventHandler? SecondaryActionRequested;

        public PageActionFooterControl()
        {
            InitializeComponent();
            btnPrimary.Click += (_, _) => PrimaryActionRequested?.Invoke(this, EventArgs.Empty);
            btnSecondary.Click += (_, _) => SecondaryActionRequested?.Invoke(this, EventArgs.Empty);
            footerCard.SizeChanged += (_, _) => UpdateButtonLayout();
            SizeChanged += (_, _) => UpdateButtonLayout();
            Layout += (_, _) => UpdateButtonLayout();
            UpdateButtonLayout();
        }

        [Category("Appearance")]
        [DefaultValue("Review the information above before continuing.")]
        public string HintText
        {
            get => lblFooterHint.Text;
            set => lblFooterHint.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("Save Changes")]
        public string PrimaryButtonText
        {
            get => _idlePrimaryText;
            set
            {
                _idlePrimaryText = string.IsNullOrWhiteSpace(value) ? "Save Changes" : value;
                if (!_isBusy)
                {
                    btnPrimary.Text = _idlePrimaryText;
                    UpdateButtonLayout();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue("Cancel")]
        public string SecondaryButtonText
        {
            get => btnSecondary.Text;
            set => btnSecondary.Text = string.IsNullOrWhiteSpace(value) ? "Cancel" : value;
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool PrimaryButtonEnabled
        {
            get => btnPrimary.Enabled;
            set => btnPrimary.Enabled = value;
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool SecondaryButtonEnabled
        {
            get => btnSecondary.Enabled;
            set => btnSecondary.Enabled = value;
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowSecondaryButton
        {
            get => _showSecondaryButton;
            set
            {
                _showSecondaryButton = value;
                btnSecondary.Visible = value;
                UpdateButtonLayout();
            }
        }

        public void SetState(bool primaryEnabled, string hintMessage, bool isWarningOrError = false)
        {
            if (!_isBusy)
                btnPrimary.Enabled = primaryEnabled;

            lblFooterHint.Text = hintMessage ?? string.Empty;

            if (isWarningOrError)
            {
                lblHintDot.ForeColor = Color.FromArgb(217, 119, 6);
                lblFooterHint.ForeColor = Color.FromArgb(146, 64, 14);
            }
            else if (primaryEnabled)
            {
                lblHintDot.ForeColor = Color.FromArgb(22, 163, 74);
                lblFooterHint.ForeColor = Color.FromArgb(51, 65, 85);
            }
            else
            {
                lblHintDot.ForeColor = Color.FromArgb(13, 148, 136);
                lblFooterHint.ForeColor = Color.FromArgb(100, 116, 139);
            }
        }

        public void SetBusy(bool isBusy, string? busyButtonText = null)
        {
            _isBusy = isBusy;
            if (isBusy)
            {
                btnPrimary.Enabled = false;
                btnSecondary.Enabled = false;
                btnPrimary.Text = string.IsNullOrWhiteSpace(busyButtonText) ? "Processing…" : busyButtonText;
            }
            else
            {
                btnPrimary.Text = _idlePrimaryText;
                btnSecondary.Enabled = true;
            }

            UpdateButtonLayout();
        }

        private void UpdateButtonLayout()
        {
            int measured = TextRenderer.MeasureText(btnPrimary.Text, btnPrimary.Font).Width + 36;
            int primaryWidth = Math.Max(148, measured);
            int primaryLeft = footerCard.ClientSize.Width - 16 - primaryWidth;
            btnPrimary.SetBounds(primaryLeft, 10, primaryWidth, 36);
            btnSecondary.Location = new Point(primaryLeft - 10 - btnSecondary.Width, 10);
            UpdateHintWidth();
        }

        private void UpdateHintWidth()
        {
            int rightLimit = _showSecondaryButton ? btnSecondary.Left - 14 : btnPrimary.Left - 14;
            int width = Math.Max(140, rightLimit - lblFooterHint.Left);
            lblFooterHint.Size = new Size(width, lblFooterHint.Height);
            btnSecondary.BringToFront();
            btnPrimary.BringToFront();
        }


    }
}
