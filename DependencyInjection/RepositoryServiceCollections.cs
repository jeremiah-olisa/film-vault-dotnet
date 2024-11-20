using FilmVault.Repository;

namespace FilmVault.DependencyInjection;

public static class RepositoryServiceCollections
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        return services;
    }
}