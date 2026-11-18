namespace DVLD.WinForms.Features.Tests.ScheduleTest
{
    partial class ScheduleTestControl
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
            applicantBanner = new DVLD.WinForms.Shared.Controls.ApplicantBannerControl();
            contentLayout = new TableLayoutPanel();
            applicationMetadataCard = new DVLD.WinForms.Shared.Controls.ApplicationMetadataCardControl();
            appointmentCard = new Guna.UI2.WinForms.Guna2Panel();
            lblBookingTag = new Label();
            lblBookingTitle = new Label();
            lblTestName = new Guna.UI2.WinForms.Guna2Button();
            bookingDivider = new Panel();
            feesBox = new Guna.UI2.WinForms.Guna2Panel();
            lblFeesCaption = new Label();
            lblFees = new Label();
            trialsBox = new Guna.UI2.WinForms.Guna2Panel();
            lblTrailCaption = new Label();
            lblTrail = new Label();
            lblDateCaption = new Label();
            tpAppointmentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblDateHint = new Label();
            bookingNotePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblBookingNote = new Label();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            pageLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            appointmentCard.SuspendLayout();
            feesBox.SuspendLayout();
            trialsBox.SuspendLayout();
            bookingNotePanel.SuspendLayout();
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
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 289F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            pageLayout.Size = new Size(1003, 571);
            pageLayout.TabIndex = 0;
            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● Scheduling Slot";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "ST";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Select a date and time for the applicant's examination attempt";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Schedule Examination Appointment";
            // 
            // applicantBanner
            // 
            applicantBanner.BackColor = Color.Transparent;
            applicantBanner.Dock = DockStyle.Fill;
            applicantBanner.Font = new Font("Segoe UI", 9F);
            applicantBanner.Location = new Point(16, 94);
            applicantBanner.Margin = new Padding(0);
            applicantBanner.Name = "applicantBanner";
            applicantBanner.ShowViewPersonButton = false;
            applicantBanner.Size = new Size(971, 96);
            applicantBanner.TabIndex = 1;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 430F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(applicationMetadataCard, 0, 0);
            contentLayout.Controls.Add(appointmentCard, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(16, 200);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(971, 289);
            contentLayout.TabIndex = 2;
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
            // appointmentCard
            // 
            appointmentCard.BackColor = Color.Transparent;
            appointmentCard.BorderColor = Color.FromArgb(220, 230, 238);
            appointmentCard.BorderRadius = 12;
            appointmentCard.BorderThickness = 1;
            appointmentCard.Controls.Add(lblBookingTag);
            appointmentCard.Controls.Add(lblBookingTitle);
            appointmentCard.Controls.Add(lblTestName);
            appointmentCard.Controls.Add(bookingDivider);
            appointmentCard.Controls.Add(feesBox);
            appointmentCard.Controls.Add(trialsBox);
            appointmentCard.Controls.Add(lblDateCaption);
            appointmentCard.Controls.Add(tpAppointmentDate);
            appointmentCard.Controls.Add(lblDateHint);
            appointmentCard.Controls.Add(bookingNotePanel);
            appointmentCard.CustomizableEdges = customizableEdges1;
            appointmentCard.Dock = DockStyle.Fill;
            appointmentCard.FillColor = Color.White;
            appointmentCard.Location = new Point(444, 0);
            appointmentCard.Margin = new Padding(14, 0, 0, 0);
            appointmentCard.Name = "appointmentCard";
            appointmentCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            appointmentCard.Size = new Size(527, 289);
            appointmentCard.TabIndex = 1;
            // 
            // lblBookingTag
            // 
            lblBookingTag.AutoSize = true;
            lblBookingTag.BackColor = Color.Transparent;
            lblBookingTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblBookingTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblBookingTag.Location = new Point(18, 12);
            lblBookingTag.Name = "lblBookingTag";
            lblBookingTag.Size = new Size(118, 12);
            lblBookingTag.TabIndex = 0;
            lblBookingTag.Text = "APPOINTMENT SLOT";
            lblBookingTag.UseMnemonic = false;
            // 
            // lblBookingTitle
            // 
            lblBookingTitle.AutoSize = true;
            lblBookingTitle.BackColor = Color.Transparent;
            lblBookingTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBookingTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblBookingTitle.Location = new Point(17, 27);
            lblBookingTitle.Name = "lblBookingTitle";
            lblBookingTitle.Size = new Size(189, 20);
            lblBookingTitle.TabIndex = 1;
            lblBookingTitle.Text = "Examination Slot & Fees";
            lblBookingTitle.UseMnemonic = false;
            // 
            // lblTestName
            // 
            lblTestName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTestName.Animated = false;
            lblTestName.BackColor = Color.Transparent;
            lblTestName.BorderColor = Color.FromArgb(153, 246, 228);
            lblTestName.BorderRadius = 13;
            lblTestName.BorderThickness = 1;
            lblTestName.CustomizableEdges = customizableEdges3;
            lblTestName.FillColor = Color.FromArgb(240, 253, 250);
            lblTestName.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            lblTestName.ForeColor = Color.FromArgb(15, 118, 110);
            lblTestName.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            lblTestName.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            lblTestName.HoverState.ForeColor = Color.FromArgb(15, 118, 110);
            lblTestName.Location = new Point(365, 17);
            lblTestName.Name = "lblTestName";
            lblTestName.PressedColor = Color.FromArgb(240, 253, 250);
            lblTestName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            lblTestName.Size = new Size(144, 28);
            lblTestName.TabIndex = 2;
            lblTestName.TabStop = false;
            lblTestName.Text = "Vision Test";
            // 
            // bookingDivider
            // 
            bookingDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookingDivider.BackColor = Color.FromArgb(226, 232, 240);
            bookingDivider.Location = new Point(18, 56);
            bookingDivider.Name = "bookingDivider";
            bookingDivider.Size = new Size(491, 1);
            bookingDivider.TabIndex = 3;
            // 
            // feesBox
            // 
            feesBox.BackColor = Color.Transparent;
            feesBox.BorderColor = Color.FromArgb(187, 247, 208);
            feesBox.BorderRadius = 8;
            feesBox.BorderThickness = 1;
            feesBox.Controls.Add(lblFeesCaption);
            feesBox.Controls.Add(lblFees);
            feesBox.CustomizableEdges = customizableEdges5;
            feesBox.FillColor = Color.FromArgb(220, 252, 231);
            feesBox.Location = new Point(18, 66);
            feesBox.Name = "feesBox";
            feesBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            feesBox.Size = new Size(238, 52);
            feesBox.TabIndex = 4;
            // 
            // lblFeesCaption
            // 
            lblFeesCaption.AutoSize = true;
            lblFeesCaption.BackColor = Color.Transparent;
            lblFeesCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFeesCaption.ForeColor = Color.FromArgb(22, 101, 52);
            lblFeesCaption.Location = new Point(12, 7);
            lblFeesCaption.Name = "lblFeesCaption";
            lblFeesCaption.Size = new Size(92, 12);
            lblFeesCaption.TabIndex = 0;
            lblFeesCaption.Text = "EXAMINATION FEE";
            lblFeesCaption.UseMnemonic = false;
            // 
            // lblFees
            // 
            lblFees.AutoEllipsis = true;
            lblFees.BackColor = Color.Transparent;
            lblFees.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblFees.ForeColor = Color.FromArgb(22, 101, 52);
            lblFees.Location = new Point(12, 22);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(214, 22);
            lblFees.TabIndex = 1;
            lblFees.Text = "$10.00";
            lblFees.UseMnemonic = false;
            // 
            // trialsBox
            // 
            trialsBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trialsBox.BackColor = Color.Transparent;
            trialsBox.BorderColor = Color.FromArgb(226, 232, 240);
            trialsBox.BorderRadius = 8;
            trialsBox.BorderThickness = 1;
            trialsBox.Controls.Add(lblTrailCaption);
            trialsBox.Controls.Add(lblTrail);
            trialsBox.CustomizableEdges = customizableEdges7;
            trialsBox.FillColor = Color.FromArgb(248, 250, 252);
            trialsBox.Location = new Point(268, 66);
            trialsBox.Name = "trialsBox";
            trialsBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            trialsBox.Size = new Size(241, 52);
            trialsBox.TabIndex = 5;
            // 
            // lblTrailCaption
            // 
            lblTrailCaption.AutoSize = true;
            lblTrailCaption.BackColor = Color.Transparent;
            lblTrailCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblTrailCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblTrailCaption.Location = new Point(12, 7);
            lblTrailCaption.Name = "lblTrailCaption";
            lblTrailCaption.Size = new Size(88, 12);
            lblTrailCaption.TabIndex = 0;
            lblTrailCaption.Text = "PRIOR ATTEMPTS";
            lblTrailCaption.UseMnemonic = false;
            // 
            // lblTrail
            // 
            lblTrail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrail.AutoEllipsis = true;
            lblTrail.BackColor = Color.Transparent;
            lblTrail.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTrail.ForeColor = Color.FromArgb(15, 23, 42);
            lblTrail.Location = new Point(12, 22);
            lblTrail.Name = "lblTrail";
            lblTrail.Size = new Size(217, 22);
            lblTrail.TabIndex = 1;
            lblTrail.Text = "0";
            lblTrail.UseMnemonic = false;
            // 
            // lblDateCaption
            // 
            lblDateCaption.AutoSize = true;
            lblDateCaption.BackColor = Color.Transparent;
            lblDateCaption.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblDateCaption.ForeColor = Color.FromArgb(51, 65, 85);
            lblDateCaption.Location = new Point(18, 132);
            lblDateCaption.Name = "lblDateCaption";
            lblDateCaption.Size = new Size(146, 13);
            lblDateCaption.TabIndex = 6;
            lblDateCaption.Text = "APPOINTMENT DATE & TIME";
            lblDateCaption.UseMnemonic = false;
            // 
            // tpAppointmentDate
            // 
            tpAppointmentDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tpAppointmentDate.BorderColor = Color.FromArgb(220, 230, 238);
            tpAppointmentDate.BorderRadius = 8;
            tpAppointmentDate.BorderThickness = 1;
            tpAppointmentDate.Checked = true;
            tpAppointmentDate.FillColor = Color.White;
            tpAppointmentDate.FocusedColor = Color.FromArgb(13, 148, 136);
            tpAppointmentDate.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            tpAppointmentDate.ForeColor = Color.FromArgb(15, 23, 42);
            tpAppointmentDate.Format = DateTimePickerFormat.Custom;
            tpAppointmentDate.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            tpAppointmentDate.HoverState.FillColor = Color.White;
            tpAppointmentDate.HoverState.ForeColor = Color.FromArgb(15, 23, 42);
            tpAppointmentDate.Location = new Point(18, 151);
            tpAppointmentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            tpAppointmentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            tpAppointmentDate.Name = "tpAppointmentDate";
            tpAppointmentDate.Size = new Size(491, 40);
            tpAppointmentDate.TabIndex = 7;
            tpAppointmentDate.Value = new DateTime(2026, 11, 17, 9, 0, 0, 0);
            // 
            // lblDateHint
            // 
            lblDateHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDateHint.BackColor = Color.Transparent;
            lblDateHint.Font = new Font("Segoe UI", 8.25F);
            lblDateHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblDateHint.Location = new Point(18, 197);
            lblDateHint.Name = "lblDateHint";
            lblDateHint.Size = new Size(491, 18);
            lblDateHint.TabIndex = 8;
            lblDateHint.Text = "Choose a future local date and time (automatically converted to UTC on save).";
            lblDateHint.UseMnemonic = false;
            // 
            // bookingNotePanel
            // 
            bookingNotePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookingNotePanel.BackColor = Color.Transparent;
            bookingNotePanel.BorderColor = Color.FromArgb(153, 246, 228);
            bookingNotePanel.BorderRadius = 8;
            bookingNotePanel.BorderThickness = 1;
            bookingNotePanel.Controls.Add(lblBookingNote);
            bookingNotePanel.CustomizableEdges = customizableEdges9;
            bookingNotePanel.FillColor = Color.FromArgb(240, 253, 250);
            bookingNotePanel.Location = new Point(18, 224);
            bookingNotePanel.Name = "bookingNotePanel";
            bookingNotePanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            bookingNotePanel.Size = new Size(491, 46);
            bookingNotePanel.TabIndex = 9;
            // 
            // lblBookingNote
            // 
            lblBookingNote.BackColor = Color.Transparent;
            lblBookingNote.Dock = DockStyle.Fill;
            lblBookingNote.Font = new Font("Segoe UI", 8.5F);
            lblBookingNote.ForeColor = Color.FromArgb(15, 118, 110);
            lblBookingNote.Location = new Point(0, 0);
            lblBookingNote.Name = "lblBookingNote";
            lblBookingNote.Padding = new Padding(12, 0, 12, 0);
            lblBookingNote.Size = new Size(491, 46);
            lblBookingNote.TabIndex = 0;
            lblBookingNote.Text = "Appointments can only be booked for future timestamps. Maximum 3 attempts allowed per test.";
            lblBookingNote.TextAlign = ContentAlignment.MiddleLeft;
            lblBookingNote.UseMnemonic = false;
            // 
            // pageActionFooter
            // 
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Dock = DockStyle.Fill;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Confirm the appointment date and examination fee before saving.";
            pageActionFooter.Location = new Point(16, 499);
            pageActionFooter.Margin = new Padding(0);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = true;
            pageActionFooter.PrimaryButtonText = "Save Appointment";
            pageActionFooter.SecondaryButtonText = "Cancel";
            pageActionFooter.ShowSecondaryButton = false;
            pageActionFooter.Size = new Size(971, 56);
            pageActionFooter.TabIndex = 3;
            // 
            // ScheduleTestControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "ScheduleTestControl";
            Size = new Size(1003, 637);
            pageLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            appointmentCard.ResumeLayout(false);
            appointmentCard.PerformLayout();
            feesBox.ResumeLayout(false);
            feesBox.PerformLayout();
            trialsBox.ResumeLayout(false);
            trialsBox.PerformLayout();
            bookingNotePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.ApplicantBannerControl applicantBanner;
        private TableLayoutPanel contentLayout;
        private Shared.Controls.ApplicationMetadataCardControl applicationMetadataCard;
        private Guna.UI2.WinForms.Guna2Panel appointmentCard;
        private Label lblBookingTag;
        private Label lblBookingTitle;
        private Guna.UI2.WinForms.Guna2Button lblTestName;
        private Panel bookingDivider;
        private Guna.UI2.WinForms.Guna2Panel feesBox;
        private Label lblFeesCaption;
        private Label lblFees;
        private Guna.UI2.WinForms.Guna2Panel trialsBox;
        private Label lblTrailCaption;
        private Label lblTrail;
        private Label lblDateCaption;
        private Guna.UI2.WinForms.Guna2DateTimePicker tpAppointmentDate;
        private Label lblDateHint;
        private Guna.UI2.WinForms.Guna2Panel bookingNotePanel;
        private Label lblBookingNote;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
