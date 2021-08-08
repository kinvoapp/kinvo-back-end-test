using Aliquota.Domain.Models;
using Aliquota.Domain.Servicos.TipoProdutoFinanceiroSv;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebApp.Controllers
{
    public class TipoProdutoFinanceiroController : Controller
    {
        private readonly ITipoProdutoFinanceiroServico _tipoProdutoFinanceiroServico;

        public TipoProdutoFinanceiroController(ITipoProdutoFinanceiroServico tipoProdutoFinanceiroServico)
        {
            _tipoProdutoFinanceiroServico = tipoProdutoFinanceiroServico;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipoProdutoFinanceiroServico.BuscarTodos());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            var tipoProdutoFinanceiro = await _tipoProdutoFinanceiroServico
                                            .BuscaTipoProdutoFinanceiroPor(id.Value);
            if (tipoProdutoFinanceiro == null) return NotFound();
            return View(tipoProdutoFinanceiro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,PorcentagemLucro")] TipoProdutoFinanceiro tipoProdutoFinanceiro)
        {
            if (ModelState.IsValid)
            {
                await _tipoProdutoFinanceiroServico.CadastraTipoProdutoFinanceiro(tipoProdutoFinanceiro);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProdutoFinanceiro);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();
            var tipoProdutoFinanceiro = await _tipoProdutoFinanceiroServico
                                            .BuscaTipoProdutoFinanceiroPor(id.Value);
            if (tipoProdutoFinanceiro == null) return NotFound();
            return View(tipoProdutoFinanceiro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,PorcentagemLucro")] TipoProdutoFinanceiro tipoProdutoFinanceiro)
        {
            if (id != tipoProdutoFinanceiro.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _tipoProdutoFinanceiroServico.AlteraTipoProdutoServico(tipoProdutoFinanceiro);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProdutoFinanceiro);
        }

        // GET: TipoProdutoFinanceiro/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var tipoProdutoFinanceiro = await _tipoProdutoFinanceiroServico
                                        .BuscaTipoProdutoFinanceiroPor(id.Value);
            if (tipoProdutoFinanceiro == null) return NotFound();
            return View(tipoProdutoFinanceiro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoProdutoFinanceiro = await _tipoProdutoFinanceiroServico
                                        .BuscaTipoProdutoFinanceiroPor(id);
            await _tipoProdutoFinanceiroServico.DeletaTipoProdutoFinanceiro(tipoProdutoFinanceiro);
            return RedirectToAction(nameof(Index));
        }
    }
}
