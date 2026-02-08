using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    public class Entity<TId>
    {
        public TId Id { get; protected set; }

        public bool IsDeactivated { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        protected Entity() { }

        protected void Deactivate()
        {
            if (IsDeactivated) return;
            IsDeactivated = true;
            // Record that this changed
            // AddDomainEvent(new EntityDeactivatedEvent(this.Id));
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Id == null || Id.Equals(default(TId))) return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    }
}
