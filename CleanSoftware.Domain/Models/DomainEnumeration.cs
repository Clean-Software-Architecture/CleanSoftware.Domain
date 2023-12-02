using Ardalis.SmartEnum;

namespace CleanSoftware.Domain.Models
{
    public abstract class DomainEnumeration<TEnum> : SmartEnum<TEnum>
        where TEnum : SmartEnum<TEnum, int>
    {
        protected DomainEnumeration(string name, int value)
            : base(name, value)
        {
        }
    }

    public abstract class DomainEnumeration<TEnum, TValue> : SmartEnum<TEnum, TValue>
        where TEnum : SmartEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        protected DomainEnumeration(string name, TValue value)
            : base(name, value)
        {
        }
    }
}