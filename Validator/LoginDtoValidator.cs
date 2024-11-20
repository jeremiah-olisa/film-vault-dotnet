using FilmVault.DTOs;
using FluentValidation;

namespace FilmVault.Validator;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        // Validate username
        RuleFor(x => x.username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 40).WithMessage("Username must be between 3 and 50 characters.");

        // Validate password
        RuleFor(x => x.password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 20).WithMessage("Password must be between 6 and 20 characters.");
        
    }
}