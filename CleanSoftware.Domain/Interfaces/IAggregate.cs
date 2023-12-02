namespace CleanSoftware.Domain.Interfaces
{
    public interface IAggregate : IDomainEventsContainable
    {
    }

    public interface IAggregate<TIdentifier> : IAggregate, IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
    }
}