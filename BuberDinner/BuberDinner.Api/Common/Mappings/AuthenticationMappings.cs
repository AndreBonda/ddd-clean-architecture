using BuberDinner.Application.Authentication.Commands.RegisterUser;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Api.Common.Mappings;

public static class AuthenticationMappings
{
    public static RegisterUserCommand ToCommand(this RegisterRequest request)
        => new(request.FirstName, request.LastName, request.Email, request.Password);

    public static AuthenticationResponse ToResponse(this AuthenticationResult result)
        => new(
            result.User.Id.Value,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);
}