using Store.API.Models;

namespace Store.API.Services;

public interface IProductsService
{
    Task<IEnumerable<ProductItem>> GetProducts();

    Task<ProductItem?> GetProductById(Guid productId);

    Task AddProduct(ProductItem productItem);

    Task DeleteProduct(Guid productId);

    Task UpDate(ProductItem productItem);
}
