using Store.API.DAL.Entities;
using Store.API.DAL;
using Store.API.Models;

namespace Store.API.Services;

public sealed class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<IEnumerable<Users>> GetUsers()
    {
        var user = await _usersRepository.GetAll();
        return user.Select(Users.FromEntity);
    }

    public async Task<Users?> GetUsersById(Guid userId)
    {
        var userEntity = await _usersRepository.GetById(userId);
        return userEntity == null ? null : Users.FromEntity(userEntity);
    }

    public async Task AddUsers(Users user)
    {
        var userEntity = new UsersEntity
        {
            Id = user.Id,
            Name = user.Name,
            IsAdmin = user.IsAdmin

        };

        await _usersRepository.Create(userEntity);
    }
}

