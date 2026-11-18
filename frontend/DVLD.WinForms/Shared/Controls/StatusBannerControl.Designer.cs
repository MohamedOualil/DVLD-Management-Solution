namespace DVLD.WinForms.Shared.Controls
{
    partial class StatusBannerControl
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
            bannerCard = new Guna.UI2.WinForms.Guna2Panel();
            iconBadge = new Guna.UI2.WinForms.Guna2Panel();
            lblIcon = new Label();
            lblTitle = new Label();
            lblDescription = new Label();
            bannerCard.SuspendLayout();
            iconBadge.SuspendLayout();
            SuspendLayout();
            // 
            // bannerCard
            // 
            bannerCard.BackColor = Color.Transparent;
            bannerCard.BorderColor = Color.FromArgb(153, 246, 228);
            bannerCard.BorderRadius = 10;
            bannerCard.BorderThickness = 1;
            bannerCard.Controls.Add(iconBadge);
            bannerCard.Controls.Add(lblTitle);
            bannerCard.Controls.Add(lblDescription);
            bannerCard.CustomizableEdges = customizableEdges1;
            bannerCard.Dock = DockStyle.Fill;
            bannerCard.FillColor = Color.FromArgb(240, 253, 250);
            bannerCard.Location = new Point(0, 0);
            bannerCard.Name = "bannerCard";
            bannerCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            bannerCard.Size = new Size(971, 60);
            bannerCard.TabIndex = 0;
            // 
            // iconBadge
            // 
            iconBadge.BackColor = Color.Transparent;
            iconBadge.BorderRadius = 8;
            iconBadge.Controls.Add(lblIcon);
            iconBadge.CustomizableEdges = customizableEdges3;
            iconBadge.FillColor = Color.FromArgb(204, 251, 241);
            iconBadge.Location = new Point(14, 12);
            iconBadge.Name = "iconBadge";
            iconBadge.ShadowDecoration.CustomizableEdges = customizableEdges4;
            iconBadge.Size = new Size(36, 36);
            iconBadge.TabIndex = 0;
            // 
            // lblIcon
            // 
            lblIcon.BackColor = Color.Transparent;
            lblIcon.Dock = DockStyle.Fill;
            lblIcon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIcon.ForeColor = Color.FromArgb(15, 118, 110);
            lblIcon.Location = new Point(0, 0);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(36, 36);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "i";
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.UseMnemonic = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoEllipsis = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 118, 110);
            lblTitle.Location = new Point(62, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(893, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Status Notice";
            lblTitle.UseMnemonic = false;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoEllipsis = true;
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Segoe UI", 8.5F);
            lblDescription.ForeColor = Color.FromArgb(51, 65, 85);
            lblDescription.Location = new Point(62, 31);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(893, 18);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Information and eligibility details appear here.";
            lblDescription.UseMnemonic = false;
            // 
            // StatusBannerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(bannerCard);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(420, 60);
            Name = "StatusBannerControl";
            Size = new Size(971, 60);
            bannerCard.ResumeLayout(false);
            iconBadge.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel bannerCard;
        private Guna.UI2.WinForms.Guna2Panel iconBadge;
        private Label lblIcon;
        private Label lblTitle;
        private Label lblDescription;
    }
}
