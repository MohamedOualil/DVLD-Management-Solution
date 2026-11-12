#nullable enable
namespace DVLD.WinForms.Features.Test.ScheduleTest
{
    partial class ScheduleTestControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pageLayout = new TableLayoutPanel();
            headingLayout = new TableLayoutPanel();
            pageTitle = new Label();
            pageSubtitle = new Label();
            applicantCard = new Guna.UI2.WinForms.Guna2Panel();
            applicantLayout = new TableLayoutPanel();
            pbPhoto = new PictureBox();
            identityLayout = new TableLayoutPanel();
            lblFullName = new Label();
            NationalNoButton = new Guna.UI2.WinForms.Guna2Button();
            birthLayout = new TableLayoutPanel();
            birthCaption = new Label();
            lblDateOfBirth = new Label();
            ageLayout = new TableLayoutPanel();
            ageCaption = new Label();
            lblAge = new Label();
            contentLayout = new TableLayoutPanel();
            appointmentCard = new Guna.UI2.WinForms.Guna2Panel();
            bookingLayout = new TableLayoutPanel();
            bookingTitle = new Label();
            lblTestName = new Label();
            bookingDescription = new Label();
            dateCaption = new Label();
            tpAppointmentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dateHint = new Label();
            bookingNote = new Label();
            summaryCard = new Guna.UI2.WinForms.Guna2Panel();
            summaryLayout = new TableLayoutPanel();
            summaryTitle = new Label();
            applicationIdLayout = new TableLayoutPanel();
            applicationIdCaption = new Label();
            lblLocalApplicationID = new Label();
            licenseCaption = new Label();
            lblLicenseClass = new Label();
            applicationTypeCaption = new Label();
            lblApplicationType = new Label();
            feesLayout = new TableLayoutPanel();
            feesCaption = new Label();
            attemptsCaption = new Label();
            lblFees = new Label();
            lblTrail = new Label();
            footerPanel = new Panel();
            footerHint = new Label();
            footerActions = new FlowLayoutPanel();
            SaveButton = new Guna.UI2.WinForms.Guna2GradientButton();
            pageLayout.SuspendLayout();
            headingLayout.SuspendLayout();
            applicantCard.SuspendLayout();
            applicantLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            identityLayout.SuspendLayout();
            birthLayout.SuspendLayout();
            ageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            appointmentCard.SuspendLayout();
            bookingLayout.SuspendLayout();
            summaryCard.SuspendLayout();
            summaryLayout.SuspendLayout();
            applicationIdLayout.SuspendLayout();
            feesLayout.SuspendLayout();
            footerPanel.SuspendLayout();
            footerActions.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoSize = true;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLayout, 0, 0);
            pageLayout.Controls.Add(applicantCard, 0, 1);
            pageLayout.Controls.Add(contentLayout, 0, 2);
            pageLayout.Controls.Add(footerPanel, 0, 3);
            pageLayout.Dock = DockStyle.Top;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(750, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24, 16, 24, 16);
            pageLayout.RowCount = 4;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 316F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            pageLayout.Size = new Size(1003, 620);
            pageLayout.TabIndex = 0;
            // 
            // headingLayout
            // 
            headingLayout.ColumnCount = 1;
            headingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headingLayout.Controls.Add(pageTitle, 0, 0);
            headingLayout.Controls.Add(pageSubtitle, 0, 1);
            headingLayout.Dock = DockStyle.Fill;
            headingLayout.Location = new Point(24, 16);
            headingLayout.Margin = new Padding(0);
            headingLayout.Name = "headingLayout";
            headingLayout.Padding = new Padding(0, 0, 0, 12);
            headingLayout.RowCount = 2;
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headingLayout.Size = new Size(955, 84);
            headingLayout.TabIndex = 0;
            // 
            // pageTitle
            // 
            pageTitle.AutoEllipsis = true;
            pageTitle.Dock = DockStyle.Fill;
            pageTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            pageTitle.ForeColor = Color.FromArgb(15, 23, 42);
            pageTitle.Location = new Point(0, 0);
            pageTitle.Margin = new Padding(0);
            pageTitle.Name = "pageTitle";
            pageTitle.Size = new Size(955, 42);
            pageTitle.TabIndex = 0;
            pageTitle.Text = "Schedule test appointment";
            pageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pageSubtitle
            // 
            pageSubtitle.AutoEllipsis = true;
            pageSubtitle.Dock = DockStyle.Fill;
            pageSubtitle.Font = new Font("Segoe UI", 10F);
            pageSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            pageSubtitle.Location = new Point(0, 42);
            pageSubtitle.Margin = new Padding(0);
            pageSubtitle.Name = "pageSubtitle";
            pageSubtitle.Size = new Size(955, 30);
            pageSubtitle.TabIndex = 1;
            pageSubtitle.Text = "Choose a date and time, then review the booking details.";
            pageSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applicantCard
            // 
            applicantCard.BorderColor = Color.FromArgb(222, 229, 238);
            applicantCard.BorderRadius = 12;
            applicantCard.BorderThickness = 1;
            applicantCard.Controls.Add(applicantLayout);
            applicantCard.CustomizableEdges = customizableEdges3;
            applicantCard.Dock = DockStyle.Fill;
            applicantCard.FillColor = Color.White;
            applicantCard.Location = new Point(24, 100);
            applicantCard.Margin = new Padding(0, 0, 0, 12);
            applicantCard.Name = "applicantCard";
            applicantCard.Padding = new Padding(20);
            applicantCard.ShadowDecoration.CustomizableEdges = customizableEdges4;
            applicantCard.Size = new Size(955, 112);
            applicantCard.TabIndex = 1;
            // 
            // applicantLayout
            // 
            applicantLayout.BackColor = Color.White;
            applicantLayout.ColumnCount = 4;
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            applicantLayout.Controls.Add(pbPhoto, 0, 0);
            applicantLayout.Controls.Add(identityLayout, 1, 0);
            applicantLayout.Controls.Add(birthLayout, 2, 0);
            applicantLayout.Controls.Add(ageLayout, 3, 0);
            applicantLayout.Dock = DockStyle.Fill;
            applicantLayout.Location = new Point(20, 20);
            applicantLayout.Margin = new Padding(0);
            applicantLayout.Name = "applicantLayout";
            applicantLayout.RowCount = 1;
            applicantLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicantLayout.Size = new Size(915, 72);
            applicantLayout.TabIndex = 0;
            // 
            // pbPhoto
            // 
            pbPhoto.Dock = DockStyle.Fill;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.Location = new Point(0, 0);
            pbPhoto.Margin = new Padding(0, 0, 16, 0);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(64, 72);
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
            identityLayout.Controls.Add(NationalNoButton, 0, 1);
            identityLayout.Dock = DockStyle.Fill;
            identityLayout.Location = new Point(80, 0);
            identityLayout.Margin = new Padding(0);
            identityLayout.Name = "identityLayout";
            identityLayout.RowCount = 2;
            identityLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            identityLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            identityLayout.Size = new Size(590, 72);
            identityLayout.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoEllipsis = true;
            lblFullName.Dock = DockStyle.Fill;
            lblFullName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(15, 23, 42);
            lblFullName.Location = new Point(0, 0);
            lblFullName.Margin = new Padding(0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(590, 34);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Applicant name";
            lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NationalNoButton
            // 
            NationalNoButton.BorderRadius = 12;
            NationalNoButton.CustomizableEdges = customizableEdges1;
            NationalNoButton.Dock = DockStyle.Left;
            NationalNoButton.FillColor = Color.FromArgb(235, 242, 255);
            NationalNoButton.Font = new Font("Segoe UI", 9F);
            NationalNoButton.ForeColor = Color.FromArgb(37, 99, 235);
            NationalNoButton.HoverState.FillColor = Color.FromArgb(235, 242, 255);
            NationalNoButton.Location = new Point(0, 38);
            NationalNoButton.Margin = new Padding(0, 4, 0, 0);
            NationalNoButton.Name = "NationalNoButton";
            NationalNoButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            NationalNoButton.Size = new Size(160, 34);
            NationalNoButton.TabIndex = 1;
            NationalNoButton.TabStop = false;
            NationalNoButton.Text = "National number";
            NationalNoButton.TextAlign = HorizontalAlignment.Left;
            // 
            // birthLayout
            // 
            birthLayout.BackColor = Color.White;
            birthLayout.ColumnCount = 1;
            birthLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            birthLayout.Controls.Add(birthCaption, 0, 0);
            birthLayout.Controls.Add(lblDateOfBirth, 0, 1);
            birthLayout.Dock = DockStyle.Fill;
            birthLayout.Location = new Point(686, 0);
            birthLayout.Margin = new Padding(16, 0, 0, 0);
            birthLayout.Name = "birthLayout";
            birthLayout.RowCount = 2;
            birthLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            birthLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            birthLayout.Size = new Size(144, 72);
            birthLayout.TabIndex = 2;
            // 
            // birthCaption
            // 
            birthCaption.AutoEllipsis = true;
            birthCaption.Dock = DockStyle.Fill;
            birthCaption.Font = new Font("Segoe UI", 9F);
            birthCaption.ForeColor = Color.FromArgb(100, 116, 139);
            birthCaption.Location = new Point(0, 0);
            birthCaption.Margin = new Padding(0);
            birthCaption.Name = "birthCaption";
            birthCaption.Size = new Size(144, 27);
            birthCaption.TabIndex = 0;
            birthCaption.Text = "Date of birth";
            birthCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoEllipsis = true;
            lblDateOfBirth.Dock = DockStyle.Fill;
            lblDateOfBirth.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDateOfBirth.ForeColor = Color.FromArgb(15, 23, 42);
            lblDateOfBirth.Location = new Point(0, 27);
            lblDateOfBirth.Margin = new Padding(0);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(144, 45);
            lblDateOfBirth.TabIndex = 1;
            lblDateOfBirth.Text = "—";
            lblDateOfBirth.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ageLayout
            // 
            ageLayout.BackColor = Color.White;
            ageLayout.ColumnCount = 1;
            ageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ageLayout.Controls.Add(ageCaption, 0, 0);
            ageLayout.Controls.Add(lblAge, 0, 1);
            ageLayout.Dock = DockStyle.Fill;
            ageLayout.Location = new Point(846, 0);
            ageLayout.Margin = new Padding(16, 0, 0, 0);
            ageLayout.Name = "ageLayout";
            ageLayout.RowCount = 2;
            ageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            ageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ageLayout.Size = new Size(69, 72);
            ageLayout.TabIndex = 3;
            // 
            // ageCaption
            // 
            ageCaption.AutoEllipsis = true;
            ageCaption.Dock = DockStyle.Fill;
            ageCaption.Font = new Font("Segoe UI", 9F);
            ageCaption.ForeColor = Color.FromArgb(100, 116, 139);
            ageCaption.Location = new Point(0, 0);
            ageCaption.Margin = new Padding(0);
            ageCaption.Name = "ageCaption";
            ageCaption.Size = new Size(69, 27);
            ageCaption.TabIndex = 0;
            ageCaption.Text = "Age";
            ageCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAge
            // 
            lblAge.AutoEllipsis = true;
            lblAge.Dock = DockStyle.Fill;
            lblAge.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAge.ForeColor = Color.FromArgb(15, 23, 42);
            lblAge.Location = new Point(0, 27);
            lblAge.Margin = new Padding(0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(69, 45);
            lblAge.TabIndex = 1;
            lblAge.Text = "—";
            lblAge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            contentLayout.Controls.Add(appointmentCard, 0, 0);
            contentLayout.Controls.Add(summaryCard, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(24, 224);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(955, 316);
            contentLayout.TabIndex = 2;
            // 
            // appointmentCard
            // 
            appointmentCard.BorderColor = Color.FromArgb(222, 229, 238);
            appointmentCard.BorderRadius = 12;
            appointmentCard.BorderThickness = 1;
            appointmentCard.Controls.Add(bookingLayout);
            appointmentCard.CustomizableEdges = customizableEdges7;
            appointmentCard.Dock = DockStyle.Fill;
            appointmentCard.FillColor = Color.White;
            appointmentCard.Location = new Point(0, 0);
            appointmentCard.Margin = new Padding(0, 0, 14, 0);
            appointmentCard.Name = "appointmentCard";
            appointmentCard.Padding = new Padding(20);
            appointmentCard.ShadowDecoration.CustomizableEdges = customizableEdges8;
            appointmentCard.Size = new Size(578, 316);
            appointmentCard.TabIndex = 0;
            // 
            // bookingLayout
            // 
            bookingLayout.BackColor = Color.White;
            bookingLayout.ColumnCount = 1;
            bookingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bookingLayout.Controls.Add(bookingTitle, 0, 0);
            bookingLayout.Controls.Add(lblTestName, 0, 1);
            bookingLayout.Controls.Add(bookingDescription, 0, 2);
            bookingLayout.Controls.Add(dateCaption, 0, 3);
            bookingLayout.Controls.Add(tpAppointmentDate, 0, 4);
            bookingLayout.Controls.Add(dateHint, 0, 5);
            bookingLayout.Controls.Add(bookingNote, 0, 6);
            bookingLayout.Dock = DockStyle.Fill;
            bookingLayout.Location = new Point(20, 20);
            bookingLayout.Margin = new Padding(0);
            bookingLayout.Name = "bookingLayout";
            bookingLayout.RowCount = 7;
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bookingLayout.Size = new Size(538, 276);
            bookingLayout.TabIndex = 0;
            // 
            // bookingTitle
            // 
            bookingTitle.AutoEllipsis = true;
            bookingTitle.Dock = DockStyle.Fill;
            bookingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bookingTitle.ForeColor = Color.FromArgb(15, 23, 42);
            bookingTitle.Location = new Point(0, 0);
            bookingTitle.Margin = new Padding(0);
            bookingTitle.Name = "bookingTitle";
            bookingTitle.Size = new Size(538, 30);
            bookingTitle.TabIndex = 0;
            bookingTitle.Text = "Appointment details";
            bookingTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTestName
            // 
            lblTestName.AutoEllipsis = true;
            lblTestName.Dock = DockStyle.Fill;
            lblTestName.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTestName.ForeColor = Color.FromArgb(37, 99, 235);
            lblTestName.Location = new Point(0, 30);
            lblTestName.Margin = new Padding(0);
            lblTestName.Name = "lblTestName";
            lblTestName.Size = new Size(538, 44);
            lblTestName.TabIndex = 1;
            lblTestName.Text = "Test name";
            lblTestName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bookingDescription
            // 
            bookingDescription.AutoEllipsis = true;
            bookingDescription.Dock = DockStyle.Fill;
            bookingDescription.Font = new Font("Segoe UI", 10F);
            bookingDescription.ForeColor = Color.FromArgb(100, 116, 139);
            bookingDescription.Location = new Point(0, 74);
            bookingDescription.Margin = new Padding(0);
            bookingDescription.Name = "bookingDescription";
            bookingDescription.Size = new Size(538, 32);
            bookingDescription.TabIndex = 2;
            bookingDescription.Text = "Select when the applicant will take this test.";
            bookingDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateCaption
            // 
            dateCaption.AutoEllipsis = true;
            dateCaption.Dock = DockStyle.Fill;
            dateCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dateCaption.ForeColor = Color.FromArgb(15, 23, 42);
            dateCaption.Location = new Point(0, 106);
            dateCaption.Margin = new Padding(0);
            dateCaption.Name = "dateCaption";
            dateCaption.Size = new Size(538, 28);
            dateCaption.TabIndex = 3;
            dateCaption.Text = "Appointment date and time";
            dateCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tpAppointmentDate
            // 
            tpAppointmentDate.BorderColor = Color.FromArgb(203, 213, 225);
            tpAppointmentDate.BorderRadius = 8;
            tpAppointmentDate.BorderThickness = 1;
            tpAppointmentDate.Checked = true;
            tpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            tpAppointmentDate.CustomizableEdges = customizableEdges5;
            tpAppointmentDate.Dock = DockStyle.Fill;
            tpAppointmentDate.FillColor = Color.FromArgb(248, 250, 252);
            tpAppointmentDate.Font = new Font("Segoe UI", 11F);
            tpAppointmentDate.ForeColor = Color.FromArgb(15, 23, 42);
            tpAppointmentDate.Format = DateTimePickerFormat.Custom;
            tpAppointmentDate.Location = new Point(0, 138);
            tpAppointmentDate.Margin = new Padding(0, 4, 0, 4);
            tpAppointmentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            tpAppointmentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            tpAppointmentDate.Name = "tpAppointmentDate";
            tpAppointmentDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tpAppointmentDate.Size = new Size(538, 46);
            tpAppointmentDate.TabIndex = 0;
            tpAppointmentDate.Value = new DateTime(2026, 11, 12, 2, 39, 53, 813);
            // 
            // dateHint
            // 
            dateHint.AutoEllipsis = true;
            dateHint.Dock = DockStyle.Fill;
            dateHint.Font = new Font("Segoe UI", 9F);
            dateHint.ForeColor = Color.FromArgb(100, 116, 139);
            dateHint.Location = new Point(0, 188);
            dateHint.Margin = new Padding(0);
            dateHint.Name = "dateHint";
            dateHint.Size = new Size(538, 28);
            dateHint.TabIndex = 4;
            dateHint.Text = "Dates and times are shown in your local time.";
            dateHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bookingNote
            // 
            bookingNote.BackColor = Color.FromArgb(239, 246, 255);
            bookingNote.Dock = DockStyle.Fill;
            bookingNote.Font = new Font("Segoe UI", 10F);
            bookingNote.ForeColor = Color.FromArgb(30, 64, 175);
            bookingNote.Location = new Point(0, 228);
            bookingNote.Margin = new Padding(0, 12, 0, 0);
            bookingNote.Name = "bookingNote";
            bookingNote.Padding = new Padding(12, 8, 12, 8);
            bookingNote.Size = new Size(538, 48);
            bookingNote.TabIndex = 5;
            bookingNote.Text = "Test results are recorded separately after the test.";
            bookingNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // summaryCard
            // 
            summaryCard.BorderColor = Color.FromArgb(222, 229, 238);
            summaryCard.BorderRadius = 12;
            summaryCard.BorderThickness = 1;
            summaryCard.Controls.Add(summaryLayout);
            summaryCard.CustomizableEdges = customizableEdges9;
            summaryCard.Dock = DockStyle.Fill;
            summaryCard.FillColor = Color.White;
            summaryCard.Location = new Point(592, 0);
            summaryCard.Margin = new Padding(0);
            summaryCard.Name = "summaryCard";
            summaryCard.Padding = new Padding(20);
            summaryCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            summaryCard.Size = new Size(363, 316);
            summaryCard.TabIndex = 1;
            // 
            // summaryLayout
            // 
            summaryLayout.BackColor = Color.White;
            summaryLayout.ColumnCount = 1;
            summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            summaryLayout.Controls.Add(summaryTitle, 0, 0);
            summaryLayout.Controls.Add(applicationIdLayout, 0, 1);
            summaryLayout.Controls.Add(licenseCaption, 0, 2);
            summaryLayout.Controls.Add(lblLicenseClass, 0, 3);
            summaryLayout.Controls.Add(applicationTypeCaption, 0, 4);
            summaryLayout.Controls.Add(lblApplicationType, 0, 5);
            summaryLayout.Controls.Add(feesLayout, 0, 6);
            summaryLayout.Dock = DockStyle.Fill;
            summaryLayout.Location = new Point(20, 20);
            summaryLayout.Margin = new Padding(0);
            summaryLayout.Name = "summaryLayout";
            summaryLayout.RowCount = 7;
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            summaryLayout.Size = new Size(323, 276);
            summaryLayout.TabIndex = 0;
            // 
            // summaryTitle
            // 
            summaryTitle.AutoEllipsis = true;
            summaryTitle.Dock = DockStyle.Fill;
            summaryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            summaryTitle.ForeColor = Color.FromArgb(15, 23, 42);
            summaryTitle.Location = new Point(0, 0);
            summaryTitle.Margin = new Padding(0);
            summaryTitle.Name = "summaryTitle";
            summaryTitle.Size = new Size(323, 32);
            summaryTitle.TabIndex = 0;
            summaryTitle.Text = "Booking summary";
            summaryTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applicationIdLayout
            // 
            applicationIdLayout.BackColor = Color.White;
            applicationIdLayout.ColumnCount = 2;
            applicationIdLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            applicationIdLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            applicationIdLayout.Controls.Add(applicationIdCaption, 0, 0);
            applicationIdLayout.Controls.Add(lblLocalApplicationID, 1, 0);
            applicationIdLayout.Dock = DockStyle.Fill;
            applicationIdLayout.Location = new Point(0, 32);
            applicationIdLayout.Margin = new Padding(0);
            applicationIdLayout.Name = "applicationIdLayout";
            applicationIdLayout.RowCount = 1;
            applicationIdLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicationIdLayout.Size = new Size(323, 32);
            applicationIdLayout.TabIndex = 1;
            // 
            // applicationIdCaption
            // 
            applicationIdCaption.AutoEllipsis = true;
            applicationIdCaption.Dock = DockStyle.Fill;
            applicationIdCaption.Font = new Font("Segoe UI", 9F);
            applicationIdCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationIdCaption.Location = new Point(0, 0);
            applicationIdCaption.Margin = new Padding(0);
            applicationIdCaption.Name = "applicationIdCaption";
            applicationIdCaption.Size = new Size(209, 32);
            applicationIdCaption.TabIndex = 0;
            applicationIdCaption.Text = "Application ID";
            applicationIdCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocalApplicationID
            // 
            lblLocalApplicationID.AutoEllipsis = true;
            lblLocalApplicationID.Dock = DockStyle.Fill;
            lblLocalApplicationID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLocalApplicationID.ForeColor = Color.FromArgb(15, 23, 42);
            lblLocalApplicationID.Location = new Point(209, 0);
            lblLocalApplicationID.Margin = new Padding(0);
            lblLocalApplicationID.Name = "lblLocalApplicationID";
            lblLocalApplicationID.Size = new Size(114, 32);
            lblLocalApplicationID.TabIndex = 1;
            lblLocalApplicationID.Text = "—";
            lblLocalApplicationID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // licenseCaption
            // 
            licenseCaption.AutoEllipsis = true;
            licenseCaption.Dock = DockStyle.Fill;
            licenseCaption.Font = new Font("Segoe UI", 9F);
            licenseCaption.ForeColor = Color.FromArgb(100, 116, 139);
            licenseCaption.Location = new Point(0, 64);
            licenseCaption.Margin = new Padding(0);
            licenseCaption.Name = "licenseCaption";
            licenseCaption.Size = new Size(323, 22);
            licenseCaption.TabIndex = 2;
            licenseCaption.Text = "License class";
            licenseCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLicenseClass
            // 
            lblLicenseClass.AutoEllipsis = true;
            lblLicenseClass.Dock = DockStyle.Fill;
            lblLicenseClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLicenseClass.ForeColor = Color.FromArgb(15, 23, 42);
            lblLicenseClass.Location = new Point(0, 86);
            lblLicenseClass.Margin = new Padding(0);
            lblLicenseClass.Name = "lblLicenseClass";
            lblLicenseClass.Size = new Size(323, 38);
            lblLicenseClass.TabIndex = 3;
            lblLicenseClass.Text = "—";
            lblLicenseClass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applicationTypeCaption
            // 
            applicationTypeCaption.AutoEllipsis = true;
            applicationTypeCaption.Dock = DockStyle.Fill;
            applicationTypeCaption.Font = new Font("Segoe UI", 9F);
            applicationTypeCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationTypeCaption.Location = new Point(0, 124);
            applicationTypeCaption.Margin = new Padding(0);
            applicationTypeCaption.Name = "applicationTypeCaption";
            applicationTypeCaption.Size = new Size(323, 22);
            applicationTypeCaption.TabIndex = 4;
            applicationTypeCaption.Text = "Application type";
            applicationTypeCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblApplicationType
            // 
            lblApplicationType.AutoEllipsis = true;
            lblApplicationType.Dock = DockStyle.Fill;
            lblApplicationType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApplicationType.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationType.Location = new Point(0, 146);
            lblApplicationType.Margin = new Padding(0);
            lblApplicationType.Name = "lblApplicationType";
            lblApplicationType.Size = new Size(323, 40);
            lblApplicationType.TabIndex = 5;
            lblApplicationType.Text = "—";
            lblApplicationType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // feesLayout
            // 
            feesLayout.BackColor = Color.White;
            feesLayout.ColumnCount = 2;
            feesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            feesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            feesLayout.Controls.Add(feesCaption, 0, 0);
            feesLayout.Controls.Add(attemptsCaption, 1, 0);
            feesLayout.Controls.Add(lblFees, 0, 1);
            feesLayout.Controls.Add(lblTrail, 1, 1);
            feesLayout.Dock = DockStyle.Fill;
            feesLayout.Location = new Point(0, 186);
            feesLayout.Margin = new Padding(0);
            feesLayout.Name = "feesLayout";
            feesLayout.Padding = new Padding(0, 10, 0, 0);
            feesLayout.RowCount = 2;
            feesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            feesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            feesLayout.Size = new Size(323, 90);
            feesLayout.TabIndex = 6;
            // 
            // feesCaption
            // 
            feesCaption.AutoEllipsis = true;
            feesCaption.Dock = DockStyle.Fill;
            feesCaption.Font = new Font("Segoe UI", 9F);
            feesCaption.ForeColor = Color.FromArgb(100, 116, 139);
            feesCaption.Location = new Point(0, 10);
            feesCaption.Margin = new Padding(0);
            feesCaption.Name = "feesCaption";
            feesCaption.Size = new Size(161, 24);
            feesCaption.TabIndex = 0;
            feesCaption.Text = "Test fee";
            feesCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // attemptsCaption
            // 
            attemptsCaption.AutoEllipsis = true;
            attemptsCaption.Dock = DockStyle.Fill;
            attemptsCaption.Font = new Font("Segoe UI", 9F);
            attemptsCaption.ForeColor = Color.FromArgb(100, 116, 139);
            attemptsCaption.Location = new Point(161, 10);
            attemptsCaption.Margin = new Padding(0);
            attemptsCaption.Name = "attemptsCaption";
            attemptsCaption.Size = new Size(162, 24);
            attemptsCaption.TabIndex = 1;
            attemptsCaption.Text = "Previous attempts";
            attemptsCaption.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFees
            // 
            lblFees.AutoEllipsis = true;
            lblFees.Dock = DockStyle.Fill;
            lblFees.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFees.ForeColor = Color.FromArgb(37, 99, 235);
            lblFees.Location = new Point(0, 34);
            lblFees.Margin = new Padding(0);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(161, 56);
            lblFees.TabIndex = 2;
            lblFees.Text = "—";
            lblFees.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTrail
            // 
            lblTrail.AutoEllipsis = true;
            lblTrail.Dock = DockStyle.Fill;
            lblTrail.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTrail.ForeColor = Color.FromArgb(15, 23, 42);
            lblTrail.Location = new Point(161, 34);
            lblTrail.Margin = new Padding(0);
            lblTrail.Name = "lblTrail";
            lblTrail.Size = new Size(162, 56);
            lblTrail.TabIndex = 3;
            lblTrail.Text = "—";
            lblTrail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(footerHint);
            footerPanel.Controls.Add(footerActions);
            footerPanel.Dock = DockStyle.Fill;
            footerPanel.Location = new Point(24, 540);
            footerPanel.Margin = new Padding(0);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 14, 0, 0);
            footerPanel.Size = new Size(955, 64);
            footerPanel.TabIndex = 3;
            // 
            // footerHint
            // 
            footerHint.AutoEllipsis = true;
            footerHint.Dock = DockStyle.Fill;
            footerHint.Font = new Font("Segoe UI", 9F);
            footerHint.ForeColor = Color.FromArgb(100, 116, 139);
            footerHint.Location = new Point(0, 14);
            footerHint.Margin = new Padding(0);
            footerHint.Name = "footerHint";
            footerHint.Size = new Size(645, 50);
            footerHint.TabIndex = 0;
            footerHint.Text = "Review the details before saving.";
            footerHint.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // footerActions
            // 
            footerActions.Controls.Add(SaveButton);
            footerActions.Dock = DockStyle.Right;
            footerActions.Location = new Point(645, 14);
            footerActions.Margin = new Padding(0);
            footerActions.Name = "footerActions";
            footerActions.Size = new Size(310, 50);
            footerActions.TabIndex = 1;
            footerActions.WrapContents = false;
            // 
            // SaveButton
            // 
            SaveButton.BorderRadius = 8;
            SaveButton.Cursor = Cursors.Hand;
            SaveButton.CustomizableEdges = customizableEdges11;
            SaveButton.DisabledState.FillColor = Color.FromArgb(148, 163, 184);
            SaveButton.DisabledState.FillColor2 = Color.FromArgb(148, 163, 184);
            SaveButton.DisabledState.ForeColor = Color.White;
            SaveButton.FillColor = Color.FromArgb(37, 99, 235);
            SaveButton.FillColor2 = Color.FromArgb(37, 99, 235);
            SaveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            SaveButton.ForeColor = Color.White;
            SaveButton.Location = new Point(0, 0);
            SaveButton.Margin = new Padding(0);
            SaveButton.Name = "SaveButton";
            SaveButton.ShadowDecoration.CustomizableEdges = customizableEdges12;
            SaveButton.Size = new Size(185, 42);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save appointment";
            SaveButton.Click += SaveButton_Click;
            // 
            // ScheduleTestControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 246, 251);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "ScheduleTestControl";
            Size = new Size(1003, 637);
            pageLayout.ResumeLayout(false);
            headingLayout.ResumeLayout(false);
            applicantCard.ResumeLayout(false);
            applicantLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            identityLayout.ResumeLayout(false);
            birthLayout.ResumeLayout(false);
            ageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            appointmentCard.ResumeLayout(false);
            bookingLayout.ResumeLayout(false);
            summaryCard.ResumeLayout(false);
            summaryLayout.ResumeLayout(false);
            applicationIdLayout.ResumeLayout(false);
            feesLayout.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button NationalNoButton = null!;
        private TableLayoutPanel birthLayout = null!;
        private Label birthCaption = null!;
        private Label lblDateOfBirth = null!;
        private TableLayoutPanel ageLayout = null!;
        private Label ageCaption = null!;
        private Label lblAge = null!;
        private TableLayoutPanel contentLayout = null!;
        private Guna.UI2.WinForms.Guna2Panel appointmentCard = null!;
        private TableLayoutPanel bookingLayout = null!;
        private Label bookingTitle = null!;
        private Label lblTestName = null!;
        private Label bookingDescription = null!;
        private Label dateCaption = null!;
        private Guna.UI2.WinForms.Guna2DateTimePicker tpAppointmentDate = null!;
        private Label dateHint = null!;
        private Label bookingNote = null!;
        private Guna.UI2.WinForms.Guna2Panel summaryCard = null!;
        private TableLayoutPanel summaryLayout = null!;
        private Label summaryTitle = null!;
        private TableLayoutPanel applicationIdLayout = null!;
        private Label applicationIdCaption = null!;
        private Label lblLocalApplicationID = null!;
        private Label licenseCaption = null!;
        private Label lblLicenseClass = null!;
        private Label applicationTypeCaption = null!;
        private Label lblApplicationType = null!;
        private TableLayoutPanel feesLayout = null!;
        private Label feesCaption = null!;
        private Label attemptsCaption = null!;
        private Label lblFees = null!;
        private Label lblTrail = null!;
        private Panel footerPanel = null!;
        private Label footerHint = null!;
        private FlowLayoutPanel footerActions = null!;
        private Guna.UI2.WinForms.Guna2GradientButton SaveButton = null!;
    }
}

