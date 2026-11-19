using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Common;

namespace DVLD.Application.Administration.GetAuditLogs
{
    public sealed record GetAuditLogsQuery : IQuery<PagedList<AuditLogItemDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 15;
        public string? SearchTerm { get; init; }
        public string? Status { get; init; }
    }
}
