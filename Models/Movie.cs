using System.ComponentModel.DataAnnotations;

namespace FilmVault.Models;

public class Movie
{
    public Movie()
    {
    }

    public Movie(string title, string genre, bool isPublic, int quantity, decimal price, int creatorId)
    {
        Title = title;
        Quantity = quantity;
        Genre = genre;
        CreatorId = creatorId;
        Stock = quantity;
        Price = price;
        IsPublic = isPublic;
    }

    public void UpdateMovie(string title, string genre, int quantity)
    {
        Title = title;
        Quantity = quantity;
        Genre = genre;
        Stock = quantity;
    }

    public void TogglePublicVisibility()
    {
        IsPublic = !IsPublic;
    }

    [Key] public int Id { get; } = default;

    [Required] [MaxLength(255)] public string Title { get; private set; }

    [Required] [MaxLength(100)] public string Genre { get; private set; }

    // Foreign key for creator (User)
    public int CreatorId { get; private set; }

    public int Quantity { get; private set; }

    public int Stock { get; private set; }

    [Required] public decimal Price { get; private set; }

    [Required] [MaxLength(50)] public bool IsPublic { get; private set; } = false;

    public DateTime CreatedAt { get; private set; }


    public User? Creator { get; private set; }

    // Navigation property for Rentage (many-to-one)
    public ICollection<Rentage> Rentages { get; private set; } = new List<Rentage>();
}