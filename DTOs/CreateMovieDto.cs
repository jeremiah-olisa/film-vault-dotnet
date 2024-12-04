namespace FilmVault.DTOs;

public record CreateMovieDto(string Title, string Genre, int Quantity, decimal Price, bool IsPublic);