using Years.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Years.Data;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Result { get; set; }

    [BindProperty]
    public User User { get; set; }

    [BindProperty]
    public List<User> Users { get; set; }

    private readonly PeopleContext _context;

    public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
    {
        _logger = logger;
        _context = context;
    }

    public const string SessionKeyUsers = "_Users";
    public IActionResult OnPost()
    {
        var Data = HttpContext.Session.GetString(SessionKeyUsers);
        if (Data != null)
            Users =
            JsonConvert.DeserializeObject<List<User>>(Data);

        if (ModelState.IsValid)
        {
            if (Users == null)
                Users = new List<User>();

            Result = $"{User.Name} urodził się w {User.Year} roku. ";
            if (User.IsLeapYear())
                Result += "To był rok przestępny.";
            else
                Result += "To nie był rok przestępny.";

            if (User.Surname != null)
            {
                User.Result = User.IsLeapYear();
                User.CreatedTime = DateTime.Now;

                _context.User.Add(User);
                _context.SaveChanges();
            }

            Users.Add(User);

            HttpContext.Session.SetString(SessionKeyUsers,
            JsonConvert.SerializeObject(Users));
        }

        return Page();
    }
}
