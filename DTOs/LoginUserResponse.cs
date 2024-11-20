namespace FilmVault.DTOs;

public record LoginUserResponse(int Id, string username, string password, string role, string token);