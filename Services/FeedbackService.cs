using FeedbackManagementDemo.Models;

namespace FeedbackManagementDemo.Services;

public interface IFeedbackService
{
    List<Feedback> GetAllFeedbacks();
    Feedback? GetFeedbackById(int id);
    void AddFeedback(Feedback feedback);
    FeedbackSummaryViewModel GetSummary();
}

public class FeedbackService : IFeedbackService
{
    private static readonly List<Feedback> _feedbacks = new()
    {
        new Feedback
        {
            Id = 1,
            FullName = "Jane Doe",
            Email = "jane.doe@example.com",
            Category = "Feature Request",
            Rating = 5,
            Comments = "Would love to see an automated dark mode toggle in the next release.",
            SubscribeToUpdates = true,
            SubmittedAt = DateTime.UtcNow.AddDays(-2)
        },
        new Feedback
        {
            Id = 2,
            FullName = "John Smith",
            Email = "john.smith@example.com",
            Category = "Bug Report",
            Rating = 3,
            Comments = "Encountered a minor validation glitch when submitting with certain special characters.",
            SubscribeToUpdates = false,
            SubmittedAt = DateTime.UtcNow.AddDays(-1)
        },
        new Feedback
        {
            Id = 3,
            FullName = "Alice Johnson",
            Email = "alice.j@example.com",
            Category = "General",
            Rating = 4,
            Comments = "The application navigation is very intuitive and responsive. Good work!",
            SubscribeToUpdates = true,
            SubmittedAt = DateTime.UtcNow.AddHours(-5)
        }
    };

    private static readonly object _lock = new();

    public List<Feedback> GetAllFeedbacks()
    {
        lock (_lock)
        {
            return _feedbacks.OrderByDescending(f => f.SubmittedAt).ToList();
        }
    }

    public Feedback? GetFeedbackById(int id)
    {
        lock (_lock)
        {
            return _feedbacks.FirstOrDefault(f => f.Id == id);
        }
    }

    public void AddFeedback(Feedback feedback)
    {
        lock (_lock)
        {
            feedback.Id = _feedbacks.Count > 0 ? _feedbacks.Max(f => f.Id) + 1 : 1;
            feedback.SubmittedAt = DateTime.UtcNow;
            _feedbacks.Add(feedback);
        }
    }

    public FeedbackSummaryViewModel GetSummary()
    {
        lock (_lock)
        {
            int total = _feedbacks.Count;
            double avg = total > 0 ? Math.Round(_feedbacks.Average(f => f.Rating ?? 0), 1) : 0;
            int bugs = _feedbacks.Count(f => f.Category == "Bug Report");
            int features = _feedbacks.Count(f => f.Category == "Feature Request");
            int general = _feedbacks.Count(f => f.Category == "General");

            return new FeedbackSummaryViewModel
            {
                TotalFeedbacks = total,
                AverageRating = avg,
                BugReportsCount = bugs,
                FeatureRequestsCount = features,
                GeneralFeedbackCount = general
            };
        }
    }
}
