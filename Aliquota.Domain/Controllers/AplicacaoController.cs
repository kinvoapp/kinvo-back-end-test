using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Contexto;
using Aliquota.Domain.Models;
using Aliquota.Domain.Business;
using System.Globalization;

namespace Aliquota.Domain.Controllers
{
    public class AplicacaoController : Controller
    {
        private readonly AplicacaoContext _context;

        public AplicacaoController(AplicacaoContext context)
        {
            _context = context;
        }

        // GET: Aplicacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aplicacao.ToListAsync());
        }

        // GET: Aplicacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacaoModel = await _context.Aplicacao
                .FirstOrDefaultAsync(m => m.AplicacaoId == id);
            if (aplicacaoModel == null)
            {
                return NotFound();
            }

            return View(aplicacaoModel);
        }

        // GET: Aplicacao/Create
        public IActionResult Create()
        {
            AplicacaoModel Aplicacao = new AplicacaoModel();
            Aplicacao.DataAplicada = DateTime.Now;
            return View(Aplicacao);
        }

        // POST: Aplicacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AplicacaoId,ValorInicial,DataAplicada,DataRetirada,ValorFinalBruto,ValorImpostoRenda,ValorLucroLiquido")] AplicacaoModel aplicacaoModel)
        {
            if (ModelState.IsValid)
            {
                //SalvaAplicacao(aplicacaoModel);
                _context.Add(aplicacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aplicacaoModel);
        }

        // GET: Aplicacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacaoModel = await _context.Aplicacao.FindAsync(id);
            if (aplicacaoModel == null)
            {
                return NotFound();
            }
            aplicacaoModel.DataRetirada = DateTime.Now;
            return View(aplicacaoModel);
        }

        // POST: Aplicacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AplicacaoId,ValorInicial,DataAplicada,DataRetirada,ValorFinalBruto,ValorImpostoRenda,ValorLucroLiquido")] AplicacaoModel aplicacaoModel)
        {
            if (id != aplicacaoModel.AplicacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(GetAplicacaoCalculada(aplicacaoModel));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicacaoModelExists(aplicacaoModel.AplicacaoId))
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
            return View(aplicacaoModel);
        }

        // GET: Aplicacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicacaoModel = await _context.Aplicacao
                .FirstOrDefaultAsync(m => m.AplicacaoId == id);
            if (aplicacaoModel == null)
            {
                return NotFound();
            }

            return View(aplicacaoModel);
        }

        // POST: Aplicacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplicacaoModel = await _context.Aplicacao.FindAsync(id);
            _context.Aplicacao.Remove(aplicacaoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplicacaoModelExists(int id)
        {
            return _context.Aplicacao.Any(e => e.AplicacaoId == id);
        }

        private AplicacaoModel GetAplicacaoCalculada(AplicacaoModel aplicacao)
        {
            decimal lucroBruto;
            AplicacaoModel aplicacaoCalculada = aplicacao;
            CalculaAplicacao calculaAplicacao = new CalculaAplicacao();
            
            lucroBruto = calculaAplicacao.CalculaLucroBruto(aplicacao.ValorInicial, (decimal)aplicacao.ValorFinalBruto);
            aplicacaoCalculada.ValorImpostoRenda = calculaAplicacao.CalculaImpostoRenda(aplicacao.DataAplicada, (DateTime)aplicacao.DataRetirada, lucroBruto);
            aplicacaoCalculada.ValorLucroLiquido = calculaAplicacao.CalculaLucroLiquido((decimal)aplicacao.ValorImpostoRenda, lucroBruto);

            return aplicacaoCalculada;
        }

    }
}
