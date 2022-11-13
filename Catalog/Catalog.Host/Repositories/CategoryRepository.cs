using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _db;

    public CategoryRepository(IDbContextWrapper<CatalogDbContext> db)
    {
        _db = db.DbContext;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _db.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryAsync(int id)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return null;
        }

        return category;
    }

    public async Task<Category> AddCategoryAsync(string name)
    {
        var category = new Category()
        {
            Name = name
        };

        var newCategory = await _db.Categories.AddAsync(category);
        await _db.SaveChangesAsync();

        return newCategory.Entity;
    }

    public async Task<Category?> UpdateCategoryAsync(int id, string name)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return null;
        }

        category.Name = name;

        var newCategory = _db.Categories.Update(category);
        await _db.SaveChangesAsync();

        return newCategory.Entity;
    }

    public async Task<Category?> RemoveCategoryAsync(int id)
    {
        var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return null;
        }

        var newCategory = _db.Categories.Remove(category);
        await _db.SaveChangesAsync();

        return newCategory.Entity;
    }
}