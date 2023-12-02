namespace CleanSoftware.Domain.Interfaces
{
    public interface IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
        TIdentifier Id { get; }
    }
}