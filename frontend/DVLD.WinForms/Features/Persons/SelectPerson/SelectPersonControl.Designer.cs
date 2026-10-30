namespace DVLD.WinForms.Features.Persons.SelectPerson
{
    partial class SelectPersonControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            contentLayout = new TableLayoutPanel();
            searchPanel = new Guna.UI2.WinForms.Guna2Panel();
            searchHeading = new Label();
            searchHint = new Label();
            searchByCaption = new Label();
            searchCaption = new Label();
            cbSearchBy = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            SearchButton = new Guna.UI2.WinForms.Guna2GradientButton();
            messagePanel = new Guna.UI2.WinForms.Guna2Panel();
            messageIcon = new Label();
            messageHeading = new Label();
            lblMessage = new Label();
            applicantPanel = new Guna.UI2.WinForms.Guna2Panel();
            applicantHeading = new Label();
            personDivider = new Panel();
            personDetailControl1 = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();
            selectionHintHeading = new Label();
            selectionHint = new Label();
            contentLayout.SuspendLayout();
            searchPanel.SuspendLayout();
            messagePanel.SuspendLayout();
            applicantPanel.SuspendLayout();
            SuspendLayout();
            // 
            // contentLayout
            // 
            contentLayout.AutoSize = true;
            contentLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            contentLayout.ColumnCount = 1;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(searchPanel, 0, 0);
            contentLayout.Controls.Add(messagePanel, 0, 1);
            contentLayout.Controls.Add(applicantPanel, 0, 2);
            contentLayout.Dock = DockStyle.Top;
            contentLayout.Location = new Point(0, 0);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 3;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            contentLayout.RowStyles.Add(new RowStyle());
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 325F));
            contentLayout.Size = new Size(986, 527);
            contentLayout.TabIndex = 0;
            // 
            // searchPanel
            // 
            searchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchPanel.BorderColor = Color.FromArgb(219, 229, 242);
            searchPanel.BorderRadius = 8;
            searchPanel.BorderThickness = 1;
            searchPanel.Controls.Add(searchHeading);
            searchPanel.Controls.Add(searchHint);
            searchPanel.Controls.Add(searchByCaption);
            searchPanel.Controls.Add(searchCaption);
            searchPanel.Controls.Add(cbSearchBy);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(SearchButton);
            searchPanel.CustomizableEdges = customizableEdges7;
            searchPanel.FillColor = Color.White;
            searchPanel.Location = new Point(0, 0);
            searchPanel.Margin = new Padding(0);
            searchPanel.Name = "searchPanel";
            searchPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            searchPanel.Size = new Size(986, 122);
            searchPanel.TabIndex = 0;
            // 
            // searchHeading
            // 
            searchHeading.BackColor = Color.Transparent;
            searchHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            searchHeading.ForeColor = Color.FromArgb(15, 23, 42);
            searchHeading.Location = new Point(16, 10);
            searchHeading.Name = "searchHeading";
            searchHeading.Size = new Size(250, 24);
            searchHeading.TabIndex = 0;
            searchHeading.Text = "Find a person";
            // 
            // searchHint
            // 
            searchHint.BackColor = Color.Transparent;
            searchHint.ForeColor = Color.FromArgb(100, 116, 139);
            searchHint.Location = new Point(16, 35);
            searchHint.Name = "searchHint";
            searchHint.Size = new Size(700, 18);
            searchHint.TabIndex = 1;
            searchHint.Text = "Search by person ID or national number.";
            // 
            // searchByCaption
            // 
            searchByCaption.BackColor = Color.Transparent;
            searchByCaption.ForeColor = Color.FromArgb(100, 116, 139);
            searchByCaption.Location = new Point(16, 58);
            searchByCaption.Name = "searchByCaption";
            searchByCaption.Size = new Size(180, 18);
            searchByCaption.TabIndex = 2;
            searchByCaption.Text = "Search by";
            // 
            // searchCaption
            // 
            searchCaption.BackColor = Color.Transparent;
            searchCaption.ForeColor = Color.FromArgb(100, 116, 139);
            searchCaption.Location = new Point(212, 58);
            searchCaption.Name = "searchCaption";
            searchCaption.Size = new Size(530, 18);
            searchCaption.TabIndex = 3;
            searchCaption.Text = "Person ID or national number";
            // 
            // cbSearchBy
            // 
            cbSearchBy.BackColor = Color.Transparent;
            cbSearchBy.BorderColor = Color.FromArgb(219, 229, 242);
            cbSearchBy.BorderRadius = 5;
            cbSearchBy.CustomizableEdges = customizableEdges1;
            cbSearchBy.DrawMode = DrawMode.OwnerDrawFixed;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FocusedColor = Color.FromArgb(37, 99, 235);
            cbSearchBy.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            cbSearchBy.Font = new Font("Segoe UI", 9F);
            cbSearchBy.ForeColor = Color.FromArgb(15, 23, 42);
            cbSearchBy.ItemHeight = 30;
            cbSearchBy.Location = new Point(16, 80);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbSearchBy.Size = new Size(180, 36);
            cbSearchBy.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderColor = Color.FromArgb(219, 229, 242);
            txtSearch.BorderRadius = 5;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearch.Location = new Point(212, 80);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter person ID or national number";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(614, 36);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.BorderRadius = 6;
            SearchButton.CustomizableEdges = customizableEdges5;
            SearchButton.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            SearchButton.DisabledState.FillColor2 = Color.FromArgb(226, 232, 240);
            SearchButton.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            SearchButton.FillColor = Color.FromArgb(37, 99, 235);
            SearchButton.FillColor2 = Color.FromArgb(37, 99, 235);
            SearchButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SearchButton.ForeColor = Color.White;
            SearchButton.Location = new Point(842, 80);
            SearchButton.Name = "SearchButton";
            SearchButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            SearchButton.Size = new Size(128, 36);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.Click += SearchButton_Click;
            // 
            // messagePanel
            // 
            messagePanel.AccessibleRole = AccessibleRole.Alert;
            messagePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            messagePanel.BorderColor = Color.FromArgb(254, 202, 202);
            messagePanel.BorderRadius = 8;
            messagePanel.BorderThickness = 1;
            messagePanel.Controls.Add(messageIcon);
            messagePanel.Controls.Add(messageHeading);
            messagePanel.Controls.Add(lblMessage);
            messagePanel.CustomizableEdges = customizableEdges9;
            messagePanel.FillColor = Color.FromArgb(254, 242, 242);
            messagePanel.Location = new Point(0, 134);
            messagePanel.Margin = new Padding(0, 12, 0, 0);
            messagePanel.Name = "messagePanel";
            messagePanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            messagePanel.Size = new Size(986, 68);
            messagePanel.TabIndex = 1;
            messagePanel.Visible = false;
            messagePanel.SizeChanged += MessagePanel_SizeChanged;
            // 
            // messageIcon
            // 
            messageIcon.BackColor = Color.Transparent;
            messageIcon.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            messageIcon.ForeColor = Color.FromArgb(185, 28, 28);
            messageIcon.Location = new Point(12, 12);
            messageIcon.Name = "messageIcon";
            messageIcon.Size = new Size(32, 36);
            messageIcon.TabIndex = 0;
            messageIcon.Text = "!";
            messageIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // messageHeading
            // 
            messageHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            messageHeading.BackColor = Color.Transparent;
            messageHeading.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            messageHeading.ForeColor = Color.FromArgb(153, 27, 27);
            messageHeading.Location = new Point(52, 10);
            messageHeading.Name = "messageHeading";
            messageHeading.Size = new Size(918, 22);
            messageHeading.TabIndex = 1;
            messageHeading.Text = "Search unsuccessful";
            messageHeading.UseMnemonic = false;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Segoe UI", 9.5F);
            lblMessage.ForeColor = Color.FromArgb(185, 28, 28);
            lblMessage.Location = new Point(52, 34);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(918, 22);
            lblMessage.TabIndex = 2;
            lblMessage.UseMnemonic = false;
            // 
            // applicantPanel
            // 
            applicantPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            applicantPanel.BorderColor = Color.FromArgb(219, 229, 242);
            applicantPanel.BorderRadius = 8;
            applicantPanel.BorderThickness = 1;
            applicantPanel.Controls.Add(applicantHeading);
            applicantPanel.Controls.Add(personDivider);
            applicantPanel.Controls.Add(personDetailControl1);
            applicantPanel.Controls.Add(selectionHintHeading);
            applicantPanel.Controls.Add(selectionHint);
            applicantPanel.CustomizableEdges = customizableEdges11;
            applicantPanel.FillColor = Color.White;
            applicantPanel.Location = new Point(0, 214);
            applicantPanel.Margin = new Padding(0, 12, 0, 0);
            applicantPanel.Name = "applicantPanel";
            applicantPanel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            applicantPanel.Size = new Size(986, 313);
            applicantPanel.TabIndex = 2;
            // 
            // applicantHeading
            // 
            applicantHeading.BackColor = Color.Transparent;
            applicantHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            applicantHeading.ForeColor = Color.FromArgb(15, 23, 42);
            applicantHeading.Location = new Point(16, 10);
            applicantHeading.Name = "applicantHeading";
            applicantHeading.Size = new Size(360, 24);
            applicantHeading.TabIndex = 0;
            applicantHeading.Text = "Applicant information";
            // 
            // personDivider
            // 
            personDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            personDivider.BackColor = Color.FromArgb(231, 237, 246);
            personDivider.Location = new Point(1, 40);
            personDivider.Name = "personDivider";
            personDivider.Size = new Size(984, 1);
            personDivider.TabIndex = 1;
            // 
            // personDetailControl1
            // 
            personDetailControl1.BackColor = Color.White;
            personDetailControl1.Location = new Point(17, 43);
            personDetailControl1.Name = "personDetailControl1";
            personDetailControl1.Size = new Size(520, 265);
            personDetailControl1.TabIndex = 0;
            // 
            // selectionHintHeading
            // 
            selectionHintHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectionHintHeading.BackColor = Color.Transparent;
            selectionHintHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            selectionHintHeading.ForeColor = Color.FromArgb(15, 23, 42);
            selectionHintHeading.Location = new Point(568, 66);
            selectionHintHeading.Name = "selectionHintHeading";
            selectionHintHeading.Size = new Size(402, 24);
            selectionHintHeading.TabIndex = 2;
            selectionHintHeading.Text = "Before you continue";
            // 
            // selectionHint
            // 
            selectionHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectionHint.BackColor = Color.Transparent;
            selectionHint.Font = new Font("Segoe UI", 10F);
            selectionHint.ForeColor = Color.FromArgb(100, 116, 139);
            selectionHint.Location = new Point(568, 100);
            selectionHint.Name = "selectionHint";
            selectionHint.Size = new Size(402, 64);
            selectionHint.TabIndex = 3;
            selectionHint.Text = "Check the applicant's identity and contact details before continuing to licence class selection.";
            // 
            // SelectPersonControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(246, 249, 253);
            Controls.Add(contentLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "SelectPersonControl";
            Size = new Size(986, 447);
            contentLayout.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            messagePanel.ResumeLayout(false);
            applicantPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel contentLayout;
        private Guna.UI2.WinForms.Guna2Panel messagePanel;
        private Label messageIcon;
        private Label messageHeading;
        private Guna.UI2.WinForms.Guna2Panel searchPanel;
        private Label searchHeading;
        private Label searchHint;
        private Label searchByCaption;
        private Label searchCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBy;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2GradientButton SearchButton;
        private Guna.UI2.WinForms.Guna2Panel applicantPanel;
        private Label applicantHeading;
        private Panel personDivider;
        private DVLD.WinForms.Features.Persons.Detail.PersonDetailControl personDetailControl1;
        private Label selectionHintHeading;
        private Label selectionHint;
        private Label lblMessage;
    }
}
