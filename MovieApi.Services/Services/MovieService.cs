using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Entities;
using MovieApi.Services.Extensions;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;

namespace MovieApi.Services.Services;

public class MovieService : IMovieService
{
    private readonly DatabaseContext _databaseContext;

    public MovieService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    /// <inheritdoc/>
    public async Task AddRangeAsync(List<Movie> movies)
    {
        await _databaseContext.AddRangeAsync(movies);
        await _databaseContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<Pagination<Movie>> GetPaginatedAsync(PaginationRequest request)
    {
        var query = _databaseContext.Movies.AsQueryable();

        if (request.SearchTerm.IsNotNullOrEmpty())
            query = query.Where(x => EF.Functions.Like(x.Title, $"{request.SearchTerm}%"));

        if (request.GenreFilter.IsNotNullOrEmpty())
            query = query.Where(x => EF.Functions.Like(x.Genres, $"%{request.GenreFilter}%"));

        query = query.Sort(request.SortBy, request.OrderBy);

        var movies = await query.PaginateAsync(request.Page, request.PageSize);

        return movies;
    }

    /// <inheritdoc/>
    public async Task<List<string>> GetAllGenresAsync()
    {
        var genres = await _databaseContext.Movies
            .Select(x => x.Genres).ToListAsync();

        var genreList = genres.SelectMany(x => x.Split(',', StringSplitOptions.TrimEntries)).Distinct().ToList();
        
        return genreList;
    }
}