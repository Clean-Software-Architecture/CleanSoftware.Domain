using CleanSoftware.Domain.Interfaces;

namespace CleanSoftware.Domain.Models
{
    public abstract class DomainEvent<TIDomainEventsContainable> : IDomainEvent
        where TIDomainEventsContainable : IDomainEventsContainable
    {
        protected DomainEvent(TIDomainEventsContainable origin)
        {
            Id = Guid.NewGuid();
            Origin = origin;
        }

        public Guid Id { get; }

        public TIDomainEventsContainable Origin { get; }
    }
}
