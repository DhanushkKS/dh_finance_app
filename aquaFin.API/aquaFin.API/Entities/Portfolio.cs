
namespace aquaFin.API.Entities;

public class Portfolio
{
    public string AppUserId { get; set; }
    public Guid StockId { get; set; }
    // public AppUser AppUser { get; set; }
    public Stock Stock { get; set; }
}