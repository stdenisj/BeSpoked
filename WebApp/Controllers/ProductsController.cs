using BeSpoked.Api.Models.Products;
using BeSpoked.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Api.Controllers;

[Route("/api/[controller]")]
public class ProductsController : BeSpokedBaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAll(cancellationToken);
        return Success(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productService.Get(id, cancellationToken);
        return Success(product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductModel model, CancellationToken cancellationToken)
    {
        var product = await _productService.Get(model.Id, cancellationToken);
        var updatedProduct = await _productService.Update(product, model.ToRequest(), cancellationToken);
        return Success(updatedProduct);
    }
}