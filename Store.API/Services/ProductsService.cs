using Store.API.Models;

namespace Store.API.Services;

public sealed class ProductsService : IProductsService
{
    private Dictionary<Guid, ProductItem> _products = new();
    public ProductsService()
    {
        InitProduct();
    }
    public IEnumerable<ProductItem> GetProducts()
    {
        return _products.Values;
    }
    private void InitProduct()
    {
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var guid3 = Guid.NewGuid();

        _products = new Dictionary<Guid, ProductItem>
            {
                { guid1, new ProductItem(guid1, "Печенье", "Сдобное")},
                { guid2, new ProductItem(guid1, "Мармеладки", "Мишки")},
                { guid3, new ProductItem(guid1, "Шоколад", "С орешками")},
            };
    }
    
}
