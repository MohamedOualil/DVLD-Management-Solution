namespace DVLD.WinForms.Features.Persons.Detail
{
    partial class PersonDetailControl
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
            photoFrame = new Guna.UI2.WinForms.Guna2Panel();
            pbPhoto = new PictureBox();
            personIdBadgePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblPersonIdCaption = new Label();
            lblPersonId = new Label();
            nationalNoBadgePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblNationalNoCaption = new Label();
            lblNationalNo = new Label();
            lblPrimarySection = new Label();
            lblFullNameCaption = new Label();
            lblFullName = new Label();
            genderBox = new Guna.UI2.WinForms.Guna2Panel();
            lblGenderCaption = new Label();
            GenderIcon = new PictureBox();
            lblGender = new Label();
            dobBox = new Guna.UI2.WinForms.Guna2Panel();
            lblDobCaption = new Label();
            pictureBox4 = new PictureBox();
            lblDateOfBirth = new Label();
            sectionDivider = new Panel();
            lblContactSection = new Label();
            lblPhoneCaption = new Label();
            lblPhone = new Label();
            lblEmailCaption = new Label();
            lblEmail = new Label();
            addressBox = new Guna.UI2.WinForms.Guna2Panel();
            lblAddressCaption = new Label();
            lblAddress = new Label();

            photoFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            personIdBadgePanel.SuspendLayout();
            nationalNoBadgePanel.SuspendLayout();
            genderBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GenderIcon).BeginInit();
            dobBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            addressBox.SuspendLayout();
            SuspendLayout();

            //
            // photoFrame
            //
            photoFrame.BorderColor = Color.FromArgb(226, 232, 240);
            photoFrame.BorderRadius = 10;
            photoFrame.BorderThickness = 1;
            photoFrame.Controls.Add(pbPhoto);
            photoFrame.FillColor = Color.FromArgb(248, 250, 252);
            photoFrame.Location = new Point(8, 10);
            photoFrame.Name = "photoFrame";
            photoFrame.Padding = new Padding(4);
            photoFrame.Size = new Size(112, 134);
            photoFrame.TabIndex = 0;

            //
            // pbPhoto
            //
            pbPhoto.BackColor = Color.Transparent;
            pbPhoto.Dock = DockStyle.Fill;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.Location = new Point(4, 4);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(104, 126);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;

            //
            // personIdBadgePanel
            //
            personIdBadgePanel.BorderColor = Color.FromArgb(226, 232, 240);
            personIdBadgePanel.BorderRadius = 8;
            personIdBadgePanel.BorderThickness = 1;
            personIdBadgePanel.Controls.Add(lblPersonIdCaption);
            personIdBadgePanel.Controls.Add(lblPersonId);
            personIdBadgePanel.FillColor = Color.FromArgb(248, 250, 252);
            personIdBadgePanel.Location = new Point(8, 152);
            personIdBadgePanel.Name = "personIdBadgePanel";
            personIdBadgePanel.Size = new Size(112, 46);
            personIdBadgePanel.TabIndex = 1;

            lblPersonIdCaption.AutoSize = true;
            lblPersonIdCaption.BackColor = Color.Transparent;
            lblPersonIdCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblPersonIdCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblPersonIdCaption.Location = new Point(10, 6);
            lblPersonIdCaption.Name = "lblPersonIdCaption";
            lblPersonIdCaption.Size = new Size(57, 12);
            lblPersonIdCaption.TabIndex = 0;
            lblPersonIdCaption.Text = "PERSON ID";
            lblPersonIdCaption.UseMnemonic = false;

            lblPersonId.AutoEllipsis = true;
            lblPersonId.BackColor = Color.Transparent;
            lblPersonId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblPersonId.ForeColor = Color.FromArgb(15, 23, 42);
            lblPersonId.Location = new Point(10, 21);
            lblPersonId.Name = "lblPersonId";
            lblPersonId.Size = new Size(92, 18);
            lblPersonId.TabIndex = 1;
            lblPersonId.Text = "#1042";
            lblPersonId.UseMnemonic = false;

            //
            // nationalNoBadgePanel
            //
            nationalNoBadgePanel.BorderColor = Color.FromArgb(153, 246, 228);
            nationalNoBadgePanel.BorderRadius = 8;
            nationalNoBadgePanel.BorderThickness = 1;
            nationalNoBadgePanel.Controls.Add(lblNationalNoCaption);
            nationalNoBadgePanel.Controls.Add(lblNationalNo);
            nationalNoBadgePanel.FillColor = Color.FromArgb(240, 253, 250);
            nationalNoBadgePanel.Location = new Point(8, 205);
            nationalNoBadgePanel.Name = "nationalNoBadgePanel";
            nationalNoBadgePanel.Size = new Size(112, 48);
            nationalNoBadgePanel.TabIndex = 2;

            lblNationalNoCaption.AutoSize = true;
            lblNationalNoCaption.BackColor = Color.Transparent;
            lblNationalNoCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblNationalNoCaption.ForeColor = Color.FromArgb(13, 148, 136);
            lblNationalNoCaption.Location = new Point(10, 6);
            lblNationalNoCaption.Name = "lblNationalNoCaption";
            lblNationalNoCaption.Size = new Size(71, 12);
            lblNationalNoCaption.TabIndex = 0;
            lblNationalNoCaption.Text = "NATIONAL NO";
            lblNationalNoCaption.UseMnemonic = false;

            lblNationalNo.AutoEllipsis = true;
            lblNationalNo.BackColor = Color.Transparent;
            lblNationalNo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNationalNo.ForeColor = Color.FromArgb(15, 118, 110);
            lblNationalNo.Location = new Point(10, 22);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Size = new Size(92, 18);
            lblNationalNo.TabIndex = 1;
            lblNationalNo.Text = "9921045231";
            lblNationalNo.UseMnemonic = false;

            //
            // lblPrimarySection
            //
            lblPrimarySection.AutoSize = true;
            lblPrimarySection.BackColor = Color.Transparent;
            lblPrimarySection.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblPrimarySection.ForeColor = Color.FromArgb(13, 148, 136);
            lblPrimarySection.Location = new Point(134, 10);
            lblPrimarySection.Name = "lblPrimarySection";
            lblPrimarySection.Size = new Size(125, 13);
            lblPrimarySection.TabIndex = 3;
            lblPrimarySection.Text = "PRIMARY INFORMATION";
            lblPrimarySection.UseMnemonic = false;

            //
            // lblFullNameCaption
            //
            lblFullNameCaption.AutoSize = true;
            lblFullNameCaption.BackColor = Color.Transparent;
            lblFullNameCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFullNameCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblFullNameCaption.Location = new Point(134, 28);
            lblFullNameCaption.Name = "lblFullNameCaption";
            lblFullNameCaption.Size = new Size(58, 12);
            lblFullNameCaption.TabIndex = 4;
            lblFullNameCaption.Text = "FULL NAME";
            lblFullNameCaption.UseMnemonic = false;

            //
            // lblFullName
            //
            lblFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFullName.AutoEllipsis = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(15, 23, 42);
            lblFullName.Location = new Point(133, 43);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(379, 24);
            lblFullName.TabIndex = 5;
            lblFullName.Text = "Tariq Al-Mansoor";
            lblFullName.UseMnemonic = false;

            //
            // genderBox
            //
            genderBox.BorderColor = Color.FromArgb(226, 232, 240);
            genderBox.BorderRadius = 8;
            genderBox.BorderThickness = 1;
            genderBox.Controls.Add(lblGenderCaption);
            genderBox.Controls.Add(GenderIcon);
            genderBox.Controls.Add(lblGender);
            genderBox.FillColor = Color.FromArgb(248, 250, 252);
            genderBox.Location = new Point(134, 73);
            genderBox.Name = "genderBox";
            genderBox.Size = new Size(182, 48);
            genderBox.TabIndex = 6;

            lblGenderCaption.AutoSize = true;
            lblGenderCaption.BackColor = Color.Transparent;
            lblGenderCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblGenderCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblGenderCaption.Location = new Point(10, 6);
            lblGenderCaption.Name = "lblGenderCaption";
            lblGenderCaption.Size = new Size(44, 12);
            lblGenderCaption.TabIndex = 0;
            lblGenderCaption.Text = "GENDER";
            lblGenderCaption.UseMnemonic = false;

            GenderIcon.BackColor = Color.Transparent;
            GenderIcon.Image = Properties.Resources.MaleIcon;
            GenderIcon.Location = new Point(10, 23);
            GenderIcon.Name = "GenderIcon";
            GenderIcon.Size = new Size(16, 16);
            GenderIcon.SizeMode = PictureBoxSizeMode.Zoom;
            GenderIcon.TabIndex = 1;
            GenderIcon.TabStop = false;

            lblGender.AutoEllipsis = true;
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(15, 23, 42);
            lblGender.Location = new Point(31, 21);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(140, 20);
            lblGender.TabIndex = 2;
            lblGender.Text = "Male";
            lblGender.UseMnemonic = false;

            //
            // dobBox
            //
            dobBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dobBox.BorderColor = Color.FromArgb(226, 232, 240);
            dobBox.BorderRadius = 8;
            dobBox.BorderThickness = 1;
            dobBox.Controls.Add(lblDobCaption);
            dobBox.Controls.Add(pictureBox4);
            dobBox.Controls.Add(lblDateOfBirth);
            dobBox.FillColor = Color.FromArgb(248, 250, 252);
            dobBox.Location = new Point(326, 73);
            dobBox.Name = "dobBox";
            dobBox.Size = new Size(186, 48);
            dobBox.TabIndex = 7;

            lblDobCaption.AutoSize = true;
            lblDobCaption.BackColor = Color.Transparent;
            lblDobCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblDobCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblDobCaption.Location = new Point(10, 6);
            lblDobCaption.Name = "lblDobCaption";
            lblDobCaption.Size = new Size(76, 12);
            lblDobCaption.TabIndex = 0;
            lblDobCaption.Text = "DATE OF BIRTH";
            lblDobCaption.UseMnemonic = false;

            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.icons8_date_16;
            pictureBox4.Location = new Point(10, 23);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(16, 16);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;

            lblDateOfBirth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDateOfBirth.AutoEllipsis = true;
            lblDateOfBirth.BackColor = Color.Transparent;
            lblDateOfBirth.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDateOfBirth.ForeColor = Color.FromArgb(15, 23, 42);
            lblDateOfBirth.Location = new Point(31, 21);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(145, 20);
            lblDateOfBirth.TabIndex = 2;
            lblDateOfBirth.Text = "15/03/1992";
            lblDateOfBirth.UseMnemonic = false;

            //
            // sectionDivider
            //
            sectionDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sectionDivider.BackColor = Color.FromArgb(226, 232, 240);
            sectionDivider.Location = new Point(134, 130);
            sectionDivider.Name = "sectionDivider";
            sectionDivider.Size = new Size(378, 1);
            sectionDivider.TabIndex = 8;

            //
            // lblContactSection
            //
            lblContactSection.AutoSize = true;
            lblContactSection.BackColor = Color.Transparent;
            lblContactSection.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblContactSection.ForeColor = Color.FromArgb(100, 116, 139);
            lblContactSection.Location = new Point(134, 138);
            lblContactSection.Name = "lblContactSection";
            lblContactSection.Size = new Size(121, 13);
            lblContactSection.TabIndex = 9;
            lblContactSection.Text = "CONTACT & RESIDENCE";
            lblContactSection.UseMnemonic = false;

            //
            // lblPhoneCaption & lblPhone
            //
            lblPhoneCaption.AutoSize = true;
            lblPhoneCaption.BackColor = Color.Transparent;
            lblPhoneCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblPhoneCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblPhoneCaption.Location = new Point(134, 157);
            lblPhoneCaption.Name = "lblPhoneCaption";
            lblPhoneCaption.Size = new Size(80, 12);
            lblPhoneCaption.TabIndex = 10;
            lblPhoneCaption.Text = "PHONE NUMBER";
            lblPhoneCaption.UseMnemonic = false;

            lblPhone.AutoEllipsis = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(15, 23, 42);
            lblPhone.Location = new Point(134, 173);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(178, 20);
            lblPhone.TabIndex = 11;
            lblPhone.Text = "+962 79 123 4567";
            lblPhone.UseMnemonic = false;

            //
            // lblEmailCaption & lblEmail
            //
            lblEmailCaption.AutoSize = true;
            lblEmailCaption.BackColor = Color.Transparent;
            lblEmailCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblEmailCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblEmailCaption.Location = new Point(322, 157);
            lblEmailCaption.Name = "lblEmailCaption";
            lblEmailCaption.Size = new Size(81, 12);
            lblEmailCaption.TabIndex = 12;
            lblEmailCaption.Text = "EMAIL ADDRESS";
            lblEmailCaption.UseMnemonic = false;

            lblEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.AutoEllipsis = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(15, 23, 42);
            lblEmail.Location = new Point(322, 173);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(190, 20);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "tariq.mansoor@example.com";
            lblEmail.UseMnemonic = false;

            //
            // addressBox
            //
            addressBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addressBox.BorderColor = Color.FromArgb(226, 232, 240);
            addressBox.BorderRadius = 8;
            addressBox.BorderThickness = 1;
            addressBox.Controls.Add(lblAddressCaption);
            addressBox.Controls.Add(lblAddress);
            addressBox.FillColor = Color.FromArgb(248, 250, 252);
            addressBox.Location = new Point(134, 202);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(378, 51);
            addressBox.TabIndex = 14;

            lblAddressCaption.AutoSize = true;
            lblAddressCaption.BackColor = Color.Transparent;
            lblAddressCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblAddressCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblAddressCaption.Location = new Point(12, 6);
            lblAddressCaption.Name = "lblAddressCaption";
            lblAddressCaption.Size = new Size(111, 12);
            lblAddressCaption.TabIndex = 0;
            lblAddressCaption.Text = "RESIDENTIAL ADDRESS";
            lblAddressCaption.UseMnemonic = false;

            lblAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAddress.AutoEllipsis = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(51, 65, 85);
            lblAddress.Location = new Point(12, 22);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(354, 22);
            lblAddress.TabIndex = 1;
            lblAddress.Text = "42 Al-Rashid St, District 4, Amman, Jordan";
            lblAddress.UseMnemonic = false;

            //
            // PersonDetailControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(photoFrame);
            Controls.Add(personIdBadgePanel);
            Controls.Add(nationalNoBadgePanel);
            Controls.Add(lblPrimarySection);
            Controls.Add(lblFullNameCaption);
            Controls.Add(lblFullName);
            Controls.Add(genderBox);
            Controls.Add(dobBox);
            Controls.Add(sectionDivider);
            Controls.Add(lblContactSection);
            Controls.Add(lblPhoneCaption);
            Controls.Add(lblPhone);
            Controls.Add(lblEmailCaption);
            Controls.Add(lblEmail);
            Controls.Add(addressBox);
            Font = new Font("Segoe UI", 9F);
            Name = "PersonDetailControl";
            Size = new Size(520, 265);

            photoFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            personIdBadgePanel.ResumeLayout(false);
            personIdBadgePanel.PerformLayout();
            nationalNoBadgePanel.ResumeLayout(false);
            nationalNoBadgePanel.PerformLayout();
            genderBox.ResumeLayout(false);
            genderBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GenderIcon).EndInit();
            dobBox.ResumeLayout(false);
            dobBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            addressBox.ResumeLayout(false);
            addressBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel photoFrame;
        private PictureBox pbPhoto;
        private Guna.UI2.WinForms.Guna2Panel personIdBadgePanel;
        private Label lblPersonIdCaption;
        private Label lblPersonId;
        private Guna.UI2.WinForms.Guna2Panel nationalNoBadgePanel;
        private Label lblNationalNoCaption;
        private Label lblNationalNo;
        private Label lblPrimarySection;
        private Label lblFullNameCaption;
        private Label lblFullName;
        private Guna.UI2.WinForms.Guna2Panel genderBox;
        private Label lblGenderCaption;
        private PictureBox GenderIcon;
        private Label lblGender;
        private Guna.UI2.WinForms.Guna2Panel dobBox;
        private Label lblDobCaption;
        private PictureBox pictureBox4;
        private Label lblDateOfBirth;
        private Panel sectionDivider;
        private Label lblContactSection;
        private Label lblPhoneCaption;
        private Label lblPhone;
        private Label lblEmailCaption;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2Panel addressBox;
        private Label lblAddressCaption;
        private Label lblAddress;
    }
}
