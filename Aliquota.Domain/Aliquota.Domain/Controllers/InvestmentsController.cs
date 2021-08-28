using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Data;
using Aliquota.Domain.Models;

namespace Aliquota.Domain.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly AliquotaDomainContext _aliquotaContext;
        public InvestmentsController(AliquotaDomainContext context)
        {
            _aliquotaContext = context;
        }
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Add()
        {
            var newFund = new Investment();
            return View(newFund);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvestmentDB(Investment vest)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Add));
            }
            ViewData["ErrorAmount"] = null;
            await _aliquotaContext.AddAsync(vest);
            await _aliquotaContext.SaveChangesAsync();
            return RedirectToAction(nameof(Add));
        }
    }
}
