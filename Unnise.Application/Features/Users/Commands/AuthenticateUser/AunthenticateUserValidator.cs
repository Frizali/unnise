using FluentValidation;

namespace Unnise.Application.Features.Users.Commands.AuthenticateUser
{
    public class AunthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AunthenticateUserValidator()
        {
            RuleFor(x => x.Identity)
                .NotEmpty();
        }
    }
}
