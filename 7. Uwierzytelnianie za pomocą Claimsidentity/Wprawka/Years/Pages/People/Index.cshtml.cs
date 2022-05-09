#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Years.Data;
using Years.Models;

namespace Years.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly Years.Data.PeopleContext _context;

        public IndexModel(Years.Data.PeopleContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
