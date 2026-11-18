namespace DVLD.WinForms.Shared.Controls
{
    partial class ApplicantBannerControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            bannerCard = new Guna.UI2.WinForms.Guna2Panel();
            photoFrame = new Guna.UI2.WinForms.Guna2Panel();
            pbPhoto = new PictureBox();
            lblApplicantCaption = new Label();
            lblFullName = new Label();
            nationalNoBadge = new Guna.UI2.WinForms.Guna2Panel();
            lblNationalNo = new Label();
            lblDobAndAge = new Label();
            identityDivider = new Panel();
            localAppBox = new Guna.UI2.WinForms.Guna2Panel();
            lblLocalAppCaption = new Label();
            lblLocalAppId = new Label();
            licenseClassBox = new Guna.UI2.WinForms.Guna2Panel();
            lblLicenseClassCaption = new Label();
            lblLicenseClass = new Label();
            btnViewPersonCard = new Guna.UI2.WinForms.Guna2Button();
            bannerCard.SuspendLayout();
            photoFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            nationalNoBadge.SuspendLayout();
            localAppBox.SuspendLayout();
            licenseClassBox.SuspendLayout();
            SuspendLayout();
            // 
            // bannerCard
            // 
            bannerCard.BackColor = Color.Transparent;
            bannerCard.BorderColor = Color.FromArgb(220, 230, 238);
            bannerCard.BorderRadius = 12;
            bannerCard.BorderThickness = 1;
            bannerCard.Controls.Add(photoFrame);
            bannerCard.Controls.Add(lblApplicantCaption);
            bannerCard.Controls.Add(lblFullName);
            bannerCard.Controls.Add(nationalNoBadge);
            bannerCard.Controls.Add(lblDobAndAge);
            bannerCard.Controls.Add(identityDivider);
            bannerCard.Controls.Add(localAppBox);
            bannerCard.Controls.Add(licenseClassBox);
            bannerCard.Controls.Add(btnViewPersonCard);
            bannerCard.CustomizableEdges = customizableEdges1;
            bannerCard.Dock = DockStyle.Fill;
            bannerCard.FillColor = Color.White;
            bannerCard.Location = new Point(0, 0);
            bannerCard.Name = "bannerCard";
            bannerCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            bannerCard.Size = new Size(971, 96);
            bannerCard.TabIndex = 0;
            // 
            // photoFrame
            // 
            photoFrame.BackColor = Color.Transparent;
            photoFrame.BorderColor = Color.FromArgb(226, 232, 240);
            photoFrame.BorderRadius = 10;
            photoFrame.BorderThickness = 1;
            photoFrame.Controls.Add(pbPhoto);
            photoFrame.CustomizableEdges = customizableEdges3;
            photoFrame.FillColor = Color.FromArgb(248, 250, 252);
            photoFrame.Location = new Point(14, 12);
            photoFrame.Name = "photoFrame";
            photoFrame.Padding = new Padding(3);
            photoFrame.ShadowDecoration.CustomizableEdges = customizableEdges4;
            photoFrame.Size = new Size(68, 72);
            photoFrame.TabIndex = 0;
            // 
            // pbPhoto
            // 
            pbPhoto.BackColor = Color.Transparent;
            pbPhoto.Dock = DockStyle.Fill;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.Location = new Point(3, 3);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(62, 66);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;
            // 
            // lblApplicantCaption
            // 
            lblApplicantCaption.AutoSize = true;
            lblApplicantCaption.BackColor = Color.Transparent;
            lblApplicantCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblApplicantCaption.ForeColor = Color.FromArgb(13, 148, 136);
            lblApplicantCaption.Location = new Point(96, 12);
            lblApplicantCaption.Name = "lblApplicantCaption";
            lblApplicantCaption.Size = new Size(109, 12);
            lblApplicantCaption.TabIndex = 1;
            lblApplicantCaption.Text = "APPLICANT IDENTITY";
            lblApplicantCaption.UseMnemonic = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoEllipsis = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(15, 23, 42);
            lblFullName.Location = new Point(95, 27);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(265, 24);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Tariq Al-Mansoor";
            lblFullName.UseMnemonic = false;
            // 
            // nationalNoBadge
            // 
            nationalNoBadge.BackColor = Color.Transparent;
            nationalNoBadge.BorderColor = Color.FromArgb(153, 246, 228);
            nationalNoBadge.BorderRadius = 6;
            nationalNoBadge.BorderThickness = 1;
            nationalNoBadge.Controls.Add(lblNationalNo);
            nationalNoBadge.CustomizableEdges = customizableEdges5;
            nationalNoBadge.FillColor = Color.FromArgb(240, 253, 250);
            nationalNoBadge.Location = new Point(96, 56);
            nationalNoBadge.Name = "nationalNoBadge";
            nationalNoBadge.ShadowDecoration.CustomizableEdges = customizableEdges6;
            nationalNoBadge.Size = new Size(124, 24);
            nationalNoBadge.TabIndex = 3;
            // 
            // lblNationalNo
            // 
            lblNationalNo.BackColor = Color.Transparent;
            lblNationalNo.Dock = DockStyle.Fill;
            lblNationalNo.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblNationalNo.ForeColor = Color.FromArgb(15, 118, 110);
            lblNationalNo.Location = new Point(0, 0);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Size = new Size(124, 24);
            lblNationalNo.TabIndex = 0;
            lblNationalNo.Text = "ID: 9921045231";
            lblNationalNo.TextAlign = ContentAlignment.MiddleCenter;
            lblNationalNo.UseMnemonic = false;
            // 
            // lblDobAndAge
            // 
            lblDobAndAge.AutoEllipsis = true;
            lblDobAndAge.BackColor = Color.Transparent;
            lblDobAndAge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblDobAndAge.ForeColor = Color.FromArgb(100, 116, 139);
            lblDobAndAge.Location = new Point(228, 59);
            lblDobAndAge.Name = "lblDobAndAge";
            lblDobAndAge.Size = new Size(136, 18);
            lblDobAndAge.TabIndex = 4;
            lblDobAndAge.Text = "15 Mar 1992 • 34 yrs";
            lblDobAndAge.UseMnemonic = false;
            // 
            // identityDivider
            // 
            identityDivider.BackColor = Color.FromArgb(226, 232, 240);
            identityDivider.Location = new Point(372, 16);
            identityDivider.Name = "identityDivider";
            identityDivider.Size = new Size(1, 64);
            identityDivider.TabIndex = 5;
            // 
            // localAppBox
            // 
            localAppBox.BackColor = Color.Transparent;
            localAppBox.BorderColor = Color.FromArgb(226, 232, 240);
            localAppBox.BorderRadius = 8;
            localAppBox.BorderThickness = 1;
            localAppBox.Controls.Add(lblLocalAppCaption);
            localAppBox.Controls.Add(lblLocalAppId);
            localAppBox.CustomizableEdges = customizableEdges7;
            localAppBox.FillColor = Color.FromArgb(248, 250, 252);
            localAppBox.Location = new Point(388, 16);
            localAppBox.Name = "localAppBox";
            localAppBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            localAppBox.Size = new Size(126, 64);
            localAppBox.TabIndex = 6;
            // 
            // lblLocalAppCaption
            // 
            lblLocalAppCaption.AutoSize = true;
            lblLocalAppCaption.BackColor = Color.Transparent;
            lblLocalAppCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblLocalAppCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblLocalAppCaption.Location = new Point(12, 10);
            lblLocalAppCaption.Name = "lblLocalAppCaption";
            lblLocalAppCaption.Size = new Size(73, 12);
            lblLocalAppCaption.TabIndex = 0;
            lblLocalAppCaption.Text = "LOCAL APP ID";
            lblLocalAppCaption.UseMnemonic = false;
            // 
            // lblLocalAppId
            // 
            lblLocalAppId.AutoEllipsis = true;
            lblLocalAppId.BackColor = Color.Transparent;
            lblLocalAppId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLocalAppId.ForeColor = Color.FromArgb(15, 23, 42);
            lblLocalAppId.Location = new Point(12, 29);
            lblLocalAppId.Name = "lblLocalAppId";
            lblLocalAppId.Size = new Size(102, 22);
            lblLocalAppId.TabIndex = 1;
            lblLocalAppId.Text = "#1042";
            lblLocalAppId.UseMnemonic = false;
            // 
            // licenseClassBox
            // 
            licenseClassBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            licenseClassBox.BackColor = Color.Transparent;
            licenseClassBox.BorderColor = Color.FromArgb(226, 232, 240);
            licenseClassBox.BorderRadius = 8;
            licenseClassBox.BorderThickness = 1;
            licenseClassBox.Controls.Add(lblLicenseClassCaption);
            licenseClassBox.Controls.Add(lblLicenseClass);
            licenseClassBox.CustomizableEdges = customizableEdges9;
            licenseClassBox.FillColor = Color.FromArgb(248, 250, 252);
            licenseClassBox.Location = new Point(524, 16);
            licenseClassBox.Name = "licenseClassBox";
            licenseClassBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            licenseClassBox.Size = new Size(280, 64);
            licenseClassBox.TabIndex = 7;
            // 
            // lblLicenseClassCaption
            // 
            lblLicenseClassCaption.AutoSize = true;
            lblLicenseClassCaption.BackColor = Color.Transparent;
            lblLicenseClassCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblLicenseClassCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblLicenseClassCaption.Location = new Point(12, 10);
            lblLicenseClassCaption.Name = "lblLicenseClassCaption";
            lblLicenseClassCaption.Size = new Size(122, 12);
            lblLicenseClassCaption.TabIndex = 0;
            lblLicenseClassCaption.Text = "APPLIED LICENSE CLASS";
            lblLicenseClassCaption.UseMnemonic = false;
            // 
            // lblLicenseClass
            // 
            lblLicenseClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLicenseClass.AutoEllipsis = true;
            lblLicenseClass.BackColor = Color.Transparent;
            lblLicenseClass.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblLicenseClass.ForeColor = Color.FromArgb(15, 23, 42);
            lblLicenseClass.Location = new Point(12, 30);
            lblLicenseClass.Name = "lblLicenseClass";
            lblLicenseClass.Size = new Size(256, 22);
            lblLicenseClass.TabIndex = 1;
            lblLicenseClass.Text = "Class 3 - Ordinary Driving License";
            lblLicenseClass.UseMnemonic = false;
            // 
            // btnViewPersonCard
            // 
            btnViewPersonCard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewPersonCard.BackColor = Color.Transparent;
            btnViewPersonCard.BorderColor = Color.FromArgb(153, 246, 228);
            btnViewPersonCard.BorderRadius = 8;
            btnViewPersonCard.BorderThickness = 1;
            btnViewPersonCard.Cursor = Cursors.Hand;
            btnViewPersonCard.CustomizableEdges = customizableEdges11;
            btnViewPersonCard.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            btnViewPersonCard.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            btnViewPersonCard.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            btnViewPersonCard.FillColor = Color.FromArgb(240, 253, 250);
            btnViewPersonCard.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            btnViewPersonCard.ForeColor = Color.FromArgb(13, 148, 136);
            btnViewPersonCard.HoverState.BorderColor = Color.FromArgb(13, 148, 136);
            btnViewPersonCard.HoverState.FillColor = Color.FromArgb(13, 148, 136);
            btnViewPersonCard.HoverState.ForeColor = Color.White;
            btnViewPersonCard.Location = new Point(818, 29);
            btnViewPersonCard.Name = "btnViewPersonCard";
            btnViewPersonCard.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnViewPersonCard.Size = new Size(138, 38);
            btnViewPersonCard.TabIndex = 8;
            btnViewPersonCard.Text = "View Person ↗";
            // 
            // ApplicantBannerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(bannerCard);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(760, 96);
            Name = "ApplicantBannerControl";
            Size = new Size(971, 96);
            bannerCard.ResumeLayout(false);
            bannerCard.PerformLayout();
            photoFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            nationalNoBadge.ResumeLayout(false);
            localAppBox.ResumeLayout(false);
            localAppBox.PerformLayout();
            licenseClassBox.ResumeLayout(false);
            licenseClassBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel bannerCard;
        private Guna.UI2.WinForms.Guna2Panel photoFrame;
        private PictureBox pbPhoto;
        private Label lblApplicantCaption;
        private Label lblFullName;
        private Guna.UI2.WinForms.Guna2Panel nationalNoBadge;
        private Label lblNationalNo;
        private Label lblDobAndAge;
        private Panel identityDivider;
        private Guna.UI2.WinForms.Guna2Panel localAppBox;
        private Label lblLocalAppCaption;
        private Label lblLocalAppId;
        private Guna.UI2.WinForms.Guna2Panel licenseClassBox;
        private Label lblLicenseClassCaption;
        private Label lblLicenseClass;
        private Guna.UI2.WinForms.Guna2Button btnViewPersonCard;
    }
}
