using aquaFin.Domain.Entities;

namespace aquaFin.API.Entities;

public class Portfolio
{
    public string AppUserId { get; set; }
    public int StockId { get; set; }
    public AppUser AppUser { get; set; }
    public Stock Stock { get; set; }
}