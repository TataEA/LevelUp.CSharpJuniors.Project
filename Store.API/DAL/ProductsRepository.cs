using Microsoft.EntityFrameworkCore;
using Store.API.DAL.Entities;

namespace Store.API.DAL;

public sealed class ProductsRepository : IProductsRepository
{
    private readonly ProductsDbContext _dbContext;

    public ProductsRepository(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<ProductEntity>> GetAll()
    {
        return Task.FromResult<IEnumerable<ProductEntity>>(_dbContext.Products!.ToList());
    }

    public Task<ProductEntity?> GetById(Guid id)
    {
       return _dbContext.Products!
        .FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public async Task Create(ProductEntity entity)
    {
        await _dbContext.Products!.AddAsync(entity); // добавление в слепок БД
        await _dbContext.SaveChangesAsync(); // Сохраняем в БД
    }
    public async Task Delete(Guid id) 
    {
        var  entity = await _dbContext.Products!.FirstOrDefaultAsync(e => e.Id== id);
        _dbContext.Products!.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(ProductEntity entity)
    {
        _dbContext.Products!.Update(entity); // добавление в слепок БД
        await _dbContext.SaveChangesAsync();
    }
}
