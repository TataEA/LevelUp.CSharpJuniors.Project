using Microsoft.AspNetCore.Mvc;
using Store.API.Models;
using Store.API.Services;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductsController : ControllerBase
{
    private IProductsService _productsService;
    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<ProductItem>> GetProducts()
    {
        var products = _productsService.GetProducts();
        return Ok(products);
    }
}
