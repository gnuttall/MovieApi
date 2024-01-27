using Microsoft.EntityFrameworkCore;
using MovieApi.Data.Entities;

namespace MovieApi.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            entityType.SetTableName($"ma{entityType.ClrType.Name}");
        
        base.OnModelCreating(modelBuilder);
    }
}