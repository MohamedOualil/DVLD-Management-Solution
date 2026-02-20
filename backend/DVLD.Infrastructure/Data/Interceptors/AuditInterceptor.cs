using DVLD.Application.Abstractions;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DVLD.Infrastructure.Data.Interceptors
{
    public sealed class AuditInterceptor : ISaveChangesInterceptor
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public AuditInterceptor(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            SetAuditFields(eventData.Context);
            return result;
        }

        public ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            SetAuditFields(eventData.Context);
            return ValueTask.FromResult(result);
        }

        private void SetAuditFields(DbContext? context)
        {
            if (context is null) return;

            var entries = context.ChangeTracker.Entries<Entity<int>>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    // EF Core's CurrentValue bypasses private setters safely
                    entry.Property(e => e.CreatedAt).CurrentValue = _dateTimeProvider.UtcNow;
                    entry.Property(e => e.UpdatedAt).CurrentValue = _dateTimeProvider.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(e => e.UpdatedAt).CurrentValue = _dateTimeProvider.UtcNow;
                }
            }
        }
    }
}
