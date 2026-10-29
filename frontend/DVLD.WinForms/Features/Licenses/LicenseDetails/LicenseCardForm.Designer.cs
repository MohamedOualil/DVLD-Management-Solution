namespace DVLD.WinForms.Features.Licenses.LicenseDetails
{
    partial class LicenseCardForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            formShadow = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            formAnimation = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            formDrag = new Guna.UI2.WinForms.Guna2DragControl(components);
            headerPanel = new Panel();
            titleLabel = new Label();
            closeControlBox = new Guna.UI2.WinForms.Guna2ControlBox();
            closeButton = new Guna.UI2.WinForms.Guna2Button();
            licenseCardControl1 = new LicenseCardControl();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // formElipse
            // 
            formElipse.BorderRadius = 20;
            formElipse.TargetControl = this;
            // 
            // formShadow
            // 
            formShadow.TargetForm = this;
            // 
            // formAnimation
            // 
            formAnimation.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            formAnimation.Interval = 200;
            formAnimation.TargetForm = this;
            // 
            // formDrag
            // 
            formDrag.DockIndicatorTransparencyValue = 0.6D;
            formDrag.TargetControl = headerPanel;
            formDrag.UseTransparentDrag = true;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(240, 245, 251);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(closeControlBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(832, 68);
            headerPanel.TabIndex = 3;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(25, 40, 69);
            titleLabel.Location = new Point(24, 18);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(170, 31);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Licence details";
            // 
            // closeControlBox
            // 
            closeControlBox.AccessibleName = "Close";
            closeControlBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeControlBox.CustomizableEdges = customizableEdges3;
            closeControlBox.FillColor = Color.FromArgb(240, 245, 251);
            closeControlBox.IconColor = Color.DimGray;
            closeControlBox.Location = new Point(782, 20);
            closeControlBox.Name = "closeControlBox";
            closeControlBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            closeControlBox.Size = new Size(30, 30);
            closeControlBox.TabIndex = 1;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.BorderRadius = 8;
            closeButton.CustomizableEdges = customizableEdges1;
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.FillColor = Color.RoyalBlue;
            closeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(688, 576);
            closeButton.Name = "closeButton";
            closeButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            closeButton.Size = new Size(120, 36);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            // 
            // licenseCardControl1
            // 
            licenseCardControl1.BackColor = Color.Transparent;
            licenseCardControl1.Location = new Point(24, 88);
            licenseCardControl1.Name = "licenseCardControl1";
            licenseCardControl1.Size = new Size(784, 468);
            licenseCardControl1.TabIndex = 2;
            // 
            // LicenseCardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = closeButton;
            ClientSize = new Size(832, 624);
            Controls.Add(licenseCardControl1);
            Controls.Add(headerPanel);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LicenseCardForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Licence Card";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse formElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm formShadow;
        private Guna.UI2.WinForms.Guna2AnimateWindow formAnimation;

        private Guna.UI2.WinForms.Guna2DragControl formDrag;
        private Guna.UI2.WinForms.Guna2ControlBox closeControlBox;
        private Panel headerPanel;
        private Label titleLabel;
        private Guna.UI2.WinForms.Guna2Button closeButton;
        private LicenseCardControl licenseCardControl1;
    }
}

