using CleanSoftware.Domain.Interfaces;
using CleanSoftware.Domain.Services;
using FluentValidation;

namespace CleanSoftware.Domain.Models
{
    public abstract class DomainEntity<TIdentifier> : DomainValidatable, IEntity<TIdentifier> 
        where TIdentifier : notnull
    {
        private TIdentifier _id;

        protected DomainEntity(
            IdentifierFactoryService<TIdentifier> identifierFactory,
            ValidatorFactoryService<IValidator> validatorFactory)
                : this(validatorFactory)
        {
            ArgumentNullException.ThrowIfNull(identifierFactory);
            Id = identifierFactory();
        }

        protected DomainEntity(IdentifierFactoryService<TIdentifier> identifierFactory)
            : this()
        {
            ArgumentNullException.ThrowIfNull(identifierFactory);
            Id = identifierFactory();
        }

        protected DomainEntity(ValidatorFactoryService<IValidator> validatorFactory)
            : base(validatorFactory)
        {
        }

        protected DomainEntity()
            : base()
        {
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
    }
}