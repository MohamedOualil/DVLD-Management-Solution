namespace DVLD.WinForms.Features.Persons.ManagePeople
{
    partial class PersonEditorForm
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
            formElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            formShadow = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            formDrag = new Guna.UI2.WinForms.Guna2DragControl(components);
            topAccentBar = new Panel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            formCard = new Guna.UI2.WinForms.Guna2Panel();
            photoFrame = new Guna.UI2.WinForms.Guna2Panel();
            pbPhoto = new PictureBox();
            btnSelectPhoto = new Guna.UI2.WinForms.Guna2Button();
            lblFirstName = new Label();
            txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            lblSecondName = new Label();
            txtSecondName = new Guna.UI2.WinForms.Guna2TextBox();
            lblThirdName = new Label();
            txtThirdName = new Guna.UI2.WinForms.Guna2TextBox();
            lblLastName = new Label();
            txtLastName = new Guna.UI2.WinForms.Guna2TextBox();
            lblNationalNo = new Label();
            txtNationalNo = new Guna.UI2.WinForms.Guna2TextBox();
            lblDob = new Label();
            dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblGender = new Label();
            cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            lblPhone = new Label();
            txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblCity = new Label();
            txtCity = new Guna.UI2.WinForms.Guna2TextBox();
            lblStreet = new Label();
            txtStreet = new Guna.UI2.WinForms.Guna2TextBox();
            pageActionFooter = new DVLD.WinForms.Shared.Controls.PageActionFooterControl();
            formCard.SuspendLayout();
            photoFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
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
            topAccentBar.Size = new Size(750, 4);
            topAccentBar.TabIndex = 3;
            // 
            // pageHeader
            // 
            pageHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BackButtonText = "✕ Close";
            pageHeader.BadgeText = "● New Person";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "PR";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = true;
            pageHeader.Size = new Size(718, 68);
            pageHeader.Subtitle = "Enter citizen identity, contact, and address details";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "Register New Person";
            // 
            // formCard
            // 
            formCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            formCard.BackColor = Color.Transparent;
            formCard.BorderColor = Color.FromArgb(220, 230, 238);
            formCard.BorderRadius = 12;
            formCard.BorderThickness = 1;
            formCard.Controls.Add(photoFrame);
            formCard.Controls.Add(btnSelectPhoto);
            formCard.Controls.Add(lblFirstName);
            formCard.Controls.Add(txtFirstName);
            formCard.Controls.Add(lblSecondName);
            formCard.Controls.Add(txtSecondName);
            formCard.Controls.Add(lblThirdName);
            formCard.Controls.Add(txtThirdName);
            formCard.Controls.Add(lblLastName);
            formCard.Controls.Add(txtLastName);
            formCard.Controls.Add(lblNationalNo);
            formCard.Controls.Add(txtNationalNo);
            formCard.Controls.Add(lblDob);
            formCard.Controls.Add(dtpDateOfBirth);
            formCard.Controls.Add(lblGender);
            formCard.Controls.Add(cmbGender);
            formCard.Controls.Add(lblPhone);
            formCard.Controls.Add(txtPhone);
            formCard.Controls.Add(lblEmail);
            formCard.Controls.Add(txtEmail);
            formCard.Controls.Add(lblCity);
            formCard.Controls.Add(txtCity);
            formCard.Controls.Add(lblStreet);
            formCard.Controls.Add(txtStreet);
            formCard.CustomizableEdges = customizableEdges1;
            formCard.FillColor = Color.White;
            formCard.Location = new Point(16, 94);
            formCard.Name = "formCard";
            formCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            formCard.Size = new Size(718, 362);
            formCard.TabIndex = 1;
            // 
            // photoFrame
            // 
            photoFrame.BorderColor = Color.FromArgb(226, 232, 240);
            photoFrame.BorderRadius = 10;
            photoFrame.BorderThickness = 1;
            photoFrame.Controls.Add(pbPhoto);
            photoFrame.FillColor = Color.FromArgb(248, 250, 252);
            photoFrame.Location = new Point(18, 18);
            photoFrame.Name = "photoFrame";
            photoFrame.Padding = new Padding(4);
            photoFrame.Size = new Size(124, 146);
            photoFrame.TabIndex = 0;
            // 
            // pbPhoto
            // 
            pbPhoto.BackColor = Color.Transparent;
            pbPhoto.Dock = DockStyle.Fill;
            pbPhoto.Image = Properties.Resources.DefaultAvatar;
            pbPhoto.Location = new Point(4, 4);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(116, 138);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;
            // 
            // btnSelectPhoto
            // 
            btnSelectPhoto.BorderColor = Color.FromArgb(153, 246, 228);
            btnSelectPhoto.BorderRadius = 8;
            btnSelectPhoto.BorderThickness = 1;
            btnSelectPhoto.Cursor = Cursors.Hand;
            btnSelectPhoto.CustomizableEdges = customizableEdges3;
            btnSelectPhoto.FillColor = Color.FromArgb(240, 253, 250);
            btnSelectPhoto.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnSelectPhoto.ForeColor = Color.FromArgb(13, 148, 136);
            btnSelectPhoto.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            btnSelectPhoto.HoverState.FillColor = Color.FromArgb(204, 251, 241);
            btnSelectPhoto.HoverState.ForeColor = Color.FromArgb(15, 118, 110);
            btnSelectPhoto.Location = new Point(18, 172);
            btnSelectPhoto.Name = "btnSelectPhoto";
            btnSelectPhoto.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSelectPhoto.Size = new Size(124, 34);
            btnSelectPhoto.TabIndex = 1;
            btnSelectPhoto.Text = "Choose Photo";
            // 
            // Row 1: First / Second / Third / Last Name (x=160..700)
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(71, 85, 105);
            lblFirstName.Location = new Point(160, 18);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Text = "FIRST NAME *";
            lblFirstName.UseMnemonic = false;

            txtFirstName.BorderColor = Color.FromArgb(220, 230, 238);
            txtFirstName.BorderRadius = 7;
            txtFirstName.FillColor = Color.FromArgb(248, 250, 252);
            txtFirstName.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtFirstName.FocusedState.FillColor = Color.White;
            txtFirstName.Font = new Font("Segoe UI", 9F);
            txtFirstName.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtFirstName.Location = new Point(160, 35);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First";
            txtFirstName.Size = new Size(128, 36);
            txtFirstName.TabIndex = 2;

            lblSecondName.AutoSize = true;
            lblSecondName.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblSecondName.ForeColor = Color.FromArgb(71, 85, 105);
            lblSecondName.Location = new Point(298, 18);
            lblSecondName.Name = "lblSecondName";
            lblSecondName.Text = "SECOND NAME";
            lblSecondName.UseMnemonic = false;

            txtSecondName.BorderColor = Color.FromArgb(220, 230, 238);
            txtSecondName.BorderRadius = 7;
            txtSecondName.FillColor = Color.FromArgb(248, 250, 252);
            txtSecondName.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtSecondName.FocusedState.FillColor = Color.White;
            txtSecondName.Font = new Font("Segoe UI", 9F);
            txtSecondName.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtSecondName.Location = new Point(298, 35);
            txtSecondName.Name = "txtSecondName";
            txtSecondName.PlaceholderText = "Optional";
            txtSecondName.Size = new Size(128, 36);
            txtSecondName.TabIndex = 3;

            lblThirdName.AutoSize = true;
            lblThirdName.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblThirdName.ForeColor = Color.FromArgb(71, 85, 105);
            lblThirdName.Location = new Point(436, 18);
            lblThirdName.Name = "lblThirdName";
            lblThirdName.Text = "THIRD NAME";
            lblThirdName.UseMnemonic = false;

            txtThirdName.BorderColor = Color.FromArgb(220, 230, 238);
            txtThirdName.BorderRadius = 7;
            txtThirdName.FillColor = Color.FromArgb(248, 250, 252);
            txtThirdName.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtThirdName.FocusedState.FillColor = Color.White;
            txtThirdName.Font = new Font("Segoe UI", 9F);
            txtThirdName.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtThirdName.Location = new Point(436, 35);
            txtThirdName.Name = "txtThirdName";
            txtThirdName.PlaceholderText = "Optional";
            txtThirdName.Size = new Size(124, 36);
            txtThirdName.TabIndex = 4;

            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(71, 85, 105);
            lblLastName.Location = new Point(570, 18);
            lblLastName.Name = "lblLastName";
            lblLastName.Text = "LAST NAME *";
            lblLastName.UseMnemonic = false;

            txtLastName.BorderColor = Color.FromArgb(220, 230, 238);
            txtLastName.BorderRadius = 7;
            txtLastName.FillColor = Color.FromArgb(248, 250, 252);
            txtLastName.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtLastName.FocusedState.FillColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 9F);
            txtLastName.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtLastName.Location = new Point(570, 35);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last";
            txtLastName.Size = new Size(130, 36);
            txtLastName.TabIndex = 5;

            // 
            // Row 2: National No / Date of Birth / Gender
            // 
            lblNationalNo.AutoSize = true;
            lblNationalNo.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblNationalNo.ForeColor = Color.FromArgb(71, 85, 105);
            lblNationalNo.Location = new Point(160, 84);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Text = "NATIONAL NO *";
            lblNationalNo.UseMnemonic = false;

            txtNationalNo.BorderColor = Color.FromArgb(220, 230, 238);
            txtNationalNo.BorderRadius = 7;
            txtNationalNo.FillColor = Color.FromArgb(248, 250, 252);
            txtNationalNo.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtNationalNo.FocusedState.FillColor = Color.White;
            txtNationalNo.Font = new Font("Segoe UI", 9F);
            txtNationalNo.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtNationalNo.Location = new Point(160, 101);
            txtNationalNo.Name = "txtNationalNo";
            txtNationalNo.PlaceholderText = "e.g., 9921045231";
            txtNationalNo.Size = new Size(180, 36);
            txtNationalNo.TabIndex = 6;

            lblDob.AutoSize = true;
            lblDob.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblDob.ForeColor = Color.FromArgb(71, 85, 105);
            lblDob.Location = new Point(352, 84);
            lblDob.Name = "lblDob";
            lblDob.Text = "DATE OF BIRTH *";
            lblDob.UseMnemonic = false;

            dtpDateOfBirth.BorderColor = Color.FromArgb(220, 230, 238);
            dtpDateOfBirth.BorderRadius = 7;
            dtpDateOfBirth.BorderThickness = 1;
            dtpDateOfBirth.Checked = true;
            dtpDateOfBirth.FillColor = Color.FromArgb(248, 250, 252);
            dtpDateOfBirth.FocusedColor = Color.FromArgb(13, 148, 136);
            dtpDateOfBirth.Font = new Font("Segoe UI", 9F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            dtpDateOfBirth.Location = new Point(352, 101);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(180, 36);
            dtpDateOfBirth.TabIndex = 7;
            dtpDateOfBirth.Value = new DateTime(1995, 1, 1, 0, 0, 0, 0);

            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(71, 85, 105);
            lblGender.Location = new Point(544, 84);
            lblGender.Name = "lblGender";
            lblGender.Text = "GENDER *";
            lblGender.UseMnemonic = false;

            cmbGender.BorderColor = Color.FromArgb(220, 230, 238);
            cmbGender.BorderRadius = 7;
            cmbGender.DrawMode = DrawMode.OwnerDrawFixed;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FillColor = Color.FromArgb(248, 250, 252);
            cmbGender.FocusedColor = Color.FromArgb(13, 148, 136);
            cmbGender.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            cmbGender.Font = new Font("Segoe UI", 9F);
            cmbGender.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            cmbGender.ItemHeight = 30;
            cmbGender.Location = new Point(544, 101);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(156, 36);
            cmbGender.TabIndex = 8;

            // 
            // Row 3: Phone / Email
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhone.Location = new Point(160, 150);
            lblPhone.Name = "lblPhone";
            lblPhone.Text = "PHONE NUMBER *";
            lblPhone.UseMnemonic = false;

            txtPhone.BorderColor = Color.FromArgb(220, 230, 238);
            txtPhone.BorderRadius = 7;
            txtPhone.FillColor = Color.FromArgb(248, 250, 252);
            txtPhone.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtPhone.FocusedState.FillColor = Color.White;
            txtPhone.Font = new Font("Segoe UI", 9F);
            txtPhone.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtPhone.Location = new Point(160, 167);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "+962 79 ...";
            txtPhone.Size = new Size(256, 36);
            txtPhone.TabIndex = 9;

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(428, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "EMAIL ADDRESS";
            lblEmail.UseMnemonic = false;

            txtEmail.BorderColor = Color.FromArgb(220, 230, 238);
            txtEmail.BorderRadius = 7;
            txtEmail.FillColor = Color.FromArgb(248, 250, 252);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtEmail.FocusedState.FillColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtEmail.Location = new Point(428, 167);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "name@example.com";
            txtEmail.Size = new Size(272, 36);
            txtEmail.TabIndex = 10;

            // 
            // Row 4: City / Street
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblCity.ForeColor = Color.FromArgb(71, 85, 105);
            lblCity.Location = new Point(160, 220);
            lblCity.Name = "lblCity";
            lblCity.Text = "CITY";
            lblCity.UseMnemonic = false;

            txtCity.BorderColor = Color.FromArgb(220, 230, 238);
            txtCity.BorderRadius = 7;
            txtCity.FillColor = Color.FromArgb(248, 250, 252);
            txtCity.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtCity.FocusedState.FillColor = Color.White;
            txtCity.Font = new Font("Segoe UI", 9F);
            txtCity.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtCity.Location = new Point(160, 237);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "City / District";
            txtCity.Size = new Size(220, 36);
            txtCity.TabIndex = 11;

            lblStreet.AutoSize = true;
            lblStreet.Font = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold);
            lblStreet.ForeColor = Color.FromArgb(71, 85, 105);
            lblStreet.Location = new Point(392, 220);
            lblStreet.Name = "lblStreet";
            lblStreet.Text = "STREET ADDRESS";
            lblStreet.UseMnemonic = false;

            txtStreet.BorderColor = Color.FromArgb(220, 230, 238);
            txtStreet.BorderRadius = 7;
            txtStreet.FillColor = Color.FromArgb(248, 250, 252);
            txtStreet.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtStreet.FocusedState.FillColor = Color.White;
            txtStreet.Font = new Font("Segoe UI", 9F);
            txtStreet.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtStreet.Location = new Point(392, 237);
            txtStreet.Name = "txtStreet";
            txtStreet.PlaceholderText = "Building / Street name";
            txtStreet.Size = new Size(308, 36);
            txtStreet.TabIndex = 12;

            // 
            // pageActionFooter
            // 
            pageActionFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pageActionFooter.BackColor = Color.Transparent;
            pageActionFooter.Font = new Font("Segoe UI", 9F);
            pageActionFooter.HintText = "Fields marked with * are required to save a citizen record.";
            pageActionFooter.Location = new Point(16, 466);
            pageActionFooter.Name = "pageActionFooter";
            pageActionFooter.PrimaryButtonEnabled = true;
            pageActionFooter.PrimaryButtonText = "Save Person";
            pageActionFooter.SecondaryButtonText = "Cancel";
            pageActionFooter.ShowSecondaryButton = true;
            pageActionFooter.Size = new Size(718, 56);
            pageActionFooter.TabIndex = 2;

            // 
            // PersonEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            ClientSize = new Size(750, 538);
            Controls.Add(topAccentBar);
            Controls.Add(pageHeader);
            Controls.Add(formCard);
            Controls.Add(pageActionFooter);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonEditorForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Person Editor";
            formCard.ResumeLayout(false);
            formCard.PerformLayout();
            photoFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse formElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm formShadow;
        private Guna.UI2.WinForms.Guna2DragControl formDrag;
        private Panel topAccentBar;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Guna.UI2.WinForms.Guna2Panel formCard;
        private Guna.UI2.WinForms.Guna2Panel photoFrame;
        private PictureBox pbPhoto;
        private Guna.UI2.WinForms.Guna2Button btnSelectPhoto;
        private Label lblFirstName;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName;
        private Label lblSecondName;
        private Guna.UI2.WinForms.Guna2TextBox txtSecondName;
        private Label lblThirdName;
        private Guna.UI2.WinForms.Guna2TextBox txtThirdName;
        private Label lblLastName;
        private Guna.UI2.WinForms.Guna2TextBox txtLastName;
        private Label lblNationalNo;
        private Guna.UI2.WinForms.Guna2TextBox txtNationalNo;
        private Label lblDob;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private Label lblGender;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private Label lblPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Label lblCity;
        private Guna.UI2.WinForms.Guna2TextBox txtCity;
        private Label lblStreet;
        private Guna.UI2.WinForms.Guna2TextBox txtStreet;
        private Shared.Controls.PageActionFooterControl pageActionFooter;
    }
}
