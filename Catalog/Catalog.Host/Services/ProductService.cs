using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class ProductService : BaseDataService<CatalogDbContext>, IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    protected ProductService(
        IDbContextWrapper<CatalogDbContext> dbContextWrapper,
        ILogger<BaseDataService<CatalogDbContext>> logger,
        IMapper mapper,
        IProductRepository productRepository)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
    }

    public async Task<ProductDto?> GetProductAsync(int id)
    {
        var product = await _productRepository.GetProductAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> AddProductAsync(
        string name,
        int categoryId,
        int manufactureId,
        string description,
        decimal price,
        string picture,
        int countProduct,
        bool available)
    {
        var product = await _productRepository.AddProductAsync(
            name,
            categoryId,
            manufactureId,
            description,
            price,
            picture,
            countProduct,
            available);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto?> UpdateProductAsync(
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
        var product = await _productRepository.UpdateProductAsync(
            id,
            name,
            categoryId,
            manufactureId,
            description,
            price,
            picture,
            countProduct,
            available);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto?> RemoveProductAsync(int id)
    {
        var product = await _productRepository.RemoveProductAsync(id);
        return _mapper.Map<ProductDto>(product);
    }
}