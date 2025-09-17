using System;
using System.ComponentModel.DataAnnotations;

namespace Task5.Models;

public class User
{
    [Key]
    public Guid UserID { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;
    
    public bool IsActive { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    
    public DateTime? LastLoginDate { get; set; }
    
    [MaxLength(500)]
    public string? AvatarURL { get; set; }
}