using FluentValidation;

namespace Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable
{
    public class IsProjectNameAvailableValidator : AbstractValidator<IsProjectNameAvailableQuery>
    {
        public IsProjectNameAvailableValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
