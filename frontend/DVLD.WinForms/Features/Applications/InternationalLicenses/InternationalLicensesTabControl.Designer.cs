namespace DVLD.WinForms.Features.Applications.InternationalLicenses
{
    partial class InternationalLicensesTabControl
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
            DataGridViewCellStyle altStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();

            pnlIntlToolbar = new Panel();
            txtIntlSearch = new Guna.UI2.WinForms.Guna2TextBox();
            cbIntlStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            lblIntlMessage = new Label();
            IntlDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            IntlLicenseId = new DataGridViewTextBoxColumn();
            IntlFullName = new DataGridViewTextBoxColumn();
            IntlNationalNo = new DataGridViewTextBoxColumn();
            IntlLocalLicenseId = new DataGridViewTextBoxColumn();
            IntlApplicationId = new DataGridViewTextBoxColumn();
            IntlIssueDate = new DataGridViewTextBoxColumn();
            IntlExpirationDate = new DataGridViewTextBoxColumn();
            IntlStatus = new DataGridViewTextBoxColumn();
            IntlPersonId = new DataGridViewTextBoxColumn();
            intlPaginationFooter = new DVLD.WinForms.Shared.Controls.PaginationBarControl();
            IntlActionMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            IntlShowPerson = new ToolStripMenuItem();
            IntlShowLicense = new ToolStripMenuItem();
            IntlShowHistory = new ToolStripMenuItem();

            pnlIntlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IntlDataGridView).BeginInit();
            IntlActionMenu.SuspendLayout();
            SuspendLayout();

            // 
            // pnlIntlToolbar
            // 
            pnlIntlToolbar.BackColor = Color.White;
            pnlIntlToolbar.Controls.Add(txtIntlSearch);
            pnlIntlToolbar.Controls.Add(cbIntlStatus);
            pnlIntlToolbar.Dock = DockStyle.Top;
            pnlIntlToolbar.Location = new Point(0, 0);
            pnlIntlToolbar.Name = "pnlIntlToolbar";
            pnlIntlToolbar.Size = new Size(943, 72);
            pnlIntlToolbar.TabIndex = 1;

            // 
            // txtIntlSearch
            // 
            txtIntlSearch.BorderColor = Color.FromArgb(220, 230, 238);
            txtIntlSearch.BorderRadius = 8;
            txtIntlSearch.Cursor = Cursors.IBeam;
            txtIntlSearch.CustomizableEdges = customizableEdges1;
            txtIntlSearch.DefaultText = "";
            txtIntlSearch.FillColor = Color.FromArgb(248, 250, 252);
            txtIntlSearch.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtIntlSearch.Font = new Font("Segoe UI", 9.5F);
            txtIntlSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtIntlSearch.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtIntlSearch.Location = new Point(16, 16);
            txtIntlSearch.Name = "txtIntlSearch";
            txtIntlSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtIntlSearch.PlaceholderText = "Search Int'l ID, License ID, or Driver...";
            txtIntlSearch.SelectedText = "";
            txtIntlSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtIntlSearch.Size = new Size(360, 40);
            txtIntlSearch.TabIndex = 0;
            txtIntlSearch.TextOffset = new Point(8, 0);

            // 
            // cbIntlStatus
            // 
            cbIntlStatus.BackColor = Color.Transparent;
            cbIntlStatus.BorderColor = Color.FromArgb(220, 230, 238);
            cbIntlStatus.BorderRadius = 8;
            cbIntlStatus.CustomizableEdges = customizableEdges3;
            cbIntlStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbIntlStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIntlStatus.FillColor = Color.FromArgb(248, 250, 252);
            cbIntlStatus.FocusedColor = Color.FromArgb(13, 148, 136);
            cbIntlStatus.Font = new Font("Segoe UI", 9.5F);
            cbIntlStatus.ForeColor = Color.FromArgb(15, 23, 42);
            cbIntlStatus.ItemHeight = 34;
            cbIntlStatus.Items.AddRange(new object[] { "All Statuses", "Active", "Expired" });
            cbIntlStatus.Location = new Point(388, 16);
            cbIntlStatus.Name = "cbIntlStatus";
            cbIntlStatus.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbIntlStatus.Size = new Size(170, 40);
            cbIntlStatus.TabIndex = 1;

            // 
            // lblIntlMessage
            // 
            lblIntlMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblIntlMessage.BackColor = Color.Transparent;
            lblIntlMessage.Font = new Font("Segoe UI", 10F);
            lblIntlMessage.ForeColor = Color.FromArgb(100, 116, 139);
            lblIntlMessage.Location = new Point(24, 210);
            lblIntlMessage.Name = "lblIntlMessage";
            lblIntlMessage.Size = new Size(895, 36);
            lblIntlMessage.TabIndex = 3;
            lblIntlMessage.Text = "No international licenses found.";
            lblIntlMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblIntlMessage.UseMnemonic = false;
            lblIntlMessage.Visible = false;

            // 
            // IntlDataGridView
            // 
            IntlDataGridView.AllowUserToAddRows = false;
            IntlDataGridView.AllowUserToDeleteRows = false;
            IntlDataGridView.AllowUserToResizeRows = false;
            altStyle.BackColor = Color.White;
            IntlDataGridView.AlternatingRowsDefaultCellStyle = altStyle;
            IntlDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IntlDataGridView.BackgroundColor = Color.White;
            IntlDataGridView.BorderStyle = BorderStyle.None;
            IntlDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            IntlDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(16, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.True;
            IntlDataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
            IntlDataGridView.ColumnHeadersHeight = 44;
            IntlDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            IntlDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                IntlLicenseId,
                IntlFullName,
                IntlNationalNo,
                IntlLocalLicenseId,
                IntlApplicationId,
                IntlIssueDate,
                IntlExpirationDate,
                IntlStatus,
                IntlPersonId
            });
            IntlDataGridView.ContextMenuStrip = IntlActionMenu;
            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9.5F);
            defaultStyle.ForeColor = Color.FromArgb(51, 65, 85);
            defaultStyle.Padding = new Padding(16, 0, 8, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            IntlDataGridView.DefaultCellStyle = defaultStyle;
            IntlDataGridView.Dock = DockStyle.Fill;
            IntlDataGridView.EnableHeadersVisualStyles = false;
            IntlDataGridView.GridColor = Color.FromArgb(241, 245, 249);
            IntlDataGridView.Location = new Point(0, 72);
            IntlDataGridView.MultiSelect = false;
            IntlDataGridView.Name = "IntlDataGridView";
            IntlDataGridView.ReadOnly = true;
            IntlDataGridView.RowHeadersVisible = false;
            IntlDataGridView.RowTemplate.Height = 56;
            IntlDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IntlDataGridView.Size = new Size(943, 359);
            IntlDataGridView.TabIndex = 0;
            IntlDataGridView.ThemeStyle.BackColor = Color.White;
            IntlDataGridView.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            IntlDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            IntlDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
            IntlDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            IntlDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            IntlDataGridView.ThemeStyle.HeaderStyle.Height = 44;
            IntlDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            IntlDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            IntlDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(51, 65, 85);
            IntlDataGridView.ThemeStyle.RowsStyle.Height = 56;
            IntlDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            IntlDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            IntlLicenseId.FillWeight = 62F;
            IntlLicenseId.HeaderText = "INT'L ID";
            IntlLicenseId.Name = "IntlLicenseId";
            IntlLicenseId.ReadOnly = true;

            IntlFullName.FillWeight = 180F;
            IntlFullName.HeaderText = "DRIVER";
            IntlFullName.Name = "FullName";
            IntlFullName.ReadOnly = true;

            IntlNationalNo.FillWeight = 90F;
            IntlNationalNo.HeaderText = "NATIONAL NO";
            IntlNationalNo.Name = "NationalNo";
            IntlNationalNo.ReadOnly = true;

            IntlLocalLicenseId.FillWeight = 82F;
            IntlLocalLicenseId.HeaderText = "LOCAL LICENSE";
            IntlLocalLicenseId.Name = "IntlLocalLicenseId";
            IntlLocalLicenseId.ReadOnly = true;

            IntlApplicationId.FillWeight = 66F;
            IntlApplicationId.HeaderText = "APP ID";
            IntlApplicationId.Name = "IntlApplicationId";
            IntlApplicationId.ReadOnly = true;

            IntlIssueDate.FillWeight = 92F;
            IntlIssueDate.HeaderText = "ISSUED ON";
            IntlIssueDate.Name = "IntlIssueDate";
            IntlIssueDate.ReadOnly = true;

            IntlExpirationDate.FillWeight = 92F;
            IntlExpirationDate.HeaderText = "EXPIRES ON";
            IntlExpirationDate.Name = "IntlExpirationDate";
            IntlExpirationDate.ReadOnly = true;

            IntlStatus.FillWeight = 88F;
            IntlStatus.HeaderText = "STATUS";
            IntlStatus.Name = "Status";
            IntlStatus.ReadOnly = true;
            IntlStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

            IntlPersonId.Name = "IntlPersonId";
            IntlPersonId.ReadOnly = true;
            IntlPersonId.Visible = false;

            // 
            // intlPaginationFooter
            // 
            intlPaginationFooter.BackColor = Color.FromArgb(248, 250, 252);
            intlPaginationFooter.Dock = DockStyle.Bottom;
            intlPaginationFooter.Font = new Font("Segoe UI", 9F);
            intlPaginationFooter.ItemLabel = "international licenses";
            intlPaginationFooter.Location = new Point(0, 431);
            intlPaginationFooter.Margin = new Padding(0);
            intlPaginationFooter.Name = "intlPaginationFooter";
            intlPaginationFooter.Size = new Size(943, 46);
            intlPaginationFooter.TabIndex = 2;

            // 
            // IntlActionMenu
            // 
            IntlActionMenu.BackColor = Color.White;
            IntlActionMenu.Font = new Font("Segoe UI", 9.5F);
            IntlActionMenu.ImageScalingSize = new Size(18, 18);
            IntlActionMenu.Items.AddRange(new ToolStripItem[] { IntlShowPerson, IntlShowLicense, IntlShowHistory });
            IntlActionMenu.Name = "IntlActionMenu";
            IntlActionMenu.Size = new Size(220, 76);

            IntlShowPerson.Name = "IntlShowPerson";
            IntlShowPerson.Size = new Size(219, 22);
            IntlShowPerson.Text = "Show Driver Person Details";

            IntlShowLicense.Name = "IntlShowLicense";
            IntlShowLicense.Size = new Size(219, 22);
            IntlShowLicense.Text = "Show Local License Card";

            IntlShowHistory.Name = "IntlShowHistory";
            IntlShowHistory.Size = new Size(219, 22);
            IntlShowHistory.Text = "Driver License History";

            // 
            // InternationalLicensesTabControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblIntlMessage);
            Controls.Add(IntlDataGridView);
            Controls.Add(pnlIntlToolbar);
            Controls.Add(intlPaginationFooter);
            Font = new Font("Segoe UI", 9F);
            Name = "InternationalLicensesTabControl";
            Size = new Size(943, 477);
            pnlIntlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)IntlDataGridView).EndInit();
            IntlActionMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlIntlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtIntlSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbIntlStatus;
        private Label lblIntlMessage;
        private Guna.UI2.WinForms.Guna2DataGridView IntlDataGridView;
        private DataGridViewTextBoxColumn IntlLicenseId;
        private DataGridViewTextBoxColumn IntlFullName;
        private DataGridViewTextBoxColumn IntlNationalNo;
        private DataGridViewTextBoxColumn IntlLocalLicenseId;
        private DataGridViewTextBoxColumn IntlApplicationId;
        private DataGridViewTextBoxColumn IntlIssueDate;
        private DataGridViewTextBoxColumn IntlExpirationDate;
        private DataGridViewTextBoxColumn IntlStatus;
        private DataGridViewTextBoxColumn IntlPersonId;
        private DVLD.WinForms.Shared.Controls.PaginationBarControl intlPaginationFooter;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip IntlActionMenu;
        private ToolStripMenuItem IntlShowPerson;
        private ToolStripMenuItem IntlShowLicense;
        private ToolStripMenuItem IntlShowHistory;
    }
}
