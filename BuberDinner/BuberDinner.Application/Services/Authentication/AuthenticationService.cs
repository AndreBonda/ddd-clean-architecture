using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public sealed class AuthenticationService(IJwtTokenGenerator tokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists

        // Create user (generate an uid)

        // Creat JWT
        Guid id = Guid.NewGuid();
        string token = tokenGenerator.GenerateToken(id, firstName, lastName);
        return new(id, firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new(Guid.NewGuid(), "firstName", "lastName", email, "a-token");
    }
}