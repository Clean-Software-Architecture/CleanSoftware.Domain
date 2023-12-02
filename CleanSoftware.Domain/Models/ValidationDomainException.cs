using FluentValidation.Results;
using System.Text;

namespace CleanSoftware.Domain.Models
{
    public class ValidationDomainException : Exception
    {
        private readonly Lazy<List<ValidationFailure>> _failures;

        public ValidationDomainException(IReadOnlyCollection<ValidationFailure> failures)
            : this()
        {
            _failures = new Lazy<List<ValidationFailure>>(failures.ToList());
        }

        public ValidationDomainException(IReadOnlyCollection<(string PropertyName, string ErrorMessage)> failures)
            : this()
        {
            _failures = new Lazy<List<ValidationFailure>>(
                failures
                    .Select(x => new ValidationFailure(x.PropertyName, x.ErrorMessage))
                    .ToList());
        }

        public ValidationDomainException(string propertyName, string errorMessage)
            : this()
        {
            _failures = new Lazy<List<ValidationFailure>>(
                new List<ValidationFailure> { new ValidationFailure(propertyName, errorMessage) });
        }

        public ValidationDomainException(string message)
            : base(message)
        {
            _failures = new Lazy<List<ValidationFailure>>();
        }

        public ValidationDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ValidationDomainException()
            : base("One or more validation failures have occurred")
        {
            _failures = new Lazy<List<ValidationFailure>>();
        }

        public IReadOnlyCollection<ValidationFailure> Failures => _failures.Value;

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());

            if (Failures.Count > 0)
            {
                builder.AppendLine();
                builder.AppendLine($"{nameof(Failures)}:");

                foreach (var failure in Failures)
                {
                    builder.AppendLine();
                    builder.AppendLine($" PropertyName: {failure.PropertyName}");
                    builder.AppendLine($" AttemptedValue: {failure.AttemptedValue}");
                    builder.AppendLine($" ErrorMessage: {failure.ErrorMessage}");
                }
            }

            return builder.ToString();
        }
    }
}
