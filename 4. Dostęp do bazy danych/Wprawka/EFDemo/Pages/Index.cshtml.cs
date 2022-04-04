using EFDemo.Data;
using EFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly PeopleContext _context;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Person> People { get; set; }
        public void OnGet()
        {
            // People = _context.Person.Where(p => p.FirstName == "Robert").ToList();
            People = _context.Person.OrderBy(p => p.LastName).ToList();
        }

        [BindProperty]
        public Person Person { get; set; }
        public IActionResult OnPost()
        {
            People = _context.Person.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Person.Add(Person);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}