namespace CleanSoftware.Domain.Interfaces
{
    public interface IDomainEventsContainable
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    }
}
