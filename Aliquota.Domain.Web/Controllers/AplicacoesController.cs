using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain;
using Aliquota.Domain.Web.Data;

namespace Aliquota.Domain.Web.Controllers
{
    public class AplicacoesController : Controller
    {
        private readonly AplicacaoDbContext _context;

        public AplicacoesController(AplicacaoDbContext context)
        {
            _context = context;
        }

        // GET: Aplicacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aplicacao.ToListAsync());
        }

        // GET: Aplicacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacao = await _context.Aplicacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicacao == null)
            {
                return NotFound();
            }

            return View(aplicacao);
        }

        // GET: Aplicacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aplicacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAplicacao,DataResgate,QuantiaInicial,QuantiaFinal,Lucro,Juros,ValorFinalDeduzidoINSS")] Aplicacao aplicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aplicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aplicacao);
        }

        // GET: Aplicacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacao = await _context.Aplicacao.FindAsync(id);
            if (aplicacao == null)
            {
                return NotFound();
            }
            return View(aplicacao);
        }

        // POST: Aplicacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataAplicacao,DataResgate,QuantiaInicial,QuantiaFinal,Lucro,Juros,ValorFinalDeduzidoINSS")] Aplicacao aplicacao)
        {
            if (id != aplicacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aplicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicacaoExists(aplicacao.Id))
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
            return View(aplicacao);
        }

        // GET: Aplicacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacao = await _context.Aplicacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicacao == null)
            {
                return NotFound();
            }

            return View(aplicacao);
        }

        // POST: Aplicacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplicacao = await _context.Aplicacao.FindAsync(id);
            _context.Aplicacao.Remove(aplicacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplicacaoExists(int id)
        {
            return _context.Aplicacao.Any(e => e.Id == id);
        }
    }
}
