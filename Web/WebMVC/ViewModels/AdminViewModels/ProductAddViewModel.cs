using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC.ViewModels.AdminViewModels;

public class ProductAddViewModel
{
    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> Manufactures { get; set; } = Enumerable.Empty<SelectListItem>();
    public int? CategoryId { get; set; }
    public int? ManufactureId { get; set; }
}