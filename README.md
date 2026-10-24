# Practical 7 - Feedback Management Module

**AIM:** Develop Feedback Management Module using MVC Layout, Partial View & Validation (HTML Helpers, Validation, Layouts).

**Student:** Ankit raj sharma

**Live Demo (GitHub Pages):** [https://ankitraj-sharma.github.io/Feedback-Management-Module/](https://ankitraj-sharma.github.io/Feedback-Management-Module/)

---

## Features Demonstrated

- **No CSS Requirement:** Built strictly using unstyled, standard semantic HTML elements (`<form>`, `<fieldset>`, `<legend>`, `<input>`, `<select>`, `<textarea>`, `<button>`) for pure demonstration purposes.
- **Model & Validation:** Data Annotations in `Feedback.cs` for required fields, string length, email address format, and rating range (`1` to `5`).
- **Controller:** GET/POST actions, `ModelState.IsValid` verification, anti-forgery token, and redirect after successful POST.
- **MVC Layout:** `_Layout.cshtml` provides shared header navigation and footer across all views.
- **Partial View:** `_FeedbackCard.cshtml` renders each submitted feedback item as a reusable card component.
- **Live Interactive Demo:** Hosted on GitHub Pages via `/docs/index.html` allowing immediate live browser testing.

---

## Project Structure

```text
Feedback-Management-Module/
├── Controllers/
│   ├── FeedbackController.cs       # GET/POST actions with ModelState.IsValid
│   └── HomeController.cs
├── Models/
│   ├── Feedback.cs                 # Feedback model with validation data annotations
│   └── ErrorViewModel.cs
├── Services/
│   └── FeedbackService.cs          # In-memory thread-safe feedback repository
├── Views/
│   ├── Feedback/
│   │   ├── Create.cshtml           # Feedback submission form with validation helpers
│   │   └── Index.cshtml            # All feedback list using partial view
│   ├── Shared/
│   │   ├── _FeedbackCard.cshtml    # Partial view for individual feedback item
│   │   ├── _Layout.cshtml          # Master MVC layout (no CSS)
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── docs/
│   └── index.html                  # Interactive live GitHub Pages demo
├── Program.cs                      # Entry point and DI service registration
└── FeedbackManagementDemo.csproj
```

---

## Run Locally (.NET)

```bash
cd FeedbackManagementDemo
dotnet run
```
Open `http://localhost:5000/` or `https://localhost:5001/` in your browser.
