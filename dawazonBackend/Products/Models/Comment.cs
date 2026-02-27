using System.ComponentModel.DataAnnotations;

namespace dawazonBackend.Products.Models;

public class Comment
{
    [Required]
    public int UserId { get; set; }
    [Required]
    [MaxLength(200)]
    [MinLength(2)]
    public string Content { get; set; }= string.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public bool verified { get; set; } = false;
    [Required]
    public bool recommended { get; set; } = false;
}