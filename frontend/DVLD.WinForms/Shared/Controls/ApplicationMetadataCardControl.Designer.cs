namespace DVLD.WinForms.Shared.Controls
{
    partial class ApplicationMetadataCardControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            cardPanel = new Guna.UI2.WinForms.Guna2Panel();
            lblSectionTag = new Label();
            lblCardTitle = new Label();
            statusPill = new Guna.UI2.WinForms.Guna2Button();
            headerDivider = new Panel();
            localIdBox = new Guna.UI2.WinForms.Guna2Panel();
            lblLocalIdCaption = new Label();
            lblLocalApplicationID = new Label();
            appIdBox = new Guna.UI2.WinForms.Guna2Panel();
            lblAppIdCaption = new Label();
            lblApplicationID = new Label();
            lblApplicationTypeCaption = new Label();
            lblApplicationType = new Label();
            lblFeesCaption = new Label();
            lblFees = new Label();
            lblAppDateCaption = new Label();
            lblApplicationDate = new Label();
            lblStatusDateCaption = new Label();
            lblStatusDate = new Label();
            lblCreatedByCaption = new Label();
            lblCreatedBy = new Label();
            classDivider = new Panel();
            lblLicenseClassCaption = new Label();
            cmbLicenseClass = new Guna.UI2.WinForms.Guna2ComboBox();
            cardPanel.SuspendLayout();
            localIdBox.SuspendLayout();
            appIdBox.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.Transparent;
            cardPanel.BorderColor = Color.FromArgb(220, 230, 238);
            cardPanel.BorderRadius = 12;
            cardPanel.BorderThickness = 1;
            cardPanel.Controls.Add(lblSectionTag);
            cardPanel.Controls.Add(lblCardTitle);
            cardPanel.Controls.Add(statusPill);
            cardPanel.Controls.Add(headerDivider);
            cardPanel.Controls.Add(localIdBox);
            cardPanel.Controls.Add(appIdBox);
            cardPanel.Controls.Add(lblApplicationTypeCaption);
            cardPanel.Controls.Add(lblApplicationType);
            cardPanel.Controls.Add(lblFeesCaption);
            cardPanel.Controls.Add(lblFees);
            cardPanel.Controls.Add(lblAppDateCaption);
            cardPanel.Controls.Add(lblApplicationDate);
            cardPanel.Controls.Add(lblStatusDateCaption);
            cardPanel.Controls.Add(lblStatusDate);
            cardPanel.Controls.Add(lblCreatedByCaption);
            cardPanel.Controls.Add(lblCreatedBy);
            cardPanel.Controls.Add(classDivider);
            cardPanel.Controls.Add(lblLicenseClassCaption);
            cardPanel.Controls.Add(cmbLicenseClass);
            cardPanel.CustomizableEdges = customizableEdges9;
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.FillColor = Color.White;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cardPanel.Size = new Size(430, 289);
            cardPanel.TabIndex = 0;
            // 
            // lblSectionTag
            // 
            lblSectionTag.AutoSize = true;
            lblSectionTag.BackColor = Color.Transparent;
            lblSectionTag.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblSectionTag.ForeColor = Color.FromArgb(13, 148, 136);
            lblSectionTag.Location = new Point(18, 12);
            lblSectionTag.Name = "lblSectionTag";
            lblSectionTag.Size = new Size(110, 12);
            lblSectionTag.TabIndex = 0;
            lblSectionTag.Text = "APPLICATION RECORD";
            lblSectionTag.UseMnemonic = false;
            // 
            // lblCardTitle
            // 
            lblCardTitle.AutoSize = true;
            lblCardTitle.BackColor = Color.Transparent;
            lblCardTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblCardTitle.Location = new Point(17, 27);
            lblCardTitle.Name = "lblCardTitle";
            lblCardTitle.Size = new Size(170, 20);
            lblCardTitle.TabIndex = 1;
            lblCardTitle.Text = "Service & Filing Details";
            lblCardTitle.UseMnemonic = false;
            // 
            // statusPill
            // 
            statusPill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusPill.BackColor = Color.Transparent;
            statusPill.BorderColor = Color.FromArgb(153, 246, 228);
            statusPill.BorderRadius = 13;
            statusPill.BorderThickness = 1;
            statusPill.CustomizableEdges = customizableEdges1;
            statusPill.FillColor = Color.FromArgb(240, 253, 250);
            statusPill.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            statusPill.ForeColor = Color.FromArgb(15, 118, 110);
            statusPill.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            statusPill.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            statusPill.HoverState.ForeColor = Color.FromArgb(15, 118, 110);
            statusPill.Location = new Point(312, 18);
            statusPill.Name = "statusPill";
            statusPill.PressedColor = Color.FromArgb(240, 253, 250);
            statusPill.ShadowDecoration.CustomizableEdges = customizableEdges2;
            statusPill.Size = new Size(100, 26);
            statusPill.TabIndex = 2;
            statusPill.TabStop = false;
            statusPill.Text = "● New";
            // 
            // headerDivider
            // 
            headerDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerDivider.BackColor = Color.FromArgb(226, 232, 240);
            headerDivider.Location = new Point(18, 56);
            headerDivider.Name = "headerDivider";
            headerDivider.Size = new Size(394, 1);
            headerDivider.TabIndex = 3;
            // 
            // localIdBox
            // 
            localIdBox.BackColor = Color.Transparent;
            localIdBox.BorderColor = Color.FromArgb(226, 232, 240);
            localIdBox.BorderRadius = 8;
            localIdBox.BorderThickness = 1;
            localIdBox.Controls.Add(lblLocalIdCaption);
            localIdBox.Controls.Add(lblLocalApplicationID);
            localIdBox.CustomizableEdges = customizableEdges3;
            localIdBox.FillColor = Color.FromArgb(248, 250, 252);
            localIdBox.Location = new Point(18, 66);
            localIdBox.Name = "localIdBox";
            localIdBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            localIdBox.Size = new Size(190, 48);
            localIdBox.TabIndex = 4;
            // 
            // lblLocalIdCaption
            // 
            lblLocalIdCaption.AutoSize = true;
            lblLocalIdCaption.BackColor = Color.Transparent;
            lblLocalIdCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblLocalIdCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblLocalIdCaption.Location = new Point(12, 6);
            lblLocalIdCaption.Name = "lblLocalIdCaption";
            lblLocalIdCaption.Size = new Size(71, 12);
            lblLocalIdCaption.TabIndex = 0;
            lblLocalIdCaption.Text = "LOCAL APP ID";
            lblLocalIdCaption.UseMnemonic = false;
            // 
            // lblLocalApplicationID
            // 
            lblLocalApplicationID.AutoEllipsis = true;
            lblLocalApplicationID.BackColor = Color.Transparent;
            lblLocalApplicationID.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblLocalApplicationID.ForeColor = Color.FromArgb(15, 23, 42);
            lblLocalApplicationID.Location = new Point(12, 22);
            lblLocalApplicationID.Name = "lblLocalApplicationID";
            lblLocalApplicationID.Size = new Size(166, 20);
            lblLocalApplicationID.TabIndex = 1;
            lblLocalApplicationID.Text = "#1042";
            lblLocalApplicationID.UseMnemonic = false;
            // 
            // appIdBox
            // 
            appIdBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            appIdBox.BackColor = Color.Transparent;
            appIdBox.BorderColor = Color.FromArgb(226, 232, 240);
            appIdBox.BorderRadius = 8;
            appIdBox.BorderThickness = 1;
            appIdBox.Controls.Add(lblAppIdCaption);
            appIdBox.Controls.Add(lblApplicationID);
            appIdBox.CustomizableEdges = customizableEdges5;
            appIdBox.FillColor = Color.FromArgb(248, 250, 252);
            appIdBox.Location = new Point(220, 66);
            appIdBox.Name = "appIdBox";
            appIdBox.ShadowDecoration.CustomizableEdges = customizableEdges6;
            appIdBox.Size = new Size(192, 48);
            appIdBox.TabIndex = 5;
            // 
            // lblAppIdCaption
            // 
            lblAppIdCaption.AutoSize = true;
            lblAppIdCaption.BackColor = Color.Transparent;
            lblAppIdCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblAppIdCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblAppIdCaption.Location = new Point(12, 6);
            lblAppIdCaption.Name = "lblAppIdCaption";
            lblAppIdCaption.Size = new Size(108, 12);
            lblAppIdCaption.TabIndex = 0;
            lblAppIdCaption.Text = "BASE APPLICATION ID";
            lblAppIdCaption.UseMnemonic = false;
            // 
            // lblApplicationID
            // 
            lblApplicationID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblApplicationID.AutoEllipsis = true;
            lblApplicationID.BackColor = Color.Transparent;
            lblApplicationID.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblApplicationID.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationID.Location = new Point(12, 22);
            lblApplicationID.Name = "lblApplicationID";
            lblApplicationID.Size = new Size(168, 20);
            lblApplicationID.TabIndex = 1;
            lblApplicationID.Text = "#884";
            lblApplicationID.UseMnemonic = false;
            // 
            // lblApplicationTypeCaption
            // 
            lblApplicationTypeCaption.AutoSize = true;
            lblApplicationTypeCaption.BackColor = Color.Transparent;
            lblApplicationTypeCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblApplicationTypeCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblApplicationTypeCaption.Location = new Point(18, 122);
            lblApplicationTypeCaption.Name = "lblApplicationTypeCaption";
            lblApplicationTypeCaption.Size = new Size(67, 12);
            lblApplicationTypeCaption.TabIndex = 6;
            lblApplicationTypeCaption.Text = "SERVICE TYPE";
            lblApplicationTypeCaption.UseMnemonic = false;
            // 
            // lblApplicationType
            // 
            lblApplicationType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblApplicationType.AutoEllipsis = true;
            lblApplicationType.BackColor = Color.Transparent;
            lblApplicationType.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            lblApplicationType.ForeColor = Color.FromArgb(15, 23, 42);
            lblApplicationType.Location = new Point(18, 138);
            lblApplicationType.Name = "lblApplicationType";
            lblApplicationType.Size = new Size(252, 20);
            lblApplicationType.TabIndex = 7;
            lblApplicationType.Text = "New Local Driving License Service";
            lblApplicationType.UseMnemonic = false;
            // 
            // lblFeesCaption
            // 
            lblFeesCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFeesCaption.AutoSize = true;
            lblFeesCaption.BackColor = Color.Transparent;
            lblFeesCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblFeesCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblFeesCaption.Location = new Point(280, 122);
            lblFeesCaption.Name = "lblFeesCaption";
            lblFeesCaption.Size = new Size(50, 12);
            lblFeesCaption.TabIndex = 8;
            lblFeesCaption.Text = "PAID FEES";
            lblFeesCaption.UseMnemonic = false;
            // 
            // lblFees
            // 
            lblFees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFees.AutoEllipsis = true;
            lblFees.BackColor = Color.Transparent;
            lblFees.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblFees.ForeColor = Color.FromArgb(21, 128, 61);
            lblFees.Location = new Point(280, 138);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(132, 20);
            lblFees.TabIndex = 9;
            lblFees.Text = "$15.00";
            lblFees.UseMnemonic = false;
            // 
            // lblAppDateCaption
            // 
            lblAppDateCaption.AutoSize = true;
            lblAppDateCaption.BackColor = Color.Transparent;
            lblAppDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblAppDateCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblAppDateCaption.Location = new Point(18, 166);
            lblAppDateCaption.Name = "lblAppDateCaption";
            lblAppDateCaption.Size = new Size(63, 12);
            lblAppDateCaption.TabIndex = 10;
            lblAppDateCaption.Text = "APPLIED ON";
            lblAppDateCaption.UseMnemonic = false;
            // 
            // lblApplicationDate
            // 
            lblApplicationDate.AutoEllipsis = true;
            lblApplicationDate.BackColor = Color.Transparent;
            lblApplicationDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblApplicationDate.ForeColor = Color.FromArgb(51, 65, 85);
            lblApplicationDate.Location = new Point(18, 182);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(118, 18);
            lblApplicationDate.TabIndex = 11;
            lblApplicationDate.Text = "14 Nov 2026";
            lblApplicationDate.UseMnemonic = false;
            // 
            // lblStatusDateCaption
            // 
            lblStatusDateCaption.AutoSize = true;
            lblStatusDateCaption.BackColor = Color.Transparent;
            lblStatusDateCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblStatusDateCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblStatusDateCaption.Location = new Point(148, 166);
            lblStatusDateCaption.Name = "lblStatusDateCaption";
            lblStatusDateCaption.Size = new Size(66, 12);
            lblStatusDateCaption.TabIndex = 12;
            lblStatusDateCaption.Text = "STATUS DATE";
            lblStatusDateCaption.UseMnemonic = false;
            // 
            // lblStatusDate
            // 
            lblStatusDate.AutoEllipsis = true;
            lblStatusDate.BackColor = Color.Transparent;
            lblStatusDate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblStatusDate.ForeColor = Color.FromArgb(51, 65, 85);
            lblStatusDate.Location = new Point(148, 182);
            lblStatusDate.Name = "lblStatusDate";
            lblStatusDate.Size = new Size(118, 18);
            lblStatusDate.TabIndex = 13;
            lblStatusDate.Text = "14 Nov 2026";
            lblStatusDate.UseMnemonic = false;
            // 
            // lblCreatedByCaption
            // 
            lblCreatedByCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCreatedByCaption.AutoSize = true;
            lblCreatedByCaption.BackColor = Color.Transparent;
            lblCreatedByCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblCreatedByCaption.ForeColor = Color.FromArgb(148, 163, 184);
            lblCreatedByCaption.Location = new Point(280, 166);
            lblCreatedByCaption.Name = "lblCreatedByCaption";
            lblCreatedByCaption.Size = new Size(61, 12);
            lblCreatedByCaption.TabIndex = 14;
            lblCreatedByCaption.Text = "CREATED BY";
            lblCreatedByCaption.UseMnemonic = false;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCreatedBy.AutoEllipsis = true;
            lblCreatedBy.BackColor = Color.Transparent;
            lblCreatedBy.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCreatedBy.ForeColor = Color.FromArgb(51, 65, 85);
            lblCreatedBy.Location = new Point(280, 182);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(132, 18);
            lblCreatedBy.TabIndex = 15;
            lblCreatedBy.Text = "Adam Admin";
            lblCreatedBy.UseMnemonic = false;
            // 
            // classDivider
            // 
            classDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            classDivider.BackColor = Color.FromArgb(226, 232, 240);
            classDivider.Location = new Point(18, 209);
            classDivider.Name = "classDivider";
            classDivider.Size = new Size(394, 1);
            classDivider.TabIndex = 16;
            // 
            // lblLicenseClassCaption
            // 
            lblLicenseClassCaption.AutoSize = true;
            lblLicenseClassCaption.BackColor = Color.Transparent;
            lblLicenseClassCaption.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            lblLicenseClassCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblLicenseClassCaption.Location = new Point(18, 217);
            lblLicenseClassCaption.Name = "lblLicenseClassCaption";
            lblLicenseClassCaption.Size = new Size(115, 12);
            lblLicenseClassCaption.TabIndex = 17;
            lblLicenseClassCaption.Text = "APPLIED LICENSE CLASS";
            lblLicenseClassCaption.UseMnemonic = false;
            // 
            // cmbLicenseClass
            // 
            cmbLicenseClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbLicenseClass.BackColor = Color.Transparent;
            cmbLicenseClass.BorderColor = Color.FromArgb(219, 229, 242);
            cmbLicenseClass.BorderRadius = 6;
            cmbLicenseClass.CustomizableEdges = customizableEdges7;
            cmbLicenseClass.DisabledState.BorderColor = Color.FromArgb(219, 229, 242);
            cmbLicenseClass.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            cmbLicenseClass.DisabledState.ForeColor = Color.FromArgb(51, 65, 85);
            cmbLicenseClass.DrawMode = DrawMode.OwnerDrawFixed;
            cmbLicenseClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLicenseClass.Enabled = false;
            cmbLicenseClass.FocusedColor = Color.FromArgb(13, 148, 136);
            cmbLicenseClass.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            cmbLicenseClass.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cmbLicenseClass.ForeColor = Color.FromArgb(15, 23, 42);
            cmbLicenseClass.ItemHeight = 30;
            cmbLicenseClass.Location = new Point(18, 235);
            cmbLicenseClass.Name = "cmbLicenseClass";
            cmbLicenseClass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbLicenseClass.Size = new Size(394, 36);
            cmbLicenseClass.TabIndex = 18;
            // 
            // ApplicationMetadataCardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cardPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(380, 289);
            Name = "ApplicationMetadataCardControl";
            Size = new Size(430, 289);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            localIdBox.ResumeLayout(false);
            localIdBox.PerformLayout();
            appIdBox.ResumeLayout(false);
            appIdBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel cardPanel;
        private Label lblSectionTag;
        private Label lblCardTitle;
        private Guna.UI2.WinForms.Guna2Button statusPill;
        private Panel headerDivider;
        private Guna.UI2.WinForms.Guna2Panel localIdBox;
        private Label lblLocalIdCaption;
        private Label lblLocalApplicationID;
        private Guna.UI2.WinForms.Guna2Panel appIdBox;
        private Label lblAppIdCaption;
        private Label lblApplicationID;
        private Label lblApplicationTypeCaption;
        private Label lblApplicationType;
        private Label lblFeesCaption;
        private Label lblFees;
        private Label lblAppDateCaption;
        private Label lblApplicationDate;
        private Label lblStatusDateCaption;
        private Label lblStatusDate;
        private Label lblCreatedByCaption;
        private Label lblCreatedBy;
        private Panel classDivider;
        private Label lblLicenseClassCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLicenseClass;
    }
}
