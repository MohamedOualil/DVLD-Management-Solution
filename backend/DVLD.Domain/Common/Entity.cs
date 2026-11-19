namespace DVLD.Domain.Common
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; protected set; }

        protected Entity() { }

        public override int GetHashCode() => HashCode.Combine(GetType(), Id);

        public bool Equals(Entity? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            if (Id == 0 || other.Id == 0) return false;

            return Id == other.Id;
        }

        public override bool Equals(object? obj) => Equals(obj as Entity);
        public static bool operator ==(Entity? a, Entity? b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);
        public static bool operator !=(Entity? a, Entity? b) => !(a == b);
    }
}
