namespace Catalog.Host.Models.Requests;

public class CatalogRequest<TFilters, TSorting>
    where TFilters : notnull
    where TSorting : Enum
{
    public Dictionary<TFilters, int>? Filters { get; set; }

    public TSorting? Sorting { get; set; }
}