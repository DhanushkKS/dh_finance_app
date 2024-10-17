using aquaFin.API.Dtos.Stock;
using aquaFin.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace aquaFin.API.Interfaces;

public interface IStockRepository
{
    public Task  <List<StockDto>> GetAll();
    public Task<Stock> GetById([FromRoute] Guid id);
    public Task<Stock> Create([FromBody] CreateStockRequestDto stockDto);
    public Task<Stock?> Update([FromRoute] Guid id, [FromBody] UpdateStockRequestDto stockDto);
    public Task<Guid?> Delete([FromRoute] Guid id);


}