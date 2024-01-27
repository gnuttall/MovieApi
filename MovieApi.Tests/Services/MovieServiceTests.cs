using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Data.Entities;
using MovieApi.Services.Enums;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;
using MovieApi.Services.Services;
using MovieApi.Tests.SeedData;
using NUnit.Framework;

namespace MovieApi.Tests.Services;

public class MovieServiceTests : BaseSetup
{
    private IMovieService _movieService;
    
    protected override void SetUp(DatabaseContext databaseContext)
    {
        _movieService = new MovieService(databaseContext);
    }

    [Test]
    public async Task GetAllGenresAsync_ReturnsNoDuplicates()
    {
        // act
        var genres = await _movieService.GetAllGenresAsync();

        // assert
        Assert.That(genres.Count, Is.EqualTo(genres.Distinct().Count()));
    }

    [Test]
    public void AddRangeAsync_InvalidEntriesAreNotAdded()
    {
        // arrange
        var newMovies = new List<Movie>()
        {
            new ()
            {
                ReleaseDate = new DateTime(2001, 12, 10),
                Title = "The lord of the rings: The fellowship of the ring",
                Overview = null,
                Popularity = 6302.243f,
                VoteCount = 1856,
                VoteAverage = 8,
                OriginalLanguage = "en",
                Genres = "Action, Fantasy",
                PosterUrl = "https://fakeurl.com"
            }
        };
        
        // assert
        Assert.That(() => _movieService.AddRangeAsync(newMovies), Throws.Exception.TypeOf<DbUpdateException>());
    }

    [Test]
    public async Task AddRangeAsync_ValidEntriesAreAdded()
    {
        // arrange
        var request = new PaginationRequest
        {
            SearchTerm = "The lord of the rings",
            Page = 1,
            PageSize = 10,
            SortBy = MovieSortableFields.ReleaseDate,
            OrderBy = OrderBy.Ascending
        };
        
        var newMovies = new List<Movie>()
        {
            new ()
            {
                ReleaseDate = new DateTime(2001, 12, 10),
                Title = "The lord of the rings: The fellowship of the ring",
                Overview = "A ring with mysterious powers lands in the hands of a young hobbit, Frodo. Under the guidance of Gandalf, a wizard, he and his three friends set out on a journey and land in the Elvish kingdom.",
                Popularity = 6302.243f,
                VoteCount = 1856,
                VoteAverage = 8,
                OriginalLanguage = "en",
                Genres = "Action, Fantasy",
                PosterUrl = "https://fakeurl.com"
            },
            new ()
            {
                ReleaseDate = new DateTime(2002, 12, 11),
                Title = "The lord of the rings: The two towers",
                Overview = "Frodo and Sam arrive in Mordor with the help of Gollum. A number of new allies join their former companions to defend Isengard as Saruman launches an assault from his domain.",
                Popularity = 6302.243f,
                VoteCount = 1856,
                VoteAverage = 8,
                OriginalLanguage = "en",
                Genres = "Action, Fantasy",
                PosterUrl = "https://fakeurl.com"
            }
        };

        // act
        var resultsBefore = await _movieService.GetPaginatedAsync(request);
        
        await _movieService.AddRangeAsync(newMovies);

        var resultsAfter = await _movieService.GetPaginatedAsync(request);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(resultsBefore.TotalResults, Is.EqualTo(0));
            Assert.That(resultsAfter.TotalResults, Is.EqualTo(newMovies.Count));
        });
    }

    [Test]
    public async Task GetPaginatedAsync_GenreFilterReturnsExpected()
    {
        // arrange
        var genreFilter = "Action";
        var request = new PaginationRequest
        {
            Page = 1,
            PageSize = 20,
            SortBy = MovieSortableFields.ReleaseDate,
            OrderBy = OrderBy.Ascending,
            GenreFilter = genreFilter
        };
        var actionMovies = Movies.SeedData.Where(x => x.Genres.Contains(genreFilter));
        
        // act
        var paginatedResult = await _movieService.GetPaginatedAsync(request);

        // asset
        Assert.Multiple(() =>
        {
            Assert.That(actionMovies.Count(), Is.EqualTo(paginatedResult.Results.Count()));
        });
    }

    [Test]
    public async Task GetPaginatedAsync_PaginationResultReturnsExpected()
    {
        // arrange
        var request = new PaginationRequest
        {
            Page = 2,
            PageSize = 5,
            SortBy = MovieSortableFields.ReleaseDate,
            OrderBy = OrderBy.Ascending
        };
        var movies = Movies.SeedData.OrderBy(x => x.ReleaseDate);
        var pageTwoMovies = movies.Skip(request.PageSize * (request.Page - 1)).Take(request.PageSize).ToArray();
        
        // act
        var paginatedResult = await _movieService.GetPaginatedAsync(request);
        var searchResults = paginatedResult.Results.ToArray();

        // asset
        Assert.Multiple(() =>
        {
            Assert.That(paginatedResult.TotalResults, Is.EqualTo(20));
            Assert.That(paginatedResult.CurrentPage, Is.EqualTo(2));
            Assert.That(paginatedResult.TotalPages, Is.EqualTo(4));
            
            Assert.That(searchResults[0].Title, Is.EqualTo(pageTwoMovies[0].Title));
            Assert.That(searchResults[1].Title, Is.EqualTo(pageTwoMovies[1].Title));
            Assert.That(searchResults[2].Title, Is.EqualTo(pageTwoMovies[2].Title));
            Assert.That(searchResults[3].Title, Is.EqualTo(pageTwoMovies[3].Title));
            Assert.That(searchResults[4].Title, Is.EqualTo(pageTwoMovies[4].Title));
        });
    }
}