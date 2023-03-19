using Store.API.Models;

namespace Store.API.Services;

public interface IProductsService
{
    IEnumerable<ProductItem> GetProducts();
}
