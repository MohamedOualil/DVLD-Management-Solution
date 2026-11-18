#nullable enable
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Shared.Events;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Tests.Appointments.ManageTestAppointments
{
    public interface IManageTestAppointmentsView
    {
        event EventHandler? LoadRequested;
        event EventHandler<int>? PageRequested;
        event EventHandler? FilterChanged;
        event EventHandler<ScheduleTestEventArgs>? ManageAppointmentsRequested;
        event EventHandler<int>? ViewApplicationDetailsRequested;
        event EventHandler<int>? ViewLicenseHistoryRequested;

        string SearchTerm { get; }
        int StageFilterIndex { get; }
        int StatusFilterIndex { get; }

        void DisplayApplications(IEnumerable<GetAllLocalApplicationsResponse> items);
        void DisplayPagination(int pageNumber, int totalPages, int totalCount);
        void SetLoading(bool isLoading);
        void SetKpiSummary(int totalActiveExams, int visionQueue, int writtenQueue, int streetQueue);
        void DisplayMessage(string message);
    }
}
