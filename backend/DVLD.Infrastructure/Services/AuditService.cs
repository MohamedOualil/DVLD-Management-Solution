using DVLD.Application.Abstractions;
using DVLD.Domain.Entities;
using DVLD.Domain.Interfaces;
using DVLD.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DVLD.Infrastructure.Services
{
    public class AuditService : IAuditService
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ICurrentUserService _currentUser;

        public AuditService(IServiceScopeFactory scopeFactory, ICurrentUserService currentUser)
        {
            _scopeFactory = scopeFactory;
            _currentUser = currentUser;
        }

        public async Task LogActionAsync(
            string action,
            string entityName,
            string entityId,
            object? oldValues,
            object? newValues,
            bool isSuccess = true,
            string failureReason = "")
        {
            string? oldJson = oldValues != null ? JsonSerializer.Serialize(oldValues, SerializerOptions) : null;
            string? newJson = newValues != null ? JsonSerializer.Serialize(newValues, SerializerOptions) : null;

            var auditLog = AuditLog.Create(
                userId: _currentUser.UserId,
                userEmail: _currentUser.UserName,
                action: action,
                entityName: entityName,
                entityId: entityId,
                oldValues: oldJson,
                newValues: newJson,
                isSuccess: isSuccess,
                failureReason: failureReason);

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.AuditLog.Add(auditLog);
            await dbContext.SaveChangesAsync();
        }
    }
}
