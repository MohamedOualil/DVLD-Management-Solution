namespace DVLD.WinForms.Features.Applications.DetainedLicenses
{
    partial class DetainedLicensesTabControl
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
            DataGridViewCellStyle altStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle fineStyle = new DataGridViewCellStyle();

            pnlDetainedToolbar = new Panel();
            txtDetainedSearch = new Guna.UI2.WinForms.Guna2TextBox();
            cbDetainedStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            btnDetainShortcut = new Guna.UI2.WinForms.Guna2Button();
            lblDetainedMessage = new Label();
            DetainedDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            DetainId = new DataGridViewTextBoxColumn();
            DetainedLicenseId = new DataGridViewTextBoxColumn();
            DetainedFullName = new DataGridViewTextBoxColumn();
            DetainedNationalNo = new DataGridViewTextBoxColumn();
            DetainDate = new DataGridViewTextBoxColumn();
            FineFees = new DataGridViewTextBoxColumn();
            DetainStatus = new DataGridViewTextBoxColumn();
            ReleaseDate = new DataGridViewTextBoxColumn();
            ReleaseAppId = new DataGridViewTextBoxColumn();
            DetainedPersonId = new DataGridViewTextBoxColumn();
            detainedPaginationFooter = new DVLD.WinForms.Shared.Controls.PaginationBarControl();
            DetainedActionMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            DetainedShowPerson = new ToolStripMenuItem();
            DetainedShowLicense = new ToolStripMenuItem();
            DetainedShowHistory = new ToolStripMenuItem();
            toolStripSeparatorDetained = new ToolStripSeparator();
            DetainedReleaseAction = new ToolStripMenuItem();

            pnlDetainedToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DetainedDataGridView).BeginInit();
            DetainedActionMenu.SuspendLayout();
            SuspendLayout();

            // 
            // pnlDetainedToolbar
            // 
            pnlDetainedToolbar.BackColor = Color.White;
            pnlDetainedToolbar.Controls.Add(btnDetainShortcut);
            pnlDetainedToolbar.Controls.Add(txtDetainedSearch);
            pnlDetainedToolbar.Controls.Add(cbDetainedStatus);
            pnlDetainedToolbar.Dock = DockStyle.Top;
            pnlDetainedToolbar.Location = new Point(0, 0);
            pnlDetainedToolbar.Name = "pnlDetainedToolbar";
            pnlDetainedToolbar.Size = new Size(943, 72);
            pnlDetainedToolbar.TabIndex = 1;

            // 
            // txtDetainedSearch
            // 
            txtDetainedSearch.BorderColor = Color.FromArgb(220, 230, 238);
            txtDetainedSearch.BorderRadius = 8;
            txtDetainedSearch.Cursor = Cursors.IBeam;
            txtDetainedSearch.CustomizableEdges = customizableEdges1;
            txtDetainedSearch.DefaultText = "";
            txtDetainedSearch.FillColor = Color.FromArgb(248, 250, 252);
            txtDetainedSearch.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtDetainedSearch.Font = new Font("Segoe UI", 9.5F);
            txtDetainedSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtDetainedSearch.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtDetainedSearch.Location = new Point(16, 16);
            txtDetainedSearch.Name = "txtDetainedSearch";
            txtDetainedSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtDetainedSearch.PlaceholderText = "Search Detain ID, License ID, or Driver...";
            txtDetainedSearch.SelectedText = "";
            txtDetainedSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtDetainedSearch.Size = new Size(360, 40);
            txtDetainedSearch.TabIndex = 0;
            txtDetainedSearch.TextOffset = new Point(8, 0);

            // 
            // cbDetainedStatus
            // 
            cbDetainedStatus.BackColor = Color.Transparent;
            cbDetainedStatus.BorderColor = Color.FromArgb(220, 230, 238);
            cbDetainedStatus.BorderRadius = 8;
            cbDetainedStatus.CustomizableEdges = customizableEdges3;
            cbDetainedStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbDetainedStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDetainedStatus.FillColor = Color.FromArgb(248, 250, 252);
            cbDetainedStatus.FocusedColor = Color.FromArgb(13, 148, 136);
            cbDetainedStatus.Font = new Font("Segoe UI", 9.5F);
            cbDetainedStatus.ForeColor = Color.FromArgb(15, 23, 42);
            cbDetainedStatus.ItemHeight = 34;
            cbDetainedStatus.Items.AddRange(new object[] { "All Records", "Detained", "Released" });
            cbDetainedStatus.Location = new Point(388, 16);
            cbDetainedStatus.Name = "cbDetainedStatus";
            cbDetainedStatus.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbDetainedStatus.Size = new Size(170, 40);
            cbDetainedStatus.TabIndex = 1;

            // 
            // btnDetainShortcut
            // 
            btnDetainShortcut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetainShortcut.BorderColor = Color.FromArgb(153, 246, 228);
            btnDetainShortcut.BorderRadius = 8;
            btnDetainShortcut.BorderThickness = 1;
            btnDetainShortcut.Cursor = Cursors.Hand;
            btnDetainShortcut.CustomizableEdges = customizableEdges5;
            btnDetainShortcut.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            btnDetainShortcut.DisabledState.FillColor = Color.FromArgb(241, 245, 249);
            btnDetainShortcut.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            btnDetainShortcut.FillColor = Color.FromArgb(240, 253, 250);
            btnDetainShortcut.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDetainShortcut.ForeColor = Color.FromArgb(13, 148, 136);
            btnDetainShortcut.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            btnDetainShortcut.HoverState.FillColor = Color.FromArgb(204, 251, 241);
            btnDetainShortcut.HoverState.ForeColor = Color.FromArgb(15, 118, 110);
            btnDetainShortcut.Location = new Point(745, 16);
            btnDetainShortcut.Name = "btnDetainShortcut";
            btnDetainShortcut.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDetainShortcut.Size = new Size(182, 40);
            btnDetainShortcut.TabIndex = 2;
            btnDetainShortcut.Text = "Detain / Release License";

            // 
            // lblDetainedMessage
            // 
            lblDetainedMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetainedMessage.BackColor = Color.Transparent;
            lblDetainedMessage.Font = new Font("Segoe UI", 10F);
            lblDetainedMessage.ForeColor = Color.FromArgb(100, 116, 139);
            lblDetainedMessage.Location = new Point(24, 210);
            lblDetainedMessage.Name = "lblDetainedMessage";
            lblDetainedMessage.Size = new Size(895, 36);
            lblDetainedMessage.TabIndex = 3;
            lblDetainedMessage.Text = "No detained license records found.";
            lblDetainedMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblDetainedMessage.UseMnemonic = false;
            lblDetainedMessage.Visible = false;

            // 
            // DetainedDataGridView
            // 
            DetainedDataGridView.AllowUserToAddRows = false;
            DetainedDataGridView.AllowUserToDeleteRows = false;
            DetainedDataGridView.AllowUserToResizeRows = false;
            altStyle.BackColor = Color.White;
            DetainedDataGridView.AlternatingRowsDefaultCellStyle = altStyle;
            DetainedDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DetainedDataGridView.BackgroundColor = Color.White;
            DetainedDataGridView.BorderStyle = BorderStyle.None;
            DetainedDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DetainedDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(16, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.True;
            DetainedDataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            DetainedDataGridView.ColumnHeadersHeight = 44;
            DetainedDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DetainedDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                DetainId,
                DetainedLicenseId,
                DetainedFullName,
                DetainedNationalNo,
                DetainDate,
                FineFees,
                DetainStatus,
                ReleaseDate,
                ReleaseAppId,
                DetainedPersonId
            });
            DetainedDataGridView.ContextMenuStrip = DetainedActionMenu;
            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9.5F);
            defaultStyle.ForeColor = Color.FromArgb(51, 65, 85);
            defaultStyle.Padding = new Padding(16, 0, 8, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            DetainedDataGridView.DefaultCellStyle = defaultStyle;
            DetainedDataGridView.Dock = DockStyle.Fill;
            DetainedDataGridView.EnableHeadersVisualStyles = false;
            DetainedDataGridView.GridColor = Color.FromArgb(241, 245, 249);
            DetainedDataGridView.Location = new Point(0, 72);
            DetainedDataGridView.MultiSelect = false;
            DetainedDataGridView.Name = "DetainedDataGridView";
            DetainedDataGridView.ReadOnly = true;
            DetainedDataGridView.RowHeadersVisible = false;
            DetainedDataGridView.RowTemplate.Height = 56;
            DetainedDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DetainedDataGridView.Size = new Size(943, 359);
            DetainedDataGridView.TabIndex = 0;
            DetainedDataGridView.ThemeStyle.BackColor = Color.White;
            DetainedDataGridView.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            DetainedDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            DetainedDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
            DetainedDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            DetainedDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DetainedDataGridView.ThemeStyle.HeaderStyle.Height = 44;
            DetainedDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            DetainedDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            DetainedDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(51, 65, 85);
            DetainedDataGridView.ThemeStyle.RowsStyle.Height = 56;
            DetainedDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            DetainedDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            DetainId.FillWeight = 56F;
            DetainId.HeaderText = "DETAIN ID";
            DetainId.Name = "DetainId";
            DetainId.ReadOnly = true;

            DetainedLicenseId.FillWeight = 66F;
            DetainedLicenseId.HeaderText = "LICENSE ID";
            DetainedLicenseId.Name = "DetainedLicenseId";
            DetainedLicenseId.ReadOnly = true;

            DetainedFullName.FillWeight = 150F;
            DetainedFullName.HeaderText = "DRIVER";
            DetainedFullName.Name = "FullName";
            DetainedFullName.ReadOnly = true;

            DetainedNationalNo.FillWeight = 98F;
            DetainedNationalNo.HeaderText = "NATIONAL NO";
            DetainedNationalNo.Name = "NationalNo";
            DetainedNationalNo.ReadOnly = true;

            DetainDate.FillWeight = 98F;
            DetainDate.HeaderText = "DETAINED ON";
            DetainDate.Name = "DetainDate";
            DetainDate.ReadOnly = true;

            fineStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            fineStyle.ForeColor = Color.FromArgb(180, 83, 9);
            fineStyle.Format = "C2";
            FineFees.DefaultCellStyle = fineStyle;
            FineFees.FillWeight = 68F;
            FineFees.HeaderText = "FINE FEES";
            FineFees.Name = "FineFees";
            FineFees.ReadOnly = true;

            DetainStatus.FillWeight = 86F;
            DetainStatus.HeaderText = "STATUS";
            DetainStatus.Name = "Status";
            DetainStatus.ReadOnly = true;
            DetainStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

            ReleaseDate.FillWeight = 98F;
            ReleaseDate.HeaderText = "RELEASED ON";
            ReleaseDate.Name = "ReleaseDate";
            ReleaseDate.ReadOnly = true;

            ReleaseAppId.FillWeight = 68F;
            ReleaseAppId.HeaderText = "RELEASE APP";
            ReleaseAppId.Name = "ReleaseAppId";
            ReleaseAppId.ReadOnly = true;

            DetainedPersonId.Name = "DetainedPersonId";
            DetainedPersonId.ReadOnly = true;
            DetainedPersonId.Visible = false;

            // 
            // detainedPaginationFooter
            // 
            detainedPaginationFooter.BackColor = Color.FromArgb(248, 250, 252);
            detainedPaginationFooter.Dock = DockStyle.Bottom;
            detainedPaginationFooter.Font = new Font("Segoe UI", 9F);
            detainedPaginationFooter.ItemLabel = "detained licenses";
            detainedPaginationFooter.Location = new Point(0, 431);
            detainedPaginationFooter.Margin = new Padding(0);
            detainedPaginationFooter.Name = "detainedPaginationFooter";
            detainedPaginationFooter.Size = new Size(943, 46);
            detainedPaginationFooter.TabIndex = 2;

            // 
            // DetainedActionMenu
            // 
            DetainedActionMenu.BackColor = Color.White;
            DetainedActionMenu.Font = new Font("Segoe UI", 9.5F);
            DetainedActionMenu.ImageScalingSize = new Size(18, 18);
            DetainedActionMenu.Items.AddRange(new ToolStripItem[]
            {
                DetainedShowPerson,
                DetainedShowLicense,
                DetainedShowHistory,
                toolStripSeparatorDetained,
                DetainedReleaseAction
            });
            DetainedActionMenu.Name = "DetainedActionMenu";
            DetainedActionMenu.Size = new Size(228, 104);

            DetainedShowPerson.Name = "DetainedShowPerson";
            DetainedShowPerson.Size = new Size(227, 22);
            DetainedShowPerson.Text = "Show Driver Person Details";

            DetainedShowLicense.Name = "DetainedShowLicense";
            DetainedShowLicense.Size = new Size(227, 22);
            DetainedShowLicense.Text = "Show License Card";

            DetainedShowHistory.Name = "DetainedShowHistory";
            DetainedShowHistory.Size = new Size(227, 22);
            DetainedShowHistory.Text = "Driver License History";

            toolStripSeparatorDetained.Name = "toolStripSeparatorDetained";
            toolStripSeparatorDetained.Size = new Size(224, 6);

            DetainedReleaseAction.Name = "DetainedReleaseAction";
            DetainedReleaseAction.Size = new Size(227, 22);
            DetainedReleaseAction.Text = "Release Detained License";

            // 
            // DetainedLicensesTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblDetainedMessage);
            Controls.Add(DetainedDataGridView);
            Controls.Add(pnlDetainedToolbar);
            Controls.Add(detainedPaginationFooter);
            Font = new Font("Segoe UI", 9F);
            Name = "DetainedLicensesTabControl";
            Size = new Size(943, 477);
            pnlDetainedToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DetainedDataGridView).EndInit();
            DetainedActionMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlDetainedToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtDetainedSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbDetainedStatus;
        private Guna.UI2.WinForms.Guna2Button btnDetainShortcut;
        private Label lblDetainedMessage;
        private Guna.UI2.WinForms.Guna2DataGridView DetainedDataGridView;
        private DataGridViewTextBoxColumn DetainId;
        private DataGridViewTextBoxColumn DetainedLicenseId;
        private DataGridViewTextBoxColumn DetainedFullName;
        private DataGridViewTextBoxColumn DetainedNationalNo;
        private DataGridViewTextBoxColumn DetainDate;
        private DataGridViewTextBoxColumn FineFees;
        private DataGridViewTextBoxColumn DetainStatus;
        private DataGridViewTextBoxColumn ReleaseDate;
        private DataGridViewTextBoxColumn ReleaseAppId;
        private DataGridViewTextBoxColumn DetainedPersonId;
        private DVLD.WinForms.Shared.Controls.PaginationBarControl detainedPaginationFooter;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip DetainedActionMenu;
        private ToolStripMenuItem DetainedShowPerson;
        private ToolStripMenuItem DetainedShowLicense;
        private ToolStripMenuItem DetainedShowHistory;
        private ToolStripSeparator toolStripSeparatorDetained;
        private ToolStripMenuItem DetainedReleaseAction;
    }
}
