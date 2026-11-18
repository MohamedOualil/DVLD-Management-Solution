namespace DVLD.WinForms.Features.Administration.AuditLogs
{
    partial class AuditLogsControl
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            filterBar = new DVLD.WinForms.Shared.Controls.DirectoryFilterBarControl();
            gridCard = new Guna.UI2.WinForms.Guna2Panel();
            gridHost = new Panel();
            lblEmptyState = new Label();
            auditGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            colLogId = new DataGridViewTextBoxColumn();
            colTimestamp = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colOperation = new DataGridViewTextBoxColumn();
            colTargetEntity = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            detailStrip = new Panel();
            lblDetailValue = new Label();
            lblDetailCaption = new Label();
            paginationBar = new DVLD.WinForms.Shared.Controls.PaginationBarControl();
            pageLayout.SuspendLayout();
            gridCard.SuspendLayout();
            gridHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)auditGrid).BeginInit();
            detailStrip.SuspendLayout();
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
            pageHeader.BadgeText = "● Audit Trail";
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "AL";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.MinimumSize = new Size(560, 68);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Inspect operational activity, authentication history, and administrative modifications";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "System Audit Logs";
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Loading audit trail feed...";
            statusBanner.Dock = DockStyle.Fill;
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 94);
            statusBanner.Margin = new Padding(0);
            statusBanner.MinimumSize = new Size(420, 60);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(971, 60);
            statusBanner.TabIndex = 1;
            statusBanner.Title = "Audit Telemetry";
            // 
            // filterBar
            // 
            filterBar.BackColor = Color.Transparent;
            filterBar.CountText = "0 events";
            filterBar.Dock = DockStyle.Fill;
            filterBar.Font = new Font("Segoe UI", 9F);
            filterBar.Location = new Point(16, 162);
            filterBar.Margin = new Padding(0);
            filterBar.MinimumSize = new Size(560, 60);
            filterBar.Name = "filterBar";
            filterBar.PrimaryButtonText = "Refresh Logs";
            filterBar.SearchPlaceholder = "Search by user, operation, target entity, or ID...";
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
            gridCard.Controls.Add(detailStrip);
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
            gridHost.Controls.Add(auditGrid);
            gridHost.Dock = DockStyle.Fill;
            gridHost.Location = new Point(1, 1);
            gridHost.Name = "gridHost";
            gridHost.Size = new Size(969, 303);
            gridHost.TabIndex = 0;
            // 
            // lblEmptyState
            // 
            lblEmptyState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmptyState.BackColor = Color.Transparent;
            lblEmptyState.Font = new Font("Segoe UI", 10F);
            lblEmptyState.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyState.Location = new Point(24, 110);
            lblEmptyState.Name = "lblEmptyState";
            lblEmptyState.Size = new Size(921, 60);
            lblEmptyState.TabIndex = 1;
            lblEmptyState.Text = "No audit log entries match the current filter.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.UseMnemonic = false;
            lblEmptyState.Visible = false;
            // 
            // auditGrid
            // 
            auditGrid.AllowUserToAddRows = false;
            auditGrid.AllowUserToDeleteRows = false;
            auditGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 252, 255);
            auditGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            auditGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            auditGrid.ColumnHeadersHeight = 40;
            auditGrid.Columns.AddRange(new DataGridViewColumn[] { colLogId, colTimestamp, colUsername, colRole, colOperation, colTargetEntity, colStatus });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9.25F);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle10.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(240, 253, 250);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            auditGrid.DefaultCellStyle = dataGridViewCellStyle10;
            auditGrid.Dock = DockStyle.Fill;
            auditGrid.GridColor = Color.FromArgb(241, 245, 249);
            auditGrid.Location = new Point(0, 0);
            auditGrid.MultiSelect = false;
            auditGrid.Name = "auditGrid";
            auditGrid.ReadOnly = true;
            auditGrid.RowHeadersVisible = false;
            auditGrid.RowTemplate.Height = 42;
            auditGrid.Size = new Size(969, 303);
            auditGrid.TabIndex = 0;
            auditGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 252, 255);
            auditGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            auditGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            auditGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            auditGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            auditGrid.ThemeStyle.BackColor = Color.White;
            auditGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            auditGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            auditGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            auditGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            auditGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            auditGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            auditGrid.ThemeStyle.HeaderStyle.Height = 40;
            auditGrid.ThemeStyle.ReadOnly = true;
            auditGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            auditGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            auditGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
            auditGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            auditGrid.ThemeStyle.RowsStyle.Height = 42;
            auditGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            auditGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            // 
            // colLogId
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 85, 105);
            colLogId.DefaultCellStyle = dataGridViewCellStyle3;
            colLogId.FillWeight = 66F;
            colLogId.HeaderText = "LOG ID";
            colLogId.Name = "colLogId";
            colLogId.ReadOnly = true;
            // 
            // colTimestamp
            // 
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle4.Format = "dd MMM HH:mm:ss";
            colTimestamp.DefaultCellStyle = dataGridViewCellStyle4;
            colTimestamp.FillWeight = 112F;
            colTimestamp.HeaderText = "TIMESTAMP";
            colTimestamp.Name = "colTimestamp";
            colTimestamp.ReadOnly = true;
            // 
            // colUsername
            // 
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(15, 23, 42);
            colUsername.DefaultCellStyle = dataGridViewCellStyle5;
            colUsername.FillWeight = 105F;
            colUsername.HeaderText = "OPERATOR";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colRole
            // 
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(100, 116, 139);
            colRole.DefaultCellStyle = dataGridViewCellStyle6;
            colRole.FillWeight = 82F;
            colRole.HeaderText = "ROLE";
            colRole.Name = "colRole";
            colRole.ReadOnly = true;
            // 
            // colOperation
            // 
            dataGridViewCellStyle7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(15, 118, 110);
            colOperation.DefaultCellStyle = dataGridViewCellStyle7;
            colOperation.FillWeight = 128F;
            colOperation.HeaderText = "OPERATION";
            colOperation.Name = "colOperation";
            colOperation.ReadOnly = true;
            // 
            // colTargetEntity
            // 
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(51, 65, 85);
            colTargetEntity.DefaultCellStyle = dataGridViewCellStyle8;
            colTargetEntity.FillWeight = 175F;
            colTargetEntity.HeaderText = "TARGET ENTITY";
            colTargetEntity.Name = "colTargetEntity";
            colTargetEntity.ReadOnly = true;
            // 
            // colStatus
            // 
            dataGridViewCellStyle9.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            colStatus.DefaultCellStyle = dataGridViewCellStyle9;
            colStatus.FillWeight = 82F;
            colStatus.HeaderText = "OUTCOME";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // detailStrip
            // 
            detailStrip.BackColor = Color.FromArgb(248, 250, 252);
            detailStrip.Controls.Add(lblDetailValue);
            detailStrip.Controls.Add(lblDetailCaption);
            detailStrip.Dock = DockStyle.Bottom;
            detailStrip.Location = new Point(1, 304);
            detailStrip.Name = "detailStrip";
            detailStrip.Size = new Size(969, 38);
            detailStrip.TabIndex = 2;
            // 
            // lblDetailValue
            // 
            lblDetailValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetailValue.AutoEllipsis = true;
            lblDetailValue.Font = new Font("Segoe UI", 8.75F);
            lblDetailValue.ForeColor = Color.FromArgb(51, 65, 85);
            lblDetailValue.Location = new Point(112, 10);
            lblDetailValue.Name = "lblDetailValue";
            lblDetailValue.Size = new Size(842, 18);
            lblDetailValue.TabIndex = 1;
            lblDetailValue.Text = "Select any audit event row above to inspect detailed payload notes.";
            lblDetailValue.UseMnemonic = false;
            // 
            // lblDetailCaption
            // 
            lblDetailCaption.AutoSize = true;
            lblDetailCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblDetailCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblDetailCaption.Location = new Point(16, 12);
            lblDetailCaption.Name = "lblDetailCaption";
            lblDetailCaption.Size = new Size(77, 12);
            lblDetailCaption.TabIndex = 0;
            lblDetailCaption.Text = "EVENT DETAILS:";
            lblDetailCaption.UseMnemonic = false;
            // 
            // paginationBar
            // 
            paginationBar.BackColor = Color.FromArgb(248, 250, 252);
            paginationBar.Dock = DockStyle.Bottom;
            paginationBar.Font = new Font("Segoe UI", 9F);
            paginationBar.ItemLabel = "events";
            paginationBar.Location = new Point(1, 342);
            paginationBar.MinimumSize = new Size(340, 46);
            paginationBar.Name = "paginationBar";
            paginationBar.Size = new Size(969, 46);
            paginationBar.TabIndex = 1;
            // 
            // AuditLogsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "AuditLogsControl";
            Size = new Size(1003, 637);
            Load += AuditLogsControl_Load;
            pageLayout.ResumeLayout(false);
            gridCard.ResumeLayout(false);
            gridHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)auditGrid).EndInit();
            detailStrip.ResumeLayout(false);
            detailStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.StatusBannerControl statusBanner;
        private Shared.Controls.DirectoryFilterBarControl filterBar;
        private Guna.UI2.WinForms.Guna2Panel gridCard;
        private Panel gridHost;
        private Guna.UI2.WinForms.Guna2DataGridView auditGrid;
        private DataGridViewTextBoxColumn colLogId;
        private DataGridViewTextBoxColumn colTimestamp;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colOperation;
        private DataGridViewTextBoxColumn colTargetEntity;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblEmptyState;
        private Panel detailStrip;
        private Label lblDetailCaption;
        private Label lblDetailValue;
        private Shared.Controls.PaginationBarControl paginationBar;
    }
}
