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
        public string? DeviceInfo { get; private set; }

        public DateTime CreateAt { get; private set; }
    }
}
