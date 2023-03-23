using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.API.DAL.Entities;

namespace Store.API.DAL.Configurations;

public sealed class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired() // не нулл
            .HasColumnType("nvarchar")
            .HasMaxLength(300);

        builder.Property(e => e.Description)
            .HasColumnType("nvarchar")
            .HasMaxLength(500);

        builder.Property(e => e.CategoryId)
            .IsRequired()
            .HasColumnType("uniqueidentifier");

        builder.HasIndex(e => e.CategoryId);
    }
}