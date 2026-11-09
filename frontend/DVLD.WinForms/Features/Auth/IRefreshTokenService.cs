using System;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Auth
{
    public interface IRefreshTokenService
    {
        Task<bool> RefreshTokenAsync();
        event EventHandler? OnSessionExpired;
    }
}
