using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using MovieApi.Data.Entities;
using MovieApi.Models;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;

namespace MovieApi.Controllers;

/// <summary>
/// Provides methods to upload data
/// </summary>
public class UploadController : BaseApiController
{
    private readonly IMovieService _movieService;

    public UploadController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Upload csv file of movies to database
    /// </summary>
    /// <param name="upload"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Attempt<UploadResponse>> UploadMovies([FromForm] CsvFileUpload upload)
    {
        await using var stream = upload.CsvFile.OpenReadStream();
        var parser = new TextFieldParser(stream);
        parser.SetDelimiters(",");

        var movies = new List<Movie>();
        var errors = new List<string>();

        while (!parser.EndOfData)
        {
            var row = parser.ReadFields();
            if (row[0].Equals("Release_Date"))
                continue;

            try
            {
                movies.Add(new Movie
                {
                    ReleaseDate = DateTime.Parse(row[0]),
                    Title = row[1],
                    Overview = row[2],
                    Popularity = float.Parse(row[3]),
                    VoteCount = int.Parse(row[4]),
                    VoteAverage = float.Parse(row[5]),
                    OriginalLanguage = row[6],
                    Genres = row[7],
                    PosterUrl = row[8]
                });
            }
            catch (Exception ex)
            {
                errors.Add($"row '{string.Join(", ", row)}' failed to parse with {ex.Message}");
            }
        }

        await _movieService.AddRangeAsync(movies);

        var response = new UploadResponse
        {
            Message = $"{movies.Count} movies uploaded successfully",
            Errors = errors
        };

        return Attempt<UploadResponse>.Succeed(response);
    }
}