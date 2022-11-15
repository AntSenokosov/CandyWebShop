using Microsoft.Extensions.Options;
using WebMVC.Configurations;
using WebMVC.Models;
using WebMVC.Models.Requests;
using WebMVC.Models.Responses;
using WebMVC.Services.Interfaces;

namespace WebMVC.Services;

public class AdminManufactureService : IAdminManufactureService
{
    private readonly IHttpClientService _clientService;
    private readonly AppSettings _settings;

    public AdminManufactureService(
        IHttpClientService clientService,
        IOptions<AppSettings> settings)
    {
        _clientService = clientService;
        _settings = settings.Value;
    }

    public async Task<ItemsListResponse<Manufacture>?> GetManufacturesAsync()
    {
        var response = await _clientService.SendAsync<ItemsListResponse<Manufacture>?, object?>(
            $"{_settings.AdminManufactureUrl}/GetManufactures",
            HttpMethod.Get,
            null);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Manufacture>?> GetManufactureAsync(int id)
    {
        var response = await _clientService.SendAsync<ItemResponse<Manufacture>?, object>(
            $"{_settings.AdminManufactureUrl}/GetManufacture/{id}",
            HttpMethod.Post,
            new GetRequest()
            {
                Id = id
            });

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Manufacture>?> AddManufactureAsync(AddRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Manufacture>?, AddRequest>(
            $"{_settings.AdminManufactureUrl}/AddManufacture",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Manufacture>?> UpdateManufactureAsync(UpdateRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Manufacture>?, UpdateRequest>(
            $"{_settings.AdminManufactureUrl}/UpdateManufacture",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Manufacture>?> RemoveManufactureAsync(GetRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Manufacture>?, GetRequest>(
            $"{_settings.AdminManufactureUrl}/RemoveManufacture",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }
}