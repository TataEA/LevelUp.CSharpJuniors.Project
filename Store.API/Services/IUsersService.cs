using Store.API.Models;

namespace Store.API.Services;

public interface IUsersService
{
    Task<IEnumerable<Users>> GetUsers();

    Task<Users?> GetUsersById(Guid userId);

    Task AddUsers(Users user);
}
