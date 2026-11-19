using System;

namespace DVLD.Contracts.Administration
{
    public sealed record AuditLogItemDto
    {
        public int LogId { get; init; }
        public DateTime Timestamp { get; init; }
        public string Username { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
        public string Operation { get; init; } = string.Empty;
        public string TargetEntity { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public string Details { get; init; } = string.Empty;
        public string? OldValues { get; init; }
        public string? NewValues { get; init; }
        public string? FailureReason { get; init; }
    }
}
