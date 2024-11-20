using FilmVault;
using FilmVault.DependencyInjection;
using FilmVault.Util;
using FilmVault.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserDtoValidator>());
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>(); // register validators
builder.Services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
builder.Services.AddFluentValidationClientsideAdapters(); // for client side

// Add SQLite DbContext configuration
builder.Services.AddDbContext<FilmVaultDbContext>(options =>
    options.UseSqlite("Data Source=movies_rentals.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation
builder.Services.AddSwaggerGen(options =>
{
    // Define the Bearer token authentication scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter the JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    // Add security requirement to use Bearer token
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });

    // Set up global response content types (JSON and XML)
    // options.AddResponseType( "application/json");

    // Optionally, add XML support globally (this makes your API support application/xml as well)
    // options.AddResponseType("application/xml");

    // Add content-type and accept headers in Swagger UI
    options.OperationFilter<AddAcceptContentTypeHeader>();
});

builder.Services.AddRepositoryServices();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();