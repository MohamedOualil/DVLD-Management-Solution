namespace DVLD.WinForms.Features.Licenses.LicenseHistory;

partial class LicenseHistoryControl
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
        components = new System.ComponentModel.Container();
        DataGridViewCellStyle localAltStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localHeaderStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localDefaultStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localIdStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localAppIdStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localIssueDateStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localExpiryDateStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle localStatusStyle = new DataGridViewCellStyle();

        DataGridViewCellStyle intlAltStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlHeaderStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlDefaultStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlIdStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlAppIdStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlLocalIdStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlIssueDateStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlExpiryDateStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle intlStatusStyle = new DataGridViewCellStyle();

        pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();

        personPanel = new Guna.UI2.WinForms.Guna2Panel();
        personDetails = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();

        summaryPanel = new Guna.UI2.WinForms.Guna2Panel();
        summaryHeading = new Label();
        summarySubheading = new Label();
        localCountPanel = new Guna.UI2.WinForms.Guna2Panel();
        lblLocalSubTag = new Label();
        localCountValue = new Label();
        localCountCaption = new Label();
        internationalCountPanel = new Guna.UI2.WinForms.Guna2Panel();
        lblIntlSubTag = new Label();
        internationalCountValue = new Label();
        internationalCountCaption = new Label();
        standingPanel = new Guna.UI2.WinForms.Guna2Panel();
        lblStandingTitle = new Label();
        lblStandingDesc = new Label();
        hintPanel = new Guna.UI2.WinForms.Guna2Panel();
        hintIcon = new Label();
        hintText = new Label();

        historyPanel = new Guna.UI2.WinForms.Guna2Panel();
        historyToolbar = new Panel();
        tabSwitcherPanel = new Guna.UI2.WinForms.Guna2Panel();
        btnLocalTab = new Guna.UI2.WinForms.Guna2Button();
        btnInternationalTab = new Guna.UI2.WinForms.Guna2Button();
        txtFilterHistory = new Guna.UI2.WinForms.Guna2TextBox();
        historyContentHost = new Panel();

        localTab = new Panel();
        localGridHost = new Panel();
        localGrid = new Guna.UI2.WinForms.Guna2DataGridView();
        localIdColumn = new DataGridViewTextBoxColumn();
        localLocalColumn = new DataGridViewTextBoxColumn();
        localClassColumn = new DataGridViewTextBoxColumn();
        localIssueColumn = new DataGridViewTextBoxColumn();
        localExpiryColumn = new DataGridViewTextBoxColumn();
        localStatusColumn = new DataGridViewTextBoxColumn();
        localActionColumn = new DataGridViewLinkColumn();
        localMessage = new Label();
        localPaginationBar = new DVLD.WinForms.Shared.Controls.PaginationBarControl();

        internationalTab = new Panel();
        internationalGridHost = new Panel();
        internationalGrid = new Guna.UI2.WinForms.Guna2DataGridView();
        internationalIdColumn = new DataGridViewTextBoxColumn();
        internationalApplicationColumn = new DataGridViewTextBoxColumn();
        internationalLocalColumn = new DataGridViewTextBoxColumn();
        internationalIssueColumn = new DataGridViewTextBoxColumn();
        internationalExpiryColumn = new DataGridViewTextBoxColumn();
        internationalStatusColumn = new DataGridViewTextBoxColumn();
        internationalActionColumn = new DataGridViewLinkColumn();
        internationalMessage = new Label();
        internationalPaginationBar = new DVLD.WinForms.Shared.Controls.PaginationBarControl();

        personPanel.SuspendLayout();
        summaryPanel.SuspendLayout();
        localCountPanel.SuspendLayout();
        internationalCountPanel.SuspendLayout();
        standingPanel.SuspendLayout();
        hintPanel.SuspendLayout();
        historyPanel.SuspendLayout();
        historyToolbar.SuspendLayout();
        tabSwitcherPanel.SuspendLayout();
        historyContentHost.SuspendLayout();
        localTab.SuspendLayout();
        localGridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)localGrid).BeginInit();
        internationalTab.SuspendLayout();
        internationalGridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)internationalGrid).BeginInit();
        SuspendLayout();

        //
        // pageHeader
        //
        pageHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pageHeader.BackColor = Color.Transparent;
        pageHeader.BackButtonText = "← Close";
        pageHeader.BadgeText = "● Awaiting Driver";
        pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Neutral;
        pageHeader.Font = new Font("Segoe UI", 9F);
        pageHeader.IconText = "LH";
        pageHeader.Location = new Point(20, 12);
        pageHeader.Name = "pageHeader";
        pageHeader.ShowBackButton = true;
        pageHeader.Size = new Size(944, 68);
        pageHeader.Subtitle = "Complete record of local driving licenses and international permits issued to this driver";
        pageHeader.TabIndex = 0;
        pageHeader.Title = "Driver License History";

        //
        // personPanel
        //
        personPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        personPanel.BorderColor = Color.FromArgb(220, 230, 238);
        personPanel.BorderRadius = 12;
        personPanel.BorderThickness = 1;
        personPanel.Controls.Add(personDetails);
        personPanel.FillColor = Color.White;
        personPanel.Location = new Point(20, 86);
        personPanel.Name = "personPanel";
        personPanel.Size = new Size(535, 258);
        personPanel.TabIndex = 4;

        //
        // personDetails (embedded redesigned PersonDetailControl)
        //
        personDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        personDetails.BackColor = Color.White;
        personDetails.Location = new Point(12, 2);
        personDetails.Name = "personDetails";
        personDetails.Size = new Size(511, 254);
        personDetails.TabIndex = 0;

        //
        // summaryPanel
        //
        summaryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        summaryPanel.BorderColor = Color.FromArgb(220, 230, 238);
        summaryPanel.BorderRadius = 12;
        summaryPanel.BorderThickness = 1;
        summaryPanel.Controls.Add(summaryHeading);
        summaryPanel.Controls.Add(summarySubheading);
        summaryPanel.Controls.Add(localCountPanel);
        summaryPanel.Controls.Add(internationalCountPanel);
        summaryPanel.Controls.Add(standingPanel);
        summaryPanel.Controls.Add(hintPanel);
        summaryPanel.FillColor = Color.White;
        summaryPanel.Location = new Point(569, 86);
        summaryPanel.Name = "summaryPanel";
        summaryPanel.Size = new Size(395, 258);
        summaryPanel.TabIndex = 5;

        //
        // summaryHeading & summarySubheading
        //
        summaryHeading.AutoSize = true;
        summaryHeading.BackColor = Color.Transparent;
        summaryHeading.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
        summaryHeading.ForeColor = Color.FromArgb(13, 148, 136);
        summaryHeading.Location = new Point(18, 12);
        summaryHeading.Name = "summaryHeading";
        summaryHeading.Size = new Size(124, 13);
        summaryHeading.TabIndex = 0;
        summaryHeading.Text = "CREDENTIAL SUMMARY";
        summaryHeading.UseMnemonic = false;

        summarySubheading.AutoSize = true;
        summarySubheading.BackColor = Color.Transparent;
        summarySubheading.Font = new Font("Segoe UI", 8.75F);
        summarySubheading.ForeColor = Color.FromArgb(100, 116, 139);
        summarySubheading.Location = new Point(18, 28);
        summarySubheading.Name = "summarySubheading";
        summarySubheading.Size = new Size(256, 15);
        summarySubheading.TabIndex = 1;
        summarySubheading.Text = "Overview of issued licenses and active standing";
        summarySubheading.UseMnemonic = false;

        //
        // localCountPanel
        //
        localCountPanel.BorderColor = Color.FromArgb(153, 246, 228);
        localCountPanel.BorderRadius = 10;
        localCountPanel.BorderThickness = 1;
        localCountPanel.Controls.Add(lblLocalSubTag);
        localCountPanel.Controls.Add(localCountValue);
        localCountPanel.Controls.Add(localCountCaption);
        localCountPanel.FillColor = Color.FromArgb(240, 253, 250);
        localCountPanel.Location = new Point(18, 52);
        localCountPanel.Name = "localCountPanel";
        localCountPanel.Size = new Size(174, 78);
        localCountPanel.TabIndex = 2;

        lblLocalSubTag.AutoSize = true;
        lblLocalSubTag.BackColor = Color.Transparent;
        lblLocalSubTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
        lblLocalSubTag.ForeColor = Color.FromArgb(15, 118, 110);
        lblLocalSubTag.Location = new Point(14, 10);
        lblLocalSubTag.Name = "lblLocalSubTag";
        lblLocalSubTag.Size = new Size(57, 12);
        lblLocalSubTag.TabIndex = 0;
        lblLocalSubTag.Text = "DOMESTIC";
        lblLocalSubTag.UseMnemonic = false;

        localCountValue.BackColor = Color.Transparent;
        localCountValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        localCountValue.ForeColor = Color.FromArgb(15, 118, 110);
        localCountValue.Location = new Point(12, 23);
        localCountValue.Name = "localCountValue";
        localCountValue.Size = new Size(148, 35);
        localCountValue.TabIndex = 1;
        localCountValue.Text = "0";
        localCountValue.TextAlign = ContentAlignment.MiddleLeft;
        localCountValue.UseMnemonic = false;

        localCountCaption.AutoSize = true;
        localCountCaption.BackColor = Color.Transparent;
        localCountCaption.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
        localCountCaption.ForeColor = Color.FromArgb(15, 118, 110);
        localCountCaption.Location = new Point(14, 58);
        localCountCaption.Name = "localCountCaption";
        localCountCaption.Size = new Size(88, 15);
        localCountCaption.TabIndex = 2;
        localCountCaption.Text = "Local Licenses";
        localCountCaption.UseMnemonic = false;

        //
        // internationalCountPanel
        //
        internationalCountPanel.BorderColor = Color.FromArgb(226, 232, 240);
        internationalCountPanel.BorderRadius = 10;
        internationalCountPanel.BorderThickness = 1;
        internationalCountPanel.Controls.Add(lblIntlSubTag);
        internationalCountPanel.Controls.Add(internationalCountValue);
        internationalCountPanel.Controls.Add(internationalCountCaption);
        internationalCountPanel.FillColor = Color.FromArgb(248, 250, 252);
        internationalCountPanel.Location = new Point(203, 52);
        internationalCountPanel.Name = "internationalCountPanel";
        internationalCountPanel.Size = new Size(174, 78);
        internationalCountPanel.TabIndex = 3;

        lblIntlSubTag.AutoSize = true;
        lblIntlSubTag.BackColor = Color.Transparent;
        lblIntlSubTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
        lblIntlSubTag.ForeColor = Color.FromArgb(100, 116, 139);
        lblIntlSubTag.Location = new Point(14, 10);
        lblIntlSubTag.Name = "lblIntlSubTag";
        lblIntlSubTag.Size = new Size(45, 12);
        lblIntlSubTag.TabIndex = 0;
        lblIntlSubTag.Text = "GLOBAL";
        lblIntlSubTag.UseMnemonic = false;

        internationalCountValue.BackColor = Color.Transparent;
        internationalCountValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        internationalCountValue.ForeColor = Color.FromArgb(15, 23, 42);
        internationalCountValue.Location = new Point(12, 23);
        internationalCountValue.Name = "internationalCountValue";
        internationalCountValue.Size = new Size(148, 35);
        internationalCountValue.TabIndex = 1;
        internationalCountValue.Text = "0";
        internationalCountValue.TextAlign = ContentAlignment.MiddleLeft;
        internationalCountValue.UseMnemonic = false;

        internationalCountCaption.AutoSize = true;
        internationalCountCaption.BackColor = Color.Transparent;
        internationalCountCaption.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
        internationalCountCaption.ForeColor = Color.FromArgb(51, 65, 85);
        internationalCountCaption.Location = new Point(14, 58);
        internationalCountCaption.Name = "internationalCountCaption";
        internationalCountCaption.Size = new Size(78, 15);
        internationalCountCaption.TabIndex = 2;
        internationalCountCaption.Text = "Int'l Permits";
        internationalCountCaption.UseMnemonic = false;

        //
        // standingPanel
        //
        standingPanel.BorderColor = Color.FromArgb(226, 232, 240);
        standingPanel.BorderRadius = 8;
        standingPanel.BorderThickness = 1;
        standingPanel.Controls.Add(lblStandingTitle);
        standingPanel.Controls.Add(lblStandingDesc);
        standingPanel.FillColor = Color.FromArgb(248, 250, 252);
        standingPanel.Location = new Point(18, 138);
        standingPanel.Name = "standingPanel";
        standingPanel.Size = new Size(359, 52);
        standingPanel.TabIndex = 4;

        lblStandingTitle.AutoEllipsis = true;
        lblStandingTitle.BackColor = Color.Transparent;
        lblStandingTitle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
        lblStandingTitle.ForeColor = Color.FromArgb(51, 65, 85);
        lblStandingTitle.Location = new Point(12, 8);
        lblStandingTitle.Name = "lblStandingTitle";
        lblStandingTitle.Size = new Size(335, 18);
        lblStandingTitle.TabIndex = 0;
        lblStandingTitle.Text = "● Awaiting Driver History";
        lblStandingTitle.UseMnemonic = false;

        lblStandingDesc.AutoEllipsis = true;
        lblStandingDesc.BackColor = Color.Transparent;
        lblStandingDesc.Font = new Font("Segoe UI", 8.25F);
        lblStandingDesc.ForeColor = Color.FromArgb(100, 116, 139);
        lblStandingDesc.Location = new Point(12, 28);
        lblStandingDesc.Name = "lblStandingDesc";
        lblStandingDesc.Size = new Size(335, 17);
        lblStandingDesc.TabIndex = 1;
        lblStandingDesc.Text = "Load a driver record to evaluate credential standing";
        lblStandingDesc.UseMnemonic = false;

        //
        // hintPanel
        //
        hintPanel.BorderColor = Color.FromArgb(226, 232, 240);
        hintPanel.BorderRadius = 8;
        hintPanel.BorderThickness = 1;
        hintPanel.Controls.Add(hintIcon);
        hintPanel.Controls.Add(hintText);
        hintPanel.FillColor = Color.FromArgb(248, 250, 252);
        hintPanel.Location = new Point(18, 198);
        hintPanel.Name = "hintPanel";
        hintPanel.Size = new Size(359, 44);
        hintPanel.TabIndex = 5;

        hintIcon.BackColor = Color.FromArgb(13, 148, 136);
        hintIcon.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        hintIcon.ForeColor = Color.White;
        hintIcon.Location = new Point(12, 13);
        hintIcon.Name = "hintIcon";
        hintIcon.Size = new Size(18, 18);
        hintIcon.TabIndex = 0;
        hintIcon.Text = "i";
        hintIcon.TextAlign = ContentAlignment.MiddleCenter;
        hintIcon.UseMnemonic = false;

        hintText.BackColor = Color.Transparent;
        hintText.Font = new Font("Segoe UI", 8.25F);
        hintText.ForeColor = Color.FromArgb(71, 85, 105);
        hintText.Location = new Point(38, 6);
        hintText.Name = "hintText";
        hintText.Size = new Size(310, 32);
        hintText.TabIndex = 1;
        hintText.Text = "Select 'View Card ↗' on any row below to inspect the full license card.";
        hintText.TextAlign = ContentAlignment.MiddleLeft;
        hintText.UseMnemonic = false;

        //
        // historyPanel
        //
        historyPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        historyPanel.BorderColor = Color.FromArgb(220, 230, 238);
        historyPanel.BorderRadius = 12;
        historyPanel.BorderThickness = 1;
        historyPanel.Controls.Add(historyContentHost);
        historyPanel.Controls.Add(historyToolbar);
        historyPanel.FillColor = Color.White;
        historyPanel.Location = new Point(20, 352);
        historyPanel.Name = "historyPanel";
        historyPanel.Padding = new Padding(16, 10, 16, 8);
        historyPanel.Size = new Size(944, 256);
        historyPanel.TabIndex = 6;

        //
        // historyToolbar
        //
        historyToolbar.BackColor = Color.White;
        historyToolbar.Controls.Add(tabSwitcherPanel);
        historyToolbar.Controls.Add(txtFilterHistory);
        historyToolbar.Dock = DockStyle.Top;
        historyToolbar.Location = new Point(16, 10);
        historyToolbar.Name = "historyToolbar";
        historyToolbar.Size = new Size(912, 48);
        historyToolbar.TabIndex = 0;

        //
        // tabSwitcherPanel
        //
        tabSwitcherPanel.BorderColor = Color.FromArgb(226, 232, 240);
        tabSwitcherPanel.BorderRadius = 9;
        tabSwitcherPanel.BorderThickness = 1;
        tabSwitcherPanel.Controls.Add(btnLocalTab);
        tabSwitcherPanel.Controls.Add(btnInternationalTab);
        tabSwitcherPanel.FillColor = Color.FromArgb(241, 245, 249);
        tabSwitcherPanel.Location = new Point(0, 3);
        tabSwitcherPanel.Name = "tabSwitcherPanel";
        tabSwitcherPanel.Size = new Size(392, 38);
        tabSwitcherPanel.TabIndex = 0;

        btnLocalTab.BorderRadius = 7;
        btnLocalTab.Cursor = Cursors.Hand;
        btnLocalTab.FillColor = Color.FromArgb(13, 148, 136);
        btnLocalTab.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnLocalTab.ForeColor = Color.White;
        btnLocalTab.HoverState.FillColor = Color.FromArgb(15, 118, 110);
        btnLocalTab.HoverState.ForeColor = Color.White;
        btnLocalTab.Image = Properties.Resources.icons8_car_48;
        btnLocalTab.ImageSize = new Size(16, 16);
        btnLocalTab.Location = new Point(4, 4);
        btnLocalTab.Name = "btnLocalTab";
        btnLocalTab.Size = new Size(192, 30);
        btnLocalTab.TabIndex = 0;
        btnLocalTab.Text = "Local Licenses";

        btnInternationalTab.BorderRadius = 7;
        btnInternationalTab.Cursor = Cursors.Hand;
        btnInternationalTab.FillColor = Color.Transparent;
        btnInternationalTab.Font = new Font("Segoe UI Semibold", 9F);
        btnInternationalTab.ForeColor = Color.FromArgb(100, 116, 139);
        btnInternationalTab.HoverState.FillColor = Color.FromArgb(248, 250, 252);
        btnInternationalTab.HoverState.ForeColor = Color.FromArgb(15, 23, 42);
        btnInternationalTab.Image = Properties.Resources.icons8_international_48;
        btnInternationalTab.ImageSize = new Size(16, 16);
        btnInternationalTab.Location = new Point(198, 4);
        btnInternationalTab.Name = "btnInternationalTab";
        btnInternationalTab.Size = new Size(190, 30);
        btnInternationalTab.TabIndex = 1;
        btnInternationalTab.Text = "International Permits";

        //
        // txtFilterHistory
        //
        txtFilterHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        txtFilterHistory.BorderColor = Color.FromArgb(226, 232, 240);
        txtFilterHistory.BorderRadius = 8;
        txtFilterHistory.FillColor = Color.FromArgb(248, 250, 252);
        txtFilterHistory.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
        txtFilterHistory.FocusedState.FillColor = Color.White;
        txtFilterHistory.Font = new Font("Segoe UI", 9F);
        txtFilterHistory.ForeColor = Color.FromArgb(15, 23, 42);
        txtFilterHistory.HoverState.BorderColor = Color.FromArgb(148, 163, 184);
        txtFilterHistory.Location = new Point(650, 3);
        txtFilterHistory.Name = "txtFilterHistory";
        txtFilterHistory.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
        txtFilterHistory.PlaceholderText = "Filter by ID, class, or status...";
        txtFilterHistory.Size = new Size(262, 38);
        txtFilterHistory.TabIndex = 1;
        txtFilterHistory.TextOffset = new Point(6, 0);

        //
        // historyContentHost
        //
        historyContentHost.BackColor = Color.White;
        historyContentHost.Controls.Add(localTab);
        historyContentHost.Controls.Add(internationalTab);
        historyContentHost.Dock = DockStyle.Fill;
        historyContentHost.Location = new Point(16, 58);
        historyContentHost.Name = "historyContentHost";
        historyContentHost.Size = new Size(912, 190);
        historyContentHost.TabIndex = 1;

        //
        // localTab
        //
        localTab.BackColor = Color.White;
        localTab.Controls.Add(localGridHost);
        localTab.Controls.Add(localPaginationBar);
        localTab.Dock = DockStyle.Fill;
        localTab.Location = new Point(0, 0);
        localTab.Name = "localTab";
        localTab.Size = new Size(931, 231);
        localTab.TabIndex = 0;

        //
        // localGridHost
        //
        localGridHost.BackColor = Color.White;
        localGridHost.Controls.Add(localMessage);
        localGridHost.Controls.Add(localGrid);
        localGridHost.Dock = DockStyle.Fill;
        localGridHost.Location = new Point(0, 0);
        localGridHost.Name = "localGridHost";
        localGridHost.Size = new Size(931, 185);
        localGridHost.TabIndex = 0;

        //
        // localGrid
        //
        localGrid.AllowUserToAddRows = false;
        localGrid.AllowUserToDeleteRows = false;
        localGrid.AllowUserToResizeRows = false;
        localAltStyle.BackColor = Color.White;
        localGrid.AlternatingRowsDefaultCellStyle = localAltStyle;
        localGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        localGrid.BackgroundColor = Color.White;
        localGrid.BorderStyle = BorderStyle.None;
        localGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        localGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        localHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        localHeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
        localHeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
        localHeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
        localHeaderStyle.Padding = new Padding(12, 0, 6, 0);
        localHeaderStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
        localHeaderStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
        localHeaderStyle.WrapMode = DataGridViewTriState.False;
        localGrid.ColumnHeadersDefaultCellStyle = localHeaderStyle;
        localGrid.ColumnHeadersHeight = 38;
        localGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        localGrid.Columns.AddRange(new DataGridViewColumn[]
        {
            localIdColumn,
            localLocalColumn,
            localClassColumn,
            localIssueColumn,
            localExpiryColumn,
            localStatusColumn,
            localActionColumn
        });
        localDefaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        localDefaultStyle.BackColor = Color.White;
        localDefaultStyle.Font = new Font("Segoe UI", 9.25F);
        localDefaultStyle.ForeColor = Color.FromArgb(51, 65, 85);
        localDefaultStyle.Padding = new Padding(12, 0, 6, 0);
        localDefaultStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
        localDefaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        localDefaultStyle.WrapMode = DataGridViewTriState.False;
        localGrid.DefaultCellStyle = localDefaultStyle;
        localGrid.Dock = DockStyle.Fill;
        localGrid.EnableHeadersVisualStyles = false;
        localGrid.GridColor = Color.FromArgb(241, 245, 249);
        localGrid.Location = new Point(0, 0);
        localGrid.MultiSelect = false;
        localGrid.Name = "localGrid";
        localGrid.ReadOnly = true;
        localGrid.RowHeadersVisible = false;
        localGrid.RowTemplate.Height = 44;
        localGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        localGrid.Size = new Size(931, 209);
        localGrid.TabIndex = 0;
        localGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
        localGrid.ThemeStyle.BackColor = Color.White;
        localGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
        localGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
        localGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
        localGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
        localGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
        localGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        localGrid.ThemeStyle.HeaderStyle.Height = 38;
        localGrid.ThemeStyle.ReadOnly = true;
        localGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
        localGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        localGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
        localGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(51, 65, 85);
        localGrid.ThemeStyle.RowsStyle.Height = 44;
        localGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
        localGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

        localIdStyle.NullValue = "—";
        localIdColumn.DefaultCellStyle = localIdStyle;
        localIdColumn.FillWeight = 90F;
        localIdColumn.HeaderText = "LICENSE ID";
        localIdColumn.MinimumWidth = 85;
        localIdColumn.Name = "LicenseId";
        localIdColumn.ReadOnly = true;
        localIdColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        localAppIdStyle.NullValue = "—";
        localLocalColumn.DefaultCellStyle = localAppIdStyle;
        localLocalColumn.FillWeight = 80F;
        localLocalColumn.HeaderText = "APP ID";
        localLocalColumn.MinimumWidth = 75;
        localLocalColumn.Name = "LocalApplicationId";
        localLocalColumn.ReadOnly = true;
        localLocalColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        localClassColumn.FillWeight = 235F;
        localClassColumn.HeaderText = "LICENSE CLASS";
        localClassColumn.MinimumWidth = 175;
        localClassColumn.Name = "LicenseClass";
        localClassColumn.ReadOnly = true;
        localClassColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        localIssueDateStyle.Format = "MMM dd, yyyy";
        localIssueDateStyle.ForeColor = Color.FromArgb(71, 85, 105);
        localIssueColumn.DefaultCellStyle = localIssueDateStyle;
        localIssueColumn.FillWeight = 115F;
        localIssueColumn.HeaderText = "ISSUE DATE";
        localIssueColumn.MinimumWidth = 95;
        localIssueColumn.Name = "IssueDate";
        localIssueColumn.ReadOnly = true;
        localIssueColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        localExpiryDateStyle.Format = "MMM dd, yyyy";
        localExpiryDateStyle.ForeColor = Color.FromArgb(71, 85, 105);
        localExpiryColumn.DefaultCellStyle = localExpiryDateStyle;
        localExpiryColumn.FillWeight = 115F;
        localExpiryColumn.HeaderText = "EXPIRY DATE";
        localExpiryColumn.MinimumWidth = 95;
        localExpiryColumn.Name = "ExpirationDate";
        localExpiryColumn.ReadOnly = true;
        localExpiryColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        localStatusStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        localStatusStyle.ForeColor = Color.FromArgb(100, 116, 139);
        localStatusStyle.NullValue = "—";
        localStatusColumn.DefaultCellStyle = localStatusStyle;
        localStatusColumn.FillWeight = 110F;
        localStatusColumn.HeaderText = "STATUS";
        localStatusColumn.MinimumWidth = 100;
        localStatusColumn.Name = "LicenseStatus";
        localStatusColumn.ReadOnly = true;
        localStatusColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        localActionColumn.ActiveLinkColor = Color.FromArgb(15, 118, 110);
        localActionColumn.FillWeight = 105F;
        localActionColumn.HeaderText = "ACTION";
        localActionColumn.LinkBehavior = LinkBehavior.NeverUnderline;
        localActionColumn.LinkColor = Color.FromArgb(13, 148, 136);
        localActionColumn.MinimumWidth = 95;
        localActionColumn.Name = "ViewLicense";
        localActionColumn.ReadOnly = true;
        localActionColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        localActionColumn.Text = "View Card ↗";
        localActionColumn.TrackVisitedState = false;
        localActionColumn.UseColumnTextForLinkValue = true;

        //
        // localMessage
        //
        localMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        localMessage.BackColor = Color.Transparent;
        localMessage.Font = new Font("Segoe UI", 10F);
        localMessage.ForeColor = Color.FromArgb(100, 116, 139);
        localMessage.Location = new Point(24, 74);
        localMessage.Name = "localMessage";
        localMessage.Size = new Size(883, 60);
        localMessage.TabIndex = 1;
        localMessage.Text = "No local driving licenses found for this driver.";
        localMessage.TextAlign = ContentAlignment.MiddleCenter;
        localMessage.UseMnemonic = false;
        localMessage.Visible = false;

        //
        // localPaginationBar
        //
        localPaginationBar.BackColor = Color.White;
        localPaginationBar.Dock = DockStyle.Bottom;
        localPaginationBar.Font = new Font("Segoe UI", 9F);
        localPaginationBar.ItemLabel = "local licenses";
        localPaginationBar.Location = new Point(0, 185);
        localPaginationBar.Name = "localPaginationBar";
        localPaginationBar.Size = new Size(931, 46);
        localPaginationBar.TabIndex = 1;

        //
        // internationalTab
        //
        internationalTab.BackColor = Color.White;
        internationalTab.Controls.Add(internationalGridHost);
        internationalTab.Controls.Add(internationalPaginationBar);
        internationalTab.Dock = DockStyle.Fill;
        internationalTab.Location = new Point(0, 0);
        internationalTab.Name = "internationalTab";
        internationalTab.Size = new Size(931, 231);
        internationalTab.TabIndex = 1;
        internationalTab.Visible = false;

        //
        // internationalGridHost
        //
        internationalGridHost.BackColor = Color.White;
        internationalGridHost.Controls.Add(internationalMessage);
        internationalGridHost.Controls.Add(internationalGrid);
        internationalGridHost.Dock = DockStyle.Fill;
        internationalGridHost.Location = new Point(0, 0);
        internationalGridHost.Name = "internationalGridHost";
        internationalGridHost.Size = new Size(931, 185);
        internationalGridHost.TabIndex = 0;

        //
        // internationalGrid
        //
        internationalGrid.AllowUserToAddRows = false;
        internationalGrid.AllowUserToDeleteRows = false;
        internationalGrid.AllowUserToResizeRows = false;
        intlAltStyle.BackColor = Color.White;
        internationalGrid.AlternatingRowsDefaultCellStyle = intlAltStyle;
        internationalGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        internationalGrid.BackgroundColor = Color.White;
        internationalGrid.BorderStyle = BorderStyle.None;
        internationalGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        internationalGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        intlHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        intlHeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
        intlHeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
        intlHeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
        intlHeaderStyle.Padding = new Padding(12, 0, 6, 0);
        intlHeaderStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
        intlHeaderStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
        intlHeaderStyle.WrapMode = DataGridViewTriState.False;
        internationalGrid.ColumnHeadersDefaultCellStyle = intlHeaderStyle;
        internationalGrid.ColumnHeadersHeight = 38;
        internationalGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        internationalGrid.Columns.AddRange(new DataGridViewColumn[]
        {
            internationalIdColumn,
            internationalApplicationColumn,
            internationalLocalColumn,
            internationalIssueColumn,
            internationalExpiryColumn,
            internationalStatusColumn,
            internationalActionColumn
        });
        intlDefaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        intlDefaultStyle.BackColor = Color.White;
        intlDefaultStyle.Font = new Font("Segoe UI", 9.25F);
        intlDefaultStyle.ForeColor = Color.FromArgb(51, 65, 85);
        intlDefaultStyle.Padding = new Padding(12, 0, 6, 0);
        intlDefaultStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
        intlDefaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        intlDefaultStyle.WrapMode = DataGridViewTriState.False;
        internationalGrid.DefaultCellStyle = intlDefaultStyle;
        internationalGrid.Dock = DockStyle.Fill;
        internationalGrid.EnableHeadersVisualStyles = false;
        internationalGrid.GridColor = Color.FromArgb(241, 245, 249);
        internationalGrid.Location = new Point(0, 0);
        internationalGrid.MultiSelect = false;
        internationalGrid.Name = "internationalGrid";
        internationalGrid.ReadOnly = true;
        internationalGrid.RowHeadersVisible = false;
        internationalGrid.RowTemplate.Height = 44;
        internationalGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        internationalGrid.Size = new Size(931, 209);
        internationalGrid.TabIndex = 0;
        internationalGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
        internationalGrid.ThemeStyle.BackColor = Color.White;
        internationalGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
        internationalGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
        internationalGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
        internationalGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F);
        internationalGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
        internationalGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        internationalGrid.ThemeStyle.HeaderStyle.Height = 38;
        internationalGrid.ThemeStyle.ReadOnly = true;
        internationalGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
        internationalGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        internationalGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
        internationalGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(51, 65, 85);
        internationalGrid.ThemeStyle.RowsStyle.Height = 44;
        internationalGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
        internationalGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

        intlIdStyle.NullValue = "—";
        internationalIdColumn.DefaultCellStyle = intlIdStyle;
        internationalIdColumn.FillWeight = 120F;
        internationalIdColumn.HeaderText = "PERMIT ID";
        internationalIdColumn.MinimumWidth = 90;
        internationalIdColumn.Name = "LicenseId";
        internationalIdColumn.ReadOnly = true;
        internationalIdColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        intlAppIdStyle.NullValue = "—";
        internationalApplicationColumn.DefaultCellStyle = intlAppIdStyle;
        internationalApplicationColumn.FillWeight = 115F;
        internationalApplicationColumn.HeaderText = "APPLICATION ID";
        internationalApplicationColumn.MinimumWidth = 95;
        internationalApplicationColumn.Name = "ApplicationId";
        internationalApplicationColumn.ReadOnly = true;
        internationalApplicationColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        intlLocalIdStyle.NullValue = "—";
        internationalLocalColumn.DefaultCellStyle = intlLocalIdStyle;
        internationalLocalColumn.FillWeight = 120F;
        internationalLocalColumn.HeaderText = "LOCAL LICENSE ID";
        internationalLocalColumn.MinimumWidth = 95;
        internationalLocalColumn.Name = "LocalLicenseId";
        internationalLocalColumn.ReadOnly = true;
        internationalLocalColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        intlIssueDateStyle.Format = "MMM dd, yyyy";
        intlIssueDateStyle.ForeColor = Color.FromArgb(71, 85, 105);
        internationalIssueColumn.DefaultCellStyle = intlIssueDateStyle;
        internationalIssueColumn.FillWeight = 125F;
        internationalIssueColumn.HeaderText = "ISSUE DATE";
        internationalIssueColumn.MinimumWidth = 95;
        internationalIssueColumn.Name = "IssueDate";
        internationalIssueColumn.ReadOnly = true;
        internationalIssueColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        intlExpiryDateStyle.Format = "MMM dd, yyyy";
        intlExpiryDateStyle.ForeColor = Color.FromArgb(71, 85, 105);
        internationalExpiryColumn.DefaultCellStyle = intlExpiryDateStyle;
        internationalExpiryColumn.FillWeight = 125F;
        internationalExpiryColumn.HeaderText = "EXPIRY DATE";
        internationalExpiryColumn.MinimumWidth = 95;
        internationalExpiryColumn.Name = "ExpirationDate";
        internationalExpiryColumn.ReadOnly = true;
        internationalExpiryColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        intlStatusStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        intlStatusStyle.ForeColor = Color.FromArgb(100, 116, 139);
        intlStatusStyle.NullValue = "—";
        internationalStatusColumn.DefaultCellStyle = intlStatusStyle;
        internationalStatusColumn.FillWeight = 115F;
        internationalStatusColumn.HeaderText = "STATUS";
        internationalStatusColumn.MinimumWidth = 100;
        internationalStatusColumn.Name = "LicenseStatus";
        internationalStatusColumn.ReadOnly = true;
        internationalStatusColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

        internationalActionColumn.ActiveLinkColor = Color.FromArgb(15, 118, 110);
        internationalActionColumn.FillWeight = 105F;
        internationalActionColumn.HeaderText = "ACTION";
        internationalActionColumn.LinkBehavior = LinkBehavior.NeverUnderline;
        internationalActionColumn.LinkColor = Color.FromArgb(13, 148, 136);
        internationalActionColumn.MinimumWidth = 95;
        internationalActionColumn.Name = "ViewLicense";
        internationalActionColumn.ReadOnly = true;
        internationalActionColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        internationalActionColumn.Text = "View Card ↗";
        internationalActionColumn.TrackVisitedState = false;
        internationalActionColumn.UseColumnTextForLinkValue = true;

        //
        // internationalMessage
        //
        internationalMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        internationalMessage.BackColor = Color.Transparent;
        internationalMessage.Font = new Font("Segoe UI", 10F);
        internationalMessage.ForeColor = Color.FromArgb(100, 116, 139);
        internationalMessage.Location = new Point(24, 74);
        internationalMessage.Name = "internationalMessage";
        internationalMessage.Size = new Size(883, 60);
        internationalMessage.TabIndex = 1;
        internationalMessage.Text = "No international driving permits found for this driver.";
        internationalMessage.TextAlign = ContentAlignment.MiddleCenter;
        internationalMessage.UseMnemonic = false;
        internationalMessage.Visible = false;

        //
        // internationalPaginationBar
        //
        internationalPaginationBar.BackColor = Color.White;
        internationalPaginationBar.Dock = DockStyle.Bottom;
        internationalPaginationBar.Font = new Font("Segoe UI", 9F);
        internationalPaginationBar.ItemLabel = "international permits";
        internationalPaginationBar.Location = new Point(0, 185);
        internationalPaginationBar.Name = "internationalPaginationBar";
        internationalPaginationBar.Size = new Size(931, 46);
        internationalPaginationBar.TabIndex = 1;

        //
        // LicenseHistoryControl
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(243, 247, 249);
        Controls.Add(pageHeader);
        Controls.Add(personPanel);
        Controls.Add(summaryPanel);
        Controls.Add(historyPanel);
        Font = new Font("Segoe UI", 9.5F);
        Name = "LicenseHistoryControl";
        Size = new Size(984, 620);

        personPanel.ResumeLayout(false);
        summaryPanel.ResumeLayout(false);
        summaryPanel.PerformLayout();
        localCountPanel.ResumeLayout(false);
        localCountPanel.PerformLayout();
        internationalCountPanel.ResumeLayout(false);
        internationalCountPanel.PerformLayout();
        standingPanel.ResumeLayout(false);
        hintPanel.ResumeLayout(false);
        historyPanel.ResumeLayout(false);
        historyToolbar.ResumeLayout(false);
        tabSwitcherPanel.ResumeLayout(false);
        historyContentHost.ResumeLayout(false);
        localTab.ResumeLayout(false);
        localGridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)localGrid).EndInit();
        internationalTab.ResumeLayout(false);
        internationalGridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)internationalGrid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DVLD.WinForms.Shared.Controls.PageHeaderControl pageHeader;
    private Guna.UI2.WinForms.Guna2Panel personPanel;
    private DVLD.WinForms.Features.Persons.Detail.PersonDetailControl personDetails;
    private Guna.UI2.WinForms.Guna2Panel summaryPanel;
    private Label summaryHeading;
    private Label summarySubheading;
    private Guna.UI2.WinForms.Guna2Panel localCountPanel;
    private Label lblLocalSubTag;
    private Label localCountValue;
    private Label localCountCaption;
    private Guna.UI2.WinForms.Guna2Panel internationalCountPanel;
    private Label lblIntlSubTag;
    private Label internationalCountValue;
    private Label internationalCountCaption;
    private Guna.UI2.WinForms.Guna2Panel standingPanel;
    private Label lblStandingTitle;
    private Label lblStandingDesc;
    private Guna.UI2.WinForms.Guna2Panel hintPanel;
    private Label hintIcon;
    private Label hintText;
    private Guna.UI2.WinForms.Guna2Panel historyPanel;
    private Panel historyToolbar;
    private Guna.UI2.WinForms.Guna2Panel tabSwitcherPanel;
    private Guna.UI2.WinForms.Guna2Button btnLocalTab;
    private Guna.UI2.WinForms.Guna2Button btnInternationalTab;
    private Guna.UI2.WinForms.Guna2TextBox txtFilterHistory;
    private Panel historyContentHost;
    private Panel localTab;
    private Panel localGridHost;
    private Guna.UI2.WinForms.Guna2DataGridView localGrid;
    private DataGridViewTextBoxColumn localIdColumn;
    private DataGridViewTextBoxColumn localLocalColumn;
    private DataGridViewTextBoxColumn localClassColumn;
    private DataGridViewTextBoxColumn localIssueColumn;
    private DataGridViewTextBoxColumn localExpiryColumn;
    private DataGridViewTextBoxColumn localStatusColumn;
    private DataGridViewLinkColumn localActionColumn;
    private Label localMessage;
    private DVLD.WinForms.Shared.Controls.PaginationBarControl localPaginationBar;
    private Panel internationalTab;
    private Panel internationalGridHost;
    private Guna.UI2.WinForms.Guna2DataGridView internationalGrid;
    private DataGridViewTextBoxColumn internationalIdColumn;
    private DataGridViewTextBoxColumn internationalApplicationColumn;
    private DataGridViewTextBoxColumn internationalLocalColumn;
    private DataGridViewTextBoxColumn internationalIssueColumn;
    private DataGridViewTextBoxColumn internationalExpiryColumn;
    private DataGridViewTextBoxColumn internationalStatusColumn;
    private DataGridViewLinkColumn internationalActionColumn;
    private Label internationalMessage;
    private DVLD.WinForms.Shared.Controls.PaginationBarControl internationalPaginationBar;
}
