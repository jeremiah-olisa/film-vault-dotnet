namespace FilmVault.Repository;

public class UnitOfWork(FilmVaultDbContext dbContext)
{
    private readonly FilmVaultDbContext _dbContext = dbContext;

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}