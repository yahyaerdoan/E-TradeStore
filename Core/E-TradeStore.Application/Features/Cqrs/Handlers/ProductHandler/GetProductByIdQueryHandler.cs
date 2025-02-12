﻿using E_TradeStore.Application.Features.Cqrs.Queries.ProductQuery;
using E_TradeStore.Application.Features.Cqrs.Results.ProductResult;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler
{
    public class GetProductByIdQueryHandler
    {
        private readonly IRepository<Product> _productRepository;

        public GetProductByIdQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery getProductByIdQuery)
        {
            var values = await _productRepository.GetByIdAsync(getProductByIdQuery.Id);
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
