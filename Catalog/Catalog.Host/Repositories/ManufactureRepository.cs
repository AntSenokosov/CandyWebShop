using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class ManufactureRepository : IManufactureRepository
{
    private readonly CatalogDbContext _db;

    public ManufactureRepository(IDbContextWrapper<CatalogDbContext> db)
    {
        _db = db.DbContext;
    }

    public async Task<IEnumerable<Manufacture>> GetManufacturesAsync()
    {
        return await _db.Manufactures.ToListAsync();
    }

    public async Task<Manufacture?> GetManufactureAsync(int id)
    {
        var manufacture = await _db.Manufactures.FirstOrDefaultAsync(m => m.Id == id);

        if (manufacture == null)
        {
            return null;
        }

        return manufacture;
    }

    public async Task<Manufacture> AddManufactureAsync(string name)
    {
        var manufacture = new Manufacture()
        {
            Name = name
        };

        var newManufacture = await _db.Manufactures.AddAsync(manufacture);
        await _db.SaveChangesAsync();

        return newManufacture.Entity;
    }

    public async Task<Manufacture?> UpdateManufactureAsync(int id, string name)
    {
        var manufacture = await _db.Manufactures.FirstOrDefaultAsync(m => m.Id == id);

        if (manufacture == null)
        {
            return null;
        }

        manufacture.Name = name;
        var newManufacture = _db.Manufactures.Update(manufacture);
        await _db.SaveChangesAsync();

        return newManufacture.Entity;
    }

    public async Task<Manufacture?> RemoveManufactureAsync(int id)
    {
        var manufacture = await _db.Manufactures.FirstOrDefaultAsync(m => m.Id == id);

        if (manufacture == null)
        {
            return null;
        }

        var newManufacture = _db.Manufactures.Remove(manufacture);
        await _db.SaveChangesAsync();

        return newManufacture.Entity;
    }
}