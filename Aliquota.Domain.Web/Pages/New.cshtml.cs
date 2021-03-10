using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Aliquota.Domain.Web.Pages
{
    public class NewModel : PageModel
    {
        private readonly ILogger<NewModel> _logger;
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Application application { get; set; }

        public NewModel(ILogger<NewModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return new UnprocessableEntityResult();
            
            application.OnNewEntry();
            _context.Add(application);
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
