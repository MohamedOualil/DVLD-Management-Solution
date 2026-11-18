namespace DVLD.WinForms.Shared.Controls
{
    partial class TestRoadmapControl
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
            roadmapPanel = new Guna.UI2.WinForms.Guna2Panel();
            pbRoadmapIcon = new PictureBox();
            lblRoadmapTitle = new Label();
            eligibilityBadge = new Guna.UI2.WinForms.Guna2Button();
            roadmapDivider = new Panel();
            testCardsLayout = new TableLayoutPanel();
            visionTestCard = new DVLD.WinForms.Shared.Controls.TestResultCard();
            writtenTestCard = new DVLD.WinForms.Shared.Controls.TestResultCard();
            streetTestCard = new DVLD.WinForms.Shared.Controls.TestResultCard();
            roadmapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbRoadmapIcon).BeginInit();
            testCardsLayout.SuspendLayout();
            SuspendLayout();
            // 
            // roadmapPanel
            // 
            roadmapPanel.BackColor = Color.Transparent;
            roadmapPanel.BorderColor = Color.FromArgb(220, 230, 238);
            roadmapPanel.BorderRadius = 12;
            roadmapPanel.BorderThickness = 1;
            roadmapPanel.Controls.Add(pbRoadmapIcon);
            roadmapPanel.Controls.Add(lblRoadmapTitle);
            roadmapPanel.Controls.Add(eligibilityBadge);
            roadmapPanel.Controls.Add(roadmapDivider);
            roadmapPanel.Controls.Add(testCardsLayout);
            roadmapPanel.CustomizableEdges = customizableEdges1;
            roadmapPanel.Dock = DockStyle.Fill;
            roadmapPanel.FillColor = Color.White;
            roadmapPanel.Location = new Point(0, 0);
            roadmapPanel.Name = "roadmapPanel";
            roadmapPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            roadmapPanel.Size = new Size(971, 188);
            roadmapPanel.TabIndex = 0;
            // 
            // pbRoadmapIcon
            // 
            pbRoadmapIcon.BackColor = Color.Transparent;
            pbRoadmapIcon.Image = Properties.Resources.icons8_test_48;
            pbRoadmapIcon.Location = new Point(18, 9);
            pbRoadmapIcon.Name = "pbRoadmapIcon";
            pbRoadmapIcon.Size = new Size(20, 20);
            pbRoadmapIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbRoadmapIcon.TabIndex = 0;
            pbRoadmapIcon.TabStop = false;
            // 
            // lblRoadmapTitle
            // 
            lblRoadmapTitle.AutoSize = true;
            lblRoadmapTitle.BackColor = Color.Transparent;
            lblRoadmapTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRoadmapTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblRoadmapTitle.Location = new Point(44, 9);
            lblRoadmapTitle.Name = "lblRoadmapTitle";
            lblRoadmapTitle.Size = new Size(232, 20);
            lblRoadmapTitle.TabIndex = 1;
            lblRoadmapTitle.Text = "Licensing Examination Roadmap";
            lblRoadmapTitle.UseMnemonic = false;
            // 
            // eligibilityBadge
            // 
            eligibilityBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            eligibilityBadge.Animated = false;
            eligibilityBadge.BackColor = Color.Transparent;
            eligibilityBadge.BorderColor = Color.FromArgb(226, 232, 240);
            eligibilityBadge.BorderRadius = 13;
            eligibilityBadge.BorderThickness = 1;
            eligibilityBadge.CustomizableEdges = customizableEdges3;
            eligibilityBadge.FillColor = Color.FromArgb(248, 250, 252);
            eligibilityBadge.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            eligibilityBadge.ForeColor = Color.FromArgb(71, 85, 105);
            eligibilityBadge.HoverState.BorderColor = Color.FromArgb(226, 232, 240);
            eligibilityBadge.HoverState.FillColor = Color.FromArgb(248, 250, 252);
            eligibilityBadge.HoverState.ForeColor = Color.FromArgb(71, 85, 105);
            eligibilityBadge.Location = new Point(735, 6);
            eligibilityBadge.Name = "eligibilityBadge";
            eligibilityBadge.PressedColor = Color.FromArgb(248, 250, 252);
            eligibilityBadge.ShadowDecoration.CustomizableEdges = customizableEdges4;
            eligibilityBadge.Size = new Size(218, 26);
            eligibilityBadge.TabIndex = 2;
            eligibilityBadge.TabStop = false;
            eligibilityBadge.Text = "○ 0 of 3 Tests Passed";
            // 
            // roadmapDivider
            // 
            roadmapDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roadmapDivider.BackColor = Color.FromArgb(226, 232, 240);
            roadmapDivider.Location = new Point(18, 37);
            roadmapDivider.Name = "roadmapDivider";
            roadmapDivider.Size = new Size(935, 1);
            roadmapDivider.TabIndex = 3;
            // 
            // testCardsLayout
            // 
            testCardsLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testCardsLayout.BackColor = Color.White;
            testCardsLayout.ColumnCount = 3;
            testCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            testCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            testCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            testCardsLayout.Controls.Add(visionTestCard, 0, 0);
            testCardsLayout.Controls.Add(writtenTestCard, 1, 0);
            testCardsLayout.Controls.Add(streetTestCard, 2, 0);
            testCardsLayout.Location = new Point(14, 44);
            testCardsLayout.Margin = new Padding(0);
            testCardsLayout.Name = "testCardsLayout";
            testCardsLayout.RowCount = 1;
            testCardsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            testCardsLayout.Size = new Size(943, 139);
            testCardsLayout.TabIndex = 4;
            // 
            // visionTestCard
            // 
            visionTestCard.BackColor = Color.Transparent;
            visionTestCard.Dock = DockStyle.Fill;
            visionTestCard.Font = new Font("Segoe UI", 9F);
            visionTestCard.Location = new Point(0, 0);
            visionTestCard.Margin = new Padding(0, 0, 12, 0);
            visionTestCard.MinimumSize = new Size(224, 139);
            visionTestCard.Name = "visionTestCard";
            visionTestCard.Size = new Size(302, 139);
            visionTestCard.TabIndex = 0;
            // 
            // writtenTestCard
            // 
            writtenTestCard.BackColor = Color.Transparent;
            writtenTestCard.Dock = DockStyle.Fill;
            writtenTestCard.Font = new Font("Segoe UI", 9F);
            writtenTestCard.Location = new Point(314, 0);
            writtenTestCard.Margin = new Padding(0, 0, 12, 0);
            writtenTestCard.MinimumSize = new Size(224, 139);
            writtenTestCard.Name = "writtenTestCard";
            writtenTestCard.Size = new Size(302, 139);
            writtenTestCard.TabIndex = 1;
            // 
            // streetTestCard
            // 
            streetTestCard.BackColor = Color.Transparent;
            streetTestCard.Dock = DockStyle.Fill;
            streetTestCard.Font = new Font("Segoe UI", 9F);
            streetTestCard.Location = new Point(628, 0);
            streetTestCard.Margin = new Padding(0);
            streetTestCard.MinimumSize = new Size(224, 139);
            streetTestCard.Name = "streetTestCard";
            streetTestCard.Size = new Size(315, 139);
            streetTestCard.TabIndex = 2;
            // 
            // TestRoadmapControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(roadmapPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(710, 188);
            Name = "TestRoadmapControl";
            Size = new Size(971, 188);
            roadmapPanel.ResumeLayout(false);
            roadmapPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbRoadmapIcon).EndInit();
            testCardsLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel roadmapPanel;
        private PictureBox pbRoadmapIcon;
        private Label lblRoadmapTitle;
        private Guna.UI2.WinForms.Guna2Button eligibilityBadge;
        private Panel roadmapDivider;
        private TableLayoutPanel testCardsLayout;
        private TestResultCard visionTestCard;
        private TestResultCard writtenTestCard;
        private TestResultCard streetTestCard;
    }
}
