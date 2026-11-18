namespace DVLD.WinForms.Features.Tests.Appointments
{
    partial class ListTestAppointmentsControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            applicantBanner = new DVLD.WinForms.Shared.Controls.ApplicantBannerControl();
            testRoadmapControl = new DVLD.WinForms.Shared.Controls.TestRoadmapControl();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            historyCard = new Guna.UI2.WinForms.Guna2Panel();
            TestAppointmentsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            feesColumn = new DataGridViewTextBoxColumn();
            resultColumn = new DataGridViewTextBoxColumn();
            detailsColumn = new DataGridViewLinkColumn();
            historyDivider = new Panel();
            historyHeaderPanel = new Panel();
            historyTitle = new Label();
            lblAppointmentCount = new Label();
            CreateAppointmentButton = new Guna.UI2.WinForms.Guna2Button();
            footerHint = new Label();
            pageLayout.SuspendLayout();
            historyCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TestAppointmentsDataGridView).BeginInit();
            historyHeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoSize = true;
            pageLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(applicantBanner, 0, 2);
            pageLayout.Controls.Add(testRoadmapControl, 0, 4);
            pageLayout.Controls.Add(statusBanner, 0, 6);
            pageLayout.Controls.Add(historyCard, 0, 8);
            pageLayout.Dock = DockStyle.Top;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(760, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 9;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 188F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            pageLayout.Size = new Size(1000, 736);
            pageLayout.TabIndex = 0;
            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● Test Queue";
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "TA";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.MinimumSize = new Size(560, 68);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(968, 68);
            pageHeader.Subtitle = "Review examination progress and manage scheduled appointments";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Test Appointments";
            // 
            // applicantBanner
            // 
            applicantBanner.BackColor = Color.Transparent;
            applicantBanner.Dock = DockStyle.Fill;
            applicantBanner.Font = new Font("Segoe UI", 9F);
            applicantBanner.Location = new Point(16, 92);
            applicantBanner.Margin = new Padding(0);
            applicantBanner.MinimumSize = new Size(760, 96);
            applicantBanner.Name = "applicantBanner";
            applicantBanner.ShowViewPersonButton = false;
            applicantBanner.Size = new Size(968, 96);
            applicantBanner.TabIndex = 1;
            // 
            // testRoadmapControl
            // 
            testRoadmapControl.BackColor = Color.Transparent;
            testRoadmapControl.Dock = DockStyle.Fill;
            testRoadmapControl.Font = new Font("Segoe UI", 9F);
            testRoadmapControl.Location = new Point(16, 196);
            testRoadmapControl.Margin = new Padding(0);
            testRoadmapControl.MinimumSize = new Size(710, 188);
            testRoadmapControl.Name = "testRoadmapControl";
            testRoadmapControl.Size = new Size(968, 188);
            testRoadmapControl.TabIndex = 2;
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Loading appointment information…";
            statusBanner.Dock = DockStyle.Fill;
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 392);
            statusBanner.Margin = new Padding(0);
            statusBanner.MinimumSize = new Size(420, 60);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(968, 60);
            statusBanner.TabIndex = 3;
            statusBanner.Title = "Scheduling Availability";
            // 
            // historyCard
            // 
            historyCard.BackColor = Color.Transparent;
            historyCard.BorderColor = Color.FromArgb(220, 230, 238);
            historyCard.BorderRadius = 12;
            historyCard.BorderThickness = 1;
            historyCard.Controls.Add(TestAppointmentsDataGridView);
            historyCard.Controls.Add(historyDivider);
            historyCard.Controls.Add(historyHeaderPanel);
            historyCard.Controls.Add(footerHint);
            historyCard.CustomizableEdges = customizableEdges3;
            historyCard.Dock = DockStyle.Fill;
            historyCard.FillColor = Color.White;
            historyCard.Location = new Point(16, 460);
            historyCard.Margin = new Padding(0);
            historyCard.Name = "historyCard";
            historyCard.ShadowDecoration.CustomizableEdges = customizableEdges4;
            historyCard.Size = new Size(968, 260);
            historyCard.TabIndex = 4;
            // 
            // TestAppointmentsDataGridView
            // 
            TestAppointmentsDataGridView.AllowUserToAddRows = false;
            TestAppointmentsDataGridView.AllowUserToDeleteRows = false;
            TestAppointmentsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 252, 255);
            TestAppointmentsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            TestAppointmentsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TestAppointmentsDataGridView.BackgroundColor = Color.White;
            TestAppointmentsDataGridView.BorderStyle = BorderStyle.None;
            TestAppointmentsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TestAppointmentsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            TestAppointmentsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            TestAppointmentsDataGridView.ColumnHeadersHeight = 36;
            TestAppointmentsDataGridView.Columns.AddRange(new DataGridViewColumn[] { idColumn, dateColumn, statusColumn, feesColumn, resultColumn, detailsColumn });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.25F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle8.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(240, 253, 250);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            TestAppointmentsDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            TestAppointmentsDataGridView.Dock = DockStyle.Fill;
            TestAppointmentsDataGridView.EnableHeadersVisualStyles = false;
            TestAppointmentsDataGridView.GridColor = Color.FromArgb(226, 232, 240);
            TestAppointmentsDataGridView.Location = new Point(0, 61);
            TestAppointmentsDataGridView.MultiSelect = false;
            TestAppointmentsDataGridView.Name = "TestAppointmentsDataGridView";
            TestAppointmentsDataGridView.ReadOnly = true;
            TestAppointmentsDataGridView.RowHeadersVisible = false;
            TestAppointmentsDataGridView.RowTemplate.Height = 42;
            TestAppointmentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TestAppointmentsDataGridView.Size = new Size(968, 169);
            TestAppointmentsDataGridView.TabIndex = 2;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 252, 255);
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            TestAppointmentsDataGridView.ThemeStyle.BackColor = Color.White;
            TestAppointmentsDataGridView.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.Height = 36;
            TestAppointmentsDataGridView.ThemeStyle.ReadOnly = true;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.Height = 40;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            TestAppointmentsDataGridView.CellContentClick += AppointmentDetails_Click;
            // 
            // idColumn
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(15, 23, 42);
            idColumn.DefaultCellStyle = dataGridViewCellStyle3;
            idColumn.FillWeight = 85F;
            idColumn.HeaderText = "APPOINTMENT ID";
            idColumn.Name = "TestAppointmentId";
            idColumn.ReadOnly = true;
            // 
            // dateColumn
            // 
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle4.Format = "dd MMM yyyy, HH:mm";
            dateColumn.DefaultCellStyle = dataGridViewCellStyle4;
            dateColumn.FillWeight = 155F;
            dateColumn.HeaderText = "APPOINTMENT DATE";
            dateColumn.Name = "AppointmentDate";
            dateColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            statusColumn.DefaultCellStyle = dataGridViewCellStyle5;
            statusColumn.FillWeight = 95F;
            statusColumn.HeaderText = "STATUS";
            statusColumn.Name = "TestStatus";
            statusColumn.ReadOnly = true;
            // 
            // feesColumn
            // 
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle6.Format = "N2";
            feesColumn.DefaultCellStyle = dataGridViewCellStyle6;
            feesColumn.FillWeight = 80F;
            feesColumn.HeaderText = "PAID FEES";
            feesColumn.Name = "PaidFees";
            feesColumn.ReadOnly = true;
            // 
            // resultColumn
            // 
            dataGridViewCellStyle7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            resultColumn.DefaultCellStyle = dataGridViewCellStyle7;
            resultColumn.FillWeight = 95F;
            resultColumn.HeaderText = "RESULT";
            resultColumn.Name = "TestResult";
            resultColumn.ReadOnly = true;
            // 
            // detailsColumn
            // 
            detailsColumn.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            detailsColumn.FillWeight = 110F;
            detailsColumn.HeaderText = "ACTION";
            detailsColumn.LinkBehavior = LinkBehavior.HoverUnderline;
            detailsColumn.LinkColor = Color.FromArgb(13, 148, 136);
            detailsColumn.Name = "Details";
            detailsColumn.ReadOnly = true;
            detailsColumn.VisitedLinkColor = Color.FromArgb(13, 148, 136);
            // 
            // historyDivider
            // 
            historyDivider.BackColor = Color.FromArgb(226, 232, 240);
            historyDivider.Dock = DockStyle.Top;
            historyDivider.Location = new Point(0, 60);
            historyDivider.Name = "historyDivider";
            historyDivider.Size = new Size(968, 1);
            historyDivider.TabIndex = 1;
            // 
            // historyHeaderPanel
            // 
            historyHeaderPanel.BackColor = Color.White;
            historyHeaderPanel.Controls.Add(historyTitle);
            historyHeaderPanel.Controls.Add(lblAppointmentCount);
            historyHeaderPanel.Controls.Add(CreateAppointmentButton);
            historyHeaderPanel.Dock = DockStyle.Top;
            historyHeaderPanel.Location = new Point(0, 0);
            historyHeaderPanel.Name = "historyHeaderPanel";
            historyHeaderPanel.Padding = new Padding(18, 12, 18, 10);
            historyHeaderPanel.Size = new Size(968, 60);
            historyHeaderPanel.TabIndex = 0;
            // 
            // historyTitle
            // 
            historyTitle.AutoSize = true;
            historyTitle.BackColor = Color.Transparent;
            historyTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            historyTitle.ForeColor = Color.FromArgb(15, 23, 42);
            historyTitle.Location = new Point(18, 11);
            historyTitle.Name = "historyTitle";
            historyTitle.Size = new Size(159, 20);
            historyTitle.TabIndex = 0;
            historyTitle.Text = "Appointment History";
            historyTitle.UseMnemonic = false;
            // 
            // lblAppointmentCount
            // 
            lblAppointmentCount.AutoSize = true;
            lblAppointmentCount.BackColor = Color.Transparent;
            lblAppointmentCount.Font = new Font("Segoe UI", 8.75F);
            lblAppointmentCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblAppointmentCount.Location = new Point(18, 34);
            lblAppointmentCount.Name = "lblAppointmentCount";
            lblAppointmentCount.Size = new Size(136, 15);
            lblAppointmentCount.TabIndex = 1;
            lblAppointmentCount.Text = "Loading appointments…";
            lblAppointmentCount.UseMnemonic = false;
            // 
            // CreateAppointmentButton
            // 
            CreateAppointmentButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreateAppointmentButton.BackColor = Color.Transparent;
            CreateAppointmentButton.BorderColor = Color.FromArgb(13, 148, 136);
            CreateAppointmentButton.BorderRadius = 8;
            CreateAppointmentButton.BorderThickness = 1;
            CreateAppointmentButton.Cursor = Cursors.Hand;
            CreateAppointmentButton.CustomizableEdges = customizableEdges1;
            CreateAppointmentButton.DisabledState.BorderColor = Color.FromArgb(203, 213, 225);
            CreateAppointmentButton.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            CreateAppointmentButton.DisabledState.ForeColor = Color.FromArgb(100, 116, 139);
            CreateAppointmentButton.Enabled = false;
            CreateAppointmentButton.FillColor = Color.FromArgb(13, 148, 136);
            CreateAppointmentButton.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            CreateAppointmentButton.ForeColor = Color.White;
            CreateAppointmentButton.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            CreateAppointmentButton.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            CreateAppointmentButton.Location = new Point(762, 12);
            CreateAppointmentButton.Name = "CreateAppointmentButton";
            CreateAppointmentButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CreateAppointmentButton.Size = new Size(188, 36);
            CreateAppointmentButton.TabIndex = 2;
            CreateAppointmentButton.Text = "+ New Appointment";
            CreateAppointmentButton.Click += CreateAppointmentButton_Click;
            // 
            // footerHint
            // 
            footerHint.BackColor = Color.FromArgb(248, 250, 252);
            footerHint.Dock = DockStyle.Bottom;
            footerHint.Font = new Font("Segoe UI", 8.5F);
            footerHint.ForeColor = Color.FromArgb(100, 116, 139);
            footerHint.Location = new Point(0, 230);
            footerHint.Name = "footerHint";
            footerHint.Padding = new Padding(18, 0, 18, 0);
            footerHint.Size = new Size(968, 30);
            footerHint.TabIndex = 3;
            footerHint.Text = "Select Record result on a scheduled row to log the outcome, or View details on completed rows.";
            footerHint.TextAlign = ContentAlignment.MiddleLeft;
            footerHint.UseMnemonic = false;
            // 
            // ListTestAppointmentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(15, 23, 42);
            Name = "ListTestAppointmentsControl";
            Size = new Size(986, 660);
            pageLayout.ResumeLayout(false);
            historyCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TestAppointmentsDataGridView).EndInit();
            historyHeaderPanel.ResumeLayout(false);
            historyHeaderPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.ApplicantBannerControl applicantBanner;
        private Shared.Controls.TestRoadmapControl testRoadmapControl;
        private Shared.Controls.StatusBannerControl statusBanner;
        private Guna.UI2.WinForms.Guna2Panel historyCard;
        private Panel historyHeaderPanel;
        private Label historyTitle;
        private Label lblAppointmentCount;
        private Guna.UI2.WinForms.Guna2Button CreateAppointmentButton;
        private Panel historyDivider;
        private Guna.UI2.WinForms.Guna2DataGridView TestAppointmentsDataGridView;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewTextBoxColumn feesColumn;
        private DataGridViewTextBoxColumn resultColumn;
        private DataGridViewLinkColumn detailsColumn;
        private Label footerHint;
    }
}
