using WebMVC.Models;
using WebMVC.Models.Requests;
using WebMVC.Models.Responses;

namespace WebMVC.Services.Interfaces;

public interface IAdminCategoryService
{
    public Task<ItemsListResponse<Category>?> GetCategoriesAsync();
    public Task<ItemResponse<Category>?> GetCategoryAsync(int id);
    public Task<ItemResponse<Category>?> AddCategoryAsync(AddRequest request);
    public Task<ItemResponse<Category>?> UpdateCategoryAsync(UpdateRequest request);
    public Task<ItemResponse<Category>?> RemoveCategoryAsync(GetRequest request);
}