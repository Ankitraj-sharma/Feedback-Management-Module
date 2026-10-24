namespace FeedbackManagementDemo.Models;

public class FeedbackSummaryViewModel
{
    public int TotalFeedbacks { get; set; }
    public double AverageRating { get; set; }
    public int BugReportsCount { get; set; }
    public int FeatureRequestsCount { get; set; }
    public int GeneralFeedbackCount { get; set; }
}

public class FeedbackListViewModel
{
    public FeedbackSummaryViewModel Summary { get; set; } = new();
    public List<Feedback> Feedbacks { get; set; } = new();
}
