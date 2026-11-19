using DVLD.Application.Abstractions.Authentication;
using DVLD.Contracts.Auth;
using DVLD.Domain.Entities;
using DVLD.Infrastructure.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DVLD.Infrastructure.Authentication
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings _jwtSettings;

        public JwtProvider(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public TokenResponse Generate(User user)
        {
            var now = DateTime.UtcNow;
            var accessExpiry = now.AddMinutes(_jwtSettings.ExpiresInMinutes);
            var refreshExpiry = now.AddDays(_jwtSettings.RefreshTokenExpiresInDays);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("iat_ticks", now.Ticks.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("PersonId", user.PersonId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: now,
                expires: accessExpiry,
                signingCredentials: creds);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            string refreshToken = GenerateRefreshToken();

            return new TokenResponse(accessToken, refreshToken, refreshExpiry, accessExpiry);
        }

        public string HashRefreshToken(string refreshToken)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken));
            return Convert.ToHexString(hash);
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
