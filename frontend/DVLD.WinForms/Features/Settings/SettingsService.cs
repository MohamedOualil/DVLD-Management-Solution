using DVLD.Contracts.Common;
using DVLD.Contracts.Persons;
using DVLD.Contracts.Users;
using DVLD.WinForms.Common;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Settings
{
    public interface ISettingsService
    {
        Task<ApiResponse<PersonResponse>> GetPersonAsync(int personId);
        Task<ApiResponse<object>> UpdatePersonAsync(int personId, UpdatePersonRequest request);
        Task<ApiResponse<object>> ChangePasswordAsync(int userId, ChangePasswordRequest request);
        Task<ApiResponse<PagedList<UsersListResponse>>> GetUsersListAsync(int pageNumber, int pageSize, string? searchName, bool? isActive);
        Task<ApiResponse<UserResponse>> GetUserAsync(int userId);
        Task<ApiResponse<int>> CreateUserAsync(CreateUserRequest request);
        Task<ApiResponse<object>> UpdateUserAsync(int userId, UpdateUserRequest request);
    }

    public class SettingsService(IApiClient apiClient) : ISettingsService
    {
        private readonly IApiClient _apiClient = apiClient;

        public Task<ApiResponse<PersonResponse>> GetPersonAsync(int personId)
        {
            return _apiClient.GetAsync<PersonResponse>($"Person/{personId}");
        }

        public Task<ApiResponse<object>> UpdatePersonAsync(int personId, UpdatePersonRequest request)
        {
            return _apiClient.PutAsync<object>($"Person/{personId}", request);
        }

        public Task<ApiResponse<object>> ChangePasswordAsync(int userId, ChangePasswordRequest request)
        {
            return _apiClient.PatchAsync<object>($"User/{userId}/change-password", request);
        }

        public Task<ApiResponse<PagedList<UsersListResponse>>> GetUsersListAsync(
            int pageNumber, int pageSize, string? searchName, bool? isActive)
        {
            string query = $"User/All?PageNumber={pageNumber}&PageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchName))
                query += $"&FullName={System.Uri.EscapeDataString(searchName)}";
            if (isActive.HasValue)
                query += $"&IsActive={isActive.Value.ToString().ToLowerInvariant()}";

            return _apiClient.GetAsync<PagedList<UsersListResponse>>(query);
        }

        public Task<ApiResponse<UserResponse>> GetUserAsync(int userId)
        {
            return _apiClient.GetAsync<UserResponse>($"User/{userId}");
        }

        public Task<ApiResponse<int>> CreateUserAsync(CreateUserRequest request)
        {
            return _apiClient.PostAsync<int>("User/Create", request);
        }

        public Task<ApiResponse<object>> UpdateUserAsync(int userId, UpdateUserRequest request)
        {
            return _apiClient.PutAsync<object>($"User/{userId}", request);
        }
    }
}
