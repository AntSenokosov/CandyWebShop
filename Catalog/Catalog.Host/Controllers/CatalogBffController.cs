using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[Route(ComponentDefault.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ICatalogService _catalogService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IManufactureService _manufactureService;

    public CatalogBffController(
        ICatalogService catalogService,
        IProductService productService,
        ICategoryService categoryService,
        IManufactureService manufactureService)
    {
        _catalogService = catalogService;
        _productService = productService;
        _categoryService = categoryService;
        _manufactureService = manufactureService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemsListResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts(CatalogRequest<TypeFilter, TypeSorting> request)
    {
        var response = new ItemsListResponse<ProductDto>()
        {
            Items = await _catalogService.GetCatalogProductsAsync(request.Filters, request.Sorting)
        };

        return Ok(response);
    }

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(ItemResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProduct(int id)
    {
        var response = new ItemResponse<ProductDto>();

        if (id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var product = await _productService.GetProductAsync(id);

        if (product == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Product with id - {id} not found";
        }

        response.Item = product;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ItemsListResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategories()
    {
        var response = new ItemsListResponse<CategoryDto>()
        {
            Items = await _categoryService.GetCategoriesAsync()
        };

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ItemsListResponse<ManufactureDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetManufactures()
    {
        var response = new ItemsListResponse<ManufactureDto>()
        {
            Items = await _manufactureService.GetManufacturesAsync()
        };

        return Ok(response);
    }
}