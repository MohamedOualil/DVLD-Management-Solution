using DVLD.Application.Abstractions.Authentication;
using DVLD.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace DVLD.Infrastructure.Authentication
{
    internal sealed class MemoryUserAccessInvalidator : IUserAccessInvalidator
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _ttl;

        public MemoryUserAccessInvalidator(IMemoryCache cache, IOptions<JwtSettings> jwtSettings)
        {
            _cache = cache;
            int expiryMinutes = Math.Max(1, jwtSettings.Value.ExpiresInMinutes);
            _ttl = TimeSpan.FromMinutes(expiryMinutes + 1);
        }

        public void InvalidateUserAccess(int userId)
        {
            if (userId <= 0)
                return;

            _cache.Set(GetCacheKey(userId), DateTime.UtcNow, _ttl);
        }

        public bool IsTokenInvalidated(int userId, DateTime tokenIssuedAtUtc)
        {
            if (userId <= 0)
                return false;

            return _cache.TryGetValue(GetCacheKey(userId), out DateTime invalidatedAtUtc) &&
                   tokenIssuedAtUtc <= invalidatedAtUtc;
        }

        private static string GetCacheKey(int userId) => $"revoked-user-access:{userId}";
    }
}
