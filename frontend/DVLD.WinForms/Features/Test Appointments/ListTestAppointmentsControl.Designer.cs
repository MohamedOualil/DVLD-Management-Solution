namespace DVLD.WinForms.Features.Test_Appointments
{
    partial class ListTestAppointmentsControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListTestAppointmentsControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            TestAppointmentsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            TestAppointmentId = new DataGridViewTextBoxColumn();
            AppointmentDate = new DataGridViewTextBoxColumn();
            TestStatus = new DataGridViewTextBoxColumn();
            PaidFees = new DataGridViewTextBoxColumn();
            TestResult = new DataGridViewTextBoxColumn();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            CreateAppointmentButton = new Guna.UI2.WinForms.Guna2GradientButton();
            pictureBox3 = new PictureBox();
            guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)TestAppointmentsDataGridView).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // TestAppointmentsDataGridView
            // 
            TestAppointmentsDataGridView.AllowUserToAddRows = false;
            TestAppointmentsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            TestAppointmentsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            TestAppointmentsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            TestAppointmentsDataGridView.ColumnHeadersHeight = 30;
            TestAppointmentsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TestAppointmentsDataGridView.Columns.AddRange(new DataGridViewColumn[] { TestAppointmentId, AppointmentDate, TestStatus, PaidFees, TestResult });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            TestAppointmentsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            TestAppointmentsDataGridView.GridColor = Color.FromArgb(233, 236, 239);
            TestAppointmentsDataGridView.Location = new Point(3, 74);
            TestAppointmentsDataGridView.MultiSelect = false;
            TestAppointmentsDataGridView.Name = "TestAppointmentsDataGridView";
            TestAppointmentsDataGridView.ReadOnly = true;
            TestAppointmentsDataGridView.RowHeadersVisible = false;
            TestAppointmentsDataGridView.RowTemplate.Height = 30;
            TestAppointmentsDataGridView.Size = new Size(970, 296);
            TestAppointmentsDataGridView.TabIndex = 1;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            TestAppointmentsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            TestAppointmentsDataGridView.ThemeStyle.BackColor = Color.White;
            TestAppointmentsDataGridView.ThemeStyle.GridColor = Color.FromArgb(233, 236, 239);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(37, 99, 235);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            TestAppointmentsDataGridView.ThemeStyle.HeaderStyle.Height = 30;
            TestAppointmentsDataGridView.ThemeStyle.ReadOnly = true;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.Height = 30;
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            TestAppointmentsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // TestAppointmentId
            // 
            TestAppointmentId.FillWeight = 90F;
            TestAppointmentId.HeaderText = "Appointments ID";
            TestAppointmentId.Name = "TestAppointmentId";
            TestAppointmentId.ReadOnly = true;
            // 
            // AppointmentDate
            // 
            AppointmentDate.HeaderText = "Appointment Date";
            AppointmentDate.Name = "AppointmentDate";
            AppointmentDate.ReadOnly = true;
            // 
            // TestStatus
            // 
            TestStatus.HeaderText = "Status";
            TestStatus.Name = "TestStatus";
            TestStatus.ReadOnly = true;
            TestStatus.Resizable = DataGridViewTriState.True;
            TestStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // PaidFees
            // 
            PaidFees.HeaderText = "Paid Fees";
            PaidFees.Name = "PaidFees";
            PaidFees.ReadOnly = true;
            // 
            // TestResult
            // 
            TestResult.HeaderText = "Result";
            TestResult.Name = "TestResult";
            TestResult.ReadOnly = true;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblMessage);
            guna2ShadowPanel1.Controls.Add(CreateAppointmentButton);
            guna2ShadowPanel1.Controls.Add(pictureBox3);
            guna2ShadowPanel1.Controls.Add(guna2HtmlLabel8);
            guna2ShadowPanel1.Controls.Add(TestAppointmentsDataGridView);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(11, 252);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 6;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 50;
            guna2ShadowPanel1.Size = new Size(976, 373);
            guna2ShadowPanel1.TabIndex = 2;
            // 
            // CreateAppointmentButton
            // 
            CreateAppointmentButton.BorderRadius = 10;
            CreateAppointmentButton.CustomizableEdges = customizableEdges1;
            CreateAppointmentButton.DisabledState.BorderColor = Color.DarkGray;
            CreateAppointmentButton.DisabledState.CustomBorderColor = Color.DarkGray;
            CreateAppointmentButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CreateAppointmentButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            CreateAppointmentButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CreateAppointmentButton.FillColor = Color.Transparent;
            CreateAppointmentButton.FillColor2 = Color.Transparent;
            CreateAppointmentButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CreateAppointmentButton.ForeColor = Color.FromArgb(37, 99, 235);
            CreateAppointmentButton.Image = (Image)resources.GetObject("CreateAppointmentButton.Image");
            CreateAppointmentButton.ImageAlign = HorizontalAlignment.Left;
            CreateAppointmentButton.ImageOffset = new Point(-3, 0);
            CreateAppointmentButton.Location = new Point(777, 19);
            CreateAppointmentButton.Name = "CreateAppointmentButton";
            CreateAppointmentButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            CreateAppointmentButton.Size = new Size(180, 35);
            CreateAppointmentButton.TabIndex = 11;
            CreateAppointmentButton.Text = "   New Appointment";
            CreateAppointmentButton.Click += CreateAppointmentButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(18, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel8.ForeColor = Color.Black;
            guna2HtmlLabel8.Location = new Point(54, 12);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(203, 30);
            guna2HtmlLabel8.TabIndex = 9;
            guna2HtmlLabel8.Text = "Appointment History";
            // 
            // lblMessage
            // 
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.FromArgb(37, 99, 235);
            lblMessage.Location = new Point(436, 187);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(64, 22);
            lblMessage.TabIndex = 12;
            lblMessage.Text = "Message";
            lblMessage.Visible = false;
            // 
            // ListTestAppointmentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel1);
            Name = "ListTestAppointmentsControl";
            Size = new Size(1003, 637);
            ((System.ComponentModel.ISupportInitialize)TestAppointmentsDataGridView).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView TestAppointmentsDataGridView;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2GradientButton CreateAppointmentButton;
        private DataGridViewTextBoxColumn TestAppointmentId;
        private DataGridViewTextBoxColumn AppointmentDate;
        private DataGridViewTextBoxColumn TestStatus;
        private DataGridViewTextBoxColumn PaidFees;
        private DataGridViewTextBoxColumn TestResult;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMessage;
    }
}
