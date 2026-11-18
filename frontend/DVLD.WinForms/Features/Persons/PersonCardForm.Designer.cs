namespace DVLD.WinForms.Features.Persons
{
    partial class PersonCardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            formShadow = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            formAnimation = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            formDrag = new Guna.UI2.WinForms.Guna2DragControl(components);
            headerPanel = new Panel();
            headerAccentBar = new Panel();
            headerIconBadge = new Guna.UI2.WinForms.Guna2Panel();
            lblHeaderIcon = new Label();
            titleLabel = new Label();
            subtitleLabel = new Label();
            recordStatusBadge = new Guna.UI2.WinForms.Guna2Button();
            closeControlBox = new Guna.UI2.WinForms.Guna2ControlBox();
            headerDivider = new Panel();
            cardContainerPanel = new Guna.UI2.WinForms.Guna2Panel();
            personDetailControl1 = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();
            footerPanel = new Panel();
            footerDivider = new Panel();
            lblFooterHint = new Label();
            closeButton = new Guna.UI2.WinForms.Guna2Button();
            headerPanel.SuspendLayout();
            headerIconBadge.SuspendLayout();
            cardContainerPanel.SuspendLayout();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // formElipse
            // 
            formElipse.BorderRadius = 14;
            formElipse.TargetControl = this;
            // 
            // formShadow
            // 
            formShadow.TargetForm = this;
            // 
            // formAnimation
            // 
            formAnimation.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            formAnimation.Interval = 180;
            formAnimation.TargetForm = this;
            // 
            // formDrag
            // 
            formDrag.DockIndicatorTransparencyValue = 0.6D;
            formDrag.TargetControl = headerPanel;
            formDrag.UseTransparentDrag = true;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(headerAccentBar);
            headerPanel.Controls.Add(headerIconBadge);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(recordStatusBadge);
            headerPanel.Controls.Add(closeControlBox);
            headerPanel.Controls.Add(headerDivider);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(576, 78);
            headerPanel.TabIndex = 0;
            // 
            // headerAccentBar
            // 
            headerAccentBar.BackColor = Color.FromArgb(13, 148, 136);
            headerAccentBar.Dock = DockStyle.Top;
            headerAccentBar.Location = new Point(0, 0);
            headerAccentBar.Name = "headerAccentBar";
            headerAccentBar.Size = new Size(576, 4);
            headerAccentBar.TabIndex = 0;
            // 
            // headerIconBadge
            // 
            headerIconBadge.BackColor = Color.Transparent;
            headerIconBadge.BorderColor = Color.FromArgb(153, 246, 228);
            headerIconBadge.BorderRadius = 10;
            headerIconBadge.BorderThickness = 1;
            headerIconBadge.Controls.Add(lblHeaderIcon);
            headerIconBadge.CustomizableEdges = customizableEdges1;
            headerIconBadge.FillColor = Color.FromArgb(240, 253, 250);
            headerIconBadge.Location = new Point(20, 19);
            headerIconBadge.Name = "headerIconBadge";
            headerIconBadge.ShadowDecoration.CustomizableEdges = customizableEdges2;
            headerIconBadge.Size = new Size(42, 42);
            headerIconBadge.TabIndex = 1;
            // 
            // lblHeaderIcon
            // 
            lblHeaderIcon.BackColor = Color.Transparent;
            lblHeaderIcon.Dock = DockStyle.Fill;
            lblHeaderIcon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderIcon.ForeColor = Color.FromArgb(13, 148, 136);
            lblHeaderIcon.Location = new Point(0, 0);
            lblHeaderIcon.Name = "lblHeaderIcon";
            lblHeaderIcon.Size = new Size(42, 42);
            lblHeaderIcon.TabIndex = 0;
            lblHeaderIcon.Text = "ID";
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblHeaderIcon.UseMnemonic = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(15, 23, 42);
            titleLabel.Location = new Point(74, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(176, 25);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Person Profile Card";
            titleLabel.UseMnemonic = false;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.BackColor = Color.Transparent;
            subtitleLabel.Font = new Font("Segoe UI", 8.75F);
            subtitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            subtitleLabel.Location = new Point(75, 43);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(243, 15);
            subtitleLabel.TabIndex = 3;
            subtitleLabel.Text = "Official citizen identity & contact information";
            subtitleLabel.UseMnemonic = false;
            // 
            // recordStatusBadge
            // 
            recordStatusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            recordStatusBadge.Animated = false;
            recordStatusBadge.BackColor = Color.Transparent;
            recordStatusBadge.BorderColor = Color.FromArgb(187, 247, 208);
            recordStatusBadge.BorderRadius = 14;
            recordStatusBadge.BorderThickness = 1;
            recordStatusBadge.CustomizableEdges = customizableEdges3;
            recordStatusBadge.FillColor = Color.FromArgb(220, 252, 231);
            recordStatusBadge.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            recordStatusBadge.ForeColor = Color.FromArgb(22, 101, 52);
            recordStatusBadge.HoverState.BorderColor = Color.FromArgb(187, 247, 208);
            recordStatusBadge.HoverState.FillColor = Color.FromArgb(220, 252, 231);
            recordStatusBadge.HoverState.ForeColor = Color.FromArgb(22, 101, 52);
            recordStatusBadge.Location = new Point(386, 25);
            recordStatusBadge.Name = "recordStatusBadge";
            recordStatusBadge.PressedColor = Color.FromArgb(220, 252, 231);
            recordStatusBadge.ShadowDecoration.CustomizableEdges = customizableEdges4;
            recordStatusBadge.Size = new Size(130, 28);
            recordStatusBadge.TabIndex = 4;
            recordStatusBadge.TabStop = false;
            recordStatusBadge.Text = "● Verified Profile";
            // 
            // closeControlBox
            // 
            closeControlBox.AccessibleName = "Close";
            closeControlBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeControlBox.BorderRadius = 8;
            closeControlBox.CustomizableEdges = customizableEdges5;
            closeControlBox.FillColor = Color.FromArgb(248, 250, 252);
            closeControlBox.HoverState.FillColor = Color.FromArgb(254, 226, 226);
            closeControlBox.HoverState.IconColor = Color.FromArgb(220, 38, 38);
            closeControlBox.IconColor = Color.FromArgb(100, 116, 139);
            closeControlBox.Location = new Point(526, 23);
            closeControlBox.Name = "closeControlBox";
            closeControlBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            closeControlBox.Size = new Size(32, 32);
            closeControlBox.TabIndex = 5;
            // 
            // headerDivider
            // 
            headerDivider.BackColor = Color.FromArgb(226, 232, 240);
            headerDivider.Dock = DockStyle.Bottom;
            headerDivider.Location = new Point(0, 77);
            headerDivider.Name = "headerDivider";
            headerDivider.Size = new Size(576, 1);
            headerDivider.TabIndex = 6;
            // 
            // cardContainerPanel
            // 
            cardContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cardContainerPanel.BackColor = Color.Transparent;
            cardContainerPanel.BorderColor = Color.FromArgb(220, 230, 238);
            cardContainerPanel.BorderRadius = 12;
            cardContainerPanel.BorderThickness = 1;
            cardContainerPanel.Controls.Add(personDetailControl1);
            cardContainerPanel.CustomizableEdges = customizableEdges7;
            cardContainerPanel.FillColor = Color.White;
            cardContainerPanel.Location = new Point(20, 94);
            cardContainerPanel.Name = "cardContainerPanel";
            cardContainerPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cardContainerPanel.Size = new Size(536, 284);
            cardContainerPanel.TabIndex = 1;
            // 
            // personDetailControl1
            // 
            personDetailControl1.BackColor = Color.White;
            personDetailControl1.Font = new Font("Segoe UI", 9F);
            personDetailControl1.Location = new Point(8, 9);
            personDetailControl1.Name = "personDetailControl1";
            personDetailControl1.Size = new Size(520, 265);
            personDetailControl1.TabIndex = 0;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.White;
            footerPanel.Controls.Add(footerDivider);
            footerPanel.Controls.Add(lblFooterHint);
            footerPanel.Controls.Add(closeButton);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(0, 394);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(576, 58);
            footerPanel.TabIndex = 2;
            // 
            // footerDivider
            // 
            footerDivider.BackColor = Color.FromArgb(226, 232, 240);
            footerDivider.Dock = DockStyle.Top;
            footerDivider.Location = new Point(0, 0);
            footerDivider.Name = "footerDivider";
            footerDivider.Size = new Size(576, 1);
            footerDivider.TabIndex = 0;
            // 
            // lblFooterHint
            // 
            lblFooterHint.AutoSize = true;
            lblFooterHint.BackColor = Color.Transparent;
            lblFooterHint.Font = new Font("Segoe UI", 8.5F);
            lblFooterHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooterHint.Location = new Point(20, 20);
            lblFooterHint.Name = "lblFooterHint";
            lblFooterHint.Size = new Size(258, 15);
            lblFooterHint.TabIndex = 1;
            lblFooterHint.Text = "Read-only profile snapshot • Press Esc to close";
            lblFooterHint.UseMnemonic = false;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.BorderColor = Color.FromArgb(13, 148, 136);
            closeButton.BorderRadius = 8;
            closeButton.BorderThickness = 1;
            closeButton.Cursor = Cursors.Hand;
            closeButton.CustomizableEdges = customizableEdges9;
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.FillColor = Color.FromArgb(13, 148, 136);
            closeButton.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            closeButton.ForeColor = Color.White;
            closeButton.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            closeButton.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            closeButton.Location = new Point(440, 11);
            closeButton.Name = "closeButton";
            closeButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            closeButton.Size = new Size(116, 36);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            // 
            // PersonCardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            CancelButton = closeButton;
            ClientSize = new Size(576, 452);
            Controls.Add(cardContainerPanel);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonCardForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Person Profile Card";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            headerIconBadge.ResumeLayout(false);
            cardContainerPanel.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse formElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm formShadow;
        private Guna.UI2.WinForms.Guna2AnimateWindow formAnimation;
        private Guna.UI2.WinForms.Guna2DragControl formDrag;
        private Panel headerPanel;
        private Panel headerAccentBar;
        private Guna.UI2.WinForms.Guna2Panel headerIconBadge;
        private Label lblHeaderIcon;
        private Label titleLabel;
        private Label subtitleLabel;
        private Guna.UI2.WinForms.Guna2Button recordStatusBadge;
        private Guna.UI2.WinForms.Guna2ControlBox closeControlBox;
        private Panel headerDivider;
        private Guna.UI2.WinForms.Guna2Panel cardContainerPanel;
        private Detail.PersonDetailControl personDetailControl1;
        private Panel footerPanel;
        private Panel footerDivider;
        private Label lblFooterHint;
        private Guna.UI2.WinForms.Guna2Button closeButton;
    }
}
