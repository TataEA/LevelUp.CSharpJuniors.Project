using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.API.DAL.Entities;

namespace Store.API.DAL.Configurations;

public sealed class UsersEntityConfiguration : IEntityTypeConfiguration<UsersEntity>
{
    public void Configure(EntityTypeBuilder<UsersEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired() // не нулл
            .HasColumnType("nvarchar")
            .HasMaxLength(300);

        builder.Property(e => e.IsAdmin)
            .IsRequired()
            .HasColumnType("bool");
    }
}
