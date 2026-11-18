using DVLD.Contracts.Persons;
using DVLD.Contracts.Users;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Settings
{
    public interface ISettingsView
    {
        event EventHandler? OnViewLoaded;
        event EventHandler? OnSaveProfileRequested;
        event EventHandler? OnChangePasswordRequested;
        event EventHandler? OnChangePhotoRequested;
        event EventHandler? OnRefreshUsersRequested;
        event EventHandler? OnAddUserRequested;
        event EventHandler<int>? OnEditUserRequested;

        // Profile Form Inputs
        string FirstName { get; set; }
        string SecondName { get; set; }
        string ThirdName { get; set; }
        string LastName { get; set; }
        string NationalNo { get; set; }
        DateTime DateOfBirth { get; set; }
        byte Gender { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        int CountryId { get; set; }
        string ImagePath { get; set; }

        // Password Form Inputs
        string CurrentPassword { get; set; }
        string NewPassword { get; set; }
        string ConfirmPassword { get; set; }

        // User Management Filter Inputs
        string UserSearchTerm { get; }
        int UserStatusFilterIndex { get; }

        void SetHeaderProfile(string fullName, string roleText, string initials, string? imagePath);
        void DisplayUsers(IEnumerable<UsersListResponse> users, int totalCount);
        void ShowProfileFeedback(string message, bool isError);
        void ShowPasswordFeedback(string message, bool isError);
        void ShowUsersFeedback(string message, bool isError);
        void SetProfileSaving(bool isSaving);
        void SetPasswordSaving(bool isSaving);
    }
}
