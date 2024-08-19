using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(User user)
    {
        List<Claim> claims =
        [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
        ];

        SigningCredentials credentials = new(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            claims: claims,
            notBefore: _dateTimeProvider.UtcNow,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: credentials,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}