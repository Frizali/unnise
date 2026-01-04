using FluentValidation.Results;

namespace Unnise.Application.Common.Exceptions
{
    public sealed class RequestValidationException : AppException
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }

        public RequestValidationException(IEnumerable<ValidationFailure> failures)
            : base(BuildMessage(failures))
        {
            Errors = failures
                .GroupBy(f => f.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(f => f.ErrorMessage).ToArray()
                );
        }

        private static string BuildMessage(IEnumerable<ValidationFailure> failures)
        {
            var firstError = failures.FirstOrDefault();
            if (firstError == null)
                return "Validation failed.";

            return firstError.ErrorMessage;
        }
    }

}
