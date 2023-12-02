namespace CleanSoftware.Domain.Interfaces
{
    public interface IAggregate
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    }

    public interface IAggregate<TIdentifier> : IAggregate, IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
    }
}