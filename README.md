# Feedback Management Module (ASP.NET Core MVC Demo)

A clean, lightweight demonstration of an **ASP.NET Core MVC** Feedback Management Module showcasing:
1. **MVC Layout** (`_Layout.cshtml`)
2. **Partial Views** (`_FeedbackSummaryPartial`, `_FeedbackItemRowPartial`, `_FeedbackDetailsPartial`, `_ValidationScriptsPartial`)
3. **Model Validation** (Data Annotations, Server-Side `ModelState.IsValid`, and Client-Side Unobtrusive Validation)
4. **No CSS / Pure HTML**: Built strictly with standard HTML elements (`<form>`, `<table>`, `<fieldset>`, `<input>`, `<select>`, `<textarea>`, `<button>`) without external CSS or frameworks for pure demonstration purposes.

---

## Key Features & Architecture

### 1. MVC Layout (`Views/Shared/_Layout.cshtml`)
- Implements a unified header, navigation bar, content injection point (`@RenderBody()`), and footer.
- No CSS files or styles are imported, providing an unstyled semantic baseline.
- Defines an optional script section (`@await RenderSectionAsync("Scripts", required: false)`) to load validation scripts only on views that require them.

### 2. Partial Views (`Views/Shared/`)
- `_FeedbackSummaryPartial.cshtml`: Reusable partial view that displays aggregate metrics (total feedback count, average rating, count by category).
- `_FeedbackItemRowPartial.cshtml`: Reusable row component for rendering feedback records inside the list table.
- `_FeedbackDetailsPartial.cshtml`: Reusable detail component displaying full submission attributes.
- `_ValidationScriptsPartial.cshtml`: Includes jQuery Validation and Unobtrusive Validation libraries for client-side evaluation.

### 3. Validation Implementation
- **Model Data Annotations (`Models/Feedback.cs`)**:
  - `FullName`: `[Required]`, `[StringLength(60, MinimumLength = 3)]`
  - `Email`: `[Required]`, `[EmailAddress]`
  - `Category`: `[Required]`
  - `Rating`: `[Required]`, `[Range(1, 5)]`
  - `Comments`: `[Required]`, `[StringLength(500, MinimumLength = 10)]`
- **Server-Side Validation**:
  - Checked in `FeedbackController.Create([HttpPost])` via `if (!ModelState.IsValid) { return View(feedback); }`.
- **Client-Side Validation**:
  - Rendered with Tag Helpers (`asp-for`, `asp-validation-for`, `asp-validation-summary`).

---

## Project Structure

```text
FeedbackManagementDemo/
├── Controllers/
│   ├── FeedbackController.cs       # Handles Index, Create (GET/POST), Details
│   └── HomeController.cs           # Home and overview
├── Models/
│   ├── Feedback.cs                 # Feedback entity with validation attributes
│   ├── FeedbackViewModels.cs       # Summary and list viewmodels
│   └── ErrorViewModel.cs
├── Services/
│   └── FeedbackService.cs          # In-memory thread-safe feedback repository
├── Views/
│   ├── Feedback/
│   │   ├── Create.cshtml           # Submission form with validation helpers
│   │   ├── Details.cshtml          # Details view using partial view
│   │   └── Index.cshtml            # List view using summary & row partial views
│   ├── Home/
│   │   ├── Index.cshtml            # Overview and quick navigation
│   │   └── Privacy.cshtml
│   └── Shared/
│       ├── _FeedbackDetailsPartial.cshtml
│       ├── _FeedbackItemRowPartial.cshtml
│       ├── _FeedbackSummaryPartial.cshtml
│       ├── _Layout.cshtml          # Master MVC layout (no CSS)
│       └── _ValidationScriptsPartial.cshtml
├── Program.cs                      # Application entry point and DI configuration
└── FeedbackManagementDemo.csproj
```

---

## How to Run Locally

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/)

### Running the Application
```bash
dotnet restore
dotnet run
```

Then open your browser to the URL displayed in the console (e.g. `http://localhost:5000` or `https://localhost:5001`).

---

## Pushing to GitHub

To push this project to your GitHub account:

```bash
# 1. Create a new empty repository on GitHub (e.g. feedback-management-mvc)
# 2. In your terminal inside the project folder:
git remote add origin https://github.com/<your-username>/<your-repo-name>.git
git branch -M main
git push -u origin main
```
