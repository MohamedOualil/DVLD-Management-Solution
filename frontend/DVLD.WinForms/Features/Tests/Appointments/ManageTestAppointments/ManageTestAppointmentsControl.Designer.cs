namespace DVLD.WinForms.Features.Tests.Appointments.ManageTestAppointments
{
    partial class ManageTestAppointmentsControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            DataGridViewCellStyle altStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();

            pnlStageBar = new FlowLayoutPanel();
            btnStageAll = new Guna.UI2.WinForms.Guna2Button();
            btnStageVision = new Guna.UI2.WinForms.Guna2Button();
            btnStageWritten = new Guna.UI2.WinForms.Guna2Button();
            btnStageStreet = new Guna.UI2.WinForms.Guna2Button();
            gridCard = new Guna.UI2.WinForms.Guna2Panel();
            cardInnerHost = new Panel();
            pnlToolbar = new Panel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            cbStageFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            cbStatusFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            btnManageSelected = new Guna.UI2.WinForms.Guna2Button();
            gridHost = new Panel();
            lblEmptyState = new Label();
            AppointmentsQueueGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            colLocalId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colNationalNo = new DataGridViewTextBoxColumn();
            colDrivingClass = new DataGridViewTextBoxColumn();
            colApplicationDate = new DataGridViewTextBoxColumn();
            colExamStage = new DataGridViewTextBoxColumn();
            colPassedTest = new DataGridViewTextBoxColumn();
            colPassedTestId = new DataGridViewTextBoxColumn();
            colStatusId = new DataGridViewTextBoxColumn();
            paginationFooter = new DVLD.WinForms.Shared.Controls.PaginationBarControl();
            QueueActionMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            menuOpenNextTest = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuVisionAppointments = new ToolStripMenuItem();
            menuWrittenAppointments = new ToolStripMenuItem();
            menuStreetAppointments = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuShowApplication = new ToolStripMenuItem();
            menuLicenceHistory = new ToolStripMenuItem();

            pnlStageBar.SuspendLayout();
            gridCard.SuspendLayout();
            cardInnerHost.SuspendLayout();
            pnlToolbar.SuspendLayout();
            gridHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AppointmentsQueueGrid).BeginInit();
            QueueActionMenu.SuspendLayout();
            SuspendLayout();

            // 
            // pnlStageBar
            // 
            pnlStageBar.BackColor = Color.Transparent;
            pnlStageBar.Controls.Add(btnStageAll);
            pnlStageBar.Controls.Add(btnStageVision);
            pnlStageBar.Controls.Add(btnStageWritten);
            pnlStageBar.Controls.Add(btnStageStreet);
            pnlStageBar.Dock = DockStyle.Top;
            pnlStageBar.Location = new Point(24, 20);
            pnlStageBar.Margin = new Padding(0);
            pnlStageBar.Name = "pnlStageBar";
            pnlStageBar.Size = new Size(955, 58);
            pnlStageBar.TabIndex = 0;
            pnlStageBar.WrapContents = false;

            // 
            // btnStageAll
            // 
            btnStageAll.BorderColor = Color.FromArgb(13, 148, 136);
            btnStageAll.BorderRadius = 10;
            btnStageAll.BorderThickness = 1;
            btnStageAll.Cursor = Cursors.Hand;
            btnStageAll.CustomizableEdges = customizableEdges1;
            btnStageAll.FillColor = Color.FromArgb(13, 148, 136);
            btnStageAll.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnStageAll.ForeColor = Color.White;
            btnStageAll.Location = new Point(0, 0);
            btnStageAll.Margin = new Padding(0, 0, 12, 16);
            btnStageAll.Name = "btnStageAll";
            btnStageAll.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnStageAll.Size = new Size(195, 42);
            btnStageAll.TabIndex = 0;
            btnStageAll.Text = "All Active Exams (0)";

            // 
            // btnStageVision
            // 
            btnStageVision.BorderColor = Color.FromArgb(226, 232, 240);
            btnStageVision.BorderRadius = 10;
            btnStageVision.BorderThickness = 1;
            btnStageVision.Cursor = Cursors.Hand;
            btnStageVision.CustomizableEdges = customizableEdges3;
            btnStageVision.FillColor = Color.White;
            btnStageVision.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnStageVision.ForeColor = Color.FromArgb(51, 65, 85);
            btnStageVision.Location = new Point(207, 0);
            btnStageVision.Margin = new Padding(0, 0, 12, 16);
            btnStageVision.Name = "btnStageVision";
            btnStageVision.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnStageVision.Size = new Size(205, 42);
            btnStageVision.TabIndex = 1;
            btnStageVision.Text = "Vision Test Queue (0)";

            // 
            // btnStageWritten
            // 
            btnStageWritten.BorderColor = Color.FromArgb(226, 232, 240);
            btnStageWritten.BorderRadius = 10;
            btnStageWritten.BorderThickness = 1;
            btnStageWritten.Cursor = Cursors.Hand;
            btnStageWritten.CustomizableEdges = customizableEdges5;
            btnStageWritten.FillColor = Color.White;
            btnStageWritten.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnStageWritten.ForeColor = Color.FromArgb(51, 65, 85);
            btnStageWritten.Location = new Point(424, 0);
            btnStageWritten.Margin = new Padding(0, 0, 12, 16);
            btnStageWritten.Name = "btnStageWritten";
            btnStageWritten.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnStageWritten.Size = new Size(210, 42);
            btnStageWritten.TabIndex = 2;
            btnStageWritten.Text = "Written Test Queue (0)";

            // 
            // btnStageStreet
            // 
            btnStageStreet.BorderColor = Color.FromArgb(226, 232, 240);
            btnStageStreet.BorderRadius = 10;
            btnStageStreet.BorderThickness = 1;
            btnStageStreet.Cursor = Cursors.Hand;
            btnStageStreet.CustomizableEdges = customizableEdges7;
            btnStageStreet.FillColor = Color.White;
            btnStageStreet.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnStageStreet.ForeColor = Color.FromArgb(51, 65, 85);
            btnStageStreet.Location = new Point(646, 0);
            btnStageStreet.Margin = new Padding(0, 0, 12, 16);
            btnStageStreet.Name = "btnStageStreet";
            btnStageStreet.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnStageStreet.Size = new Size(205, 42);
            btnStageStreet.TabIndex = 3;
            btnStageStreet.Text = "Street Test Queue (0)";

            // 
            // gridCard
            // 
            gridCard.BackColor = Color.Transparent;
            gridCard.BorderColor = Color.FromArgb(220, 230, 238);
            gridCard.BorderRadius = 12;
            gridCard.BorderThickness = 1;
            gridCard.Controls.Add(cardInnerHost);
            gridCard.Dock = DockStyle.Fill;
            gridCard.FillColor = Color.White;
            gridCard.Location = new Point(24, 78);
            gridCard.Name = "gridCard";
            gridCard.Padding = new Padding(2);
            gridCard.Size = new Size(955, 535);
            gridCard.TabIndex = 1;

            // 
            // cardInnerHost
            // 
            cardInnerHost.BackColor = Color.White;
            cardInnerHost.Controls.Add(gridHost);
            cardInnerHost.Controls.Add(pnlToolbar);
            cardInnerHost.Controls.Add(paginationFooter);
            cardInnerHost.Dock = DockStyle.Fill;
            cardInnerHost.Location = new Point(2, 2);
            cardInnerHost.Name = "cardInnerHost";
            cardInnerHost.Size = new Size(951, 531);
            cardInnerHost.TabIndex = 0;

            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(btnManageSelected);
            pnlToolbar.Controls.Add(cbStatusFilter);
            pnlToolbar.Controls.Add(cbStageFilter);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(951, 72);
            pnlToolbar.TabIndex = 0;

            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(226, 232, 240);
            txtSearch.BorderRadius = 10;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges9;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(248, 250, 252);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearch.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtSearch.Location = new Point(16, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "Search App ID, Applicant, or National No...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtSearch.Size = new Size(320, 40);
            txtSearch.TabIndex = 0;
            txtSearch.TextOffset = new Point(8, 0);

            // 
            // cbStageFilter
            // 
            cbStageFilter.BackColor = Color.Transparent;
            cbStageFilter.BorderColor = Color.FromArgb(226, 232, 240);
            cbStageFilter.BorderRadius = 10;
            cbStageFilter.CustomizableEdges = customizableEdges11;
            cbStageFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cbStageFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStageFilter.FillColor = Color.FromArgb(248, 250, 252);
            cbStageFilter.FocusedColor = Color.FromArgb(13, 148, 136);
            cbStageFilter.Font = new Font("Segoe UI", 9.25F);
            cbStageFilter.ForeColor = Color.FromArgb(15, 23, 42);
            cbStageFilter.ItemHeight = 34;
            cbStageFilter.Items.AddRange(new object[]
            {
                "All Exam Stages",
                "Vision Test (0/3)",
                "Written Test (1/3)",
                "Street Test (2/3)",
                "Passed All (3/3)"
            });
            cbStageFilter.Location = new Point(348, 16);
            cbStageFilter.Name = "cbStageFilter";
            cbStageFilter.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cbStageFilter.Size = new Size(190, 40);
            cbStageFilter.TabIndex = 1;

            // 
            // cbStatusFilter
            // 
            cbStatusFilter.BackColor = Color.Transparent;
            cbStatusFilter.BorderColor = Color.FromArgb(226, 232, 240);
            cbStatusFilter.BorderRadius = 10;
            cbStatusFilter.CustomizableEdges = customizableEdges13;
            cbStatusFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.FillColor = Color.FromArgb(248, 250, 252);
            cbStatusFilter.FocusedColor = Color.FromArgb(13, 148, 136);
            cbStatusFilter.Font = new Font("Segoe UI", 9.25F);
            cbStatusFilter.ForeColor = Color.FromArgb(15, 23, 42);
            cbStatusFilter.ItemHeight = 34;
            cbStatusFilter.Items.AddRange(new object[] { "All Statuses", "New", "Cancelled", "Completed" });
            cbStatusFilter.Location = new Point(550, 16);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.ShadowDecoration.CustomizableEdges = customizableEdges14;
            cbStatusFilter.Size = new Size(155, 40);
            cbStatusFilter.TabIndex = 2;

            // 
            // btnManageSelected
            // 
            btnManageSelected.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnManageSelected.BorderRadius = 10;
            btnManageSelected.Cursor = Cursors.Hand;
            btnManageSelected.Enabled = false;
            btnManageSelected.FillColor = Color.FromArgb(13, 148, 136);
            btnManageSelected.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnManageSelected.ForeColor = Color.White;
            btnManageSelected.Location = new Point(725, 16);
            btnManageSelected.Name = "btnManageSelected";
            btnManageSelected.Size = new Size(210, 40);
            btnManageSelected.TabIndex = 3;
            btnManageSelected.Text = "Schedule / Manage Test ↗";

            // 
            // gridHost
            // 
            gridHost.BackColor = Color.White;
            gridHost.Controls.Add(lblEmptyState);
            gridHost.Controls.Add(AppointmentsQueueGrid);
            gridHost.Dock = DockStyle.Fill;
            gridHost.Location = new Point(0, 72);
            gridHost.Name = "gridHost";
            gridHost.Size = new Size(951, 413);
            gridHost.TabIndex = 1;

            // 
            // lblEmptyState
            // 
            lblEmptyState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmptyState.BackColor = Color.Transparent;
            lblEmptyState.Font = new Font("Segoe UI", 10F);
            lblEmptyState.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyState.Location = new Point(24, 150);
            lblEmptyState.Name = "lblEmptyState";
            lblEmptyState.Size = new Size(903, 50);
            lblEmptyState.TabIndex = 1;
            lblEmptyState.Text = "No driving test applications found matching the selected queue.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.UseMnemonic = false;
            lblEmptyState.Visible = false;

            // 
            // AppointmentsQueueGrid
            // 
            AppointmentsQueueGrid.AllowUserToAddRows = false;
            AppointmentsQueueGrid.AllowUserToDeleteRows = false;
            AppointmentsQueueGrid.AllowUserToResizeRows = false;
            altStyle.BackColor = Color.White;
            AppointmentsQueueGrid.AlternatingRowsDefaultCellStyle = altStyle;
            AppointmentsQueueGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AppointmentsQueueGrid.BackgroundColor = Color.White;
            AppointmentsQueueGrid.BorderStyle = BorderStyle.None;
            AppointmentsQueueGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            AppointmentsQueueGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(16, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.True;
            AppointmentsQueueGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            AppointmentsQueueGrid.ColumnHeadersHeight = 44;
            AppointmentsQueueGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            AppointmentsQueueGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                colLocalId,
                colFullName,
                colNationalNo,
                colDrivingClass,
                colApplicationDate,
                colExamStage,
                colPassedTest,
                colPassedTestId,
                colStatusId
            });
            AppointmentsQueueGrid.ContextMenuStrip = QueueActionMenu;
            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9.5F);
            defaultStyle.ForeColor = Color.FromArgb(51, 65, 85);
            defaultStyle.Padding = new Padding(16, 0, 8, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            AppointmentsQueueGrid.DefaultCellStyle = defaultStyle;
            AppointmentsQueueGrid.Dock = DockStyle.Fill;
            AppointmentsQueueGrid.EnableHeadersVisualStyles = false;
            AppointmentsQueueGrid.GridColor = Color.FromArgb(241, 245, 249);
            AppointmentsQueueGrid.Location = new Point(0, 0);
            AppointmentsQueueGrid.MultiSelect = false;
            AppointmentsQueueGrid.Name = "AppointmentsQueueGrid";
            AppointmentsQueueGrid.ReadOnly = true;
            AppointmentsQueueGrid.RowHeadersVisible = false;
            AppointmentsQueueGrid.RowTemplate.Height = 56;
            AppointmentsQueueGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AppointmentsQueueGrid.Size = new Size(951, 413);
            AppointmentsQueueGrid.TabIndex = 0;
            AppointmentsQueueGrid.ThemeStyle.BackColor = Color.White;
            AppointmentsQueueGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            AppointmentsQueueGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            AppointmentsQueueGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
            AppointmentsQueueGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            AppointmentsQueueGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            AppointmentsQueueGrid.ThemeStyle.HeaderStyle.Height = 44;
            AppointmentsQueueGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            AppointmentsQueueGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            AppointmentsQueueGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(51, 65, 85);
            AppointmentsQueueGrid.ThemeStyle.RowsStyle.Height = 56;
            AppointmentsQueueGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            AppointmentsQueueGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            colLocalId.FillWeight = 58F;
            colLocalId.HeaderText = "APP ID";
            colLocalId.Name = "LocalID";
            colLocalId.ReadOnly = true;

            colFullName.FillWeight = 185F;
            colFullName.HeaderText = "APPLICANT";
            colFullName.Name = "FullName";
            colFullName.ReadOnly = true;

            colNationalNo.FillWeight = 92F;
            colNationalNo.HeaderText = "NATIONAL NO";
            colNationalNo.Name = "NationalNo";
            colNationalNo.ReadOnly = true;

            colDrivingClass.FillWeight = 135F;
            colDrivingClass.HeaderText = "LICENSE CLASS";
            colDrivingClass.Name = "DrivingClass";
            colDrivingClass.ReadOnly = true;

            colApplicationDate.FillWeight = 96F;
            colApplicationDate.HeaderText = "APPLIED ON";
            colApplicationDate.Name = "ApplicationDate";
            colApplicationDate.ReadOnly = true;

            colExamStage.FillWeight = 112F;
            colExamStage.HeaderText = "CURRENT EXAM STAGE";
            colExamStage.Name = "ExamStage";
            colExamStage.ReadOnly = true;
            colExamStage.SortMode = DataGridViewColumnSortMode.NotSortable;

            colPassedTest.FillWeight = 105F;
            colPassedTest.HeaderText = "TESTS PASSED";
            colPassedTest.Name = "PassedTest";
            colPassedTest.ReadOnly = true;

            colPassedTestId.Name = "PassedTestId";
            colPassedTestId.ReadOnly = true;
            colPassedTestId.Visible = false;

            colStatusId.Name = "StatusId";
            colStatusId.ReadOnly = true;
            colStatusId.Visible = false;

            // 
            // paginationFooter
            // 
            paginationFooter.BackColor = Color.FromArgb(248, 250, 252);
            paginationFooter.Dock = DockStyle.Bottom;
            paginationFooter.Font = new Font("Segoe UI", 9F);
            paginationFooter.ItemLabel = "exam applications";
            paginationFooter.Location = new Point(0, 485);
            paginationFooter.Margin = new Padding(0);
            paginationFooter.Name = "paginationFooter";
            paginationFooter.Size = new Size(951, 46);
            paginationFooter.TabIndex = 2;

            // 
            // QueueActionMenu
            // 
            QueueActionMenu.BackColor = Color.White;
            QueueActionMenu.Font = new Font("Segoe UI", 9.5F);
            QueueActionMenu.Items.AddRange(new ToolStripItem[]
            {
                menuOpenNextTest,
                toolStripSeparator1,
                menuVisionAppointments,
                menuWrittenAppointments,
                menuStreetAppointments,
                toolStripSeparator2,
                menuShowApplication,
                menuLicenceHistory
            });
            QueueActionMenu.Name = "QueueActionMenu";
            QueueActionMenu.Size = new Size(256, 178);

            menuOpenNextTest.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            menuOpenNextTest.Name = "menuOpenNextTest";
            menuOpenNextTest.Size = new Size(255, 22);
            menuOpenNextTest.Text = "Open Current Stage Appointments";

            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(252, 6);

            menuVisionAppointments.Name = "menuVisionAppointments";
            menuVisionAppointments.Size = new Size(255, 22);
            menuVisionAppointments.Text = "Vision Test Appointments";

            menuWrittenAppointments.Name = "menuWrittenAppointments";
            menuWrittenAppointments.Size = new Size(255, 22);
            menuWrittenAppointments.Text = "Written Test Appointments";

            menuStreetAppointments.Name = "menuStreetAppointments";
            menuStreetAppointments.Size = new Size(255, 22);
            menuStreetAppointments.Text = "Street Test Appointments";

            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(252, 6);

            menuShowApplication.Name = "menuShowApplication";
            menuShowApplication.Size = new Size(255, 22);
            menuShowApplication.Text = "Show Application Details";

            menuLicenceHistory.Name = "menuLicenceHistory";
            menuLicenceHistory.Size = new Size(255, 22);
            menuLicenceHistory.Text = "Applicant Licence History";

            // 
            // ManageTestAppointmentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(gridCard);
            Controls.Add(pnlStageBar);
            Name = "ManageTestAppointmentsControl";
            Padding = new Padding(24, 20, 24, 24);
            Size = new Size(1003, 637);
            Load += ManageTestAppointmentsControl_Load;
            pnlStageBar.ResumeLayout(false);
            gridCard.ResumeLayout(false);
            cardInnerHost.ResumeLayout(false);
            pnlToolbar.ResumeLayout(false);
            gridHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AppointmentsQueueGrid).EndInit();
            QueueActionMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlStageBar;
        private Guna.UI2.WinForms.Guna2Button btnStageAll;
        private Guna.UI2.WinForms.Guna2Button btnStageVision;
        private Guna.UI2.WinForms.Guna2Button btnStageWritten;
        private Guna.UI2.WinForms.Guna2Button btnStageStreet;
        private Guna.UI2.WinForms.Guna2Panel gridCard;
        private Panel cardInnerHost;
        private Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbStageFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatusFilter;
        private Guna.UI2.WinForms.Guna2Button btnManageSelected;
        private Panel gridHost;
        private Label lblEmptyState;
        private Guna.UI2.WinForms.Guna2DataGridView AppointmentsQueueGrid;
        private DataGridViewTextBoxColumn colLocalId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colNationalNo;
        private DataGridViewTextBoxColumn colDrivingClass;
        private DataGridViewTextBoxColumn colApplicationDate;
        private DataGridViewTextBoxColumn colExamStage;
        private DataGridViewTextBoxColumn colPassedTest;
        private DataGridViewTextBoxColumn colPassedTestId;
        private DataGridViewTextBoxColumn colStatusId;
        private DVLD.WinForms.Shared.Controls.PaginationBarControl paginationFooter;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip QueueActionMenu;
        private ToolStripMenuItem menuOpenNextTest;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuVisionAppointments;
        private ToolStripMenuItem menuWrittenAppointments;
        private ToolStripMenuItem menuStreetAppointments;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem menuShowApplication;
        private ToolStripMenuItem menuLicenceHistory;
    }
}
