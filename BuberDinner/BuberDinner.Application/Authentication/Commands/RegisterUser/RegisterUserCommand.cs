using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.RegisterUser;

public record RegisterUserCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;