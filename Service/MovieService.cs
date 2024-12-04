using FilmVault.DTOs;
using FilmVault.Models;
using FilmVault.Repository;
using FilmVault.Util;

namespace FilmVault.Service;

public class MovieService(ILogger<MovieService> logger, MovieRepository movieRepository, JwtSession jwtSession)
{
    private readonly ILogger<MovieService> _logger = logger;
    private readonly MovieRepository _movieRepository = movieRepository;
    private readonly JwtSession _jwtSession = jwtSession;

    public async Task<Movie> CreateMovie(CreateMovieDto createMovieDto)
    {
        var creatorId = int.Parse(_jwtSession.UserId ??
                                  throw new UnauthorizedAccessException("You are not authorized to access this page!"));

        var movie = await _movieRepository.CreateMovie(createMovieDto.Title, createMovieDto.Genre,
            createMovieDto.Quantity,
            createMovieDto.Price, createMovieDto.IsPublic, creatorId);

        return movie;
    }

    // public async Task<Movie?> GetMovieById(int movieId)
    // {
    // }
    //
    // public async Task DeleteMovieById(int movieId)
    // {
    // }
    //
    // public async Task<Movie> Update(int movieId, string title, string genre, int quantity)
    // {
    // }
    //
    // public async Task<Movie> TogglePublicVisibility(int movieId, string title, string genre, int quantity)
    // {
    // }
}