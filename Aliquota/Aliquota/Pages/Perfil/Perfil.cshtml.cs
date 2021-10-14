using Aliquota.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aliquota.Website.Pages.Perfil
{
    public class PerfilModel : PageModel
    {
        [BindProperty]
        public User user {  get; set; }
        public void OnGet()
        {
            user = new User();
            user.Name = "porra jao";

        }
    }
}
