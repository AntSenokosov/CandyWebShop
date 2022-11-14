using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface IManufactureService
{
    public Task<IEnumerable<ManufactureDto>> GetManufacturesAsync();
    public Task<ManufactureDto?> GetManufactureAsync(int id);
    public Task<ManufactureDto> AddManufactureAsync(string name);
    public Task<ManufactureDto?> UpdateManufactureAsync(int id, string name);
    public Task<ManufactureDto?> RemoveManufactureAsync(int id);
}