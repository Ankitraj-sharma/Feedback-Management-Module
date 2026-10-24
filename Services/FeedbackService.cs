using FeedbackManagementDemo.Models;

namespace FeedbackManagementDemo.Services;

public interface IFeedbackService
{
    List<Feedback> GetAllFeedbacks();
    Feedback? GetFeedbackById(int id);
    void AddFeedback(Feedback feedback);
}

public class FeedbackService : IFeedbackService
{
    private static readonly List<Feedback> _feedbacks = new()
    {
        new Feedback
        {
            Id = 1,
            StudentName = "Jane Doe",
            Email = "jane.doe@example.com",
            Subject = "ASP.NET MVC Architecture",
            Rating = 5,
            Comments = "Excellent explanation of Layouts, Partial Views and model validation flow.",
            SubmittedAt = DateTime.Now.AddDays(-1)
        },
        new Feedback
        {
            Id = 2,
            StudentName = "John Smith",
            Email = "john.smith@example.com",
            Subject = "C# Model Binding & Validation",
            Rating = 4,
            Comments = "Clear practical implementation of DataAnnotations and ModelState verification.",
            SubmittedAt = DateTime.Now.AddHours(-3)
        }
    };

    private static readonly object _lock = new();

    public List<Feedback> GetAllFeedbacks()
    {
        lock (_lock)
        {
            return _feedbacks.OrderByDescending(f => f.Id).ToList();
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
            feedback.SubmittedAt = DateTime.Now;
            _feedbacks.Add(feedback);
        }
    }
}
