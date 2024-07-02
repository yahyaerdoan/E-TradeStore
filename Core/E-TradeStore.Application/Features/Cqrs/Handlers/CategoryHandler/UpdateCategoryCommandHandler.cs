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
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var values = await _categoryRepository.GetByIdAsync(updateCategoryCommand.Id);
            values.Name = updateCategoryCommand.Name;
            values.Description = updateCategoryCommand.Description;
            await _categoryRepository.UpdateAsync(values);
        }
    }
}
