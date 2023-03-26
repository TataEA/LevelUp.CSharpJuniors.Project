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

    [HttpGet("allProduct")]
    public async Task<ActionResult<IEnumerable<ProductItem>>> GetProducts()
    {
        var products = await _productsService.GetProducts();
        return Ok(products);
    }

    [HttpGet("productId")]
    public async Task<ActionResult<ProductItem>> GetById(Guid productId)
    {
        var product = await _productsService.GetProductById(productId);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost("addProduct")]
    public async Task<IActionResult> AddProduct(ProductItem productItem)
    {
        await _productsService.AddProduct(productItem);
        return Ok();
    }

    [HttpDelete("delProduct")]
    public async Task<IActionResult> delProduct(Guid id)
    {
        await _productsService.DeleteProduct(id);
        return Ok();
    }

    [HttpPut("upDateProduct")]
    public async Task<IActionResult> UpDate(ProductItem productItem)
    {
        await _productsService.UpDate(productItem);
        return Ok();
    }
}
