namespace DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication
{
    partial class NewLocalDrivingLicenseControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            headerPanel = new Panel();
            pageTitle = new Label();
            pageSubtitle = new Label();
            stepsPanel = new Panel();
            StepProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            personStepLabel = new Label();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            classStepLabel = new Label();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            createdStepLabel = new Label();
            ApplicationPanel = new Guna.UI2.WinForms.Guna2Panel();
            successPanel = new Guna.UI2.WinForms.Guna2Panel();
            successMark = new Label();
            successHeading = new Label();
            successDescription = new Label();
            footerDivider = new Panel();
            BackButton = new Guna.UI2.WinForms.Guna2GradientButton();
            lblMessage = new Label();
            NextStepButton = new Guna.UI2.WinForms.Guna2GradientButton();
            headerPanel.SuspendLayout();
            stepsPanel.SuspendLayout();
            successPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel.Controls.Add(pageTitle);
            headerPanel.Controls.Add(pageSubtitle);
            headerPanel.Controls.Add(stepsPanel);
            headerPanel.Location = new Point(16, 16);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(971, 80);
            headerPanel.TabIndex = 0;
            // 
            // pageTitle
            // 
            pageTitle.BackColor = Color.Transparent;
            pageTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            pageTitle.ForeColor = Color.FromArgb(15, 23, 42);
            pageTitle.Location = new Point(0, 0);
            pageTitle.Name = "pageTitle";
            pageTitle.Size = new Size(470, 30);
            pageTitle.TabIndex = 0;
            pageTitle.Text = "New local driving licence";
            // 
            // pageSubtitle
            // 
            pageSubtitle.BackColor = Color.Transparent;
            pageSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            pageSubtitle.Location = new Point(2, 38);
            pageSubtitle.Name = "pageSubtitle";
            pageSubtitle.Size = new Size(470, 24);
            pageSubtitle.TabIndex = 1;
            pageSubtitle.Text = "Select an applicant and choose a licence class.";
            // 
            // stepsPanel
            // 
            stepsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stepsPanel.Controls.Add(guna2Button3);
            stepsPanel.Controls.Add(guna2Button2);
            stepsPanel.Controls.Add(guna2Button1);
            stepsPanel.Controls.Add(StepProgressBar);
            stepsPanel.Controls.Add(personStepLabel);
            stepsPanel.Controls.Add(classStepLabel);
            stepsPanel.Controls.Add(createdStepLabel);
            stepsPanel.Location = new Point(480, 0);
            stepsPanel.Name = "stepsPanel";
            stepsPanel.Size = new Size(491, 80);
            stepsPanel.TabIndex = 2;
            // 
            // StepProgressBar
            // 
            StepProgressBar.CustomizableEdges = customizableEdges7;
            StepProgressBar.FillColor = Color.FromArgb(219, 229, 242);
            StepProgressBar.Location = new Point(60, 22);
            StepProgressBar.Name = "StepProgressBar";
            StepProgressBar.ProgressColor = Color.FromArgb(37, 99, 235);
            StepProgressBar.ProgressColor2 = Color.FromArgb(37, 99, 235);
            StepProgressBar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            StepProgressBar.Size = new Size(331, 3);
            StepProgressBar.TabIndex = 0;
            StepProgressBar.TabStop = false;
            StepProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 15;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.FillColor = Color.FromArgb(37, 99, 235);
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(42, 8);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(30, 30);
            guna2Button1.TabIndex = 1;
            guna2Button1.TabStop = false;
            guna2Button1.Text = "1";
            // 
            // personStepLabel
            // 
            personStepLabel.BackColor = Color.Transparent;
            personStepLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            personStepLabel.ForeColor = Color.FromArgb(37, 99, 235);
            personStepLabel.Location = new Point(0, 46);
            personStepLabel.Name = "personStepLabel";
            personStepLabel.Size = new Size(126, 22);
            personStepLabel.TabIndex = 2;
            personStepLabel.Text = "Select person";
            personStepLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 15;
            guna2Button2.CustomizableEdges = customizableEdges3;
            guna2Button2.FillColor = Color.FromArgb(226, 232, 240);
            guna2Button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2Button2.ForeColor = Color.FromArgb(100, 116, 139);
            guna2Button2.Location = new Point(207, 8);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(30, 30);
            guna2Button2.TabIndex = 3;
            guna2Button2.TabStop = false;
            guna2Button2.Text = "2";
            // 
            // classStepLabel
            // 
            classStepLabel.BackColor = Color.Transparent;
            classStepLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            classStepLabel.ForeColor = Color.FromArgb(100, 116, 139);
            classStepLabel.Location = new Point(165, 46);
            classStepLabel.Name = "classStepLabel";
            classStepLabel.Size = new Size(126, 22);
            classStepLabel.TabIndex = 4;
            classStepLabel.Text = "Licence class";
            classStepLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // guna2Button3
            // 
            guna2Button3.BorderRadius = 15;
            guna2Button3.CustomizableEdges = customizableEdges1;
            guna2Button3.FillColor = Color.FromArgb(226, 232, 240);
            guna2Button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            guna2Button3.ForeColor = Color.FromArgb(100, 116, 139);
            guna2Button3.Location = new Point(372, 8);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button3.Size = new Size(30, 30);
            guna2Button3.TabIndex = 5;
            guna2Button3.TabStop = false;
            guna2Button3.Text = "3";
            // 
            // createdStepLabel
            // 
            createdStepLabel.BackColor = Color.Transparent;
            createdStepLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            createdStepLabel.ForeColor = Color.FromArgb(100, 116, 139);
            createdStepLabel.Location = new Point(330, 46);
            createdStepLabel.Name = "createdStepLabel";
            createdStepLabel.Size = new Size(126, 22);
            createdStepLabel.TabIndex = 6;
            createdStepLabel.Text = "Created";
            createdStepLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ApplicationPanel
            // 
            ApplicationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApplicationPanel.CustomizableEdges = customizableEdges9;
            ApplicationPanel.FillColor = Color.Transparent;
            ApplicationPanel.Location = new Point(16, 104);
            ApplicationPanel.Name = "ApplicationPanel";
            ApplicationPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            ApplicationPanel.Size = new Size(971, 447);
            ApplicationPanel.TabIndex = 0;
            // 
            // successPanel
            // 
            successPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            successPanel.BorderColor = Color.FromArgb(187, 247, 208);
            successPanel.BorderRadius = 8;
            successPanel.BorderThickness = 1;
            successPanel.Controls.Add(successMark);
            successPanel.Controls.Add(successHeading);
            successPanel.Controls.Add(successDescription);
            successPanel.CustomizableEdges = customizableEdges11;
            successPanel.FillColor = Color.FromArgb(240, 253, 244);
            successPanel.Location = new Point(16, 104);
            successPanel.Name = "successPanel";
            successPanel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            successPanel.Size = new Size(971, 447);
            successPanel.TabIndex = 1;
            successPanel.Visible = false;
            // 
            // successMark
            // 
            successMark.BackColor = Color.Transparent;
            successMark.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
            successMark.ForeColor = Color.FromArgb(22, 163, 74);
            successMark.Location = new Point(32, 126);
            successMark.Name = "successMark";
            successMark.Size = new Size(80, 90);
            successMark.TabIndex = 0;
            successMark.Text = "✓";
            successMark.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // successHeading
            // 
            successHeading.BackColor = Color.Transparent;
            successHeading.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            successHeading.ForeColor = Color.FromArgb(21, 128, 61);
            successHeading.Location = new Point(136, 142);
            successHeading.Name = "successHeading";
            successHeading.Size = new Size(650, 36);
            successHeading.TabIndex = 1;
            successHeading.Text = "Application created";
            // 
            // successDescription
            // 
            successDescription.BackColor = Color.Transparent;
            successDescription.Font = new Font("Segoe UI", 11F);
            successDescription.ForeColor = Color.FromArgb(100, 116, 139);
            successDescription.Location = new Point(140, 194);
            successDescription.Name = "successDescription";
            successDescription.Size = new Size(700, 28);
            successDescription.TabIndex = 2;
            successDescription.Text = "Your local driving licence application has been saved.";
            // 
            // footerDivider
            // 
            footerDivider.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            footerDivider.BackColor = Color.FromArgb(219, 229, 242);
            footerDivider.Location = new Point(16, 565);
            footerDivider.Name = "footerDivider";
            footerDivider.Size = new Size(971, 1);
            footerDivider.TabIndex = 2;
            // 
            // BackButton
            // 
            BackButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BackButton.BorderColor = Color.FromArgb(219, 229, 242);
            BackButton.BorderRadius = 6;
            BackButton.BorderThickness = 1;
            BackButton.CustomizableEdges = customizableEdges13;
            BackButton.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            BackButton.DisabledState.FillColor2 = Color.FromArgb(226, 232, 240);
            BackButton.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            BackButton.FillColor = Color.White;
            BackButton.FillColor2 = Color.White;
            BackButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BackButton.ForeColor = Color.FromArgb(15, 23, 42);
            BackButton.Location = new Point(16, 579);
            BackButton.Name = "BackButton";
            BackButton.ShadowDecoration.CustomizableEdges = customizableEdges14;
            BackButton.Size = new Size(116, 38);
            BackButton.TabIndex = 1;
            BackButton.Text = "Cancel";
            BackButton.Click += BackButton_Click;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.FromArgb(185, 28, 28);
            lblMessage.Location = new Point(148, 572);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(655, 52);
            lblMessage.TabIndex = 3;
            lblMessage.Visible = false;
            // 
            // NextStepButton
            // 
            NextStepButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            NextStepButton.BorderRadius = 6;
            NextStepButton.CustomizableEdges = customizableEdges15;
            NextStepButton.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            NextStepButton.DisabledState.FillColor2 = Color.FromArgb(226, 232, 240);
            NextStepButton.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            NextStepButton.Enabled = false;
            NextStepButton.FillColor = Color.FromArgb(37, 99, 235);
            NextStepButton.FillColor2 = Color.FromArgb(37, 99, 235);
            NextStepButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            NextStepButton.ForeColor = Color.White;
            NextStepButton.Location = new Point(819, 579);
            NextStepButton.Name = "NextStepButton";
            NextStepButton.ShadowDecoration.CustomizableEdges = customizableEdges16;
            NextStepButton.Size = new Size(168, 38);
            NextStepButton.TabIndex = 2;
            NextStepButton.Text = "Next step";
            NextStepButton.Click += NextStepButton_Click;
            // 
            // NewLocalDrivingLicenseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 249, 253);
            Controls.Add(headerPanel);
            Controls.Add(ApplicationPanel);
            Controls.Add(successPanel);
            Controls.Add(footerDivider);
            Controls.Add(BackButton);
            Controls.Add(lblMessage);
            Controls.Add(NextStepButton);
            Font = new Font("Segoe UI", 9F);
            Name = "NewLocalDrivingLicenseControl";
            Size = new Size(1003, 637);
            headerPanel.ResumeLayout(false);
            stepsPanel.ResumeLayout(false);
            successPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Label pageTitle;
        private Label pageSubtitle;
        private Panel stepsPanel;
        private Guna.UI2.WinForms.Guna2ProgressBar StepProgressBar;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label personStepLabel;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Label classStepLabel;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Label createdStepLabel;
        private Guna.UI2.WinForms.Guna2Panel ApplicationPanel;
        private Guna.UI2.WinForms.Guna2Panel successPanel;
        private Label successMark;
        private Label successHeading;
        private Label successDescription;
        private Panel footerDivider;
        private Guna.UI2.WinForms.Guna2GradientButton BackButton;
        private Label lblMessage;
        private Guna.UI2.WinForms.Guna2GradientButton NextStepButton;
    }
}
