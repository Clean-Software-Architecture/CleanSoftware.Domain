namespace CleanSoftware.Domain.Interfaces
{
    public interface IEntity<TIdentifier> : IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
    }
}