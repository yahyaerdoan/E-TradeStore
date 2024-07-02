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
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _categoryRepository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _categoryRepository.GetAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();
        }
    }
}
