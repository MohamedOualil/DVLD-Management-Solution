#nullable enable
using DVLD.Contracts.Users;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Settings;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Administration.Users
{
    public class UsersPresenter : BasePresenter<IUsersView>
    {
        private const int PageSize = 20;

        private readonly ISettingsService _settingsService;
        private readonly IPesronService _personService;
        private readonly IAdministrationService _administrationService;
        private List<UsersListResponse> _loadedUsers = [];
        private int _currentPage = 1;
        private bool _disposed;

        public UsersPresenter(
            IUsersView view,
            ISettingsService settingsService,
            IPesronService personService,
            IAdministrationService administrationService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _settingsService = settingsService;
            _personService = personService;
            _administrationService = administrationService;

            View.LoadRequested += OnLoadRequested;
            View.PageRequested += OnPageRequested;
            View.SearchOrFilterChanged += OnSearchOrFilterChanged;
            View.AddUserRequested += OnAddUserRequested;
            View.ViewPersonRequested += OnViewPersonRequested;
            View.EditUserRequested += OnEditUserRequested;
            View.ChangePasswordRequested += OnChangePasswordRequested;
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadUsersAsync(1);
        }

        private async void OnPageRequested(object? sender, int pageNumber)
        {
            await LoadUsersAsync(Math.Max(1, pageNumber));
        }

        private async void OnSearchOrFilterChanged(object? sender, EventArgs e)
        {
            await LoadUsersAsync(1);
        }

        private async Task LoadUsersAsync(int pageNumber)
        {
            if (_disposed) return;

            if (!_session.IsAdmin)
            {
                View.SetAdminAccessState(
                    false,
                    "Administrator Access Required",
                    "Only users with the Administrator role can view or manage employee user accounts.",
                    HeaderBadgeTone.Danger);
                View.DisplayPagination(1, 1, 0);
                return;
            }

            View.SetAdminAccessState(
                true,
                "Admin User Directory Active",
                "Register new employee or admin logins, assign system roles, toggle access status, or reset passwords.",
                HeaderBadgeTone.Success);

            _currentPage = pageNumber;
            View.SetLoading(true);
            try
            {
                int filter = View.StatusFilterIndex; // 0 = Active, 1 = Inactive, 2 = All
                if (filter == 2)
                {
                    var activeTask = _settingsService.GetUsersListAsync(1, 50, null, true);
                    var inactiveTask = _settingsService.GetUsersListAsync(1, 50, null, false);
                    await Task.WhenAll(activeTask, inactiveTask);

                    if (_disposed) return;

                    var combined = new List<UsersListResponse>();
                    if (activeTask.Result.IsSuccess && activeTask.Result.Data is not null)
                        combined.AddRange(activeTask.Result.Data.Items);
                    if (inactiveTask.Result.IsSuccess && inactiveTask.Result.Data is not null)
                        combined.AddRange(inactiveTask.Result.Data.Items);

                    combined = combined
                        .GroupBy(u => u.UserId)
                        .Select(g => g.First())
                        .OrderBy(u => u.UserId)
                        .ToList();

                    _loadedUsers = combined;
                    int totalCount = combined.Count;
                    int totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)PageSize));
                    int clampedPage = Math.Min(_currentPage, totalPages);
                    var slice = combined.Skip((clampedPage - 1) * PageSize).Take(PageSize).ToList();

                    View.DisplayUsers(slice);
                    View.DisplayPagination(clampedPage, totalPages, totalCount);
                    return;
                }

                bool isActive = filter != 1;
                var response = await _settingsService.GetUsersListAsync(_currentPage, PageSize, null, isActive);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                {
                    _loadedUsers = response.Data.Items.ToList();
                    View.DisplayUsers(_loadedUsers);
                    View.DisplayPagination(response.Data.PageNumber, Math.Max(1, response.Data.TotalPages), response.Data.TotalCount);
                }
                else
                {
                    _loadedUsers = [];
                    View.DisplayUsers(Array.Empty<UsersListResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage(isActive ? "No active user accounts found." : "No inactive user accounts found.");
                }
            }
            catch
            {
                if (!_disposed)
                {
                    _loadedUsers = [];
                    View.DisplayUsers(Array.Empty<UsersListResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage("Unable to reach the User management endpoint.");
                }
            }
            finally
            {
                if (!_disposed)
                    View.SetLoading(false);
            }
        }

        private async void OnAddUserRequested(object? sender, EventArgs e)
        {
            if (_disposed || !_session.IsAdmin) return;

            UserEditorForm? editor = null;
            bool saved = false;
            _navigationService.ShowDialog<UserEditorForm>(form =>
            {
                editor = form;
                form.ConfigureForCreate();
                form.FormClosed += (_, _) => saved = form.DialogResult == DialogResult.OK;
            });

            if (!saved || editor is null || _disposed)
                return;

            var request = editor.BuildCreateRequest();
            var response = await _settingsService.CreateUserAsync(request);
            if (_disposed) return;

            if (response.IsSuccess)
            {
                _administrationService.RecordSessionActivity(
                    "Create User",
                    $"@{request.Username} (Person #{request.PersonId})",
                    "Success",
                    $"Created user account with role {(Contracts.Enums.Role)request.Roles} (Active={request.IsActive}).");

                View.DisplayMessage($"Employee user @{request.Username} created successfully.");
                await LoadUsersAsync(_currentPage);
            }
            else
            {
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to create user account.");
            }
        }

        private async void OnEditUserRequested(object? sender, int userId)
        {
            if (_disposed || !_session.IsAdmin || userId <= 0) return;

            var user = await ResolveUserAsync(userId);
            if (_disposed || user is null) return;

            UserEditorForm? editor = null;
            bool saved = false;
            _navigationService.ShowDialog<UserEditorForm>(form =>
            {
                editor = form;
                form.ConfigureForEdit(user);
                form.FormClosed += (_, _) => saved = form.DialogResult == DialogResult.OK;
            });

            if (!saved || editor is null || _disposed)
                return;

            var request = editor.BuildUpdateRequest();
            var updateResponse = await _settingsService.UpdateUserAsync(userId, request);
            if (_disposed) return;

            if (updateResponse.IsSuccess)
            {
                _administrationService.RecordSessionActivity(
                    "Update User",
                    $"@{user.UserName} (User #{userId})",
                    "Success",
                    $"Updated role to {request.Role} and Active={request.IsActive}.");

                View.DisplayMessage($"Updated permissions for @{user.UserName}.");
                await LoadUsersAsync(_currentPage);
            }
            else
            {
                View.DisplayMessage(updateResponse.Error?.AllMessages ?? "Unable to update user permissions.");
            }
        }

        private async void OnChangePasswordRequested(object? sender, int userId)
        {
            if (_disposed || !_session.IsAdmin || userId <= 0) return;

            var user = await ResolveUserAsync(userId);
            if (_disposed || user is null) return;

            UserEditorForm? editor = null;
            bool saved = false;
            _navigationService.ShowDialog<UserEditorForm>(form =>
            {
                editor = form;
                form.ConfigureForChangePassword(user);
                form.FormClosed += (_, _) => saved = form.DialogResult == DialogResult.OK;
            });

            if (!saved || editor is null || _disposed)
                return;

            var request = editor.BuildChangePasswordRequest();
            var response = await _settingsService.ChangePasswordAsync(userId, request);
            if (_disposed) return;

            if (response.IsSuccess)
            {
                _administrationService.RecordSessionActivity(
                    "Reset User Password",
                    $"@{user.UserName} (User #{userId})",
                    "Success",
                    "Administrator updated account password.");

                View.DisplayMessage($"Password updated successfully for @{user.UserName}.");
            }
            else
            {
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to update user password.");
            }
        }

        private async void OnViewPersonRequested(object? sender, int personId)
        {
            if (_disposed || personId <= 0) return;

            try
            {
                var response = await _personService.GetPerson(personId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                    _navigationService.ShowDialog<PersonCardForm>(form => form.DisplayPerson(response.Data));
                else
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load linked person profile.");
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load linked person profile.");
            }
        }

        private async Task<UserResponse?> ResolveUserAsync(int userId)
        {
            try
            {
                var response = await _settingsService.GetUserAsync(userId);
                if (response.IsSuccess && response.Data is not null)
                    return response.Data;

                var cached = _loadedUsers.FirstOrDefault(u => u.UserId == userId);
                if (cached is not null)
                {
                    return new UserResponse
                    {
                        UserId = cached.UserId,
                        PersonId = cached.PersonId,
                        FullName = cached.FullName,
                        UserName = cached.UserName,
                        Role = Contracts.Enums.Role.Employee,
                        IsActive = cached.IsActive
                    };
                }

                View.DisplayMessage(response.Error?.AllMessages ?? $"Unable to load user #{userId}.");
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage($"Unable to load user #{userId}.");
            }

            return null;
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            View.LoadRequested -= OnLoadRequested;
            View.PageRequested -= OnPageRequested;
            View.SearchOrFilterChanged -= OnSearchOrFilterChanged;
            View.AddUserRequested -= OnAddUserRequested;
            View.ViewPersonRequested -= OnViewPersonRequested;
            View.EditUserRequested -= OnEditUserRequested;
            View.ChangePasswordRequested -= OnChangePasswordRequested;
        }
    }
}
