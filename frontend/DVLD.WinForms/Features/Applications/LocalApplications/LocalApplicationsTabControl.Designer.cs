namespace DVLD.WinForms.Features.Applications.LocalApplications
{
    partial class LocalApplicationsTabControl
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
            DataGridViewCellStyle altRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();

            pnlToolbar = new Panel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            cbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            lblMessage = new Label();
            LocalDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            LocalID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            NationalNo = new DataGridViewTextBoxColumn();
            DrivingClass = new DataGridViewTextBoxColumn();
            ApplicationDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            PassedTest = new DataGridViewTextBoxColumn();
            PassedTestId = new DataGridViewTextBoxColumn();
            StatusId = new DataGridViewTextBoxColumn();
            paginationFooter = new DVLD.WinForms.Shared.Controls.PaginationBarControl();
            LocalAppActionMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            ShowApplication = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            EditApplication = new ToolStripMenuItem();
            DeleteApplication = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            CancelApplication = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            ScheduleTest = new ToolStripMenuItem();
            ScheduleVisionTest = new ToolStripMenuItem();
            ScheduleWrittenTest = new ToolStripMenuItem();
            ScheduleStreetTest = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            IssueDrivingLicence = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            ShowLicence = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            LicenceHistory = new ToolStripMenuItem();

            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LocalDataGridView).BeginInit();
            LocalAppActionMenu.SuspendLayout();
            SuspendLayout();

            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(cbStatus);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(943, 72);
            pnlToolbar.TabIndex = 1;

            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(220, 230, 238);
            txtSearch.BorderRadius = 8;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges1;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(248, 250, 252);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearch.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtSearch.Location = new Point(16, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "Search by application ID or name...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtSearch.Size = new Size(340, 40);
            txtSearch.TabIndex = 0;
            txtSearch.TextOffset = new Point(8, 0);

            // 
            // cbStatus
            // 
            cbStatus.BackColor = Color.Transparent;
            cbStatus.BorderColor = Color.FromArgb(220, 230, 238);
            cbStatus.BorderRadius = 8;
            cbStatus.CustomizableEdges = customizableEdges3;
            cbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FillColor = Color.FromArgb(248, 250, 252);
            cbStatus.FocusedColor = Color.FromArgb(13, 148, 136);
            cbStatus.Font = new Font("Segoe UI", 9.5F);
            cbStatus.ForeColor = Color.FromArgb(15, 23, 42);
            cbStatus.ItemHeight = 34;
            cbStatus.Location = new Point(368, 16);
            cbStatus.Name = "cbStatus";
            cbStatus.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbStatus.Size = new Size(170, 40);
            cbStatus.TabIndex = 1;

            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 10F);
            lblMessage.ForeColor = Color.FromArgb(100, 116, 139);
            lblMessage.Location = new Point(24, 210);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(895, 36);
            lblMessage.TabIndex = 6;
            lblMessage.Text = "No applications found.";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.UseMnemonic = false;
            lblMessage.Visible = false;

            // 
            // LocalDataGridView
            // 
            LocalDataGridView.AllowUserToAddRows = false;
            LocalDataGridView.AllowUserToDeleteRows = false;
            LocalDataGridView.AllowUserToResizeRows = false;
            altRowStyle.BackColor = Color.White;
            LocalDataGridView.AlternatingRowsDefaultCellStyle = altRowStyle;
            LocalDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LocalDataGridView.BackgroundColor = Color.White;
            LocalDataGridView.BorderStyle = BorderStyle.None;
            LocalDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            LocalDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(16, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.True;
            LocalDataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            LocalDataGridView.ColumnHeadersHeight = 44;
            LocalDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            LocalDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                LocalID,
                FullName,
                NationalNo,
                DrivingClass,
                ApplicationDate,
                Status,
                PassedTest,
                PassedTestId,
                StatusId
            });
            LocalDataGridView.ContextMenuStrip = LocalAppActionMenu;
            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9.5F);
            defaultStyle.ForeColor = Color.FromArgb(51, 65, 85);
            defaultStyle.Padding = new Padding(16, 0, 8, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            LocalDataGridView.DefaultCellStyle = defaultStyle;
            LocalDataGridView.Dock = DockStyle.Fill;
            LocalDataGridView.EnableHeadersVisualStyles = false;
            LocalDataGridView.GridColor = Color.FromArgb(241, 245, 249);
            LocalDataGridView.Location = new Point(0, 72);
            LocalDataGridView.MultiSelect = false;
            LocalDataGridView.Name = "LocalDataGridView";
            LocalDataGridView.ReadOnly = true;
            LocalDataGridView.RowHeadersVisible = false;
            LocalDataGridView.RowTemplate.Height = 56;
            LocalDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LocalDataGridView.Size = new Size(943, 359);
            LocalDataGridView.TabIndex = 0;
            LocalDataGridView.ThemeStyle.BackColor = Color.White;
            LocalDataGridView.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            LocalDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            LocalDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
            LocalDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            LocalDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            LocalDataGridView.ThemeStyle.HeaderStyle.Height = 44;
            LocalDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            LocalDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            LocalDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(51, 65, 85);
            LocalDataGridView.ThemeStyle.RowsStyle.Height = 56;
            LocalDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            LocalDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            LocalID.FillWeight = 72F;
            LocalID.HeaderText = "APP ID";
            LocalID.MinimumWidth = 68;
            LocalID.Name = "LocalID";
            LocalID.ReadOnly = true;

            FullName.FillWeight = 190F;
            FullName.HeaderText = "APPLICANT";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;

            NationalNo.FillWeight = 100F;
            NationalNo.HeaderText = "NATIONAL NO";
            NationalNo.Name = "NationalNo";
            NationalNo.ReadOnly = true;

            DrivingClass.FillWeight = 130F;
            DrivingClass.HeaderText = "LICENSE CLASS";
            DrivingClass.Name = "DrivingClass";
            DrivingClass.ReadOnly = true;

            ApplicationDate.FillWeight = 100F;
            ApplicationDate.HeaderText = "APPLIED ON";
            ApplicationDate.Name = "ApplicationDate";
            ApplicationDate.ReadOnly = true;

            Status.FillWeight = 110F;
            Status.HeaderText = "STATUS";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.SortMode = DataGridViewColumnSortMode.NotSortable;

            PassedTest.FillWeight = 110F;
            PassedTest.HeaderText = "TESTS PASSED";
            PassedTest.Name = "PassedTest";
            PassedTest.ReadOnly = true;

            PassedTestId.Name = "PassedTestId";
            PassedTestId.ReadOnly = true;
            PassedTestId.Visible = false;

            StatusId.Name = "StatusId";
            StatusId.ReadOnly = true;
            StatusId.Visible = false;

            // 
            // paginationFooter
            // 
            paginationFooter.BackColor = Color.FromArgb(248, 250, 252);
            paginationFooter.Dock = DockStyle.Bottom;
            paginationFooter.Font = new Font("Segoe UI", 9F);
            paginationFooter.ItemLabel = "applications";
            paginationFooter.Location = new Point(0, 431);
            paginationFooter.Margin = new Padding(0);
            paginationFooter.Name = "paginationFooter";
            paginationFooter.Size = new Size(943, 46);
            paginationFooter.TabIndex = 2;

            // 
            // LocalAppActionMenu
            // 
            LocalAppActionMenu.BackColor = Color.White;
            LocalAppActionMenu.Font = new Font("Segoe UI", 9.5F);
            LocalAppActionMenu.ImageScalingSize = new Size(18, 18);
            LocalAppActionMenu.Items.AddRange(new ToolStripItem[]
            {
                ShowApplication,
                EditApplication,
                toolStripSeparator1,
                ScheduleTest,
                IssueDrivingLicence,
                ShowLicence,
                LicenceHistory,
                toolStripSeparator2,
                CancelApplication,
                DeleteApplication
            });
            LocalAppActionMenu.Name = "LocalAppActionMenu";
            LocalAppActionMenu.Size = new Size(257, 238);

            ShowApplication.Image = Properties.Resources.icons8_view_30;
            ShowApplication.Name = "ShowApplication";
            ShowApplication.Size = new Size(256, 22);
            ShowApplication.Text = "Show Application Details";

            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(253, 6);

            EditApplication.Image = Properties.Resources.icons8_edit_30;
            EditApplication.Name = "EditApplication";
            EditApplication.Size = new Size(256, 22);
            EditApplication.Text = "Edit Application";

            DeleteApplication.Image = Properties.Resources.icons8_delete_30__1_;
            DeleteApplication.Name = "DeleteApplication";
            DeleteApplication.Size = new Size(256, 22);
            DeleteApplication.Text = "Delete Application";

            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(253, 6);

            CancelApplication.Image = Properties.Resources.icons8_delete_30;
            CancelApplication.Name = "CancelApplication";
            CancelApplication.Size = new Size(256, 22);
            CancelApplication.Text = "Cancel Application";

            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(253, 6);

            ScheduleTest.DropDownItems.AddRange(new ToolStripItem[] { ScheduleVisionTest, ScheduleWrittenTest, ScheduleStreetTest });
            ScheduleTest.Image = Properties.Resources.icons8_test_30;
            ScheduleTest.Name = "ScheduleTest";
            ScheduleTest.Size = new Size(256, 22);
            ScheduleTest.Text = "Schedule Test";

            ScheduleVisionTest.Image = Properties.Resources.icons8_vision_48;
            ScheduleVisionTest.Name = "ScheduleVisionTest";
            ScheduleVisionTest.Size = new Size(201, 22);
            ScheduleVisionTest.Text = "Schedule Vision Test";

            ScheduleWrittenTest.Image = Properties.Resources.icons8_note_48;
            ScheduleWrittenTest.Name = "ScheduleWrittenTest";
            ScheduleWrittenTest.Size = new Size(201, 22);
            ScheduleWrittenTest.Text = "Schedule Written Test";

            ScheduleStreetTest.Image = Properties.Resources.icons8_driver_48;
            ScheduleStreetTest.Name = "ScheduleStreetTest";
            ScheduleStreetTest.Size = new Size(201, 22);
            ScheduleStreetTest.Text = "Schedule Street Test";

            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(253, 6);

            IssueDrivingLicence.Image = Properties.Resources.icons8_id_card_30;
            IssueDrivingLicence.Name = "IssueDrivingLicence";
            IssueDrivingLicence.Size = new Size(256, 22);
            IssueDrivingLicence.Text = "Issue Driving License (First Time)";

            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(253, 6);

            ShowLicence.Image = Properties.Resources.icons8_id_card_48;
            ShowLicence.Name = "ShowLicence";
            ShowLicence.Size = new Size(256, 22);
            ShowLicence.Text = "Show Licence";

            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(253, 6);

            LicenceHistory.Image = Properties.Resources.icons8_history_48;
            LicenceHistory.Name = "LicenceHistory";
            LicenceHistory.Size = new Size(256, 22);
            LicenceHistory.Text = "Licence History";

            // 
            // LocalApplicationsTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblMessage);
            Controls.Add(LocalDataGridView);
            Controls.Add(pnlToolbar);
            Controls.Add(paginationFooter);
            Font = new Font("Segoe UI", 9F);
            Name = "LocalApplicationsTabControl";
            Size = new Size(943, 477);
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LocalDataGridView).EndInit();
            LocalAppActionMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatus;
        private Label lblMessage;
        private Guna.UI2.WinForms.Guna2DataGridView LocalDataGridView;
        private DataGridViewTextBoxColumn LocalID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn NationalNo;
        private DataGridViewTextBoxColumn DrivingClass;
        private DataGridViewTextBoxColumn ApplicationDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn PassedTest;
        private DataGridViewTextBoxColumn PassedTestId;
        private DataGridViewTextBoxColumn StatusId;
        private DVLD.WinForms.Shared.Controls.PaginationBarControl paginationFooter;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip LocalAppActionMenu;
        private ToolStripMenuItem ShowApplication;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem EditApplication;
        private ToolStripMenuItem DeleteApplication;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem CancelApplication;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ScheduleTest;
        private ToolStripMenuItem ScheduleVisionTest;
        private ToolStripMenuItem ScheduleWrittenTest;
        private ToolStripMenuItem ScheduleStreetTest;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem IssueDrivingLicence;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem ShowLicence;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem LicenceHistory;
    }
}
