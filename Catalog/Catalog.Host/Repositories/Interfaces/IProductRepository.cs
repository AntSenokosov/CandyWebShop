using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Enums;

namespace Catalog.Host.Repositories.Interfaces;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetProductsByCatalogAsync(
        int? categoryFilter,
        int? manufactureFilter,
        decimal? priceMinFilter,
        decimal? priceMaxFilter,
        TypeSorting? sorting);
    public Task<IEnumerable<Product>> GetProductsAsync();
    public Task<Product?> GetProductAsync(int id);

    public Task<Product> AddProductAsync(
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available);

    public Task<Product?> UpdateProductAsync(
        int id,
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available);

    public Task<Product?> RemoveProductAsync(int id);
}