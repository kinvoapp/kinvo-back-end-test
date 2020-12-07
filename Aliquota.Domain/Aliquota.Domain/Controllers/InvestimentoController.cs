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
    public class InvestimentoController : Controller
    {
        private readonly AliquotaDomainContext _context;

        public InvestimentoController(AliquotaDomainContext context)
        {
            _context = context;
        }

        // GET: Investimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investimento.ToListAsync());
        }

        // GET: Investimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (investimento == null)
            {
                return NotFound();
            }

            return View(investimento);
        }

        // GET: Investimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Valor_inicio,Valor_final,Dt_entrada,Dt_saida")] Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investimento);
        }

        // GET: Investimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento.FindAsync(id);
            if (investimento == null)
            {
                return NotFound();
            }
            return View(investimento);
        }

        // POST: Investimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Valor_inicio,Valor_final,Dt_entrada,Dt_saida")] Investimento investimento)
        {
            if (id != investimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestimentoExists(investimento.ID))
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
            return View(investimento);
        }

        // GET: Investimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (investimento == null)
            {
                return NotFound();
            }

            return View(investimento);
        }

        // POST: Investimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investimento = await _context.Investimento.FindAsync(id);
            _context.Investimento.Remove(investimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestimentoExists(int id)
        {
            return _context.Investimento.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Resgate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investimento = await _context.Investimento.FindAsync(id);
            if (investimento == null)
            {
                return NotFound();
            }
            return View(investimento);
        }

        // POST: Investimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resgate(int id, [Bind("ID,Nome,Valor_inicio,Valor_final,Dt_entrada,Dt_saida")] Investimento investimento)
        {
            if (id != investimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestimentoExists(investimento.ID))
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
            return View(investimento);
        }

    }
}
