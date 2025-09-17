using System;
using System.ComponentModel.DataAnnotations;

namespace Task5.Models;

public class Review
{
    [Key]
    public Guid ReviewID { get; set; }
    
    public Guid UserID { get; set; }
    
    public Guid AnimeID { get; set; }
    
    public decimal Rating { get; set; }
    
    public string? ReviewText { get; set; }
    
    public bool IsRecommended { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime? UpdatedDate { get; set; }
}