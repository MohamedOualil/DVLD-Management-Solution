namespace DVLD.WinForms.Features.Administration.Users
{
    partial class UsersControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            filterBar = new DVLD.WinForms.Shared.Controls.DirectoryFilterBarControl();
            gridCard = new Guna.UI2.WinForms.Guna2Panel();
            gridHost = new Panel();
            lblEmptyState = new Label();
            usersGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colPersonId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colUserName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colViewPerson = new DataGridViewLinkColumn();
            colEditUser = new DataGridViewLinkColumn();
            colChangePassword = new DataGridViewLinkColumn();
            paginationBar = new DVLD.WinForms.Shared.Controls.PaginationBarControl();
            pageLayout.SuspendLayout();
            gridCard.SuspendLayout();
            gridHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersGrid).BeginInit();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(statusBanner, 0, 2);
            pageLayout.Controls.Add(filterBar, 0, 4);
            pageLayout.Controls.Add(gridCard, 0, 6);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 7;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.Size = new Size(1003, 637);
            pageLayout.TabIndex = 0;
            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● Admin Only";
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "US";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.MinimumSize = new Size(560, 68);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Admin-only directory to register employee accounts, assign roles, and manage login access";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Users & Employee Management";
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Verifying administrator privileges before loading system accounts...";
            statusBanner.Dock = DockStyle.Fill;
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 94);
            statusBanner.Margin = new Padding(0);
            statusBanner.MinimumSize = new Size(420, 60);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(971, 60);
            statusBanner.TabIndex = 1;
            statusBanner.Title = "Administrator Access Required";
            // 
            // filterBar
            // 
            filterBar.BackColor = Color.Transparent;
            filterBar.CountText = "0 users";
            filterBar.Dock = DockStyle.Fill;
            filterBar.Font = new Font("Segoe UI", 9F);
            filterBar.Location = new Point(16, 162);
            filterBar.Margin = new Padding(0);
            filterBar.MinimumSize = new Size(560, 60);
            filterBar.Name = "filterBar";
            filterBar.PrimaryButtonText = "+ Add Employee User";
            filterBar.SearchPlaceholder = "Search full name, username, or user ID...";
            filterBar.Size = new Size(971, 60);
            filterBar.TabIndex = 2;
            // 
            // gridCard
            // 
            gridCard.BackColor = Color.Transparent;
            gridCard.BorderColor = Color.FromArgb(220, 230, 238);
            gridCard.BorderRadius = 12;
            gridCard.BorderThickness = 1;
            gridCard.Controls.Add(gridHost);
            gridCard.Controls.Add(paginationBar);
            gridCard.CustomizableEdges = customizableEdges1;
            gridCard.Dock = DockStyle.Fill;
            gridCard.FillColor = Color.White;
            gridCard.Location = new Point(16, 232);
            gridCard.Margin = new Padding(0);
            gridCard.Name = "gridCard";
            gridCard.Padding = new Padding(1);
            gridCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gridCard.Size = new Size(971, 389);
            gridCard.TabIndex = 3;
            // 
            // gridHost
            // 
            gridHost.BackColor = Color.White;
            gridHost.Controls.Add(lblEmptyState);
            gridHost.Controls.Add(usersGrid);
            gridHost.Dock = DockStyle.Fill;
            gridHost.Location = new Point(1, 1);
            gridHost.Name = "gridHost";
            gridHost.Size = new Size(969, 341);
            gridHost.TabIndex = 0;
            // 
            // lblEmptyState
            // 
            lblEmptyState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmptyState.BackColor = Color.Transparent;
            lblEmptyState.Font = new Font("Segoe UI", 10F);
            lblEmptyState.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyState.Location = new Point(24, 120);
            lblEmptyState.Name = "lblEmptyState";
            lblEmptyState.Size = new Size(921, 60);
            lblEmptyState.TabIndex = 1;
            lblEmptyState.Text = "No user accounts found.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.UseMnemonic = false;
            lblEmptyState.Visible = false;
            // 
            // usersGrid
            // 
            usersGrid.AllowUserToAddRows = false;
            usersGrid.AllowUserToDeleteRows = false;
            usersGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 252, 255);
            usersGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            usersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            usersGrid.ColumnHeadersHeight = 40;
            usersGrid.Columns.AddRange(new DataGridViewColumn[] { colUserId, colPersonId, colFullName, colUserName, colStatus, colViewPerson, colEditUser, colChangePassword });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.25F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle8.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(240, 253, 250);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            usersGrid.DefaultCellStyle = dataGridViewCellStyle8;
            usersGrid.Dock = DockStyle.Fill;
            usersGrid.GridColor = Color.FromArgb(241, 245, 249);
            usersGrid.Location = new Point(0, 0);
            usersGrid.MultiSelect = false;
            usersGrid.Name = "usersGrid";
            usersGrid.ReadOnly = true;
            usersGrid.RowHeadersVisible = false;
            usersGrid.RowTemplate.Height = 44;
            usersGrid.Size = new Size(969, 341);
            usersGrid.TabIndex = 0;
            usersGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 252, 255);
            usersGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            usersGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            usersGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            usersGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            usersGrid.ThemeStyle.BackColor = Color.White;
            usersGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            usersGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            usersGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            usersGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            usersGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            usersGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            usersGrid.ThemeStyle.HeaderStyle.Height = 40;
            usersGrid.ThemeStyle.ReadOnly = true;
            usersGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            usersGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            usersGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
            usersGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            usersGrid.ThemeStyle.RowsStyle.Height = 44;
            usersGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            usersGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            // 
            // colUserId
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(15, 23, 42);
            colUserId.DefaultCellStyle = dataGridViewCellStyle3;
            colUserId.FillWeight = 72F;
            colUserId.HeaderText = "USER ID";
            colUserId.Name = "UserId";
            colUserId.ReadOnly = true;
            // 
            // colPersonId
            // 
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(100, 116, 139);
            colPersonId.DefaultCellStyle = dataGridViewCellStyle4;
            colPersonId.FillWeight = 78F;
            colPersonId.HeaderText = "PERSON ID";
            colPersonId.Name = "PersonId";
            colPersonId.ReadOnly = true;
            // 
            // colFullName
            // 
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(15, 23, 42);
            colFullName.DefaultCellStyle = dataGridViewCellStyle5;
            colFullName.FillWeight = 185F;
            colFullName.HeaderText = "EMPLOYEE FULL NAME";
            colFullName.Name = "FullName";
            colFullName.ReadOnly = true;
            // 
            // colUserName
            // 
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(15, 118, 110);
            colUserName.DefaultCellStyle = dataGridViewCellStyle6;
            colUserName.FillWeight = 120F;
            colUserName.HeaderText = "USERNAME";
            colUserName.Name = "UserName";
            colUserName.ReadOnly = true;
            // 
            // colStatus
            // 
            dataGridViewCellStyle7.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            colStatus.DefaultCellStyle = dataGridViewCellStyle7;
            colStatus.FillWeight = 82F;
            colStatus.HeaderText = "STATUS";
            colStatus.Name = "Status";
            colStatus.ReadOnly = true;
            // 
            // colViewPerson
            // 
            colViewPerson.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            colViewPerson.FillWeight = 88F;
            colViewPerson.HeaderText = "CITIZEN";
            colViewPerson.LinkBehavior = LinkBehavior.HoverUnderline;
            colViewPerson.LinkColor = Color.FromArgb(13, 148, 136);
            colViewPerson.Name = "ViewPerson";
            colViewPerson.ReadOnly = true;
            colViewPerson.Text = "Person Card";
            colViewPerson.TrackVisitedState = false;
            colViewPerson.UseColumnTextForLinkValue = true;
            // 
            // colEditUser
            // 
            colEditUser.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            colEditUser.FillWeight = 82F;
            colEditUser.HeaderText = "ROLE / STATUS";
            colEditUser.LinkBehavior = LinkBehavior.HoverUnderline;
            colEditUser.LinkColor = Color.FromArgb(13, 148, 136);
            colEditUser.Name = "EditUser";
            colEditUser.ReadOnly = true;
            colEditUser.Text = "Edit User";
            colEditUser.TrackVisitedState = false;
            colEditUser.UseColumnTextForLinkValue = true;
            // 
            // colChangePassword
            // 
            colChangePassword.ActiveLinkColor = Color.FromArgb(180, 83, 9);
            colChangePassword.FillWeight = 78F;
            colChangePassword.HeaderText = "SECURITY";
            colChangePassword.LinkBehavior = LinkBehavior.HoverUnderline;
            colChangePassword.LinkColor = Color.FromArgb(180, 83, 9);
            colChangePassword.Name = "ChangePassword";
            colChangePassword.ReadOnly = true;
            colChangePassword.Text = "Password";
            colChangePassword.TrackVisitedState = false;
            colChangePassword.UseColumnTextForLinkValue = true;
            // 
            // paginationBar
            // 
            paginationBar.BackColor = Color.FromArgb(248, 250, 252);
            paginationBar.Dock = DockStyle.Bottom;
            paginationBar.Font = new Font("Segoe UI", 9F);
            paginationBar.ItemLabel = "users";
            paginationBar.Location = new Point(1, 342);
            paginationBar.MinimumSize = new Size(340, 46);
            paginationBar.Name = "paginationBar";
            paginationBar.Size = new Size(969, 46);
            paginationBar.TabIndex = 1;
            // 
            // UsersControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "UsersControl";
            Size = new Size(1003, 637);
            Load += UsersControl_Load;
            pageLayout.ResumeLayout(false);
            gridCard.ResumeLayout(false);
            gridHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)usersGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private DVLD.WinForms.Shared.Controls.PageHeaderControl pageHeader;
        private DVLD.WinForms.Shared.Controls.StatusBannerControl statusBanner;
        private DVLD.WinForms.Shared.Controls.DirectoryFilterBarControl filterBar;
        private Guna.UI2.WinForms.Guna2Panel gridCard;
        private Panel gridHost;
        private Guna.UI2.WinForms.Guna2DataGridView usersGrid;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colPersonId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colUserName;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewLinkColumn colViewPerson;
        private DataGridViewLinkColumn colEditUser;
        private DataGridViewLinkColumn colChangePassword;
        private Label lblEmptyState;
        private DVLD.WinForms.Shared.Controls.PaginationBarControl paginationBar;
    }
}
