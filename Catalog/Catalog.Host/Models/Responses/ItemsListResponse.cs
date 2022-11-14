namespace Catalog.Host.Models.Responses;

public class ItemsListResponse<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
}