using Store.API.DAL.Entities;

namespace Store.API.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAll();

        public Task<ProductEntity?> GetById(Guid id);

        public Task Create(ProductEntity entity);
    }
}
