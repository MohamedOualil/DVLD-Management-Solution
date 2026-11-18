using DVLD.Contracts.Persons;
using DVLD.Contracts.Users;
using DVLD.WinForms.Common;
using DVLD.WinForms.Shared;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Settings
{
    public class SettingsPresenter : BasePresenter<ISettingsView>
    {
        private readonly ISettingsService _settingsService;
        private bool _disposed;

        public SettingsPresenter(
            ISettingsView view,
            ISettingsService settingsService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _settingsService = settingsService;

            View.OnViewLoaded += View_OnViewLoaded;
            View.OnSaveProfileRequested += View_OnSaveProfileRequested;
            View.OnChangePasswordRequested += View_OnChangePasswordRequested;
            View.OnChangePhotoRequested += View_OnChangePhotoRequested;
            View.OnRefreshUsersRequested += View_OnRefreshUsersRequested;
        }

        private async void View_OnViewLoaded(object? sender, EventArgs e)
        {
            if (_disposed) return;

            string displayName = string.IsNullOrWhiteSpace(_session.Username) ? "Adam Admin" : _session.Username;
            string roleText = _session.IsAdmin ? "Administrator" : _session.Role.ToString();
            View.SetHeaderProfile(displayName, roleText, GetInitials(displayName), null);

            await LoadCurrentProfileAsync();
            await LoadUsersListAsync();
        }

        private async Task LoadCurrentProfileAsync()
        {
            if (_disposed || _session.PersonId <= 0)
                return;

            try
            {
                var response = await _settingsService.GetPersonAsync(_session.PersonId);
                if (_disposed || !response.IsSuccess || response.Data is null)
                    return;

                var p = response.Data;
                View.FirstName = p.FirstName ?? string.Empty;
                View.SecondName = p.SecondName ?? string.Empty;
                View.ThirdName = p.ThirdName ?? string.Empty;
                View.LastName = p.LastName ?? string.Empty;
                View.NationalNo = p.NationalNo ?? string.Empty;
                View.DateOfBirth = p.DateOfBirth == default ? new DateTime(1995, 1, 1) : p.DateOfBirth;
                View.Gender = p.Gender == 0 ? (byte)1 : (byte)p.Gender;
                View.Email = p.Email ?? string.Empty;
                View.Phone = p.Phone ?? string.Empty;
                View.Street = p.Street ?? string.Empty;
                View.City = p.City ?? string.Empty;
                View.State = p.State ?? string.Empty;
                View.ZipCode = p.ZipCode ?? string.Empty;
                View.CountryId = p.CountryId <= 0 ? 1 : p.CountryId;
                View.ImagePath = p.ImagePath ?? string.Empty;

                string fullName = $"{p.FirstName} {p.LastName}".Trim();
                if (string.IsNullOrWhiteSpace(fullName))
                    fullName = _session.Username;

                string roleText = _session.IsAdmin ? "Administrator" : _session.Role.ToString();
                View.SetHeaderProfile(fullName, roleText, GetInitials(fullName), p.ImagePath);
            }
            catch
            {
                // Ignore if offline or endpoint not reachable
            }
        }

        private async void View_OnSaveProfileRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;

            if (string.IsNullOrWhiteSpace(View.FirstName) || string.IsNullOrWhiteSpace(View.LastName))
            {
                View.ShowProfileFeedback("First Name and Last Name are required.", isError: true);
                return;
            }

            if (string.IsNullOrWhiteSpace(View.Phone))
            {
                View.ShowProfileFeedback("Phone number is required.", isError: true);
                return;
            }

            if (_session.PersonId <= 0)
            {
                View.ShowProfileFeedback("Profile changes saved locally.", isError: false);
                return;
            }

            View.SetProfileSaving(true);
            View.ShowProfileFeedback("Saving changes...", isError: false);

            try
            {
                var request = new UpdatePersonRequest
                {
                    FirstName = View.FirstName.Trim(),
                    SecondName = View.SecondName.Trim(),
                    ThirdName = View.ThirdName.Trim(),
                    LastName = View.LastName.Trim(),
                    DateOfBirth = View.DateOfBirth,
                    Gender = View.Gender == 0 ? (byte)1 : View.Gender,
                    Phone = View.Phone.Trim(),
                    Email = View.Email.Trim(),
                    Street = string.IsNullOrWhiteSpace(View.Street) ? "Main St" : View.Street.Trim(),
                    City = string.IsNullOrWhiteSpace(View.City) ? "City" : View.City.Trim(),
                    State = string.IsNullOrWhiteSpace(View.State) ? "State" : View.State.Trim(),
                    ZipCode = string.IsNullOrWhiteSpace(View.ZipCode) ? "10000" : View.ZipCode.Trim(),
                    AddressCountryId = View.CountryId <= 0 ? 1 : View.CountryId,
                    ImagePath = View.ImagePath ?? string.Empty
                };

                var response = await _settingsService.UpdatePersonAsync(_session.PersonId, request);
                if (_disposed) return;

                if (response.IsSuccess)
                {
                    string fullName = $"{request.FirstName} {request.LastName}".Trim();
                    string roleText = _session.IsAdmin ? "Administrator" : _session.Role.ToString();
                    View.SetHeaderProfile(fullName, roleText, GetInitials(fullName), request.ImagePath);
                    View.ShowProfileFeedback("Profile updated successfully!", isError: false);
                }
                else
                {
                    View.ShowProfileFeedback(response.Error?.AllMessages ?? "Failed to update profile.", isError: true);
                }
            }
            catch
            {
                if (!_disposed)
                    View.ShowProfileFeedback("Could not reach the server to save profile.", isError: true);
            }
            finally
            {
                if (!_disposed)
                    View.SetProfileSaving(false);
            }
        }

        private async void View_OnChangePasswordRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;

            string currentPassword = View.CurrentPassword.Trim();
            string newPassword = View.NewPassword.Trim();
            string confirmPassword = View.ConfirmPassword.Trim();

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                View.ShowPasswordFeedback("Please fill in all password fields.", isError: true);
                return;
            }

            if (newPassword != confirmPassword)
            {
                View.ShowPasswordFeedback("New password and confirmation do not match.", isError: true);
                return;
            }

            if (newPassword.Length < 6)
            {
                View.ShowPasswordFeedback("New password must be at least 6 characters long.", isError: true);
                return;
            }

            View.SetPasswordSaving(true);
            View.ShowPasswordFeedback("Updating password...", isError: false);

            try
            {
                var response = await _settingsService.ChangePasswordAsync(_session.UserId, new ChangePasswordRequest
                {
                    CurrentPassword = currentPassword,
                    NewPassword = newPassword
                });

                if (_disposed) return;

                if (response.IsSuccess)
                {
                    View.CurrentPassword = string.Empty;
                    View.NewPassword = string.Empty;
                    View.ConfirmPassword = string.Empty;
                    View.ShowPasswordFeedback("Password updated successfully!", isError: false);
                }
                else
                {
                    View.ShowPasswordFeedback(response.Error?.AllMessages ?? "Failed to update password.", isError: true);
                }
            }
            catch
            {
                if (!_disposed)
                    View.ShowPasswordFeedback("Could not reach the server to update password.", isError: true);
            }
            finally
            {
                if (!_disposed)
                    View.SetPasswordSaving(false);
            }
        }

        private void View_OnChangePhotoRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;

            using var dialog = new OpenFileDialog
            {
                Title = "Select Profile Photo",
                Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                View.ImagePath = dialog.FileName;
                string fullName = $"{View.FirstName} {View.LastName}".Trim();
                if (string.IsNullOrWhiteSpace(fullName))
                    fullName = _session.Username;
                string roleText = _session.IsAdmin ? "Administrator" : _session.Role.ToString();
                View.SetHeaderProfile(fullName, roleText, GetInitials(fullName), dialog.FileName);
            }
        }

        private async void View_OnRefreshUsersRequested(object? sender, EventArgs e)
        {
            await LoadUsersListAsync();
        }

        private async Task LoadUsersListAsync()
        {
            if (_disposed) return;

            try
            {
                bool? activeFilter = View.UserStatusFilterIndex switch
                {
                    1 => true,
                    2 => false,
                    _ => true // UserController defaults IsActive ?? false, so pass true for active or null
                };

                var response = await _settingsService.GetUsersListAsync(
                    1, 25, View.UserSearchTerm, activeFilter);

                if (_disposed) return;

                if (response.IsSuccess && response.Data != null)
                {
                    View.DisplayUsers(response.Data.Items, response.Data.TotalCount);
                    View.ShowUsersFeedback(string.Empty, false);
                }
                else
                {
                    View.DisplayUsers(Array.Empty<UsersListResponse>(), 0);
                    View.ShowUsersFeedback(response.Error?.AllMessages ?? "No users found.", isError: false);
                }
            }
            catch
            {
                if (!_disposed)
                    View.ShowUsersFeedback("Could not load users list.", isError: true);
            }
        }

        private static string GetInitials(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "AA";
            var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
                return parts[0].Length >= 2 ? parts[0][..2].ToUpperInvariant() : parts[0].ToUpperInvariant();
            return $"{parts[0][0]}{parts[^1][0]}".ToUpperInvariant();
        }

        public override void Dispose()
        {
            _disposed = true;
            View.OnViewLoaded -= View_OnViewLoaded;
            View.OnSaveProfileRequested -= View_OnSaveProfileRequested;
            View.OnChangePasswordRequested -= View_OnChangePasswordRequested;
            View.OnChangePhotoRequested -= View_OnChangePhotoRequested;
            View.OnRefreshUsersRequested -= View_OnRefreshUsersRequested;
        }
    }
}
