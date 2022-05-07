using Years.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Years.Data;
using Years.Interfaces;
using Years.ViewModels.User;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUserService _userService;

    public ListUserViewModel Records { get; set; }
    public string Result { get; set; }

    [BindProperty]
    public User User { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public void OnGet()
    {
        Records = _userService.GetTodayPeople();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            Result = $"{User.Name} urodził się w {User.Year} roku. ";
            if (User.IsLeapYear())
                Result += "To był rok przestępny.";
            else
                Result += "To nie był rok przestępny.";

            if (User.Surname != null)
            {
                User.Result = User.IsLeapYear();
                User.CreatedTime = DateTime.Now;

                _userService.Insert(User);  
            }
        }
        Records = _userService.GetTodayPeople();

        return Page();
    }
}
