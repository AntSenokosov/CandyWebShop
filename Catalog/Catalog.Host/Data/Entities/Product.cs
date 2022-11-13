namespace Catalog.Host.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int ManufactureId { get; set; }
    public Manufacture Manufacture { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public int CountProduct { get; set; }
    public bool Available { get; set; }
}