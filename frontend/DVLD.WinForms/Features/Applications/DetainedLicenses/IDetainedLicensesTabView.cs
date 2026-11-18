#nullable enable
using DVLD.WinForms.Features.Licenses;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Applications.DetainedLicenses
{
    public interface IDetainedLicensesTabView
    {
        event EventHandler? SearchOrFilterChanged;
        event EventHandler<int>? PageRequested;
        event EventHandler<int>? ViewPersonRequested;
        event EventHandler<int>? ViewLicenseRequested;
        event EventHandler<int>? ViewHistoryRequested;
        event EventHandler<int>? ReleaseDetainedLicenseRequested;
        event EventHandler? OpenDetainReleaseScreenRequested;

        string SearchTerm { get; }
        int StatusFilterIndex { get; }

        void DisplayDetainedLicenses(IEnumerable<DetainedLicenseListItemDto> items);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
