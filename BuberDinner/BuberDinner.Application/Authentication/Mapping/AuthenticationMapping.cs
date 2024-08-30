using BuberDinner.Application.Authentication.Commands.RegisterUser;
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentication.Mapping;

public static class AuthenticationMapping
{
    public static User ToUser(this RegisterUserCommand command)
        => User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );
}