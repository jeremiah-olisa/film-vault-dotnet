namespace FilmVault.DTOs;

public record LoginUserResponse(int Id, string Username, string Role, string Token);