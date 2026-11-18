namespace DVLD.WinForms.Shared.Controls
{
    partial class PageHeaderControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            headerCard = new Guna.UI2.WinForms.Guna2Panel();
            iconBadgePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblIconText = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            statusBadge = new Guna.UI2.WinForms.Guna2Button();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            headerCard.SuspendLayout();
            iconBadgePanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerCard
            // 
            headerCard.BackColor = Color.Transparent;
            headerCard.BorderColor = Color.FromArgb(220, 230, 238);
            headerCard.BorderRadius = 12;
            headerCard.BorderThickness = 1;
            headerCard.Controls.Add(iconBadgePanel);
            headerCard.Controls.Add(statusBadge);
            headerCard.Controls.Add(btnBack);
            headerCard.Controls.Add(lblTitle);
            headerCard.Controls.Add(lblSubtitle);
            headerCard.CustomizableEdges = customizableEdges1;
            headerCard.Dock = DockStyle.Fill;
            headerCard.FillColor = Color.White;
            headerCard.Location = new Point(0, 0);
            headerCard.Name = "headerCard";
            headerCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            headerCard.Size = new Size(971, 68);
            headerCard.TabIndex = 0;
            // 
            // iconBadgePanel
            // 
            iconBadgePanel.BackColor = Color.Transparent;
            iconBadgePanel.BorderColor = Color.FromArgb(153, 246, 228);
            iconBadgePanel.BorderRadius = 10;
            iconBadgePanel.BorderThickness = 1;
            iconBadgePanel.Controls.Add(lblIconText);
            iconBadgePanel.CustomizableEdges = customizableEdges3;
            iconBadgePanel.FillColor = Color.FromArgb(240, 253, 250);
            iconBadgePanel.Location = new Point(16, 13);
            iconBadgePanel.Name = "iconBadgePanel";
            iconBadgePanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            iconBadgePanel.Size = new Size(42, 42);
            iconBadgePanel.TabIndex = 0;
            // 
            // lblIconText
            // 
            lblIconText.BackColor = Color.Transparent;
            lblIconText.Dock = DockStyle.Fill;
            lblIconText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIconText.ForeColor = Color.FromArgb(13, 148, 136);
            lblIconText.Location = new Point(0, 0);
            lblIconText.Name = "lblIconText";
            lblIconText.Size = new Size(42, 42);
            lblIconText.TabIndex = 0;
            lblIconText.Text = "DV";
            lblIconText.TextAlign = ContentAlignment.MiddleCenter;
            lblIconText.UseMnemonic = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblTitle.AutoEllipsis = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(70, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(618, 26);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Page Header Title";
            lblTitle.UseMnemonic = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblSubtitle.AutoEllipsis = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 8.75F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(71, 38);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(617, 18);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Manage and review details for this record";
            lblSubtitle.UseMnemonic = false;
            // 
            // statusBadge
            // 
            statusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusBadge.Animated = false;
            statusBadge.BackColor = Color.Transparent;
            statusBadge.BorderColor = Color.FromArgb(153, 246, 228);
            statusBadge.BorderRadius = 15;
            statusBadge.BorderThickness = 1;
            statusBadge.CustomizableEdges = customizableEdges5;
            statusBadge.FillColor = Color.FromArgb(240, 253, 250);
            statusBadge.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            statusBadge.ForeColor = Color.FromArgb(15, 118, 110);
            statusBadge.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            statusBadge.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            statusBadge.HoverState.ForeColor = Color.FromArgb(15, 118, 110);
            statusBadge.Location = new Point(700, 19);
            statusBadge.Name = "statusBadge";
            statusBadge.PressedColor = Color.FromArgb(240, 253, 250);
            statusBadge.ShadowDecoration.CustomizableEdges = customizableEdges6;
            statusBadge.Size = new Size(142, 30);
            statusBadge.TabIndex = 3;
            statusBadge.TabStop = false;
            statusBadge.Text = "● Active Record";
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.BackColor = Color.Transparent;
            btnBack.BorderColor = Color.FromArgb(203, 213, 225);
            btnBack.BorderRadius = 8;
            btnBack.BorderThickness = 1;
            btnBack.Cursor = Cursors.Hand;
            btnBack.CustomizableEdges = customizableEdges7;
            btnBack.FillColor = Color.FromArgb(248, 250, 252);
            btnBack.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(51, 65, 85);
            btnBack.HoverState.BorderColor = Color.FromArgb(148, 163, 184);
            btnBack.HoverState.FillColor = Color.FromArgb(241, 245, 249);
            btnBack.Location = new Point(852, 17);
            btnBack.Name = "btnBack";
            btnBack.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnBack.Size = new Size(103, 34);
            btnBack.TabIndex = 4;
            btnBack.Text = "← Back";
            // 
            // PageHeaderControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(headerCard);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(560, 68);
            Name = "PageHeaderControl";
            Size = new Size(971, 68);
            headerCard.ResumeLayout(false);
            iconBadgePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel headerCard;
        private Guna.UI2.WinForms.Guna2Panel iconBadgePanel;
        private Label lblIconText;
        private Label lblTitle;
        private Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2Button statusBadge;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}
