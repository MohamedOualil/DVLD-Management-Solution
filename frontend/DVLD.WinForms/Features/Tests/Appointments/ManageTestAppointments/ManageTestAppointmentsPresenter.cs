#nullable enable
using DVLD.Contracts.Enums;
using DVLD.Contracts.LocalLicenseApplications;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Licenses.LicenseHistory;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using DVLD.WinForms.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Tests.Appointments.ManageTestAppointments
{
    public class ManageTestAppointmentsPresenter : BasePresenter<IManageTestAppointmentsView>
    {
        private const int PageSize = 10;

        private readonly IApplicationsService _applicationsService;
        private int _currentPage = 1;
        private int _loadVersion;
        private bool _disposed;

        public ManageTestAppointmentsPresenter(
            IManageTestAppointmentsView view,
            IApplicationsService applicationsService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _applicationsService = applicationsService;

            View.LoadRequested += OnLoadRequested;
            View.PageRequested += OnPageRequested;
            View.FilterChanged += OnFilterChanged;
            View.ManageAppointmentsRequested += OnManageAppointmentsRequested;
            View.ViewApplicationDetailsRequested += OnViewApplicationDetailsRequested;
            View.ViewLicenseHistoryRequested += OnViewLicenseHistoryRequested;
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadQueueAsync(1);
        }

        private async void OnPageRequested(object? sender, int pageNumber)
        {
            await LoadQueueAsync(Math.Max(1, pageNumber));
        }

        private async void OnFilterChanged(object? sender, EventArgs e)
        {
            await LoadQueueAsync(1);
        }

        private async Task LoadQueueAsync(int requestedPage)
        {
            if (_disposed) return;

            int version = ++_loadVersion;
            _currentPage = requestedPage;
            View.SetLoading(true);

            try
            {
                int mappedStatusId = View.StatusFilterIndex switch
                {
                    1 => (int)ApplicationStatusEnum.New,
                    2 => (int)ApplicationStatusEnum.Cancelled,
                    3 => (int)ApplicationStatusEnum.Completed,
                    _ => 0
                };

                var kpiTask = _applicationsService.GetAllLocalApplicationsAsync(1, 50, string.Empty, (int)ApplicationStatusEnum.New);
                int fetchSize = View.StageFilterIndex == 0 ? PageSize : 50;
                int fetchPage = View.StageFilterIndex == 0 ? _currentPage : 1;
                var listTask = _applicationsService.GetAllLocalApplicationsAsync(fetchPage, fetchSize, View.SearchTerm, mappedStatusId);

                await Task.WhenAll(kpiTask, listTask);
                if (_disposed || version != _loadVersion)
                    return;

                var kpiResponse = await kpiTask;
                if (kpiResponse.IsSuccess && kpiResponse.Data is not null)
                {
                    var active = kpiResponse.Data.Items;
                    int vision = active.Count(a => a.PassedTest == 0);
                    int written = active.Count(a => a.PassedTest == 1);
                    int street = active.Count(a => a.PassedTest == 2);
                    View.SetKpiSummary(vision + written + street, vision, written, street);
                }

                var listResponse = await listTask;
                if (!listResponse.IsSuccess || listResponse.Data is null)
                {
                    View.DisplayApplications(Array.Empty<GetAllLocalApplicationsResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage(listResponse.Error?.AllMessages ?? "Unable to load test appointment queues.");
                    return;
                }

                if (View.StageFilterIndex == 0)
                {
                    View.DisplayApplications(listResponse.Data.Items);
                    View.DisplayPagination(
                        listResponse.Data.PageNumber,
                        Math.Max(1, listResponse.Data.TotalPages),
                        listResponse.Data.TotalCount);
                    return;
                }

                int stageIndex = View.StageFilterIndex;
                var filtered = listResponse.Data.Items.Where(a => stageIndex switch
                {
                    1 => a.PassedTest == 0,
                    2 => a.PassedTest == 1,
                    3 => a.PassedTest == 2,
                    4 => a.PassedTest >= 3,
                    _ => true
                }).ToList();

                int totalCount = filtered.Count;
                int totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)PageSize));
                int clampedPage = Math.Min(_currentPage, totalPages);
                var slice = filtered.Skip((clampedPage - 1) * PageSize).Take(PageSize).ToList();

                View.DisplayApplications(slice);
                View.DisplayPagination(clampedPage, totalPages, totalCount);
            }
            catch
            {
                if (!_disposed && version == _loadVersion)
                {
                    View.DisplayApplications(Array.Empty<GetAllLocalApplicationsResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage("Unable to load test appointments queue.");
                }
            }
            finally
            {
                if (!_disposed && version == _loadVersion)
                    View.SetLoading(false);
            }
        }

        private void OnManageAppointmentsRequested(object? sender, ScheduleTestEventArgs e)
        {
            if (_disposed || e.LocalApplicationId <= 0) return;
            _navigationService.NavigateTo<ListTestAppointmentsPresenter, IListTestAppointmentsView>(async presenter =>
            {
                await presenter.LoadTestAppointementsAsync(e.LocalApplicationId, e.TestTypeEnum);
            });
        }

        private void OnViewApplicationDetailsRequested(object? sender, int localApplicationId)
        {
            if (_disposed || localApplicationId <= 0) return;
            _navigationService.NavigateTo<ApplicationDetailPresenter, IApplicationDetailView>(async presenter =>
            {
                await presenter.LoadApplicationDetails(localApplicationId, StatusMode.ViewMode);
            });
        }

        private async void OnViewLicenseHistoryRequested(object? sender, int localApplicationId)
        {
            if (_disposed || localApplicationId <= 0) return;

            try
            {
                var response = await _applicationsService.GetApplicationDetails(localApplicationId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null && response.Data.PersonId > 0)
                {
                    int personId = response.Data.PersonId;
                    _navigationService.NavigateTo<LicenseHistoryPresenter, ILicenseHistoryView>(async presenter =>
                    {
                        await presenter.LoadAsync(personId);
                    });
                }
                else
                {
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to resolve applicant details.");
                }
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to open applicant license history.");
            }
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            ++_loadVersion;

            View.LoadRequested -= OnLoadRequested;
            View.PageRequested -= OnPageRequested;
            View.FilterChanged -= OnFilterChanged;
            View.ManageAppointmentsRequested -= OnManageAppointmentsRequested;
            View.ViewApplicationDetailsRequested -= OnViewApplicationDetailsRequested;
            View.ViewLicenseHistoryRequested -= OnViewLicenseHistoryRequested;
        }
    }
}
