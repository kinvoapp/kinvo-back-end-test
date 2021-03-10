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
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly ApplicationDbContext _context;
        public Application application;

        public DeleteModel(ILogger<DeleteModel> logger, ApplicationDbContext context)
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
        
        public async Task<IActionResult> OnPost(int? Id)
        {
            var query = _context.Applications.Find(Id);
            if (query == null)
                return NotFound();

            _context.Remove(query);
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
