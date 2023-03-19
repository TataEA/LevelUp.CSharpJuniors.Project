namespace Store.API.Models;

public sealed record ProductItem(Guid Id, string Name, string? Description);
/*{
    public static ProductItem FromEntity(ProductEntity entity)
    {
        return new ProductItem(entity.Id, entity.Name, entity.CategoryId, entity.Description);
    }
}*/