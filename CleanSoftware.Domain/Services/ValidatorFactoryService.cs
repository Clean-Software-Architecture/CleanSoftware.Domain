using FluentValidation;

namespace CleanSoftware.Domain.Services
{
    public delegate TValidator ValidatorFactoryService<TValidator>()
        where TValidator : IValidator;
}
