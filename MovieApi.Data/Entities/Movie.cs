using MovieApi.Data.Entities.Common;

namespace MovieApi.Data.Entities;

public class Movie : BaseEntity
{
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public float Popularity { get; set; }
    public int VoteCount { get; set; }
    public float VoteAverage { get; set; }
    public string OriginalLanguage { get; set; }
    public string Genres { get; set; }
    public string PosterUrl { get; set; }
}