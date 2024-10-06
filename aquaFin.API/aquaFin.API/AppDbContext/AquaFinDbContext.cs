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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

        // builder.Entity<Portfolio>()
        //     // .HasOne(u => u.AppUser)
        //     .WithMany(u => u.Portfolios)
        //     .HasForeignKey(p => p.AppUserId);

        builder.Entity<Portfolio>()
            .HasOne(u => u.Stock)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(p => p.StockId);
        
    }
    
}