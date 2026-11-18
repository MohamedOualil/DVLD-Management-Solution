#nullable enable
using DVLD.Contracts.Users;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Administration.Users
{
    public partial class UsersControl : UserControl, IUsersView
    {
        private readonly List<UsersListResponse> _allRows = [];
        private bool _isAdmin;

        public event EventHandler? LoadRequested;
        public event EventHandler<int>? PageRequested;
        public event EventHandler? SearchOrFilterChanged;
        public event EventHandler? AddUserRequested;
        public event EventHandler<int>? ViewPersonRequested;
        public event EventHandler<int>? EditUserRequested;
        public event EventHandler<int>? ChangePasswordRequested;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchTerm => filterBar.SearchText;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StatusFilterIndex => filterBar.SelectedFilterIndex;

        public UsersControl()
        {
            InitializeComponent();
            filterBar.SetFilterItems("Active Users", "Inactive Users", "All Users");

            filterBar.SearchChanged += (_, _) => ApplyFilter();
            filterBar.FilterChanged += (_, _) => SearchOrFilterChanged?.Invoke(this, EventArgs.Empty);
            filterBar.PrimaryActionClicked += (_, _) => AddUserRequested?.Invoke(this, EventArgs.Empty);
            paginationBar.PageRequested += (_, page) => PageRequested?.Invoke(this, page);
            usersGrid.CellContentClick += OnGridCellContentClick;
            usersGrid.CellDoubleClick += OnGridCellDoubleClick;
            usersGrid.CellFormatting += OnCellFormatting;
            usersGrid.CellPainting += OnCellPainting;
        }

        private void UsersControl_Load(object? sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetAdminAccessState(bool isAdmin, string title, string description, HeaderBadgeTone tone)
        {
            _isAdmin = isAdmin;
            statusBanner.SetBanner(title, description, tone);
            filterBar.ShowPrimaryButton = isAdmin;
            colEditUser.Visible = isAdmin;
            colChangePassword.Visible = isAdmin;

            if (!isAdmin)
            {
                _allRows.Clear();
                usersGrid.Rows.Clear();
                lblEmptyState.Text = description;
                lblEmptyState.Visible = true;
            }
        }

        public void DisplayUsers(IEnumerable<UsersListResponse> users)
        {
            _allRows.Clear();
            if (users is not null)
                _allRows.AddRange(users);

            ApplyFilter();
        }

        public void DisplayPagination(int pageNumber, int totalPages, int totalCount)
        {
            paginationBar.DisplayPagination(pageNumber, totalPages, totalCount, usersGrid.Rows.Count, "users");
            filterBar.CountText = $"{totalCount} {(totalCount == 1 ? "user" : "users")}";
        }

        public void SetLoading(bool isLoading)
        {
            paginationBar.SetLoading(isLoading);
            UseWaitCursor = isLoading;
        }

        public void DisplayMessage(string message)
        {
            if (_allRows.Count == 0)
            {
                lblEmptyState.Text = message;
                lblEmptyState.Visible = true;
            }
            else
            {
                MessageBox.Show(this, message, "Users & Employee Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ApplyFilter()
        {
            string term = filterBar.SearchText;

            var filtered = _allRows.Where(u =>
            {
                if (string.IsNullOrWhiteSpace(term))
                    return true;

                return (u.FullName?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)
                    || (u.UserName?.Contains(term, StringComparison.OrdinalIgnoreCase) ?? false)
                    || u.UserId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase)
                    || u.PersonId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            usersGrid.Rows.Clear();
            foreach (var user in filtered)
            {
                int rowIndex = usersGrid.Rows.Add();
                var row = usersGrid.Rows[rowIndex];
                row.Tag = user;
                row.Cells["UserId"].Value = user.UserId;
                row.Cells["PersonId"].Value = user.PersonId;
                row.Cells["FullName"].Value = user.FullName ?? "—";
                row.Cells["UserName"].Value = user.UserName ?? "—";
                row.Cells["Status"].Value = user.IsActive ? "Active" : "Inactive";
            }

            lblEmptyState.Text = filtered.Count == 0
                ? (_allRows.Count == 0 ? "No user accounts found for this filter." : "No user accounts match your search.")
                : string.Empty;
            lblEmptyState.Visible = filtered.Count == 0;
        }

        private void OnGridCellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= usersGrid.Rows.Count)
                return;

            string colName = usersGrid.Columns[e.ColumnIndex].Name;
            var row = usersGrid.Rows[e.RowIndex];

            if (colName == "ViewPerson" &&
                int.TryParse(row.Cells["PersonId"].Value?.ToString(), out int personId) &&
                personId > 0)
            {
                ViewPersonRequested?.Invoke(this, personId);
            }
            else if (_isAdmin &&
                     colName == "EditUser" &&
                     int.TryParse(row.Cells["UserId"].Value?.ToString(), out int editUserId) &&
                     editUserId > 0)
            {
                EditUserRequested?.Invoke(this, editUserId);
            }
            else if (_isAdmin &&
                     colName == "ChangePassword" &&
                     int.TryParse(row.Cells["UserId"].Value?.ToString(), out int pwdUserId) &&
                     pwdUserId > 0)
            {
                ChangePasswordRequested?.Invoke(this, pwdUserId);
            }
        }

        private void OnGridCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (!_isAdmin || e.RowIndex < 0 || e.RowIndex >= usersGrid.Rows.Count)
                return;

            if (int.TryParse(usersGrid.Rows[e.RowIndex].Cells["UserId"].Value?.ToString(), out int userId) && userId > 0)
                EditUserRequested?.Invoke(this, userId);
        }

        private void OnCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || usersGrid.Columns[e.ColumnIndex].Name != "Status")
                return;

            bool isActive = string.Equals(e.Value?.ToString(), "Active", StringComparison.OrdinalIgnoreCase);
            e.CellStyle!.ForeColor = isActive
                ? Color.FromArgb(21, 128, 61)
                : Color.FromArgb(185, 28, 28);
        }

        private void OnCellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = usersGrid.Columns[e.ColumnIndex].Name;
            if (columnName == "FullName")
                DataGridViewUIHelper.DrawAvatarAndName(e);
            else if (columnName == "Status")
                DataGridViewUIHelper.DrawStatusBadge(e);
        }
    }
}
