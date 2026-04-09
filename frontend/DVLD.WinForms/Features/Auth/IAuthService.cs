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
        Task<ApiResponse<LoginResponseDto>> LoginAsync(
            string username, string password);
    }
}
