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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            searchPanel = new Guna.UI2.WinForms.Guna2Panel();
            searchHeading = new Label();
            searchHint = new Label();
            searchByCaption = new Label();
            searchCaption = new Label();
            cbSearchBy = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            SearchButton = new Guna.UI2.WinForms.Guna2Button();
            statusBanner = new DVLD.WinForms.Shared.Controls.StatusBannerControl();
            applicantPanel = new Guna.UI2.WinForms.Guna2Panel();
            applicantHeading = new Label();
            personDivider = new Panel();
            personDetailControl1 = new DVLD.WinForms.Features.Persons.Detail.PersonDetailControl();
            selectionHintHeading = new Label();
            selectionHint = new Label();
            searchPanel.SuspendLayout();
            applicantPanel.SuspendLayout();
            SuspendLayout();
            // 
            // searchPanel
            // 
            searchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchPanel.BorderColor = Color.FromArgb(220, 230, 238);
            searchPanel.BorderRadius = 12;
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
            searchHeading.UseMnemonic = false;
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
            searchHint.UseMnemonic = false;
            // 
            // searchByCaption
            // 
            searchByCaption.BackColor = Color.Transparent;
            searchByCaption.Font = new Font("Segoe UI Semibold", 7.25F, FontStyle.Bold);
            searchByCaption.ForeColor = Color.FromArgb(71, 85, 105);
            searchByCaption.Location = new Point(16, 59);
            searchByCaption.Name = "searchByCaption";
            searchByCaption.Size = new Size(180, 16);
            searchByCaption.TabIndex = 2;
            searchByCaption.Text = "SEARCH BY";
            searchByCaption.UseMnemonic = false;
            // 
            // searchCaption
            // 
            searchCaption.BackColor = Color.Transparent;
            searchCaption.Font = new Font("Segoe UI Semibold", 7.25F, FontStyle.Bold);
            searchCaption.ForeColor = Color.FromArgb(71, 85, 105);
            searchCaption.Location = new Point(212, 59);
            searchCaption.Name = "searchCaption";
            searchCaption.Size = new Size(530, 16);
            searchCaption.TabIndex = 3;
            searchCaption.Text = "PERSON ID";
            searchCaption.UseMnemonic = false;
            // 
            // cbSearchBy
            // 
            cbSearchBy.BackColor = Color.Transparent;
            cbSearchBy.BorderColor = Color.FromArgb(203, 213, 225);
            cbSearchBy.BorderRadius = 8;
            cbSearchBy.CustomizableEdges = customizableEdges1;
            cbSearchBy.DrawMode = DrawMode.OwnerDrawFixed;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchBy.FillColor = Color.FromArgb(248, 250, 252);
            cbSearchBy.FocusedColor = Color.FromArgb(13, 148, 136);
            cbSearchBy.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            cbSearchBy.Font = new Font("Segoe UI", 9F);
            cbSearchBy.ForeColor = Color.FromArgb(15, 23, 42);
            cbSearchBy.ItemHeight = 30;
            cbSearchBy.Location = new Point(16, 80);
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbSearchBy.Size = new Size(180, 36);
            cbSearchBy.TabIndex = 0;
            cbSearchBy.SelectedIndexChanged += cbSearchBy_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderColor = Color.FromArgb(203, 213, 225);
            txtSearch.BorderRadius = 8;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(248, 250, 252);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtSearch.FocusedState.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearch.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtSearch.Location = new Point(212, 80);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
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
            SearchButton.BorderColor = Color.FromArgb(13, 148, 136);
            SearchButton.BorderRadius = 8;
            SearchButton.BorderThickness = 1;
            SearchButton.Cursor = Cursors.Hand;
            SearchButton.CustomizableEdges = customizableEdges5;
            SearchButton.DisabledState.BorderColor = Color.FromArgb(203, 213, 225);
            SearchButton.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            SearchButton.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            SearchButton.FillColor = Color.FromArgb(13, 148, 136);
            SearchButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            SearchButton.ForeColor = Color.White;
            SearchButton.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            SearchButton.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            SearchButton.Location = new Point(842, 80);
            SearchButton.Name = "SearchButton";
            SearchButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            SearchButton.Size = new Size(128, 36);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.Click += SearchButton_Click;
            // 
            // statusBanner
            // 
            statusBanner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusBanner.BackColor = Color.Transparent;
            statusBanner.Description = "Search for an applicant above.";
            statusBanner.Font = new Font("Segoe UI", 9F);
            statusBanner.Location = new Point(550, 152);
            statusBanner.Margin = new Padding(0);
            statusBanner.Name = "statusBanner";
            statusBanner.Size = new Size(420, 60);
            statusBanner.TabIndex = 4;
            statusBanner.Title = "Search unsuccessful";
            statusBanner.Tone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Danger;
            statusBanner.Visible = false;
            // 
            // applicantPanel
            // 
            applicantPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            applicantPanel.BorderColor = Color.FromArgb(220, 230, 238);
            applicantPanel.BorderRadius = 12;
            applicantPanel.BorderThickness = 1;
            applicantPanel.Controls.Add(applicantHeading);
            applicantPanel.Controls.Add(personDivider);
            applicantPanel.Controls.Add(personDetailControl1);
            applicantPanel.Controls.Add(selectionHintHeading);
            applicantPanel.Controls.Add(selectionHint);
            applicantPanel.Controls.Add(statusBanner);
            applicantPanel.CustomizableEdges = customizableEdges11;
            applicantPanel.FillColor = Color.White;
            applicantPanel.Location = new Point(0, 134);
            applicantPanel.Margin = new Padding(0);
            applicantPanel.Name = "applicantPanel";
            applicantPanel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            applicantPanel.Size = new Size(986, 313);
            applicantPanel.TabIndex = 1;
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
            applicantHeading.UseMnemonic = false;
            // 
            // personDivider
            // 
            personDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            personDivider.BackColor = Color.FromArgb(226, 232, 240);
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
            selectionHintHeading.Location = new Point(550, 56);
            selectionHintHeading.Name = "selectionHintHeading";
            selectionHintHeading.Size = new Size(420, 24);
            selectionHintHeading.TabIndex = 2;
            selectionHintHeading.Text = "Before you continue";
            selectionHintHeading.UseMnemonic = false;
            // 
            // selectionHint
            // 
            selectionHint.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectionHint.BackColor = Color.Transparent;
            selectionHint.Font = new Font("Segoe UI", 10F);
            selectionHint.ForeColor = Color.FromArgb(100, 116, 139);
            selectionHint.Location = new Point(550, 86);
            selectionHint.Name = "selectionHint";
            selectionHint.Size = new Size(420, 54);
            selectionHint.TabIndex = 3;
            selectionHint.Text = "Check the applicant's identity and contact details before continuing to licence class selection.";
            selectionHint.UseMnemonic = false;
            // 
            // SelectPersonControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(applicantPanel);
            Controls.Add(searchPanel);
            Font = new Font("Segoe UI", 9F);
            Name = "SelectPersonControl";
            Size = new Size(986, 447);
            searchPanel.ResumeLayout(false);
            applicantPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DVLD.WinForms.Shared.Controls.StatusBannerControl statusBanner;
        private Guna.UI2.WinForms.Guna2Panel searchPanel;
        private Label searchHeading;
        private Label searchHint;
        private Label searchByCaption;
        private Label searchCaption;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBy;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button SearchButton;
        private Guna.UI2.WinForms.Guna2Panel applicantPanel;
        private Label applicantHeading;
        private Panel personDivider;
        private DVLD.WinForms.Features.Persons.Detail.PersonDetailControl personDetailControl1;
        private Label selectionHintHeading;
        private Label selectionHint;
    }
}
