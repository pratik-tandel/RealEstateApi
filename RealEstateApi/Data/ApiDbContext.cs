using RealEstateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstateApi.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext()
    {

    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LP149;Database=RealEstateDB;User Id=sa;Password=Admin@123;");
    }
}
