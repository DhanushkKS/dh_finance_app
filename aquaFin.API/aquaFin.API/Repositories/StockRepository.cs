using aquaFin.API.AppDbContext;
using aquaFin.API.Dtos.Stock;
using aquaFin.API.Entities;
using aquaFin.API.Interfaces;
using aquaFin.API.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aquaFin.API.Repositories;

public class StockRepository(AquaFinDbContext context) : IStockRepository
{
    public async Task<List<StockDto> > GetAll()
    {
        var stocks =await context.Stocks.ToListAsync();
        var stocksDto =  stocks.Select(s=>s.ToStockDto());
        return stocksDto.ToList();
    }

    public async Task<Stock> GetById(Guid id)
    {
        var stock =await context.Stocks.FindAsync(id);
        if (stock ==null)
        {
           throw new Exception($"Stock with id: {id} not found");
        }
        return stock;
    }

    public async Task<Stock> Create(CreateStockRequestDto stockDto)
    {
        var newStock = stockDto.ToStockFromCreateDto();
        await context.Stocks.AddAsync(newStock);
        await context.SaveChangesAsync();
        return newStock;
        // 

    }

    public async Task<Stock?> Update(Guid id, UpdateStockRequestDto stockDto)
    {
        var stock =await context.Stocks.FirstOrDefaultAsync(s=>s.Id==id);
        if (stock == null)
        {
            throw new Exception($"Stock not found for requested id {id}"); 
        }
        stock.MarketCap = stockDto.MarketCap;
        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.LastDiv=stockDto.LastDiv;
        stock.Purchase=stockDto.Purchase;
        stock.Industry=stockDto.Industry;
        
        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<Guid?> Delete(Guid id)
    {
        var stock =await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        if (stock == null)
        {
            throw new Exception($"Stock not found for requested id {id}");
        }
        context.Stocks.Remove(stock);  
        await context.SaveChangesAsync();
        return id;
    }
}