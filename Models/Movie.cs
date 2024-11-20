using System.ComponentModel.DataAnnotations;

namespace FilmVault.Models;

public class Movie
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; } = string.Empty;

    [Required] [MaxLength(100)] public string Genre { get; set; } = string.Empty;

    // Foreign key for creator (User)
    public int CreatorId { get; set; }

    public int Quantity { get; set; }

    public int Stock { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] [MaxLength(50)] public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }


    public User? Creator { get; set; }

    // Navigation property for Rentage (many-to-one)
    public ICollection<Rentage> Rentages { get; set; } = new List<Rentage>();
}