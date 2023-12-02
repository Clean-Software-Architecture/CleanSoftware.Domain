﻿using Domain.Models;
using Domain.Services;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;

namespace CleanSoftware.Domain.Models
{
    public abstract class Validatable
    {
        private readonly Func<IValidator> _validatorFactory;

        protected Validatable(Func<IValidator> validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        protected Validatable()
        {
            _validatorFactory = CreateDefault;
        }

        protected void Validate()
        {
            var context = new ValidationContext<Validatable>(this);

            var validator = _validatorFactory.Invoke();
            var result = validator.Validate(context);

            ProcessValidationResult(result);
        }

        protected void ValidateProperty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            var context = new ValidationContext<Validatable>(
                this,
                new PropertyChain(),
                new MemberNameValidatorSelector(new[] { name }));

            var validator = _validatorFactory.Invoke();
            var result = validator.Validate(context);

            ProcessValidationResult(result);
        }

        private void ProcessValidationResult(ValidationResult result)
        {
            if (result.IsValid == false)
            {
                throw new ValidationDomainException(result.Errors);
            }
        }

        private IValidator CreateDefault()
        {
            return new DomainValidationService<Validatable>();
        }
    }
}