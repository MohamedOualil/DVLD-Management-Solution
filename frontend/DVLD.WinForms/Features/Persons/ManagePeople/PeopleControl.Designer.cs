namespace DVLD.WinForms.Features.Persons.ManagePeople
{
    partial class PeopleControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle altRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle idStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle natStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle nameStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle genderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dobStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle phoneStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle emailStyle = new DataGridViewCellStyle();

            pageLayout = new TableLayoutPanel();
            pageHeader = new DVLD.WinForms.Shared.Controls.PageHeaderControl();
            filterBar = new DVLD.WinForms.Shared.Controls.DirectoryFilterBarControl();
            gridCard = new Guna.UI2.WinForms.Guna2Panel();
            gridHost = new Panel();
            peopleGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            colPersonId = new DataGridViewTextBoxColumn();
            colNationalNo = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colDateOfBirth = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colViewCard = new DataGridViewLinkColumn();
            colEditPerson = new DataGridViewLinkColumn();
            lblEmptyState = new Label();
            paginationBar = new DVLD.WinForms.Shared.Controls.PaginationBarControl();

            pageLayout.SuspendLayout();
            gridCard.SuspendLayout();
            gridHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)peopleGrid).BeginInit();
            SuspendLayout();

            // 
            // pageLayout
            // 
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(pageHeader, 0, 0);
            pageLayout.Controls.Add(filterBar, 0, 2);
            pageLayout.Controls.Add(gridCard, 0, 4);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Location = new Point(0, 0);
            pageLayout.Margin = new Padding(0);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(16);
            pageLayout.RowCount = 5;
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.Size = new Size(1003, 637);
            pageLayout.TabIndex = 0;

            // 
            // pageHeader
            // 
            pageHeader.BackColor = Color.Transparent;
            pageHeader.BadgeText = "● Citizen Registry";
            pageHeader.BadgeTone = DVLD.WinForms.Shared.Controls.HeaderBadgeTone.Info;
            pageHeader.Dock = DockStyle.Fill;
            pageHeader.Font = new Font("Segoe UI", 9F);
            pageHeader.IconText = "PP";
            pageHeader.Location = new Point(16, 16);
            pageHeader.Margin = new Padding(0);
            pageHeader.Name = "pageHeader";
            pageHeader.ShowBackButton = false;
            pageHeader.Size = new Size(971, 68);
            pageHeader.Subtitle = "Register, search, inspect, and update citizen identity records";
            pageHeader.TabIndex = 0;
            pageHeader.Title = "People Directory";

            // 
            // filterBar
            // 
            filterBar.BackColor = Color.Transparent;
            filterBar.CountText = "0 people";
            filterBar.Dock = DockStyle.Fill;
            filterBar.Font = new Font("Segoe UI", 9F);
            filterBar.Location = new Point(16, 94);
            filterBar.Margin = new Padding(0);
            filterBar.Name = "filterBar";
            filterBar.PrimaryButtonText = "+ Add Person";
            filterBar.SearchPlaceholder = "Search by name, national no, phone, or email...";
            filterBar.ShowFilterCombo = true;
            filterBar.ShowPrimaryButton = true;
            filterBar.Size = new Size(971, 60);
            filterBar.TabIndex = 1;

            // 
            // gridCard
            // 
            gridCard.BackColor = Color.Transparent;
            gridCard.BorderColor = Color.FromArgb(220, 230, 238);
            gridCard.BorderRadius = 12;
            gridCard.BorderThickness = 1;
            gridCard.Controls.Add(gridHost);
            gridCard.Controls.Add(paginationBar);
            gridCard.CustomizableEdges = customizableEdges1;
            gridCard.Dock = DockStyle.Fill;
            gridCard.FillColor = Color.White;
            gridCard.Location = new Point(16, 164);
            gridCard.Margin = new Padding(0);
            gridCard.Name = "gridCard";
            gridCard.Padding = new Padding(1, 4, 1, 1);
            gridCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            gridCard.Size = new Size(971, 457);
            gridCard.TabIndex = 2;

            // 
            // gridHost
            // 
            gridHost.BackColor = Color.White;
            gridHost.Controls.Add(lblEmptyState);
            gridHost.Controls.Add(peopleGrid);
            gridHost.Dock = DockStyle.Fill;
            gridHost.Location = new Point(1, 4);
            gridHost.Name = "gridHost";
            gridHost.Size = new Size(969, 406);
            gridHost.TabIndex = 0;

            // 
            // peopleGrid
            // 
            peopleGrid.AllowUserToAddRows = false;
            peopleGrid.AllowUserToDeleteRows = false;
            peopleGrid.AllowUserToResizeRows = false;
            altRowStyle.BackColor = Color.FromArgb(248, 250, 252);
            peopleGrid.AlternatingRowsDefaultCellStyle = altRowStyle;
            peopleGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            peopleGrid.BackgroundColor = Color.White;
            peopleGrid.BorderStyle = BorderStyle.None;
            peopleGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            peopleGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.Padding = new Padding(10, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);
            headerStyle.WrapMode = DataGridViewTriState.False;
            peopleGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            peopleGrid.ColumnHeadersHeight = 40;
            peopleGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            peopleGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                colPersonId,
                colNationalNo,
                colFullName,
                colGender,
                colDateOfBirth,
                colPhone,
                colEmail,
                colViewCard,
                colEditPerson
            });

            defaultStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = Color.White;
            defaultStyle.Font = new Font("Segoe UI", 9F);
            defaultStyle.ForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.Padding = new Padding(10, 0, 0, 0);
            defaultStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            defaultStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            defaultStyle.WrapMode = DataGridViewTriState.False;
            peopleGrid.DefaultCellStyle = defaultStyle;

            peopleGrid.Dock = DockStyle.Fill;
            peopleGrid.EnableHeadersVisualStyles = false;
            peopleGrid.GridColor = Color.FromArgb(241, 245, 249);
            peopleGrid.Location = new Point(0, 0);
            peopleGrid.MultiSelect = false;
            peopleGrid.Name = "peopleGrid";
            peopleGrid.ReadOnly = true;
            peopleGrid.RowHeadersVisible = false;
            peopleGrid.RowTemplate.Height = 44;
            peopleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            peopleGrid.Size = new Size(969, 406);
            peopleGrid.TabIndex = 0;
            peopleGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 250, 252);
            peopleGrid.ThemeStyle.BackColor = Color.White;
            peopleGrid.ThemeStyle.GridColor = Color.FromArgb(241, 245, 249);
            peopleGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            peopleGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            peopleGrid.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(100, 116, 139);
            peopleGrid.ThemeStyle.HeaderStyle.Height = 40;
            peopleGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            peopleGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            peopleGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            peopleGrid.ThemeStyle.RowsStyle.Height = 44;
            peopleGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(240, 253, 250);
            peopleGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            idStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            idStyle.ForeColor = Color.FromArgb(15, 23, 42);
            colPersonId.DefaultCellStyle = idStyle;
            colPersonId.FillWeight = 62F;
            colPersonId.HeaderText = "ID";
            colPersonId.Name = "PersonId";
            colPersonId.ReadOnly = true;

            natStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            natStyle.ForeColor = Color.FromArgb(15, 118, 110);
            colNationalNo.DefaultCellStyle = natStyle;
            colNationalNo.FillWeight = 95F;
            colNationalNo.HeaderText = "NATIONAL NO";
            colNationalNo.Name = "NationalNo";
            colNationalNo.ReadOnly = true;

            nameStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            nameStyle.ForeColor = Color.FromArgb(15, 23, 42);
            colFullName.DefaultCellStyle = nameStyle;
            colFullName.FillWeight = 165F;
            colFullName.HeaderText = "FULL NAME";
            colFullName.Name = "FullName";
            colFullName.ReadOnly = true;

            genderStyle.ForeColor = Color.FromArgb(71, 85, 105);
            colGender.DefaultCellStyle = genderStyle;
            colGender.FillWeight = 72F;
            colGender.HeaderText = "GENDER";
            colGender.Name = "Gender";
            colGender.ReadOnly = true;

            dobStyle.Format = "dd MMM yyyy";
            dobStyle.ForeColor = Color.FromArgb(71, 85, 105);
            colDateOfBirth.DefaultCellStyle = dobStyle;
            colDateOfBirth.FillWeight = 95F;
            colDateOfBirth.HeaderText = "BIRTH DATE";
            colDateOfBirth.Name = "DateOfBirth";
            colDateOfBirth.ReadOnly = true;

            phoneStyle.ForeColor = Color.FromArgb(51, 65, 85);
            colPhone.DefaultCellStyle = phoneStyle;
            colPhone.FillWeight = 100F;
            colPhone.HeaderText = "PHONE";
            colPhone.Name = "Phone";
            colPhone.ReadOnly = true;

            emailStyle.ForeColor = Color.FromArgb(100, 116, 139);
            colEmail.DefaultCellStyle = emailStyle;
            colEmail.FillWeight = 135F;
            colEmail.HeaderText = "EMAIL";
            colEmail.Name = "Email";
            colEmail.ReadOnly = true;

            colViewCard.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            colViewCard.FillWeight = 78F;
            colViewCard.HeaderText = "PROFILE";
            colViewCard.LinkBehavior = LinkBehavior.HoverUnderline;
            colViewCard.LinkColor = Color.FromArgb(13, 148, 136);
            colViewCard.Name = "ViewCard";
            colViewCard.ReadOnly = true;
            colViewCard.Text = "View Card";
            colViewCard.TrackVisitedState = false;
            colViewCard.UseColumnTextForLinkValue = true;

            colEditPerson.ActiveLinkColor = Color.FromArgb(15, 118, 110);
            colEditPerson.FillWeight = 62F;
            colEditPerson.HeaderText = "EDIT";
            colEditPerson.LinkBehavior = LinkBehavior.HoverUnderline;
            colEditPerson.LinkColor = Color.FromArgb(13, 148, 136);
            colEditPerson.Name = "EditPerson";
            colEditPerson.ReadOnly = true;
            colEditPerson.Text = "Edit";
            colEditPerson.TrackVisitedState = false;
            colEditPerson.UseColumnTextForLinkValue = true;

            // 
            // lblEmptyState
            // 
            lblEmptyState.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmptyState.BackColor = Color.Transparent;
            lblEmptyState.Font = new Font("Segoe UI", 10F);
            lblEmptyState.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyState.Location = new Point(24, 150);
            lblEmptyState.Name = "lblEmptyState";
            lblEmptyState.Size = new Size(921, 60);
            lblEmptyState.TabIndex = 1;
            lblEmptyState.Text = "No citizen records loaded yet.";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.UseMnemonic = false;
            lblEmptyState.Visible = false;

            // 
            // paginationBar
            // 
            paginationBar.BackColor = Color.FromArgb(248, 250, 252);
            paginationBar.Dock = DockStyle.Bottom;
            paginationBar.Font = new Font("Segoe UI", 9F);
            paginationBar.ItemLabel = "people";
            paginationBar.Location = new Point(1, 410);
            paginationBar.Name = "paginationBar";
            paginationBar.Size = new Size(969, 46);
            paginationBar.TabIndex = 1;

            // 
            // PeopleControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 249);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Name = "PeopleControl";
            Size = new Size(1003, 637);
            Load += PeopleControl_Load;
            pageLayout.ResumeLayout(false);
            gridCard.ResumeLayout(false);
            gridHost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)peopleGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private Shared.Controls.PageHeaderControl pageHeader;
        private Shared.Controls.DirectoryFilterBarControl filterBar;
        private Guna.UI2.WinForms.Guna2Panel gridCard;
        private Panel gridHost;
        private Guna.UI2.WinForms.Guna2DataGridView peopleGrid;
        private DataGridViewTextBoxColumn colPersonId;
        private DataGridViewTextBoxColumn colNationalNo;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colDateOfBirth;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewLinkColumn colViewCard;
        private DataGridViewLinkColumn colEditPerson;
        private Label lblEmptyState;
        private Shared.Controls.PaginationBarControl paginationBar;
    }
}
