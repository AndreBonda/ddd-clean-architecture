using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public sealed record AuthenticationResult(User User, string Token);