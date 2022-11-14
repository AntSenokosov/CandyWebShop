using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[Route(ComponentDefault.DefaultRoute)]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
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

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(ItemResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategory(int id)
    {
        var response = new ItemResponse<CategoryDto>();
        if (id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
            return Ok(response);
        }

        var category = await _categoryService.GetCategoryAsync(id);

        if (category == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Category with Id - {id} not found";
        }

        response.Item = category;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddCategory(AddRequest request)
    {
        var response = new ItemResponse<CategoryDto>()
        {
            Item = await _categoryService.AddCategoryAsync(request.Name),
            StatusCode = HttpStatusCode.OK,
            Message = string.Empty
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateCategory(UpdateRequest request)
    {
        var response = new ItemResponse<CategoryDto>();

        if (request.Id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var category = await _categoryService.UpdateCategoryAsync(request.Id, request.Name);

        if (category == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Category with Id - {request.Id} not found";
        }

        response.Item = category;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<CategoryDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RemoveCategory(RemoveRequest request)
    {
        var response = new ItemResponse<CategoryDto>();

        if (request.Id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var category = await _categoryService.RemoveCategoryAsync(request.Id);

        if (category == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Category with Id - {request.Id} not found";
        }

        response.Item = category;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }
}