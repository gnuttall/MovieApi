using MovieApi.Services.Enums;

namespace MovieApi.Services.Models;

public class PaginationRequest
{
    public string? SearchTerm { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public MovieSortableFields SortBy { get; set; }
    public string? GenreFilter { get; set; }
    public OrderBy OrderBy { get; set; }
}