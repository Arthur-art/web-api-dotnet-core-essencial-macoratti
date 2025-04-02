using Microsoft.EntityFrameworkCore;
using web_api_catalog.Models;

namespace web_api_catalog.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category>? categories { get; set; }
    public DbSet<Product>? products { get; set; }

}
