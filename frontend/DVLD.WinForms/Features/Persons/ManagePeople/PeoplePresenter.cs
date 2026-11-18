#nullable enable
using DVLD.Contracts.Persons;
using DVLD.WinForms.Common;
using DVLD.WinForms.Shared;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Features.Persons.ManagePeople
{
    public class PeoplePresenter : BasePresenter<IPeopleView>
    {
        private const int PageSize = 15;

        private readonly IPesronService _personService;
        private int _currentPage = 1;
        private bool _disposed;

        public PeoplePresenter(
            IPeopleView view,
            IPesronService personService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _personService = personService;

            View.LoadRequested += OnLoadRequested;
            View.PageRequested += OnPageRequested;
            View.AddPersonRequested += OnAddPersonRequested;
            View.ViewPersonRequested += OnViewPersonRequested;
            View.EditPersonRequested += OnEditPersonRequested;
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
                var response = await _personService.GetAllPersonsAsync(pageNumber, PageSize);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                {
                    _currentPage = response.Data.PageNumber;
                    View.DisplayPeople(response.Data.Items);
                    View.DisplayPagination(response.Data.PageNumber, Math.Max(1, response.Data.TotalPages), response.Data.TotalCount);
                }
                else
                {
                    View.DisplayPeople(Array.Empty<GetAllPersonResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage(response.Error?.AllMessages ?? "Unable to load people directory.");
                }
            }
            catch
            {
                if (!_disposed)
                {
                    View.DisplayPeople(Array.Empty<GetAllPersonResponse>());
                    View.DisplayPagination(1, 1, 0);
                    View.DisplayMessage("Unable to reach the people directory endpoint.");
                }
            }
            finally
            {
                if (!_disposed)
                    View.SetLoading(false);
            }
        }

        private async void OnAddPersonRequested(object? sender, EventArgs e)
        {
            if (_disposed) return;

            PersonEditorForm? editor = null;
            bool saved = false;
            _navigationService.ShowDialog<PersonEditorForm>(form =>
            {
                editor = form;
                form.ConfigureForCreate();
                form.FormClosed += (_, _) => saved = form.DialogResult == DialogResult.OK;
            });

            if (!saved || editor is null || _disposed)
                return;

            var response = await _personService.CreatePersonAsync(editor.BuildCreateRequest());
            if (_disposed) return;

            if (response.IsSuccess && response.Data > 0)
            {
                View.DisplayMessage($"Citizen record #{response.Data} created successfully.");
                await LoadPageAsync(_currentPage);
            }
            else
            {
                View.DisplayMessage(response.Error?.AllMessages ?? "Unable to create person record.");
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

        private async void OnEditPersonRequested(object? sender, int personId)
        {
            if (_disposed || personId <= 0) return;

            var getResponse = await _personService.GetPerson(personId);
            if (_disposed) return;

            if (!getResponse.IsSuccess || getResponse.Data is null)
            {
                View.DisplayMessage(getResponse.Error?.AllMessages ?? "Unable to load person details for editing.");
                return;
            }

            PersonEditorForm? editor = null;
            bool saved = false;
            _navigationService.ShowDialog<PersonEditorForm>(form =>
            {
                editor = form;
                form.ConfigureForEdit(getResponse.Data);
                form.FormClosed += (_, _) => saved = form.DialogResult == DialogResult.OK;
            });

            if (!saved || editor is null || _disposed)
                return;

            var updateResponse = await _personService.UpdatePersonAsync(personId, editor.BuildUpdateRequest(personId));
            if (_disposed) return;

            if (updateResponse.IsSuccess)
            {
                View.DisplayMessage($"Citizen record #{personId} updated successfully.");
                await LoadPageAsync(_currentPage);
            }
            else
            {
                View.DisplayMessage(updateResponse.Error?.AllMessages ?? "Unable to update person record.");
            }
        }

        public override void Dispose()
        {
            _disposed = true;
            View.LoadRequested -= OnLoadRequested;
            View.PageRequested -= OnPageRequested;
            View.AddPersonRequested -= OnAddPersonRequested;
            View.ViewPersonRequested -= OnViewPersonRequested;
            View.EditPersonRequested -= OnEditPersonRequested;
        }
    }
}
