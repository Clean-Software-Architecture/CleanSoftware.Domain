using CleanSoftware.Domain.Models;

namespace CleanSoftware.Domain.Interfaces
{
    public interface IValueObject
    {
        bool Equals(object obj);

        DomainValueObject GetCopy();
        
        int GetHashCode();
    }
}