using E_TradeStore.Application.Features.Cqrs.Commands.Category;
using E_TradeStore.Application.Features.Cqrs.Commands.ProductCommand;
using E_TradeStore.Application.Features.Cqrs.Results.Category;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler;

public class CreateProductCommandHandler
{
    private readonly IRepository<Product> _productRepository;

    public CreateProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(CreateProductCommand createProductCommand)
    {
        await _productRepository.CreateAsync(new Product
        {
            Name = createProductCommand.Name,
            Description = createProductCommand.Description,
            Price = createProductCommand.Price,
            StockQuantity = createProductCommand.StockQuantity,
            CategoryId = createProductCommand.CategoryId,
        });
    }
}
