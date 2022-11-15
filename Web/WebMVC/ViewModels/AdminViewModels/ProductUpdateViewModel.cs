using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;

namespace WebMVC.ViewModels.AdminViewModels;

public class ProductUpdateViewModel
{
    public Product? Product { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> Manufactures { get; set; } = Enumerable.Empty<SelectListItem>();
    public int? CategoryApplied { get; set; }
    public int? ManufactureApplied { get; set; }
    public string? PictureFileName { get; set; }
}