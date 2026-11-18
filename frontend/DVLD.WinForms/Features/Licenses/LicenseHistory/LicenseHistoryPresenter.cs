#nullable enable
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Shared;
using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Licenses.LicenseHistory
{
    public class LicenseHistoryPresenter : BasePresenter<ILicenseHistoryView>
    {
        private const int PageSize = 10;

        private readonly IPesronService _personService;
        private readonly ILicensesService _licensesService;
        private int _personId;
        private bool _disposed;

        public LicenseHistoryPresenter(
            ILicenseHistoryView view,
            IPesronService personService,
            ILicensesService licensesService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _personService = personService;
            _licensesService = licensesService;

            View.ViewLocalLicenseRequested += OnViewLocalLicenseRequested;
            View.ViewInternationalLicenseRequested += OnViewInternationalLicenseRequested;
            View.LocalPageRequested += OnLocalPageRequested;
            View.InternationalPageRequested += OnInternationalPageRequested;
            View.CloseRequested += OnCloseRequested;
        }

        public async Task LoadAsync(int personId)
        {
            if (_disposed || personId <= 0)
                return;

            _personId = personId;
            try
            {
                var personTask = _personService.GetPerson(personId);
                var localTask = _licensesService.GetLocalLicenseHistoryAsync(personId, 1, PageSize);
                var intlTask = _licensesService.GetInternationalLicenseHistoryAsync(personId, 1, PageSize);

                await Task.WhenAll(personTask, localTask, intlTask);
                if (_disposed) return;

                if (personTask.Result.IsSuccess && personTask.Result.Data is not null)
                    View.DisplayPerson(personTask.Result.Data);
                else
                    View.DisplayMessage(personTask.Result.Error?.AllMessages ?? "Unable to load driver profile.");

                if (localTask.Result.IsSuccess && localTask.Result.Data is not null)
                {
                    View.DisplayLocalLicenses(localTask.Result.Data.Items);
                    View.DisplayLocalPagination(localTask.Result.Data.PageNumber, Math.Max(1, localTask.Result.Data.TotalPages), localTask.Result.Data.TotalCount);
                }
                else
                {
                    View.DisplayLocalLicenses(Array.Empty<GetLocalDrivingLicenseHistoryResponse>());
                    View.DisplayLocalPagination(1, 1, 0);
                }

                if (intlTask.Result.IsSuccess && intlTask.Result.Data is not null)
                {
                    View.DisplayInternationalLicenses(intlTask.Result.Data.Items);
                    View.DisplayInternationalPagination(intlTask.Result.Data.PageNumber, Math.Max(1, intlTask.Result.Data.TotalPages), intlTask.Result.Data.TotalCount);
                }
                else
                {
                    View.DisplayInternationalLicenses(Array.Empty<GetInternationalDrivingLicenseHistoryResponse>());
                    View.DisplayInternationalPagination(1, 1, 0);
                }
            }
            catch
            {
                if (!_disposed)
                    View.DisplayMessage("Unable to load license history.");
            }
        }

        private async void OnLocalPageRequested(object? sender, int pageNumber)
        {
            if (_disposed || _personId <= 0) return;

            var response = await _licensesService.GetLocalLicenseHistoryAsync(_personId, Math.Max(1, pageNumber), PageSize);
            if (_disposed || !response.IsSuccess || response.Data is null) return;

            View.DisplayLocalLicenses(response.Data.Items);
            View.DisplayLocalPagination(response.Data.PageNumber, Math.Max(1, response.Data.TotalPages), response.Data.TotalCount);
        }

        private async void OnInternationalPageRequested(object? sender, int pageNumber)
        {
            if (_disposed || _personId <= 0) return;

            var response = await _licensesService.GetInternationalLicenseHistoryAsync(_personId, Math.Max(1, pageNumber), PageSize);
            if (_disposed || !response.IsSuccess || response.Data is null) return;

            View.DisplayInternationalLicenses(response.Data.Items);
            View.DisplayInternationalPagination(response.Data.PageNumber, Math.Max(1, response.Data.TotalPages), response.Data.TotalCount);
        }

        private async void OnViewLocalLicenseRequested(object? sender, int licenseId)
        {
            if (_disposed || licenseId <= 0) return;

            var response = await _licensesService.GetLicenseAsync(licenseId);
            if (_disposed) return;

            if (response.IsSuccess && response.Data is not null)
                _navigationService.ShowDialog<LicenseCardForm>(form => form.DisplayLicense(response.Data));
            else
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load licence card.");
        }

        private void OnViewInternationalLicenseRequested(object? sender, int internationalLicenseId)
        {
            if (_disposed || internationalLicenseId <= 0) return;

            View.DisplayMessage($"Selected International Driving Permit #{internationalLicenseId}.");
        }

        private void OnCloseRequested(object? sender, EventArgs e)
        {
            if (!_disposed)
                _navigationService.GoBack();
        }

        public override void Dispose()
        {
            _disposed = true;
            View.ViewLocalLicenseRequested -= OnViewLocalLicenseRequested;
            View.ViewInternationalLicenseRequested -= OnViewInternationalLicenseRequested;
            View.LocalPageRequested -= OnLocalPageRequested;
            View.InternationalPageRequested -= OnInternationalPageRequested;
            View.CloseRequested -= OnCloseRequested;
        }
    }
}
