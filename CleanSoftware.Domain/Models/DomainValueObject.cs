using CleanSoftware.Domain.Interfaces;
using CleanSoftware.Domain.Services;
using FluentValidation;

namespace CleanSoftware.Domain.Models
{
    // Source: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
    public abstract class DomainValueObject : DomainValidatable, IValueObject
    {
        protected DomainValueObject(ValidatorFactoryService<IValidator> validatorFactory)
            : base(validatorFactory)
        {
        }

        protected DomainValueObject()
            : base()
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (DomainValueObject)obj;

            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public DomainValueObject GetCopy()
        {
            return MemberwiseClone() as DomainValueObject;
        }

        public static bool operator ==(DomainValueObject one, DomainValueObject two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(DomainValueObject one, DomainValueObject two)
        {
            return NotEqualOperator(one, two);
        }

        protected static bool EqualOperator(DomainValueObject left, DomainValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(DomainValueObject left, DomainValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}
