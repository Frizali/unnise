using FluentValidation;

namespace Unnise.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserValidator
        : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8);
        }
    }
}
