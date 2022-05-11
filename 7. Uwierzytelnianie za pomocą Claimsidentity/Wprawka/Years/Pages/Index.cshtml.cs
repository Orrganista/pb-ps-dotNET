using Years.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Years.Data;
using Years.Interfaces;
using Years.ViewModels.User;
using Microsoft.AspNetCore.Identity;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUserService _userService;

    private readonly UserManager<IdentityUser> _userManager;

    public ListUserViewModel Records { get; set; }
    public string Result { get; set; }

    [BindProperty]
    public User User { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IUserService userService, 
        UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userService = userService;
        _userManager = userManager;
    }

    public void OnGet()
    {
        Records = _userService.GetTodayPeople();
    }

    public async Task<IActionResult> OnPostAsync()
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
                User.OwnerId = _userManager.GetUserId(HttpContext.User);

                _userService.Insert(User);  
            }
        }
        Records = _userService.GetTodayPeople();

        return Page();
    }
}
