using Microsoft.AspNetCore.Mvc;
using Store.API.Models;
using Store.API.Services;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ProductItem>>> GetProducts()
    {
        var products = await _productsService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductItem>> GetById(Guid productId)
    {
        var product = await _productsService.GetProductById(productId);
        return product == null ? NotFound() : Ok(product);
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddProduct(ProductItem productItem)
    {
        await _productsService.AddProduct(productItem);
        return Ok();
    }
}
