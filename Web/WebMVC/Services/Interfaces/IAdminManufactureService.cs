using WebMVC.Models;
using WebMVC.Models.Requests;
using WebMVC.Models.Responses;

namespace WebMVC.Services.Interfaces;

public interface IAdminManufactureService
{
    public Task<ItemsListResponse<Manufacture>?> GetManufacturesAsync();
    public Task<ItemResponse<Manufacture>?> GetManufactureAsync(int id);
    public Task<ItemResponse<Manufacture>?> AddManufactureAsync(AddRequest request);
    public Task<ItemResponse<Manufacture>?> UpdateManufactureAsync(UpdateRequest request);
    public Task<ItemResponse<Manufacture>?> RemoveManufactureAsync(GetRequest request);
}