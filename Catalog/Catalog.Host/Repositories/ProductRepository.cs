using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _db;

    public ProductRepository(IDbContextWrapper<CatalogDbContext> db)
    {
        _db = db.DbContext;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        return product;
    }

    public async Task<Product> AddProductAsync(
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available)
    {
        var product = new Product()
        {
            Name = name,
            CategoryId = categoryId,
            ManufactureId = manufactureId,
            Description = description,
            Price = price,
            PictureFileName = picture,
            CountProduct = countProduct,
            Available = available
        };

        var newProduct = await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();

        return newProduct.Entity;
    }

    public async Task<Product?> UpdateProductAsync(
        int id,
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        product.Name = name;
        product.CategoryId = categoryId;
        product.ManufactureId = manufactureId;
        product.Description = description;
        product.Price = price;
        product.PictureFileName = picture;
        product.CountProduct = countProduct;
        product.Available = available;

        var newProduct = _db.Products.Update(product);
        await _db.SaveChangesAsync();

        return newProduct.Entity;
    }

    public async Task<Product?> RemoveProductAsync(int id)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        var newProduct = _db.Products.Remove(product);
        await _db.SaveChangesAsync();

        return newProduct.Entity;
    }
}