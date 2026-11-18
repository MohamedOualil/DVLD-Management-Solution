#nullable enable
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Features.Licenses.LicenseHistory;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Applications.InternationalLicenses
{
    public class InternationalLicensesPresenter : BasePresenter<IInternationalLicensesTabView>
    {
        private const int PageSize = 10;

        private readonly ILicensesService _licensesService;
        private readonly IPesronService _personService;
        private int _currentPage = 1;
        private bool _hasLoaded;
        private bool _loadingModal;
        private bool _disposed;

        public InternationalLicensesPresenter(
            IInternationalLicensesTabView view,
            ILicensesService licensesService,
            IPesronService personService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _licensesService = licensesService;
            _personService = personService;

            View.SearchOrFilterChanged += OnSearchOrFilterChanged;
            View.PageRequested += OnPageRequested;
            View.ViewPersonRequested += OnViewPersonRequested;
            View.ViewLicenseRequested += OnViewLicenseRequested;
            View.ViewHistoryRequested += OnViewHistoryRequested;
        }

        public async Task EnsureLoadedAsync()
        {
            if (!_hasLoaded)
                await LoadAsync(1);
        }

        public async Task LoadAsync(int pageNumber = 1)
        {
            if (_disposed) return;

            _hasLoaded = true;
            _currentPage = pageNumber;
            View.SetLoading(true);
            try
            {
                var response = await _licensesService.GetAllInternationalLicensesAsync(
                    _currentPage, PageSize, View.SearchTerm, View.StatusFilterIndex);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                {
                    View.DisplayInternationalLicenses(response.Data.Items);
                    View.DisplayPagination(response.Data.PageNumber, Math.Max(1, response.Data.TotalPages), response.Data.TotalCount);
                }
                else
                {
                    View.DisplayInternationalLicenses(Array.Empty<InternationalLicenseListItemDto>());
                    View.DisplayPagination(1, 1, 0);
                }
            }
            catch
            {
                if (!_disposed)
                {
                    View.DisplayInternationalLicenses(Array.Empty<InternationalLicenseListItemDto>());
                    View.DisplayPagination(1, 1, 0);
                }
            }
            finally
            {
                if (!_disposed)
                    View.SetLoading(false);
            }
        }

        private async void OnSearchOrFilterChanged(object? sender, EventArgs e)
        {
            await LoadAsync(1);
        }

        private async void OnPageRequested(object? sender, int pageNumber)
        {
            await LoadAsync(Math.Max(1, pageNumber));
        }

        private async void OnViewPersonRequested(object? sender, int personId)
        {
            if (_disposed || _loadingModal || personId <= 0) return;

            _loadingModal = true;
            try
            {
                var response = await _personService.GetPerson(personId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                    _navigationService.ShowDialog<PersonCardForm>(form => form.DisplayPerson(response.Data));
                else
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load driver profile.");
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load driver profile.");
            }
            finally
            {
                _loadingModal = false;
            }
        }

        private async void OnViewLicenseRequested(object? sender, int licenseId)
        {
            if (_disposed || _loadingModal || licenseId <= 0) return;

            _loadingModal = true;
            try
            {
                var response = await _licensesService.GetLicenseAsync(licenseId);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                    _navigationService.ShowDialog<LicenseCardForm>(form => form.DisplayLicense(response.Data));
                else
                    View.DisplayMessage(response.Error?.AllMessages ?? $"License #{licenseId} details are unavailable.");
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load license card.");
            }
            finally
            {
                _loadingModal = false;
            }
        }

        private void OnViewHistoryRequested(object? sender, int personId)
        {
            if (_disposed || personId <= 0) return;

            _navigationService.NavigateTo<LicenseHistoryPresenter, ILicenseHistoryView>(async presenter =>
            {
                await presenter.LoadAsync(personId);
            });
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            View.SearchOrFilterChanged -= OnSearchOrFilterChanged;
            View.PageRequested -= OnPageRequested;
            View.ViewPersonRequested -= OnViewPersonRequested;
            View.ViewLicenseRequested -= OnViewLicenseRequested;
            View.ViewHistoryRequested -= OnViewHistoryRequested;
        }
    }
}
