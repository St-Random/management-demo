using iTechArt.ManagementDemo.Entities.Annotations;
using System;

namespace iTechArt.ManagementDemo.Entities.Abstractions
{
    public abstract class Entity
    {
        public int Id { get; set; }

        [UtcDate]
        public DateTime? Created { get; set; }

        [UtcDate]
        public DateTime? LastUpdated { get; set; }

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) =>
            !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var entity = (Entity)obj;

            if (entity.IsTransient() || IsTransient())
            {
                return false;
            }
            else
            {
                return entity.Id == Id;
            }
        }

        // Implemented as method to avoid confusion with other props
        public bool IsTransient() =>
            Id == default(int);

        // Should work reasonably well
        public override int GetHashCode() =>
            Id ^ GetType().AssemblyQualifiedName.GetHashCode();
    }
}
