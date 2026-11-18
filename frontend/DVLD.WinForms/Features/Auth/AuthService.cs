using DVLD.Contracts.Auth;
using DVLD.Contracts.Users;
using DVLD.WinForms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public class AuthService(IApiClient apiClient) : IAuthService
    {
        private readonly IApiClient _apiClient = apiClient;

        public async Task<ApiResponse<LoginResponse>> LoginAsync(string username, string password)
        {
            return await _apiClient.PostAsync<LoginResponse>("auth/login", new LoginRequest
            {
                Username = username,
                Password = password
            });
        }

        public async Task<ApiResponse<TokenResponse>> RefreshTokenAsync(string refreshToken)
        {
            return await _apiClient.PostAsync<TokenResponse>("auth/refresh", new RefreshTokenRequest(refreshToken));
        }

        public async Task<ApiResponse<object>> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            return await _apiClient.PatchAsync<object>($"User/{userId}/change-password", new ChangePasswordRequest
            {
                CurrentPassword = currentPassword,
                NewPassword = newPassword
            });
        }
    }
}
