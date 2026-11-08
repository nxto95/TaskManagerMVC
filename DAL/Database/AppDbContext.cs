
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Database;

public class AppDbContext : DbContext
{

    public DbSet<UserModel> Users => Set<UserModel>();
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
