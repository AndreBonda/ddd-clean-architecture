using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication.Common;

public sealed record AuthenticationResult(User User, string Token);