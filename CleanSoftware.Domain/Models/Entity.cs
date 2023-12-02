using CleanSoftware.Domain.Interfaces;
using CleanSoftware.Domain.Services;
using FluentValidation;

namespace CleanSoftware.Domain.Models
{
    public abstract class Entity<TIdentifier> : Validatable, IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
        private TIdentifier _id;

        protected Entity(
            IdentifierFactoryService<TIdentifier> identifierFactory,
            ValidatorFactoryService<IValidator> validatorFactory)
                : this(validatorFactory)
        {
            ArgumentNullException.ThrowIfNull(identifierFactory);
            Id = identifierFactory();
        }

        protected Entity(IdentifierFactoryService<TIdentifier> identifierFactory)
            : this()
        {
            ArgumentNullException.ThrowIfNull(identifierFactory);
            Id = identifierFactory();
        }

        protected Entity(ValidatorFactoryService<IValidator> validatorFactory)
            : base(validatorFactory)
        {
        }

        protected Entity()
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