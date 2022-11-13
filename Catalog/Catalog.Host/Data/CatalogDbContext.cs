using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> db)
        : base(db)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Manufacture> Manufactures { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryEntityConfiguration());
        builder.ApplyConfiguration(new ManufactureEntityConfiguration());
        builder.ApplyConfiguration(new ProductEntityConfiguration());
    }
}