namespace DVLD.WinForms.Features.Administration.ServiceFees
{
    partial class ServiceFeesControl
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

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle codeStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle categoryStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle titleStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle feeStyle = new DataGridViewCellStyle();

            pageLayout = new TableLayoutPanel();
            pageHeader = new Shared.Controls.PageHeaderControl();
            statusBanner = new Shared.Controls.StatusBannerControl();
            contentLayout = new TableLayoutPanel();
            catalogCard = new Guna.UI2.WinForms.Guna2Panel();
            catalogToolbar = new Panel();
            txtSearchFee = new Guna.UI2.WinForms.Guna2TextBox();
            cmbCategoryFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            gridHost = new Panel();
            feesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colFee = new DataGridViewTextBoxColumn();
            editorCard = new Guna.UI2.WinForms.Guna2Panel();
            lblEditorTag = new Label();
            lblEditorTitle = new Label();
            btnCodePill = new Guna.UI2.WinForms.Guna2Button();
            editorDivider = new Panel();
            lblCategoryCaption = new Label();
            lblCategoryValue = new Label();
            lblTitleCaption = new Label();
            txtFeeTitle = new Guna.UI2.WinForms.Guna2TextBox();
            lblFeeCaption = new Label();
            txtFeeAmount = new Guna.UI2.WinForms.Guna2TextBox();
            lblDescriptionCaption = new Label();
            txtFeeDescription = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new Shared.Controls.PageActionFooterControl();

            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            catalogCard.SuspendLayout();
            catalogToolbar.SuspendLayout();
            gridHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)feesGrid).BeginInit();
            editorCard.SuspendLayout();
            SuspendLayout();

            // 
            // pageLayout
            // 
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(statusBanner, 0, 2);
            pageLayout.Controls.Add(contentLayout, 0, 4);
            pageLayout.Controls.Add(pageActionFooter, 0, 6);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 7;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            pageLayout.Size = new Size(1003, 637);
            pageLayout.TabIndex = 0;

            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● Fee Schedule";
            pageHeader.BadgeTone = Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "SF";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Review and maintain official DVLD application service fees and examination pricing";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Service Fees & Exam Types";

            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Select any application service or exam type on the left to inspect or adjust its fee.";
            statusBanner.Dock = DockStyle.Fill;
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 94);
            statusBanner.Margin = new Padding(0);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(971, 60);
            statusBanner.TabIndex = 1;
            statusBanner.Title = "Fee Schedule Ready";
            statusBanner.Tone = Shared.Controls.HeaderBadgeTone.Info;

            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            contentLayout.Controls.Add(catalogCard, 0, 0);
            contentLayout.Controls.Add(editorCard, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(16, 164);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(971, 391);
            contentLayout.TabIndex = 2;

            // 
            // catalogCard
            // 
            catalogCard.BackColor = Color.Transparent;
            catalogCard.BorderColor = Color.FromArgb(220, 230, 238);
            catalogCard.BorderRadius = 12;
            catalogCard.BorderThickness = 1;
            catalogCard.Controls.Add(gridHost);
            catalogCard.Controls.Add(catalogToolbar);
            catalogCard.CustomizableEdges = customizableEdges1;
            catalogCard.Dock = DockStyle.Fill;
            catalogCard.FillColor = Color.White;
            catalogCard.Location = new Point(0, 0);
            catalogCard.Margin = new Padding(0);
            catalogCard.Name = "catalogCard";
            catalogCard.Padding = new Padding(1);
            catalogCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            catalogCard.Size = new Size(563, 391);
            catalogCard.TabIndex = 0;

            // 
            // catalogToolbar
            // 
            catalogToolbar.BackColor = Color.FromArgb(248, 250, 252);
            catalogToolbar.Controls.Add(cmbCategoryFilter);
            catalogToolbar.Controls.Add(txtSearchFee);
            catalogToolbar.Dock = DockStyle.Top;
            catalogToolbar.Location = new Point(1, 1);
            catalogToolbar.Name = "catalogToolbar";
            catalogToolbar.Padding = new Padding(12, 10, 12, 10);
            catalogToolbar.Size = new Size(561, 56);
            catalogToolbar.TabIndex = 0;

            // 
            // txtSearchFee
            // 
            txtSearchFee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchFee.BorderColor = Color.FromArgb(218, 226, 236);
            txtSearchFee.BorderRadius = 8;
            txtSearchFee.Cursor = Cursors.IBeam;
            txtSearchFee.CustomizableEdges = customizableEdges3;
            txtSearchFee.DefaultText = "";
            txtSearchFee.FillColor = Color.White;
            txtSearchFee.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtSearchFee.Font = new Font("Segoe UI", 9F);
            txtSearchFee.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearchFee.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtSearchFee.Location = new Point(12, 10);
            txtSearchFee.Name = "txtSearchFee";
            txtSearchFee.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearchFee.PlaceholderText = "Search by service title or code...";
            txtSearchFee.SelectedText = "";
            txtSearchFee.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearchFee.Size = new Size(340, 36);
            txtSearchFee.TabIndex = 0;

            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCategoryFilter.BackColor = Color.Transparent;
            cmbCategoryFilter.BorderColor = Color.FromArgb(218, 226, 236);
            cmbCategoryFilter.BorderRadius = 8;
            cmbCategoryFilter.CustomizableEdges = customizableEdges5;
            cmbCategoryFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.FillColor = Color.White;
            cmbCategoryFilter.FocusedColor = Color.FromArgb(13, 148, 136);
            cmbCategoryFilter.Font = new Font("Segoe UI", 9F);
            cmbCategoryFilter.ForeColor = Color.FromArgb(51, 65, 85);
            cmbCategoryFilter.ItemHeight = 30;
            cmbCategoryFilter.Items.AddRange(new object[] { "All Fee Types", "Service Fees", "Exam Fees" });
            cmbCategoryFilter.Location = new Point(362, 10);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbCategoryFilter.Size = new Size(187, 36);
            cmbCategoryFilter.TabIndex = 1;

            // 
            // gridHost
            // 
            gridHost.BackColor = Color.White;
            gridHost.Controls.Add(feesGrid);
            gridHost.Dock = DockStyle.Fill;
            gridHost.Location = new Point(1, 57);
            gridHost.Name = "gridHost";
            gridHost.Size = new Size(561, 333);
            gridHost.TabIndex = 1;

            // 
            // feesGrid
            // 
            feesGrid.AllowUserToAddRows = false;
            feesGrid.AllowUserToDeleteRows = false;
            feesGrid.AllowUserToResizeRows = false;
            feesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            feesGrid.BackgroundColor = Color.White;
            feesGrid.BorderStyle = BorderStyle.None;
            feesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            feesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(12, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.False;
            feesGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            feesGrid.ColumnHeadersHeight = 38;
            feesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            feesGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                colCode,
                colCategory,
                colTitle,
                colFee
            });

            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9.25F);
            defaultStyle.ForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.Padding = new Padding(12, 0, 0, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            feesGrid.DefaultCellStyle = defaultStyle;

            feesGrid.Dock = DockStyle.Fill;
            feesGrid.EnableHeadersVisualStyles = false;
            feesGrid.GridColor = Color.FromArgb(241, 245, 249);
            feesGrid.Location = new Point(0, 0);
            feesGrid.MultiSelect = false;
            feesGrid.Name = "feesGrid";
            feesGrid.ReadOnly = true;
            feesGrid.RowHeadersVisible = false;
            feesGrid.RowTemplate.Height = 42;
            feesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            feesGrid.Size = new Size(561, 333);
            feesGrid.TabIndex = 0;
            feesGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 252, 255);
            feesGrid.ThemeStyle.BackColor = Color.White;
            feesGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            feesGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            feesGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            feesGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            feesGrid.ThemeStyle.HeaderStyle.Height = 38;
            feesGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            feesGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.25F);
            feesGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            feesGrid.ThemeStyle.RowsStyle.Height = 42;
            feesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            feesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            codeStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            codeStyle.ForeColor = Color.FromArgb(15, 118, 110);
            colCode.DefaultCellStyle = codeStyle;
            colCode.FillWeight = 72F;
            colCode.HeaderText = "CODE";
            colCode.Name = "Code";
            colCode.ReadOnly = true;

            categoryStyle.ForeColor = Color.FromArgb(100, 116, 139);
            colCategory.DefaultCellStyle = categoryStyle;
            colCategory.FillWeight = 92F;
            colCategory.HeaderText = "CATEGORY";
            colCategory.Name = "Category";
            colCategory.ReadOnly = true;

            titleStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            titleStyle.ForeColor = Color.FromArgb(15, 23, 42);
            colTitle.DefaultCellStyle = titleStyle;
            colTitle.FillWeight = 195F;
            colTitle.HeaderText = "SERVICE / EXAM TITLE";
            colTitle.Name = "Title";
            colTitle.ReadOnly = true;

            feeStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            feeStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            feeStyle.ForeColor = Color.FromArgb(21, 128, 61);
            feeStyle.Format = "C2";
            feeStyle.Padding = new Padding(0, 0, 14, 0);
            colFee.DefaultCellStyle = feeStyle;
            colFee.FillWeight = 78F;
            colFee.HeaderText = "FEE";
            colFee.Name = "Fee";
            colFee.ReadOnly = true;

            // 
            // editorCard
            // 
            editorCard.BackColor = Color.Transparent;
            editorCard.BorderColor = Color.FromArgb(220, 230, 238);
            editorCard.BorderRadius = 12;
            editorCard.BorderThickness = 1;
            editorCard.Controls.Add(lblEditorTag);
            editorCard.Controls.Add(lblEditorTitle);
            editorCard.Controls.Add(btnCodePill);
            editorCard.Controls.Add(editorDivider);
            editorCard.Controls.Add(lblCategoryCaption);
            editorCard.Controls.Add(lblCategoryValue);
            editorCard.Controls.Add(lblTitleCaption);
            editorCard.Controls.Add(txtFeeTitle);
            editorCard.Controls.Add(lblFeeCaption);
            editorCard.Controls.Add(txtFeeAmount);
            editorCard.Controls.Add(lblDescriptionCaption);
            editorCard.Controls.Add(txtFeeDescription);
            editorCard.CustomizableEdges = customizableEdges7;
            editorCard.Dock = DockStyle.Fill;
            editorCard.FillColor = Color.White;
            editorCard.Location = new Point(577, 0);
            editorCard.Margin = new Padding(14, 0, 0, 0);
            editorCard.Name = "editorCard";
            editorCard.ShadowDecoration.CustomizableEdges = customizableEdges8;
            editorCard.Size = new Size(394, 391);
            editorCard.TabIndex = 1;

            // 
            // lblEditorTag
            // 
            lblEditorTag.AutoSize = true;
            lblEditorTag.BackColor = Color.Transparent;
            lblEditorTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblEditorTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblEditorTag.Location = new Point(18, 12);
            lblEditorTag.Name = "lblEditorTag";
            lblEditorTag.Size = new Size(64, 12);
            lblEditorTag.TabIndex = 0;
            lblEditorTag.Text = "FEE EDITOR";
            lblEditorTag.UseMnemonic = false;

            // 
            // lblEditorTitle
            // 
            lblEditorTitle.AutoSize = true;
            lblEditorTitle.BackColor = Color.Transparent;
            lblEditorTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEditorTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblEditorTitle.Location = new Point(17, 27);
            lblEditorTitle.Name = "lblEditorTitle";
            lblEditorTitle.Size = new Size(138, 20);
            lblEditorTitle.TabIndex = 1;
            lblEditorTitle.Text = "Edit Selected Fee";
            lblEditorTitle.UseMnemonic = false;

            // 
            // btnCodePill
            // 
            btnCodePill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCodePill.Animated = false;
            btnCodePill.BackColor = Color.Transparent;
            btnCodePill.BorderColor = Color.FromArgb(226, 232, 240);
            btnCodePill.BorderRadius = 13;
            btnCodePill.BorderThickness = 1;
            btnCodePill.CustomizableEdges = customizableEdges9;
            btnCodePill.FillColor = Color.FromArgb(248, 250, 252);
            btnCodePill.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            btnCodePill.ForeColor = Color.FromArgb(71, 85, 105);
            btnCodePill.Location = new Point(282, 18);
            btnCodePill.Name = "btnCodePill";
            btnCodePill.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnCodePill.Size = new Size(94, 26);
            btnCodePill.TabIndex = 2;
            btnCodePill.TabStop = false;
            btnCodePill.Text = "NO SELECTION";

            // 
            // editorDivider
            // 
            editorDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editorDivider.BackColor = Color.FromArgb(226, 232, 240);
            editorDivider.Location = new Point(18, 56);
            editorDivider.Name = "editorDivider";
            editorDivider.Size = new Size(358, 1);
            editorDivider.TabIndex = 3;

            // 
            // lblCategoryCaption
            // 
            lblCategoryCaption.AutoSize = true;
            lblCategoryCaption.BackColor = Color.Transparent;
            lblCategoryCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblCategoryCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblCategoryCaption.Location = new Point(18, 68);
            lblCategoryCaption.Name = "lblCategoryCaption";
            lblCategoryCaption.Size = new Size(80, 13);
            lblCategoryCaption.TabIndex = 4;
            lblCategoryCaption.Text = "CATEGORY";
            lblCategoryCaption.UseMnemonic = false;

            // 
            // lblCategoryValue
            // 
            lblCategoryValue.AutoSize = true;
            lblCategoryValue.BackColor = Color.Transparent;
            lblCategoryValue.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblCategoryValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblCategoryValue.Location = new Point(18, 84);
            lblCategoryValue.Name = "lblCategoryValue";
            lblCategoryValue.Size = new Size(20, 17);
            lblCategoryValue.TabIndex = 5;
            lblCategoryValue.Text = "—";
            lblCategoryValue.UseMnemonic = false;

            // 
            // lblTitleCaption
            // 
            lblTitleCaption.AutoSize = true;
            lblTitleCaption.BackColor = Color.Transparent;
            lblTitleCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblTitleCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleCaption.Location = new Point(18, 114);
            lblTitleCaption.Name = "lblTitleCaption";
            lblTitleCaption.Size = new Size(80, 13);
            lblTitleCaption.TabIndex = 6;
            lblTitleCaption.Text = "DISPLAY TITLE";
            lblTitleCaption.UseMnemonic = false;

            // 
            // txtFeeTitle
            // 
            txtFeeTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFeeTitle.BorderColor = Color.FromArgb(218, 226, 236);
            txtFeeTitle.BorderRadius = 8;
            txtFeeTitle.Cursor = Cursors.IBeam;
            txtFeeTitle.CustomizableEdges = customizableEdges11;
            txtFeeTitle.DefaultText = "";
            txtFeeTitle.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtFeeTitle.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtFeeTitle.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtFeeTitle.FillColor = Color.White;
            txtFeeTitle.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtFeeTitle.Font = new Font("Segoe UI", 9F);
            txtFeeTitle.ForeColor = Color.FromArgb(15, 23, 42);
            txtFeeTitle.Location = new Point(18, 131);
            txtFeeTitle.Name = "txtFeeTitle";
            txtFeeTitle.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtFeeTitle.PlaceholderText = "Enter service or test title";
            txtFeeTitle.SelectedText = "";
            txtFeeTitle.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtFeeTitle.Size = new Size(358, 36);
            txtFeeTitle.TabIndex = 7;

            // 
            // lblFeeCaption
            // 
            lblFeeCaption.AutoSize = true;
            lblFeeCaption.BackColor = Color.Transparent;
            lblFeeCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblFeeCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblFeeCaption.Location = new Point(18, 178);
            lblFeeCaption.Name = "lblFeeCaption";
            lblFeeCaption.Size = new Size(92, 13);
            lblFeeCaption.TabIndex = 8;
            lblFeeCaption.Text = "STANDARD FEE ($)";
            lblFeeCaption.UseMnemonic = false;

            // 
            // txtFeeAmount
            // 
            txtFeeAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFeeAmount.BorderColor = Color.FromArgb(218, 226, 236);
            txtFeeAmount.BorderRadius = 8;
            txtFeeAmount.Cursor = Cursors.IBeam;
            txtFeeAmount.CustomizableEdges = customizableEdges13;
            txtFeeAmount.DefaultText = "";
            txtFeeAmount.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtFeeAmount.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtFeeAmount.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtFeeAmount.FillColor = Color.White;
            txtFeeAmount.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtFeeAmount.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            txtFeeAmount.ForeColor = Color.FromArgb(15, 23, 42);
            txtFeeAmount.Location = new Point(18, 195);
            txtFeeAmount.Name = "txtFeeAmount";
            txtFeeAmount.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtFeeAmount.PlaceholderText = "0.00";
            txtFeeAmount.SelectedText = "";
            txtFeeAmount.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtFeeAmount.Size = new Size(358, 36);
            txtFeeAmount.TabIndex = 9;

            // 
            // lblDescriptionCaption
            // 
            lblDescriptionCaption.AutoSize = true;
            lblDescriptionCaption.BackColor = Color.Transparent;
            lblDescriptionCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblDescriptionCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblDescriptionCaption.Location = new Point(18, 242);
            lblDescriptionCaption.Name = "lblDescriptionCaption";
            lblDescriptionCaption.Size = new Size(74, 13);
            lblDescriptionCaption.TabIndex = 10;
            lblDescriptionCaption.Text = "DESCRIPTION";
            lblDescriptionCaption.UseMnemonic = false;

            // 
            // txtFeeDescription
            // 
            txtFeeDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFeeDescription.BorderColor = Color.FromArgb(218, 226, 236);
            txtFeeDescription.BorderRadius = 8;
            txtFeeDescription.Cursor = Cursors.IBeam;
            txtFeeDescription.DefaultText = "";
            txtFeeDescription.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtFeeDescription.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtFeeDescription.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtFeeDescription.FillColor = Color.White;
            txtFeeDescription.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtFeeDescription.Font = new Font("Segoe UI", 9F);
            txtFeeDescription.ForeColor = Color.FromArgb(15, 23, 42);
            txtFeeDescription.Location = new Point(18, 259);
            txtFeeDescription.Multiline = true;
            txtFeeDescription.Name = "txtFeeDescription";
            txtFeeDescription.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtFeeDescription.PlaceholderText = "Describe when this fee is assessed...";
            txtFeeDescription.SelectedText = "";
            txtFeeDescription.Size = new Size(358, 114);
            txtFeeDescription.TabIndex = 11;

            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Select any fee row on the left to begin editing.";
            pageActionFooter.Location = new Point(16, 565);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Save Fee Changes";
            pageActionFooter.SecondaryButtonText = "Reset Changes";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;

            // 
            // ServiceFeesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "ServiceFeesControl";
            Size = new Size(1003, 637);
            Load += ServiceFeesControl_Load;
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            catalogCard.ResumeLayout(false);
            catalogToolbar.ResumeLayout(false);
            gridHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)feesGrid).EndInit();
            editorCard.ResumeLayout(false);
            editorCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.StatusBannerControl statusBanner;
        private TableLayoutPanel contentLayout;
        private Guna.UI2.WinForms.Guna2Panel catalogCard;
        private Panel catalogToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchFee;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoryFilter;
        private Panel gridHost;
        private Guna.UI2.WinForms.Guna2DataGridView feesGrid;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colFee;
        private Guna.UI2.WinForms.Guna2Panel editorCard;
        private Label lblEditorTag;
        private Label lblEditorTitle;
        private Guna.UI2.WinForms.Guna2Button btnCodePill;
        private Panel editorDivider;
        private Label lblCategoryCaption;
        private Label lblCategoryValue;
        private Label lblTitleCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtFeeTitle;
        private Label lblFeeCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtFeeAmount;
        private Label lblDescriptionCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtFeeDescription;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
