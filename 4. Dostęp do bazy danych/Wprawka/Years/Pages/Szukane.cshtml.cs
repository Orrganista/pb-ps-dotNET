using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Years.Data;
using Years.Models;

namespace Years.Pages
{
    public class SzukaneModel : PageModel
    {

        private readonly PeopleContext _context;

        public SzukaneModel(PeopleContext context)
        {
            _context = context;
        }

        public IList<User> People { get; set; }
        public void OnGet()
        {
            People = _context.User.Take(20).OrderByDescending(u => u.CreatedTime).ToList();
        }
    }
}
