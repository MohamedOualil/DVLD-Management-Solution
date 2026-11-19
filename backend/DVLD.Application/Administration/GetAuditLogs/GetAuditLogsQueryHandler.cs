using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Common;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DVLD.Application.Administration.GetAuditLogs
{
    internal sealed class GetAuditLogsQueryHandler
        : IQueryHandler<GetAuditLogsQuery, PagedList<AuditLogItemDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAuditLogsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<PagedList<AuditLogItemDto>>> Handle(
            GetAuditLogsQuery request,
            CancellationToken cancellationToken)
        {
            Result pagination = QueryProjectionHelpers.ValidatePagination(request.PageNumber, request.PageSize);
            if (pagination.IsFailure)
                return Result<PagedList<AuditLogItemDto>>.Failure(pagination.Errors);

            var query = _dbContext.AuditLog.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Status) &&
                !request.Status.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                if (request.Status.Equals("Success", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(a => a.IsSuccess);
                else if (request.Status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(a => !a.IsSuccess);
                else
                    query = query.Where(_ => false);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string term = request.SearchTerm.Trim();

                int? logId = int.TryParse(term, out int parsedId) ? parsedId : null;

                query = query.Where(a =>
                    (logId.HasValue && a.Id == logId.Value) ||
                    a.UserName.Contains(term) ||
                    a.Action.Contains(term) ||
                    a.EntityName.Contains(term) ||
                    a.EntityId.Contains(term) ||
                    a.FailureReason.Contains(term) ||
                    (a.OldValues != null && a.OldValues.Contains(term)) ||
                    (a.NewValues != null && a.NewValues.Contains(term)));
            }

            int totalCount = await query.CountAsync(cancellationToken);

            var rawLogs = await query
                .OrderByDescending(a => a.CreatedAt)
                .ThenByDescending(a => a.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(a => new
                {
                    a.Id,
                    a.CreatedAt,
                    a.UserId,
                    a.UserName,
                    a.Action,
                    a.EntityName,
                    a.EntityId,
                    a.OldValues,
                    a.NewValues,
                    a.IsSuccess,
                    a.FailureReason
                })
                .ToListAsync(cancellationToken);

            var userIds = rawLogs
                .Where(l => l.UserId.HasValue)
                .Select(l => l.UserId!.Value)
                .Distinct()
                .ToList();

            var userRoles = userIds.Count == 0
                ? new Dictionary<int, string>()
                : await _dbContext.Users
                    .AsNoTracking()
                    .Where(u => userIds.Contains(u.Id))
                    .ToDictionaryAsync(u => u.Id, u => u.Role.ToString(), cancellationToken);

            var items = rawLogs.Select(a => new AuditLogItemDto
            {
                LogId = a.Id,
                Timestamp = a.CreatedAt,
                Username = a.UserName,
                Role = a.UserId.HasValue && userRoles.TryGetValue(a.UserId.Value, out var role)
                    ? role
                    : "System",
                Operation = a.Action,
                TargetEntity = string.IsNullOrWhiteSpace(a.EntityId)
                    ? a.EntityName
                    : $"{a.EntityName} #{a.EntityId}",
                Status = a.IsSuccess ? "Success" : "Failed",
                Details = FormatDetails(a.IsSuccess, a.FailureReason, a.OldValues, a.NewValues),
                OldValues = a.OldValues,
                NewValues = a.NewValues,
                FailureReason = string.IsNullOrWhiteSpace(a.FailureReason) ? null : a.FailureReason
            }).ToList();

            return Result<PagedList<AuditLogItemDto>>.Success(
                new PagedList<AuditLogItemDto>(items, totalCount, request.PageNumber, request.PageSize));
        }

        private static string FormatDetails(
            bool isSuccess,
            string failureReason,
            string? oldValues,
            string? newValues)
        {
            if (!isSuccess && !string.IsNullOrWhiteSpace(failureReason))
                return failureReason;

            if (!string.IsNullOrWhiteSpace(oldValues) && !string.IsNullOrWhiteSpace(newValues))
                return $"Old: {oldValues} | New: {newValues}";

            if (!string.IsNullOrWhiteSpace(newValues))
                return $"New: {newValues}";

            if (!string.IsNullOrWhiteSpace(oldValues))
                return $"Old: {oldValues}";

            return string.Empty;
        }
    }
}
