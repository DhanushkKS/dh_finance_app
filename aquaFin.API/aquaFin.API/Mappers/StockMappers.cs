using aquaFin.API.Dtos.Stock;
using aquaFin.API.Entities;

namespace aquaFin.API.Mappers;

public static class  StockMappers
{
    public static StockDto ToStockDto(this Stock stockEntity)
    {
        return new StockDto()
        {
            Id = stockEntity.Id,
            Symbol = stockEntity.Symbol,
            Purchase = stockEntity.Purchase,
            CompanyName = stockEntity.CompanyName,
            MarketCap = stockEntity.MarketCap,
            LastDiv = stockEntity.LastDiv,
            Industry = stockEntity.Industry,
        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockRequestDto)
    {
        return new Stock()
        {
            MarketCap = stockRequestDto.MarketCap,
            LastDiv = stockRequestDto.LastDiv,
            Industry = stockRequestDto.Industry,
            Purchase = stockRequestDto.Purchase,
            CompanyName = stockRequestDto.CompanyName,
            Symbol = stockRequestDto.Symbol, 
            
        };
    }

    public static Stock ToStockFromUpdateDto(this UpdateStockRequestDto stockRequestDto)
    {
        return new Stock()
        {
            MarketCap = stockRequestDto.MarketCap,
            LastDiv = stockRequestDto.LastDiv,
            Industry = stockRequestDto.Industry,
            Purchase = stockRequestDto.Purchase,
            CompanyName = stockRequestDto.CompanyName,
            Symbol = stockRequestDto.Symbol, 
            
        };
    }
}