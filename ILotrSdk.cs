using LOTR.SDK.Models;

namespace LOTR.SDK;

public interface ILotrSdk
{
    Task<ApiResponse<Movie>?> GetMoviesAsync(int? limit = null, int? page = null, int? offset = null);
    Task<ApiResponse<Movie>?> GetMovieByIdAsync(string id);
    Task<ApiResponse<Quote>?> GetQuotesByMovieIdAsync(string movieId, int? limit = null, int? page = null, int? offset = null);
    Task<ApiResponse<Quote>?> GetQuotesAsync(int? limit = null, int? page = null, int? offset = null);
    Task<ApiResponse<Quote>?> GetQuoteByIdAsync(string id);
}