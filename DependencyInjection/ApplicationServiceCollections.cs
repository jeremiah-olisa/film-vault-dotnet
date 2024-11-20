using System.Text;
using FilmVault.Repository;
using FilmVault.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FilmVault.DependencyInjection;

public static class ApplicationServiceCollections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuthService>();

        // services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

        services.AddSingleton<JwtTokenService>(provider =>
            new JwtTokenService(
                configuration["Jwt:SecretKey"],
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"]
            ));

        // Add authentication services
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"], // e.g. "yourdomain.com"
                    ValidAudience = configuration["Jwt:Audience"], // e.g. "yourdomain.com"
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ??
                                               throw new InvalidDataException())) // Secret key for signing the JWT
                };
            });


        return services;
    }
}