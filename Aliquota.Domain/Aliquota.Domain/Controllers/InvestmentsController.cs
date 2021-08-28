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
                return RedirectToAction(nameof(Error), new { message = "This investment doesn't exist, please try again." });
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
                return RedirectToAction(nameof(Error), new { message = "This investment doesn't exist, please try again." });
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
            DateTime day = new DateTime();
            day = DateTime.Now;
            ViewModelRemove viewModel = new ViewModelRemove(obj, day);
            return View(viewModel);
        }

        public async Task<IActionResult> ConfirmRemove(ViewModelRemove viewExample)
        {
            int? id;
            id = viewExample.ActualInvestment.Id;
            DateTime dateSimulate = viewExample.ActualDate;

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "This investment doesn't exist, please try again." });
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
            if (dateSimulate < obj.DayOfInvestment)
            {
                return RedirectToAction(nameof(Error), new { message = "The simulated day cannot be lower than the day of investment, please, retry with a date equals or higher" });
            }
            ViewModelRemove viewModel = new ViewModelRemove(obj, dateSimulate);
            return View(viewModel);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvestmentDB(Investment vest)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Add));
            }
            await _aliquotaContext.AddAsync(vest);
            await _aliquotaContext.SaveChangesAsync();
            return RedirectToAction(nameof(ViewInvestments));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DefinitiveRemove(ViewModelRemove viewModel)
        {
            var obj = _aliquotaContext.Investment.FirstOrDefault(x => x.Id == viewModel.ActualInvestment.Id);
            _aliquotaContext.Investment.Remove(obj);
            _aliquotaContext.SaveChanges();
            return RedirectToAction(nameof(ViewInvestments));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel() { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}
