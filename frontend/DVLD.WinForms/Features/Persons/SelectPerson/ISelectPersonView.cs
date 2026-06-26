using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Persons.SelectPerson
{
    public interface ISelectPersonView
    {
        event EventHandler SearchRequested;
        string SearchTerm { get; }
        int cbSearchById { get; }
        bool MessageLabel { set; }
        void LoadPersonInfo(PersonDto personDto);
        void DisplayMessage(string message);
    }
}
