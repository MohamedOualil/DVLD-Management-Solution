using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Services
{
    public sealed class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string SecretKey { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public int ExpiresInMinutes { get; init; } = 60;
    }
}
