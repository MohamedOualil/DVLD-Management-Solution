namespace DVLD.WinForms.Features.Persons
{
    partial class PersonCardForm
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
            closeControlBox = new Guna.UI2.WinForms.Guna2ControlBox();
            headerPanel = new Panel();
            titleLabel = new Label();
            closeButton = new Guna.UI2.WinForms.Guna2Button();
            personDetailControl1 = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();
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
            // closeControlBox
            // 
            closeControlBox.AccessibleName = "Close";
            closeControlBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeControlBox.CustomizableEdges = customizableEdges3;
            closeControlBox.FillColor = Color.FromArgb(240, 245, 251);
            closeControlBox.IconColor = Color.DimGray;
            closeControlBox.Location = new Point(518, 20);
            closeControlBox.Name = "closeControlBox";
            closeControlBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            closeControlBox.Size = new Size(30, 30);
            closeControlBox.TabIndex = 1;
            // 
            // personDetailControl1
            // 
            personDetailControl1.Location = new Point(24, 88);
            personDetailControl1.Name = "personDetailControl1";
            personDetailControl1.Size = new Size(520, 265);
            personDetailControl1.TabIndex = 2;
            // 
            // PersonCartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(568, 420);
            Controls.Add(personDetailControl1);
            Controls.Add(headerPanel);
            Controls.Add(closeButton);

            FormBorderStyle = FormBorderStyle.None;
            Name = "PersonCardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Person Card";
            // A separate header makes the modal distinct from the page behind it.
            headerPanel.BackColor = Color.FromArgb(240, 245, 251);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Size = new Size(568, 68);
            headerPanel.Name = "headerPanel";
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(closeControlBox);
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(25, 40, 69);
            titleLabel.Location = new Point(24, 18);
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Person details";
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.BorderRadius = 8;
            closeButton.FillColor = Color.RoyalBlue;
            closeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(424, 368);
            closeButton.Size = new Size(120, 36);
            closeButton.Name = "closeButton";
            closeButton.Text = "Close";
            closeButton.DialogResult = DialogResult.Cancel;
            closeButton.TabIndex = 0;
            CancelButton = closeButton;
            ShowInTaskbar = false;
            MinimizeBox = false;
            MaximizeBox = false;
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
        private Detail.PersonDetailControl personDetailControl1;
    }
}
