using DVLD.Contracts.Auth;
using DVLD.Contracts.Enums;
using System;

namespace DVLD.WinForms.Common
{
    public class AppSession
    {
        public string CurrentToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? AccessTokenExpiresAt { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }

        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; } = string.Empty;
        public Role Role { get; set; } 

        public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentToken);
        public bool IsAdmin => Role == Role.Admin;

        public bool IsAccessTokenExpired =>
            AccessTokenExpiresAt.HasValue && DateTime.UtcNow >= AccessTokenExpiresAt.Value;

        public bool CanRefresh =>
            !string.IsNullOrEmpty(RefreshToken) &&
            (!RefreshTokenExpiresAt.HasValue || DateTime.UtcNow < RefreshTokenExpiresAt.Value);

        public void UpdateTokens(TokenResponse token)
        {
            CurrentToken = token.AccessToken;
            RefreshToken = token.RefreshToken;
            AccessTokenExpiresAt = token.AccessTokenExpiresAt;
            RefreshTokenExpiresAt = token.RefreshTokenExpiresAt;
        }

        public void Logout()
        {
            CurrentToken = string.Empty;
            RefreshToken = string.Empty;
            AccessTokenExpiresAt = null;
            RefreshTokenExpiresAt = null;
            UserId = 0;
            PersonId = 0;
            Username = string.Empty;
            Role = default;
        }
    }
}
