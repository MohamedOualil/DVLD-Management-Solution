#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.Persons;
using DVLD.Contracts.Users;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared.Controls;
using DVLD.WinForms.Shared.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Administration.Users
{
    public enum UserEditorMode
    {
        Create,
        EditRoleAndStatus,
        ChangePassword
    }

    public partial class UserEditorForm : Form
    {
        private readonly IPesronService _personService;
        private UserEditorMode _mode = UserEditorMode.Create;
        private int _linkedPersonId;
        private string _linkedFullName = string.Empty;

        public UserEditorForm(IPesronService personService)
        {
            _personService = personService;
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            cmbRole.Items.AddRange(new object[] { "Employee", "Admin" });
            cmbRole.SelectedIndex = 0;

            btnFindPerson.Click += async (_, _) => await LookupPersonAsync();
            txtPersonLookup.KeyDown += async (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await LookupPersonAsync();
                }
            };

            pageHeader.BackRequested += (_, _) => CancelAndClose();
            pageActionFooter.SecondaryActionRequested += (_, _) => CancelAndClose();
            pageActionFooter.PrimaryActionRequested += (_, _) => SaveAndClose();

            ModalDialogShellHelper.Attach(
                this,
                borderRadius: 13f,
                onEscape: CancelAndClose,
                topAccentBar,
                pageHeader,
                statusBanner,
                formCard,
                pageActionFooter);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LinkedPersonId => _linkedPersonId;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UsernameValue => txtUsername.Text.Trim();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Role SelectedRole => cmbRole.SelectedIndex == 1 ? Role.Admin : Role.Employee;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsActiveValue => chkIsActive.Checked;

        public void ConfigureForCreate()
        {
            _mode = UserEditorMode.Create;
            _linkedPersonId = 0;
            _linkedFullName = string.Empty;

            pageHeader.Configure(
                "Create Employee User",
                "Link an existing citizen record to a system employee or administrator login",
                "● New Account",
                HeaderBadgeTone.Info,
                showBackButton: true,
                iconText: "US");

            statusBanner.SetBanner(
                "Step 1: Link Citizen Profile",
                "Find the citizen by Person ID or National No, then set their username, role, and initial password.",
                HeaderBadgeTone.Info);

            txtPersonLookup.Clear();
            txtPersonLookup.Enabled = true;
            btnFindPerson.Enabled = true;
            lblPersonName.Text = "No citizen linked yet";
            lblPersonMeta.Text = "Enter Person ID or National No and click Find Citizen";
            ApplyPersonBoxTone(linked: false);

            txtUsername.Clear();
            txtUsername.Enabled = true;
            cmbRole.Enabled = true;
            cmbRole.SelectedIndex = 0;
            chkIsActive.Enabled = true;
            chkIsActive.Checked = true;

            lblCurrentPassword.Visible = false;
            txtCurrentPassword.Visible = false;
            txtCurrentPassword.Clear();

            lblPassword.Text = "INITIAL PASSWORD *";
            lblPassword.Location = new Point(20, 174);
            txtPassword.Location = new Point(20, 192);
            lblConfirmPassword.Location = new Point(332, 174);
            txtConfirmPassword.Location = new Point(332, 192);

            lblPassword.Visible = true;
            txtPassword.Visible = true;
            txtPassword.Clear();
            lblConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            txtConfirmPassword.Clear();

            pageActionFooter.PrimaryButtonText = "Create User";
            pageActionFooter.SetState(true, "Link a citizen record and complete all required fields.");
        }

        public void ConfigureForEdit(UserResponse user)
        {
            ArgumentNullException.ThrowIfNull(user);

            _mode = UserEditorMode.EditRoleAndStatus;
            _linkedPersonId = user.PersonId;
            _linkedFullName = user.FullName;

            pageHeader.Configure(
                $"Manage User #{user.UserId}",
                $"Updating role permissions and access status for @{user.UserName}",
                user.IsActive ? "● Active" : "● Inactive",
                user.IsActive ? HeaderBadgeTone.Success : HeaderBadgeTone.Warning,
                showBackButton: true,
                iconText: "US");

            statusBanner.SetBanner(
                $"Editing @{user.UserName}",
                "Admins can promote/demote Employee and Admin roles or activate/deactivate sign-in access.",
                HeaderBadgeTone.Info);

            txtPersonLookup.Text = user.PersonId.ToString();
            txtPersonLookup.Enabled = false;
            btnFindPerson.Enabled = false;
            lblPersonName.Text = string.IsNullOrWhiteSpace(user.FullName) ? $"Person #{user.PersonId}" : user.FullName;
            lblPersonMeta.Text = $"Linked Person ID #{user.PersonId}  •  User ID #{user.UserId}";
            ApplyPersonBoxTone(linked: true);

            txtUsername.Text = user.UserName;
            txtUsername.Enabled = false;
            cmbRole.Enabled = true;
            cmbRole.SelectedIndex = user.Role == Role.Admin ? 1 : 0;
            chkIsActive.Enabled = true;
            chkIsActive.Checked = user.IsActive;

            lblCurrentPassword.Visible = false;
            txtCurrentPassword.Visible = false;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;

            pageActionFooter.PrimaryButtonText = "Save Role & Status";
            pageActionFooter.SetState(true, "Adjust role or active login status, then click Save Role & Status.");
        }

        public void ConfigureForChangePassword(UserResponse user)
        {
            ArgumentNullException.ThrowIfNull(user);

            _mode = UserEditorMode.ChangePassword;
            _linkedPersonId = user.PersonId;
            _linkedFullName = user.FullName;

            pageHeader.Configure(
                $"Reset Password — @{user.UserName}",
                $"Security credential update for User #{user.UserId} ({user.FullName})",
                "● Security",
                HeaderBadgeTone.Warning,
                showBackButton: true,
                iconText: "PW");

            statusBanner.SetBanner(
                "Password Update",
                "Enter the current password and specify a new password of at least 6 characters.",
                HeaderBadgeTone.Warning);

            txtPersonLookup.Text = user.PersonId.ToString();
            txtPersonLookup.Enabled = false;
            btnFindPerson.Enabled = false;
            lblPersonName.Text = string.IsNullOrWhiteSpace(user.FullName) ? $"Person #{user.PersonId}" : user.FullName;
            lblPersonMeta.Text = $"@{user.UserName}  •  Role: {user.Role}";
            ApplyPersonBoxTone(linked: true);

            txtUsername.Text = user.UserName;
            txtUsername.Enabled = false;
            cmbRole.SelectedIndex = user.Role == Role.Admin ? 1 : 0;
            cmbRole.Enabled = false;
            chkIsActive.Checked = user.IsActive;
            chkIsActive.Enabled = false;

            lblCurrentPassword.Visible = true;
            txtCurrentPassword.Visible = true;
            txtCurrentPassword.Clear();

            lblPassword.Text = "NEW PASSWORD *";
            lblPassword.Location = new Point(20, 236);
            txtPassword.Location = new Point(20, 254);
            lblConfirmPassword.Location = new Point(332, 236);
            txtConfirmPassword.Location = new Point(332, 254);

            lblPassword.Visible = true;
            txtPassword.Visible = true;
            txtPassword.Clear();
            lblConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            txtConfirmPassword.Clear();

            pageActionFooter.PrimaryButtonText = "Update Password";
            pageActionFooter.SetState(true, "Enter current and new passwords, then click Update Password.");
        }

        public CreateUserRequest BuildCreateRequest() => new()
        {
            PersonId = _linkedPersonId,
            Username = txtUsername.Text.Trim(),
            Password = txtPassword.Text,
            Roles = (int)SelectedRole,
            IsActive = chkIsActive.Checked
        };

        public UpdateUserRequest BuildUpdateRequest() => new()
        {
            Role = SelectedRole,
            IsActive = chkIsActive.Checked
        };

        public ChangePasswordRequest BuildChangePasswordRequest() => new()
        {
            CurrentPassword = txtCurrentPassword.Text,
            NewPassword = txtPassword.Text
        };

        private async Task LookupPersonAsync()
        {
            string query = txtPersonLookup.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                statusBanner.SetBanner("Missing Lookup Value", "Enter a Person ID or National No to locate a citizen.", HeaderBadgeTone.Warning);
                return;
            }

            btnFindPerson.Enabled = false;
            btnFindPerson.Text = "Searching…";
            try
            {
                var response = int.TryParse(query, out int personId) && personId > 0
                    ? await _personService.GetPerson(personId)
                    : await _personService.GetPersonByNationalNo(query);

                if (IsDisposed)
                    return;

                if (response.IsSuccess && response.Data is not null)
                {
                    BindPerson(response.Data);
                }
                else
                {
                    _linkedPersonId = 0;
                    _linkedFullName = string.Empty;
                    lblPersonName.Text = "Citizen not found";
                    lblPersonMeta.Text = response.Error?.AllMessages ?? $"No citizen record matched '{query}'.";
                    ApplyPersonBoxTone(linked: false);
                    statusBanner.SetBanner("Citizen Not Found", $"No person matched '{query}'.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!IsDisposed)
                    statusBanner.SetBanner("Lookup Failed", "Unable to reach the person service.", HeaderBadgeTone.Danger);
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnFindPerson.Enabled = _mode == UserEditorMode.Create;
                    btnFindPerson.Text = "Find Citizen";
                }
            }
        }

        private void BindPerson(PersonResponse person)
        {
            _linkedPersonId = person.PersonId;
            _linkedFullName = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}"
                .Replace("  ", " ", StringComparison.Ordinal)
                .Trim();

            lblPersonName.Text = string.IsNullOrWhiteSpace(_linkedFullName) ? $"Person #{person.PersonId}" : _linkedFullName;
            lblPersonMeta.Text = $"Person ID #{person.PersonId}  •  National No: {person.NationalNo}";
            ApplyPersonBoxTone(linked: true);

            statusBanner.SetBanner(
                $"Linked: {lblPersonName.Text}",
                "Now enter a unique employee username, choose their role (Employee or Admin), and set an initial password.",
                HeaderBadgeTone.Success);
        }

        private void ApplyPersonBoxTone(bool linked)
        {
            personSummaryBox.FillColor = linked
                ? Color.FromArgb(240, 253, 244)
                : Color.FromArgb(248, 250, 252);
            personSummaryBox.BorderColor = linked
                ? Color.FromArgb(187, 247, 208)
                : Color.FromArgb(226, 232, 240);
        }

        private void SaveAndClose()
        {
            if (_mode == UserEditorMode.Create)
            {
                if (_linkedPersonId <= 0)
                {
                    pageActionFooter.SetState(true, "Link a valid citizen record using Find Citizen first.", isWarningOrError: true);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    pageActionFooter.SetState(true, "Username is required.", isWarningOrError: true);
                    return;
                }

                if (txtPassword.Text.Length < 6)
                {
                    pageActionFooter.SetState(true, "Password must be at least 6 characters.", isWarningOrError: true);
                    return;
                }

                if (!string.Equals(txtPassword.Text, txtConfirmPassword.Text, StringComparison.Ordinal))
                {
                    pageActionFooter.SetState(true, "Password and confirmation do not match.", isWarningOrError: true);
                    return;
                }
            }
            else if (_mode == UserEditorMode.ChangePassword)
            {
                if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                {
                    pageActionFooter.SetState(true, "Current password is required.", isWarningOrError: true);
                    return;
                }

                if (txtPassword.Text.Length < 6)
                {
                    pageActionFooter.SetState(true, "New password must be at least 6 characters.", isWarningOrError: true);
                    return;
                }

                if (!string.Equals(txtPassword.Text, txtConfirmPassword.Text, StringComparison.Ordinal))
                {
                    pageActionFooter.SetState(true, "New password and confirmation do not match.", isWarningOrError: true);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelAndClose()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
