namespace FilmVault;

using FilmVault.Models;
using Microsoft.EntityFrameworkCore;

public class FilmVaultDbContext : DbContext
{
    public FilmVaultDbContext(DbContextOptions<FilmVaultDbContext> options) : base(options)
    {
    }

    public DbSet<Rentage> Rentages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Rentage -> Movie (many-to-one)
        modelBuilder.Entity<Rentage>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Rentages)
            .HasForeignKey(r => r.MovieId)  // Foreign Key for Movie
            .OnDelete(DeleteBehavior.Restrict); // Set Delete behavior (optional)

        // Rentage -> User (Customer, many-to-one)
        modelBuilder.Entity<Rentage>()
            .HasOne(r => r.Customer)  // Rentage -> User (Customer)
            .WithMany(u => u.RentagesAsCustomer)
            .HasForeignKey(r => r.CustomerId)  // Foreign Key for Customer
            .OnDelete(DeleteBehavior.Restrict);  // Set Delete behavior (optional)

        // Rentage -> User (Renter, many-to-one)
        modelBuilder.Entity<Rentage>()
            .HasOne(r => r.Renter)  // Rentage -> User (Renter)
            .WithMany(u => u.RentagesAsRenter)
            .HasForeignKey(r => r.RenterId)  // Foreign Key for Renter
            .OnDelete(DeleteBehavior.Restrict);  // Set Delete behavior (optional)

        // Movie -> User (Creator, many-to-one)
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Creator)  // Movie -> User (Creator)
            .WithMany(u => u.CreatedMovies)
            .HasForeignKey(m => m.CreatorId)  // Foreign Key for Creator
            .OnDelete(DeleteBehavior.Restrict);  // Set Delete behavior (optional)
    }


}