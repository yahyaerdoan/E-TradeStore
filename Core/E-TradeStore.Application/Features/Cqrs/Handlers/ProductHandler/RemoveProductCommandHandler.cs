using E_TradeStore.Application.Features.Cqrs.Commands.ProductCommand;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler;

public class RemoveProductCommandHandler
{
    private readonly IRepository<Product> _productRepository;

    public RemoveProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(DeleteProductCommand deleteProductCommand)
    {
        await _productRepository.DeleteAsync(deleteProductCommand.Id);
    }
}
