namespace WebMVC.Services.Interfaces;

public interface IHttpClientService
{
    public Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content);
}