using LOTR.SDK.Models;
using Newtonsoft.Json;

namespace LOTR.SDK;

public class LotrApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://the-one-api.dev";
    private readonly string _version;

    public LotrApiClient(string apiKey, string version = "v2")
    { 
        _httpClient = new HttpClient();
        _version = version;

        if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }
    }

    private string GetEndpoint(string endpoint, int? limit = null, int? page = null, int? offset = null)
    {
        var url = $"{BaseUrl}/{_version}{endpoint}";

        var queryParams = new List<string>();
        if (limit.HasValue)
        {
            queryParams.Add($"limit={limit.Value}");
        }
        if (page.HasValue)
        {
            queryParams.Add($"page={page.Value}");
        }
        if (offset.HasValue)
        {
            queryParams.Add($"offset={offset.Value}");
        }

        if (queryParams.Count != 0)
        {
            url += "?" + string.Join("&", queryParams);
        }

        return url;
    }

    private static async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(content);
            throw new Exception(errorResponse?.Message ?? "An unexplainable API error occurred.");
        }

        return JsonConvert.DeserializeObject<T>(content);
    }

    public async Task<ApiResponse<Movie>?> GetMoviesAsync(int? limit = null, int? page = null, int? offset = null)
    {
        var response = await _httpClient.GetAsync(GetEndpoint("/movie", limit, page, offset));
        return await HandleResponse<ApiResponse<Movie>>(response);
    }

    public async Task<ApiResponse<Movie>?> GetMovieByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync(GetEndpoint($"/movie/{id}"));
        return await HandleResponse<ApiResponse<Movie>>(response);
    }

    public async Task<ApiResponse<Quote>?> GetQuotesByMovieIdAsync(string movieId, int? limit = null, int? page = null, int? offset = null)
    {
        var response = await _httpClient.GetAsync(GetEndpoint($"/movie/{movieId}/quote", limit, page, offset));
        return await HandleResponse<ApiResponse<Quote>>(response);
    }

    public async Task<ApiResponse<Quote>?> GetQuotesAsync(int? limit = null, int? page = null, int? offset = null)
    {
        var response = await _httpClient.GetAsync(GetEndpoint("/quote", limit, page, offset));
        return await HandleResponse<ApiResponse<Quote>>(response);
    }

    public async Task<ApiResponse<Quote>?> GetQuoteByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync(GetEndpoint($"/quote/{id}"));
        return await HandleResponse<ApiResponse<Quote>>(response);
    }
}