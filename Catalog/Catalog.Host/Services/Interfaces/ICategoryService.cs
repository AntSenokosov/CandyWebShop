using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    public Task<CategoryDto?> GetCategoryAsync(int id);
    public Task<CategoryDto> AddCategoryAsync(string name);
    public Task<CategoryDto?> UpdateCategoryAsync(int id, string name);
    public Task<CategoryDto?> RemoveCategoryAsync(int id);
}