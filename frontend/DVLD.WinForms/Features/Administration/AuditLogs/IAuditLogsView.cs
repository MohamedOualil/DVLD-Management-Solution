#nullable enable
using DVLD.WinForms.Shared.Controls;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Administration.AuditLogs
{
    public interface IAuditLogsView
    {
        event EventHandler? LoadRequested;
        event EventHandler<int>? PageRequested;
        event EventHandler? SearchOrFilterChanged;

        string SearchTerm { get; }
        string StatusFilter { get; }

        void DisplayAuditLogs(IEnumerable<AuditLogItemDto> logs);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetSourceBanner(string title, string description, HeaderBadgeTone tone);
        void SetLoading(bool isLoading);
        void DisplayMessage(string message);
    }
}
