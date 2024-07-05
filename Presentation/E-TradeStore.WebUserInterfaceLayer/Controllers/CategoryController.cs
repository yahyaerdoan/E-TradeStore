using E_TradeStore.Application.Features.Cqrs.Commands.Category;
using E_TradeStore.Application.Features.Cqrs.Handlers.CategoryHandler;
using E_TradeStore.Application.Features.Cqrs.Queries.Category;
using Microsoft.AspNetCore.Mvc;

namespace E_TradeStore.WebUserInterface.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCategoryCommandHandler.Handle(createCategoryCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new DeleteCategoryCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return RedirectToAction("Index");
        }

    }
}
