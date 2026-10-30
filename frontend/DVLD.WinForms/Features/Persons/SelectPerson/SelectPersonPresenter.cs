using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Persons.SelectPerson
{
    public class SelectPersonPresenter : BasePresenter<ISelectPersonView>
    {
        private readonly IPesronService _personService;

        private bool _disposed;
        private bool _searching;

        public event Action<int>? PersonSelected;
        public event Action? NoPersonSelected;
        public enum SearchBy
        {
            PersonId = 0,
            NationalNo = 1,
        }
        public SelectPersonPresenter(
            ISelectPersonView view,
            IPesronService pesronService,
            AppSession session,
            INavigationService navigationService) :
            base(view, session, navigationService)
        {
            _personService = pesronService;

            View.SearchRequested += View_SearchRequested;
            View.SearchCriteriaChanged += View_SearchCriteriaChanged;


            View.ClearPersonInfo();
            View.SetBusy(false);
        }

        private void View_SearchCriteriaChanged(object? sender, EventArgs e)
        {
            if (_disposed || _searching)
                return;

            ClearSelection();
        }

        private async void View_SearchRequested(object? sender, EventArgs e)
        {

            await SearchForPersonCardAsync();

        }


        private async Task SearchForPersonCardAsync()
        {
            if (_disposed || _searching)
                return;
            _searching = true;
            try
            {
                View.SetBusy(true);

                ClearSelection();
                string? searchTerm = View.SearchTerm?.Trim();
                var searchBy = (SearchBy)View.cbSearchById;

                View.MessageLabel = false;
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    View.DisplayMessage(
                        "Enter a person ID or national number.");
                    return;
                }

                ApiResponse<PersonDto> response;

                switch (searchBy)
                {
                    case SearchBy.PersonId:
                        if (!int.TryParse(searchTerm, out int personId) ||
                            personId <= 0)
                        {
                            View.DisplayMessage(
                                "Enter a valid positive person ID.");
                            return;
                        }

                        response = await _personService.GetPerson(personId);
                        break;

                    case SearchBy.NationalNo:
                        response =
                            await _personService.GetPersonByNationalNo(
                                searchTerm);
                        break;

                    default:
                        View.DisplayMessage("Select a valid search option.");
                        return;
                }

                if (_disposed)
                    return;

                if (!response.IsSuccess)
                {
                    string? message = response.Error?.AllMessages;

                    View.DisplayMessage(
                        string.IsNullOrWhiteSpace(message)
                            ? "Unable to find the applicant."
                            : message);

                    return;
                }

                if (response.Data is null || response.Data.PersonId <= 0)
                {
                    View.DisplayMessage(
                        "The search returned invalid applicant information.");
                    return;
                }

                View.LoadPersonInfo(response.Data);
                PersonSelected?.Invoke(response.Data.PersonId);
            }

            catch (Exception)
            {
                if (!_disposed)
                {
                    ClearSelection();

                    View.DisplayMessage(
                        "Unable to complete the search. Please try again.");
                }
            }
            finally
            {
                _searching = false;

                if (!_disposed)
                    View.SetBusy(false);
            }


        }



        private async Task<ApiResponse<PersonDto>?> GetPersonByPersonId(string searchTerm)
        {
            if (!int.TryParse(searchTerm, out int personId) || personId <= 0)
            {
                View.DisplayMessage("Invalid Person ID. Please enter a valid number.");
                return null;
            }

            return await _personService.GetPerson(personId);

        }


        private void ClearSelection()
        {
            View.ClearPersonInfo();
            NoPersonSelected?.Invoke();
        }

        public override void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            View.SearchRequested -= View_SearchRequested;
            View.SearchCriteriaChanged -= View_SearchCriteriaChanged;
        }
    }
}
