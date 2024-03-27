using ItemBoxStore.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class MigrationDbContext : ApplicationDbContext
{
    public MigrationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
}