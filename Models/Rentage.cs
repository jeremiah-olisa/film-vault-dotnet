using System.ComponentModel.DataAnnotations;

namespace FilmVault.Models;

public class Rentage
{
    [Key] public int Id { get; set; }

    // Foreign key for Movie
    public int MovieId { get; set; }

    // Foreign key for Customer (User)
    public int CustomerId { get; set; }

    // Foreign key for Renter (User)
    public int RenterId { get; set; }

    public int Quantity { get; set; }

    [Required] public DateTime CreatedAt { get; set; }

    [Required] public DateTime ReturnedAt { get; set; }

    public Movie? Movie { get; set; }
    public User? Renter { get; set; }
    public User? Customer { get; set; }
}