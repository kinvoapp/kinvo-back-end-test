using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Models;
using Aliquota.Domain.Negocio.Interfaces;
using Aliquota.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aliquota.WebApp.Controllers
{
    public class AplicacaoController : Controller
    {
        IAplicacaoService _aplicacaoService;
        IProdutoService _produtoService;
        public AplicacaoController(IAplicacaoService aplicacaoService, IProdutoService produtoService)
        {
            _aplicacaoService = aplicacaoService;
            _produtoService = produtoService;
        }

        // GET: AplicacaoController
        public async Task<ActionResult> Index()
        {
            var aplicacoes = await _aplicacaoService.List();
            var aplicacoesViewModel = aplicacoes.Select(x => AplicacaoViewModelList.ConvertToModelView(x));

            return View(aplicacoesViewModel);
        }

        
        // GET: AplicacaoController/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = _produtoService.List().Result.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            return View();
        }

        // POST: AplicacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AplicacaoViewModel model)
        {
            try
            {
                model.ProdutoFinanceiro = _produtoService.Find(model.ProdutoFinanceiroId).Result;
                
                Aplicacao aplicacao = model.ConvertToModel();
                aplicacao.Quantidade = Math.Round(model.ValorAplicado / model.ProdutoFinanceiro.Cotacao, 3);
                _aplicacaoService.Add(aplicacao);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Produtos = _produtoService.List().Result.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

                return View();
            }
        }

        
        // GET: AplicacaoController/Delete/5
        public async Task<ActionResult> Resgatar(Guid id)
        {
            Aplicacao aplicacao = await _aplicacaoService.Find(id);
            var model = AplicacaoViewModelList.ConvertToModelView(aplicacao);
            ViewBag.Aliquota = _aplicacaoService.ObterAlicotaImposto(aplicacao, DateTime.Now);
            ViewBag.ImpostoAtual = _aplicacaoService.ObterImpostoARecolher(aplicacao, DateTime.Now);
            return View(model);
        }

        // POST: AplicacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Resgatar(AplicacaoViewModel model)
        {
            try
            {
                Aplicacao aplicacao = model.ConvertToModel();
                _aplicacaoService.Resgatar(aplicacao, DateTime.Now);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
