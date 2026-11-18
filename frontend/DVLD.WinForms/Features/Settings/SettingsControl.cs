#nullable enable
using DVLD.Contracts.Users;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Settings
{
    public partial class SettingsControl : UserControl, ISettingsView
    {
        public event EventHandler? OnViewLoaded;
        public event EventHandler? OnSaveProfileRequested;
        public event EventHandler? OnChangePasswordRequested;
        public event EventHandler? OnChangePhotoRequested;
        public event EventHandler? OnRefreshUsersRequested;
        public event EventHandler? OnAddUserRequested;
        public event EventHandler<int>? OnEditUserRequested;

        private int _activeTabIndex;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FirstName
        {
            get => _txtFirstName.Text;
            set => _txtFirstName.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SecondName
        {
            get => _txtSecondName.Text;
            set => _txtSecondName.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ThirdName
        {
            get => _txtThirdName.Text;
            set => _txtThirdName.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName
        {
            get => _txtLastName.Text;
            set => _txtLastName.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NationalNo
        {
            get => _txtNationalNo.Text;
            set => _txtNationalNo.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateOfBirth { get; set; } = new DateTime(1995, 1, 1);

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte Gender { get; set; } = 1;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get => _txtEmail.Text;
            set => _txtEmail.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Phone
        {
            get => _txtPhone.Text;
            set => _txtPhone.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Street
        {
            get => _txtStreet.Text;
            set => _txtStreet.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string City
        {
            get => _txtCity.Text;
            set => _txtCity.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string State
        {
            get => _txtState.Text;
            set => _txtState.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ZipCode { get; set; } = "10000";

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CountryId { get; set; } = 1;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImagePath { get; set; } = string.Empty;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentPassword
        {
            get => _txtCurrentPassword.Text;
            set => _txtCurrentPassword.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NewPassword
        {
            get => _txtNewPassword.Text;
            set => _txtNewPassword.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ConfirmPassword
        {
            get => _txtConfirmPassword.Text;
            set => _txtConfirmPassword.Text = value ?? string.Empty;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserSearchTerm => _txtUserSearch.Text.Trim();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int UserStatusFilterIndex => _cbUserStatus.SelectedIndex;

        public SettingsControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Dock = DockStyle.Fill;

            ApplyVectorIcons();
            _cbUserStatus.SelectedIndex = 0;

            WireEvents();
            UpdateAvatarRegion();
            SwitchSubTab(0);
        }

        private void ApplyVectorIcons()
        {
            _txtUserSearch.IconLeft = Properties.Resources.icons8_search_32;
            _txtUserSearch.IconLeftSize = new Size(16, 16);
            _txtUserSearch.TextOffset = new Point(0, 0);

            _btnChangePhoto.Image = Properties.Resources.icons8_edit_30;
            _btnChangePhoto.ImageSize = new Size(15, 15);
            _btnChangePhoto.ImageOffset = new Point(-2, 0);

            _btnSaveProfile.Image = Properties.Resources.icons8_check_white_32;
            _btnSaveProfile.ImageSize = new Size(15, 15);
            _btnSaveProfile.ImageOffset = new Point(-2, 0);

            _btnUpdatePassword.Image = Properties.Resources.icons8_check_white_32;
            _btnUpdatePassword.ImageSize = new Size(15, 15);
            _btnUpdatePassword.ImageOffset = new Point(-2, 0);

            _btnRefreshUsers.Image = Properties.Resources.icons8_renew_48;
            _btnRefreshUsers.ImageSize = new Size(15, 15);
            _btnRefreshUsers.ImageOffset = new Point(-2, 0);

            _btnAddUser.Image = Properties.Resources.icons8_add_properties_24;
            _btnAddUser.ImageSize = new Size(15, 15);
            _btnAddUser.ImageOffset = new Point(-2, 0);
            _btnAddUser.Text = "Add Operator";
        }

        private void WireEvents()
        {
            _pbAvatar.SizeChanged += (_, _) => UpdateAvatarRegion();
            _pbAvatar.Paint += PbAvatar_PaintRing;

            _btnTabEditProfile.Click += (_, _) => SwitchSubTab(0);
            _btnTabChangePassword.Click += (_, _) => SwitchSubTab(1);
            _btnTabUserManage.Click += (_, _) => SwitchSubTab(2);

            _btnChangePhoto.Click += (_, _) => OnChangePhotoRequested?.Invoke(this, EventArgs.Empty);
            _btnSaveProfile.Click += (_, _) => OnSaveProfileRequested?.Invoke(this, EventArgs.Empty);
            _btnUpdatePassword.Click += (_, _) => OnChangePasswordRequested?.Invoke(this, EventArgs.Empty);

            _txtUserSearch.TextChanged += (_, _) => OnRefreshUsersRequested?.Invoke(this, EventArgs.Empty);
            _cbUserStatus.SelectedIndexChanged += (_, _) => OnRefreshUsersRequested?.Invoke(this, EventArgs.Empty);
            _btnRefreshUsers.Click += (_, _) => OnRefreshUsersRequested?.Invoke(this, EventArgs.Empty);
            _btnAddUser.Click += BtnAddUser_Click;

            _dgvUsers.CellPainting += DgvUsers_CellPainting;
            _dgvUsers.CellDoubleClick += DgvUsers_CellDoubleClick;
        }

        private void SettingsControl_Load(object? sender, EventArgs e)
        {
            OnViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void SwitchSubTab(int tabIndex)
        {
            _activeTabIndex = Math.Clamp(tabIndex, 0, 2);

            SetTabButtonStyle(_btnTabEditProfile, _activeTabIndex == 0);
            SetTabButtonStyle(_btnTabChangePassword, _activeTabIndex == 1);
            SetTabButtonStyle(_btnTabUserManage, _activeTabIndex == 2);

            _cardProfile.Visible = _activeTabIndex == 0;
            _cardPassword.Visible = _activeTabIndex == 1;
            _cardUsers.Visible = _activeTabIndex == 2;

            switch (_activeTabIndex)
            {
                case 0:
                    _cardProfile.BringToFront();
                    statusBanner.SetBanner(
                        "Operator Profile Ready",
                        "Review or update your personal identity details below. Changes sync with your DVLD operator account.",
                        HeaderBadgeTone.Info);
                    break;
                case 1:
                    _cardPassword.BringToFront();
                    statusBanner.SetBanner(
                        "Security & Credentials",
                        "Verify your current password before setting a new operator password (minimum 6 characters).",
                        HeaderBadgeTone.Info);
                    break;
                default:
                    _cardUsers.BringToFront();
                    statusBanner.SetBanner(
                        "System Operators Directory",
                        "Browse operator accounts by name, username, or active status. Use Administration → Users Management for full edits.",
                        HeaderBadgeTone.Info);
                    break;
            }
        }

        private static void SetTabButtonStyle(Guna2Button btn, bool active)
        {
            if (active)
            {
                btn.FillColor = UITheme.PrimaryBlue;
                btn.ForeColor = Color.White;
                btn.HoverState.FillColor = UITheme.PrimaryBlueHover;
                btn.HoverState.ForeColor = Color.White;
            }
            else
            {
                btn.FillColor = Color.Transparent;
                btn.ForeColor = UITheme.LabelInk;
                btn.HoverState.FillColor = UITheme.CardSurface;
                btn.HoverState.ForeColor = UITheme.HeadingInk;
            }
        }

        private void UpdateAvatarRegion()
        {
            if (_pbAvatar.Width <= 1 || _pbAvatar.Height <= 1)
                return;

            using var path = new GraphicsPath();
            path.AddEllipse(0, 0, _pbAvatar.Width, _pbAvatar.Height);
            _pbAvatar.Region = new Region(path);
        }

        private void PbAvatar_PaintRing(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(UITheme.CardBorder, 1.5f);
            e.Graphics.DrawEllipse(pen, 1, 1, _pbAvatar.Width - 3, _pbAvatar.Height - 3);
        }

        private void BtnAddUser_Click(object? sender, EventArgs e)
        {
            if (OnAddUserRequested is not null)
            {
                OnAddUserRequested.Invoke(this, EventArgs.Empty);
                return;
            }

            ShowUsersFeedback("Open Users Management in the Administration sidebar to register a new operator.", isError: false);
        }

        private void DgvUsers_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dgvUsers.Rows.Count)
                return;

            var row = _dgvUsers.Rows[e.RowIndex];
            int userId = 0;

            if (row.Tag is UsersListResponse user)
            {
                userId = user.UserId;
            }
            else
            {
                string rawId = row.Cells["UserId"].Value?.ToString()?.TrimStart('#') ?? string.Empty;
                int.TryParse(rawId, out userId);
            }

            if (userId <= 0)
                return;

            if (OnEditUserRequested is not null)
            {
                OnEditUserRequested.Invoke(this, userId);
                return;
            }

            ShowUsersFeedback($"Selected User #{userId}. Open Users Management in Administration to edit roles or credentials.", isError: false);
        }

        private void DgvUsers_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = _dgvUsers.Columns[e.ColumnIndex].Name;
            if (columnName == "FullName")
                DataGridViewUIHelper.DrawAvatarAndName(e);
            else if (columnName == "Status")
                DataGridViewUIHelper.DrawStatusBadge(e);
        }

        // --- ISettingsView Implementation ---

        public void SetHeaderProfile(string fullName, string roleText, string initials, string? imagePath)
        {
            string resolvedName = string.IsNullOrWhiteSpace(fullName) ? "Operator" : fullName;
            string resolvedRole = string.IsNullOrWhiteSpace(roleText) ? "User" : roleText;

            _lblProfileName.Text = resolvedName;
            _lblProfileRole.Text = resolvedRole;
            _txtRoleDisplay.Text = resolvedRole;
            _lblAvatarInitials.Text = string.IsNullOrWhiteSpace(initials) ? "OP" : initials;

            pageHeader.BadgeText = $"● {resolvedRole}";
            pageHeader.BadgeTone = resolvedRole.Equals("Administrator", StringComparison.OrdinalIgnoreCase)
                ? HeaderBadgeTone.Info
                : HeaderBadgeTone.Neutral;

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                _pbAvatar.ImageLocation = imagePath;
                _lblAvatarInitials.Visible = false;
            }
            else
            {
                _pbAvatar.Image = null;
                _lblAvatarInitials.Visible = true;
            }
        }

        public void DisplayUsers(IEnumerable<UsersListResponse> users, int totalCount)
        {
            _dgvUsers.Rows.Clear();
            int count = 0;

            if (users is not null)
            {
                foreach (var u in users)
                {
                    int idx = _dgvUsers.Rows.Add();
                    var row = _dgvUsers.Rows[idx];
                    row.Tag = u;
                    row.Cells["UserId"].Value = $"#{u.UserId}";
                    row.Cells["PersonId"].Value = $"#{u.PersonId}";
                    row.Cells["FullName"].Value = string.IsNullOrWhiteSpace(u.FullName) ? "—" : u.FullName;
                    row.Cells["UserName"].Value = string.IsNullOrWhiteSpace(u.UserName) ? "—" : $"@{u.UserName}";
                    row.Cells["Status"].Value = u.IsActive ? "Active" : "Inactive";
                    count++;
                }
            }

            _lblUsersEmpty.Visible = count == 0;
            if (count == 0)
                _lblUsersEmpty.BringToFront();

            _lblUsersCount.Text = $"Showing {count} of {totalCount} {(totalCount == 1 ? "operator" : "operators")}";
        }

        public void ShowProfileFeedback(string message, bool isError)
        {
            bool isProgress = !isError && message.EndsWith("...", StringComparison.Ordinal);

            _lblProfileFeedback.ForeColor = isError
                ? UITheme.DangerText
                : isProgress
                    ? UITheme.PrimaryBlue
                    : UITheme.SuccessText;
            _lblProfileFeedback.Text = message ?? string.Empty;

            if (_activeTabIndex == 0 && !string.IsNullOrWhiteSpace(message))
            {
                HeaderBadgeTone tone = isError
                    ? HeaderBadgeTone.Danger
                    : isProgress
                        ? HeaderBadgeTone.Info
                        : HeaderBadgeTone.Success;

                string title = isError
                    ? "Profile Validation Error"
                    : isProgress
                        ? "Saving Operator Profile"
                        : "Profile Updated";

                statusBanner.SetBanner(title, message, tone);
            }
        }

        public void ShowPasswordFeedback(string message, bool isError)
        {
            bool isProgress = !isError && message.EndsWith("...", StringComparison.Ordinal);

            _lblPasswordFeedback.ForeColor = isError
                ? UITheme.DangerText
                : isProgress
                    ? UITheme.PrimaryBlue
                    : UITheme.SuccessText;
            _lblPasswordFeedback.Text = message ?? string.Empty;

            if (_activeTabIndex == 1 && !string.IsNullOrWhiteSpace(message))
            {
                HeaderBadgeTone tone = isError
                    ? HeaderBadgeTone.Danger
                    : isProgress
                        ? HeaderBadgeTone.Info
                        : HeaderBadgeTone.Success;

                string title = isError
                    ? "Password Update Failed"
                    : isProgress
                        ? "Updating Password"
                        : "Password Updated";

                statusBanner.SetBanner(title, message, tone);
            }
        }

        public void ShowUsersFeedback(string message, bool isError)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _lblUsersFeedback.ForeColor = UITheme.MutedInk;
                _lblUsersFeedback.Text = "Double-click any operator row to edit account settings.";
                return;
            }

            _lblUsersFeedback.ForeColor = isError ? UITheme.DangerText : UITheme.InfoText;
            _lblUsersFeedback.Text = message;

            if (_activeTabIndex == 2)
            {
                statusBanner.SetBanner(
                    isError ? "Operators Load Error" : "Operators Notice",
                    message,
                    isError ? HeaderBadgeTone.Danger : HeaderBadgeTone.Info);
            }
        }

        public void SetProfileSaving(bool isSaving)
        {
            _btnSaveProfile.Enabled = !isSaving;
            _btnSaveProfile.Text = isSaving ? "Saving..." : "Save Profile Changes";
        }

        public void SetPasswordSaving(bool isSaving)
        {
            _btnUpdatePassword.Enabled = !isSaving;
            _btnUpdatePassword.Text = isSaving ? "Updating..." : "Update Password";
        }
    }
}
