namespace DVLD.WinForms.Features.Drivers
{
    partial class DriversControl
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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle altRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle driverIdStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle personIdStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle natStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle nameStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle activeStyle = new DataGridViewCellStyle();

            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            filterBar = new DVLD.WinForms.Shared.Controls.DirectoryFilterBarControl();
            gridCard = new Guna.UI2.WinForms.Guna2Panel();
            gridHost = new Panel();
            driversGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            colDriverId = new DataGridViewTextBoxColumn();
            colPersonId = new DataGridViewTextBoxColumn();
            colNationalNo = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colCreateDate = new DataGridViewTextBoxColumn();
            colActiveLicenses = new DataGridViewTextBoxColumn();
            colViewPerson = new DataGridViewLinkColumn();
            colLicenseHistory = new DataGridViewLinkColumn();
            lblEmptyState = new Label();
            paginationBar = new DVLD.WinForms.Shared.Controls.PaginationBarControl();

            pageLayout.SuspendLayout();
            gridCard.SuspendLayout();
            gridHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)driversGrid).BeginInit();
            SuspendLayout();

            // 
            // pageLayout
            // 
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(filterBar, 0, 2);
            pageLayout.Controls.Add(gridCard, 0, 4);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 5;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
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
            pageHeader.BadgeText = "● Licensed Drivers";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Success;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "DR";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Search registered drivers and inspect their active credentials or license history";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Drivers Directory";

            // 
            // filterBar
            // 
            filterBar.BackColor = Color.Transparent;
            filterBar.CountText = "0 drivers";
            filterBar.Dock = DockStyle.Fill;
            filterBar.Font = new Font("Segoe UI", 9F);
            filterBar.Location = new Point(16, 94);
            filterBar.Margin = new Padding(0);
            filterBar.Name = "filterBar";
            filterBar.PrimaryButtonText = "↻ Refresh";
            filterBar.SearchPlaceholder = "Search driver ID, national no, or full name...";
            filterBar.ShowFilterCombo = true;
            filterBar.ShowPrimaryButton = true;
            filterBar.Size = new Size(971, 60);
            filterBar.TabIndex = 1;

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
            gridCard.Location = new Point(16, 164);
            gridCard.Margin = new Padding(0);
            gridCard.Name = "gridCard";
            gridCard.Padding = new Padding(1, 4, 1, 1);
            gridCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gridCard.Size = new Size(971, 457);
            gridCard.TabIndex = 2;

            // 
            // gridHost
            // 
            gridHost.BackColor = Color.White;
            gridHost.Controls.Add(lblEmptyState);
            gridHost.Controls.Add(driversGrid);
            gridHost.Dock = DockStyle.Fill;
            gridHost.Location = new Point(1, 4);
            gridHost.Name = "gridHost";
            gridHost.Size = new Size(969, 406);
            gridHost.TabIndex = 0;

            // 
            // driversGrid
            // 
            driversGrid.AllowUserToAddRows = false;
            driversGrid.AllowUserToDeleteRows = false;
            driversGrid.AllowUserToResizeRows = false;
            altRowStyle.BackColor = Color.FromArgb(250, 252, 255);
            driversGrid.AlternatingRowsDefaultCellStyle = altRowStyle;
            driversGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            driversGrid.BackgroundColor = Color.White;
            driversGrid.BorderStyle = BorderStyle.None;
            driversGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            driversGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(12, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.False;
            driversGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            driversGrid.ColumnHeadersHeight = 40;
            driversGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            driversGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                colDriverId,
                colPersonId,
                colNationalNo,
                colFullName,
                colCreateDate,
                colActiveLicenses,
                colViewPerson,
                colLicenseHistory
            });

            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9.25F);
            defaultStyle.ForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.Padding = new Padding(12, 0, 0, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            driversGrid.DefaultCellStyle = defaultStyle;

            driversGrid.Dock = DockStyle.Fill;
            driversGrid.EnableHeadersVisualStyles = false;
            driversGrid.GridColor = Color.FromArgb(241, 245, 249);
            driversGrid.Location = new Point(0, 0);
            driversGrid.MultiSelect = false;
            driversGrid.Name = "driversGrid";
            driversGrid.ReadOnly = true;
            driversGrid.RowHeadersVisible = false;
            driversGrid.RowTemplate.Height = 44;
            driversGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            driversGrid.Size = new Size(969, 406);
            driversGrid.TabIndex = 0;
            driversGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 252, 255);
            driversGrid.ThemeStyle.BackColor = Color.White;
            driversGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            driversGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            driversGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            driversGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            driversGrid.ThemeStyle.HeaderStyle.Height = 40;
            driversGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            driversGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
            driversGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            driversGrid.ThemeStyle.RowsStyle.Height = 44;
            driversGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            driversGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            driverIdStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            driverIdStyle.ForeColor = Color.FromArgb(15, 23, 42);
            colDriverId.DefaultCellStyle = driverIdStyle;
            colDriverId.FillWeight = 78F;
            colDriverId.HeaderText = "DRIVER ID";
            colDriverId.Name = "DriverId";
            colDriverId.ReadOnly = true;

            personIdStyle.ForeColor = Color.FromArgb(100, 116, 139);
            colPersonId.DefaultCellStyle = personIdStyle;
            colPersonId.FillWeight = 78F;
            colPersonId.HeaderText = "PERSON ID";
            colPersonId.Name = "PersonId";
            colPersonId.ReadOnly = true;

            natStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            natStyle.ForeColor = Color.FromArgb(15, 118, 110);
            colNationalNo.DefaultCellStyle = natStyle;
            colNationalNo.FillWeight = 105F;
            colNationalNo.HeaderText = "NATIONAL NO";
            colNationalNo.Name = "NationalNo";
            colNationalNo.ReadOnly = true;

            nameStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            nameStyle.ForeColor = Color.FromArgb(15, 23, 42);
            colFullName.DefaultCellStyle = nameStyle;
            colFullName.FillWeight = 185F;
            colFullName.HeaderText = "FULL NAME";
            colFullName.Name = "FullName";
            colFullName.ReadOnly = true;

            dateStyle.Format = "dd MMM yyyy";
            dateStyle.ForeColor = Color.FromArgb(71, 85, 105);
            colCreateDate.DefaultCellStyle = dateStyle;
            colCreateDate.FillWeight = 105F;
            colCreateDate.HeaderText = "REGISTERED ON";
            colCreateDate.Name = "CreateDate";
            colCreateDate.ReadOnly = true;

            activeStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            activeStyle.ForeColor = Color.FromArgb(21, 128, 61);
            colActiveLicenses.DefaultCellStyle = activeStyle;
            colActiveLicenses.FillWeight = 95F;
            colActiveLicenses.HeaderText = "ACTIVE LICENSES";
            colActiveLicenses.Name = "ActiveLicenses";
            colActiveLicenses.ReadOnly = true;

            colViewPerson.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            colViewPerson.FillWeight = 85F;
            colViewPerson.HeaderText = "PERSON CARD";
            colViewPerson.LinkBehavior = LinkBehavior.HoverUnderline;
            colViewPerson.LinkColor = Color.FromArgb(13, 148, 136);
            colViewPerson.Name = "ViewPerson";
            colViewPerson.ReadOnly = true;
            colViewPerson.Text = "Person Card";
            colViewPerson.TrackVisitedState = false;
            colViewPerson.UseColumnTextForLinkValue = true;

            colLicenseHistory.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            colLicenseHistory.FillWeight = 95F;
            colLicenseHistory.HeaderText = "CREDENTIALS";
            colLicenseHistory.LinkBehavior = LinkBehavior.HoverUnderline;
            colLicenseHistory.LinkColor = Color.FromArgb(13, 148, 136);
            colLicenseHistory.Name = "ViewHistory";
            colLicenseHistory.ReadOnly = true;
            colLicenseHistory.Text = "History ↗";
            colLicenseHistory.TrackVisitedState = false;
            colLicenseHistory.UseColumnTextForLinkValue = true;

            // 
            // lblEmptyState
            // 
            lblEmptyState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmptyState.BackColor = Color.Transparent;
            lblEmptyState.Font = new Font("Segoe UI", 10F);
            lblEmptyState.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyState.Location = new Point(24, 150);
            lblEmptyState.Name = "lblEmptyState";
            lblEmptyState.Size = new Size(921, 60);
            lblEmptyState.TabIndex = 1;
            lblEmptyState.Text = "No driver records loaded yet.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.UseMnemonic = false;
            lblEmptyState.Visible = false;

            // 
            // paginationBar
            // 
            paginationBar.BackColor = Color.FromArgb(248, 250, 252);
            paginationBar.Dock = DockStyle.Bottom;
            paginationBar.Font = new Font("Segoe UI", 9F);
            paginationBar.ItemLabel = "drivers";
            paginationBar.Location = new Point(1, 410);
            paginationBar.Name = "paginationBar";
            paginationBar.Size = new Size(969, 46);
            paginationBar.TabIndex = 1;

            // 
            // DriversControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "DriversControl";
            Size = new Size(1003, 637);
            Load += DriversControl_Load;
            pageLayout.ResumeLayout(false);
            gridCard.ResumeLayout(false);
            gridHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)driversGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.DirectoryFilterBarControl filterBar;
        private Guna.UI2.WinForms.Guna2Panel gridCard;
        private Panel gridHost;
        private Guna.UI2.WinForms.Guna2DataGridView driversGrid;
        private DataGridViewTextBoxColumn colDriverId;
        private DataGridViewTextBoxColumn colPersonId;
        private DataGridViewTextBoxColumn colNationalNo;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colCreateDate;
        private DataGridViewTextBoxColumn colActiveLicenses;
        private DataGridViewLinkColumn colViewPerson;
        private DataGridViewLinkColumn colLicenseHistory;
        private Label lblEmptyState;
        private Shared.Controls.PaginationBarControl paginationBar;
    }
}
