using Microsoft.Extensions.Options;
using WebMVC.Configurations;
using WebMVC.Models;
using WebMVC.Models.Requests;
using WebMVC.Models.Responses;
using WebMVC.Services.Interfaces;

namespace WebMVC.Services;

public class AdminProductService : IAdminProductService
{
    private readonly IHttpClientService _clientService;
    private readonly AppSettings _settings;

    public AdminProductService(
        IHttpClientService clientService,
        IOptions<AppSettings> settings)
    {
        _clientService = clientService;
        _settings = settings.Value;
    }

    public async Task<ItemsListResponse<Product>?> GetProductsAsync()
    {
        var response = await _clientService.SendAsync<ItemsListResponse<Product>?, object>(
            $"{_settings.AdminProductUrl}/GetProducts",
            HttpMethod.Get,
            null);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Product>?> GetProductAsync(int id)
    {
        var response = await _clientService.SendAsync<ItemResponse<Product>?, object>(
            $"{_settings.AdminProductUrl}/GetProduct/{id}",
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

    public async Task<ItemResponse<Product>?> AddProductAsync(AddProductRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Product>?, AddProductRequest>(
            $"{_settings.AdminProductUrl}/AddProduct",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Product>?> UpdateProductAsync(UpdateProductRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Product>?, UpdateProductRequest>(
            $"{_settings.AdminProductUrl}/UpdateProduct",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }

    public async Task<ItemResponse<Product>?> RemoveProductAsync(GetRequest request)
    {
        var response = await _clientService.SendAsync<ItemResponse<Product>?, GetRequest>(
            $"{_settings.AdminProductUrl}/RemoveProduct",
            HttpMethod.Post,
            request);

        if (response == null)
        {
            return null;
        }

        return response;
    }
}