using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace UserProfile.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        string returnUrl = Request.Query["returnUrl"];
        if (!String.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return Page();
    }
}