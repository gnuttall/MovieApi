namespace MovieApi.Services.Models;

public record PaginationDto<TResult>
{
    public IEnumerable<TResult> Results { get; set; }
    public int CurrentPage { get; set; }
    public int TotalResults { get; set; }
    public int TotalPages { get; set; }
}