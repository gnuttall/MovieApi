using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Services.Enums;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;

namespace MovieApi.Controllers;

public class MovieController : BaseApiController
{
    private readonly IMovieService _movieService;
    private readonly IMapper _mapper;

    
    public MovieController(IMovieService movieService, IMapper mapper)
    {
        _movieService = movieService;
        _mapper = mapper;
    }

    /// <summary>
    /// Get movies in a paginated response
    /// </summary>
    /// <param name="searchTerm">optional</param>
    /// <param name="page">optional, defaults to 1</param>
    /// <param name="pageSize">optional, defaults to 20</param>
    /// <param name="sortBy">optional, defaults to popularity</param>
    /// <param name="orderBy">optional, defaults to descending</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<Attempt<PaginationDto<MovieDto>>> GetPaginated([FromQuery] string? searchTerm = null,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] MovieSortableFields sortBy = MovieSortableFields.Popularity,
        [FromQuery] OrderBy orderBy = OrderBy.Descending, [FromQuery] string? genreFilter = null)
    {
        var request = new PaginationRequest
        {
            SearchTerm = searchTerm,
            Page = page,
            PageSize = pageSize,
            SortBy = sortBy,
            OrderBy = orderBy,
            GenreFilter = genreFilter
        };
        
        var categories = await _movieService.GetPaginatedAsync(request);
        var result = _mapper.Map<PaginationDto<MovieDto>>(categories);

        return Attempt<PaginationDto<MovieDto>>.Succeed(result);
    }

    /// <summary>
    /// Get all available genres
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("genres")]
    public async Task<Attempt<List<string>>> GetAllGenres()
    {
        var genres = await _movieService.GetAllGenresAsync();

        return Attempt<List<string>>.Succeed(genres);
    }
}