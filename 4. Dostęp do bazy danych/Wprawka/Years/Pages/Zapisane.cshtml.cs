using Years.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Years.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<User> Users;

        public const string SessionKeyUsers = "_Users";

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString(SessionKeyUsers);
            if (Data != null)
                Users =
                JsonConvert.DeserializeObject<List<User>>(Data);
        }
    }
}