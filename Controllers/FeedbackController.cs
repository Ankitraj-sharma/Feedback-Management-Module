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

    // GET: /Feedback
    public IActionResult Index()
    {
        var model = new FeedbackListViewModel
        {
            Feedbacks = _feedbackService.GetAllFeedbacks(),
            Summary = _feedbackService.GetSummary()
        };
        return View(model);
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
        // Demonstration of MVC Model Validation
        if (!ModelState.IsValid)
        {
            return View(feedback);
        }

        _feedbackService.AddFeedback(feedback);
        TempData["SuccessMessage"] = "Thank you! Your feedback has been recorded successfully.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Feedback/Details/5
    public IActionResult Details(int id)
    {
        var feedback = _feedbackService.GetFeedbackById(id);
        if (feedback == null)
        {
            return NotFound();
        }
        return View(feedback);
    }
}
