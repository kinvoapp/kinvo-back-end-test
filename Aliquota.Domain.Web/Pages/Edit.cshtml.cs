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
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Application application { get; set; }

        public EditModel(ILogger<EditModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet(int? Id)
        {
            var query = _context.Applications.Find(Id);
            if (query == null)
                return NotFound();

            application = query;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return new UnprocessableEntityResult();

            application.OnNewEntry();
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
