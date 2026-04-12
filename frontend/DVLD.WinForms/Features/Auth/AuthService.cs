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


        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(string username, string password)
        {
            return await _apiClient.PostAsync<LoginResponseDto>("auth/login", new { username, password });
        }
    }
}
