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
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponse>> LoginAsync(
            string username, string password);

        Task<ApiResponse<TokenResponse>> RefreshTokenAsync(
            string refreshToken);

        Task<ApiResponse<object>> ChangePasswordAsync(
            int userId, string currentPassword, string newPassword);
    }
}
