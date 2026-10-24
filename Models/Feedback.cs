using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagementDemo.Models;

public class Feedback
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Student name is required.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Student name must be between 2 and 60 characters.")]
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Subject is required.")]
    [StringLength(80, ErrorMessage = "Subject cannot exceed 80 characters.")]
    [Display(Name = "Subject")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rating is required.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    [Display(Name = "Rating (1 to 5)")]
    public int? Rating { get; set; }

    [Required(ErrorMessage = "Comments are required.")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Comments must be between 10 and 500 characters.")]
    [Display(Name = "Comments")]
    public string Comments { get; set; } = string.Empty;

    [Display(Name = "Submitted At")]
    public DateTime SubmittedAt { get; set; } = DateTime.Now;
}
