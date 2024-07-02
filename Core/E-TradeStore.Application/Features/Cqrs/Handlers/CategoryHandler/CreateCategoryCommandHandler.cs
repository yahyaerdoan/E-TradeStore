using E_TradeStore.Application.Features.Cqrs.Commands.Category;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.CategoryHandler
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(CreateCategoryCommand createCategoryCommand)
        {
            await _categoryRepository.CreateAsync(new Category
            {
                Name = createCategoryCommand.Name,
                Description = createCategoryCommand.Description,
            });
        }
    }
}
