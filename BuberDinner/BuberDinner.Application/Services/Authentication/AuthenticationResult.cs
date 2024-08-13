namespace BuberDinner.Application.Services.Authentication;

public sealed record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);