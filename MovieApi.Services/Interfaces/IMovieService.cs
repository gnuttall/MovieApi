using MovieApi.Data.Entities;
using MovieApi.Services.Models;

namespace MovieApi.Services.Interfaces;

public interface IMovieService
{
    /// <summary>
    /// Add a range of movies to database
    /// </summary>
    /// <param name="movies"></param>
    /// <returns></returns>
    Task AddRangeAsync(List<Movie> movies);

    /// <summary>
    /// Get movies based on search criteria in a paginated response
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<Pagination<Movie>> GetPaginatedAsync(PaginationRequest request);

    /// <summary>
    /// Get all genres
    /// </summary>
    /// <returns></returns>
    Task<List<string>> GetAllGenresAsync();
}