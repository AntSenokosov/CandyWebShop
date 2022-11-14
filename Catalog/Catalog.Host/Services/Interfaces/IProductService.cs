using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetProductsAsync();
    public Task<ProductDto?> GetProductAsync(int id);

    public Task<ProductDto> AddProductAsync(
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available);

    public Task<ProductDto?> UpdateProductAsync(
        int id,
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available);

    public Task<ProductDto?> RemoveProductAsync(int id);
}