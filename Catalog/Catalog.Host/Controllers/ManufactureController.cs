using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[Route(ComponentDefault.DefaultRoute)]
public class ManufactureController : Controller
{
    private readonly IManufactureService _manufactureService;

    public ManufactureController(IManufactureService manufactureService)
    {
        _manufactureService = manufactureService;
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

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(ItemResponse<ManufactureDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetManufacture(int id)
    {
        var response = new ItemResponse<ManufactureDto>();

        if (id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var manufacture = await _manufactureService.GetManufactureAsync(id);

        if (manufacture == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Manufacture with id - {id} not found";
        }

        response.Item = manufacture;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<ManufactureDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddManufacture(AddRequest request)
    {
        var response = new ItemResponse<ManufactureDto>()
        {
            Item = await _manufactureService.AddManufactureAsync(request.Name),
            StatusCode = HttpStatusCode.OK,
            Message = string.Empty
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<ManufactureDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateManufacture(UpdateRequest request)
    {
        var response = new ItemResponse<ManufactureDto>();

        if (request.Id <= 0)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Message = "Id must be than 0";
        }

        var manufacture = await _manufactureService.UpdateManufactureAsync(request.Id, request.Name);

        if (manufacture == null)
        {
            response.Item = null;
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = $"Manufacture with id - {request.Id} not found";
        }

        response.Item = manufacture;
        response.StatusCode = HttpStatusCode.OK;
        response.Message = string.Empty;

        return Ok(response);
    }
}