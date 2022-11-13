using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface IManufactureRepository
{
    public Task<IEnumerable<Manufacture>> GetManufacturesAsync();
    public Task<Manufacture?> GetManufactureAsync(int id);
    public Task<Manufacture> AddManufactureAsync(string name);
    public Task<Manufacture?> UpdateManufactureAsync(int id, string name);
    public Task<Manufacture?> RemoveManufactureAsync(int id);
}