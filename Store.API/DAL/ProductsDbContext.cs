using Microsoft.EntityFrameworkCore;
using Store.API.DAL.Configurations;
using Store.API.DAL.Entities;

namespace Store.API.DAL;

public sealed class ProductsDbContext : DbContext
{
    public DbSet<ProductEntity>? Products { get; set; } // Products - таблица, ProductEntity - строка в таблице + 5 колоки (внутри ProductEntity)
    public DbSet<UsersEntity>? Users { get; set; }
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
       // Database.EnsureCreated();
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
    }
   
}