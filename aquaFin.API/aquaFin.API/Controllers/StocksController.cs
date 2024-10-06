using aquaFin.API.AppDbContext;
using Microsoft.AspNetCore.Mvc;

namespace aquaFin.API.Controllers;
[Route("stock")]
public class StocksController:ApiControllerBase
{
    private readonly AquaFinDbContext _context;

    public StocksController(AquaFinDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
     var stocks = _context.Stocks.ToList();
     return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var stock = _context.Stocks.Find(id);
        if (stock ==null)
        {
            return NotFound();
        }
        return Ok(stock);
    }
}