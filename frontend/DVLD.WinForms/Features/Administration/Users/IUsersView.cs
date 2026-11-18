#nullable enable
using DVLD.Contracts.Users;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Administration.Users
{
    public interface IUsersView
    {
        event EventHandler? LoadRequested;
        event EventHandler<int>? PageRequested;
        event EventHandler? SearchOrFilterChanged;
        event EventHandler? AddUserRequested;
        event EventHandler<int>? ViewPersonRequested;
        event EventHandler<int>? EditUserRequested;
        event EventHandler<int>? ChangePasswordRequested;

        string SearchTerm { get; }
        int StatusFilterIndex { get; }

        void SetAdminAccessState(bool isAdmin, string title, string description, HeaderBadgeTone tone);
        void DisplayUsers(IEnumerable<UsersListResponse> users);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
