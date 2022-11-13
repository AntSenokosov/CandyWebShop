namespace Catalog.Host.Models.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public int ManufactureId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public int CountProduct { get; set; }
    public bool Available { get; set; }
}