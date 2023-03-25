using Microsoft.EntityFrameworkCore;
using Store.API.DAL.Entities;

namespace Store.API.DAL;

public sealed class UsersRepository : IUsersRepository
{
    private readonly ProductsDbContext _dbContext;

    public UsersRepository(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<UsersEntity>> GetAll()
    {
        return Task.FromResult<IEnumerable<UsersEntity>>(_dbContext.Users!.ToList());
    }

    public Task<UsersEntity?> GetById(Guid id)
    {
        return _dbContext.Users!
         .FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public async Task Create(UsersEntity entity)
    {
        await _dbContext.Users!.AddAsync(entity); // добавление в слепок БД
        await _dbContext.SaveChangesAsync(); // Сохраняем в БД
    }
}

