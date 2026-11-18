#nullable enable
using DVLD.Contracts.Drivers;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseHistory;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Drivers
{
    public class DriversPresenter : BasePresenter<IDriversView>
    {
        private const int PageSize = 15;

        private readonly IDriversService _driversService;
        private readonly IPesronService _personService;
        private bool _disposed;

        public DriversPresenter(
            IDriversView view,
            IDriversService driversService,
            IPesronService personService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _driversService = driversService;
            _personService = personService;

            View.LoadRequested += OnLoadRequested;
            View.PageRequested += OnPageRequested;
            View.ViewPersonRequested += OnViewPersonRequested;
            View.ViewLicenseHistoryRequested += OnViewLicenseHistoryRequested;
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadPageAsync(1);
        }

        private async void OnPageRequested(object? sender, int pageNumber)
        {
            await LoadPageAsync(Math.Max(1, pageNumber));
        }

        private async Task LoadPageAsync(int pageNumber)
        {
            if (_disposed) return;

            View.SetLoading(true);
            try
            {
                var response = await _driversService.GetDriversAsync(pageNumber, PageSize);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                {
                    View.DisplayDrivers(response.Data.Items);
                    View.DisplayPagination(response.Data.PageNumber, Math.Max(1, response.Data.TotalPages), response.Data.TotalCount);
                }
                else
                {
                    View.DisplayDrivers(Array.Empty<DriversListResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load drivers directory.");
                }
            }
            catch
            {
                if (!_disposed)
                {
                    View.DisplayDrivers(Array.Empty<DriversListResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage("Unable to reach the drivers directory endpoint.");
                }
            }
            finally
            {
                if (!_disposed)
                    View.SetLoading(false);
            }
        }

        private async void OnViewPersonRequested(object? sender, int personId)
        {
            if (_disposed || personId <= 0) return;

            try
            {
                var response = await _personService.GetPerson(personId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                    _navigationService.ShowDialog<PersonCardForm>(form => form.DisplayPerson(response.Data));
                else
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load person profile.");
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load person profile.");
            }
        }

        private void OnViewLicenseHistoryRequested(object? sender, int personId)
        {
            if (_disposed || personId <= 0) return;

            _navigationService.NavigateTo<LicenseHistoryPresenter, ILicenseHistoryView>(async presenter =>
            {
                await presenter.LoadAsync(personId);
            });
        }

        public override void Dispose()
        {
            _disposed = true;
            View.LoadRequested -= OnLoadRequested;
            View.PageRequested -= OnPageRequested;
            View.ViewPersonRequested -= OnViewPersonRequested;
            View.ViewLicenseHistoryRequested -= OnViewLicenseHistoryRequested;
        }
    }
}
