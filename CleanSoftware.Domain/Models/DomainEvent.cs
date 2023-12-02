using CleanSoftware.Domain.Interfaces;

namespace CleanSoftware.Domain.Models
{
    public abstract class DomainEvent<TOrigin> : IDomainEvent
        where TOrigin : IAggregate
    {
        protected DomainEvent(TOrigin origin)
        {
            Id = Guid.NewGuid();
            Origin = origin;
        }

        public Guid Id { get; }

        public TOrigin Origin { get; }
    }
}
