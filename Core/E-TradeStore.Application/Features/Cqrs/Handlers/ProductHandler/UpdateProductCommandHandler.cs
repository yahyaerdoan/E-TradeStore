using E_TradeStore.Application.Features.Cqrs.Commands.ProductCommand;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler;

public class UpdateProductCommandHandler
{
    private readonly IRepository<Product> _productRepository;

    public UpdateProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(UpdateProductCommand updateProductCommand)
    {
        var values = await _productRepository.GetByIdAsync(updateProductCommand.Id);
        values.Name = updateProductCommand.Name;
        values.Description = updateProductCommand.Description;
        values.Price = updateProductCommand.Price;
        values.StockQuantity = updateProductCommand.StockQuantity;
        values.CategoryId = updateProductCommand.CategoryId;
        await _productRepository.UpdateAsync(values);
    }
}
