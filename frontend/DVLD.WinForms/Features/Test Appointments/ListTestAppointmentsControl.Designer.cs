#nullable enable
namespace DVLD.WinForms.Features.Test_Appointments
{
    partial class ListTestAppointmentsControl
    {
        private System.ComponentModel.IContainer? components;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            page = new TableLayoutPanel();
            heading = new Panel();
            lblPageTitle = new Label();
            subtitle = new Label();
            applicantCard = new Guna.UI2.WinForms.Guna2Panel();
            applicantLayout = new TableLayoutPanel();
            identity = new Panel();
            avatar = new Label();
            lblFullName = new Label();
            lblNationalNo = new Label();
            application = new Panel();
            lblApplicationId = new Label();
            applicationCaption = new Label();
            licenseClass = new Panel();
            lblLicenseClass = new Label();
            classCaption = new Label();
            status = new Panel();
            lblApplicationStatus = new Label();
            statusCaption = new Label();
            progressCard = new Guna.UI2.WinForms.Guna2Panel();
            progressLayout = new TableLayoutPanel();
            lblVisionProgress = new Label();
            lblWrittenProgress = new Label();
            lblStreetProgress = new Label();
            progressTitle = new Label();
            historyCard = new Guna.UI2.WinForms.Guna2Panel();
            history = new TableLayoutPanel();
            historyHeading = new Panel();
            historyTitle = new Label();
            lblAppointmentCount = new Label();
            CreateAppointmentButton = new Guna.UI2.WinForms.Guna2Button();
            lblMessage = new Label();
            TestAppointmentsDataGridView = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            feesColumn = new DataGridViewTextBoxColumn();
            resultColumn = new DataGridViewTextBoxColumn();
            detailsColumn = new DataGridViewLinkColumn();
            footer = new Label();
            page.SuspendLayout();
            heading.SuspendLayout();
            applicantCard.SuspendLayout();
            applicantLayout.SuspendLayout();
            identity.SuspendLayout();
            application.SuspendLayout();
            licenseClass.SuspendLayout();
            status.SuspendLayout();
            progressCard.SuspendLayout();
            progressLayout.SuspendLayout();
            historyCard.SuspendLayout();
            history.SuspendLayout();
            historyHeading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TestAppointmentsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // page
            // 
            page.AutoSize = true;
            page.ColumnCount = 1;
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(heading, 0, 0);
            page.Controls.Add(applicantCard, 0, 1);
            page.Controls.Add(progressCard, 0, 2);
            page.Controls.Add(historyCard, 0, 3);
            page.Dock = DockStyle.Top;
            page.Location = new Point(0, 0);
            page.Name = "page";
            page.Padding = new Padding(24, 12, 24, 20);
            page.RowCount = 4;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            page.Size = new Size(1003, 658);
            page.TabIndex = 0;
            // 
            // heading
            // 
            heading.Controls.Add(lblPageTitle);
            heading.Controls.Add(subtitle);
            heading.Dock = DockStyle.Fill;
            heading.Location = new Point(24, 12);
            heading.Margin = new Padding(0);
            heading.Name = "heading";
            heading.Size = new Size(955, 92);
            heading.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            lblPageTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPageTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPageTitle.Location = new Point(0, 3);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(850, 36);
            lblPageTitle.TabIndex = 1;
            lblPageTitle.Text = "Test Appointments";
            // 
            // subtitle
            // 
            subtitle.ForeColor = Color.FromArgb(100, 116, 139);
            subtitle.Location = new Point(5, 45);
            subtitle.Name = "subtitle";
            subtitle.Size = new Size(650, 22);
            subtitle.TabIndex = 2;
            subtitle.Text = "Manage bookings and review previous attempts";
            // 
            // applicantCard
            // 
            applicantCard.BorderColor = Color.FromArgb(222, 229, 238);
            applicantCard.BorderRadius = 10;
            applicantCard.BorderThickness = 1;
            applicantCard.Controls.Add(applicantLayout);
            applicantCard.CustomizableEdges = customizableEdges9;
            applicantCard.Dock = DockStyle.Fill;
            applicantCard.FillColor = Color.White;
            applicantCard.Location = new Point(24, 110);
            applicantCard.Margin = new Padding(0, 6, 0, 8);
            applicantCard.Name = "applicantCard";
            applicantCard.Padding = new Padding(18);
            applicantCard.ShadowDecoration.CustomizableEdges = customizableEdges10;
            applicantCard.Size = new Size(955, 108);
            applicantCard.TabIndex = 1;
            // 
            // applicantLayout
            // 
            applicantLayout.BackColor = Color.White;
            applicantLayout.ColumnCount = 4;
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            applicantLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            applicantLayout.Controls.Add(identity, 0, 0);
            applicantLayout.Controls.Add(application, 1, 0);
            applicantLayout.Controls.Add(licenseClass, 2, 0);
            applicantLayout.Controls.Add(status, 3, 0);
            applicantLayout.Dock = DockStyle.Fill;
            applicantLayout.Location = new Point(18, 18);
            applicantLayout.Name = "applicantLayout";
            applicantLayout.RowCount = 1;
            applicantLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            applicantLayout.Size = new Size(919, 72);
            applicantLayout.TabIndex = 0;
            // 
            // identity
            // 
            identity.Controls.Add(avatar);
            identity.Controls.Add(lblFullName);
            identity.Controls.Add(lblNationalNo);
            identity.Dock = DockStyle.Fill;
            identity.Location = new Point(3, 3);
            identity.Name = "identity";
            identity.Size = new Size(324, 66);
            identity.TabIndex = 0;
            // 
            // avatar
            // 
            avatar.BackColor = Color.FromArgb(231, 240, 255);
            avatar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            avatar.ForeColor = Color.FromArgb(37, 99, 235);
            avatar.Location = new Point(0, 6);
            avatar.Name = "avatar";
            avatar.Size = new Size(52, 54);
            avatar.TabIndex = 0;
            avatar.Text = "DV";
            avatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            lblFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFullName.AutoEllipsis = true;
            lblFullName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFullName.Location = new Point(64, 8);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(289, 27);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Loading applicant…";
            // 
            // lblNationalNo
            // 
            lblNationalNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNationalNo.AutoEllipsis = true;
            lblNationalNo.ForeColor = Color.FromArgb(100, 116, 139);
            lblNationalNo.Location = new Point(64, 38);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Size = new Size(289, 24);
            lblNationalNo.TabIndex = 2;
            lblNationalNo.Text = "National No: —";
            // 
            // application
            // 
            application.Controls.Add(lblApplicationId);
            application.Controls.Add(applicationCaption);
            application.Dock = DockStyle.Fill;
            application.Location = new Point(333, 3);
            application.Name = "application";
            application.Size = new Size(141, 66);
            application.TabIndex = 1;
            // 
            // lblApplicationId
            // 
            lblApplicationId.Dock = DockStyle.Fill;
            lblApplicationId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblApplicationId.Location = new Point(0, 30);
            lblApplicationId.Name = "lblApplicationId";
            lblApplicationId.Size = new Size(141, 36);
            lblApplicationId.TabIndex = 0;
            lblApplicationId.Text = "—";
            // 
            // applicationCaption
            // 
            applicationCaption.Dock = DockStyle.Top;
            applicationCaption.ForeColor = Color.FromArgb(100, 116, 139);
            applicationCaption.Location = new Point(0, 0);
            applicationCaption.Name = "applicationCaption";
            applicationCaption.Size = new Size(141, 30);
            applicationCaption.TabIndex = 1;
            applicationCaption.Text = "Application ID";
            // 
            // licenseClass
            // 
            licenseClass.Controls.Add(lblLicenseClass);
            licenseClass.Controls.Add(classCaption);
            licenseClass.Dock = DockStyle.Fill;
            licenseClass.Location = new Point(480, 3);
            licenseClass.Name = "licenseClass";
            licenseClass.Size = new Size(269, 66);
            licenseClass.TabIndex = 2;
            // 
            // lblLicenseClass
            // 
            lblLicenseClass.AutoEllipsis = true;
            lblLicenseClass.Dock = DockStyle.Fill;
            lblLicenseClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLicenseClass.Location = new Point(0, 30);
            lblLicenseClass.Name = "lblLicenseClass";
            lblLicenseClass.Size = new Size(269, 36);
            lblLicenseClass.TabIndex = 0;
            lblLicenseClass.Text = "—";
            // 
            // classCaption
            // 
            classCaption.Dock = DockStyle.Top;
            classCaption.ForeColor = Color.FromArgb(100, 116, 139);
            classCaption.Location = new Point(0, 0);
            classCaption.Name = "classCaption";
            classCaption.Size = new Size(269, 30);
            classCaption.TabIndex = 1;
            classCaption.Text = "License Class";
            // 
            // status
            // 
            status.Controls.Add(lblApplicationStatus);
            status.Controls.Add(statusCaption);
            status.Dock = DockStyle.Fill;
            status.Location = new Point(755, 3);
            status.Name = "status";
            status.Size = new Size(161, 66);
            status.TabIndex = 3;
            // 
            // lblApplicationStatus
            // 
            lblApplicationStatus.BackColor = Color.FromArgb(231, 240, 255);
            lblApplicationStatus.Dock = DockStyle.Fill;
            lblApplicationStatus.ForeColor = Color.FromArgb(37, 99, 235);
            lblApplicationStatus.Location = new Point(0, 30);
            lblApplicationStatus.Name = "lblApplicationStatus";
            lblApplicationStatus.Size = new Size(161, 36);
            lblApplicationStatus.TabIndex = 0;
            lblApplicationStatus.Text = "—";
            lblApplicationStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusCaption
            // 
            statusCaption.Dock = DockStyle.Top;
            statusCaption.ForeColor = Color.FromArgb(100, 116, 139);
            statusCaption.Location = new Point(0, 0);
            statusCaption.Name = "statusCaption";
            statusCaption.Size = new Size(161, 30);
            statusCaption.TabIndex = 1;
            statusCaption.Text = "Application Status";
            // 
            // progressCard
            // 
            progressCard.BorderColor = Color.FromArgb(222, 229, 238);
            progressCard.BorderRadius = 10;
            progressCard.BorderThickness = 1;
            progressCard.Controls.Add(progressLayout);
            progressCard.Controls.Add(progressTitle);
            progressCard.CustomizableEdges = customizableEdges11;
            progressCard.Dock = DockStyle.Fill;
            progressCard.FillColor = Color.White;
            progressCard.Location = new Point(24, 226);
            progressCard.Margin = new Padding(0, 0, 0, 12);
            progressCard.Name = "progressCard";
            progressCard.Padding = new Padding(18, 10, 18, 12);
            progressCard.ShadowDecoration.CustomizableEdges = customizableEdges12;
            progressCard.Size = new Size(955, 100);
            progressCard.TabIndex = 2;
            // 
            // progressLayout
            // 
            progressLayout.BackColor = Color.White;
            progressLayout.ColumnCount = 3;
            progressLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            progressLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            progressLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            progressLayout.Controls.Add(lblVisionProgress, 0, 0);
            progressLayout.Controls.Add(lblWrittenProgress, 1, 0);
            progressLayout.Controls.Add(lblStreetProgress, 2, 0);
            progressLayout.Dock = DockStyle.Fill;
            progressLayout.Location = new Point(18, 36);
            progressLayout.Name = "progressLayout";
            progressLayout.RowCount = 1;
            progressLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            progressLayout.Size = new Size(919, 52);
            progressLayout.TabIndex = 0;
            // 
            // lblVisionProgress
            // 
            lblVisionProgress.Dock = DockStyle.Fill;
            lblVisionProgress.Location = new Point(3, 0);
            lblVisionProgress.Name = "lblVisionProgress";
            lblVisionProgress.Size = new Size(300, 52);
            lblVisionProgress.TabIndex = 0;
            lblVisionProgress.Text = "1  Vision\r\nLoading…";
            lblVisionProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWrittenProgress
            // 
            lblWrittenProgress.Dock = DockStyle.Fill;
            lblWrittenProgress.Location = new Point(309, 0);
            lblWrittenProgress.Name = "lblWrittenProgress";
            lblWrittenProgress.Size = new Size(300, 52);
            lblWrittenProgress.TabIndex = 1;
            lblWrittenProgress.Text = "2  Written\r\nLoading…";
            lblWrittenProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStreetProgress
            // 
            lblStreetProgress.Dock = DockStyle.Fill;
            lblStreetProgress.Location = new Point(615, 0);
            lblStreetProgress.Name = "lblStreetProgress";
            lblStreetProgress.Size = new Size(301, 52);
            lblStreetProgress.TabIndex = 2;
            lblStreetProgress.Text = "3  Street\r\nLoading…";
            lblStreetProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressTitle
            // 
            progressTitle.BackColor = Color.White;
            progressTitle.Dock = DockStyle.Top;
            progressTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            progressTitle.Location = new Point(18, 10);
            progressTitle.Name = "progressTitle";
            progressTitle.Size = new Size(919, 26);
            progressTitle.TabIndex = 1;
            progressTitle.Text = "Test progress";
            // 
            // historyCard
            // 
            historyCard.BorderColor = Color.FromArgb(222, 229, 238);
            historyCard.BorderRadius = 10;
            historyCard.BorderThickness = 1;
            historyCard.Controls.Add(history);
            historyCard.CustomizableEdges = customizableEdges13;
            historyCard.Dock = DockStyle.Fill;
            historyCard.FillColor = Color.White;
            historyCard.Location = new Point(24, 338);
            historyCard.Margin = new Padding(0);
            historyCard.Name = "historyCard";
            historyCard.Padding = new Padding(18, 12, 18, 12);
            historyCard.ShadowDecoration.CustomizableEdges = customizableEdges14;
            historyCard.Size = new Size(955, 300);
            historyCard.TabIndex = 3;
            // 
            // history
            // 
            history.BackColor = Color.White;
            history.ColumnCount = 1;
            history.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            history.Controls.Add(historyHeading, 0, 0);
            history.Controls.Add(lblMessage, 0, 1);
            history.Controls.Add(TestAppointmentsDataGridView, 0, 2);
            history.Controls.Add(footer, 0, 3);
            history.Dock = DockStyle.Fill;
            history.Location = new Point(18, 12);
            history.Name = "history";
            history.RowCount = 4;
            history.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            history.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            history.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            history.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            history.Size = new Size(919, 276);
            history.TabIndex = 0;
            // 
            // historyHeading
            // 
            historyHeading.Controls.Add(historyTitle);
            historyHeading.Controls.Add(lblAppointmentCount);
            historyHeading.Controls.Add(CreateAppointmentButton);
            historyHeading.Dock = DockStyle.Fill;
            historyHeading.Location = new Point(0, 0);
            historyHeading.Margin = new Padding(0);
            historyHeading.Name = "historyHeading";
            historyHeading.Size = new Size(919, 58);
            historyHeading.TabIndex = 0;
            // 
            // historyTitle
            // 
            historyTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            historyTitle.Location = new Point(0, 0);
            historyTitle.Name = "historyTitle";
            historyTitle.Size = new Size(350, 28);
            historyTitle.TabIndex = 0;
            historyTitle.Text = "Appointment History";
            // 
            // lblAppointmentCount
            // 
            lblAppointmentCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblAppointmentCount.Location = new Point(0, 30);
            lblAppointmentCount.Name = "lblAppointmentCount";
            lblAppointmentCount.Size = new Size(400, 22);
            lblAppointmentCount.TabIndex = 1;
            lblAppointmentCount.Text = "Loading appointments…";
            // 
            // CreateAppointmentButton
            // 
            CreateAppointmentButton.BorderRadius = 7;
            CreateAppointmentButton.CustomizableEdges = customizableEdges15;
            CreateAppointmentButton.DisabledState.FillColor = Color.FromArgb(239, 243, 248);
            CreateAppointmentButton.DisabledState.ForeColor = Color.FromArgb(135, 148, 165);
            CreateAppointmentButton.Dock = DockStyle.Right;
            CreateAppointmentButton.Enabled = false;
            CreateAppointmentButton.FillColor = Color.FromArgb(37, 99, 235);
            CreateAppointmentButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CreateAppointmentButton.ForeColor = Color.White;
            CreateAppointmentButton.Location = new Point(729, 0);
            CreateAppointmentButton.Name = "CreateAppointmentButton";
            CreateAppointmentButton.ShadowDecoration.CustomizableEdges = customizableEdges16;
            CreateAppointmentButton.Size = new Size(190, 58);
            CreateAppointmentButton.TabIndex = 2;
            CreateAppointmentButton.Text = "+  New Appointment";
            CreateAppointmentButton.Click += CreateAppointmentButton_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoEllipsis = true;
            lblMessage.BackColor = Color.FromArgb(231, 240, 255);
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.ForeColor = Color.FromArgb(37, 99, 235);
            lblMessage.Location = new Point(0, 60);
            lblMessage.Margin = new Padding(0, 2, 0, 6);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new Padding(10, 0, 4, 0);
            lblMessage.Size = new Size(919, 30);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Loading appointment information…";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TestAppointmentsDataGridView
            // 
            TestAppointmentsDataGridView.AllowUserToAddRows = false;
            TestAppointmentsDataGridView.AllowUserToDeleteRows = false;
            TestAppointmentsDataGridView.AllowUserToResizeRows = false;
            TestAppointmentsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TestAppointmentsDataGridView.BackgroundColor = Color.White;
            TestAppointmentsDataGridView.BorderStyle = BorderStyle.None;
            TestAppointmentsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TestAppointmentsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(242, 246, 251);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(242, 246, 251);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            TestAppointmentsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            TestAppointmentsDataGridView.ColumnHeadersHeight = 36;
            TestAppointmentsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TestAppointmentsDataGridView.Columns.AddRange(new DataGridViewColumn[] { idColumn, dateColumn, statusColumn, feesColumn, resultColumn, detailsColumn });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle8.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            TestAppointmentsDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            TestAppointmentsDataGridView.Dock = DockStyle.Fill;
            TestAppointmentsDataGridView.EnableHeadersVisualStyles = false;
            TestAppointmentsDataGridView.GridColor = Color.FromArgb(226, 232, 240);
            TestAppointmentsDataGridView.Location = new Point(0, 100);
            TestAppointmentsDataGridView.Margin = new Padding(0, 4, 0, 6);
            TestAppointmentsDataGridView.MultiSelect = false;
            TestAppointmentsDataGridView.Name = "TestAppointmentsDataGridView";
            TestAppointmentsDataGridView.ReadOnly = true;
            TestAppointmentsDataGridView.RowHeadersVisible = false;
            TestAppointmentsDataGridView.RowTemplate.Height = 40;
            TestAppointmentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TestAppointmentsDataGridView.Size = new Size(919, 146);
            TestAppointmentsDataGridView.TabIndex = 2;
            TestAppointmentsDataGridView.CellContentClick += AppointmentDetails_Click;
            // 
            // idColumn
            // 
            idColumn.FillWeight = 90F;
            idColumn.HeaderText = "Appointment ID";
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            // 
            // dateColumn
            // 
            dataGridViewCellStyle6.Format = "dd MMM yyyy, HH:mm";
            dateColumn.DefaultCellStyle = dataGridViewCellStyle6;
            dateColumn.FillWeight = 155F;
            dateColumn.HeaderText = "Appointment Date";
            dateColumn.Name = "dateColumn";
            dateColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            // 
            // feesColumn
            // 
            dataGridViewCellStyle7.Format = "N2";
            feesColumn.DefaultCellStyle = dataGridViewCellStyle7;
            feesColumn.FillWeight = 70F;
            feesColumn.HeaderText = "Paid Fees";
            feesColumn.Name = "feesColumn";
            feesColumn.ReadOnly = true;
            // 
            // resultColumn
            // 
            resultColumn.HeaderText = "Result";
            resultColumn.Name = "resultColumn";
            resultColumn.ReadOnly = true;
            // 
            // detailsColumn
            // 
            detailsColumn.ActiveLinkColor = Color.FromArgb(29, 78, 216);
            detailsColumn.HeaderText = "Action";
            detailsColumn.LinkBehavior = LinkBehavior.HoverUnderline;
            detailsColumn.LinkColor = Color.FromArgb(37, 99, 235);
            detailsColumn.Name = "detailsColumn";
            detailsColumn.ReadOnly = true;
            detailsColumn.VisitedLinkColor = Color.FromArgb(37, 99, 235);
            // 
            // footer
            // 
            footer.Dock = DockStyle.Fill;
            footer.ForeColor = Color.FromArgb(100, 116, 139);
            footer.Location = new Point(3, 252);
            footer.Name = "footer";
            footer.Size = new Size(913, 24);
            footer.TabIndex = 3;
            footer.Text = "Select View details to review an appointment and its result.";
            footer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ListTestAppointmentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 246, 251);
            Controls.Add(page);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(15, 23, 42);
            Name = "ListTestAppointmentsControl";
            Size = new Size(1003, 680);
            page.ResumeLayout(false);
            heading.ResumeLayout(false);
            applicantCard.ResumeLayout(false);
            applicantLayout.ResumeLayout(false);
            identity.ResumeLayout(false);
            application.ResumeLayout(false);
            licenseClass.ResumeLayout(false);
            status.ResumeLayout(false);
            progressCard.ResumeLayout(false);
            progressLayout.ResumeLayout(false);
            historyCard.ResumeLayout(false);
            history.ResumeLayout(false);
            historyHeading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TestAppointmentsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblPageTitle = null!;
        private Label lblFullName = null!;
        private Label avatar = null!;
        private Label lblNationalNo = null!;
        private Label lblApplicationId = null!;
        private Label lblLicenseClass = null!;
        private Label lblApplicationStatus = null!;
        private Label lblVisionProgress = null!;
        private Label lblWrittenProgress = null!;
        private Label lblStreetProgress = null!;
        private Label lblAppointmentCount = null!;
        private Label lblMessage = null!;
        private Guna.UI2.WinForms.Guna2Button CreateAppointmentButton = null!;
        private DataGridView TestAppointmentsDataGridView = null!;
        private TableLayoutPanel page;
        private Panel heading;
        private Label subtitle;
        private Guna.UI2.WinForms.Guna2Panel applicantCard;
        private TableLayoutPanel applicantLayout;
        private Panel identity;
        private Panel application;
        private Label applicationCaption;
        private Panel licenseClass;
        private Label classCaption;
        private Panel status;
        private Label statusCaption;
        private Guna.UI2.WinForms.Guna2Panel progressCard;
        private TableLayoutPanel progressLayout;
        private Label progressTitle;
        private Guna.UI2.WinForms.Guna2Panel historyCard;
        private TableLayoutPanel history;
        private Panel historyHeading;
        private Label historyTitle;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewTextBoxColumn feesColumn;
        private DataGridViewTextBoxColumn resultColumn;
        private DataGridViewLinkColumn detailsColumn;
        private Label footer;
    }
}
