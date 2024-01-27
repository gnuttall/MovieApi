using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.Entities.Common;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
    }
    
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}