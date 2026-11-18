#nullable enable
using DVLD.Contracts.Common;
using DVLD.Contracts.Persons;
using DVLD.WinForms.Common;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Persons
{
    public interface IPesronService
    {
        Task<ApiResponse<PersonResponse>> GetPerson(int personId);
        Task<ApiResponse<PersonResponse>> GetPersonByNationalNo(string nationalNo);
        Task<ApiResponse<PagedList<GetAllPersonResponse>>> GetAllPersonsAsync(int pageNumber, int pageSize);
        Task<ApiResponse<int>> CreatePersonAsync(CreatePersonRequest request);
        Task<ApiResponse<bool>> UpdatePersonAsync(int personId, UpdatePersonRequest request);
    }
}
