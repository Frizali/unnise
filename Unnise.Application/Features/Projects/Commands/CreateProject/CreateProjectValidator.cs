using FluentValidation;

namespace Unnise.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Visibility).NotNull();
        }
    }
}
