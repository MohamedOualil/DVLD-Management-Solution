namespace DVLD.WinForms.Features.Licenses.ReplaceLicense
{
    partial class ReplaceLicenseControl
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
            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            contentLayout = new TableLayoutPanel();
            licenseLookup = new DVLD.WinForms.Shared.Controls.LicenseLookupControl();
            replaceCard = new Guna.UI2.WinForms.Guna2Panel();
            lblCardTag = new Label();
            lblCardTitle = new Label();
            lblNewLicensePill = new Guna.UI2.WinForms.Guna2Button();
            cardDivider = new Panel();
            lblReasonCaption = new Label();
            damagedBox = new Guna.UI2.WinForms.Guna2Panel();
            rbDamaged = new RadioButton();
            lostBox = new Guna.UI2.WinForms.Guna2Panel();
            rbLost = new RadioButton();
            feeBox = new Guna.UI2.WinForms.Guna2Panel();
            lblFeeCaption = new Label();
            lblReplacementFee = new Label();
            appDateBox = new Guna.UI2.WinForms.Guna2Panel();
            lblAppDateCaption = new Label();
            lblApplicationDate = new Label();
            lblCreatedByCaption = new Label();
            lblCreatedBy = new Label();
            lblNotesCaption = new Label();
            txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            replaceCard.SuspendLayout();
            damagedBox.SuspendLayout();
            lostBox.SuspendLayout();
            feeBox.SuspendLayout();
            appDateBox.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoSize = true;
            pageLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(statusBanner, 0, 2);
            pageLayout.Controls.Add(contentLayout, 0, 4);
            pageLayout.Controls.Add(pageActionFooter, 0, 6);
            pageLayout.Dock = DockStyle.Top;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(760, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 7;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 340F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            pageLayout.Size = new Size(1003, 586);
            pageLayout.TabIndex = 0;
            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● Lost / Damaged";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Warning;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "RP";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Issue a replacement licence for a lost or physically damaged active credential";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Replace Driving Licence";
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Search for an active, non-detained local driving licence to process replacement.";
            statusBanner.Dock = DockStyle.Fill;
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 94);
            statusBanner.Margin = new Padding(0);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(971, 60);
            statusBanner.TabIndex = 1;
            statusBanner.Title = "Awaiting License Selection";
            statusBanner.Tone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 540F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(licenseLookup, 0, 0);
            contentLayout.Controls.Add(replaceCard, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(16, 164);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(971, 340);
            contentLayout.TabIndex = 2;
            // 
            // licenseLookup
            // 
            licenseLookup.BackColor = Color.Transparent;
            licenseLookup.Dock = DockStyle.Fill;
            licenseLookup.Font = new Font("Segoe UI", 9F);
            licenseLookup.Location = new Point(0, 0);
            licenseLookup.Margin = new Padding(0);
            licenseLookup.Name = "licenseLookup";
            licenseLookup.Size = new Size(540, 340);
            licenseLookup.TabIndex = 0;
            // 
            // replaceCard
            // 
            replaceCard.BackColor = Color.Transparent;
            replaceCard.BorderColor = Color.FromArgb(220, 230, 238);
            replaceCard.BorderRadius = 12;
            replaceCard.BorderThickness = 1;
            replaceCard.Controls.Add(lblCardTag);
            replaceCard.Controls.Add(lblCardTitle);
            replaceCard.Controls.Add(lblNewLicensePill);
            replaceCard.Controls.Add(cardDivider);
            replaceCard.Controls.Add(lblReasonCaption);
            replaceCard.Controls.Add(damagedBox);
            replaceCard.Controls.Add(lostBox);
            replaceCard.Controls.Add(feeBox);
            replaceCard.Controls.Add(appDateBox);
            replaceCard.Controls.Add(lblCreatedByCaption);
            replaceCard.Controls.Add(lblCreatedBy);
            replaceCard.Controls.Add(lblNotesCaption);
            replaceCard.Controls.Add(txtNotes);
            replaceCard.CustomizableEdges = customizableEdges1;
            replaceCard.Dock = DockStyle.Fill;
            replaceCard.FillColor = Color.White;
            replaceCard.Location = new Point(554, 0);
            replaceCard.Margin = new Padding(14, 0, 0, 0);
            replaceCard.Name = "replaceCard";
            replaceCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            replaceCard.Size = new Size(417, 340);
            replaceCard.TabIndex = 1;
            // 
            // lblCardTag
            // 
            lblCardTag.AutoSize = true;
            lblCardTag.BackColor = Color.Transparent;
            lblCardTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCardTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblCardTag.Location = new Point(18, 12);
            lblCardTag.Name = "lblCardTag";
            lblCardTag.Size = new Size(115, 12);
            lblCardTag.TabIndex = 0;
            lblCardTag.Text = "REPLACEMENT TYPE";
            lblCardTag.UseMnemonic = false;
            // 
            // lblCardTitle
            // 
            lblCardTitle.AutoSize = true;
            lblCardTitle.BackColor = Color.Transparent;
            lblCardTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblCardTitle.Location = new Point(17, 27);
            lblCardTitle.Name = "lblCardTitle";
            lblCardTitle.Size = new Size(197, 20);
            lblCardTitle.TabIndex = 1;
            lblCardTitle.Text = "Reason & Replacement Fee";
            lblCardTitle.UseMnemonic = false;
            // 
            // lblNewLicensePill
            // 
            lblNewLicensePill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNewLicensePill.Animated = false;
            lblNewLicensePill.BackColor = Color.Transparent;
            lblNewLicensePill.BorderColor = Color.FromArgb(226, 232, 240);
            lblNewLicensePill.BorderRadius = 13;
            lblNewLicensePill.BorderThickness = 1;
            lblNewLicensePill.CustomizableEdges = customizableEdges3;
            lblNewLicensePill.FillColor = Color.FromArgb(248, 250, 252);
            lblNewLicensePill.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblNewLicensePill.ForeColor = Color.FromArgb(71, 85, 105);
            lblNewLicensePill.HoverState.BorderColor = Color.FromArgb(226, 232, 240);
            lblNewLicensePill.HoverState.FillColor = Color.FromArgb(248, 250, 252);
            lblNewLicensePill.HoverState.ForeColor = Color.FromArgb(71, 85, 105);
            lblNewLicensePill.Location = new Point(268, 18);
            lblNewLicensePill.Name = "lblNewLicensePill";
            lblNewLicensePill.PressedColor = Color.FromArgb(248, 250, 252);
            lblNewLicensePill.ShadowDecoration.CustomizableEdges = customizableEdges4;
            lblNewLicensePill.Size = new Size(131, 26);
            lblNewLicensePill.TabIndex = 2;
            lblNewLicensePill.TabStop = false;
            lblNewLicensePill.Text = "New ID: Pending";
            // 
            // cardDivider
            // 
            cardDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cardDivider.BackColor = Color.FromArgb(226, 232, 240);
            cardDivider.Location = new Point(18, 56);
            cardDivider.Name = "cardDivider";
            cardDivider.Size = new Size(381, 1);
            cardDivider.TabIndex = 3;
            // 
            // lblReasonCaption
            // 
            lblReasonCaption.AutoSize = true;
            lblReasonCaption.BackColor = Color.Transparent;
            lblReasonCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblReasonCaption.ForeColor = Color.FromArgb(51, 65, 85);
            lblReasonCaption.Location = new Point(18, 65);
            lblReasonCaption.Name = "lblReasonCaption";
            lblReasonCaption.Size = new Size(130, 13);
            lblReasonCaption.TabIndex = 4;
            lblReasonCaption.Text = "SELECT REPLACEMENT REASON";
            lblReasonCaption.UseMnemonic = false;
            // 
            // damagedBox
            // 
            damagedBox.BackColor = Color.Transparent;
            damagedBox.BorderColor = Color.FromArgb(13, 148, 136);
            damagedBox.BorderRadius = 8;
            damagedBox.BorderThickness = 2;
            damagedBox.Controls.Add(rbDamaged);
            damagedBox.CustomizableEdges = customizableEdges5;
            damagedBox.FillColor = Color.FromArgb(204, 251, 241);
            damagedBox.Location = new Point(18, 83);
            damagedBox.Name = "damagedBox";
            damagedBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            damagedBox.Size = new Size(184, 42);
            damagedBox.TabIndex = 5;
            // 
            // rbDamaged
            // 
            rbDamaged.BackColor = Color.Transparent;
            rbDamaged.Checked = true;
            rbDamaged.Cursor = Cursors.Hand;
            rbDamaged.Dock = DockStyle.Fill;
            rbDamaged.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbDamaged.ForeColor = Color.FromArgb(15, 118, 110);
            rbDamaged.Location = new Point(0, 0);
            rbDamaged.Name = "rbDamaged";
            rbDamaged.Padding = new Padding(10, 0, 6, 0);
            rbDamaged.Size = new Size(184, 42);
            rbDamaged.TabIndex = 0;
            rbDamaged.TabStop = true;
            rbDamaged.Text = "Damaged ($5.00)";
            rbDamaged.UseMnemonic = false;
            rbDamaged.UseVisualStyleBackColor = false;
            // 
            // lostBox
            // 
            lostBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lostBox.BackColor = Color.Transparent;
            lostBox.BorderColor = Color.FromArgb(226, 232, 240);
            lostBox.BorderRadius = 8;
            lostBox.BorderThickness = 1;
            lostBox.Controls.Add(rbLost);
            lostBox.CustomizableEdges = customizableEdges7;
            lostBox.FillColor = Color.FromArgb(248, 250, 252);
            lostBox.Location = new Point(212, 83);
            lostBox.Name = "lostBox";
            lostBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            lostBox.Size = new Size(187, 42);
            lostBox.TabIndex = 6;
            // 
            // rbLost
            // 
            rbLost.BackColor = Color.Transparent;
            rbLost.Cursor = Cursors.Hand;
            rbLost.Dock = DockStyle.Fill;
            rbLost.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            rbLost.ForeColor = Color.FromArgb(51, 65, 85);
            rbLost.Location = new Point(0, 0);
            rbLost.Name = "rbLost";
            rbLost.Padding = new Padding(10, 0, 6, 0);
            rbLost.Size = new Size(187, 42);
            rbLost.TabIndex = 0;
            rbLost.Text = "Lost ($10.00)";
            rbLost.UseMnemonic = false;
            rbLost.UseVisualStyleBackColor = false;
            // 
            // feeBox
            // 
            feeBox.BackColor = Color.Transparent;
            feeBox.BorderColor = Color.FromArgb(187, 247, 208);
            feeBox.BorderRadius = 8;
            feeBox.BorderThickness = 1;
            feeBox.Controls.Add(lblFeeCaption);
            feeBox.Controls.Add(lblReplacementFee);
            feeBox.FillColor = Color.FromArgb(220, 252, 231);
            feeBox.Location = new Point(18, 134);
            feeBox.Name = "feeBox";
            feeBox.Size = new Size(184, 50);
            feeBox.TabIndex = 7;
            // 
            // lblFeeCaption
            // 
            lblFeeCaption.AutoSize = true;
            lblFeeCaption.BackColor = Color.Transparent;
            lblFeeCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFeeCaption.ForeColor = Color.FromArgb(22, 101, 52);
            lblFeeCaption.Location = new Point(12, 6);
            lblFeeCaption.Name = "lblFeeCaption";
            lblFeeCaption.Size = new Size(92, 12);
            lblFeeCaption.TabIndex = 0;
            lblFeeCaption.Text = "APPLICATION FEE";
            lblFeeCaption.UseMnemonic = false;
            // 
            // lblReplacementFee
            // 
            lblReplacementFee.AutoEllipsis = true;
            lblReplacementFee.BackColor = Color.Transparent;
            lblReplacementFee.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblReplacementFee.ForeColor = Color.FromArgb(22, 101, 52);
            lblReplacementFee.Location = new Point(12, 22);
            lblReplacementFee.Name = "lblReplacementFee";
            lblReplacementFee.Size = new Size(160, 22);
            lblReplacementFee.TabIndex = 1;
            lblReplacementFee.Text = "$5.00";
            lblReplacementFee.UseMnemonic = false;
            // 
            // appDateBox
            // 
            appDateBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            appDateBox.BackColor = Color.Transparent;
            appDateBox.BorderColor = Color.FromArgb(226, 232, 240);
            appDateBox.BorderRadius = 8;
            appDateBox.BorderThickness = 1;
            appDateBox.Controls.Add(lblAppDateCaption);
            appDateBox.Controls.Add(lblApplicationDate);
            appDateBox.FillColor = Color.FromArgb(248, 250, 252);
            appDateBox.Location = new Point(212, 134);
            appDateBox.Name = "appDateBox";
            appDateBox.Size = new Size(187, 50);
            appDateBox.TabIndex = 8;
            // 
            // lblAppDateCaption
            // 
            lblAppDateCaption.AutoSize = true;
            lblAppDateCaption.BackColor = Color.Transparent;
            lblAppDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblAppDateCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblAppDateCaption.Location = new Point(12, 6);
            lblAppDateCaption.Name = "lblAppDateCaption";
            lblAppDateCaption.Size = new Size(92, 12);
            lblAppDateCaption.TabIndex = 0;
            lblAppDateCaption.Text = "APPLICATION DATE";
            lblAppDateCaption.UseMnemonic = false;
            // 
            // lblApplicationDate
            // 
            lblApplicationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblApplicationDate.AutoEllipsis = true;
            lblApplicationDate.BackColor = Color.Transparent;
            lblApplicationDate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblApplicationDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationDate.Location = new Point(12, 23);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(163, 20);
            lblApplicationDate.TabIndex = 1;
            lblApplicationDate.Text = "—";
            lblApplicationDate.UseMnemonic = false;
            // 
            // lblCreatedByCaption & lblCreatedBy
            // 
            lblCreatedByCaption.AutoSize = true;
            lblCreatedByCaption.BackColor = Color.Transparent;
            lblCreatedByCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCreatedByCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblCreatedByCaption.Location = new Point(18, 194);
            lblCreatedByCaption.Name = "lblCreatedByCaption";
            lblCreatedByCaption.Size = new Size(63, 12);
            lblCreatedByCaption.TabIndex = 9;
            lblCreatedByCaption.Text = "CREATED BY";
            lblCreatedByCaption.UseMnemonic = false;

            lblCreatedBy.AutoEllipsis = true;
            lblCreatedBy.BackColor = Color.Transparent;
            lblCreatedBy.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            lblCreatedBy.ForeColor = Color.FromArgb(51, 65, 85);
            lblCreatedBy.Location = new Point(18, 209);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(381, 18);
            lblCreatedBy.TabIndex = 10;
            lblCreatedBy.Text = "—";
            lblCreatedBy.UseMnemonic = false;

            // 
            // lblNotesCaption & txtNotes
            // 
            lblNotesCaption.AutoSize = true;
            lblNotesCaption.BackColor = Color.Transparent;
            lblNotesCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblNotesCaption.ForeColor = Color.FromArgb(51, 65, 85);
            lblNotesCaption.Location = new Point(18, 236);
            lblNotesCaption.Name = "lblNotesCaption";
            lblNotesCaption.Size = new Size(164, 13);
            lblNotesCaption.TabIndex = 11;
            lblNotesCaption.Text = "REPLACEMENT NOTES (OPTIONAL)";
            lblNotesCaption.UseMnemonic = false;

            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNotes.BorderColor = Color.FromArgb(220, 230, 238);
            txtNotes.BorderRadius = 8;
            txtNotes.Cursor = Cursors.IBeam;
            txtNotes.CustomizableEdges = customizableEdges9;
            txtNotes.DefaultText = "";
            txtNotes.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtNotes.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtNotes.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtNotes.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtNotes.FillColor = Color.FromArgb(248, 250, 252);
            txtNotes.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtNotes.FocusedState.FillColor = Color.White;
            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.ForeColor = Color.FromArgb(15, 23, 42);
            txtNotes.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtNotes.Location = new Point(18, 254);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtNotes.PlaceholderText = "Optional incident reference or replacement comments...";
            txtNotes.SelectedText = "";
            txtNotes.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtNotes.Size = new Size(381, 68);
            txtNotes.TabIndex = 12;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Find an active local license to issue a replacement.";
            pageActionFooter.Location = new Point(16, 514);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Issue Replacement";
            pageActionFooter.SecondaryButtonText = "Clear";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;
            // 
            // ReplaceLicenseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "ReplaceLicenseControl";
            Size = new Size(1003, 637);
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            replaceCard.ResumeLayout(false);
            replaceCard.PerformLayout();
            damagedBox.ResumeLayout(false);
            lostBox.ResumeLayout(false);
            feeBox.ResumeLayout(false);
            feeBox.PerformLayout();
            appDateBox.ResumeLayout(false);
            appDateBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.StatusBannerControl statusBanner;
        private TableLayoutPanel contentLayout;
        private Shared.Controls.LicenseLookupControl licenseLookup;
        private Guna.UI2.WinForms.Guna2Panel replaceCard;
        private Label lblCardTag;
        private Label lblCardTitle;
        private Guna.UI2.WinForms.Guna2Button lblNewLicensePill;
        private Panel cardDivider;
        private Label lblReasonCaption;
        private Guna.UI2.WinForms.Guna2Panel damagedBox;
        private RadioButton rbDamaged;
        private Guna.UI2.WinForms.Guna2Panel lostBox;
        private RadioButton rbLost;
        private Guna.UI2.WinForms.Guna2Panel feeBox;
        private Label lblFeeCaption;
        private Label lblReplacementFee;
        private Guna.UI2.WinForms.Guna2Panel appDateBox;
        private Label lblAppDateCaption;
        private Label lblApplicationDate;
        private Label lblCreatedByCaption;
        private Label lblCreatedBy;
        private Label lblNotesCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
