using aquaFin.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace aquaFin.API.AppDbContext;

public class AquaFinDbContext:DbContext
{
    public AquaFinDbContext(DbContextOptions options) : base(options)
    {
        
    }
    //Db sets
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    
}