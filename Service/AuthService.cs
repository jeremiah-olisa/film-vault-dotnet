using FilmVault.DTOs;
using FilmVault.Models;
using FilmVault.Repository;

namespace FilmVault.Service;

public class AuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly UserRepository _userRepository;
    private readonly JwtTokenService _jwtTokenService;

    public AuthService(ILogger<AuthService> logger, UserRepository userRepository, JwtTokenService jwtTokenService)
    {
        _logger = logger;
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<User> Register(CreateUserDto userDto)
    {
        return await _userRepository.CreateUser(userDto.username, userDto.password, userDto.role);
    }

    public async Task<LoginUserResponse> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByUserName(loginDto.username);

        if (user is null)
            throw new UnauthorizedAccessException("User does not exist");

        var isCorrectPwd = BCrypt.Net.BCrypt.Verify(loginDto.password, user.Password);

        if (!isCorrectPwd)
            throw new UnauthorizedAccessException("Invalid username or password");

        // Use the JwtTokenService to generate the token
        var jwtToken = _jwtTokenService.GenerateToken(user.Id, user.Username, user.Role);

        return new LoginUserResponse(user.Id, user.Username, user.Username, user.Role, jwtToken);
    }
}