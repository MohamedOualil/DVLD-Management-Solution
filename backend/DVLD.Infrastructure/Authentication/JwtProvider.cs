using DVLD.Application.Abstractions.Authentication;
using DVLD.Domain.Entities;
using DVLD.Infrastructure.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            var claims = new[]
            {
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
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                signingCredentials: creds
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            string refreshToken = GenerateRefreshToken();

            DateTime refreshTokenExpiresInDays = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiresInDays);

            return new TokenResponse(accessToken, refreshToken, refreshTokenExpiresInDays);
        }

        private  string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
