using System;
using System.ComponentModel.DataAnnotations;

namespace Task5.Models;

public class Genre
{
    [Key]
    public Guid GenreID { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string GenreName { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime CreatedDate { get; set; }
}