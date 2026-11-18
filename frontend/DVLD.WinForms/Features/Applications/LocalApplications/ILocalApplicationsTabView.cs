#nullable enable
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Events;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Applications.LocalApplications
{
    public interface ILocalApplicationsTabView
    {
        event EventHandler? SearchOrFilterChanged;
        event EventHandler<int>? PageRequested;
        event EventHandler<ApplicationMenuEventArgs>? OpeningActionMenu;
        event EventHandler<PageModeEventArgs>? ApplicationDetailsRequested;
        event EventHandler<int>? CancelApplicationRequested;
        event EventHandler<int>? DeleteApplicationRequested;
        event EventHandler<ScheduleTestEventArgs>? ScheduleTestRequested;
        event EventHandler<int>? IssueDrivingLicenceRequested;
        event EventHandler<int>? ShowLicenceRequested;
        event EventHandler<int>? LicenseHistoryRequested;

        string SearchTerm { get; }
        int StatusFilterId { get; }

        bool IsEditOptionEnabled { set; }
        bool IsCancelOptionEnabled { set; }
        bool IsDeleteOptionEnabled { set; }
        bool IsIssueLicenseOptionEnabled { set; }
        bool IsScheduleTestOptionEnabled { set; }
        bool IsShowLicenceOptionEnabled { set; }

        bool IsScheduleVisionTestEnabled { set; }
        bool IsScheduleWrittenTestEnabled { set; }
        bool IsScheduleStreetTestEnabled { set; }

        void DisplayLocalApplications(IEnumerable<GetAllLocalApplicationsResponse> localApplications);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetPaginationLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
