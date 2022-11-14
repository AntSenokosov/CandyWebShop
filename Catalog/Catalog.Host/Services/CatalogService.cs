using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<CatalogDbContext>, ICatalogService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    protected CatalogService(
        IDbContextWrapper<CatalogDbContext> dbContextWrapper,
        ILogger<BaseDataService<CatalogDbContext>> logger,
        IMapper mapper,
        IProductRepository productRepository)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetCatalogProductsAsync(Dictionary<TypeFilter, int>? filters, TypeSorting? sorting)
    {
        int? categoryFilter = null;
        int? manufactureFilter = null;
        int? priceMinFilter = null;
        int? priceMaxFilter = null;
        TypeSorting typeSorting;

        if (filters != null)
        {
            if (filters.TryGetValue(TypeFilter.Category, out var category))
            {
                categoryFilter = category;
            }

            if (filters.TryGetValue(TypeFilter.Manufacture, out var manufacture))
            {
                manufactureFilter = manufacture;
            }

            if (filters.TryGetValue(TypeFilter.PriceMax, out var priceMax))
            {
                priceMaxFilter = priceMax;
            }

            if (filters.TryGetValue(TypeFilter.PriceMin, out var priceMin))
            {
                priceMinFilter = priceMin;
            }
        }

        sorting = sorting ?? 0;

        if (!Enum.TryParse(sorting.Value.ToString(), out typeSorting))
        {
            typeSorting = 0;
        }

        var products = await _productRepository.GetProductsByCatalogAsync(
            categoryFilter,
            manufactureFilter,
            priceMinFilter,
            priceMaxFilter,
            typeSorting);

        return products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
    }
}