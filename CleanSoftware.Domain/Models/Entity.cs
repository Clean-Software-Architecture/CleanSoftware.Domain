using CleanSoftware.Domain.Interfaces;
using FluentValidation;

namespace CleanSoftware.Domain.Models
{
    public abstract class Entity<TIdentifier> : Validatable, IIdentifiable<TIdentifier>, IDomainEventsContainable
        where TIdentifier : notnull
    {
        private readonly List<IDomainEvent> _domainEvents;
        private TIdentifier _id;

        protected Entity(
            Func<TIdentifier> identifierFactory,
            Func<IValidator> validatorFactory)
                : this(validatorFactory)
        {
            ArgumentNullException.ThrowIfNull(identifierFactory);

            Id = identifierFactory();
        }

        protected Entity(Func<TIdentifier> identifierFactory)
            : this()
        {
            ArgumentNullException.ThrowIfNull(identifierFactory);

            Id = identifierFactory();
        }

        protected Entity(Func<IValidator> validatorFactory)
            : base(validatorFactory)
        {
            _domainEvents = new List<IDomainEvent>();
        }

        protected Entity()
            : base()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        public TIdentifier Id
        {
            get => _id;
            private set
            {
                _id = value;
                ValidateProperty(nameof(Id));
            }
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