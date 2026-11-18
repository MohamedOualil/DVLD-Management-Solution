namespace DVLD.WinForms.Shared.Controls
{
    partial class DirectoryFilterBarControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            filterCard = new Guna.UI2.WinForms.Guna2Panel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            cmbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            lblCountBadge = new Guna.UI2.WinForms.Guna2Button();
            btnPrimaryAction = new Guna.UI2.WinForms.Guna2Button();
            filterCard.SuspendLayout();
            SuspendLayout();
            // 
            // filterCard
            // 
            filterCard.BackColor = Color.Transparent;
            filterCard.BorderColor = Color.FromArgb(220, 230, 238);
            filterCard.BorderRadius = 10;
            filterCard.BorderThickness = 1;
            filterCard.Controls.Add(txtSearch);
            filterCard.Controls.Add(cmbFilter);
            filterCard.Controls.Add(lblCountBadge);
            filterCard.Controls.Add(btnPrimaryAction);
            filterCard.CustomizableEdges = customizableEdges1;
            filterCard.Dock = DockStyle.Fill;
            filterCard.FillColor = Color.White;
            filterCard.Location = new Point(0, 0);
            filterCard.Name = "filterCard";
            filterCard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            filterCard.Size = new Size(971, 60);
            filterCard.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderColor = Color.FromArgb(220, 230, 238);
            txtSearch.BorderRadius = 8;
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(226, 232, 240);
            txtSearch.DisabledState.FillColor = Color.FromArgb(248, 250, 252);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.FillColor = Color.FromArgb(248, 250, 252);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            txtSearch.FocusedState.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.FromArgb(15, 23, 42);
            txtSearch.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            txtSearch.Location = new Point(14, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "Search records...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(364, 38);
            txtSearch.TabIndex = 0;
            txtSearch.TextOffset = new Point(8, 0);
            // 
            // cmbFilter
            // 
            cmbFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilter.BackColor = Color.Transparent;
            cmbFilter.BorderColor = Color.FromArgb(220, 230, 238);
            cmbFilter.BorderRadius = 8;
            cmbFilter.CustomizableEdges = customizableEdges5;
            cmbFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FillColor = Color.FromArgb(248, 250, 252);
            cmbFilter.FocusedColor = Color.FromArgb(13, 148, 136);
            cmbFilter.FocusedState.BorderColor = Color.FromArgb(13, 148, 136);
            cmbFilter.Font = new Font("Segoe UI", 9.25F);
            cmbFilter.ForeColor = Color.FromArgb(15, 23, 42);
            cmbFilter.ItemHeight = 32;
            cmbFilter.Location = new Point(390, 11);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbFilter.Size = new Size(192, 38);
            cmbFilter.TabIndex = 1;
            // 
            // lblCountBadge
            // 
            lblCountBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCountBadge.Animated = false;
            lblCountBadge.BackColor = Color.Transparent;
            lblCountBadge.BorderColor = Color.FromArgb(153, 246, 228);
            lblCountBadge.BorderRadius = 16;
            lblCountBadge.BorderThickness = 1;
            lblCountBadge.CustomizableEdges = customizableEdges7;
            lblCountBadge.FillColor = Color.FromArgb(240, 253, 250);
            lblCountBadge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCountBadge.ForeColor = Color.FromArgb(15, 118, 110);
            lblCountBadge.HoverState.BorderColor = Color.FromArgb(153, 246, 228);
            lblCountBadge.HoverState.FillColor = Color.FromArgb(240, 253, 250);
            lblCountBadge.HoverState.ForeColor = Color.FromArgb(15, 118, 110);
            lblCountBadge.Location = new Point(594, 14);
            lblCountBadge.Name = "lblCountBadge";
            lblCountBadge.PressedColor = Color.FromArgb(240, 253, 250);
            lblCountBadge.ShadowDecoration.CustomizableEdges = customizableEdges8;
            lblCountBadge.Size = new Size(162, 32);
            lblCountBadge.TabIndex = 2;
            lblCountBadge.TabStop = false;
            lblCountBadge.Text = "0 records";
            // 
            // btnPrimaryAction
            // 
            btnPrimaryAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrimaryAction.BackColor = Color.Transparent;
            btnPrimaryAction.BorderColor = Color.FromArgb(13, 148, 136);
            btnPrimaryAction.BorderRadius = 8;
            btnPrimaryAction.BorderThickness = 1;
            btnPrimaryAction.Cursor = Cursors.Hand;
            btnPrimaryAction.CustomizableEdges = customizableEdges9;
            btnPrimaryAction.DisabledState.BorderColor = Color.FromArgb(203, 213, 225);
            btnPrimaryAction.DisabledState.FillColor = Color.FromArgb(226, 232, 240);
            btnPrimaryAction.DisabledState.ForeColor = Color.FromArgb(100, 116, 139);
            btnPrimaryAction.FillColor = Color.FromArgb(13, 148, 136);
            btnPrimaryAction.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            btnPrimaryAction.ForeColor = Color.White;
            btnPrimaryAction.HoverState.BorderColor = Color.FromArgb(15, 118, 110);
            btnPrimaryAction.HoverState.FillColor = Color.FromArgb(15, 118, 110);
            btnPrimaryAction.Location = new Point(768, 11);
            btnPrimaryAction.Name = "btnPrimaryAction";
            btnPrimaryAction.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnPrimaryAction.Size = new Size(187, 38);
            btnPrimaryAction.TabIndex = 3;
            btnPrimaryAction.Text = "+ Add Record";
            // 
            // DirectoryFilterBarControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(filterCard);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(560, 60);
            Name = "DirectoryFilterBarControl";
            Size = new Size(971, 60);
            filterCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel filterCard;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilter;
        private Guna.UI2.WinForms.Guna2Button lblCountBadge;
        private Guna.UI2.WinForms.Guna2Button btnPrimaryAction;
    }
}
