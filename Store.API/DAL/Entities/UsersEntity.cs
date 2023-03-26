namespace Store.API.DAL.Entities;

public sealed record UsersEntity
{
    public Guid Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public bool IsAdmin { get; init; } 
}
