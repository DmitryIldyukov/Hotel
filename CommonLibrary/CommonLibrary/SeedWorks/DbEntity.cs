using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.SeedWorks;

public abstract class DbEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    [Required]
    public bool IsDeleted { get; set; }
}