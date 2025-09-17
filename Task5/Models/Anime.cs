using System;
using System.ComponentModel.DataAnnotations;

namespace Task5.Models;

public class Anime
{
    [Key]
    public Guid AnimeID { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? OriginalTitle { get; set; }
    
    public string? Description { get; set; }
    
    public int EpisodeCount { get; set; }
    
    public decimal Duration { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public decimal? AverageRating { get; set; }
    
    public bool IsCompleted { get; set; }
    
    [MaxLength(500)]
    public string? PosterURL { get; set; }
    
    public DateTime CreatedDate { get; set; }
}