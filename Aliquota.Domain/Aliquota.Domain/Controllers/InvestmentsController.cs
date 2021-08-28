using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

        public IActionResult ViewInvestments()
        {
            var investments = _aliquotaContext.Investment.ToList().OrderBy(x => x.DayOfInvestment);
            return View(investments);
        }
        public async Task<IActionResult> ViewInvestmentDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Sorry, investment not found, please try again." });
            }
            if (!(await _aliquotaContext.Investment.AnyAsync(x => x.Id == id)))
            {
                return RedirectToAction(nameof(Error), new { message = "Sorry, investment not found, please try again." });
            }
            var obj = await _aliquotaContext.Investment.FirstOrDefaultAsync(x => x.Id == id);
            if(obj == null)
            {
                return RedirectToAction(nameof(ViewInvestments));
            }
            return View(obj);
        }

        public async Task<IActionResult> RemoveInvestment(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Sorry, investment not found, please try again." });
            }
            if (!(await _aliquotaContext.Investment.AnyAsync(x => x.Id == id)))
            {
                return RedirectToAction(nameof(Error), new { message = "Sorry, investment not found, please try again." });
            }
            var obj = await _aliquotaContext.Investment.FirstOrDefaultAsync(x => x.Id == id);
            if (obj == null)
            {
                return RedirectToAction(nameof(ViewInvestments));
            }
            return View(obj);
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
            return RedirectToAction(nameof(ViewInvestments));
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel() { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}
