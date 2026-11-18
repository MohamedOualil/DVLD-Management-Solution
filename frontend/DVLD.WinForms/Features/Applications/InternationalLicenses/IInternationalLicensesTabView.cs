#nullable enable
using DVLD.WinForms.Features.Licenses;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Applications.InternationalLicenses
{
    public interface IInternationalLicensesTabView
    {
        event EventHandler? SearchOrFilterChanged;
        event EventHandler<int>? PageRequested;
        event EventHandler<int>? ViewPersonRequested;
        event EventHandler<int>? ViewLicenseRequested;
        event EventHandler<int>? ViewHistoryRequested;

        string SearchTerm { get; }
        int StatusFilterIndex { get; }

        void DisplayInternationalLicenses(IEnumerable<InternationalLicenseListItemDto> items);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
