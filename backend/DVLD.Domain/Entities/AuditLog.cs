using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Entities
{
    public class AuditLog : Entity
    {

        public int? UserId { get; private set; }
        public string UserName { get; private set; } = "anonymous";

        public string Action { get; private set; } = string.Empty;


        public string EntityName { get; private set; } = string.Empty;
        public string EntityId { get; private set; } = string.Empty;

        public string? OldValues { get; private set; }
        public string? NewValues { get; private set; }


        public bool IsSuccess { get; private set; }
        public string FailureReason { get; private set; } = string.Empty;


        public string IpAddress { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;


        private AuditLog() { }

        public static AuditLog Create(
            int? userId,
            string userEmail,
            string action,
            string entityName,
            string entityId,
            string? oldValues,
            string? newValues,
            bool isSuccess,
            string failureReason,
            string ipAddress)
        {
            return new AuditLog
            {
                UserId = userId,
                UserName = string.IsNullOrWhiteSpace(userEmail) ? "anonymous" : userEmail,
                Action = action,
                EntityName = entityName,
                EntityId = entityId,
                OldValues = oldValues,
                NewValues = newValues,
                IsSuccess = isSuccess,
                FailureReason = failureReason ?? string.Empty,
                IpAddress = ipAddress ?? "unknown",
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
