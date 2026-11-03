using DVLD.Contracts.Persons;
using DVLD.WinForms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Persons
{
    public interface IPesronService 
    {
        Task<ApiResponse<PersonResponse>> GetPerson(int personId);
        Task<ApiResponse<PersonResponse>> GetPersonByNationalNo(string nationalNo);
    }
}
