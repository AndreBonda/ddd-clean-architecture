using BuberDinner.Application.Authentication.Commands.RegisterUser;
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentication.Mappings;

public static class AuthenticationMappings
{
    public static User ToUser(this RegisterUserCommand command)
        => User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );
}