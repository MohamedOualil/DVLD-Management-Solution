namespace DVLD.WinForms.Features.Licenses.RenewLicense
{
    partial class RenewLicenseControl
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
            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            contentLayout = new TableLayoutPanel();
            licenseLookup = new DVLD.WinForms.Shared.Controls.LicenseLookupControl();
            renewalCard = new Guna.UI2.WinForms.Guna2Panel();
            lblCardTag = new Label();
            lblCardTitle = new Label();
            lblNewLicensePill = new Guna.UI2.WinForms.Guna2Button();
            cardDivider = new Panel();
            appDateBox = new Guna.UI2.WinForms.Guna2Panel();
            lblAppDateCaption = new Label();
            lblApplicationDate = new Label();
            expiryBox = new Guna.UI2.WinForms.Guna2Panel();
            lblNewExpiryCaption = new Label();
            lblNewExpirationDate = new Label();
            feesBreakdownBox = new Guna.UI2.WinForms.Guna2Panel();
            lblFeesSummaryCaption = new Label();
            lblTotalFees = new Label();
            lblFeesBreakdown = new Label();
            lblCreatedByCaption = new Label();
            lblCreatedBy = new Label();
            lblNotesCaption = new Label();
            txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            renewalCard.SuspendLayout();
            appDateBox.SuspendLayout();
            expiryBox.SuspendLayout();
            feesBreakdownBox.SuspendLayout();
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
            pageHeader.BadgeText = "● License Renewal";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "RN";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Search for an expired local driving licence to verify eligibility and renew validity";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Renew Driving Licence";
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Search by License ID on the left to load driver eligibility and renewal terms.";
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
            contentLayout.Controls.Add(renewalCard, 1, 0);
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
            // renewalCard
            // 
            renewalCard.BackColor = Color.Transparent;
            renewalCard.BorderColor = Color.FromArgb(220, 230, 238);
            renewalCard.BorderRadius = 12;
            renewalCard.BorderThickness = 1;
            renewalCard.Controls.Add(lblCardTag);
            renewalCard.Controls.Add(lblCardTitle);
            renewalCard.Controls.Add(lblNewLicensePill);
            renewalCard.Controls.Add(cardDivider);
            renewalCard.Controls.Add(appDateBox);
            renewalCard.Controls.Add(expiryBox);
            renewalCard.Controls.Add(feesBreakdownBox);
            renewalCard.Controls.Add(lblCreatedByCaption);
            renewalCard.Controls.Add(lblCreatedBy);
            renewalCard.Controls.Add(lblNotesCaption);
            renewalCard.Controls.Add(txtNotes);
            renewalCard.CustomizableEdges = customizableEdges1;
            renewalCard.Dock = DockStyle.Fill;
            renewalCard.FillColor = Color.White;
            renewalCard.Location = new Point(554, 0);
            renewalCard.Margin = new Padding(14, 0, 0, 0);
            renewalCard.Name = "renewalCard";
            renewalCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            renewalCard.Size = new Size(417, 340);
            renewalCard.TabIndex = 1;
            // 
            // lblCardTag
            // 
            lblCardTag.AutoSize = true;
            lblCardTag.BackColor = Color.Transparent;
            lblCardTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCardTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblCardTag.Location = new Point(18, 12);
            lblCardTag.Name = "lblCardTag";
            lblCardTag.Size = new Size(102, 12);
            lblCardTag.TabIndex = 0;
            lblCardTag.Text = "RENEWAL TERMS";
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
            lblCardTitle.Size = new Size(165, 20);
            lblCardTitle.TabIndex = 1;
            lblCardTitle.Text = "Renewal & Fee Summary";
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
            // appDateBox
            // 
            appDateBox.BackColor = Color.Transparent;
            appDateBox.BorderColor = Color.FromArgb(226, 232, 240);
            appDateBox.BorderRadius = 8;
            appDateBox.BorderThickness = 1;
            appDateBox.Controls.Add(lblAppDateCaption);
            appDateBox.Controls.Add(lblApplicationDate);
            appDateBox.FillColor = Color.FromArgb(248, 250, 252);
            appDateBox.Location = new Point(18, 66);
            appDateBox.Name = "appDateBox";
            appDateBox.Size = new Size(184, 50);
            appDateBox.TabIndex = 4;
            // 
            // lblAppDateCaption
            // 
            lblAppDateCaption.AutoSize = true;
            lblAppDateCaption.BackColor = Color.Transparent;
            lblAppDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblAppDateCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblAppDateCaption.Location = new Point(12, 7);
            lblAppDateCaption.Name = "lblAppDateCaption";
            lblAppDateCaption.Size = new Size(92, 12);
            lblAppDateCaption.TabIndex = 0;
            lblAppDateCaption.Text = "APPLICATION DATE";
            lblAppDateCaption.UseMnemonic = false;
            // 
            // lblApplicationDate
            // 
            lblApplicationDate.AutoEllipsis = true;
            lblApplicationDate.BackColor = Color.Transparent;
            lblApplicationDate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblApplicationDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationDate.Location = new Point(12, 23);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(160, 20);
            lblApplicationDate.TabIndex = 1;
            lblApplicationDate.Text = "—";
            lblApplicationDate.UseMnemonic = false;
            // 
            // expiryBox
            // 
            expiryBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            expiryBox.BackColor = Color.Transparent;
            expiryBox.BorderColor = Color.FromArgb(153, 246, 228);
            expiryBox.BorderRadius = 8;
            expiryBox.BorderThickness = 1;
            expiryBox.Controls.Add(lblNewExpiryCaption);
            expiryBox.Controls.Add(lblNewExpirationDate);
            expiryBox.FillColor = Color.FromArgb(240, 253, 250);
            expiryBox.Location = new Point(212, 66);
            expiryBox.Name = "expiryBox";
            expiryBox.Size = new Size(187, 50);
            expiryBox.TabIndex = 5;
            // 
            // lblNewExpiryCaption
            // 
            lblNewExpiryCaption.AutoSize = true;
            lblNewExpiryCaption.BackColor = Color.Transparent;
            lblNewExpiryCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblNewExpiryCaption.ForeColor = Color.FromArgb(13, 148, 136);
            lblNewExpiryCaption.Location = new Point(12, 7);
            lblNewExpiryCaption.Name = "lblNewExpiryCaption";
            lblNewExpiryCaption.Size = new Size(95, 12);
            lblNewExpiryCaption.TabIndex = 0;
            lblNewExpiryCaption.Text = "NEW EXPIRATION DATE";
            lblNewExpiryCaption.UseMnemonic = false;
            // 
            // lblNewExpirationDate
            // 
            lblNewExpirationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNewExpirationDate.AutoEllipsis = true;
            lblNewExpirationDate.BackColor = Color.Transparent;
            lblNewExpirationDate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNewExpirationDate.ForeColor = Color.FromArgb(15, 118, 110);
            lblNewExpirationDate.Location = new Point(12, 23);
            lblNewExpirationDate.Name = "lblNewExpirationDate";
            lblNewExpirationDate.Size = new Size(163, 20);
            lblNewExpirationDate.TabIndex = 1;
            lblNewExpirationDate.Text = "—";
            lblNewExpirationDate.UseMnemonic = false;
            // 
            // feesBreakdownBox
            // 
            feesBreakdownBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            feesBreakdownBox.BackColor = Color.Transparent;
            feesBreakdownBox.BorderColor = Color.FromArgb(187, 247, 208);
            feesBreakdownBox.BorderRadius = 8;
            feesBreakdownBox.BorderThickness = 1;
            feesBreakdownBox.Controls.Add(lblFeesSummaryCaption);
            feesBreakdownBox.Controls.Add(lblTotalFees);
            feesBreakdownBox.Controls.Add(lblFeesBreakdown);
            feesBreakdownBox.CustomizableEdges = customizableEdges5;
            feesBreakdownBox.FillColor = Color.FromArgb(220, 252, 231);
            feesBreakdownBox.Location = new Point(18, 124);
            feesBreakdownBox.Name = "feesBreakdownBox";
            feesBreakdownBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            feesBreakdownBox.Size = new Size(381, 60);
            feesBreakdownBox.TabIndex = 6;
            // 
            // lblFeesSummaryCaption
            // 
            lblFeesSummaryCaption.AutoSize = true;
            lblFeesSummaryCaption.BackColor = Color.Transparent;
            lblFeesSummaryCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFeesSummaryCaption.ForeColor = Color.FromArgb(22, 101, 52);
            lblFeesSummaryCaption.Location = new Point(12, 7);
            lblFeesSummaryCaption.Name = "lblFeesSummaryCaption";
            lblFeesSummaryCaption.Size = new Size(92, 12);
            lblFeesSummaryCaption.TabIndex = 0;
            lblFeesSummaryCaption.Text = "TOTAL RENEWAL FEE";
            lblFeesSummaryCaption.UseMnemonic = false;
            // 
            // lblTotalFees
            // 
            lblTotalFees.AutoSize = true;
            lblTotalFees.BackColor = Color.Transparent;
            lblTotalFees.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTotalFees.ForeColor = Color.FromArgb(22, 101, 52);
            lblTotalFees.Location = new Point(12, 22);
            lblTotalFees.Name = "lblTotalFees";
            lblTotalFees.Size = new Size(64, 23);
            lblTotalFees.TabIndex = 1;
            lblTotalFees.Text = "$27.00";
            lblTotalFees.UseMnemonic = false;
            // 
            // lblFeesBreakdown
            // 
            lblFeesBreakdown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFeesBreakdown.BackColor = Color.Transparent;
            lblFeesBreakdown.Font = new Font("Segoe UI", 8.25F);
            lblFeesBreakdown.ForeColor = Color.FromArgb(22, 101, 52);
            lblFeesBreakdown.Location = new Point(140, 26);
            lblFeesBreakdown.Name = "lblFeesBreakdown";
            lblFeesBreakdown.Size = new Size(228, 18);
            lblFeesBreakdown.TabIndex = 2;
            lblFeesBreakdown.Text = "App: $7.00 + License: $20.00";
            lblFeesBreakdown.TextAlign = ContentAlignment.MiddleRight;
            lblFeesBreakdown.UseMnemonic = false;
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
            lblCreatedByCaption.TabIndex = 7;
            lblCreatedByCaption.Text = "CREATED BY";
            lblCreatedByCaption.UseMnemonic = false;

            lblCreatedBy.AutoEllipsis = true;
            lblCreatedBy.BackColor = Color.Transparent;
            lblCreatedBy.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            lblCreatedBy.ForeColor = Color.FromArgb(51, 65, 85);
            lblCreatedBy.Location = new Point(18, 209);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(381, 18);
            lblCreatedBy.TabIndex = 8;
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
            lblNotesCaption.Size = new Size(150, 13);
            lblNotesCaption.TabIndex = 9;
            lblNotesCaption.Text = "RENEWAL NOTES (OPTIONAL)";
            lblNotesCaption.UseMnemonic = false;

            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNotes.BorderColor = Color.FromArgb(220, 230, 238);
            txtNotes.BorderRadius = 8;
            txtNotes.Cursor = Cursors.IBeam;
            txtNotes.CustomizableEdges = customizableEdges7;
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
            txtNotes.PlaceholderText = "Optional notes to store on the renewed licence...";
            txtNotes.SelectedText = "";
            txtNotes.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtNotes.Size = new Size(381, 68);
            txtNotes.TabIndex = 10;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Find an expired local license to enable renewal.";
            pageActionFooter.Location = new Point(16, 514);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Renew License";
            pageActionFooter.SecondaryButtonText = "Clear";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;
            // 
            // RenewLicenseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "RenewLicenseControl";
            Size = new Size(1003, 637);
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            renewalCard.ResumeLayout(false);
            renewalCard.PerformLayout();
            appDateBox.ResumeLayout(false);
            appDateBox.PerformLayout();
            expiryBox.ResumeLayout(false);
            expiryBox.PerformLayout();
            feesBreakdownBox.ResumeLayout(false);
            feesBreakdownBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.StatusBannerControl statusBanner;
        private TableLayoutPanel contentLayout;
        private Shared.Controls.LicenseLookupControl licenseLookup;
        private Guna.UI2.WinForms.Guna2Panel renewalCard;
        private Label lblCardTag;
        private Label lblCardTitle;
        private Guna.UI2.WinForms.Guna2Button lblNewLicensePill;
        private Panel cardDivider;
        private Guna.UI2.WinForms.Guna2Panel appDateBox;
        private Label lblAppDateCaption;
        private Label lblApplicationDate;
        private Guna.UI2.WinForms.Guna2Panel expiryBox;
        private Label lblNewExpiryCaption;
        private Label lblNewExpirationDate;
        private Guna.UI2.WinForms.Guna2Panel feesBreakdownBox;
        private Label lblFeesSummaryCaption;
        private Label lblTotalFees;
        private Label lblFeesBreakdown;
        private Label lblCreatedByCaption;
        private Label lblCreatedBy;
        private Label lblNotesCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
