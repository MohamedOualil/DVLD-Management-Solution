using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class UserSession : Entity
    {
        public int UserId { get;private set; }
        public User User { get; private set; }
        public string RefreshTokenHash { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public string? CreatedIp { get; private set; }

        public string DeviceId { get; private set; }
        public string? DeviceInfo { get; private set; }

        public DateTime CreateAt { get; private set; }

        public bool IsActive => RevokedAt == null && ExpiresAt >= DateTime.UtcNow;

        private UserSession() { }
        private UserSession(User user, string refreshTokenHash,
            DateTime refreshTokenExpiresAt,
            DateTime? refreshTokenRevokedAt,
            string createdIp,
            string deviceId,
            string deviceInfo)
        {
            RefreshTokenHash = refreshTokenHash;
            ExpiresAt = refreshTokenExpiresAt;
            RevokedAt = refreshTokenRevokedAt;
            CreatedIp = createdIp;
            DeviceInfo = deviceInfo;
            User = user;
            UserId = user.Id;
        }

        public static UserSession RegisterUserSession(User user,string refreshTokenHash,
            DateTime refreshTokenExpiresAt,
            string createdIp,
            string deviceId,
            string deviceInfo)
        {
            return new UserSession(user, refreshTokenHash, 
                refreshTokenExpiresAt, null, createdIp,deviceId, deviceInfo);
        }
    }
    
}
