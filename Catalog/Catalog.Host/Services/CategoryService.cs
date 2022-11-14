using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CategoryService : BaseDataService<CatalogDbContext>, ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    protected CategoryService(
        IDbContextWrapper<CatalogDbContext> dbContextWrapper,
        ILogger<BaseDataService<CatalogDbContext>> logger,
        IMapper mapper,
        ICategoryRepository categoryRepository)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        return categories.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
    }

    public async Task<CategoryDto?> GetCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryAsync(id);

        if (category == null)
        {
            return null;
        }

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> AddCategoryAsync(string name)
    {
        var category = await _categoryRepository.AddCategoryAsync(name);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(int id, string name)
    {
        var category = await _categoryRepository.UpdateCategoryAsync(id, name);

        if (category == null)
        {
            return null;
        }

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto?> RemoveCategoryAsync(int id)
    {
        var category = await _categoryRepository.RemoveCategoryAsync(id);

        if (category == null)
        {
            return null;
        }

        return _mapper.Map<CategoryDto>(category);
    }
}