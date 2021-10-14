using Aliquota.BusinessLogic.Models;
using FrameworksAndDrivers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Aliquota.Website.Pages.Authenticate
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public DatabaseDriver db = new DatabaseDriver();

        public void OnGet()
        {
            if(user == null) user = new User();
            user.Name = "";
        }
        public IActionResult OnPost()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (!ModelState.IsValid)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("post");
            Console.ForegroundColor = ConsoleColor.Gray;
           return Page();
            //db.AddUser(user);
            //return RedirectToPage("/Index");
        }
    }
}
