using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[Route(ComponentDefault.DefaultRoute)]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ItemsListResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
    {
        var response = new ItemsListResponse<ProductDto>()
        {
            Items = await _productService.GetProductsAsync()
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

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddProduct(AddProductRequest request)
    {
        var response = new ItemResponse<ProductDto>()
        {
            Item = await _productService.AddProductAsync(
                request.Name,
                request.CategoryId,
                request.ManufactureId,
                request.Description,
                request.Price,
                request.PictureFileName,
                request.CountProduct,
                request.Available),
            StatusCode = HttpStatusCode.OK,
            Message = string.Empty
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
        var response = new ItemResponse<ProductDto>();

        if (request.Id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var product = await _productService.UpdateProductAsync(
            request.Id,
            request.Name,
            request.CategoryId,
            request.ManufactureId,
            request.Description,
            request.Price,
            request.PictureFileName,
            request.CountProduct,
            request.Available);

        if (product == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Product with id - {request.Id} not found";
        }

        response.Item = product;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<ProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RemoveProduct(RemoveRequest request)
    {
        var response = new ItemResponse<ProductDto>();

        if (request.Id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var product = await _productService.RemoveProductAsync(request.Id);

        if (product == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Product with id - {request.Id} not found";
        }

        response.Item = product;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }
}