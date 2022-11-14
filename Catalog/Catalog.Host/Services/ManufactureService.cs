using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class ManufactureService : BaseDataService<CatalogDbContext>, IManufactureService
{
    private readonly IMapper _mapper;
    private readonly IManufactureRepository _manufactureRepository;

    public ManufactureService(
        IDbContextWrapper<CatalogDbContext> dbContextWrapper,
        ILogger<BaseDataService<CatalogDbContext>> logger,
        IMapper mapper,
        IManufactureRepository manufactureRepository)
        : base(dbContextWrapper, logger)
    {
        _mapper = mapper;
        _manufactureRepository = manufactureRepository;
    }

    public async Task<IEnumerable<ManufactureDto>> GetManufacturesAsync()
    {
        var manufactures = await _manufactureRepository.GetManufacturesAsync();
        return manufactures.Select(m => _mapper.Map<ManufactureDto>(m)).ToList();
    }

    public async Task<ManufactureDto?> GetManufactureAsync(int id)
    {
        var manufacture = await _manufactureRepository.GetManufactureAsync(id);

        if (manufacture == null)
        {
            return null;
        }

        return _mapper.Map<ManufactureDto>(manufacture);
    }

    public async Task<ManufactureDto> AddManufactureAsync(string name)
    {
        var manufacture = await _manufactureRepository.AddManufactureAsync(name);

        return _mapper.Map<ManufactureDto>(manufacture);
    }

    public async Task<ManufactureDto?> UpdateManufactureAsync(int id, string name)
    {
        var manufacture = await _manufactureRepository.UpdateManufactureAsync(id, name);

        if (manufacture == null)
        {
            return null;
        }

        return _mapper.Map<ManufactureDto>(manufacture);
    }

    public async Task<ManufactureDto?> RemoveManufactureAsync(int id)
    {
        var manufacture = await _manufactureRepository.RemoveManufactureAsync(id);

        if (manufacture == null)
        {
            return null;
        }

        return _mapper.Map<ManufactureDto>(manufacture);
    }
}