using System.Net;

namespace WebMVC.Models.Responses;

public class ItemResponse<T>
{
    public T? Item { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
}