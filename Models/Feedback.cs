using System.ComponentModel.DataAnnotations;

namespace FeedbackManagementDemo.Models;

public class Feedback
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 60 characters.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a feedback category.")]
    [Display(Name = "Category")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rating is required.")]
    [Range(1, 5, ErrorMessage = "Rating must be an integer between 1 and 5.")]
    [Display(Name = "Rating (1 to 5)")]
    public int? Rating { get; set; }

    [Required(ErrorMessage = "Comments are required.")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Comments must be between 10 and 500 characters.")]
    [Display(Name = "Comments / Suggestions")]
    public string Comments { get; set; } = string.Empty;

    [Display(Name = "Subscribe to response updates")]
    public bool SubscribeToUpdates { get; set; }

    [Display(Name = "Submitted Date")]
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
