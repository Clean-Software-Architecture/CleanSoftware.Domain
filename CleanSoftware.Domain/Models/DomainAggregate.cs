using CleanSoftware.Domain.Interfaces;
using CleanSoftware.Domain.Services;
using FluentValidation;

namespace CleanSoftware.Domain.Models
{
    public abstract class DomainAggregate<TIdentifier> : DomainEntity<TIdentifier>, IAggregate<TIdentifier>
        where TIdentifier : notnull
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        protected DomainAggregate(
            IdentifierFactoryService<TIdentifier> identifierFactory,
            ValidatorFactoryService<IValidator> validatorFactory)
            : base(identifierFactory, validatorFactory)
        {
        }

        protected DomainAggregate(ValidatorFactoryService<IValidator> validatorFactory)
            : base(validatorFactory)
        {
        }

        protected DomainAggregate(IdentifierFactoryService<TIdentifier> identifierFactory)
            : base(identifierFactory)
        {
        }

        protected DomainAggregate()
            : base()
        {
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        protected void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }
    }
}
