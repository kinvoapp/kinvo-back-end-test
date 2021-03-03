using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain;
using Aliquota.Domain.Data;

namespace Aliquota.Domain.Controllers
{
    public class AplicacoesController : Controller
    {
        private readonly AplicacaoDbContext _context;

        public AplicacoesController(AplicacaoDbContext context)
        {
            _context = context;
        }

        // GET: Aplicacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aplicacao.ToListAsync());
        }

        // GET: Aplicacoes/Details/5
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

        // GET: Aplicacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aplicacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAplicacao,DataResgate,QuantiaInicial,QuantiaFinal,Lucro,Juros,ValorFinalDeduzidoINSS")] Aplicacao aplicacao)
        {
            if (aplicacao.DataAplicacao > aplicacao.DataResgate)
            {

            }
            if (ModelState.IsValid)
            {
              
              aplicacao.Lucro = aplicacao.QuantiaFinal - aplicacao.QuantiaInicial;
              aplicacao.Juros = ImpostoRenda.CalculaTaxaJuros(aplicacao.DataAplicacao, aplicacao.DataResgate);
              decimal quantiaINSS = (aplicacao.Juros * aplicacao.Lucro) / 100;
              aplicacao.ValorFinalDeduzidoINSS = aplicacao.QuantiaFinal - quantiaINSS;
                      _context.Add(aplicacao);
                      await _context.SaveChangesAsync();
                      return RedirectToAction(nameof(Index));
            }
            return View(aplicacao);
        }

        // GET: Aplicacoes/Edit/5
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

        // POST: Aplicacoes/Edit/5
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

        // GET: Aplicacoes/Delete/5
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

        // POST: Aplicacoes/Delete/5
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
