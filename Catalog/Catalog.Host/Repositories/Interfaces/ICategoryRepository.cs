using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> GetCategoriesAsync();
    public Task<Category?> GetCategoryAsync(int id);
    public Task<Category> AddCategoryAsync(string name);
    public Task<Category?> UpdateCategoryAsync(int id, string name);
    public Task<Category?> RemoveCategoryAsync(int id);
}