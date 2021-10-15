using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Models;

namespace ProjetoMVC.Controllers
{
    public class RescuesController : Controller
    {
        private readonly Context _context;

        public RescuesController(Context context)
        {
            _context = context;
        }

        // GET: Rescues
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rescues.ToListAsync());
        }

        // GET: Rescues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rescue = await _context.Rescues
                .FirstOrDefaultAsync(m => m.RescueId == id);
            if (rescue == null)
            {
                return NotFound();
            }

            return View(rescue);
        }

        // GET: Rescues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rescues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RescueId,ApplicationDate,ApplicationRescue,ApplicationValue,GrossValue,Income,Ir,Profit,LiquidValue")] Rescue rescue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rescue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rescue);
        }

        // GET: Rescues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rescue = await _context.Rescues.FindAsync(id);
            if (rescue == null)
            {
                return NotFound();
            }
            return View(rescue);
        }

        // POST: Rescues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RescueId,ApplicationDate,ApplicationRescue,ApplicationValue,GrossValue,Income,Ir,Profit,LiquidValue")] Rescue rescue)
        {
            if (id != rescue.RescueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rescue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RescueExists(rescue.RescueId))
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
            return View(rescue);
        }

        // GET: Rescues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rescue = await _context.Rescues
                .FirstOrDefaultAsync(m => m.RescueId == id);
            if (rescue == null)
            {
                return NotFound();
            }

            return View(rescue);
        }

        // POST: Rescues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rescue = await _context.Rescues.FindAsync(id);
            _context.Rescues.Remove(rescue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RescueExists(int id)
        {
            return _context.Rescues.Any(e => e.RescueId == id);
        }
    }
}
