using Store.API.DAL.Entities;
using Store.API.DAL;
using Store.API.Models;

namespace Store.API.Services;

public sealed class ProductsService : IProductsService
{
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<ProductItem>> GetProducts()
    {
        var entities = await _productsRepository.GetAll();
        return entities.Select(ProductItem.FromEntity);
    }

    public async Task<ProductItem?> GetProductById(Guid productId)
    {
        var productEntity = await _productsRepository.GetById(productId);
        return productEntity == null ? null : ProductItem.FromEntity(productEntity);
    }

    public async Task AddProduct(ProductItem productItem)
    {
        var productEntity = new ProductEntity
        {
            Id = productItem.Id,
            CategoryId = productItem.CategoryId,
            Name = productItem.Name,
            Description = productItem.Description
        };

        await _productsRepository.Create(productEntity);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _productsRepository.Delete(id);
    }

    public async Task UpDate(ProductItem productItem)
    {
        var productEntity = new ProductEntity
        {
            Id = productItem.Id,
            CategoryId = productItem.CategoryId,
            Name = productItem.Name,
            Description = productItem.Description
        };

        await _productsRepository.Update(productEntity);
    }
}
