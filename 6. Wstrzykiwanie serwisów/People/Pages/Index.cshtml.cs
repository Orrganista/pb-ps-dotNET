using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using People.Interfaces;
using People.ViewModels.Person;

namespace People.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        public ListPersonForListVM Records { get; set; }
        public IndexModel(ILogger<IndexModel> logger,
        IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetPeopleForList();
        }

    }
}