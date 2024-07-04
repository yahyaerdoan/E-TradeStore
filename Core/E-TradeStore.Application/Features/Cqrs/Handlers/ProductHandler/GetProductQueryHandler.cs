using E_TradeStore.Application.Features.Cqrs.Results.ProductResult;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler;

public class GetProductQueryHandler
{
    private readonly IRepository<Product> _productRepository;

    public GetProductQueryHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<GetProductQueryResult>> Handle()
    {
        var values = await _productRepository.GetAsync();
        return values.Select(x => new GetProductQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            StockQuantity = x.StockQuantity,
            CategoryId = x.CategoryId,
        }).ToList();
    }
}
