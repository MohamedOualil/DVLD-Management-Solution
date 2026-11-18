namespace DVLD.WinForms.Features.Auth
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            pictureBox1 = new PictureBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            RemebermeSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            label1 = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            lblErrorMessage = new Label();
            loader = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 16;
            guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            guna2ShadowForm1.TargetForm = this;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(411, 407);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.BorderColor = Color.FromArgb(220, 230, 238);
            txtUsername.BorderRadius = 8;
            txtUsername.BorderThickness = 1;
            txtUsername.CustomizableEdges = customizableEdges12;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtUsername.DisabledState.FillColor = Color.FromArgb(241, 245, 249);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtUsername.FillColor = Color.FromArgb(248, 250, 252);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtUsername.FocusedState.FillColor = Color.White;
            txtUsername.Font = new Font("Segoe UI", 9.5F);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtUsername.IconLeft = (Image)resources.GetObject("txtUsername.IconLeft");
            txtUsername.Location = new Point(468, 128);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtUsername.PlaceholderText = "Username";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges13;
            txtUsername.Size = new Size(268, 40);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(220, 230, 238);
            txtPassword.BorderRadius = 8;
            txtPassword.BorderThickness = 1;
            txtPassword.CustomizableEdges = customizableEdges10;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtPassword.DisabledState.FillColor = Color.FromArgb(241, 245, 249);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.FillColor = Color.FromArgb(248, 250, 252);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtPassword.FocusedState.FillColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 9.5F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtPassword.IconLeft = (Image)resources.GetObject("txtPassword.IconLeft");
            txtPassword.Location = new Point(468, 184);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges11;
            txtPassword.Size = new Size(268, 40);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // RemebermeSwitch
            // 
            RemebermeSwitch.CheckedState.BorderColor = Color.FromArgb(13, 148, 136);
            RemebermeSwitch.CheckedState.FillColor = Color.FromArgb(13, 148, 136);
            RemebermeSwitch.CheckedState.InnerBorderColor = Color.White;
            RemebermeSwitch.CheckedState.InnerColor = Color.White;
            RemebermeSwitch.CustomizableEdges = customizableEdges8;
            RemebermeSwitch.Location = new Point(468, 240);
            RemebermeSwitch.Name = "RemebermeSwitch";
            RemebermeSwitch.ShadowDecoration.CustomizableEdges = customizableEdges9;
            RemebermeSwitch.Size = new Size(35, 20);
            RemebermeSwitch.TabIndex = 2;
            RemebermeSwitch.UncheckedState.BorderColor = Color.FromArgb(220, 230, 238);
            RemebermeSwitch.UncheckedState.FillColor = Color.FromArgb(220, 230, 238);
            RemebermeSwitch.UncheckedState.InnerBorderColor = Color.White;
            RemebermeSwitch.UncheckedState.InnerColor = Color.White;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(71, 85, 105);
            label1.Location = new Point(512, 241);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 4;
            label1.Text = "Remember me";
            label1.UseMnemonic = false;
            // 
            // btnLogin
            // 
            btnLogin.Animated = true;
            btnLogin.BorderColor = Color.FromArgb(13, 148, 136);
            btnLogin.BorderRadius = 8;
            btnLogin.BorderThickness = 1;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            btnLogin.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            btnLogin.FillColor = Color.FromArgb(13, 148, 136);
            btnLogin.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            btnLogin.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            btnLogin.Location = new Point(468, 286);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(268, 42);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Sign In";
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(15, 23, 42);
            label2.Location = new Point(468, 66);
            label2.Name = "label2";
            label2.Size = new Size(156, 30);
            label2.TabIndex = 4;
            label2.Text = "Sign in to DVLD";
            label2.UseMnemonic = false;
            // 
            // guna2AnimateWindow1
            // 
            guna2AnimateWindow1.TargetForm = this;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.BorderRadius = 6;
            guna2ControlBox1.CustomizableEdges = customizableEdges6;
            guna2ControlBox1.FillColor = Color.Transparent;
            guna2ControlBox1.HoverState.FillColor = Color.FromArgb(254, 226, 226);
            guna2ControlBox1.HoverState.IconColor = Color.FromArgb(220, 38, 38);
            guna2ControlBox1.IconColor = Color.FromArgb(100, 116, 139);
            guna2ControlBox1.Location = new Point(738, 10);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2ControlBox1.Size = new Size(28, 28);
            guna2ControlBox1.TabIndex = 0;
            // 
            // guna2ControlBox2
            // 
            guna2ControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox2.BorderRadius = 6;
            guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            guna2ControlBox2.CustomizableEdges = customizableEdges4;
            guna2ControlBox2.FillColor = Color.Transparent;
            guna2ControlBox2.HoverState.FillColor = Color.FromArgb(241, 245, 249);
            guna2ControlBox2.IconColor = Color.FromArgb(100, 116, 139);
            guna2ControlBox2.Location = new Point(706, 10);
            guna2ControlBox2.Name = "guna2ControlBox2";
            guna2ControlBox2.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2ControlBox2.Size = new Size(28, 28);
            guna2ControlBox2.TabIndex = 0;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoEllipsis = true;
            lblErrorMessage.BackColor = Color.FromArgb(254, 226, 226);
            lblErrorMessage.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrorMessage.ForeColor = Color.FromArgb(185, 28, 28);
            lblErrorMessage.Location = new Point(468, 342);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Padding = new Padding(10, 4, 10, 4);
            lblErrorMessage.Size = new Size(268, 38);
            lblErrorMessage.TabIndex = 6;
            lblErrorMessage.Text = "";
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.UseMnemonic = false;
            lblErrorMessage.Visible = false;
            // 
            // loader
            // 
            loader.AutoStart = true;
            loader.Location = new Point(361, 151);
            loader.Name = "loader";
            loader.ShadowDecoration.CustomizableEdges = customizableEdges3;
            loader.Size = new Size(90, 90);
            loader.TabIndex = 7;
            loader.Visible = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(779, 444);
            Controls.Add(loader);
            Controls.Add(lblErrorMessage);
            Controls.Add(guna2ControlBox2);
            Controls.Add(guna2ControlBox1);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RemebermeSwitch);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(779, 444);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DVLD Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch RemebermeSwitch;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Label lblErrorMessage;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator loader;
    }
}