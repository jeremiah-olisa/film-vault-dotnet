using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilmVault.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FilmVault.Service;

public class JwtTokenService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expirationMinutes;

    public JwtTokenService(IOptions<JwtSettings> jwtSettings)
    {
        _secretKey = jwtSettings.Value.SecretKey;
        _issuer = jwtSettings.Value.Issuer;
        _audience = jwtSettings.Value.Audience;
        _expirationMinutes = jwtSettings.Value.ExpirationMinutes;
    }

    public string GenerateToken(int userId, string username, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()), // User ID
            new Claim(ClaimTypes.Name, username), // Username
            new Claim(ClaimTypes.Role, role), // User Role
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_expirationMinutes), // Token expiration time
            signingCredentials: creds
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token); // Generates the JWT as a string
    }
}