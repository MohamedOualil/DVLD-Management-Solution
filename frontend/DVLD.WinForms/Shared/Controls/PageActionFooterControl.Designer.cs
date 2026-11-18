namespace DVLD.WinForms.Shared.Controls
{
    partial class PageActionFooterControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            footerCard = new Guna.UI2.WinForms.Guna2Panel();
            lblHintDot = new Label();
            btnSecondary = new Guna.UI2.WinForms.Guna2Button();
            btnPrimary = new Guna.UI2.WinForms.Guna2Button();
            lblFooterHint = new Label();
            footerCard.SuspendLayout();
            SuspendLayout();
            // 
            // footerCard
            // 
            footerCard.BackColor = Color.Transparent;
            footerCard.BorderColor = Color.FromArgb(220, 230, 238);
            footerCard.BorderRadius = 10;
            footerCard.BorderThickness = 1;
            footerCard.Controls.Add(lblHintDot);
            footerCard.Controls.Add(btnSecondary);
            footerCard.Controls.Add(btnPrimary);
            footerCard.Controls.Add(lblFooterHint);
            footerCard.CustomizableEdges = customizableEdges5;
            footerCard.Dock = DockStyle.Fill;
            footerCard.FillColor = Color.White;
            footerCard.Location = new Point(0, 0);
            footerCard.Name = "footerCard";
            footerCard.ShadowDecoration.CustomizableEdges = customizableEdges6;
            footerCard.Size = new Size(971, 56);
            footerCard.TabIndex = 0;
            // 
            // lblHintDot
            // 
            lblHintDot.AutoSize = true;
            lblHintDot.BackColor = Color.Transparent;
            lblHintDot.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHintDot.ForeColor = Color.FromArgb(13, 148, 136);
            lblHintDot.Location = new Point(16, 19);
            lblHintDot.Name = "lblHintDot";
            lblHintDot.Size = new Size(14, 15);
            lblHintDot.TabIndex = 0;
            lblHintDot.Text = "●";
            lblHintDot.UseMnemonic = false;
            // 
            // btnSecondary
            // 
            btnSecondary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSecondary.BackColor = Color.Transparent;
            btnSecondary.BorderColor = Color.FromArgb(203, 213, 225);
            btnSecondary.BorderRadius = 8;
            btnSecondary.BorderThickness = 1;
            btnSecondary.Cursor = Cursors.Hand;
            btnSecondary.CustomizableEdges = customizableEdges1;
            btnSecondary.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            btnSecondary.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            btnSecondary.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            btnSecondary.FillColor = Color.FromArgb(248, 250, 252);
            btnSecondary.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnSecondary.ForeColor = Color.FromArgb(51, 65, 85);
            btnSecondary.HoverState.BorderColor = Color.FromArgb(148, 163, 184);
            btnSecondary.HoverState.FillColor = Color.FromArgb(241, 245, 249);
            btnSecondary.Location = new Point(655, 10);
            btnSecondary.Name = "btnSecondary";
            btnSecondary.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSecondary.Size = new Size(130, 36);
            btnSecondary.TabIndex = 2;
            btnSecondary.Text = "Cancel";
            // 
            // btnPrimary
            // 
            btnPrimary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrimary.BackColor = Color.Transparent;
            btnPrimary.BorderColor = Color.FromArgb(13, 148, 136);
            btnPrimary.BorderRadius = 8;
            btnPrimary.BorderThickness = 1;
            btnPrimary.Cursor = Cursors.Hand;
            btnPrimary.CustomizableEdges = customizableEdges3;
            btnPrimary.DisabledState.BorderColor = Color.FromArgb(203, 213, 225);
            btnPrimary.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            btnPrimary.DisabledState.ForeColor = Color.FromArgb(100, 116, 139);
            btnPrimary.FillColor = Color.FromArgb(13, 148, 136);
            btnPrimary.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnPrimary.ForeColor = Color.White;
            btnPrimary.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            btnPrimary.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            btnPrimary.Location = new Point(795, 10);
            btnPrimary.Name = "btnPrimary";
            btnPrimary.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPrimary.Size = new Size(160, 36);
            btnPrimary.TabIndex = 3;
            btnPrimary.Text = "Save Changes";
            // 
            // lblFooterHint
            // 
            lblFooterHint.AutoEllipsis = true;
            lblFooterHint.BackColor = Color.Transparent;
            lblFooterHint.Font = new Font("Segoe UI", 9F);
            lblFooterHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooterHint.Location = new Point(34, 18);
            lblFooterHint.Name = "lblFooterHint";
            lblFooterHint.Size = new Size(625, 20);
            lblFooterHint.TabIndex = 1;
            lblFooterHint.Text = "Review the information above before continuing.";
            lblFooterHint.TextAlign = ContentAlignment.MiddleLeft;
            lblFooterHint.UseMnemonic = false;
            // 
            // PageActionFooterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(footerCard);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(520, 56);
            Name = "PageActionFooterControl";
            Size = new Size(971, 56);
            footerCard.ResumeLayout(false);
            footerCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel footerCard;
        private Label lblHintDot;
        private Label lblFooterHint;
        private Guna.UI2.WinForms.Guna2Button btnSecondary;
        private Guna.UI2.WinForms.Guna2Button btnPrimary;
    }
}
