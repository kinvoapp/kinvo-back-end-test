using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Data;
using Aliquota.Domain.Models;

namespace Aliquota.Domain.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly AliquotaDomainContext _context;

        public InvestmentsController(AliquotaDomainContext context)
        {
            _context = context;
        }

        // GET: Investments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investment.ToListAsync());
        }

        // GET: Investments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // GET: Investments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvestorName,DayOfInvestment,InitialAmount")] Investment investment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investment);
        }

        // GET: Investments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investment.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }
            return View(investment);
        }

        // POST: Investments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvestorName,DayOfInvestment,InitialAmount")] Investment investment)
        {
            if (id != investment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentExists(investment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(investment);
        }

        // GET: Investments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investment == null)
            {
                return NotFound();
            }

            return View(investment);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investment = await _context.Investment.FindAsync(id);
            _context.Investment.Remove(investment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentExists(int id)
        {
            return _context.Investment.Any(e => e.Id == id);
        }
    }
}
