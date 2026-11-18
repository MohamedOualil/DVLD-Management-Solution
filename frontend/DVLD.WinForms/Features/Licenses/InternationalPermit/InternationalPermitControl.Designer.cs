namespace DVLD.WinForms.Features.Licenses.InternationalPermit
{
    partial class InternationalPermitControl
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
            permitCard = new Guna.UI2.WinForms.Guna2Panel();
            lblCardTag = new Label();
            lblCardTitle = new Label();
            lblPermitIdPill = new Guna.UI2.WinForms.Guna2Button();
            cardDivider = new Panel();
            localIdBox = new Guna.UI2.WinForms.Guna2Panel();
            lblLocalIdCaption = new Label();
            lblLocalLicenseId = new Label();
            driverIdBox = new Guna.UI2.WinForms.Guna2Panel();
            lblDriverIdCaption = new Label();
            lblDriverId = new Label();
            issueDateBox = new Guna.UI2.WinForms.Guna2Panel();
            lblIssueDateCaption = new Label();
            lblIssueDate = new Label();
            expiryDateBox = new Guna.UI2.WinForms.Guna2Panel();
            lblExpiryDateCaption = new Label();
            lblExpirationDate = new Label();
            feeBox = new Guna.UI2.WinForms.Guna2Panel();
            lblFeeCaption = new Label();
            lblApplicationFee = new Label();
            lblCreatedByInline = new Label();
            ruleNoticeBox = new Guna.UI2.WinForms.Guna2Panel();
            lblRuleNotice = new Label();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            permitCard.SuspendLayout();
            localIdBox.SuspendLayout();
            driverIdBox.SuspendLayout();
            issueDateBox.SuspendLayout();
            expiryDateBox.SuspendLayout();
            feeBox.SuspendLayout();
            ruleNoticeBox.SuspendLayout();
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
            pageHeader.BadgeText = "● Global Permit";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "IP";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Issue a 1-year International Driving Permit backed by an active Class 3 local licence";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "International Driving Permit";
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Search for an active Class 3 (Ordinary) local driving licence to verify eligibility.";
            statusBanner.Dock = DockStyle.Fill;
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 94);
            statusBanner.Margin = new Padding(0);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(971, 60);
            statusBanner.TabIndex = 1;
            statusBanner.Title = "Awaiting Local License Lookup";
            statusBanner.Tone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 540F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(licenseLookup, 0, 0);
            contentLayout.Controls.Add(permitCard, 1, 0);
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
            // permitCard
            // 
            permitCard.BackColor = Color.Transparent;
            permitCard.BorderColor = Color.FromArgb(220, 230, 238);
            permitCard.BorderRadius = 12;
            permitCard.BorderThickness = 1;
            permitCard.Controls.Add(lblCardTag);
            permitCard.Controls.Add(lblCardTitle);
            permitCard.Controls.Add(lblPermitIdPill);
            permitCard.Controls.Add(cardDivider);
            permitCard.Controls.Add(localIdBox);
            permitCard.Controls.Add(driverIdBox);
            permitCard.Controls.Add(issueDateBox);
            permitCard.Controls.Add(expiryDateBox);
            permitCard.Controls.Add(feeBox);
            permitCard.Controls.Add(ruleNoticeBox);
            permitCard.CustomizableEdges = customizableEdges1;
            permitCard.Dock = DockStyle.Fill;
            permitCard.FillColor = Color.White;
            permitCard.Location = new Point(554, 0);
            permitCard.Margin = new Padding(14, 0, 0, 0);
            permitCard.Name = "permitCard";
            permitCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            permitCard.Size = new Size(417, 340);
            permitCard.TabIndex = 1;
            // 
            // lblCardTag
            // 
            lblCardTag.AutoSize = true;
            lblCardTag.BackColor = Color.Transparent;
            lblCardTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCardTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblCardTag.Location = new Point(18, 12);
            lblCardTag.Name = "lblCardTag";
            lblCardTag.Size = new Size(118, 12);
            lblCardTag.TabIndex = 0;
            lblCardTag.Text = "INTERNATIONAL PERMIT";
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
            lblCardTitle.Size = new Size(176, 20);
            lblCardTitle.TabIndex = 1;
            lblCardTitle.Text = "Permit Issuance Summary";
            lblCardTitle.UseMnemonic = false;
            // 
            // lblPermitIdPill
            // 
            lblPermitIdPill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPermitIdPill.Animated = false;
            lblPermitIdPill.BackColor = Color.Transparent;
            lblPermitIdPill.BorderColor = Color.FromArgb(226, 232, 240);
            lblPermitIdPill.BorderRadius = 13;
            lblPermitIdPill.BorderThickness = 1;
            lblPermitIdPill.CustomizableEdges = customizableEdges3;
            lblPermitIdPill.FillColor = Color.FromArgb(248, 250, 252);
            lblPermitIdPill.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblPermitIdPill.ForeColor = Color.FromArgb(71, 85, 105);
            lblPermitIdPill.HoverState.BorderColor = Color.FromArgb(226, 232, 240);
            lblPermitIdPill.HoverState.FillColor = Color.FromArgb(248, 250, 252);
            lblPermitIdPill.HoverState.ForeColor = Color.FromArgb(71, 85, 105);
            lblPermitIdPill.Location = new Point(268, 18);
            lblPermitIdPill.Name = "lblPermitIdPill";
            lblPermitIdPill.PressedColor = Color.FromArgb(248, 250, 252);
            lblPermitIdPill.ShadowDecoration.CustomizableEdges = customizableEdges4;
            lblPermitIdPill.Size = new Size(131, 26);
            lblPermitIdPill.TabIndex = 2;
            lblPermitIdPill.TabStop = false;
            lblPermitIdPill.Text = "Permit: Pending";
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
            // localIdBox
            // 
            localIdBox.BackColor = Color.Transparent;
            localIdBox.BorderColor = Color.FromArgb(226, 232, 240);
            localIdBox.BorderRadius = 8;
            localIdBox.BorderThickness = 1;
            localIdBox.Controls.Add(lblLocalIdCaption);
            localIdBox.Controls.Add(lblLocalLicenseId);
            localIdBox.FillColor = Color.FromArgb(248, 250, 252);
            localIdBox.Location = new Point(18, 66);
            localIdBox.Name = "localIdBox";
            localIdBox.Size = new Size(184, 52);
            localIdBox.TabIndex = 4;
            // 
            // lblLocalIdCaption
            // 
            lblLocalIdCaption.AutoSize = true;
            lblLocalIdCaption.BackColor = Color.Transparent;
            lblLocalIdCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblLocalIdCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblLocalIdCaption.Location = new Point(12, 7);
            lblLocalIdCaption.Name = "lblLocalIdCaption";
            lblLocalIdCaption.Size = new Size(92, 12);
            lblLocalIdCaption.TabIndex = 0;
            lblLocalIdCaption.Text = "LOCAL LICENSE ID";
            lblLocalIdCaption.UseMnemonic = false;
            // 
            // lblLocalLicenseId
            // 
            lblLocalLicenseId.AutoEllipsis = true;
            lblLocalLicenseId.BackColor = Color.Transparent;
            lblLocalLicenseId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLocalLicenseId.ForeColor = Color.FromArgb(15, 23, 42);
            lblLocalLicenseId.Location = new Point(12, 23);
            lblLocalLicenseId.Name = "lblLocalLicenseId";
            lblLocalLicenseId.Size = new Size(160, 22);
            lblLocalLicenseId.TabIndex = 1;
            lblLocalLicenseId.Text = "—";
            lblLocalLicenseId.UseMnemonic = false;
            // 
            // driverIdBox
            // 
            driverIdBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            driverIdBox.BackColor = Color.Transparent;
            driverIdBox.BorderColor = Color.FromArgb(226, 232, 240);
            driverIdBox.BorderRadius = 8;
            driverIdBox.BorderThickness = 1;
            driverIdBox.Controls.Add(lblDriverIdCaption);
            driverIdBox.Controls.Add(lblDriverId);
            driverIdBox.FillColor = Color.FromArgb(248, 250, 252);
            driverIdBox.Location = new Point(212, 66);
            driverIdBox.Name = "driverIdBox";
            driverIdBox.Size = new Size(187, 52);
            driverIdBox.TabIndex = 5;
            // 
            // lblDriverIdCaption
            // 
            lblDriverIdCaption.AutoSize = true;
            lblDriverIdCaption.BackColor = Color.Transparent;
            lblDriverIdCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblDriverIdCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblDriverIdCaption.Location = new Point(12, 7);
            lblDriverIdCaption.Name = "lblDriverIdCaption";
            lblDriverIdCaption.Size = new Size(57, 12);
            lblDriverIdCaption.TabIndex = 0;
            lblDriverIdCaption.Text = "DRIVER ID";
            lblDriverIdCaption.UseMnemonic = false;
            // 
            // lblDriverId
            // 
            lblDriverId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDriverId.AutoEllipsis = true;
            lblDriverId.BackColor = Color.Transparent;
            lblDriverId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDriverId.ForeColor = Color.FromArgb(15, 23, 42);
            lblDriverId.Location = new Point(12, 23);
            lblDriverId.Name = "lblDriverId";
            lblDriverId.Size = new Size(163, 22);
            lblDriverId.TabIndex = 1;
            lblDriverId.Text = "—";
            lblDriverId.UseMnemonic = false;
            // 
            // issueDateBox
            // 
            issueDateBox.BackColor = Color.Transparent;
            issueDateBox.BorderColor = Color.FromArgb(226, 232, 240);
            issueDateBox.BorderRadius = 8;
            issueDateBox.BorderThickness = 1;
            issueDateBox.Controls.Add(lblIssueDateCaption);
            issueDateBox.Controls.Add(lblIssueDate);
            issueDateBox.FillColor = Color.FromArgb(248, 250, 252);
            issueDateBox.Location = new Point(18, 126);
            issueDateBox.Name = "issueDateBox";
            issueDateBox.Size = new Size(184, 52);
            issueDateBox.TabIndex = 6;
            // 
            // lblIssueDateCaption
            // 
            lblIssueDateCaption.AutoSize = true;
            lblIssueDateCaption.BackColor = Color.Transparent;
            lblIssueDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblIssueDateCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblIssueDateCaption.Location = new Point(12, 7);
            lblIssueDateCaption.Name = "lblIssueDateCaption";
            lblIssueDateCaption.Size = new Size(61, 12);
            lblIssueDateCaption.TabIndex = 0;
            lblIssueDateCaption.Text = "ISSUE DATE";
            lblIssueDateCaption.UseMnemonic = false;
            // 
            // lblIssueDate
            // 
            lblIssueDate.AutoEllipsis = true;
            lblIssueDate.BackColor = Color.Transparent;
            lblIssueDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblIssueDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblIssueDate.Location = new Point(12, 24);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(160, 20);
            lblIssueDate.TabIndex = 1;
            lblIssueDate.Text = "—";
            lblIssueDate.UseMnemonic = false;
            // 
            // expiryDateBox
            // 
            expiryDateBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            expiryDateBox.BackColor = Color.Transparent;
            expiryDateBox.BorderColor = Color.FromArgb(153, 246, 228);
            expiryDateBox.BorderRadius = 8;
            expiryDateBox.BorderThickness = 1;
            expiryDateBox.Controls.Add(lblExpiryDateCaption);
            expiryDateBox.Controls.Add(lblExpirationDate);
            expiryDateBox.FillColor = Color.FromArgb(240, 253, 250);
            expiryDateBox.Location = new Point(212, 126);
            expiryDateBox.Name = "expiryDateBox";
            expiryDateBox.Size = new Size(187, 52);
            expiryDateBox.TabIndex = 7;
            // 
            // lblExpiryDateCaption
            // 
            lblExpiryDateCaption.AutoSize = true;
            lblExpiryDateCaption.BackColor = Color.Transparent;
            lblExpiryDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblExpiryDateCaption.ForeColor = Color.FromArgb(13, 148, 136);
            lblExpiryDateCaption.Location = new Point(12, 7);
            lblExpiryDateCaption.Name = "lblExpiryDateCaption";
            lblExpiryDateCaption.Size = new Size(106, 12);
            lblExpiryDateCaption.TabIndex = 0;
            lblExpiryDateCaption.Text = "EXPIRATION (+1 YEAR)";
            lblExpiryDateCaption.UseMnemonic = false;
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblExpirationDate.AutoEllipsis = true;
            lblExpirationDate.BackColor = Color.Transparent;
            lblExpirationDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblExpirationDate.ForeColor = Color.FromArgb(15, 118, 110);
            lblExpirationDate.Location = new Point(12, 24);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(163, 20);
            lblExpirationDate.TabIndex = 1;
            lblExpirationDate.Text = "—";
            lblExpirationDate.UseMnemonic = false;
            // 
            // feeBox
            // 
            feeBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            feeBox.BackColor = Color.Transparent;
            feeBox.BorderColor = Color.FromArgb(187, 247, 208);
            feeBox.BorderRadius = 8;
            feeBox.BorderThickness = 1;
            feeBox.Controls.Add(lblFeeCaption);
            feeBox.Controls.Add(lblApplicationFee);
            feeBox.Controls.Add(lblCreatedByInline);
            feeBox.CustomizableEdges = customizableEdges5;
            feeBox.FillColor = Color.FromArgb(220, 252, 231);
            feeBox.Location = new Point(18, 188);
            feeBox.Name = "feeBox";
            feeBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            feeBox.Size = new Size(381, 62);
            feeBox.TabIndex = 8;
            // 
            // lblFeeCaption
            // 
            lblFeeCaption.AutoSize = true;
            lblFeeCaption.BackColor = Color.Transparent;
            lblFeeCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFeeCaption.ForeColor = Color.FromArgb(22, 101, 52);
            lblFeeCaption.Location = new Point(12, 8);
            lblFeeCaption.Name = "lblFeeCaption";
            lblFeeCaption.Size = new Size(124, 12);
            lblFeeCaption.TabIndex = 0;
            lblFeeCaption.Text = "INTERNATIONAL PERMIT FEE";
            lblFeeCaption.UseMnemonic = false;
            // 
            // lblApplicationFee
            // 
            lblApplicationFee.AutoSize = true;
            lblApplicationFee.BackColor = Color.Transparent;
            lblApplicationFee.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblApplicationFee.ForeColor = Color.FromArgb(22, 101, 52);
            lblApplicationFee.Location = new Point(12, 24);
            lblApplicationFee.Name = "lblApplicationFee";
            lblApplicationFee.Size = new Size(64, 25);
            lblApplicationFee.TabIndex = 1;
            lblApplicationFee.Text = "$50.00";
            lblApplicationFee.UseMnemonic = false;
            // 
            // lblCreatedByInline
            // 
            lblCreatedByInline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCreatedByInline.BackColor = Color.Transparent;
            lblCreatedByInline.Font = new Font("Segoe UI", 8.5F);
            lblCreatedByInline.ForeColor = Color.FromArgb(22, 101, 52);
            lblCreatedByInline.Location = new Point(155, 29);
            lblCreatedByInline.Name = "lblCreatedByInline";
            lblCreatedByInline.Size = new Size(214, 18);
            lblCreatedByInline.TabIndex = 2;
            lblCreatedByInline.Text = "Officer: —";
            lblCreatedByInline.TextAlign = ContentAlignment.MiddleRight;
            lblCreatedByInline.UseMnemonic = false;
            // 
            // ruleNoticeBox
            // 
            ruleNoticeBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ruleNoticeBox.BackColor = Color.Transparent;
            ruleNoticeBox.BorderColor = Color.FromArgb(153, 246, 228);
            ruleNoticeBox.BorderRadius = 8;
            ruleNoticeBox.BorderThickness = 1;
            ruleNoticeBox.Controls.Add(lblRuleNotice);
            ruleNoticeBox.CustomizableEdges = customizableEdges7;
            ruleNoticeBox.FillColor = Color.FromArgb(240, 253, 250);
            ruleNoticeBox.Location = new Point(18, 260);
            ruleNoticeBox.Name = "ruleNoticeBox";
            ruleNoticeBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            ruleNoticeBox.Size = new Size(381, 62);
            ruleNoticeBox.TabIndex = 9;
            // 
            // lblRuleNotice
            // 
            lblRuleNotice.BackColor = Color.Transparent;
            lblRuleNotice.Dock = DockStyle.Fill;
            lblRuleNotice.Font = new Font("Segoe UI", 8.5F);
            lblRuleNotice.ForeColor = Color.FromArgb(15, 118, 110);
            lblRuleNotice.Location = new Point(0, 0);
            lblRuleNotice.Name = "lblRuleNotice";
            lblRuleNotice.Padding = new Padding(12, 6, 12, 6);
            lblRuleNotice.Size = new Size(381, 62);
            lblRuleNotice.TabIndex = 0;
            lblRuleNotice.Text = "Eligibility: Requires an active, non-detained Class 3 (Ordinary Driving License) and no currently active International Driving Permit.";
            lblRuleNotice.TextAlign = ContentAlignment.MiddleLeft;
            lblRuleNotice.UseMnemonic = false;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Find an eligible Class 3 local license to issue an international permit.";
            pageActionFooter.Location = new Point(16, 514);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Issue International Permit";
            pageActionFooter.SecondaryButtonText = "Clear";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;
            // 
            // InternationalPermitControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "InternationalPermitControl";
            Size = new Size(1003, 637);
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            permitCard.ResumeLayout(false);
            permitCard.PerformLayout();
            localIdBox.ResumeLayout(false);
            localIdBox.PerformLayout();
            driverIdBox.ResumeLayout(false);
            driverIdBox.PerformLayout();
            issueDateBox.ResumeLayout(false);
            issueDateBox.PerformLayout();
            expiryDateBox.ResumeLayout(false);
            expiryDateBox.PerformLayout();
            feeBox.ResumeLayout(false);
            feeBox.PerformLayout();
            ruleNoticeBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.StatusBannerControl statusBanner;
        private TableLayoutPanel contentLayout;
        private Shared.Controls.LicenseLookupControl licenseLookup;
        private Guna.UI2.WinForms.Guna2Panel permitCard;
        private Label lblCardTag;
        private Label lblCardTitle;
        private Guna.UI2.WinForms.Guna2Button lblPermitIdPill;
        private Panel cardDivider;
        private Guna.UI2.WinForms.Guna2Panel localIdBox;
        private Label lblLocalIdCaption;
        private Label lblLocalLicenseId;
        private Guna.UI2.WinForms.Guna2Panel driverIdBox;
        private Label lblDriverIdCaption;
        private Label lblDriverId;
        private Guna.UI2.WinForms.Guna2Panel issueDateBox;
        private Label lblIssueDateCaption;
        private Label lblIssueDate;
        private Guna.UI2.WinForms.Guna2Panel expiryDateBox;
        private Label lblExpiryDateCaption;
        private Label lblExpirationDate;
        private Guna.UI2.WinForms.Guna2Panel feeBox;
        private Label lblFeeCaption;
        private Label lblApplicationFee;
        private Label lblCreatedByInline;
        private Guna.UI2.WinForms.Guna2Panel ruleNoticeBox;
        private Label lblRuleNotice;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
