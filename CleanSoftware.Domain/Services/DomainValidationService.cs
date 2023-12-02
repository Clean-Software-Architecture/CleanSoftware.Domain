using CleanSoftware.Domain.Models;
using FluentValidation;

namespace CleanSoftware.Domain.Services
{
    public class DomainValidationService<TValidatable> : AbstractValidator<TValidatable>
        where TValidatable : DomainValidatable
    {
        public DomainValidationService()
        {
            ClassLevelCascadeMode = CascadeMode.Continue;
        }
    }
}