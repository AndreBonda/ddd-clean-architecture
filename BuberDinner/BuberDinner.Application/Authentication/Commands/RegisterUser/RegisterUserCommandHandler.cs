using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Mapping;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.RegisterUser;

public class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator tokenGenerator)
    : IRequestHandler<RegisterUserCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        // Check if user already exists
        if (userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        // Create user (generate an uid)
        User user = command.ToUser();
        userRepository.AddUser(user);

        // Create JWT
        string token = tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}