using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public sealed class AuthenticationService(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if (userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already exists");
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
        return new(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        User? user = userRepository.GetUserByEmail(email);
        if (user is null || user.Password != password)
            throw new Exception("Invalid username or password");

        string token = tokenGenerator.GenerateToken(user);

        return new(user, token);
    }
}