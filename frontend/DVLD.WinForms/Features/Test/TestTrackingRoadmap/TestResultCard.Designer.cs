namespace DVLD.WinForms.Features.Test.TestTrackingRoadmap
{
    partial class TestResultCard
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
            pbTestImage = new PictureBox();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblTestDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblAttemt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblResult = new Guna.UI2.WinForms.Guna2HtmlLabel();
            TeststatusButton = new Guna.UI2.WinForms.Guna2Button();
            lblTestName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTestDateName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)pbTestImage).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pbTestImage
            // 
            pbTestImage.Image = Properties.Resources.icons8_test_48;
            pbTestImage.Location = new Point(11, 13);
            pbTestImage.Name = "pbTestImage";
            pbTestImage.Size = new Size(42, 40);
            pbTestImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbTestImage.TabIndex = 0;
            pbTestImage.TabStop = false;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblTestDate);
            guna2ShadowPanel1.Controls.Add(lblAttemt);
            guna2ShadowPanel1.Controls.Add(lblResult);
            guna2ShadowPanel1.Controls.Add(TeststatusButton);
            guna2ShadowPanel1.Controls.Add(lblTestName);
            guna2ShadowPanel1.Controls.Add(guna2HtmlLabel3);
            guna2ShadowPanel1.Controls.Add(guna2HtmlLabel1);
            guna2ShadowPanel1.Controls.Add(lblTestDateName);
            guna2ShadowPanel1.Controls.Add(pbTestImage);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(3, 4);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 6;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 50;
            guna2ShadowPanel1.Size = new Size(216, 133);
            guna2ShadowPanel1.TabIndex = 1;
            // 
            // lblTestDate
            // 
            lblTestDate.BackColor = Color.Transparent;
            lblTestDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTestDate.ForeColor = Color.Black;
            lblTestDate.Location = new Point(100, 61);
            lblTestDate.Name = "lblTestDate";
            lblTestDate.Size = new Size(30, 19);
            lblTestDate.TabIndex = 12;
            lblTestDate.Text = "date";
            // 
            // lblAttemt
            // 
            lblAttemt.BackColor = Color.Transparent;
            lblAttemt.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttemt.ForeColor = Color.Black;
            lblAttemt.Location = new Point(100, 103);
            lblAttemt.Name = "lblAttemt";
            lblAttemt.Size = new Size(10, 19);
            lblAttemt.TabIndex = 12;
            lblAttemt.Text = "1";
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.Transparent;
            lblResult.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.ForeColor = Color.Black;
            lblResult.Location = new Point(100, 81);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(45, 19);
            lblResult.TabIndex = 12;
            lblResult.Text = "Passed";
            // 
            // TeststatusButton
            // 
            TeststatusButton.BorderRadius = 12;
            TeststatusButton.CustomizableEdges = customizableEdges1;
            TeststatusButton.DisabledState.BorderColor = Color.DarkGray;
            TeststatusButton.DisabledState.CustomBorderColor = Color.DarkGray;
            TeststatusButton.DisabledState.FillColor = Color.Lime;
            TeststatusButton.DisabledState.ForeColor = Color.White;
            TeststatusButton.FillColor = Color.RosyBrown;
            TeststatusButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeststatusButton.ForeColor = Color.White;
            TeststatusButton.Location = new Point(133, 0);
            TeststatusButton.Name = "TeststatusButton";
            TeststatusButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            TeststatusButton.Size = new Size(74, 20);
            TeststatusButton.TabIndex = 11;
            TeststatusButton.Text = "Passed";
            // 
            // lblTestName
            // 
            lblTestName.AutoSize = false;
            lblTestName.BackColor = Color.Transparent;
            lblTestName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTestName.ForeColor = Color.Black;
            lblTestName.Location = new Point(58, 19);
            lblTestName.Name = "lblTestName";
            lblTestName.Size = new Size(144, 19);
            lblTestName.TabIndex = 9;
            lblTestName.Text = "Vision Test";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Black;
            guna2HtmlLabel3.Location = new Point(21, 105);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(45, 17);
            guna2HtmlLabel3.TabIndex = 8;
            guna2HtmlLabel3.Text = "Attemts";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(21, 83);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(35, 17);
            guna2HtmlLabel1.TabIndex = 8;
            guna2HtmlLabel1.Text = "Result";
            // 
            // lblTestDateName
            // 
            lblTestDateName.BackColor = Color.Transparent;
            lblTestDateName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTestDateName.ForeColor = Color.Black;
            lblTestDateName.Location = new Point(21, 61);
            lblTestDateName.Name = "lblTestDateName";
            lblTestDateName.Size = new Size(53, 17);
            lblTestDateName.TabIndex = 8;
            lblTestDateName.Text = "Test Date";
            // 
            // TestResultCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(guna2ShadowPanel1);
            Name = "TestResultCard";
            Size = new Size(224, 139);
            ((System.ComponentModel.ISupportInitialize)pbTestImage).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbTestImage;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestDateName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button TeststatusButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttemt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblResult;
    }
}
