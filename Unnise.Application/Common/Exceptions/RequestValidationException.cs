using FluentValidation.Results;

namespace Unnise.Application.Common.Exceptions
{
    public sealed class RequestValidationException(IEnumerable<ValidationFailure> failures)
        : AppException(BuildMessage(failures))
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; } = failures
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(f => f.ErrorMessage).ToArray()
            );

        private static string BuildMessage(IEnumerable<ValidationFailure> failures)
        {
            var firstError = failures.FirstOrDefault();
            if (firstError == null)
                return "Validation failed.";

            return firstError.ErrorMessage;
        }
    }
}
