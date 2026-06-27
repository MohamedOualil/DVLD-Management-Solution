namespace DVLD.WinForms.Features.Persons.SelectPerson
{
    partial class SelectPersonControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPersonControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            personDetailControl1 = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            cbSearchBy = new Guna.UI2.WinForms.Guna2ComboBox();
            SearchButton = new Guna.UI2.WinForms.Guna2GradientButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // personDetailControl1
            // 
            personDetailControl1.Location = new Point(20, 170);
            personDetailControl1.Name = "personDetailControl1";
            personDetailControl1.Size = new Size(520, 265);
            personDetailControl1.TabIndex = 0;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(cbSearchBy);
            guna2ShadowPanel1.Controls.Add(SearchButton);
            guna2ShadowPanel1.Controls.Add(txtSearch);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(20, 30);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(949, 134);
            guna2ShadowPanel1.TabIndex = 1;
            // 
            // cbSearchBy
            // 
            cbSearchBy.BackColor = Color.Transparent;
            cbSearchBy.BorderColor = Color.FromArgb(213, 218, 225);
            cbSearchBy.BorderRadius = 15;
            cbSearchBy.CustomizableEdges = customizableEdges1;
            cbSearchBy.DrawMode = DrawMode.OwnerDrawFixed;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FocusedColor = Color.FromArgb(37, 99, 235);
            cbSearchBy.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            cbSearchBy.Font = new Font("Segoe UI", 10F);
            cbSearchBy.ForeColor = Color.FromArgb(15, 23, 42);
            cbSearchBy.ItemHeight = 30;
            cbSearchBy.Location = new Point(430, 58);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbSearchBy.Size = new Size(125, 36);
            cbSearchBy.TabIndex = 7;
            // 
            // SearchButton
            // 
            SearchButton.BorderRadius = 10;
            SearchButton.CustomizableEdges = customizableEdges3;
            SearchButton.DisabledState.BorderColor = Color.DarkGray;
            SearchButton.DisabledState.CustomBorderColor = Color.DarkGray;
            SearchButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            SearchButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            SearchButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            SearchButton.FillColor = Color.FromArgb(37, 99, 235);
            SearchButton.FillColor2 = Color.FromArgb(37, 120, 235);
            SearchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SearchButton.ForeColor = Color.White;
            SearchButton.ImageAlign = HorizontalAlignment.Left;
            SearchButton.ImageOffset = new Point(-3, 0);
            SearchButton.Location = new Point(598, 58);
            SearchButton.Name = "SearchButton";
            SearchButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            SearchButton.Size = new Size(74, 40);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.Click += SearchButton_Click;
            // 
            // txtSearch
            // 
            txtSearch.AutoRoundedCorners = true;
            txtSearch.BorderRadius = 19;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges5;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconLeft = (Image)resources.GetObject("txtSearch.IconLeft");
            txtSearch.IconLeftOffset = new Point(5, 0);
            txtSearch.IconLeftSize = new Size(15, 15);
            txtSearch.Location = new Point(22, 54);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search ID or Name";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSearch.Size = new Size(384, 40);
            txtSearch.TabIndex = 5;
            txtSearch.TextOffset = new Point(5, 0);
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = false;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.LightCoral;
            lblMessage.Location = new Point(618, 191);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(368, 227);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "Message";
            lblMessage.Visible = false;
            // 
            // SelectPersonControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMessage);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(personDetailControl1);
            Name = "SelectPersonControl";
            Size = new Size(1003, 447);
            guna2ShadowPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Detail.PersonDetailControl personDetailControl1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2GradientButton SearchButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMessage;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBy;
    }
}
