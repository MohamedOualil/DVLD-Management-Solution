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
            components = new System.ComponentModel.Container();
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
            CancelButton = new Guna.UI2.WinForms.Guna2GradientButton();
            SaveButton = new Guna.UI2.WinForms.Guna2GradientButton();
            SuspendLayout();
            // pageLayout
            pageLayout.Name = "pageLayout";
            pageLayout.Dock = DockStyle.Top;
            pageLayout.ColumnCount = 1;
            pageLayout.RowCount = 4;
            pageLayout.Margin = new Padding(0);
            pageLayout.AutoSize = true;
            pageLayout.Padding = new Padding(24, 16, 24, 16);
            pageLayout.MinimumSize = new Size(750, 0);
            // headingLayout
            headingLayout.Name = "headingLayout";
            headingLayout.Dock = DockStyle.Fill;
            headingLayout.ColumnCount = 1;
            headingLayout.RowCount = 2;
            headingLayout.Margin = new Padding(0);
            headingLayout.Padding = new Padding(0, 0, 0, 12);
            // pageTitle
            pageTitle.Name = "pageTitle";
            pageTitle.Text = "Schedule test appointment";
            pageTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            pageTitle.ForeColor = Color.FromArgb(15, 23, 42);
            pageTitle.AutoEllipsis = true;
            pageTitle.Dock = DockStyle.Fill;
            pageTitle.TextAlign = ContentAlignment.MiddleLeft;
            pageTitle.Margin = new Padding(0);
            // pageSubtitle
            pageSubtitle.Name = "pageSubtitle";
            pageSubtitle.Text = "Choose a date and time, then review the booking details.";
            pageSubtitle.Font = new Font("Segoe UI", 10F);
            pageSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            pageSubtitle.AutoEllipsis = true;
            pageSubtitle.Dock = DockStyle.Fill;
            pageSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            pageSubtitle.Margin = new Padding(0);
            // applicantCard
            applicantCard.Name = "applicantCard";
            applicantCard.Dock = DockStyle.Fill;
            applicantCard.FillColor = Color.White;
            applicantCard.BorderColor = Color.FromArgb(222, 229, 238);
            applicantCard.BorderRadius = 12;
            applicantCard.BorderThickness = 1;
            applicantCard.Padding = new Padding(20);
            applicantCard.Margin = new Padding(0, 0, 0, 12);
            // applicantLayout
            applicantLayout.Name = "applicantLayout";
            applicantLayout.Dock = DockStyle.Fill;
            applicantLayout.ColumnCount = 4;
            applicantLayout.RowCount = 1;
            applicantLayout.Margin = new Padding(0);
            // pbPhoto
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Dock = DockStyle.Fill;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.Margin = new Padding(0, 0, 16, 0);
            pbPhoto.TabStop = false;
            // identityLayout
            identityLayout.Name = "identityLayout";
            identityLayout.Dock = DockStyle.Fill;
            identityLayout.ColumnCount = 1;
            identityLayout.RowCount = 2;
            identityLayout.Margin = new Padding(0);
            // lblFullName
            lblFullName.Name = "lblFullName";
            lblFullName.Text = "Applicant name";
            lblFullName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(15, 23, 42);
            lblFullName.AutoEllipsis = true;
            lblFullName.Dock = DockStyle.Fill;
            lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            lblFullName.Margin = new Padding(0);
            // NationalNoButton
            NationalNoButton.Name = "NationalNoButton";
            NationalNoButton.Text = "National number";
            NationalNoButton.Dock = DockStyle.Left;
            NationalNoButton.Width = 160;
            NationalNoButton.Height = 28;
            NationalNoButton.FillColor = Color.FromArgb(235, 242, 255);
            NationalNoButton.ForeColor = Color.FromArgb(37, 99, 235);
            NationalNoButton.BorderRadius = 12;
            NationalNoButton.Font = new Font("Segoe UI", 9F);
            NationalNoButton.TabStop = false;
            NationalNoButton.Cursor = Cursors.Default;
            NationalNoButton.Margin = new Padding(0, 4, 0, 0);
            NationalNoButton.TextAlign = HorizontalAlignment.Left;
            // birthLayout
            birthLayout.Name = "birthLayout";
            birthLayout.Dock = DockStyle.Fill;
            birthLayout.ColumnCount = 1;
            birthLayout.RowCount = 2;
            birthLayout.Margin = new Padding(16, 0, 0, 0);
            // birthCaption
            birthCaption.Name = "birthCaption";
            birthCaption.Text = "Date of birth";
            birthCaption.Font = new Font("Segoe UI", 9F);
            birthCaption.ForeColor = Color.FromArgb(100, 116, 139);
            birthCaption.AutoEllipsis = true;
            birthCaption.Dock = DockStyle.Fill;
            birthCaption.TextAlign = ContentAlignment.MiddleLeft;
            birthCaption.Margin = new Padding(0);
            // lblDateOfBirth
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Text = "—";
            lblDateOfBirth.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDateOfBirth.ForeColor = Color.FromArgb(15, 23, 42);
            lblDateOfBirth.AutoEllipsis = true;
            lblDateOfBirth.Dock = DockStyle.Fill;
            lblDateOfBirth.TextAlign = ContentAlignment.MiddleLeft;
            lblDateOfBirth.Margin = new Padding(0);
            // ageLayout
            ageLayout.Name = "ageLayout";
            ageLayout.Dock = DockStyle.Fill;
            ageLayout.ColumnCount = 1;
            ageLayout.RowCount = 2;
            ageLayout.Margin = new Padding(16, 0, 0, 0);
            // ageCaption
            ageCaption.Name = "ageCaption";
            ageCaption.Text = "Age";
            ageCaption.Font = new Font("Segoe UI", 9F);
            ageCaption.ForeColor = Color.FromArgb(100, 116, 139);
            ageCaption.AutoEllipsis = true;
            ageCaption.Dock = DockStyle.Fill;
            ageCaption.TextAlign = ContentAlignment.MiddleLeft;
            ageCaption.Margin = new Padding(0);
            // lblAge
            lblAge.Name = "lblAge";
            lblAge.Text = "—";
            lblAge.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAge.ForeColor = Color.FromArgb(15, 23, 42);
            lblAge.AutoEllipsis = true;
            lblAge.Dock = DockStyle.Fill;
            lblAge.TextAlign = ContentAlignment.MiddleLeft;
            lblAge.Margin = new Padding(0);
            // contentLayout
            contentLayout.Name = "contentLayout";
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.ColumnCount = 2;
            contentLayout.RowCount = 1;
            contentLayout.Margin = new Padding(0);
            // appointmentCard
            appointmentCard.Name = "appointmentCard";
            appointmentCard.Dock = DockStyle.Fill;
            appointmentCard.FillColor = Color.White;
            appointmentCard.BorderColor = Color.FromArgb(222, 229, 238);
            appointmentCard.BorderRadius = 12;
            appointmentCard.BorderThickness = 1;
            appointmentCard.Padding = new Padding(20);
            appointmentCard.Margin = new Padding(0, 0, 14, 0);
            // bookingLayout
            bookingLayout.Name = "bookingLayout";
            bookingLayout.Dock = DockStyle.Fill;
            bookingLayout.ColumnCount = 1;
            bookingLayout.RowCount = 7;
            bookingLayout.Margin = new Padding(0);
            // bookingTitle
            bookingTitle.Name = "bookingTitle";
            bookingTitle.Text = "Appointment details";
            bookingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bookingTitle.ForeColor = Color.FromArgb(15, 23, 42);
            bookingTitle.AutoEllipsis = true;
            bookingTitle.Dock = DockStyle.Fill;
            bookingTitle.TextAlign = ContentAlignment.MiddleLeft;
            bookingTitle.Margin = new Padding(0);
            // lblTestName
            lblTestName.Name = "lblTestName";
            lblTestName.Text = "Test name";
            lblTestName.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTestName.ForeColor = Color.FromArgb(37, 99, 235);
            lblTestName.AutoEllipsis = true;
            lblTestName.Dock = DockStyle.Fill;
            lblTestName.TextAlign = ContentAlignment.MiddleLeft;
            lblTestName.Margin = new Padding(0);
            // bookingDescription
            bookingDescription.Name = "bookingDescription";
            bookingDescription.Text = "Select when the applicant will take this test.";
            bookingDescription.Font = new Font("Segoe UI", 10F);
            bookingDescription.ForeColor = Color.FromArgb(100, 116, 139);
            bookingDescription.AutoEllipsis = true;
            bookingDescription.Dock = DockStyle.Fill;
            bookingDescription.TextAlign = ContentAlignment.MiddleLeft;
            bookingDescription.Margin = new Padding(0);
            // dateCaption
            dateCaption.Name = "dateCaption";
            dateCaption.Text = "Appointment date and time";
            dateCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dateCaption.ForeColor = Color.FromArgb(15, 23, 42);
            dateCaption.AutoEllipsis = true;
            dateCaption.Dock = DockStyle.Fill;
            dateCaption.TextAlign = ContentAlignment.MiddleLeft;
            dateCaption.Margin = new Padding(0);
            // tpAppointmentDate
            tpAppointmentDate.Name = "tpAppointmentDate";
            tpAppointmentDate.Dock = DockStyle.Fill;
            tpAppointmentDate.FillColor = Color.FromArgb(248, 250, 252);
            tpAppointmentDate.ForeColor = Color.FromArgb(15, 23, 42);
            tpAppointmentDate.BorderColor = Color.FromArgb(203, 213, 225);
            tpAppointmentDate.BorderThickness = 1;
            tpAppointmentDate.BorderRadius = 8;
            tpAppointmentDate.Font = new Font("Segoe UI", 11F);
            tpAppointmentDate.Format = DateTimePickerFormat.Custom;
            tpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            tpAppointmentDate.Checked = true;
            tpAppointmentDate.Margin = new Padding(0, 4, 0, 4);
            tpAppointmentDate.TabIndex = 0;
            // dateHint
            dateHint.Name = "dateHint";
            dateHint.Text = "Dates and times are shown in your local time.";
            dateHint.Font = new Font("Segoe UI", 9F);
            dateHint.ForeColor = Color.FromArgb(100, 116, 139);
            dateHint.AutoEllipsis = true;
            dateHint.Dock = DockStyle.Fill;
            dateHint.TextAlign = ContentAlignment.MiddleLeft;
            dateHint.Margin = new Padding(0);
            // bookingNote
            bookingNote.Name = "bookingNote";
            bookingNote.Text = "Test results are recorded separately after the test.";
            bookingNote.Font = new Font("Segoe UI", 10F);
            bookingNote.ForeColor = Color.FromArgb(30, 64, 175);
            bookingNote.AutoEllipsis = false;
            bookingNote.Dock = DockStyle.Fill;
            bookingNote.TextAlign = ContentAlignment.MiddleLeft;
            bookingNote.Margin = new Padding(0, 12, 0, 0);
            bookingNote.BackColor = Color.FromArgb(239, 246, 255);
            bookingNote.Padding = new Padding(12, 8, 12, 8);
            // summaryCard
            summaryCard.Name = "summaryCard";
            summaryCard.Dock = DockStyle.Fill;
            summaryCard.FillColor = Color.White;
            summaryCard.BorderColor = Color.FromArgb(222, 229, 238);
            summaryCard.BorderRadius = 12;
            summaryCard.BorderThickness = 1;
            summaryCard.Padding = new Padding(20);
            summaryCard.Margin = new Padding(0);
            // summaryLayout
            summaryLayout.Name = "summaryLayout";
            summaryLayout.Dock = DockStyle.Fill;
            summaryLayout.ColumnCount = 1;
            summaryLayout.RowCount = 7;
            summaryLayout.Margin = new Padding(0);
            // summaryTitle
            summaryTitle.Name = "summaryTitle";
            summaryTitle.Text = "Booking summary";
            summaryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            summaryTitle.ForeColor = Color.FromArgb(15, 23, 42);
            summaryTitle.AutoEllipsis = true;
            summaryTitle.Dock = DockStyle.Fill;
            summaryTitle.TextAlign = ContentAlignment.MiddleLeft;
            summaryTitle.Margin = new Padding(0);
            // applicationIdLayout
            applicationIdLayout.Name = "applicationIdLayout";
            applicationIdLayout.Dock = DockStyle.Fill;
            applicationIdLayout.ColumnCount = 2;
            applicationIdLayout.RowCount = 1;
            applicationIdLayout.Margin = new Padding(0);
            // applicationIdCaption
            applicationIdCaption.Name = "applicationIdCaption";
            applicationIdCaption.Text = "Application ID";
            applicationIdCaption.Font = new Font("Segoe UI", 9F);
            applicationIdCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationIdCaption.AutoEllipsis = true;
            applicationIdCaption.Dock = DockStyle.Fill;
            applicationIdCaption.TextAlign = ContentAlignment.MiddleLeft;
            applicationIdCaption.Margin = new Padding(0);
            // lblLocalApplicationID
            lblLocalApplicationID.Name = "lblLocalApplicationID";
            lblLocalApplicationID.Text = "—";
            lblLocalApplicationID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLocalApplicationID.ForeColor = Color.FromArgb(15, 23, 42);
            lblLocalApplicationID.AutoEllipsis = true;
            lblLocalApplicationID.Dock = DockStyle.Fill;
            lblLocalApplicationID.TextAlign = ContentAlignment.MiddleRight;
            lblLocalApplicationID.Margin = new Padding(0);
            // licenseCaption
            licenseCaption.Name = "licenseCaption";
            licenseCaption.Text = "License class";
            licenseCaption.Font = new Font("Segoe UI", 9F);
            licenseCaption.ForeColor = Color.FromArgb(100, 116, 139);
            licenseCaption.AutoEllipsis = true;
            licenseCaption.Dock = DockStyle.Fill;
            licenseCaption.TextAlign = ContentAlignment.MiddleLeft;
            licenseCaption.Margin = new Padding(0);
            // lblLicenseClass
            lblLicenseClass.Name = "lblLicenseClass";
            lblLicenseClass.Text = "—";
            lblLicenseClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLicenseClass.ForeColor = Color.FromArgb(15, 23, 42);
            lblLicenseClass.AutoEllipsis = true;
            lblLicenseClass.Dock = DockStyle.Fill;
            lblLicenseClass.TextAlign = ContentAlignment.MiddleLeft;
            lblLicenseClass.Margin = new Padding(0);
            // applicationTypeCaption
            applicationTypeCaption.Name = "applicationTypeCaption";
            applicationTypeCaption.Text = "Application type";
            applicationTypeCaption.Font = new Font("Segoe UI", 9F);
            applicationTypeCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationTypeCaption.AutoEllipsis = true;
            applicationTypeCaption.Dock = DockStyle.Fill;
            applicationTypeCaption.TextAlign = ContentAlignment.MiddleLeft;
            applicationTypeCaption.Margin = new Padding(0);
            // lblApplicationType
            lblApplicationType.Name = "lblApplicationType";
            lblApplicationType.Text = "—";
            lblApplicationType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApplicationType.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationType.AutoEllipsis = true;
            lblApplicationType.Dock = DockStyle.Fill;
            lblApplicationType.TextAlign = ContentAlignment.MiddleLeft;
            lblApplicationType.Margin = new Padding(0);
            // feesLayout
            feesLayout.Name = "feesLayout";
            feesLayout.Dock = DockStyle.Fill;
            feesLayout.ColumnCount = 2;
            feesLayout.RowCount = 2;
            feesLayout.Margin = new Padding(0);
            feesLayout.Padding = new Padding(0, 10, 0, 0);
            // feesCaption
            feesCaption.Name = "feesCaption";
            feesCaption.Text = "Test fee";
            feesCaption.Font = new Font("Segoe UI", 9F);
            feesCaption.ForeColor = Color.FromArgb(100, 116, 139);
            feesCaption.AutoEllipsis = true;
            feesCaption.Dock = DockStyle.Fill;
            feesCaption.TextAlign = ContentAlignment.MiddleLeft;
            feesCaption.Margin = new Padding(0);
            // attemptsCaption
            attemptsCaption.Name = "attemptsCaption";
            attemptsCaption.Text = "Previous attempts";
            attemptsCaption.Font = new Font("Segoe UI", 9F);
            attemptsCaption.ForeColor = Color.FromArgb(100, 116, 139);
            attemptsCaption.AutoEllipsis = true;
            attemptsCaption.Dock = DockStyle.Fill;
            attemptsCaption.TextAlign = ContentAlignment.MiddleRight;
            attemptsCaption.Margin = new Padding(0);
            // lblFees
            lblFees.Name = "lblFees";
            lblFees.Text = "—";
            lblFees.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFees.ForeColor = Color.FromArgb(37, 99, 235);
            lblFees.AutoEllipsis = true;
            lblFees.Dock = DockStyle.Fill;
            lblFees.TextAlign = ContentAlignment.MiddleLeft;
            lblFees.Margin = new Padding(0);
            // lblTrail
            lblTrail.Name = "lblTrail";
            lblTrail.Text = "—";
            lblTrail.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTrail.ForeColor = Color.FromArgb(15, 23, 42);
            lblTrail.AutoEllipsis = true;
            lblTrail.Dock = DockStyle.Fill;
            lblTrail.TextAlign = ContentAlignment.MiddleRight;
            lblTrail.Margin = new Padding(0);
            // footerPanel
            footerPanel.Name = "footerPanel";
            footerPanel.Dock = DockStyle.Fill;
            footerPanel.Margin = new Padding(0);
            footerPanel.Padding = new Padding(0, 14, 0, 0);
            // footerHint
            footerHint.Name = "footerHint";
            footerHint.Text = "Review the details before saving.";
            footerHint.Font = new Font("Segoe UI", 9F);
            footerHint.ForeColor = Color.FromArgb(100, 116, 139);
            footerHint.AutoEllipsis = true;
            footerHint.Dock = DockStyle.Fill;
            footerHint.TextAlign = ContentAlignment.MiddleLeft;
            footerHint.Margin = new Padding(0);
            // footerActions
            footerActions.Name = "footerActions";
            footerActions.Dock = DockStyle.Right;
            footerActions.Width = 310;
            footerActions.FlowDirection = FlowDirection.LeftToRight;
            footerActions.WrapContents = false;
            footerActions.Margin = new Padding(0);
            footerActions.Padding = new Padding(0);
            footerActions.TabIndex = 1;
            // CancelButton
            CancelButton.Name = "CancelButton";
            CancelButton.Text = "Cancel";
            CancelButton.Size = new Size(110, 42);
            CancelButton.FillColor = Color.White;
            CancelButton.FillColor2 = Color.White;
            CancelButton.ForeColor = Color.FromArgb(100, 116, 139);
            CancelButton.BorderColor = Color.FromArgb(203, 213, 225);
            CancelButton.BorderThickness = 1;
            CancelButton.BorderRadius = 8;
            CancelButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CancelButton.Margin = new Padding(0, 0, 12, 0);
            CancelButton.TabIndex = 2;
            CancelButton.Cursor = Cursors.Hand;
            // SaveButton
            SaveButton.Name = "SaveButton";
            SaveButton.Text = "Save appointment";
            SaveButton.Size = new Size(185, 42);
            SaveButton.FillColor = Color.FromArgb(37, 99, 235);
            SaveButton.FillColor2 = Color.FromArgb(37, 99, 235);
            SaveButton.ForeColor = Color.White;
            SaveButton.BorderRadius = 8;
            SaveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            SaveButton.Margin = new Padding(0);
            SaveButton.TabIndex = 1;
            SaveButton.Cursor = Cursors.Hand;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 316F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            headingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            headingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            applicantLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            identityLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            identityLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            identityLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            birthLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            birthLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            birthLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            ageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bookingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            bookingLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            summaryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicationIdLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            applicationIdLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            applicationIdLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            feesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            feesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            feesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            feesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headingLayout, 0, 0);
            pageLayout.Controls.Add(applicantCard, 0, 1);
            pageLayout.Controls.Add(contentLayout, 0, 2);
            pageLayout.Controls.Add(footerPanel, 0, 3);
            headingLayout.Controls.Add(pageTitle, 0, 0);
            headingLayout.Controls.Add(pageSubtitle, 0, 1);
            applicantCard.Controls.Add(applicantLayout);
            applicantLayout.Controls.Add(pbPhoto, 0, 0);
            applicantLayout.Controls.Add(identityLayout, 1, 0);
            applicantLayout.Controls.Add(birthLayout, 2, 0);
            applicantLayout.Controls.Add(ageLayout, 3, 0);
            identityLayout.Controls.Add(lblFullName, 0, 0);
            identityLayout.Controls.Add(NationalNoButton, 0, 1);
            birthLayout.Controls.Add(birthCaption, 0, 0);
            birthLayout.Controls.Add(lblDateOfBirth, 0, 1);
            ageLayout.Controls.Add(ageCaption, 0, 0);
            ageLayout.Controls.Add(lblAge, 0, 1);
            contentLayout.Controls.Add(appointmentCard, 0, 0);
            contentLayout.Controls.Add(summaryCard, 1, 0);
            appointmentCard.Controls.Add(bookingLayout);
            bookingLayout.Controls.Add(bookingTitle, 0, 0);
            bookingLayout.Controls.Add(lblTestName, 0, 1);
            bookingLayout.Controls.Add(bookingDescription, 0, 2);
            bookingLayout.Controls.Add(dateCaption, 0, 3);
            bookingLayout.Controls.Add(tpAppointmentDate, 0, 4);
            bookingLayout.Controls.Add(dateHint, 0, 5);
            bookingLayout.Controls.Add(bookingNote, 0, 6);
            summaryCard.Controls.Add(summaryLayout);
            summaryLayout.Controls.Add(summaryTitle, 0, 0);
            summaryLayout.Controls.Add(applicationIdLayout, 0, 1);
            summaryLayout.Controls.Add(licenseCaption, 0, 2);
            summaryLayout.Controls.Add(lblLicenseClass, 0, 3);
            summaryLayout.Controls.Add(applicationTypeCaption, 0, 4);
            summaryLayout.Controls.Add(lblApplicationType, 0, 5);
            summaryLayout.Controls.Add(feesLayout, 0, 6);
            applicationIdLayout.Controls.Add(applicationIdCaption, 0, 0);
            applicationIdLayout.Controls.Add(lblLocalApplicationID, 1, 0);
            feesLayout.Controls.Add(feesCaption, 0, 0);
            feesLayout.Controls.Add(attemptsCaption, 1, 0);
            feesLayout.Controls.Add(lblFees, 0, 1);
            feesLayout.Controls.Add(lblTrail, 1, 1);
            footerPanel.Controls.Add(footerHint);
            footerPanel.Controls.Add(footerActions);
            footerActions.Controls.Add(CancelButton);
            footerActions.Controls.Add(SaveButton);
            SaveButton.Click += SaveButton_Click;
            CancelButton.Click += CancelButton_Click;
            SaveButton.DisabledState.FillColor = Color.FromArgb(148, 163, 184);
            SaveButton.DisabledState.FillColor2 = Color.FromArgb(148, 163, 184);
            SaveButton.DisabledState.ForeColor = Color.White;
            NationalNoButton.HoverState.FillColor = Color.FromArgb(235, 242, 255);
            applicantLayout.BackColor = Color.White;
            identityLayout.BackColor = Color.White;
            birthLayout.BackColor = Color.White;
            ageLayout.BackColor = Color.White;
            bookingLayout.BackColor = Color.White;
            summaryLayout.BackColor = Color.White;
            applicationIdLayout.BackColor = Color.White;
            feesLayout.BackColor = Color.White;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 251);
            Font = new Font("Segoe UI", 9F);
            AutoScroll = true;
            Name = "ScheduleTestControl";
            Size = new Size(1003, 637);
            Controls.Add(pageLayout);
            ResumeLayout(true);
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
        private Guna.UI2.WinForms.Guna2GradientButton CancelButton = null!;
        private Guna.UI2.WinForms.Guna2GradientButton SaveButton = null!;
    }
}

