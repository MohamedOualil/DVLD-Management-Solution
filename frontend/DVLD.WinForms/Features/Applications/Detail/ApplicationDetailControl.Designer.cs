namespace DVLD.WinForms.Features.Applications.Detail
{
    partial class ApplicationDetailControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pageLayout = new TableLayoutPanel();
            headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            headerIconBadge = new Guna.UI2.WinForms.Guna2Panel();
            lblHeaderIcon = new Label();
            statusButton = new Guna.UI2.WinForms.Guna2Button();
            pageTitle = new Label();
            pageSubtitle = new Label();
            CancelButton = new Guna.UI2.WinForms.Guna2Button();
            EditButton = new Guna.UI2.WinForms.Guna2Button();
            detailsLayout = new TableLayoutPanel();
            applicationMetadataCard = new DVLD.WinForms.Shared.Controls.ApplicationMetadataCardControl();
            applicantPanel = new Guna.UI2.WinForms.Guna2Panel();
            personDetailControl1 = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();
            testRoadmapControl = new DVLD.WinForms.Shared.Controls.TestRoadmapControl();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            headerPanel.SuspendLayout();
            headerIconBadge.SuspendLayout();
            detailsLayout.SuspendLayout();
            applicantPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoSize = true;
            pageLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headerPanel, 0, 0);
            pageLayout.Controls.Add(detailsLayout, 0, 1);
            pageLayout.Controls.Add(testRoadmapControl, 0, 3);
            pageLayout.Controls.Add(pageActionFooter, 0, 5);
            pageLayout.Dock = DockStyle.Top;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(760, 0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 6;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 289F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 188F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            pageLayout.Size = new Size(1003, 653);
            pageLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Transparent;
            headerPanel.BorderColor = Color.FromArgb(220, 230, 238);
            headerPanel.BorderRadius = 12;
            headerPanel.BorderThickness = 1;
            headerPanel.Controls.Add(headerIconBadge);
            headerPanel.Controls.Add(statusButton);
            headerPanel.Controls.Add(pageTitle);
            headerPanel.Controls.Add(pageSubtitle);
            headerPanel.Controls.Add(CancelButton);
            headerPanel.Controls.Add(EditButton);
            headerPanel.CustomizableEdges = customizableEdges9;
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.FillColor = Color.White;
            headerPanel.Location = new Point(16, 16);
            headerPanel.Margin = new Padding(0, 0, 0, 10);
            headerPanel.Name = "headerPanel";
            headerPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            headerPanel.Size = new Size(971, 58);
            headerPanel.TabIndex = 0;
            // 
            // headerIconBadge
            // 
            headerIconBadge.BackColor = Color.Transparent;
            headerIconBadge.BorderColor = Color.FromArgb(153, 246, 228);
            headerIconBadge.BorderRadius = 10;
            headerIconBadge.BorderThickness = 1;
            headerIconBadge.Controls.Add(lblHeaderIcon);
            headerIconBadge.CustomizableEdges = customizableEdges1;
            headerIconBadge.FillColor = Color.FromArgb(240, 253, 250);
            headerIconBadge.Location = new Point(16, 13);
            headerIconBadge.Name = "headerIconBadge";
            headerIconBadge.ShadowDecoration.CustomizableEdges = customizableEdges2;
            headerIconBadge.Size = new Size(42, 42);
            headerIconBadge.TabIndex = 0;
            // 
            // lblHeaderIcon
            // 
            lblHeaderIcon.BackColor = Color.Transparent;
            lblHeaderIcon.Dock = DockStyle.Fill;
            lblHeaderIcon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderIcon.ForeColor = Color.FromArgb(13, 148, 136);
            lblHeaderIcon.Location = new Point(0, 0);
            lblHeaderIcon.Name = "lblHeaderIcon";
            lblHeaderIcon.Size = new Size(42, 42);
            lblHeaderIcon.TabIndex = 0;
            lblHeaderIcon.Text = "AD";
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblHeaderIcon.UseMnemonic = false;
            // 
            // statusButton
            // 
            statusButton.BackColor = Color.Transparent;
            statusButton.BorderColor = Color.FromArgb(153, 246, 228);
            statusButton.BorderRadius = 13;
            statusButton.BorderThickness = 1;
            statusButton.CustomizableEdges = customizableEdges3;
            statusButton.DisabledState.BorderColor = Color.FromArgb(153, 246, 228);
            statusButton.DisabledState.FillColor = Color.FromArgb(204, 251, 241);
            statusButton.DisabledState.ForeColor = Color.FromArgb(15, 118, 110);
            statusButton.Enabled = false;
            statusButton.FillColor = Color.FromArgb(204, 251, 241);
            statusButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            statusButton.ForeColor = Color.FromArgb(15, 118, 110);
            statusButton.Location = new Point(268, 11);
            statusButton.Name = "statusButton";
            statusButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            statusButton.Size = new Size(122, 26);
            statusButton.TabIndex = 3;
            statusButton.TabStop = false;
            statusButton.Text = "● New";
            // 
            // pageTitle
            // 
            pageTitle.AutoSize = true;
            pageTitle.BackColor = Color.Transparent;
            pageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            pageTitle.ForeColor = Color.FromArgb(15, 23, 42);
            pageTitle.Location = new Point(70, 11);
            pageTitle.Name = "pageTitle";
            pageTitle.Size = new Size(176, 25);
            pageTitle.TabIndex = 1;
            pageTitle.Text = "Application details";
            pageTitle.UseMnemonic = false;
            // 
            // pageSubtitle
            // 
            pageSubtitle.AutoSize = true;
            pageSubtitle.BackColor = Color.Transparent;
            pageSubtitle.Font = new Font("Segoe UI", 8.75F);
            pageSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            pageSubtitle.Location = new Point(71, 38);
            pageSubtitle.Name = "pageSubtitle";
            pageSubtitle.Size = new Size(292, 15);
            pageSubtitle.TabIndex = 2;
            pageSubtitle.Text = "Local driving licence application & examination status";
            pageSubtitle.UseMnemonic = false;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CancelButton.BorderColor = Color.FromArgb(254, 202, 202);
            CancelButton.BorderRadius = 8;
            CancelButton.BorderThickness = 1;
            CancelButton.Cursor = Cursors.Hand;
            CancelButton.CustomizableEdges = customizableEdges5;
            CancelButton.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            CancelButton.DisabledState.FillColor = Color.FromArgb(241, 245, 249);
            CancelButton.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            CancelButton.FillColor = Color.FromArgb(254, 242, 242);
            CancelButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            CancelButton.ForeColor = Color.FromArgb(185, 28, 28);
            CancelButton.HoverState.BorderColor = Color.FromArgb(248, 113, 113);
            CancelButton.HoverState.FillColor = Color.FromArgb(254, 226, 226);
            CancelButton.Location = new Point(682, 11);
            CancelButton.Name = "CancelButton";
            CancelButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            CancelButton.Size = new Size(164, 36);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel application";
            CancelButton.Click += CancelButton_Click;
            // 
            // EditButton
            // 
            EditButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditButton.BorderColor = Color.FromArgb(13, 148, 136);
            EditButton.BorderRadius = 8;
            EditButton.BorderThickness = 1;
            EditButton.Cursor = Cursors.Hand;
            EditButton.CustomizableEdges = customizableEdges7;
            EditButton.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            EditButton.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            EditButton.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            EditButton.FillColor = Color.FromArgb(13, 148, 136);
            EditButton.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            EditButton.ForeColor = Color.White;
            EditButton.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            EditButton.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            EditButton.Image = Properties.Resources.icons8_edit_30;
            EditButton.ImageSize = new Size(16, 16);
            EditButton.Location = new Point(856, 11);
            EditButton.Name = "EditButton";
            EditButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            EditButton.Size = new Size(99, 36);
            EditButton.TabIndex = 1;
            EditButton.Text = "Edit";
            EditButton.Click += EditButton_Click;
            // 
            // detailsLayout
            // 
            detailsLayout.ColumnCount = 2;
            detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
            detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56F));
            detailsLayout.Controls.Add(applicationMetadataCard, 0, 0);
            detailsLayout.Controls.Add(applicantPanel, 1, 0);
            detailsLayout.Dock = DockStyle.Fill;
            detailsLayout.Location = new Point(16, 84);
            detailsLayout.Margin = new Padding(0);
            detailsLayout.Name = "detailsLayout";
            detailsLayout.RowCount = 1;
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            detailsLayout.Size = new Size(971, 289);
            detailsLayout.TabIndex = 1;
            // 
            // applicationMetadataCard
            // 
            applicationMetadataCard.BackColor = Color.Transparent;
            applicationMetadataCard.Dock = DockStyle.Fill;
            applicationMetadataCard.Font = new Font("Segoe UI", 9F);
            applicationMetadataCard.Location = new Point(0, 0);
            applicationMetadataCard.Margin = new Padding(0);
            applicationMetadataCard.MinimumSize = new Size(380, 289);
            applicationMetadataCard.Name = "applicationMetadataCard";
            applicationMetadataCard.Size = new Size(427, 289);
            applicationMetadataCard.TabIndex = 0;
            // 
            // applicantPanel
            // 
            applicantPanel.BorderColor = Color.FromArgb(220, 230, 238);
            applicantPanel.BorderRadius = 12;
            applicantPanel.BorderThickness = 1;
            applicantPanel.Controls.Add(personDetailControl1);
            applicantPanel.CustomizableEdges = customizableEdges11;
            applicantPanel.Dock = DockStyle.Fill;
            applicantPanel.FillColor = Color.White;
            applicantPanel.Location = new Point(441, 0);
            applicantPanel.Margin = new Padding(14, 0, 0, 0);
            applicantPanel.Name = "applicantPanel";
            applicantPanel.Padding = new Padding(12);
            applicantPanel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            applicantPanel.Size = new Size(530, 289);
            applicantPanel.TabIndex = 1;
            // 
            // personDetailControl1
            // 
            personDetailControl1.BackColor = Color.White;
            personDetailControl1.Dock = DockStyle.Fill;
            personDetailControl1.Font = new Font("Segoe UI", 9F);
            personDetailControl1.Location = new Point(12, 12);
            personDetailControl1.Name = "personDetailControl1";
            personDetailControl1.Size = new Size(506, 265);
            personDetailControl1.TabIndex = 0;
            // 
            // testRoadmapControl
            // 
            testRoadmapControl.BackColor = Color.Transparent;
            testRoadmapControl.Dock = DockStyle.Fill;
            testRoadmapControl.Font = new Font("Segoe UI", 9F);
            testRoadmapControl.Location = new Point(16, 383);
            testRoadmapControl.Margin = new Padding(0);
            testRoadmapControl.MinimumSize = new Size(710, 188);
            testRoadmapControl.Name = "testRoadmapControl";
            testRoadmapControl.Size = new Size(971, 188);
            testRoadmapControl.TabIndex = 2;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Licence details are available after the application is completed.";
            pageActionFooter.Location = new Point(16, 581);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.MinimumSize = new Size(520, 56);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = false;
            pageActionFooter.PrimaryButtonText = "Show Licence";
            pageActionFooter.SecondaryButtonText = "Cancel Edit";
            pageActionFooter.ShowSecondaryButton = false;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;
            // 
            // ApplicationDetailControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "ApplicationDetailControl";
            Size = new Size(1003, 653);
            pageLayout.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            headerIconBadge.ResumeLayout(false);
            detailsLayout.ResumeLayout(false);
            applicantPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private Guna.UI2.WinForms.Guna2Panel headerIconBadge;
        private Label lblHeaderIcon;
        private Label pageTitle;
        private Label pageSubtitle;
        private Guna.UI2.WinForms.Guna2Button statusButton;
        private Guna.UI2.WinForms.Guna2Button EditButton;
        private Guna.UI2.WinForms.Guna2Button CancelButton;
        private TableLayoutPanel detailsLayout;
        private Shared.Controls.ApplicationMetadataCardControl applicationMetadataCard;
        private Guna.UI2.WinForms.Guna2Panel applicantPanel;
        private Persons.Detail.PersonDetailControl personDetailControl1;
        private Shared.Controls.TestRoadmapControl testRoadmapControl;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
