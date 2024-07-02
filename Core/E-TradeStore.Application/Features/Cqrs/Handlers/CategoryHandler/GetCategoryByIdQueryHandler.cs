using E_TradeStore.Application.Features.Cqrs.Results.Category;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.CategoryHandler
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(int id)
        {
            var values = await _categoryRepository.GetByIdAsync(id);
            return new GetCategoryByIdQueryResult
            {
                Name = values.Name,
                Description = values.Description,
            };
        }
    }
}
