using BuberDinner.Application.Authentication.Commands.RegisterUser;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication.Mapping;

public static class AuthenticationMapping
{
    public static User ToUser(this RegisterUserCommand command)
        => new()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
}