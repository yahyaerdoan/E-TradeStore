using E_TradeStore.Application.Features.Cqrs.Results.ProductResult;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler
{
    public class GetProductByIdCommandHandler
    {
        private readonly IRepository<Product> _productRepository;

        public GetProductByIdCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductByIdQueryResult> Handle(int id)
        {
            var values = await _productRepository.GetByIdAsync(id);
            return new GetProductByIdQueryResult
            {
                Name = values.Name,
                Description = values.Description,
                Price = values.Price,
                StockQuantity = values.StockQuantity,
                CategoryId = values.CategoryId,
            };
        }
    }
}
