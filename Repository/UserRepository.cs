using FilmVault.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmVault.Repository;

public class UserRepository
{
    private readonly FilmVaultDbContext _dbContext;

    public UserRepository(FilmVaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateUser(string username, string password, string role)
    {
        var user = new User(username, password, role);
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByUserName(string username)
    {
        return await _dbContext.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
    }
}