namespace DVLD.WinForms.Features.Applications.IssueDrivingLicence
{
    partial class IssueDrivingLicenceControl
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
            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            applicantBanner = new DVLD.WinForms.Shared.Controls.ApplicantBannerControl();
            eligibilityBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            contentLayout = new TableLayoutPanel();
            applicationMetadataCard = new DVLD.WinForms.Shared.Controls.ApplicationMetadataCardControl();
            notesCard = new Guna.UI2.WinForms.Guna2Panel();
            lblNotesTag = new Label();
            lblNotesTitle = new Label();
            lblNotesOptional = new Label();
            notesDivider = new Panel();
            lblNotesPrompt = new Label();
            notesTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            notesCard.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoSize = true;
            pageLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(applicantBanner, 0, 2);
            pageLayout.Controls.Add(eligibilityBanner, 0, 4);
            pageLayout.Controls.Add(contentLayout, 0, 6);
            pageLayout.Controls.Add(pageActionFooter, 0, 8);
            pageLayout.Dock = DockStyle.Top;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(760, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 9;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 289F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            pageLayout.Size = new Size(1003, 641);
            pageLayout.TabIndex = 0;
            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● First Issuance";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "DL";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Verify examination eligibility and issue the first-time driving licence";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Issue Driving Licence";
            // 
            // applicantBanner
            // 
            applicantBanner.BackColor = Color.Transparent;
            applicantBanner.Dock = DockStyle.Fill;
            applicantBanner.Font = new Font("Segoe UI", 9F);
            applicantBanner.Location = new Point(16, 94);
            applicantBanner.Margin = new Padding(0);
            applicantBanner.Name = "applicantBanner";
            applicantBanner.ShowViewPersonButton = true;
            applicantBanner.Size = new Size(971, 96);
            applicantBanner.TabIndex = 1;
            // 
            // eligibilityBanner
            // 
            eligibilityBanner.BackColor = Color.Transparent;
            eligibilityBanner.Description = "Checking passed examination records and application standing…";
            eligibilityBanner.Dock = DockStyle.Fill;
            eligibilityBanner.Font = new Font("Segoe UI", 9F);
            eligibilityBanner.Location = new Point(16, 200);
            eligibilityBanner.Margin = new Padding(0);
            eligibilityBanner.Name = "eligibilityBanner";
            eligibilityBanner.Size = new Size(971, 60);
            eligibilityBanner.TabIndex = 2;
            eligibilityBanner.Title = "Loading application information…";
            eligibilityBanner.Tone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 430F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(applicationMetadataCard, 0, 0);
            contentLayout.Controls.Add(notesCard, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(16, 270);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(971, 289);
            contentLayout.TabIndex = 3;
            // 
            // applicationMetadataCard
            // 
            applicationMetadataCard.BackColor = Color.Transparent;
            applicationMetadataCard.Dock = DockStyle.Fill;
            applicationMetadataCard.Font = new Font("Segoe UI", 9F);
            applicationMetadataCard.IsLicenseClassEditable = false;
            applicationMetadataCard.Location = new Point(0, 0);
            applicationMetadataCard.Margin = new Padding(0);
            applicationMetadataCard.Name = "applicationMetadataCard";
            applicationMetadataCard.Size = new Size(430, 289);
            applicationMetadataCard.TabIndex = 0;
            // 
            // notesCard
            // 
            notesCard.BackColor = Color.Transparent;
            notesCard.BorderColor = Color.FromArgb(220, 230, 238);
            notesCard.BorderRadius = 12;
            notesCard.BorderThickness = 1;
            notesCard.Controls.Add(lblNotesTag);
            notesCard.Controls.Add(lblNotesTitle);
            notesCard.Controls.Add(lblNotesOptional);
            notesCard.Controls.Add(notesDivider);
            notesCard.Controls.Add(lblNotesPrompt);
            notesCard.Controls.Add(notesTextBox);
            notesCard.CustomizableEdges = customizableEdges1;
            notesCard.Dock = DockStyle.Fill;
            notesCard.FillColor = Color.White;
            notesCard.Location = new Point(444, 0);
            notesCard.Margin = new Padding(14, 0, 0, 0);
            notesCard.Name = "notesCard";
            notesCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            notesCard.Size = new Size(527, 289);
            notesCard.TabIndex = 1;
            // 
            // lblNotesTag
            // 
            lblNotesTag.AutoSize = true;
            lblNotesTag.BackColor = Color.Transparent;
            lblNotesTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblNotesTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblNotesTag.Location = new Point(18, 12);
            lblNotesTag.Name = "lblNotesTag";
            lblNotesTag.Size = new Size(88, 12);
            lblNotesTag.TabIndex = 0;
            lblNotesTag.Text = "ISSUANCE NOTES";
            lblNotesTag.UseMnemonic = false;
            // 
            // lblNotesTitle
            // 
            lblNotesTitle.AutoSize = true;
            lblNotesTitle.BackColor = Color.Transparent;
            lblNotesTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNotesTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblNotesTitle.Location = new Point(17, 27);
            lblNotesTitle.Name = "lblNotesTitle";
            lblNotesTitle.Size = new Size(218, 20);
            lblNotesTitle.TabIndex = 1;
            lblNotesTitle.Text = "Licence Remarks & Conditions";
            lblNotesTitle.UseMnemonic = false;
            // 
            // lblNotesOptional
            // 
            lblNotesOptional.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNotesOptional.AutoSize = true;
            lblNotesOptional.BackColor = Color.Transparent;
            lblNotesOptional.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblNotesOptional.ForeColor = Color.FromArgb(100, 116, 139);
            lblNotesOptional.Location = new Point(458, 29);
            lblNotesOptional.Name = "lblNotesOptional";
            lblNotesOptional.Size = new Size(51, 13);
            lblNotesOptional.TabIndex = 2;
            lblNotesOptional.Text = "Optional";
            lblNotesOptional.UseMnemonic = false;
            // 
            // notesDivider
            // 
            notesDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            notesDivider.BackColor = Color.FromArgb(226, 232, 240);
            notesDivider.Location = new Point(18, 56);
            notesDivider.Name = "notesDivider";
            notesDivider.Size = new Size(491, 1);
            notesDivider.TabIndex = 3;
            // 
            // lblNotesPrompt
            // 
            lblNotesPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNotesPrompt.BackColor = Color.Transparent;
            lblNotesPrompt.Font = new Font("Segoe UI", 8.75F);
            lblNotesPrompt.ForeColor = Color.FromArgb(100, 116, 139);
            lblNotesPrompt.Location = new Point(18, 66);
            lblNotesPrompt.Name = "lblNotesPrompt";
            lblNotesPrompt.Size = new Size(491, 34);
            lblNotesPrompt.TabIndex = 4;
            lblNotesPrompt.Text = "Record any driving restrictions, medical endorsements, or inspector comments to attach to this licence.";
            lblNotesPrompt.UseMnemonic = false;
            // 
            // notesTextBox
            // 
            notesTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            notesTextBox.BorderColor = Color.FromArgb(220, 230, 238);
            notesTextBox.BorderRadius = 8;
            notesTextBox.Cursor = Cursors.IBeam;
            notesTextBox.CustomizableEdges = customizableEdges3;
            notesTextBox.DefaultText = "";
            notesTextBox.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            notesTextBox.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            notesTextBox.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            notesTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            notesTextBox.FillColor = Color.FromArgb(248, 250, 252);
            notesTextBox.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            notesTextBox.FocusedState.FillColor = Color.White;
            notesTextBox.Font = new Font("Segoe UI", 9.5F);
            notesTextBox.ForeColor = Color.FromArgb(15, 23, 42);
            notesTextBox.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            notesTextBox.Location = new Point(18, 108);
            notesTextBox.Multiline = true;
            notesTextBox.Name = "notesTextBox";
            notesTextBox.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            notesTextBox.PlaceholderText = "Optional remarks (e.g., Corrective lenses required while driving)...";
            notesTextBox.SelectedText = "";
            notesTextBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            notesTextBox.Size = new Size(491, 163);
            notesTextBox.TabIndex = 5;
            notesTextBox.TextChanged += notesTextBox_TextChanged;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Loading application information…";
            pageActionFooter.Location = new Point(16, 569);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Issue Driving Licence";
            pageActionFooter.SecondaryButtonText = "Cancel";
            pageActionFooter.ShowSecondaryButton = false;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 4;
            // 
            // IssueDrivingLicenceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "IssueDrivingLicenceControl";
            Size = new Size(1003, 650);
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            notesCard.ResumeLayout(false);
            notesCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.ApplicantBannerControl applicantBanner;
        private Shared.Controls.StatusBannerControl eligibilityBanner;
        private TableLayoutPanel contentLayout;
        private Shared.Controls.ApplicationMetadataCardControl applicationMetadataCard;
        private Guna.UI2.WinForms.Guna2Panel notesCard;
        private Label lblNotesTag;
        private Label lblNotesTitle;
        private Label lblNotesOptional;
        private Panel notesDivider;
        private Label lblNotesPrompt;
        private Guna.UI2.WinForms.Guna2TextBox notesTextBox;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
