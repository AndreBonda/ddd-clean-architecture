using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using FluentResults;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public sealed class AuthenticationService(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) : IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if (userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Create user (generate an uid)
        User user = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        userRepository.AddUser(user);

        // Create JWT
        string token = tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        User? user = userRepository.GetUserByEmail(email);
        if (user is null || user.Password != password)
            return Errors.Authentication.LoginFail;

        string token = tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}