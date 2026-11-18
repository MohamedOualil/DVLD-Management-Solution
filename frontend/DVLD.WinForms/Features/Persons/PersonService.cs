#nullable enable
using DVLD.Contracts.Common;
using DVLD.Contracts.Persons;
using DVLD.WinForms.Common;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Persons
{
    public class PersonService(IApiClient apiClient) : IPesronService
    {
        private readonly IApiClient _apiClient = apiClient;

        public Task<ApiResponse<PersonResponse>> GetPerson(int personId)
            => _apiClient.GetAsync<PersonResponse>($"Person/{personId}");

        public Task<ApiResponse<PersonResponse>> GetPersonByNationalNo(string nationalNo)
            => _apiClient.GetAsync<PersonResponse>($"Person/NationalNo/{nationalNo}");

        public Task<ApiResponse<PagedList<GetAllPersonResponse>>> GetAllPersonsAsync(int pageNumber, int pageSize)
            => _apiClient.GetAsync<PagedList<GetAllPersonResponse>>($"Person?pageNumber={pageNumber}&pageSize={pageSize}");

        public Task<ApiResponse<int>> CreatePersonAsync(CreatePersonRequest request)
            => _apiClient.PostAsync<int>("Person", request);

        public Task<ApiResponse<bool>> UpdatePersonAsync(int personId, UpdatePersonRequest request)
            => _apiClient.PutAsync<bool>($"Person/{personId}", request);
    }
}
