using MediatR;
using Unnise.Application.Abstractions.Persistence;
using Unnise.Application.Abstractions.Security;
using Unnise.Application.Features.Users.Exceptions;
using Unnise.Domain.Entities;

namespace Unnise.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.IsUsernameTakenAsync(request.Username))
                throw new UsernameTakenException(request.Username);

            if (await _userRepository.IsEmailTakenAsync(request.Email))
                throw new EmailTakenException();

            var passwordHash = _passwordHasher.Hash(request.Password);

            var user = new User(
                Guid.NewGuid(),
                request.Username,
                request.GlobalName,
                request.Email,
                passwordHash);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
