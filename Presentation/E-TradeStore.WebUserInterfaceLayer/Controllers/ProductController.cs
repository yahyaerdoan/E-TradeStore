﻿using E_TradeStore.Application.Features.Cqrs.Commands.ProductCommand;
using E_TradeStore.Application.Features.Cqrs.Handlers.ProductHandler;
using E_TradeStore.Application.Features.Cqrs.Queries.ProductQuery;
using Microsoft.AspNetCore.Mvc;

namespace E_TradeStore.WebUserInterface.Controllers;

public class ProductController : Controller
{
    private readonly CreateProductCommandHandler _createProductCommandHandler;
    private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
    private readonly GetProductQueryHandler _getProductQueryHandler;
    private readonly RemoveProductCommandHandler _removeProductCommandHandler;
    private readonly UpdateProductCommandHandler _updateProductCommandHandler;

    public ProductController(CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductQueryHandler getProductQueryHandler, RemoveProductCommandHandler removeProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler)
    {
        _createProductCommandHandler = createProductCommandHandler;
        _getProductByIdQueryHandler = getProductByIdQueryHandler;
        _getProductQueryHandler = getProductQueryHandler;
        _removeProductCommandHandler = removeProductCommandHandler;
        _updateProductCommandHandler = updateProductCommandHandler;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _getProductQueryHandler.Handle();
        return View(values);
    }
    [HttpGet]
    public IActionResult CreateProduct()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
    {
        await _createProductCommandHandler.Handle(createProductCommand);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> DeleteProduct(int id) 
    {
        await _removeProductCommandHandler.Handle(new DeleteProductCommand(id));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        var values = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
        return View(values);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
    {
        await _updateProductCommandHandler.Handle(updateProductCommand);
        return RedirectToAction(nameof(Index));
    }
}

