using System.ComponentModel.DataAnnotations;
using MovieApi.Attributes;

namespace MovieApi.Models;

public record CsvFileUpload
{
    [Required(ErrorMessage = "No CSV added to request")]
    [AllowedExtensions(new[] { ".csv" })]
    [DataType(DataType.Upload)]
    public IFormFile CsvFile { get; set; }
}