using FilmVault.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmVault.Repository;

public class MovieRepository(FilmVaultDbContext dbContext)
{
    private readonly FilmVaultDbContext _dbContext = dbContext;
    private readonly DbSet<Movie> _movies = dbContext.Movies;

    public async Task<Movie> CreateMovie(string title, string genre, int quantity, decimal price, bool isPublic,
        int creatorId)
    {
        Movie movie = new(title, genre, isPublic, quantity, price, creatorId);
        await _movies.AddAsync(movie);
        return movie;
    }

    public async Task<Movie?> GetMovieById(int movieId)
    {
        return await _movies.Where(c => c.Id == movieId).SingleOrDefaultAsync();
    }

    public async Task DeleteMovieById(int movieId)
    {
        var movie = await GetMovieByIdOrThrow(movieId);
        _movies.Remove(movie);
    }

    public async Task<Movie> Update(int movieId, string title, string genre, int quantity)
    {
        var movie = await GetMovieByIdOrThrow(movieId);

        movie.UpdateMovie(title, genre, quantity);
        _movies.Update(movie);

        return movie;
    }

    public async Task<Movie> TogglePublicVisibility(int movieId, string title, string genre, int quantity)
    {
        var movie = await GetMovieByIdOrThrow(movieId);

        movie.TogglePublicVisibility();
        _movies.Update(movie);

        return movie;
    }

    public async Task<Movie> GetMovieByIdOrThrow(int movieId)
    {
        return await GetMovieById(movieId) ?? throw new KeyNotFoundException($"Movie {movieId} not found");
    }
}