namespace DVLD.WinForms.Features.Licenses.DetainRelease
{
    partial class DetainReleaseLicenseControl
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
            detainReleaseCard = new Guna.UI2.WinForms.Guna2Panel();
            lblCardTag = new Label();
            lblCardTitle = new Label();
            lblModePill = new Guna.UI2.WinForms.Guna2Button();
            cardDivider = new Panel();
            dateBox = new Guna.UI2.WinForms.Guna2Panel();
            lblDateCaption = new Label();
            lblActionDate = new Label();
            feeBox = new Guna.UI2.WinForms.Guna2Panel();
            lblFeeCaption = new Label();
            lblReleaseFee = new Label();
            lblFineCaption = new Label();
            txtFineAmount = new Guna.UI2.WinForms.Guna2TextBox();
            lblCreatedByCaption = new Label();
            lblCreatedBy = new Label();
            lblNotesCaption = new Label();
            txtReasonNotes = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            detainReleaseCard.SuspendLayout();
            dateBox.SuspendLayout();
            feeBox.SuspendLayout();
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
            pageHeader.BadgeText = "● Hold / Release";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Warning;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "DR";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Place an administrative hold (detain) on a licence or release an existing detention";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Detain & Release Driving Licence";
            // 
            // statusBanner
            // 
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Search for a licence on the left to automatically switch between Detain and Release mode.";
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
            contentLayout.Controls.Add(detainReleaseCard, 1, 0);
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
            // detainReleaseCard
            // 
            detainReleaseCard.BackColor = Color.Transparent;
            detainReleaseCard.BorderColor = Color.FromArgb(220, 230, 238);
            detainReleaseCard.BorderRadius = 12;
            detainReleaseCard.BorderThickness = 1;
            detainReleaseCard.Controls.Add(lblCardTag);
            detainReleaseCard.Controls.Add(lblCardTitle);
            detainReleaseCard.Controls.Add(lblModePill);
            detainReleaseCard.Controls.Add(cardDivider);
            detainReleaseCard.Controls.Add(dateBox);
            detainReleaseCard.Controls.Add(feeBox);
            detainReleaseCard.Controls.Add(lblFineCaption);
            detainReleaseCard.Controls.Add(txtFineAmount);
            detainReleaseCard.Controls.Add(lblCreatedByCaption);
            detainReleaseCard.Controls.Add(lblCreatedBy);
            detainReleaseCard.Controls.Add(lblNotesCaption);
            detainReleaseCard.Controls.Add(txtReasonNotes);
            detainReleaseCard.CustomizableEdges = customizableEdges1;
            detainReleaseCard.Dock = DockStyle.Fill;
            detainReleaseCard.FillColor = Color.White;
            detainReleaseCard.Location = new Point(554, 0);
            detainReleaseCard.Margin = new Padding(14, 0, 0, 0);
            detainReleaseCard.Name = "detainReleaseCard";
            detainReleaseCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            detainReleaseCard.Size = new Size(417, 340);
            detainReleaseCard.TabIndex = 1;
            // 
            // lblCardTag
            // 
            lblCardTag.AutoSize = true;
            lblCardTag.BackColor = Color.Transparent;
            lblCardTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCardTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblCardTag.Location = new Point(18, 12);
            lblCardTag.Name = "lblCardTag";
            lblCardTag.Size = new Size(131, 12);
            lblCardTag.TabIndex = 0;
            lblCardTag.Text = "DETENTION & RELEASE";
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
            lblCardTitle.Text = "Detention Action Details";
            lblCardTitle.UseMnemonic = false;
            // 
            // lblModePill
            // 
            lblModePill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblModePill.Animated = false;
            lblModePill.BackColor = Color.Transparent;
            lblModePill.BorderColor = Color.FromArgb(226, 232, 240);
            lblModePill.BorderRadius = 13;
            lblModePill.BorderThickness = 1;
            lblModePill.CustomizableEdges = customizableEdges3;
            lblModePill.FillColor = Color.FromArgb(248, 250, 252);
            lblModePill.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblModePill.ForeColor = Color.FromArgb(71, 85, 105);
            lblModePill.HoverState.BorderColor = Color.FromArgb(226, 232, 240);
            lblModePill.HoverState.FillColor = Color.FromArgb(248, 250, 252);
            lblModePill.HoverState.ForeColor = Color.FromArgb(71, 85, 105);
            lblModePill.Location = new Point(268, 18);
            lblModePill.Name = "lblModePill";
            lblModePill.PressedColor = Color.FromArgb(248, 250, 252);
            lblModePill.ShadowDecoration.CustomizableEdges = customizableEdges4;
            lblModePill.Size = new Size(131, 26);
            lblModePill.TabIndex = 2;
            lblModePill.TabStop = false;
            lblModePill.Text = "○ Mode: Auto";
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
            // dateBox
            // 
            dateBox.BackColor = Color.Transparent;
            dateBox.BorderColor = Color.FromArgb(226, 232, 240);
            dateBox.BorderRadius = 8;
            dateBox.BorderThickness = 1;
            dateBox.Controls.Add(lblDateCaption);
            dateBox.Controls.Add(lblActionDate);
            dateBox.FillColor = Color.FromArgb(248, 250, 252);
            dateBox.Location = new Point(18, 66);
            dateBox.Name = "dateBox";
            dateBox.Size = new Size(184, 50);
            dateBox.TabIndex = 4;
            // 
            // lblDateCaption
            // 
            lblDateCaption.AutoSize = true;
            lblDateCaption.BackColor = Color.Transparent;
            lblDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblDateCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblDateCaption.Location = new Point(12, 6);
            lblDateCaption.Name = "lblDateCaption";
            lblDateCaption.Size = new Size(71, 12);
            lblDateCaption.TabIndex = 0;
            lblDateCaption.Text = "ACTION DATE";
            lblDateCaption.UseMnemonic = false;
            // 
            // lblActionDate
            // 
            lblActionDate.AutoEllipsis = true;
            lblActionDate.BackColor = Color.Transparent;
            lblActionDate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblActionDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblActionDate.Location = new Point(12, 23);
            lblActionDate.Name = "lblActionDate";
            lblActionDate.Size = new Size(160, 20);
            lblActionDate.TabIndex = 1;
            lblActionDate.Text = "—";
            lblActionDate.UseMnemonic = false;
            // 
            // feeBox
            // 
            feeBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            feeBox.BackColor = Color.Transparent;
            feeBox.BorderColor = Color.FromArgb(226, 232, 240);
            feeBox.BorderRadius = 8;
            feeBox.BorderThickness = 1;
            feeBox.Controls.Add(lblFeeCaption);
            feeBox.Controls.Add(lblReleaseFee);
            feeBox.FillColor = Color.FromArgb(248, 250, 252);
            feeBox.Location = new Point(212, 66);
            feeBox.Name = "feeBox";
            feeBox.Size = new Size(187, 50);
            feeBox.TabIndex = 5;
            // 
            // lblFeeCaption
            // 
            lblFeeCaption.AutoSize = true;
            lblFeeCaption.BackColor = Color.Transparent;
            lblFeeCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFeeCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblFeeCaption.Location = new Point(12, 6);
            lblFeeCaption.Name = "lblFeeCaption";
            lblFeeCaption.Size = new Size(88, 12);
            lblFeeCaption.TabIndex = 0;
            lblFeeCaption.Text = "RELEASE APP FEE";
            lblFeeCaption.UseMnemonic = false;
            // 
            // lblReleaseFee
            // 
            lblReleaseFee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblReleaseFee.AutoEllipsis = true;
            lblReleaseFee.BackColor = Color.Transparent;
            lblReleaseFee.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblReleaseFee.ForeColor = Color.FromArgb(15, 23, 42);
            lblReleaseFee.Location = new Point(12, 22);
            lblReleaseFee.Name = "lblReleaseFee";
            lblReleaseFee.Size = new Size(163, 22);
            lblReleaseFee.TabIndex = 1;
            lblReleaseFee.Text = "$15.00";
            lblReleaseFee.UseMnemonic = false;
            // 
            // lblFineCaption
            // 
            lblFineCaption.AutoSize = true;
            lblFineCaption.BackColor = Color.Transparent;
            lblFineCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblFineCaption.ForeColor = Color.FromArgb(51, 65, 85);
            lblFineCaption.Location = new Point(18, 126);
            lblFineCaption.Name = "lblFineCaption";
            lblFineCaption.Size = new Size(121, 13);
            lblFineCaption.TabIndex = 6;
            lblFineCaption.Text = "DETENTION FINE (USD)";
            lblFineCaption.UseMnemonic = false;
            // 
            // txtFineAmount
            // 
            txtFineAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFineAmount.BorderColor = Color.FromArgb(220, 230, 238);
            txtFineAmount.BorderRadius = 8;
            txtFineAmount.Cursor = Cursors.IBeam;
            txtFineAmount.CustomizableEdges = customizableEdges5;
            txtFineAmount.DefaultText = "";
            txtFineAmount.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtFineAmount.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtFineAmount.DisabledState.ForeColor = Color.FromArgb(100, 116, 139);
            txtFineAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtFineAmount.Enabled = false;
            txtFineAmount.FillColor = Color.FromArgb(248, 250, 252);
            txtFineAmount.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtFineAmount.FocusedState.FillColor = Color.White;
            txtFineAmount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            txtFineAmount.ForeColor = Color.FromArgb(15, 23, 42);
            txtFineAmount.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtFineAmount.Location = new Point(18, 143);
            txtFineAmount.Name = "txtFineAmount";
            txtFineAmount.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtFineAmount.PlaceholderText = "Enter fine amount (e.g., 150.00)...";
            txtFineAmount.SelectedText = "";
            txtFineAmount.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtFineAmount.Size = new Size(381, 38);
            txtFineAmount.TabIndex = 7;
            txtFineAmount.TextOffset = new Point(8, 0);
            // 
            // lblCreatedByCaption & lblCreatedBy
            // 
            lblCreatedByCaption.AutoSize = true;
            lblCreatedByCaption.BackColor = Color.Transparent;
            lblCreatedByCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCreatedByCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblCreatedByCaption.Location = new Point(18, 190);
            lblCreatedByCaption.Name = "lblCreatedByCaption";
            lblCreatedByCaption.Size = new Size(63, 12);
            lblCreatedByCaption.TabIndex = 8;
            lblCreatedByCaption.Text = "PROCESSED BY";
            lblCreatedByCaption.UseMnemonic = false;

            lblCreatedBy.AutoEllipsis = true;
            lblCreatedBy.BackColor = Color.Transparent;
            lblCreatedBy.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            lblCreatedBy.ForeColor = Color.FromArgb(51, 65, 85);
            lblCreatedBy.Location = new Point(18, 205);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(381, 18);
            lblCreatedBy.TabIndex = 9;
            lblCreatedBy.Text = "—";
            lblCreatedBy.UseMnemonic = false;

            // 
            // lblNotesCaption & txtReasonNotes
            // 
            lblNotesCaption.AutoSize = true;
            lblNotesCaption.BackColor = Color.Transparent;
            lblNotesCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblNotesCaption.ForeColor = Color.FromArgb(51, 65, 85);
            lblNotesCaption.Location = new Point(18, 232);
            lblNotesCaption.Name = "lblNotesCaption";
            lblNotesCaption.Size = new Size(160, 13);
            lblNotesCaption.TabIndex = 10;
            lblNotesCaption.Text = "REASON / NOTES (OPTIONAL)";
            lblNotesCaption.UseMnemonic = false;

            txtReasonNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtReasonNotes.BorderColor = Color.FromArgb(220, 230, 238);
            txtReasonNotes.BorderRadius = 8;
            txtReasonNotes.Cursor = Cursors.IBeam;
            txtReasonNotes.CustomizableEdges = customizableEdges7;
            txtReasonNotes.DefaultText = "";
            txtReasonNotes.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtReasonNotes.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtReasonNotes.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtReasonNotes.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtReasonNotes.FillColor = Color.FromArgb(248, 250, 252);
            txtReasonNotes.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtReasonNotes.FocusedState.FillColor = Color.White;
            txtReasonNotes.Font = new Font("Segoe UI", 9F);
            txtReasonNotes.ForeColor = Color.FromArgb(15, 23, 42);
            txtReasonNotes.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtReasonNotes.Location = new Point(18, 250);
            txtReasonNotes.Multiline = true;
            txtReasonNotes.Name = "txtReasonNotes";
            txtReasonNotes.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtReasonNotes.PlaceholderText = "Reason for detention or release officer remarks...";
            txtReasonNotes.SelectedText = "";
            txtReasonNotes.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtReasonNotes.Size = new Size(381, 72);
            txtReasonNotes.TabIndex = 11;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Find a local license to detain or release it.";
            pageActionFooter.Location = new Point(16, 514);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Detain License";
            pageActionFooter.SecondaryButtonText = "Clear";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;
            // 
            // DetainReleaseLicenseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "DetainReleaseLicenseControl";
            Size = new Size(1003, 637);
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            detainReleaseCard.ResumeLayout(false);
            detainReleaseCard.PerformLayout();
            dateBox.ResumeLayout(false);
            dateBox.PerformLayout();
            feeBox.ResumeLayout(false);
            feeBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.StatusBannerControl statusBanner;
        private TableLayoutPanel contentLayout;
        private Shared.Controls.LicenseLookupControl licenseLookup;
        private Guna.UI2.WinForms.Guna2Panel detainReleaseCard;
        private Label lblCardTag;
        private Label lblCardTitle;
        private Guna.UI2.WinForms.Guna2Button lblModePill;
        private Panel cardDivider;
        private Guna.UI2.WinForms.Guna2Panel dateBox;
        private Label lblDateCaption;
        private Label lblActionDate;
        private Guna.UI2.WinForms.Guna2Panel feeBox;
        private Label lblFeeCaption;
        private Label lblReleaseFee;
        private Label lblFineCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtFineAmount;
        private Label lblCreatedByCaption;
        private Label lblCreatedBy;
        private Label lblNotesCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtReasonNotes;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
