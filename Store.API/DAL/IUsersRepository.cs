using Store.API.DAL.Entities;

namespace Store.API.DAL
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<UsersEntity>> GetAll();

        public Task<UsersEntity?> GetById(Guid id);

        public Task Create(UsersEntity user);
    }
}