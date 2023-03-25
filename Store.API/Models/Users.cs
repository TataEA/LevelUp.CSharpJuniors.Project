using Store.API.DAL.Entities;

namespace Store.API.Models;

public sealed record Users(Guid Id, string Name, bool IsAdmin)
{
    public static Users FromEntity(UsersEntity user)
    {
        return new Users(user.Id, user.Name, user.IsAdmin);
    }
}
