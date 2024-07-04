using E_TradeStore.Application.Features.Cqrs.Commands.Category;
using E_TradeStore.Application.Interfaces;
using E_TradeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TradeStore.Application.Features.Cqrs.Handlers.CategoryHandler;

public class RemoveCategoryCommandHandler
{
    private readonly IRepository<Category> _categoryRepository;

    public RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task Handle(DeleteCategoryCommand deleteCategoryCommand)
    {
        await _categoryRepository.DeleteAsync(deleteCategoryCommand.Id);
    }
}
