using DVLD.Application.Abstractions;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Services
{
    public class AuditService : IAuditService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public AuditService(AppDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task LogActionAsync(string action, string entityName, string entityId, object? oldValues, object? newValues, bool isSuccess = true, string failureReason = "")
        {
            string? oldJson = oldValues != null ? JsonSerializer.Serialize(oldValues) : null;
            string? newJson = newValues != null ? JsonSerializer.Serialize(newValues) : null;

            var auditLog = AuditLog.Create(
                userId: _currentUser.UserId,
                userEmail: _currentUser.UserName,
                action: action,
                entityName: entityName,
                entityId: entityId,
                oldValues: oldJson,
                newValues: newJson,
                isSuccess: isSuccess,
                failureReason: failureReason,
                ipAddress: _currentUser.IpAddress
            );

            _context.AuditLog.Add(auditLog);

            await _context.SaveChangesAsync();
        }
    }
}
