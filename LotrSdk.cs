using LOTR.SDK.Models;

namespace LOTR.SDK;

public class LotrSdk(string apiKey, string version = "v2") : ILotrSdk
{
    private readonly LotrApiClient _client = new(apiKey, version);

    public Task<ApiResponse<Movie>?> GetMoviesAsync(int? limit = null, int? page = null, int? offset = null) 
        => _client.GetMoviesAsync(limit, page, offset);

    public Task<ApiResponse<Movie>?> GetMovieByIdAsync(string id) 
        => _client.GetMovieByIdAsync(id);

    public Task<ApiResponse<Quote>?> GetQuotesByMovieIdAsync(string movieId, int? limit = null, int? page = null, int? offset = null) 
        => _client.GetQuotesByMovieIdAsync(movieId, limit, page, offset);

    public Task<ApiResponse<Quote>?> GetQuotesAsync(int? limit = null, int? page = null, int? offset = null) 
        => _client.GetQuotesAsync(limit, page, offset);

    public Task<ApiResponse<Quote>?> GetQuoteByIdAsync(string id) 
        => _client.GetQuoteByIdAsync(id);
}