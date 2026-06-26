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
        private readonly IPesronService _pesronService;
        public event Action<int>? PersonSelected;
        public event Action NoPersonSelected;
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
            _pesronService = pesronService;

            View.SearchRequested += View_SearchRequested;
        }

        private async void View_SearchRequested(object? sender, EventArgs e)
        {
            try
            {
                await SearchForPersonCardAsync();
            }
            catch (Exception)
            {
                View.DisplayMessage("An unexpected error occurred during the search.");
            }
        }


        private async Task SearchForPersonCardAsync()
        {

            string? searchTerm = View.SearchTerm?.Trim();

            View.MessageLabel = false;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                View.DisplayMessage("Requered");
                NoPersonSelected?.Invoke();
                return;
            }

            var searchBy = (SearchBy)View.cbSearchById;

            ApiResponse<PersonDto>? person = searchBy switch
            {
                SearchBy.PersonId => await GetPersonByPersonId(searchTerm),
                SearchBy.NationalNo => await _pesronService.GetPersonByNationalNo(searchTerm),
                _ => null
            };

            if (person is null)
            {
                NoPersonSelected?.Invoke();
                return;
            }
                

            if (!person.IsSuccess)
            {
                View.DisplayMessage(person.Error!.AllMessages);
                NoPersonSelected?.Invoke();
                return;
            }

            View.LoadPersonInfo(person.Data!);

            PersonSelected?.Invoke(person.Data!.PersonId);
        }

        private async Task<ApiResponse<PersonDto>?> GetPersonByPersonId(string searchTerm)
        {
            if (!int.TryParse(searchTerm, out int personId) || personId <= 0)
            {
                View.DisplayMessage("Invalid Person ID. Please enter a valid number.");
                return null;
            }

            return await _pesronService.GetPerson(personId);

        }


        public override void Dispose()
        {
            View.SearchRequested -= View_SearchRequested;
        }
    }
}
