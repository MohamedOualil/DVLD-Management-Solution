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
        public int UserId { get; private set; }
        public User User { get; private set; } = null!;

        public string RefreshTokenHash { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }


        public bool IsRevoked => RevokedAt != null;
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsActive => !IsRevoked && !IsExpired;


        private UserSession() { }

        public static UserSession Create(int userId, string refreshTokenHash, DateTime expiresAt) => new()
        {
            UserId = userId,
            RefreshTokenHash = refreshTokenHash,
            ExpiresAt = expiresAt,
            CreatedAt = DateTime.UtcNow
        };

        public void UpdateToken(string newRefreshTokenHash, DateTime newExpiresAt)
        {
            RefreshTokenHash = newRefreshTokenHash;
            ExpiresAt = newExpiresAt;
            RevokedAt = null; // Re-activates on new login
        }

        

        public void Revoke()
        {
            if (IsRevoked) return;
            RevokedAt = DateTime.UtcNow;
        }
    }
    
}
