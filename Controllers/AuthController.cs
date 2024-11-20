using FilmVault.DTOs;
using FilmVault.Models;
using FilmVault.Service;
using FilmVault.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmVault.Controllers;

public class AuthController : BaseController<AuthController>
{
    private readonly AuthService _authService;

    public AuthController(ILogger<AuthController> logger, AuthService authService) : base(logger)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    public async Task<IActionResult> Register(CreateUserDto userDto)
    {
        // await new CreateUserDtoValidator().ValidateAndThrowAsync(userDto);

        var user = await _authService.Register(userDto);


        return Ok(user);
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginUserResponse))]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var loginUserResponse = await _authService.Login(dto);

        return Ok(loginUserResponse);
    }
}