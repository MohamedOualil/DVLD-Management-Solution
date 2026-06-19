using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Persons.Detail
{
    public interface IPersonDetailView
    {
        string FullName { set; }
        string DateofBirth { set; }
        string NationlNo { set; }
        string Gender { set; }
        string Phone { set; }
        string Email { set; }
        string Address { set; }
        string PersonId { set; }

        string ImagePath { set; }
    }
}
