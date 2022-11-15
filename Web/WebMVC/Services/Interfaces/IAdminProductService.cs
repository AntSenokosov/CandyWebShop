using WebMVC.Models;
using WebMVC.Models.Requests;
using WebMVC.Models.Responses;

namespace WebMVC.Services.Interfaces;

public interface IAdminProductService
{
    public Task<ItemsListResponse<Product>?> GetProductsAsync();
    public Task<ItemResponse<Product>?> GetProductAsync(int id);
    public Task<ItemResponse<Product>?> AddProductAsync(AddProductRequest request);
    public Task<ItemResponse<Product>?> UpdateProductAsync(UpdateProductRequest request);
    public Task<ItemResponse<Product>?> RemoveProductAsync(GetRequest request);
}