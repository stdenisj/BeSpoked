using BeSpoked.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/[controller]")]
public class ProductController : BeSpokedBaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
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
}