using aquaFin.API.AppDbContext;
using aquaFin.API.Dtos.Stock;
using aquaFin.API.Interfaces;
using aquaFin.API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aquaFin.API.Controllers;
[Route("stock")]
public class StocksController(IStockRepository stockRepository) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult>GetAll()
    {
     var stocks = await stockRepository.GetAll();
     return Ok(stocks);
    
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]Guid id)
    {
       var stock = await stockRepository.GetById(id);
       return Ok(stock);
    }

    [HttpPost]
    public async  Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        var newStock = await stockRepository.Create(stockDto);
        return CreatedAtAction(nameof(GetById), new { id = newStock.Id }, newStock.ToStockDto());
        
    }

    [HttpPut("{id}")]
    public async  Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStockRequestDto stockDto)
    {
        var  stock= await  stockRepository.Update(id, stockDto);
        if (stock == null)
        {
            return NotFound();
        }
        return Ok(stock.ToStockDto());

    }

    [HttpDelete("{id}")]
    public async  Task<IActionResult> Delete([FromRoute] Guid id)
    {
      await stockRepository.Delete(id);
        return NoContent();
    }
}