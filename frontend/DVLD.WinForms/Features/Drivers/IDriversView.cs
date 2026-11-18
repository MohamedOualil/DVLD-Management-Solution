#nullable enable
using DVLD.Contracts.Drivers;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Drivers
{
    public interface IDriversView
    {
        event EventHandler? LoadRequested;
        event EventHandler<int>? PageRequested;
        event EventHandler<int>? ViewPersonRequested;
        event EventHandler<int>? ViewLicenseHistoryRequested;

        void DisplayDrivers(IEnumerable<DriversListResponse> drivers);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
