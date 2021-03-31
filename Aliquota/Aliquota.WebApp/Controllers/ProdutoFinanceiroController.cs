using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Models;
using Aliquota.Domain.Negocio.Interfaces;
using Aliquota.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.WebApp.Controllers
{
    public class ProdutoFinanceiroController : Controller
    {
        IProdutoService _produtoService;

        public ProdutoFinanceiroController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: ProdutoFinanceiroController
        public async Task<ActionResult> Index()
        {
            var produtos = await _produtoService.List();
            var produtosViewModel = produtos.Select(x => new ProdutoFinanceiroViewModel() { Id = x.Id, Nome = x.Nome, Cotacao = x.Cotacao });

            return View(produtosViewModel);
        }

        // GET: ProdutoFinanceiroController/Details/5
        public ActionResult Details(Guid id)
        {
            var produto = _produtoService.Find(id).Result;

            var model = new ProdutoFinanceiroViewModel() { Id = produto.Id, Nome = produto.Nome, Cotacao = produto.Cotacao };
            return View(model);
        }

        // GET: ProdutoFinanceiroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoFinanceiroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoFinanceiroViewModel model)
        {
            try
            {
                ProdutoFinanceiro produto = new ProdutoFinanceiro()
                {
                    Nome = model.Nome
                    , Cotacao = model.Cotacao
                };

                _produtoService.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoFinanceiroController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var produto = _produtoService.Find(id).Result;

            var model = new ProdutoFinanceiroViewModel() { Id = produto.Id, Nome = produto.Nome, Cotacao = produto.Cotacao };
            return View(model);
        }

        // POST: ProdutoFinanceiroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ProdutoFinanceiroViewModel model)
        {
            try
            {
                _produtoService.Edit(model.ConvertToModel());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoFinanceiroController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var produto = _produtoService.Find(id).Result;

            var model = new ProdutoFinanceiroViewModel() { Id = produto.Id, Nome = produto.Nome, Cotacao = produto.Cotacao };
            return View(model);
        }

        // POST: ProdutoFinanceiroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var produto = _produtoService.Find(id).Result;
                _produtoService.Remove(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
