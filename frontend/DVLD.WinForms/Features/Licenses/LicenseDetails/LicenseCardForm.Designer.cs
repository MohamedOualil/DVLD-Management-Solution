namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    partial class LicenseCardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges badgeEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges badgeShadowEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges statusEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges statusShadowEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges controlBoxEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges controlBoxShadowEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges containerEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges containerShadowEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges closeBtnEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges closeBtnShadowEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            formElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            formShadow = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            formAnimation = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            formDrag = new Guna.UI2.WinForms.Guna2DragControl(components);

            headerPanel = new Panel();
            headerAccentBar = new Panel();
            headerIconBadge = new Guna.UI2.WinForms.Guna2Panel();
            headerIconLabel = new Label();
            titleLabel = new Label();
            subtitleLabel = new Label();
            recordStatusBadge = new Guna.UI2.WinForms.Guna2Panel();
            lblRecordStatus = new Label();
            closeControlBox = new Guna.UI2.WinForms.Guna2ControlBox();
            headerDivider = new Panel();

            bodyPanel = new Panel();
            cardContainerPanel = new Guna.UI2.WinForms.Guna2Panel();
            licenseCardControl1 = new LicenseCardControl();

            footerPanel = new Panel();
            footerDivider = new Panel();
            lblFooterHint = new Label();
            closeButton = new Guna.UI2.WinForms.Guna2Button();

            headerPanel.SuspendLayout();
            headerIconBadge.SuspendLayout();
            recordStatusBadge.SuspendLayout();
            bodyPanel.SuspendLayout();
            cardContainerPanel.SuspendLayout();
            footerPanel.SuspendLayout();
            SuspendLayout();

            formElipse.BorderRadius = 12;
            formElipse.TargetControl = this;

            formShadow.TargetForm = this;

            formAnimation.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            formAnimation.Interval = 180;

            formDrag.DockIndicatorTransparencyValue = 0.6D;
            formDrag.TargetControl = headerPanel;
            formDrag.UseTransparentDrag = true;

            // Header strip
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(headerIconBadge);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(recordStatusBadge);
            headerPanel.Controls.Add(closeControlBox);
            headerPanel.Controls.Add(headerDivider);
            headerPanel.Controls.Add(headerAccentBar);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(768, 76);
            headerPanel.TabIndex = 0;

            headerAccentBar.BackColor = Color.FromArgb(13, 148, 136);
            headerAccentBar.Dock = DockStyle.Top;
            headerAccentBar.Location = new Point(0, 0);
            headerAccentBar.Name = "headerAccentBar";
            headerAccentBar.Size = new Size(768, 4);
            headerAccentBar.TabIndex = 0;

            headerIconBadge.BackColor = Color.Transparent;
            headerIconBadge.BorderColor = Color.FromArgb(153, 246, 228);
            headerIconBadge.BorderRadius = 10;
            headerIconBadge.BorderThickness = 1;
            headerIconBadge.Controls.Add(headerIconLabel);
            headerIconBadge.CustomizableEdges = badgeEdges;
            headerIconBadge.FillColor = Color.FromArgb(240, 253, 250);
            headerIconBadge.Location = new Point(24, 18);
            headerIconBadge.Name = "headerIconBadge";
            headerIconBadge.ShadowDecoration.CustomizableEdges = badgeShadowEdges;
            headerIconBadge.Size = new Size(42, 42);
            headerIconBadge.TabIndex = 1;

            headerIconLabel.BackColor = Color.Transparent;
            headerIconLabel.Dock = DockStyle.Fill;
            headerIconLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerIconLabel.ForeColor = Color.FromArgb(13, 148, 136);
            headerIconLabel.Location = new Point(0, 0);
            headerIconLabel.Name = "headerIconLabel";
            headerIconLabel.Size = new Size(42, 42);
            headerIconLabel.TabIndex = 0;
            headerIconLabel.Text = "DL";
            headerIconLabel.TextAlign = ContentAlignment.MiddleCenter;
            headerIconLabel.UseMnemonic = false;

            titleLabel.AutoSize = false;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(15, 23, 42);
            titleLabel.Location = new Point(78, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(420, 24);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Driving License Credential";
            titleLabel.UseMnemonic = false;

            subtitleLabel.AutoEllipsis = true;
            subtitleLabel.AutoSize = false;
            subtitleLabel.BackColor = Color.Transparent;
            subtitleLabel.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subtitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            subtitleLabel.Location = new Point(78, 42);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(454, 18);
            subtitleLabel.TabIndex = 3;
            subtitleLabel.Text = "Official driver license record and validity details";
            subtitleLabel.UseMnemonic = false;

            recordStatusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            recordStatusBadge.BackColor = Color.Transparent;
            recordStatusBadge.BorderColor = Color.FromArgb(187, 247, 208);
            recordStatusBadge.BorderRadius = 14;
            recordStatusBadge.BorderThickness = 1;
            recordStatusBadge.Controls.Add(lblRecordStatus);
            recordStatusBadge.CustomizableEdges = statusEdges;
            recordStatusBadge.FillColor = Color.FromArgb(220, 252, 231);
            recordStatusBadge.Location = new Point(544, 24);
            recordStatusBadge.Name = "recordStatusBadge";
            recordStatusBadge.ShadowDecoration.CustomizableEdges = statusShadowEdges;
            recordStatusBadge.Size = new Size(156, 28);
            recordStatusBadge.TabIndex = 4;

            lblRecordStatus.BackColor = Color.Transparent;
            lblRecordStatus.Dock = DockStyle.Fill;
            lblRecordStatus.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordStatus.ForeColor = Color.FromArgb(22, 101, 52);
            lblRecordStatus.Location = new Point(0, 0);
            lblRecordStatus.Name = "lblRecordStatus";
            lblRecordStatus.Size = new Size(156, 28);
            lblRecordStatus.TabIndex = 0;
            lblRecordStatus.Text = "● Active License";
            lblRecordStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblRecordStatus.UseMnemonic = false;

            closeControlBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeControlBox.BorderRadius = 8;
            closeControlBox.CustomizableEdges = controlBoxEdges;
            closeControlBox.FillColor = Color.FromArgb(248, 250, 252);
            closeControlBox.HoverState.FillColor = Color.FromArgb(254, 226, 226);
            closeControlBox.HoverState.IconColor = Color.FromArgb(220, 38, 38);
            closeControlBox.IconColor = Color.FromArgb(100, 116, 139);
            closeControlBox.Location = new Point(712, 22);
            closeControlBox.Name = "closeControlBox";
            closeControlBox.ShadowDecoration.CustomizableEdges = controlBoxShadowEdges;
            closeControlBox.Size = new Size(32, 32);
            closeControlBox.TabIndex = 5;

            headerDivider.BackColor = Color.FromArgb(226, 232, 240);
            headerDivider.Dock = DockStyle.Bottom;
            headerDivider.Location = new Point(0, 75);
            headerDivider.Name = "headerDivider";
            headerDivider.Size = new Size(768, 1);
            headerDivider.TabIndex = 6;

            // Body canvas
            bodyPanel.BackColor = Color.FromArgb(243, 247, 249);
            bodyPanel.Controls.Add(cardContainerPanel);
            bodyPanel.Dock = DockStyle.Fill;
            bodyPanel.Location = new Point(0, 76);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Size = new Size(768, 406);
            bodyPanel.TabIndex = 1;

            cardContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cardContainerPanel.BackColor = Color.Transparent;
            cardContainerPanel.Controls.Add(licenseCardControl1);
            cardContainerPanel.CustomizableEdges = containerEdges;
            cardContainerPanel.FillColor = Color.Transparent;
            cardContainerPanel.Location = new Point(24, 13);
            cardContainerPanel.Name = "cardContainerPanel";
            cardContainerPanel.ShadowDecoration.CustomizableEdges = containerShadowEdges;
            cardContainerPanel.Size = new Size(720, 380);
            cardContainerPanel.TabIndex = 0;

            licenseCardControl1.BackColor = Color.Transparent;
            licenseCardControl1.Dock = DockStyle.Fill;
            licenseCardControl1.Location = new Point(0, 0);
            licenseCardControl1.MinimumSize = new Size(680, 360);
            licenseCardControl1.Name = "licenseCardControl1";
            licenseCardControl1.Size = new Size(720, 380);
            licenseCardControl1.TabIndex = 0;

            // Footer bar
            footerPanel.BackColor = Color.White;
            footerPanel.Controls.Add(closeButton);
            footerPanel.Controls.Add(lblFooterHint);
            footerPanel.Controls.Add(footerDivider);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(0, 482);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(768, 54);
            footerPanel.TabIndex = 2;

            footerDivider.BackColor = Color.FromArgb(226, 232, 240);
            footerDivider.Dock = DockStyle.Top;
            footerDivider.Location = new Point(0, 0);
            footerDivider.Name = "footerDivider";
            footerDivider.Size = new Size(768, 1);
            footerDivider.TabIndex = 0;

            lblFooterHint.AutoSize = false;
            lblFooterHint.BackColor = Color.Transparent;
            lblFooterHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFooterHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooterHint.Location = new Point(24, 18);
            lblFooterHint.Name = "lblFooterHint";
            lblFooterHint.Size = new Size(480, 18);
            lblFooterHint.TabIndex = 1;
            lblFooterHint.Text = "Official DVLD credential view  •  Press Esc to close";
            lblFooterHint.UseMnemonic = false;

            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BorderRadius = 8;
            closeButton.Cursor = Cursors.Hand;
            closeButton.CustomizableEdges = closeBtnEdges;
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.FillColor = Color.FromArgb(15, 23, 42);
            closeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            closeButton.ForeColor = Color.White;
            closeButton.HoverState.FillColor = Color.FromArgb(23, 35, 56);
            closeButton.HoverState.ForeColor = Color.White;
            closeButton.Location = new Point(636, 10);
            closeButton.Name = "closeButton";
            closeButton.ShadowDecoration.CustomizableEdges = closeBtnShadowEdges;
            closeButton.Size = new Size(108, 34);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";

            // LicenseCardForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            ClientSize = new Size(768, 536);
            Controls.Add(bodyPanel);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LicenseCardForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Driving License Credential";

            headerPanel.ResumeLayout(false);
            headerIconBadge.ResumeLayout(false);
            recordStatusBadge.ResumeLayout(false);
            bodyPanel.ResumeLayout(false);
            cardContainerPanel.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Elipse formElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm formShadow;
        private Guna.UI2.WinForms.Guna2AnimateWindow formAnimation;
        private Guna.UI2.WinForms.Guna2DragControl formDrag;
        private Panel headerPanel;
        private Panel headerAccentBar;
        private Guna.UI2.WinForms.Guna2Panel headerIconBadge;
        private Label headerIconLabel;
        private Label titleLabel;
        private Label subtitleLabel;
        private Guna.UI2.WinForms.Guna2Panel recordStatusBadge;
        private Label lblRecordStatus;
        private Guna.UI2.WinForms.Guna2ControlBox closeControlBox;
        private Panel headerDivider;
        private Panel bodyPanel;
        private Guna.UI2.WinForms.Guna2Panel cardContainerPanel;
        private LicenseCardControl licenseCardControl1;
        private Panel footerPanel;
        private Panel footerDivider;
        private Label lblFooterHint;
        private Guna.UI2.WinForms.Guna2Button closeButton;
    }
}
