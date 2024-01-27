namespace MovieApi.Models;

public record UploadResponse
{
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}