namespace BuberDinner.Application.Common.Interfaces.Authentication;

public sealed class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public required string SecretKey { get; set; }
    public required int ExpiryMinutes { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
}