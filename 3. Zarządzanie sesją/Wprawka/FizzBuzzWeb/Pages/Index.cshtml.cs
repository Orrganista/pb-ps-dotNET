using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [BindProperty]
    public FizzBuzz FizzBuzz { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            Name = "User";
        }
    }

    // public IActionResult OnPost()
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return Page();
    //     }

    //     return RedirectToPage("./Privacy");
    // }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Data",
            JsonConvert.SerializeObject(FizzBuzz));
            return RedirectToPage("./SavedInSession");
        }
        return Page();
    }
}
