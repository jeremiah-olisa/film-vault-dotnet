using System.Security.Claims;

namespace FilmVault.Util;


public class JwtSession
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtSession(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Gets the User ID from the current context claims.
    /// </summary>
    public string? UserId => 
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    /// <summary>
    /// Gets the Username from the current context claims.
    /// </summary>
    public string? Username => 
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

    /// <summary>
    /// Gets the User Role from the current context claims.
    /// </summary>
    public string? UserRole => 
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
}
