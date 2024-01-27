using System.ComponentModel.DataAnnotations;

namespace MovieApi.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedExtensionsAttribute(string[] extensions)
    {
        _extensions = extensions;
    }
    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                throw new BadHttpRequestException($"Only the following file types are allowed: {string.Join(", ", _extensions)}");
            }
        }

        return ValidationResult.Success;
    }
}