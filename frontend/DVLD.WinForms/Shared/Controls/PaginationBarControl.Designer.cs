namespace DVLD.WinForms.Shared.Controls
{
    partial class PaginationBarControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblPaginationSummary = new Label();
            btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            pageBadgePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblCurrentPage = new Label();
            btnNext = new Guna.UI2.WinForms.Guna2Button();
            pageBadgePanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblPaginationSummary
            // 
            lblPaginationSummary.AutoSize = true;
            lblPaginationSummary.BackColor = Color.Transparent;
            lblPaginationSummary.Font = new Font("Segoe UI", 8.75F);
            lblPaginationSummary.ForeColor = Color.FromArgb(100, 116, 139);
            lblPaginationSummary.Location = new Point(16, 15);
            lblPaginationSummary.Name = "lblPaginationSummary";
            lblPaginationSummary.Size = new Size(134, 15);
            lblPaginationSummary.TabIndex = 0;
            lblPaginationSummary.Text = "Showing 0 of 0 records";
            lblPaginationSummary.UseMnemonic = false;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.BackColor = Color.Transparent;
            btnPrevious.BorderColor = Color.FromArgb(226, 232, 240);
            btnPrevious.BorderRadius = 6;
            btnPrevious.BorderThickness = 1;
            btnPrevious.Cursor = Cursors.Hand;
            btnPrevious.CustomizableEdges = customizableEdges1;
            btnPrevious.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            btnPrevious.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            btnPrevious.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            btnPrevious.Enabled = false;
            btnPrevious.FillColor = Color.White;
            btnPrevious.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnPrevious.ForeColor = Color.FromArgb(51, 65, 85);
            btnPrevious.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            btnPrevious.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            btnPrevious.Location = new Point(843, 8);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrevious.Size = new Size(34, 30);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "<";
            // 
            // pageBadgePanel
            // 
            pageBadgePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pageBadgePanel.BackColor = Color.Transparent;
            pageBadgePanel.BorderRadius = 6;
            pageBadgePanel.Controls.Add(lblCurrentPage);
            pageBadgePanel.CustomizableEdges = customizableEdges3;
            pageBadgePanel.FillColor = Color.FromArgb(13, 148, 136);
            pageBadgePanel.Location = new Point(883, 8);
            pageBadgePanel.Name = "pageBadgePanel";
            pageBadgePanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pageBadgePanel.Size = new Size(36, 30);
            pageBadgePanel.TabIndex = 2;
            // 
            // lblCurrentPage
            // 
            lblCurrentPage.BackColor = Color.Transparent;
            lblCurrentPage.Dock = DockStyle.Fill;
            lblCurrentPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentPage.ForeColor = Color.White;
            lblCurrentPage.Location = new Point(0, 0);
            lblCurrentPage.Name = "lblCurrentPage";
            lblCurrentPage.Size = new Size(36, 30);
            lblCurrentPage.TabIndex = 0;
            lblCurrentPage.Text = "1";
            lblCurrentPage.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentPage.UseMnemonic = false;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.BackColor = Color.Transparent;
            btnNext.BorderColor = Color.FromArgb(226, 232, 240);
            btnNext.BorderRadius = 6;
            btnNext.BorderThickness = 1;
            btnNext.Cursor = Cursors.Hand;
            btnNext.CustomizableEdges = customizableEdges5;
            btnNext.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            btnNext.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            btnNext.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            btnNext.Enabled = false;
            btnNext.FillColor = Color.White;
            btnNext.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(51, 65, 85);
            btnNext.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            btnNext.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            btnNext.Location = new Point(925, 8);
            btnNext.Name = "btnNext";
            btnNext.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnNext.Size = new Size(34, 30);
            btnNext.TabIndex = 3;
            btnNext.Text = ">";
            // 
            // PaginationBarControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(lblPaginationSummary);
            Controls.Add(btnPrevious);
            Controls.Add(pageBadgePanel);
            Controls.Add(btnNext);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(340, 46);
            Name = "PaginationBarControl";
            Size = new Size(971, 46);
            pageBadgePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPaginationSummary;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Panel pageBadgePanel;
        private Label lblCurrentPage;
        private Guna.UI2.WinForms.Guna2Button btnNext;
    }
}
