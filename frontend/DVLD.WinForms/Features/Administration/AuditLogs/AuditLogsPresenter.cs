#nullable enable
using DVLD.WinForms.Common;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Administration.AuditLogs
{
    public class AuditLogsPresenter : BasePresenter<IAuditLogsView>
    {
        private const int PageSize = 15;

        private readonly IAdministrationService _administrationService;
        private int _currentPage = 1;
        private bool _disposed;

        public AuditLogsPresenter(
            IAuditLogsView view,
            IAdministrationService administrationService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _administrationService = administrationService;

            View.LoadRequested += OnLoadRequested;
            View.PageRequested += OnPageRequested;
            View.SearchOrFilterChanged += OnSearchOrFilterChanged;
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadPageAsync(1);
        }

        private async void OnPageRequested(object? sender, int pageNumber)
        {
            await LoadPageAsync(Math.Max(1, pageNumber));
        }

        private async void OnSearchOrFilterChanged(object? sender, EventArgs e)
        {
            await LoadPageAsync(1);
        }

        private async Task LoadPageAsync(int pageNumber)
        {
            if (_disposed) return;

            _currentPage = pageNumber;
            View.SetLoading(true);
            try
            {
                var response = await _administrationService.GetAuditLogsAsync(
                    _currentPage,
                    PageSize,
                    View.SearchTerm,
                    View.StatusFilter);

                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                {
                    var page = response.Data.Page;
                    View.DisplayAuditLogs(page.Items);
                    View.DisplayPagination(page.PageNumber, Math.Max(1, page.TotalPages), page.TotalCount);

                    View.SetSourceBanner(
                        response.Data.IsFromLiveApi ? "Live Audit Stream Connected" : "Local Session Activity Feed",
                        response.Data.IsFromLiveApi
                            ? $"Streaming server audit telemetry ({page.TotalCount} total records)."
                            : "Backend AuditLogs endpoint is not active yet — showing live activity recorded during this session.",
                        response.Data.IsFromLiveApi ? HeaderBadgeTone.Success : HeaderBadgeTone.Warning);
                }
                else
                {
                    View.DisplayAuditLogs(Array.Empty<AuditLogItemDto>());
                    View.DisplayPagination(1, 1, 0);
                    View.SetSourceBanner("Audit Load Failed", response.Error?.AllMessages ?? "Unable to load audit log entries.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!_disposed)
                {
                    View.DisplayAuditLogs(Array.Empty<AuditLogItemDto>());
                    View.DisplayPagination(1, 1, 0);
                    View.SetSourceBanner("Connection Error", "Unable to reach audit logs endpoint.", HeaderBadgeTone.Danger);
                }
            }
            finally
            {
                if (!_disposed)
                    View.SetLoading(false);
            }
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            View.LoadRequested -= OnLoadRequested;
            View.PageRequested -= OnPageRequested;
            View.SearchOrFilterChanged -= OnSearchOrFilterChanged;
        }
    }
}
