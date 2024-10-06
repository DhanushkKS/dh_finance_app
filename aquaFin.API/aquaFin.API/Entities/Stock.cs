using System.ComponentModel.DataAnnotations.Schema;

namespace aquaFin.API.Entities;

public class Stock:API.Entities.BaseEntity
{
    public string Symbol { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Purchase { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal LastDiv { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
   
    public List<API.Entities.Comment> Comments { get; set; } = new List<API.Entities.Comment>();
    public List<API.Entities.Portfolio> Portfolios { get; set; } = new List<API.Entities.Portfolio>();
}