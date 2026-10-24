using Microsoft.AspNetCore.Mvc;
using FeedbackManagementDemo.Models;
using FeedbackManagementDemo.Services;

namespace FeedbackManagementDemo.Controllers;

public class FeedbackController : Controller
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    // GET: /Feedback or /Feedback/Index
    public IActionResult Index()
    {
        var feedbacks = _feedbackService.GetAllFeedbacks();
        return View(feedbacks);
    }

    // GET: /Feedback/Create
    public IActionResult Create()
    {
        return View(new Feedback());
    }

    // POST: /Feedback/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Feedback feedback)
    {
        if (!ModelState.IsValid)
        {
            return View(feedback);
        }

        _feedbackService.AddFeedback(feedback);
        TempData["Success"] = "Feedback submitted successfully!";
        return RedirectToAction(nameof(Index));
    }
}
