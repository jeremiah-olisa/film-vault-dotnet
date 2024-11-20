using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmVault.Models;

public class User
{
    public User()
    {
    }

    public User(string username, string password, string role)
    {
        Username = username;
        Password = BCrypt.Net.BCrypt.HashPassword(password);
        Role = role;
        CreatedAt = DateTime.Now;
    }

    [Key] public int Id { get; set; }

    // TODO: make user name unique
    [Required] [MaxLength(40)] public string Username { get; set; } = string.Empty;

    [Required] [MaxLength(20)] public string Role { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    [JsonIgnore]
    public string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    // Navigation properties for relationships
    public IReadOnlyCollection<Rentage> RentagesAsCustomer { get; } = new List<Rentage>();
    public IReadOnlyCollection<Rentage> RentagesAsRenter { get; } = new List<Rentage>();
    public IReadOnlyCollection<Movie> CreatedMovies { get; } = new List<Movie>();
}