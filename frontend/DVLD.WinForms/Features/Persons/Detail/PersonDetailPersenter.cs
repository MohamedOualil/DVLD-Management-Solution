using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace DVLD.WinForms.Features.Persons.Detail
{
    public class PersonDetailPersenter : BasePresenter<IPersonDetailView>
    {
        private readonly IPesronService _pesronService ;
        public PersonDetailPersenter(IPersonDetailView view, 
            AppSession appSession, 
            INavigationService navigationService,
            IPesronService pesronService)
            :base(view,appSession,navigationService)
        {
            _pesronService = pesronService;

            View.OnPersonIdReceived += View_OnPersonIdReceived;
        }

        private async void View_OnPersonIdReceived(object? sender, int e)
        {
            await PersonInitialized(e);
        }

        private async Task PersonInitialized(int personId)
        {
            ApiResponse<PersonDto>? person = await _pesronService.GetPerson(personId);

            if (!person.IsSuccess)
            {
                return;
            }

            PersonDto ?personDto = person.Data;
            View.NationlNo = personDto.NationalNo;
            View.DateofBirth = personDto.DateOfBirth.ToString("dd/MM/yyyy");
            View.PersonId = personDto.PersonId.ToString();
            View.FullName = personDto.FullName;
            View.Address = personDto.FullAddress;
            View.Email = personDto.Email;
            View.Phone = personDto.Phone;
            View.Gender = personDto.Gender.ToString();
            View.ImagePath = personDto.ImagePath;
            View.Gender = ((GenderEnum)personDto.Gender).ToString();

        }

        public override void Dispose()
        {
            View.OnPersonIdReceived -= View_OnPersonIdReceived;
        }
    }
}
