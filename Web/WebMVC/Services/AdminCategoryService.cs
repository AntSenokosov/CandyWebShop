using Microsoft.Extensions.Options;
using WebMVC.Configurations;
using WebMVC.Models;
using WebMVC.Models.Requests;
using WebMVC.Models.Responses;
using WebMVC.Services.Interfaces;

namespace WebMVC.Services;

public class AdminCategoryService : IAdminCategoryService
{
    private readonly IHttpClientService _clientService;
    private readonly AppSettings _settings;

    public AdminCategoryService(
        IHttpClientService clientService,
        IOptions<AppSettings> settings)
    {
        _clientService = clientService;
        _settings = settings.Value;
    }

    public async Task<ItemsListResponse<Category>?> GetCategoriesAsync()
    {
        var response = await _clientService.SendAsync<ItemsListResponse<Category>?, object?>(
            $"{_settings.AdminCategoryUrl}/GetCategories",
            HttpMethod.Get,
            null);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Category>?> GetCategoryAsync(int id)
    {
        var response = await _clientService.SendAsync<ItemResponse<Category>?, object>(
            $"{_settings.AdminCategoryUrl}/GetCategory/{id}",
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

    public async Task<ItemResponse<Category>?> AddCategoryAsync(AddRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Category>?, AddRequest>(
            $"{_settings.AdminCategoryUrl}/AddCategory",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Category>?> UpdateCategoryAsync(UpdateRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Category>?, UpdateRequest>(
            $"{_settings.AdminCategoryUrl}/UpdateCategory",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Category>?> RemoveCategoryAsync(GetRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Category>?, GetRequest>(
            $"{_settings.AdminCategoryUrl}/RemoveCategory",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }
}