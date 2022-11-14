using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    public Task<IEnumerable<ProductDto>> GetCatalogProductsAsync(
        Dictionary<TypeFilter, int>? filters,
        TypeSorting? sorting);
}