#nullable enable
namespace DVLD.WinForms.Features.Test.RecordTestResult
{
    partial class RecordTestResultControl
    {
        private System.ComponentModel.IContainer? components;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }
        #region Component Designer generated code
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
            pageLayout = new TableLayoutPanel();
            headingLayout = new TableLayoutPanel();
            pageTitle = new Label();
            pageSubtitle = new Label();
            applicantCard = new Guna.UI2.WinForms.Guna2Panel();
            applicantLayout = new TableLayoutPanel();
            pbPhoto = new PictureBox();
            identityLayout = new TableLayoutPanel();
            lblFullName = new Label();
            lblNationalNo = new Label();
            applicationLayout = new TableLayoutPanel();
            applicationCaption = new Label();
            lblLocalApplicationId = new Label();
            licenseLayout = new TableLayoutPanel();
            licenseCaption = new Label();
            lblLicenseClass = new Label();
            contentLayout = new TableLayoutPanel();
            outcomeCard = new Guna.UI2.WinForms.Guna2Panel();
            outcomeLayout = new TableLayoutPanel();
            outcomeHeading = new TableLayoutPanel();
            outcomeTitle = new Label();
            lblTestName = new Label();
            resultCaption = new Label();
            resultOptions = new TableLayoutPanel();
            PassRadioButton = new RadioButton();
            FailRadioButton = new RadioButton();
            notesCaption = new Label();
            NotesTextBox = new TextBox();
            notesHint = new Label();
            detailsCard = new Guna.UI2.WinForms.Guna2Panel();
            detailsLayout = new TableLayoutPanel();
            detailsTitle = new Label();
            appointmentIdCaption = new Label();
            testTypeCaption = new Label();
            scheduledCaption = new Label();
            attemptCaption = new Label();
            feesCaption = new Label();
            statusCaption = new Label();
            lblAppointmentId = new Label();
            lblAppointmentTestType = new Label();
            lblAppointmentDate = new Label();
            lblAttempt = new Label();
            lblPaidFees = new Label();
            lblAppointmentStatus = new Label();
            infoBanner = new Label();
            footerPanel = new Panel();
            footerHint = new Label();
            footerActions = new FlowLayoutPanel();
            SaveResultButton = new Guna.UI2.WinForms.Guna2Button();
            pageLayout.SuspendLayout();
            headingLayout.SuspendLayout();
            applicantCard.SuspendLayout();
            applicantLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            identityLayout.SuspendLayout();
            applicationLayout.SuspendLayout();
            licenseLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            outcomeCard.SuspendLayout();
            outcomeLayout.SuspendLayout();
            outcomeHeading.SuspendLayout();
            resultOptions.SuspendLayout();
            detailsCard.SuspendLayout();
            detailsLayout.SuspendLayout();
            footerPanel.SuspendLayout();
            footerActions.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoSize = true;
            pageLayout.BackColor = Color.FromArgb(243, 246, 251);
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLayout, 0, 0);
            pageLayout.Controls.Add(applicantCard, 0, 1);
            pageLayout.Controls.Add(contentLayout, 0, 2);
            pageLayout.Controls.Add(infoBanner, 0, 3);
            pageLayout.Controls.Add(footerPanel, 0, 4);
            pageLayout.Dock = DockStyle.Top;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(760, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24, 12, 24, 16);
            pageLayout.RowCount = 5;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            pageLayout.Size = new Size(1003, 634);
            pageLayout.TabIndex = 0;
            // 
            // headingLayout
            // 
            headingLayout.BackColor = Color.Transparent;
            headingLayout.ColumnCount = 1;
            headingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headingLayout.Controls.Add(pageTitle, 0, 1);
            headingLayout.Controls.Add(pageSubtitle, 0, 2);
            headingLayout.Dock = DockStyle.Fill;
            headingLayout.Location = new Point(24, 12);
            headingLayout.Margin = new Padding(0);
            headingLayout.Name = "headingLayout";
            headingLayout.RowCount = 3;
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headingLayout.Size = new Size(955, 90);
            headingLayout.TabIndex = 0;
            // 
            // pageTitle
            // 
            pageTitle.AutoEllipsis = true;
            pageTitle.Dock = DockStyle.Fill;
            pageTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            pageTitle.ForeColor = Color.FromArgb(15, 23, 42);
            pageTitle.Location = new Point(0, 28);
            pageTitle.Margin = new Padding(0);
            pageTitle.Name = "pageTitle";
            pageTitle.Size = new Size(955, 42);
            pageTitle.TabIndex = 1;
            pageTitle.Text = "Record test result";
            pageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pageSubtitle
            // 
            pageSubtitle.AutoEllipsis = true;
            pageSubtitle.Dock = DockStyle.Fill;
            pageSubtitle.Font = new Font("Segoe UI", 10F);
            pageSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            pageSubtitle.Location = new Point(0, 70);
            pageSubtitle.Margin = new Padding(0);
            pageSubtitle.Name = "pageSubtitle";
            pageSubtitle.Size = new Size(955, 20);
            pageSubtitle.TabIndex = 2;
            pageSubtitle.Text = "Review the appointment and enter the test outcome.";
            pageSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applicantCard
            // 
            applicantCard.BorderColor = Color.FromArgb(222, 229, 238);
            applicantCard.BorderRadius = 12;
            applicantCard.BorderThickness = 1;
            applicantCard.Controls.Add(applicantLayout);
            applicantCard.CustomizableEdges = customizableEdges1;
            applicantCard.Dock = DockStyle.Fill;
            applicantCard.FillColor = Color.White;
            applicantCard.Location = new Point(24, 102);
            applicantCard.Margin = new Padding(0, 0, 0, 12);
            applicantCard.Name = "applicantCard";
            applicantCard.Padding = new Padding(18);
            applicantCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            applicantCard.Size = new Size(955, 88);
            applicantCard.TabIndex = 1;
            // 
            // applicantLayout
            // 
            applicantLayout.BackColor = Color.White;
            applicantLayout.ColumnCount = 4;
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 76F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            applicantLayout.Controls.Add(pbPhoto, 0, 0);
            applicantLayout.Controls.Add(identityLayout, 1, 0);
            applicantLayout.Controls.Add(applicationLayout, 2, 0);
            applicantLayout.Controls.Add(licenseLayout, 3, 0);
            applicantLayout.Dock = DockStyle.Fill;
            applicantLayout.Location = new Point(18, 18);
            applicantLayout.Margin = new Padding(0);
            applicantLayout.Name = "applicantLayout";
            applicantLayout.RowCount = 1;
            applicantLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicantLayout.Size = new Size(919, 52);
            applicantLayout.TabIndex = 0;
            // 
            // pbPhoto
            // 
            pbPhoto.Dock = DockStyle.Fill;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.Location = new Point(0, 0);
            pbPhoto.Margin = new Padding(0, 0, 14, 0);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(62, 52);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;
            // 
            // identityLayout
            // 
            identityLayout.BackColor = Color.White;
            identityLayout.ColumnCount = 1;
            identityLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            identityLayout.Controls.Add(lblFullName, 0, 0);
            identityLayout.Controls.Add(lblNationalNo, 0, 1);
            identityLayout.Dock = DockStyle.Fill;
            identityLayout.Location = new Point(76, 0);
            identityLayout.Margin = new Padding(0);
            identityLayout.Name = "identityLayout";
            identityLayout.RowCount = 2;
            identityLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            identityLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            identityLayout.Size = new Size(354, 52);
            identityLayout.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoEllipsis = true;
            lblFullName.Dock = DockStyle.Fill;
            lblFullName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(15, 23, 42);
            lblFullName.Location = new Point(0, 0);
            lblFullName.Margin = new Padding(0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(354, 29);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Applicant name";
            lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNationalNo
            // 
            lblNationalNo.AutoEllipsis = true;
            lblNationalNo.Dock = DockStyle.Fill;
            lblNationalNo.Font = new Font("Segoe UI", 9F);
            lblNationalNo.ForeColor = Color.FromArgb(100, 116, 139);
            lblNationalNo.Location = new Point(0, 29);
            lblNationalNo.Margin = new Padding(0);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Size = new Size(354, 23);
            lblNationalNo.TabIndex = 1;
            lblNationalNo.Text = "National number: —";
            lblNationalNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applicationLayout
            // 
            applicationLayout.BackColor = Color.White;
            applicationLayout.ColumnCount = 1;
            applicationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            applicationLayout.Controls.Add(applicationCaption, 0, 0);
            applicationLayout.Controls.Add(lblLocalApplicationId, 0, 1);
            applicationLayout.Dock = DockStyle.Fill;
            applicationLayout.Location = new Point(444, 0);
            applicationLayout.Margin = new Padding(14, 0, 0, 0);
            applicationLayout.Name = "applicationLayout";
            applicationLayout.RowCount = 2;
            applicationLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            applicationLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicationLayout.Size = new Size(154, 52);
            applicationLayout.TabIndex = 2;
            // 
            // applicationCaption
            // 
            applicationCaption.AutoEllipsis = true;
            applicationCaption.Dock = DockStyle.Fill;
            applicationCaption.Font = new Font("Segoe UI", 9F);
            applicationCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationCaption.Location = new Point(0, 0);
            applicationCaption.Margin = new Padding(0);
            applicationCaption.Name = "applicationCaption";
            applicationCaption.Size = new Size(154, 29);
            applicationCaption.TabIndex = 0;
            applicationCaption.Text = "Application ID";
            applicationCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocalApplicationId
            // 
            lblLocalApplicationId.AutoEllipsis = true;
            lblLocalApplicationId.Dock = DockStyle.Fill;
            lblLocalApplicationId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLocalApplicationId.ForeColor = Color.FromArgb(15, 23, 42);
            lblLocalApplicationId.Location = new Point(0, 29);
            lblLocalApplicationId.Margin = new Padding(0);
            lblLocalApplicationId.Name = "lblLocalApplicationId";
            lblLocalApplicationId.Size = new Size(154, 23);
            lblLocalApplicationId.TabIndex = 1;
            lblLocalApplicationId.Text = "—";
            lblLocalApplicationId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // licenseLayout
            // 
            licenseLayout.BackColor = Color.White;
            licenseLayout.ColumnCount = 1;
            licenseLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            licenseLayout.Controls.Add(licenseCaption, 0, 0);
            licenseLayout.Controls.Add(lblLicenseClass, 0, 1);
            licenseLayout.Dock = DockStyle.Fill;
            licenseLayout.Location = new Point(612, 0);
            licenseLayout.Margin = new Padding(14, 0, 0, 0);
            licenseLayout.Name = "licenseLayout";
            licenseLayout.RowCount = 2;
            licenseLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            licenseLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            licenseLayout.Size = new Size(307, 52);
            licenseLayout.TabIndex = 3;
            // 
            // licenseCaption
            // 
            licenseCaption.AutoEllipsis = true;
            licenseCaption.Dock = DockStyle.Fill;
            licenseCaption.Font = new Font("Segoe UI", 9F);
            licenseCaption.ForeColor = Color.FromArgb(100, 116, 139);
            licenseCaption.Location = new Point(0, 0);
            licenseCaption.Margin = new Padding(0);
            licenseCaption.Name = "licenseCaption";
            licenseCaption.Size = new Size(307, 29);
            licenseCaption.TabIndex = 0;
            licenseCaption.Text = "License class";
            licenseCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLicenseClass
            // 
            lblLicenseClass.AutoEllipsis = true;
            lblLicenseClass.Dock = DockStyle.Fill;
            lblLicenseClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLicenseClass.ForeColor = Color.FromArgb(15, 23, 42);
            lblLicenseClass.Location = new Point(0, 29);
            lblLicenseClass.Margin = new Padding(0);
            lblLicenseClass.Name = "lblLicenseClass";
            lblLicenseClass.Size = new Size(307, 23);
            lblLicenseClass.TabIndex = 1;
            lblLicenseClass.Text = "—";
            lblLicenseClass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contentLayout
            // 
            contentLayout.BackColor = Color.Transparent;
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            contentLayout.Controls.Add(outcomeCard, 0, 0);
            contentLayout.Controls.Add(detailsCard, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(24, 202);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(955, 320);
            contentLayout.TabIndex = 2;
            // 
            // outcomeCard
            // 
            outcomeCard.BorderColor = Color.FromArgb(222, 229, 238);
            outcomeCard.BorderRadius = 12;
            outcomeCard.BorderThickness = 1;
            outcomeCard.Controls.Add(outcomeLayout);
            outcomeCard.CustomizableEdges = customizableEdges3;
            outcomeCard.Dock = DockStyle.Fill;
            outcomeCard.FillColor = Color.White;
            outcomeCard.Location = new Point(0, 0);
            outcomeCard.Margin = new Padding(0, 0, 14, 12);
            outcomeCard.Name = "outcomeCard";
            outcomeCard.Padding = new Padding(18);
            outcomeCard.ShadowDecoration.CustomizableEdges = customizableEdges4;
            outcomeCard.Size = new Size(578, 308);
            outcomeCard.TabIndex = 0;
            // 
            // outcomeLayout
            // 
            outcomeLayout.BackColor = Color.White;
            outcomeLayout.ColumnCount = 1;
            outcomeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            outcomeLayout.Controls.Add(outcomeHeading, 0, 0);
            outcomeLayout.Controls.Add(resultCaption, 0, 1);
            outcomeLayout.Controls.Add(resultOptions, 0, 2);
            outcomeLayout.Controls.Add(notesCaption, 0, 3);
            outcomeLayout.Controls.Add(NotesTextBox, 0, 4);
            outcomeLayout.Controls.Add(notesHint, 0, 5);
            outcomeLayout.Dock = DockStyle.Fill;
            outcomeLayout.Location = new Point(18, 18);
            outcomeLayout.Margin = new Padding(0);
            outcomeLayout.Name = "outcomeLayout";
            outcomeLayout.RowCount = 6;
            outcomeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            outcomeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            outcomeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            outcomeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            outcomeLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            outcomeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            outcomeLayout.Size = new Size(542, 272);
            outcomeLayout.TabIndex = 0;
            // 
            // outcomeHeading
            // 
            outcomeHeading.BackColor = Color.White;
            outcomeHeading.ColumnCount = 2;
            outcomeHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            outcomeHeading.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            outcomeHeading.Controls.Add(outcomeTitle, 0, 0);
            outcomeHeading.Controls.Add(lblTestName, 1, 0);
            outcomeHeading.Dock = DockStyle.Fill;
            outcomeHeading.Location = new Point(0, 0);
            outcomeHeading.Margin = new Padding(0);
            outcomeHeading.Name = "outcomeHeading";
            outcomeHeading.RowCount = 1;
            outcomeHeading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            outcomeHeading.Size = new Size(542, 36);
            outcomeHeading.TabIndex = 0;
            // 
            // outcomeTitle
            // 
            outcomeTitle.AutoEllipsis = true;
            outcomeTitle.Dock = DockStyle.Fill;
            outcomeTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            outcomeTitle.ForeColor = Color.FromArgb(15, 23, 42);
            outcomeTitle.Location = new Point(0, 0);
            outcomeTitle.Margin = new Padding(0);
            outcomeTitle.Name = "outcomeTitle";
            outcomeTitle.Size = new Size(424, 36);
            outcomeTitle.TabIndex = 0;
            outcomeTitle.Text = "Test outcome";
            outcomeTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTestName
            // 
            lblTestName.AutoEllipsis = true;
            lblTestName.BackColor = Color.FromArgb(235, 242, 255);
            lblTestName.Dock = DockStyle.Fill;
            lblTestName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTestName.ForeColor = Color.FromArgb(37, 99, 235);
            lblTestName.Location = new Point(430, 0);
            lblTestName.Margin = new Padding(6, 0, 0, 0);
            lblTestName.Name = "lblTestName";
            lblTestName.Size = new Size(112, 36);
            lblTestName.TabIndex = 1;
            lblTestName.Text = "Test type";
            lblTestName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultCaption
            // 
            resultCaption.AutoEllipsis = true;
            resultCaption.Dock = DockStyle.Fill;
            resultCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            resultCaption.ForeColor = Color.FromArgb(15, 23, 42);
            resultCaption.Location = new Point(0, 36);
            resultCaption.Margin = new Padding(0);
            resultCaption.Name = "resultCaption";
            resultCaption.Size = new Size(542, 27);
            resultCaption.TabIndex = 1;
            resultCaption.Text = "Result *";
            resultCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resultOptions
            // 
            resultOptions.BackColor = Color.White;
            resultOptions.ColumnCount = 2;
            resultOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            resultOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            resultOptions.Controls.Add(PassRadioButton, 0, 0);
            resultOptions.Controls.Add(FailRadioButton, 1, 0);
            resultOptions.Dock = DockStyle.Fill;
            resultOptions.Location = new Point(0, 63);
            resultOptions.Margin = new Padding(0);
            resultOptions.Name = "resultOptions";
            resultOptions.RowCount = 1;
            resultOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            resultOptions.Size = new Size(542, 78);
            resultOptions.TabIndex = 2;
            // 
            // PassRadioButton
            // 
            PassRadioButton.AccessibleName = "Pass: applicant passed the test";
            PassRadioButton.Appearance = Appearance.Button;
            PassRadioButton.BackColor = Color.White;
            PassRadioButton.Cursor = Cursors.Hand;
            PassRadioButton.Dock = DockStyle.Fill;
            PassRadioButton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            PassRadioButton.FlatAppearance.CheckedBackColor = Color.FromArgb(220, 252, 231);
            PassRadioButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 253, 244);
            PassRadioButton.FlatStyle = FlatStyle.Flat;
            PassRadioButton.Font = new Font("Segoe UI", 10F);
            PassRadioButton.ForeColor = Color.FromArgb(15, 23, 42);
            PassRadioButton.Location = new Point(0, 4);
            PassRadioButton.Margin = new Padding(0, 4, 7, 8);
            PassRadioButton.Name = "PassRadioButton";
            PassRadioButton.Padding = new Padding(14, 0, 8, 0);
            PassRadioButton.Size = new Size(264, 66);
            PassRadioButton.TabIndex = 1;
            PassRadioButton.Text = "Pass\r\nApplicant passed the test";
            PassRadioButton.UseVisualStyleBackColor = false;
            PassRadioButton.TextChanged += NotesTextBox_TextChanged;
            // 
            // FailRadioButton
            // 
            FailRadioButton.AccessibleName = "Fail: applicant did not pass";
            FailRadioButton.Appearance = Appearance.Button;
            FailRadioButton.BackColor = Color.White;
            FailRadioButton.Cursor = Cursors.Hand;
            FailRadioButton.Dock = DockStyle.Fill;
            FailRadioButton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            FailRadioButton.FlatAppearance.CheckedBackColor = Color.FromArgb(254, 226, 226);
            FailRadioButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 242, 242);
            FailRadioButton.FlatStyle = FlatStyle.Flat;
            FailRadioButton.Font = new Font("Segoe UI", 10F);
            FailRadioButton.ForeColor = Color.FromArgb(15, 23, 42);
            FailRadioButton.Location = new Point(278, 4);
            FailRadioButton.Margin = new Padding(7, 4, 0, 8);
            FailRadioButton.Name = "FailRadioButton";
            FailRadioButton.Padding = new Padding(14, 0, 8, 0);
            FailRadioButton.Size = new Size(264, 66);
            FailRadioButton.TabIndex = 2;
            FailRadioButton.Text = "Fail\r\nApplicant did not pass";
            FailRadioButton.UseVisualStyleBackColor = false;
            FailRadioButton.TextChanged += NotesTextBox_TextChanged;
            // 
            // notesCaption
            // 
            notesCaption.AutoEllipsis = true;
            notesCaption.Dock = DockStyle.Fill;
            notesCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            notesCaption.ForeColor = Color.FromArgb(15, 23, 42);
            notesCaption.Location = new Point(0, 141);
            notesCaption.Margin = new Padding(0);
            notesCaption.Name = "notesCaption";
            notesCaption.Size = new Size(542, 28);
            notesCaption.TabIndex = 3;
            notesCaption.Text = "Examiner notes (optional)";
            notesCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NotesTextBox
            // 
            NotesTextBox.AcceptsReturn = true;
            NotesTextBox.AccessibleName = "Examiner notes";
            NotesTextBox.BorderStyle = BorderStyle.FixedSingle;
            NotesTextBox.Dock = DockStyle.Fill;
            NotesTextBox.Font = new Font("Segoe UI", 10F);
            NotesTextBox.Location = new Point(0, 173);
            NotesTextBox.Margin = new Padding(0, 4, 0, 4);
            NotesTextBox.Multiline = true;
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.PlaceholderText = "Add observations about this test…";
            NotesTextBox.ScrollBars = ScrollBars.Vertical;
            NotesTextBox.Size = new Size(542, 71);
            NotesTextBox.TabIndex = 3;
            NotesTextBox.TextChanged += NotesTextBox_TextChanged;
            // 
            // notesHint
            // 
            notesHint.AutoEllipsis = true;
            notesHint.Dock = DockStyle.Fill;
            notesHint.Font = new Font("Segoe UI", 9F);
            notesHint.ForeColor = Color.FromArgb(100, 116, 139);
            notesHint.Location = new Point(0, 248);
            notesHint.Margin = new Padding(0);
            notesHint.Name = "notesHint";
            notesHint.Size = new Size(542, 24);
            notesHint.TabIndex = 4;
            notesHint.Text = "Include any observations relevant to the result.";
            notesHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // detailsCard
            // 
            detailsCard.BorderColor = Color.FromArgb(222, 229, 238);
            detailsCard.BorderRadius = 12;
            detailsCard.BorderThickness = 1;
            detailsCard.Controls.Add(detailsLayout);
            detailsCard.CustomizableEdges = customizableEdges5;
            detailsCard.Dock = DockStyle.Fill;
            detailsCard.FillColor = Color.White;
            detailsCard.Location = new Point(592, 0);
            detailsCard.Margin = new Padding(0, 0, 0, 12);
            detailsCard.Name = "detailsCard";
            detailsCard.Padding = new Padding(18);
            detailsCard.ShadowDecoration.CustomizableEdges = customizableEdges6;
            detailsCard.Size = new Size(363, 308);
            detailsCard.TabIndex = 1;
            // 
            // detailsLayout
            // 
            detailsLayout.BackColor = Color.White;
            detailsLayout.ColumnCount = 2;
            detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            detailsLayout.Controls.Add(detailsTitle, 0, 0);
            detailsLayout.Controls.Add(appointmentIdCaption, 0, 1);
            detailsLayout.Controls.Add(testTypeCaption, 0, 2);
            detailsLayout.Controls.Add(scheduledCaption, 0, 3);
            detailsLayout.Controls.Add(attemptCaption, 0, 4);
            detailsLayout.Controls.Add(feesCaption, 0, 5);
            detailsLayout.Controls.Add(statusCaption, 0, 6);
            detailsLayout.Controls.Add(lblAppointmentId, 1, 1);
            detailsLayout.Controls.Add(lblAppointmentTestType, 1, 2);
            detailsLayout.Controls.Add(lblAppointmentDate, 1, 3);
            detailsLayout.Controls.Add(lblAttempt, 1, 4);
            detailsLayout.Controls.Add(lblPaidFees, 1, 5);
            detailsLayout.Controls.Add(lblAppointmentStatus, 1, 6);
            detailsLayout.Dock = DockStyle.Fill;
            detailsLayout.Location = new Point(18, 18);
            detailsLayout.Margin = new Padding(0);
            detailsLayout.Name = "detailsLayout";
            detailsLayout.RowCount = 7;
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            detailsLayout.Size = new Size(327, 272);
            detailsLayout.TabIndex = 0;
            // 
            // detailsTitle
            // 
            detailsTitle.AutoEllipsis = true;
            detailsLayout.SetColumnSpan(detailsTitle, 2);
            detailsTitle.Dock = DockStyle.Fill;
            detailsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            detailsTitle.ForeColor = Color.FromArgb(15, 23, 42);
            detailsTitle.Location = new Point(0, 0);
            detailsTitle.Margin = new Padding(0);
            detailsTitle.Name = "detailsTitle";
            detailsTitle.Size = new Size(327, 38);
            detailsTitle.TabIndex = 0;
            detailsTitle.Text = "Appointment details";
            detailsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // appointmentIdCaption
            // 
            appointmentIdCaption.AutoEllipsis = true;
            appointmentIdCaption.Dock = DockStyle.Fill;
            appointmentIdCaption.Font = new Font("Segoe UI", 9F);
            appointmentIdCaption.ForeColor = Color.FromArgb(100, 116, 139);
            appointmentIdCaption.Location = new Point(0, 38);
            appointmentIdCaption.Margin = new Padding(0);
            appointmentIdCaption.Name = "appointmentIdCaption";
            appointmentIdCaption.Size = new Size(147, 38);
            appointmentIdCaption.TabIndex = 1;
            appointmentIdCaption.Text = "Appointment ID";
            appointmentIdCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // testTypeCaption
            // 
            testTypeCaption.AutoEllipsis = true;
            testTypeCaption.Dock = DockStyle.Fill;
            testTypeCaption.Font = new Font("Segoe UI", 9F);
            testTypeCaption.ForeColor = Color.FromArgb(100, 116, 139);
            testTypeCaption.Location = new Point(0, 76);
            testTypeCaption.Margin = new Padding(0);
            testTypeCaption.Name = "testTypeCaption";
            testTypeCaption.Size = new Size(147, 38);
            testTypeCaption.TabIndex = 2;
            testTypeCaption.Text = "Test type";
            testTypeCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // scheduledCaption
            // 
            scheduledCaption.AutoEllipsis = true;
            scheduledCaption.Dock = DockStyle.Fill;
            scheduledCaption.Font = new Font("Segoe UI", 9F);
            scheduledCaption.ForeColor = Color.FromArgb(100, 116, 139);
            scheduledCaption.Location = new Point(0, 114);
            scheduledCaption.Margin = new Padding(0);
            scheduledCaption.Name = "scheduledCaption";
            scheduledCaption.Size = new Size(147, 38);
            scheduledCaption.TabIndex = 3;
            scheduledCaption.Text = "Scheduled for";
            scheduledCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // attemptCaption
            // 
            attemptCaption.AutoEllipsis = true;
            attemptCaption.Dock = DockStyle.Fill;
            attemptCaption.Font = new Font("Segoe UI", 9F);
            attemptCaption.ForeColor = Color.FromArgb(100, 116, 139);
            attemptCaption.Location = new Point(0, 152);
            attemptCaption.Margin = new Padding(0);
            attemptCaption.Name = "attemptCaption";
            attemptCaption.Size = new Size(147, 38);
            attemptCaption.TabIndex = 4;
            attemptCaption.Text = "Attempt";
            attemptCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // feesCaption
            // 
            feesCaption.AutoEllipsis = true;
            feesCaption.Dock = DockStyle.Fill;
            feesCaption.Font = new Font("Segoe UI", 9F);
            feesCaption.ForeColor = Color.FromArgb(100, 116, 139);
            feesCaption.Location = new Point(0, 190);
            feesCaption.Margin = new Padding(0);
            feesCaption.Name = "feesCaption";
            feesCaption.Size = new Size(147, 38);
            feesCaption.TabIndex = 5;
            feesCaption.Text = "Paid fees";
            feesCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusCaption
            // 
            statusCaption.AutoEllipsis = true;
            statusCaption.Dock = DockStyle.Fill;
            statusCaption.Font = new Font("Segoe UI", 9F);
            statusCaption.ForeColor = Color.FromArgb(100, 116, 139);
            statusCaption.Location = new Point(0, 228);
            statusCaption.Margin = new Padding(0);
            statusCaption.Name = "statusCaption";
            statusCaption.Size = new Size(147, 44);
            statusCaption.TabIndex = 6;
            statusCaption.Text = "Status";
            statusCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentId
            // 
            lblAppointmentId.AutoEllipsis = true;
            lblAppointmentId.Dock = DockStyle.Fill;
            lblAppointmentId.Font = new Font("Segoe UI", 10F);
            lblAppointmentId.ForeColor = Color.FromArgb(15, 23, 42);
            lblAppointmentId.Location = new Point(147, 38);
            lblAppointmentId.Margin = new Padding(0);
            lblAppointmentId.Name = "lblAppointmentId";
            lblAppointmentId.Size = new Size(180, 38);
            lblAppointmentId.TabIndex = 7;
            lblAppointmentId.Text = "—";
            lblAppointmentId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentTestType
            // 
            lblAppointmentTestType.AutoEllipsis = true;
            lblAppointmentTestType.Dock = DockStyle.Fill;
            lblAppointmentTestType.Font = new Font("Segoe UI", 10F);
            lblAppointmentTestType.ForeColor = Color.FromArgb(15, 23, 42);
            lblAppointmentTestType.Location = new Point(147, 76);
            lblAppointmentTestType.Margin = new Padding(0);
            lblAppointmentTestType.Name = "lblAppointmentTestType";
            lblAppointmentTestType.Size = new Size(180, 38);
            lblAppointmentTestType.TabIndex = 8;
            lblAppointmentTestType.Text = "—";
            lblAppointmentTestType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentDate
            // 
            lblAppointmentDate.AutoEllipsis = true;
            lblAppointmentDate.Dock = DockStyle.Fill;
            lblAppointmentDate.Font = new Font("Segoe UI", 10F);
            lblAppointmentDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblAppointmentDate.Location = new Point(147, 114);
            lblAppointmentDate.Margin = new Padding(0);
            lblAppointmentDate.Name = "lblAppointmentDate";
            lblAppointmentDate.Size = new Size(180, 38);
            lblAppointmentDate.TabIndex = 9;
            lblAppointmentDate.Text = "—";
            lblAppointmentDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAttempt
            // 
            lblAttempt.AutoEllipsis = true;
            lblAttempt.Dock = DockStyle.Fill;
            lblAttempt.Font = new Font("Segoe UI", 10F);
            lblAttempt.ForeColor = Color.FromArgb(15, 23, 42);
            lblAttempt.Location = new Point(147, 152);
            lblAttempt.Margin = new Padding(0);
            lblAttempt.Name = "lblAttempt";
            lblAttempt.Size = new Size(180, 38);
            lblAttempt.TabIndex = 10;
            lblAttempt.Text = "—";
            lblAttempt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPaidFees
            // 
            lblPaidFees.AutoEllipsis = true;
            lblPaidFees.Dock = DockStyle.Fill;
            lblPaidFees.Font = new Font("Segoe UI", 10F);
            lblPaidFees.ForeColor = Color.FromArgb(15, 23, 42);
            lblPaidFees.Location = new Point(147, 190);
            lblPaidFees.Margin = new Padding(0);
            lblPaidFees.Name = "lblPaidFees";
            lblPaidFees.Size = new Size(180, 38);
            lblPaidFees.TabIndex = 11;
            lblPaidFees.Text = "—";
            lblPaidFees.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentStatus
            // 
            lblAppointmentStatus.AutoEllipsis = true;
            lblAppointmentStatus.BackColor = Color.FromArgb(235, 242, 255);
            lblAppointmentStatus.Dock = DockStyle.Fill;
            lblAppointmentStatus.Font = new Font("Segoe UI", 10F);
            lblAppointmentStatus.ForeColor = Color.FromArgb(37, 99, 235);
            lblAppointmentStatus.Location = new Point(147, 228);
            lblAppointmentStatus.Margin = new Padding(0);
            lblAppointmentStatus.Name = "lblAppointmentStatus";
            lblAppointmentStatus.Size = new Size(180, 44);
            lblAppointmentStatus.TabIndex = 12;
            lblAppointmentStatus.Text = "Awaiting result";
            lblAppointmentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoBanner
            // 
            infoBanner.AutoEllipsis = true;
            infoBanner.BackColor = Color.FromArgb(231, 240, 255);
            infoBanner.Dock = DockStyle.Fill;
            infoBanner.Font = new Font("Segoe UI", 10F);
            infoBanner.ForeColor = Color.FromArgb(30, 64, 175);
            infoBanner.Location = new Point(24, 522);
            infoBanner.Margin = new Padding(0, 0, 0, 8);
            infoBanner.Name = "infoBanner";
            infoBanner.Padding = new Padding(12, 0, 12, 0);
            infoBanner.Size = new Size(955, 34);
            infoBanner.TabIndex = 3;
            infoBanner.Text = "ⓘ  Saving the result completes this appointment.";
            infoBanner.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(footerHint);
            footerPanel.Controls.Add(footerActions);
            footerPanel.Dock = DockStyle.Fill;
            footerPanel.Location = new Point(24, 564);
            footerPanel.Margin = new Padding(0);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 8, 0, 0);
            footerPanel.Size = new Size(955, 54);
            footerPanel.TabIndex = 4;
            // 
            // footerHint
            // 
            footerHint.AutoEllipsis = true;
            footerHint.Dock = DockStyle.Fill;
            footerHint.Font = new Font("Segoe UI", 9F);
            footerHint.ForeColor = Color.FromArgb(100, 116, 139);
            footerHint.Location = new Point(0, 8);
            footerHint.Margin = new Padding(0);
            footerHint.Name = "footerHint";
            footerHint.Size = new Size(675, 46);
            footerHint.TabIndex = 0;
            footerHint.Text = "Review your selection before saving.";
            footerHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // footerActions
            // 
            footerActions.Controls.Add(SaveResultButton);
            footerActions.Dock = DockStyle.Right;
            footerActions.Location = new Point(675, 8);
            footerActions.Margin = new Padding(0);
            footerActions.Name = "footerActions";
            footerActions.Size = new Size(280, 46);
            footerActions.TabIndex = 4;
            footerActions.WrapContents = false;
            // 
            // SaveResultButton
            // 
            SaveResultButton.BorderRadius = 8;
            SaveResultButton.Cursor = Cursors.Hand;
            SaveResultButton.CustomizableEdges = customizableEdges7;
            SaveResultButton.FillColor = Color.FromArgb(37, 99, 235);
            SaveResultButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            SaveResultButton.ForeColor = Color.White;
            SaveResultButton.Location = new Point(0, 0);
            SaveResultButton.Margin = new Padding(0);
            SaveResultButton.Name = "SaveResultButton";
            SaveResultButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            SaveResultButton.Size = new Size(155, 42);
            SaveResultButton.TabIndex = 4;
            SaveResultButton.Text = "Save result";
            // 
            // RecordTestResultControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 246, 251);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "RecordTestResultControl";
            Size = new Size(1003, 680);
            pageLayout.ResumeLayout(false);
            headingLayout.ResumeLayout(false);
            applicantCard.ResumeLayout(false);
            applicantLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            identityLayout.ResumeLayout(false);
            applicationLayout.ResumeLayout(false);
            licenseLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            outcomeCard.ResumeLayout(false);
            outcomeLayout.ResumeLayout(false);
            outcomeLayout.PerformLayout();
            outcomeHeading.ResumeLayout(false);
            resultOptions.ResumeLayout(false);
            detailsCard.ResumeLayout(false);
            detailsLayout.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            footerActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private TableLayoutPanel pageLayout = null!;
        private TableLayoutPanel headingLayout = null!;
        private Label pageTitle = null!;
        private Label pageSubtitle = null!;
        private Guna.UI2.WinForms.Guna2Panel applicantCard = null!;
        private TableLayoutPanel applicantLayout = null!;
        private PictureBox pbPhoto = null!;
        private TableLayoutPanel identityLayout = null!;
        private Label lblFullName = null!;
        private Label lblNationalNo = null!;
        private TableLayoutPanel applicationLayout = null!;
        private Label applicationCaption = null!;
        private Label lblLocalApplicationId = null!;
        private TableLayoutPanel licenseLayout = null!;
        private Label licenseCaption = null!;
        private Label lblLicenseClass = null!;
        private TableLayoutPanel contentLayout = null!;
        private Guna.UI2.WinForms.Guna2Panel outcomeCard = null!;
        private TableLayoutPanel outcomeLayout = null!;
        private TableLayoutPanel outcomeHeading = null!;
        private Label outcomeTitle = null!;
        private Label lblTestName = null!;
        private Label resultCaption = null!;
        private TableLayoutPanel resultOptions = null!;
        private RadioButton PassRadioButton = null!;
        private RadioButton FailRadioButton = null!;
        private Label notesCaption = null!;
        private TextBox NotesTextBox = null!;
        private Label notesHint = null!;
        private Guna.UI2.WinForms.Guna2Panel detailsCard = null!;
        private TableLayoutPanel detailsLayout = null!;
        private Label detailsTitle = null!;
        private Label appointmentIdCaption = null!;
        private Label testTypeCaption = null!;
        private Label scheduledCaption = null!;
        private Label attemptCaption = null!;
        private Label feesCaption = null!;
        private Label statusCaption = null!;
        private Label lblAppointmentId = null!;
        private Label lblAppointmentTestType = null!;
        private Label lblAppointmentDate = null!;
        private Label lblAttempt = null!;
        private Label lblPaidFees = null!;
        private Label lblAppointmentStatus = null!;
        private Label infoBanner = null!;
        private Panel footerPanel = null!;
        private Label footerHint = null!;
        private FlowLayoutPanel footerActions = null!;
        private Guna.UI2.WinForms.Guna2Button SaveResultButton = null!;
    }
}

