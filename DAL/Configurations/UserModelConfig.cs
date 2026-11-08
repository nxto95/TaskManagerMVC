
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class UserModelConfig : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Username).IsUnique();

        builder.Property(u => u.Username).HasColumnType("VARCHAR(55)").IsRequired();
        builder.Property(u => u.Email).HasColumnType("VARCHAR(255)").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnType("VARCHAR(255)").IsRequired();


    }
}
