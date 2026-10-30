namespace DVLD.WinForms.Features.Applications.ApplicationInfo
{
    partial class ApplicationInfoControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            categoryPanel = new Guna.UI2.WinForms.Guna2Panel();
            categoryHeading = new Label();
            categoryHint = new Label();
            gbContainer = new Guna.UI2.WinForms.Guna2GroupBox();
            guna2RadioButton1 = new Guna.UI2.WinForms.Guna2RadioButton();
            guna2RadioButton2 = new Guna.UI2.WinForms.Guna2RadioButton();
            guna2RadioButton3 = new Guna.UI2.WinForms.Guna2RadioButton();
            guna2RadioButton4 = new Guna.UI2.WinForms.Guna2RadioButton();
            guna2RadioButton5 = new Guna.UI2.WinForms.Guna2RadioButton();
            categoryFooter = new Label();
            summaryPanel = new Guna.UI2.WinForms.Guna2Panel();
            summaryHeading = new Label();
            photoFrame = new Guna.UI2.WinForms.Guna2Panel();
            pbPhoto = new PictureBox();
            lblFullName = new Label();
            NationalNoButton = new Guna.UI2.WinForms.Guna2Button();
            summaryDivider = new Panel();
            birthCaption = new Label();
            lblDateOfBirth = new Label();
            ageCaption = new Label();
            lblAge = new Label();
            applicationIdCaption = new Label();
            lblApplicationID = new Label();
            applicationDateCaption = new Label();
            lblApplicationDate = new Label();
            createdByCaption = new Label();
            lblCreateby = new Label();
            feeCaption = new Label();
            lblFees = new Label();
            SuspendLayout();
            Size = new Size(1003, 447);
            Size = new Size(1003, 447);
            // categoryPanel
            categoryPanel.Location = new Point(0, 0);
            categoryPanel.Size = new Size(641, 447);
            categoryPanel.FillColor = Color.White;
            categoryPanel.BorderColor = Color.FromArgb(219, 229, 242);
            categoryPanel.BorderThickness = 1;
            categoryPanel.BorderRadius = 8;
            categoryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Controls.Add(categoryHeading);
            // categoryHeading
            categoryHeading.Text = "Select licence class";
            categoryHeading.Location = new Point(16, 12);
            categoryHeading.Size = new Size(400, 26);
            categoryHeading.BackColor = Color.Transparent;
            categoryHeading.ForeColor = Color.FromArgb(15, 23, 42);
            categoryHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            categoryHeading.Name = "categoryHeading";
            categoryPanel.Controls.Add(categoryHint);
            // categoryHint
            categoryHint.Text = "Choose one category for this application.";
            categoryHint.Location = new Point(16, 40);
            categoryHint.Size = new Size(600, 20);
            categoryHint.BackColor = Color.Transparent;
            categoryHint.ForeColor = Color.FromArgb(100, 116, 139);
            categoryHint.Name = "categoryHint";
            categoryPanel.Controls.Add(gbContainer);
            // gbContainer
            gbContainer.Location = new Point(16, 70);
            gbContainer.Size = new Size(609, 332);
            gbContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbContainer.Text = "";
            gbContainer.CustomBorderThickness = new Padding(0);
            gbContainer.BorderThickness = 0;
            gbContainer.FillColor = Color.White;
            gbContainer.Font = new Font("Segoe UI", 9F);
            gbContainer.Name = "gbContainer";
            gbContainer.Controls.Add(guna2RadioButton1);
            // guna2RadioButton1
            guna2RadioButton1.Text = "      Class 1 · Small Motorcycle";
            guna2RadioButton1.Tag = "1";
            guna2RadioButton1.AutoSize = false;
            guna2RadioButton1.Padding = new Padding(16, 0, 12, 0);
            guna2RadioButton1.TextAlign = ContentAlignment.MiddleLeft;
            guna2RadioButton1.Appearance = Appearance.Button;
            guna2RadioButton1.FlatStyle = FlatStyle.Flat;
            guna2RadioButton1.FlatAppearance.BorderColor = Color.FromArgb(219, 229, 242);
            guna2RadioButton1.FlatAppearance.BorderSize = 1;
            guna2RadioButton1.FlatAppearance.CheckedBackColor = Color.FromArgb(226, 239, 255);
            guna2RadioButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
            guna2RadioButton1.Location = new Point(0, 0);
            guna2RadioButton1.Size = new Size(609, 56);
            guna2RadioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2RadioButton1.BackColor = Color.FromArgb(250, 252, 255);
            guna2RadioButton1.ForeColor = Color.FromArgb(15, 23, 42);
            guna2RadioButton1.Font = new Font("Segoe UI", 11F);
            guna2RadioButton1.CheckedState.BorderColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton1.CheckedState.BorderThickness = 1;
            guna2RadioButton1.CheckedState.FillColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton1.CheckedState.InnerColor = Color.White;
            guna2RadioButton1.UncheckedState.BorderColor = Color.FromArgb(148, 163, 184);
            guna2RadioButton1.UncheckedState.BorderThickness = 2;
            guna2RadioButton1.UncheckedState.FillColor = Color.White;
            guna2RadioButton1.UncheckedState.InnerColor = Color.White;
            guna2RadioButton1.TabIndex = 0;
            guna2RadioButton1.Name = "guna2RadioButton1";
            guna2RadioButton1.CheckedChanged += LicenseRadioButton_CheckedChanged;
            guna2RadioButton1.BringToFront();
            gbContainer.Controls.Add(guna2RadioButton2);
            // guna2RadioButton2
            guna2RadioButton2.Text = "      Class 2 · Large Motorcycle";
            guna2RadioButton2.Tag = "2";
            guna2RadioButton2.AutoSize = false;
            guna2RadioButton2.Padding = new Padding(16, 0, 12, 0);
            guna2RadioButton2.TextAlign = ContentAlignment.MiddleLeft;
            guna2RadioButton2.Appearance = Appearance.Button;
            guna2RadioButton2.FlatStyle = FlatStyle.Flat;
            guna2RadioButton2.FlatAppearance.BorderColor = Color.FromArgb(219, 229, 242);
            guna2RadioButton2.FlatAppearance.BorderSize = 1;
            guna2RadioButton2.FlatAppearance.CheckedBackColor = Color.FromArgb(226, 239, 255);
            guna2RadioButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
            guna2RadioButton2.Location = new Point(0, 66);
            guna2RadioButton2.Size = new Size(609, 56);
            guna2RadioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2RadioButton2.BackColor = Color.FromArgb(250, 252, 255);
            guna2RadioButton2.ForeColor = Color.FromArgb(15, 23, 42);
            guna2RadioButton2.Font = new Font("Segoe UI", 11F);
            guna2RadioButton2.CheckedState.BorderColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton2.CheckedState.BorderThickness = 1;
            guna2RadioButton2.CheckedState.FillColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton2.CheckedState.InnerColor = Color.White;
            guna2RadioButton2.UncheckedState.BorderColor = Color.FromArgb(148, 163, 184);
            guna2RadioButton2.UncheckedState.BorderThickness = 2;
            guna2RadioButton2.UncheckedState.FillColor = Color.White;
            guna2RadioButton2.UncheckedState.InnerColor = Color.White;
            guna2RadioButton2.TabIndex = 1;
            guna2RadioButton2.Name = "guna2RadioButton2";
            guna2RadioButton2.CheckedChanged += LicenseRadioButton_CheckedChanged;
            guna2RadioButton2.BringToFront();
            gbContainer.Controls.Add(guna2RadioButton3);
            // guna2RadioButton3
            guna2RadioButton3.Text = "      Class 3 · Ordinary Motor Vehicle";
            guna2RadioButton3.Tag = "3";
            guna2RadioButton3.AutoSize = false;
            guna2RadioButton3.Padding = new Padding(16, 0, 12, 0);
            guna2RadioButton3.TextAlign = ContentAlignment.MiddleLeft;
            guna2RadioButton3.Appearance = Appearance.Button;
            guna2RadioButton3.FlatStyle = FlatStyle.Flat;
            guna2RadioButton3.FlatAppearance.BorderColor = Color.FromArgb(219, 229, 242);
            guna2RadioButton3.FlatAppearance.BorderSize = 1;
            guna2RadioButton3.FlatAppearance.CheckedBackColor = Color.FromArgb(226, 239, 255);
            guna2RadioButton3.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
            guna2RadioButton3.Location = new Point(0, 132);
            guna2RadioButton3.Size = new Size(609, 56);
            guna2RadioButton3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2RadioButton3.BackColor = Color.FromArgb(250, 252, 255);
            guna2RadioButton3.ForeColor = Color.FromArgb(15, 23, 42);
            guna2RadioButton3.Font = new Font("Segoe UI", 11F);
            guna2RadioButton3.CheckedState.BorderColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton3.CheckedState.BorderThickness = 1;
            guna2RadioButton3.CheckedState.FillColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton3.CheckedState.InnerColor = Color.White;
            guna2RadioButton3.UncheckedState.BorderColor = Color.FromArgb(148, 163, 184);
            guna2RadioButton3.UncheckedState.BorderThickness = 2;
            guna2RadioButton3.UncheckedState.FillColor = Color.White;
            guna2RadioButton3.UncheckedState.InnerColor = Color.White;
            guna2RadioButton3.TabIndex = 2;
            guna2RadioButton3.Name = "guna2RadioButton3";
            guna2RadioButton3.CheckedChanged += LicenseRadioButton_CheckedChanged;
            guna2RadioButton3.BringToFront();
            gbContainer.Controls.Add(guna2RadioButton4);
            // guna2RadioButton4
            guna2RadioButton4.Text = "      Class 4 · Commercial Vehicle";
            guna2RadioButton4.Tag = "4";
            guna2RadioButton4.AutoSize = false;
            guna2RadioButton4.Padding = new Padding(16, 0, 12, 0);
            guna2RadioButton4.TextAlign = ContentAlignment.MiddleLeft;
            guna2RadioButton4.Appearance = Appearance.Button;
            guna2RadioButton4.FlatStyle = FlatStyle.Flat;
            guna2RadioButton4.FlatAppearance.BorderColor = Color.FromArgb(219, 229, 242);
            guna2RadioButton4.FlatAppearance.BorderSize = 1;
            guna2RadioButton4.FlatAppearance.CheckedBackColor = Color.FromArgb(226, 239, 255);
            guna2RadioButton4.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
            guna2RadioButton4.Location = new Point(0, 198);
            guna2RadioButton4.Size = new Size(609, 56);
            guna2RadioButton4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2RadioButton4.BackColor = Color.FromArgb(250, 252, 255);
            guna2RadioButton4.ForeColor = Color.FromArgb(15, 23, 42);
            guna2RadioButton4.Font = new Font("Segoe UI", 11F);
            guna2RadioButton4.CheckedState.BorderColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton4.CheckedState.BorderThickness = 1;
            guna2RadioButton4.CheckedState.FillColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton4.CheckedState.InnerColor = Color.White;
            guna2RadioButton4.UncheckedState.BorderColor = Color.FromArgb(148, 163, 184);
            guna2RadioButton4.UncheckedState.BorderThickness = 2;
            guna2RadioButton4.UncheckedState.FillColor = Color.White;
            guna2RadioButton4.UncheckedState.InnerColor = Color.White;
            guna2RadioButton4.TabIndex = 3;
            guna2RadioButton4.Name = "guna2RadioButton4";
            guna2RadioButton4.CheckedChanged += LicenseRadioButton_CheckedChanged;
            guna2RadioButton4.BringToFront();
            gbContainer.Controls.Add(guna2RadioButton5);
            // guna2RadioButton5
            guna2RadioButton5.Text = "      Class 5 · Agricultural / Equipment";
            guna2RadioButton5.Tag = "5";
            guna2RadioButton5.AutoSize = false;
            guna2RadioButton5.Padding = new Padding(16, 0, 12, 0);
            guna2RadioButton5.TextAlign = ContentAlignment.MiddleLeft;
            guna2RadioButton5.Appearance = Appearance.Button;
            guna2RadioButton5.FlatStyle = FlatStyle.Flat;
            guna2RadioButton5.FlatAppearance.BorderColor = Color.FromArgb(219, 229, 242);
            guna2RadioButton5.FlatAppearance.BorderSize = 1;
            guna2RadioButton5.FlatAppearance.CheckedBackColor = Color.FromArgb(226, 239, 255);
            guna2RadioButton5.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 246, 255);
            guna2RadioButton5.Location = new Point(0, 264);
            guna2RadioButton5.Size = new Size(609, 56);
            guna2RadioButton5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2RadioButton5.BackColor = Color.FromArgb(250, 252, 255);
            guna2RadioButton5.ForeColor = Color.FromArgb(15, 23, 42);
            guna2RadioButton5.Font = new Font("Segoe UI", 11F);
            guna2RadioButton5.CheckedState.BorderColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton5.CheckedState.BorderThickness = 1;
            guna2RadioButton5.CheckedState.FillColor = Color.FromArgb(37, 99, 235);
            guna2RadioButton5.CheckedState.InnerColor = Color.White;
            guna2RadioButton5.UncheckedState.BorderColor = Color.FromArgb(148, 163, 184);
            guna2RadioButton5.UncheckedState.BorderThickness = 2;
            guna2RadioButton5.UncheckedState.FillColor = Color.White;
            guna2RadioButton5.UncheckedState.InnerColor = Color.White;
            guna2RadioButton5.TabIndex = 4;
            guna2RadioButton5.Name = "guna2RadioButton5";
            guna2RadioButton5.CheckedChanged += LicenseRadioButton_CheckedChanged;
            guna2RadioButton5.BringToFront();
            categoryPanel.Controls.Add(categoryFooter);
            // categoryFooter
            categoryFooter.Text = "Select a class to enable Confirm & Save.";
            categoryFooter.Location = new Point(16, 418);
            categoryFooter.Size = new Size(600, 20);
            categoryFooter.BackColor = Color.Transparent;
            categoryFooter.ForeColor = Color.FromArgb(100, 116, 139);
            categoryFooter.Name = "categoryFooter";
            Controls.Add(categoryPanel);
            // summaryPanel
            summaryPanel.Location = new Point(657, 0);
            summaryPanel.Size = new Size(346, 447);
            summaryPanel.FillColor = Color.White;
            summaryPanel.BorderColor = Color.FromArgb(219, 229, 242);
            summaryPanel.BorderThickness = 1;
            summaryPanel.BorderRadius = 8;
            summaryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            summaryPanel.Name = "summaryPanel";
            summaryPanel.Controls.Add(summaryHeading);
            // summaryHeading
            summaryHeading.Text = "Applicant summary";
            summaryHeading.Location = new Point(18, 12);
            summaryHeading.Size = new Size(310, 26);
            summaryHeading.BackColor = Color.Transparent;
            summaryHeading.ForeColor = Color.FromArgb(15, 23, 42);
            summaryHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            summaryHeading.Name = "summaryHeading";
            summaryPanel.Controls.Add(photoFrame);
            // photoFrame
            photoFrame.Location = new Point(133, 48);
            photoFrame.Size = new Size(80, 80);
            photoFrame.FillColor = Color.FromArgb(239, 246, 255);
            photoFrame.BorderColor = Color.FromArgb(219, 229, 242);
            photoFrame.BorderThickness = 1;
            photoFrame.BorderRadius = 8;
            photoFrame.Name = "photoFrame";
            photoFrame.Controls.Add(pbPhoto);
            // pbPhoto
            pbPhoto.Location = new Point(5, 5);
            pbPhoto.Size = new Size(70, 70);
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabStop = false;
            pbPhoto.Name = "pbPhoto";
            summaryPanel.Controls.Add(lblFullName);
            // lblFullName
            lblFullName.Text = "Applicant name";
            lblFullName.Location = new Point(16, 138);
            lblFullName.Size = new Size(314, 24);
            lblFullName.BackColor = Color.Transparent;
            lblFullName.ForeColor = Color.FromArgb(15, 23, 42);
            lblFullName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFullName.TextAlign = ContentAlignment.MiddleCenter;
            lblFullName.AutoEllipsis = true;
            lblFullName.Name = "lblFullName";
            summaryPanel.Controls.Add(NationalNoButton);
            // NationalNoButton
            NationalNoButton.Location = new Point(105, 168);
            NationalNoButton.Size = new Size(136, 26);
            NationalNoButton.Text = "National number";
            NationalNoButton.FillColor = Color.FromArgb(226, 239, 255);
            NationalNoButton.ForeColor = Color.FromArgb(37, 99, 235);
            NationalNoButton.BorderRadius = 13;
            NationalNoButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            NationalNoButton.TabStop = false;
            NationalNoButton.Name = "NationalNoButton";
            summaryPanel.Controls.Add(summaryDivider);
            // summaryDivider
            summaryDivider.Location = new Point(18, 274);
            summaryDivider.Size = new Size(310, 1);
            summaryDivider.BackColor = Color.FromArgb(219, 229, 242);
            summaryDivider.Name = "summaryDivider";
            summaryPanel.Controls.Add(birthCaption);
            // birthCaption
            birthCaption.Text = "Date of birth";
            birthCaption.Location = new Point(18, 214);
            birthCaption.Size = new Size(118, 22);
            birthCaption.BackColor = Color.Transparent;
            birthCaption.ForeColor = Color.FromArgb(100, 116, 139);
            birthCaption.Name = "birthCaption";
            summaryPanel.Controls.Add(lblDateOfBirth);
            // lblDateOfBirth
            lblDateOfBirth.Text = "—";
            lblDateOfBirth.Location = new Point(140, 214);
            lblDateOfBirth.Size = new Size(188, 24);
            lblDateOfBirth.BackColor = Color.Transparent;
            lblDateOfBirth.ForeColor = Color.FromArgb(15, 23, 42);
            lblDateOfBirth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateOfBirth.AutoEllipsis = true;
            lblDateOfBirth.Name = "lblDateOfBirth";
            summaryPanel.Controls.Add(ageCaption);
            // ageCaption
            ageCaption.Text = "Age";
            ageCaption.Location = new Point(18, 242);
            ageCaption.Size = new Size(118, 22);
            ageCaption.BackColor = Color.Transparent;
            ageCaption.ForeColor = Color.FromArgb(100, 116, 139);
            ageCaption.Name = "ageCaption";
            summaryPanel.Controls.Add(lblAge);
            // lblAge
            lblAge.Text = "—";
            lblAge.Location = new Point(140, 242);
            lblAge.Size = new Size(188, 24);
            lblAge.BackColor = Color.Transparent;
            lblAge.ForeColor = Color.FromArgb(15, 23, 42);
            lblAge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAge.AutoEllipsis = true;
            lblAge.Name = "lblAge";
            summaryPanel.Controls.Add(applicationIdCaption);
            // applicationIdCaption
            applicationIdCaption.Text = "Application ID";
            applicationIdCaption.Location = new Point(18, 288);
            applicationIdCaption.Size = new Size(118, 22);
            applicationIdCaption.BackColor = Color.Transparent;
            applicationIdCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationIdCaption.Name = "applicationIdCaption";
            summaryPanel.Controls.Add(lblApplicationID);
            // lblApplicationID
            lblApplicationID.Text = "Assigned after saving";
            lblApplicationID.Location = new Point(140, 288);
            lblApplicationID.Size = new Size(188, 24);
            lblApplicationID.BackColor = Color.Transparent;
            lblApplicationID.ForeColor = Color.FromArgb(100, 116, 139);
            lblApplicationID.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblApplicationID.AutoEllipsis = true;
            lblApplicationID.Name = "lblApplicationID";
            summaryPanel.Controls.Add(applicationDateCaption);
            // applicationDateCaption
            applicationDateCaption.Text = "Application date";
            applicationDateCaption.Location = new Point(18, 318);
            applicationDateCaption.Size = new Size(118, 22);
            applicationDateCaption.BackColor = Color.Transparent;
            applicationDateCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationDateCaption.Name = "applicationDateCaption";
            summaryPanel.Controls.Add(lblApplicationDate);
            // lblApplicationDate
            lblApplicationDate.Text = "—";
            lblApplicationDate.Location = new Point(140, 318);
            lblApplicationDate.Size = new Size(188, 24);
            lblApplicationDate.BackColor = Color.Transparent;
            lblApplicationDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApplicationDate.AutoEllipsis = true;
            lblApplicationDate.Name = "lblApplicationDate";
            summaryPanel.Controls.Add(createdByCaption);
            // createdByCaption
            createdByCaption.Text = "Created by";
            createdByCaption.Location = new Point(18, 348);
            createdByCaption.Size = new Size(118, 22);
            createdByCaption.BackColor = Color.Transparent;
            createdByCaption.ForeColor = Color.FromArgb(100, 116, 139);
            createdByCaption.Name = "createdByCaption";
            summaryPanel.Controls.Add(lblCreateby);
            // lblCreateby
            lblCreateby.Text = "—";
            lblCreateby.Location = new Point(140, 348);
            lblCreateby.Size = new Size(188, 24);
            lblCreateby.BackColor = Color.Transparent;
            lblCreateby.ForeColor = Color.FromArgb(15, 23, 42);
            lblCreateby.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreateby.AutoEllipsis = true;
            lblCreateby.Name = "lblCreateby";
            summaryPanel.Controls.Add(feeCaption);
            // feeCaption
            feeCaption.Text = "Application fee";
            feeCaption.Location = new Point(18, 378);
            feeCaption.Size = new Size(118, 22);
            feeCaption.BackColor = Color.Transparent;
            feeCaption.ForeColor = Color.FromArgb(100, 116, 139);
            feeCaption.Name = "feeCaption";
            summaryPanel.Controls.Add(lblFees);
            // lblFees
            lblFees.Text = "—";
            lblFees.Location = new Point(140, 378);
            lblFees.Size = new Size(188, 24);
            lblFees.BackColor = Color.Transparent;
            lblFees.ForeColor = Color.FromArgb(15, 23, 42);
            lblFees.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFees.AutoEllipsis = true;
            lblFees.Name = "lblFees";
            Controls.Add(summaryPanel);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 249, 253);
            Font = new Font("Segoe UI", 9F);
            Name = "ApplicationInfoControl";
            Size = new Size(1003, 447);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel categoryPanel;
        private Label categoryHeading;
        private Label categoryHint;
        private Guna.UI2.WinForms.Guna2GroupBox gbContainer;
        private Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton1;
        private Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton2;
        private Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton3;
        private Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton4;
        private Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton5;
        private Label categoryFooter;
        private Guna.UI2.WinForms.Guna2Panel summaryPanel;
        private Label summaryHeading;
        private Guna.UI2.WinForms.Guna2Panel photoFrame;
        private PictureBox pbPhoto;
        private Label lblFullName;
        private Guna.UI2.WinForms.Guna2Button NationalNoButton;
        private Panel summaryDivider;
        private Label birthCaption;
        private Label lblDateOfBirth;
        private Label ageCaption;
        private Label lblAge;
        private Label applicationIdCaption;
        private Label lblApplicationID;
        private Label applicationDateCaption;
        private Label lblApplicationDate;
        private Label createdByCaption;
        private Label lblCreateby;
        private Label feeCaption;
        private Label lblFees;
    }
}
