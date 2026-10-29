namespace DVLD.WinForms.Features.Test.TestTrackingRoadmap
{
    partial class TestResultCard
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
            cardPanel = new Guna.UI2.WinForms.Guna2Panel();
            iconPanel = new Guna.UI2.WinForms.Guna2Panel();
            pbTestImage = new PictureBox();
            lblTestName = new Label();
            statusPanel = new Guna.UI2.WinForms.Guna2Panel();
            statusIcon = new PictureBox();
            lblStatus = new Label();
            lblTestDateName = new Label();
            lblResultCaption = new Label();
            lblAttemptsCaption = new Label();
            lblTestDate = new Label();
            lblResult = new Label();
            lblAttemt = new Label();
            cardPanel.SuspendLayout();
            iconPanel.SuspendLayout();
            statusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbTestImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)statusIcon).BeginInit();
            SuspendLayout();
            // cardPanel
            cardPanel.BackColor = Color.Transparent;
            cardPanel.BorderColor = Color.FromArgb(219, 229, 242);
            cardPanel.BorderRadius = 6;
            cardPanel.BorderThickness = 1;
            cardPanel.Controls.Add(iconPanel);
            cardPanel.Controls.Add(lblTestName);
            cardPanel.Controls.Add(statusPanel);
            cardPanel.Controls.Add(lblTestDateName);
            cardPanel.Controls.Add(lblResultCaption);
            cardPanel.Controls.Add(lblAttemptsCaption);
            cardPanel.Controls.Add(lblTestDate);
            cardPanel.Controls.Add(lblResult);
            cardPanel.Controls.Add(lblAttemt);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.FillColor = Color.White;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(280, 139);
            cardPanel.TabIndex = 0;
            // iconPanel
            iconPanel.BackColor = Color.Transparent;
            iconPanel.BorderRadius = 7;
            iconPanel.Controls.Add(pbTestImage);
            iconPanel.FillColor = Color.FromArgb(226, 239, 255);
            iconPanel.Location = new Point(12, 12);
            iconPanel.Name = "iconPanel";
            iconPanel.Size = new Size(34, 34);
            iconPanel.TabIndex = 0;
            // pbTestImage
            pbTestImage.BackColor = Color.Transparent;
            pbTestImage.Image = Properties.Resources.icons8_vision_48;
            pbTestImage.Location = new Point(5, 5);
            pbTestImage.Name = "pbTestImage";
            pbTestImage.Size = new Size(24, 24);
            pbTestImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbTestImage.TabStop = false;
            // lblTestName
            lblTestName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTestName.AutoEllipsis = true;
            lblTestName.BackColor = Color.Transparent;
            lblTestName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTestName.ForeColor = Color.FromArgb(15, 23, 42);
            lblTestName.Location = new Point(54, 12);
            lblTestName.Name = "lblTestName";
            lblTestName.Size = new Size(134, 34);
            lblTestName.Text = "Vision test";
            lblTestName.TextAlign = ContentAlignment.MiddleLeft;
            // statusPanel
            statusPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusPanel.BackColor = Color.Transparent;
            statusPanel.BorderRadius = 6;
            statusPanel.Controls.Add(statusIcon);
            statusPanel.Controls.Add(lblStatus);
            statusPanel.FillColor = Color.FromArgb(226, 250, 236);
            statusPanel.Location = new Point(194, 16);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(74, 26);
            statusPanel.TabIndex = 1;
            // statusIcon
            statusIcon.BackColor = Color.Transparent;
            statusIcon.Location = new Point(8, 7);
            statusIcon.Name = "statusIcon";
            statusIcon.Size = new Size(12, 12);
            statusIcon.TabStop = false;
            statusIcon.Paint += statusIcon_Paint;
            // lblStatus
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(21, 128, 61);
            lblStatus.Location = new Point(23, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 26);
            lblStatus.Text = "Passed";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // lblTestDateName
            lblTestDateName.BackColor = Color.Transparent;
            lblTestDateName.ForeColor = Color.FromArgb(100, 116, 139);
            lblTestDateName.Location = new Point(12, 58);
            lblTestDateName.Name = "lblTestDateName";
            lblTestDateName.Size = new Size(88, 20);
            lblTestDateName.Text = "Test date";
            lblTestDateName.TextAlign = ContentAlignment.MiddleLeft;
            // lblResultCaption
            lblResultCaption.BackColor = Color.Transparent;
            lblResultCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblResultCaption.Location = new Point(12, 82);
            lblResultCaption.Name = "lblResultCaption";
            lblResultCaption.Size = new Size(88, 20);
            lblResultCaption.Text = "Result";
            lblResultCaption.TextAlign = ContentAlignment.MiddleLeft;
            // lblAttemptsCaption
            lblAttemptsCaption.BackColor = Color.Transparent;
            lblAttemptsCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblAttemptsCaption.Location = new Point(12, 106);
            lblAttemptsCaption.Name = "lblAttemptsCaption";
            lblAttemptsCaption.Size = new Size(88, 20);
            lblAttemptsCaption.Text = "Attempts";
            lblAttemptsCaption.TextAlign = ContentAlignment.MiddleLeft;
            // lblTestDate
            lblTestDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTestDate.AutoEllipsis = true;
            lblTestDate.BackColor = Color.Transparent;
            lblTestDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTestDate.ForeColor = Color.FromArgb(15, 23, 42);
            lblTestDate.Location = new Point(104, 58);
            lblTestDate.Name = "lblTestDate";
            lblTestDate.Size = new Size(164, 20);
            lblTestDate.Text = "03 Nov 2015";
            lblTestDate.TextAlign = ContentAlignment.MiddleLeft;
            // lblResult
            lblResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResult.AutoEllipsis = true;
            lblResult.BackColor = Color.Transparent;
            lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(15, 23, 42);
            lblResult.Location = new Point(104, 82);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(164, 20);
            lblResult.Text = "Success";
            lblResult.TextAlign = ContentAlignment.MiddleLeft;
            // lblAttemt
            lblAttemt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAttemt.AutoEllipsis = true;
            lblAttemt.BackColor = Color.Transparent;
            lblAttemt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAttemt.ForeColor = Color.FromArgb(15, 23, 42);
            lblAttemt.Location = new Point(104, 106);
            lblAttemt.Name = "lblAttemt";
            lblAttemt.Size = new Size(164, 20);
            lblAttemt.Text = "1";
            lblAttemt.TextAlign = ContentAlignment.MiddleLeft;
            // TestResultCard
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(cardPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(224, 139);
            Name = "TestResultCard";
            Size = new Size(280, 139);
            cardPanel.ResumeLayout(false);
            iconPanel.ResumeLayout(false);
            statusPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbTestImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)statusIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel cardPanel;
        private Guna.UI2.WinForms.Guna2Panel iconPanel;
        private PictureBox pbTestImage;
        private Label lblTestName;
        private Guna.UI2.WinForms.Guna2Panel statusPanel;
        private PictureBox statusIcon;
        private Label lblStatus;
        private Label lblTestDateName;
        private Label lblResultCaption;
        private Label lblAttemptsCaption;
        private Label lblTestDate;
        private Label lblResult;
        private Label lblAttemt;
    }
}
