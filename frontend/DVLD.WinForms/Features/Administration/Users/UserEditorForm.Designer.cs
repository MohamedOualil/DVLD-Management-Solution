namespace DVLD.WinForms.Features.Administration.Users
{
    partial class UserEditorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            formElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            formShadow = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            formDrag = new Guna.UI2.WinForms.Guna2DragControl(components);
            topAccentBar = new Panel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            formCard = new Guna.UI2.WinForms.Guna2Panel();
            lblPersonLookup = new Label();
            txtPersonLookup = new Guna.UI2.WinForms.Guna2TextBox();
            btnFindPerson = new Guna.UI2.WinForms.Guna2Button();
            personSummaryBox = new Guna.UI2.WinForms.Guna2Panel();
            lblPersonName = new Label();
            lblPersonMeta = new Label();
            lblUsername = new Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            lblRole = new Label();
            cmbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            lblAccountStatus = new Label();
            chkIsActive = new CheckBox();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();

            formCard.SuspendLayout();
            personSummaryBox.SuspendLayout();
            SuspendLayout();

            // 
            // formElipse
            // 
            formElipse.BorderRadius = 14;
            formElipse.TargetControl = this;

            // 
            // formShadow
            // 
            formShadow.TargetForm = this;

            // 
            // formDrag
            // 
            formDrag.DockIndicatorTransparencyValue = 0.6D;
            formDrag.TargetControl = pageHeader;
            formDrag.UseTransparentDrag = true;

            // 
            // topAccentBar
            // 
            topAccentBar.BackColor = Color.FromArgb(13, 148, 136);
            topAccentBar.Dock = DockStyle.Top;
            topAccentBar.Location = new Point(0, 0);
            topAccentBar.Name = "topAccentBar";
            topAccentBar.Size = new Size(680, 4);
            topAccentBar.TabIndex = 4;

            // 
            // pageHeader
            // 
            pageHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BackButtonText = "✕ Close";
            pageHeader.BadgeText = "● New User";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "US";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = true;
            pageHeader.Size = new Size(648, 68);
            pageHeader.Subtitle = "Link an existing citizen record to a system employee account";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Create Employee User";

            // 
            // statusBanner
            // 
            statusBanner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Search by Person ID or National No, then configure login credentials and role.";
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(16, 92);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(648, 58);
            statusBanner.TabIndex = 1;
            statusBanner.Title = "Account Configuration";
            statusBanner.Tone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;

            // 
            // formCard
            // 
            formCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            formCard.BackColor = Color.Transparent;
            formCard.BorderColor = Color.FromArgb(220, 230, 238);
            formCard.BorderRadius = 12;
            formCard.BorderThickness = 1;
            formCard.Controls.Add(lblPersonLookup);
            formCard.Controls.Add(txtPersonLookup);
            formCard.Controls.Add(btnFindPerson);
            formCard.Controls.Add(personSummaryBox);
            formCard.Controls.Add(lblUsername);
            formCard.Controls.Add(txtUsername);
            formCard.Controls.Add(lblRole);
            formCard.Controls.Add(cmbRole);
            formCard.Controls.Add(lblAccountStatus);
            formCard.Controls.Add(chkIsActive);
            formCard.Controls.Add(lblCurrentPassword);
            formCard.Controls.Add(txtCurrentPassword);
            formCard.Controls.Add(lblPassword);
            formCard.Controls.Add(txtPassword);
            formCard.Controls.Add(lblConfirmPassword);
            formCard.Controls.Add(txtConfirmPassword);
            formCard.CustomizableEdges = customizableEdges1;
            formCard.FillColor = Color.White;
            formCard.Location = new Point(16, 160);
            formCard.Name = "formCard";
            formCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            formCard.Size = new Size(648, 342);
            formCard.TabIndex = 2;

            // 
            // lblPersonLookup
            // 
            lblPersonLookup.AutoSize = true;
            lblPersonLookup.BackColor = Color.Transparent;
            lblPersonLookup.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblPersonLookup.ForeColor = Color.FromArgb(100, 116, 139);
            lblPersonLookup.Location = new Point(20, 16);
            lblPersonLookup.Name = "lblPersonLookup";
            lblPersonLookup.Size = new Size(216, 13);
            lblPersonLookup.TabIndex = 0;
            lblPersonLookup.Text = "LINK CITIZEN (PERSON ID OR NATIONAL NO) *";
            lblPersonLookup.UseMnemonic = false;

            // 
            // txtPersonLookup
            // 
            txtPersonLookup.BorderColor = Color.FromArgb(218, 226, 236);
            txtPersonLookup.BorderRadius = 8;
            txtPersonLookup.Cursor = Cursors.IBeam;
            txtPersonLookup.CustomizableEdges = customizableEdges3;
            txtPersonLookup.DefaultText = "";
            txtPersonLookup.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtPersonLookup.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtPersonLookup.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtPersonLookup.FillColor = Color.FromArgb(248, 250, 252);
            txtPersonLookup.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtPersonLookup.FocusedState.FillColor = Color.White;
            txtPersonLookup.Font = new Font("Segoe UI", 9F);
            txtPersonLookup.ForeColor = Color.FromArgb(15, 23, 42);
            txtPersonLookup.Location = new Point(20, 34);
            txtPersonLookup.Name = "txtPersonLookup";
            txtPersonLookup.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPersonLookup.PlaceholderText = "e.g. 12 or N-1045";
            txtPersonLookup.SelectedText = "";
            txtPersonLookup.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPersonLookup.Size = new Size(210, 36);
            txtPersonLookup.TabIndex = 1;

            // 
            // btnFindPerson
            // 
            btnFindPerson.BorderColor = Color.FromArgb(153, 246, 228);
            btnFindPerson.BorderRadius = 8;
            btnFindPerson.BorderThickness = 1;
            btnFindPerson.Cursor = Cursors.Hand;
            btnFindPerson.CustomizableEdges = customizableEdges5;
            btnFindPerson.FillColor = Color.FromArgb(240, 253, 250);
            btnFindPerson.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            btnFindPerson.ForeColor = Color.FromArgb(13, 148, 136);
            btnFindPerson.Location = new Point(238, 34);
            btnFindPerson.Name = "btnFindPerson";
            btnFindPerson.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnFindPerson.Size = new Size(112, 36);
            btnFindPerson.TabIndex = 2;
            btnFindPerson.Text = "Find Citizen";

            // 
            // personSummaryBox
            // 
            personSummaryBox.BackColor = Color.Transparent;
            personSummaryBox.BorderColor = Color.FromArgb(226, 232, 240);
            personSummaryBox.BorderRadius = 8;
            personSummaryBox.BorderThickness = 1;
            personSummaryBox.Controls.Add(lblPersonName);
            personSummaryBox.Controls.Add(lblPersonMeta);
            personSummaryBox.CustomizableEdges = customizableEdges7;
            personSummaryBox.FillColor = Color.FromArgb(248, 250, 252);
            personSummaryBox.Location = new Point(362, 24);
            personSummaryBox.Name = "personSummaryBox";
            personSummaryBox.ShadowDecoration.CustomizableEdges = customizableEdges8;
            personSummaryBox.Size = new Size(266, 50);
            personSummaryBox.TabIndex = 3;

            // 
            // lblPersonName
            // 
            lblPersonName.AutoEllipsis = true;
            lblPersonName.BackColor = Color.Transparent;
            lblPersonName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPersonName.ForeColor = Color.FromArgb(15, 23, 42);
            lblPersonName.Location = new Point(12, 7);
            lblPersonName.Name = "lblPersonName";
            lblPersonName.Size = new Size(242, 18);
            lblPersonName.TabIndex = 0;
            lblPersonName.Text = "No citizen linked yet";
            lblPersonName.UseMnemonic = false;

            // 
            // lblPersonMeta
            // 
            lblPersonMeta.AutoEllipsis = true;
            lblPersonMeta.BackColor = Color.Transparent;
            lblPersonMeta.Font = new Font("Segoe UI", 8F);
            lblPersonMeta.ForeColor = Color.FromArgb(100, 116, 139);
            lblPersonMeta.Location = new Point(12, 26);
            lblPersonMeta.Name = "lblPersonMeta";
            lblPersonMeta.Size = new Size(242, 16);
            lblPersonMeta.TabIndex = 1;
            lblPersonMeta.Text = "Enter Person ID or National No and click Find Citizen";
            lblPersonMeta.UseMnemonic = false;

            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(100, 116, 139);
            lblUsername.Location = new Point(20, 92);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(64, 13);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "USERNAME *";
            lblUsername.UseMnemonic = false;

            // 
            // txtUsername
            // 
            txtUsername.BorderColor = Color.FromArgb(218, 226, 236);
            txtUsername.BorderRadius = 8;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.CustomizableEdges = customizableEdges9;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtUsername.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(100, 116, 139);
            txtUsername.FillColor = Color.FromArgb(248, 250, 252);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtUsername.FocusedState.FillColor = Color.White;
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(20, 110);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtUsername.PlaceholderText = "e.g. a.khalid";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtUsername.Size = new Size(220, 36);
            txtUsername.TabIndex = 5;

            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.BackColor = Color.Transparent;
            lblRole.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(100, 116, 139);
            lblRole.Location = new Point(256, 92);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(80, 13);
            lblRole.TabIndex = 6;
            lblRole.Text = "SYSTEM ROLE *";
            lblRole.UseMnemonic = false;

            // 
            // cmbRole
            // 
            cmbRole.BackColor = Color.Transparent;
            cmbRole.BorderColor = Color.FromArgb(218, 226, 236);
            cmbRole.BorderRadius = 8;
            cmbRole.CustomizableEdges = customizableEdges11;
            cmbRole.DrawMode = DrawMode.OwnerDrawFixed;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FillColor = Color.FromArgb(248, 250, 252);
            cmbRole.FocusedColor = Color.FromArgb(13, 148, 136);
            cmbRole.Font = new Font("Segoe UI", 9F);
            cmbRole.ForeColor = Color.FromArgb(15, 23, 42);
            cmbRole.ItemHeight = 30;
            cmbRole.Location = new Point(256, 110);
            cmbRole.Name = "cmbRole";
            cmbRole.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbRole.Size = new Size(156, 36);
            cmbRole.TabIndex = 7;

            // 
            // lblAccountStatus
            // 
            lblAccountStatus.AutoSize = true;
            lblAccountStatus.BackColor = Color.Transparent;
            lblAccountStatus.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblAccountStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblAccountStatus.Location = new Point(428, 92);
            lblAccountStatus.Name = "lblAccountStatus";
            lblAccountStatus.Size = new Size(92, 13);
            lblAccountStatus.TabIndex = 8;
            lblAccountStatus.Text = "ACCOUNT STATUS";
            lblAccountStatus.UseMnemonic = false;

            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.BackColor = Color.Transparent;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            chkIsActive.ForeColor = Color.FromArgb(15, 23, 42);
            chkIsActive.Location = new Point(428, 118);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(176, 19);
            chkIsActive.TabIndex = 9;
            chkIsActive.Text = "Active — Allow Sign-In";
            chkIsActive.UseVisualStyleBackColor = true;

            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.BackColor = Color.Transparent;
            lblCurrentPassword.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblCurrentPassword.ForeColor = Color.FromArgb(100, 116, 139);
            lblCurrentPassword.Location = new Point(20, 166);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(116, 13);
            lblCurrentPassword.TabIndex = 10;
            lblCurrentPassword.Text = "CURRENT PASSWORD *";
            lblCurrentPassword.UseMnemonic = false;

            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.BorderColor = Color.FromArgb(218, 226, 236);
            txtCurrentPassword.BorderRadius = 8;
            txtCurrentPassword.Cursor = Cursors.IBeam;
            txtCurrentPassword.CustomizableEdges = customizableEdges13;
            txtCurrentPassword.DefaultText = "";
            txtCurrentPassword.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtCurrentPassword.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtCurrentPassword.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtCurrentPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtCurrentPassword.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtCurrentPassword.FocusedState.FillColor = Color.White;
            txtCurrentPassword.Font = new Font("Segoe UI", 9F);
            txtCurrentPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtCurrentPassword.Location = new Point(20, 184);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '●';
            txtCurrentPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtCurrentPassword.PlaceholderText = "Enter current password";
            txtCurrentPassword.SelectedText = "";
            txtCurrentPassword.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtCurrentPassword.Size = new Size(608, 36);
            txtCurrentPassword.TabIndex = 11;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(100, 116, 139);
            lblPassword.Location = new Point(20, 236);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 13);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "NEW PASSWORD *";
            lblPassword.UseMnemonic = false;

            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(218, 226, 236);
            txtPassword.BorderRadius = 8;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.CustomizableEdges = customizableEdges15;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtPassword.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtPassword.FocusedState.FillColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.Location = new Point(20, 254);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "At least 6 characters";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtPassword.Size = new Size(296, 36);
            txtPassword.TabIndex = 13;

            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(100, 116, 139);
            lblConfirmPassword.Location = new Point(332, 236);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(116, 13);
            lblConfirmPassword.TabIndex = 14;
            lblConfirmPassword.Text = "CONFIRM PASSWORD *";
            lblConfirmPassword.UseMnemonic = false;

            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderColor = Color.FromArgb(218, 226, 236);
            txtConfirmPassword.BorderRadius = 8;
            txtConfirmPassword.Cursor = Cursors.IBeam;
            txtConfirmPassword.DefaultText = "";
            txtConfirmPassword.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtConfirmPassword.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtConfirmPassword.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtConfirmPassword.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtConfirmPassword.FocusedState.FillColor = Color.White;
            txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtConfirmPassword.Location = new Point(332, 254);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.PlaceholderText = "Re-enter password";
            txtConfirmPassword.SelectedText = "";
            txtConfirmPassword.Size = new Size(296, 36);
            txtConfirmPassword.TabIndex = 15;

            // 
            // pageActionFooter
            // 
            pageActionFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Confirm employee role and credentials before saving.";
            pageActionFooter.Location = new Point(16, 510);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = true;
            pageActionFooter.PrimaryButtonText = "Save User";
            pageActionFooter.SecondaryButtonText = "Cancel";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(648, 56);
            pageActionFooter.TabIndex = 3;

            // 
            // UserEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            ClientSize = new Size(680, 580);
            Controls.Add(topAccentBar);
            Controls.Add(pageHeader);
            Controls.Add(statusBanner);
            Controls.Add(formCard);
            Controls.Add(pageActionFooter);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditorForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Employee User Editor";
            formCard.ResumeLayout(false);
            formCard.PerformLayout();
            personSummaryBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse formElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm formShadow;
        private Guna.UI2.WinForms.Guna2DragControl formDrag;
        private Panel topAccentBar;
        private DVLD.WinForms.Shared.Controls.PageHeaderControl pageHeader;
        private DVLD.WinForms.Shared.Controls.StatusBannerControl statusBanner;
        private Guna.UI2.WinForms.Guna2Panel formCard;
        private Label lblPersonLookup;
        private Guna.UI2.WinForms.Guna2TextBox txtPersonLookup;
        private Guna.UI2.WinForms.Guna2Button btnFindPerson;
        private Guna.UI2.WinForms.Guna2Panel personSummaryBox;
        private Label lblPersonName;
        private Label lblPersonMeta;
        private Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Label lblRole;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRole;
        private Label lblAccountStatus;
        private CheckBox chkIsActive;
        private Label lblCurrentPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentPassword;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Label lblConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private DVLD.WinForms.Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
