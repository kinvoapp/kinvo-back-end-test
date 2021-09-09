using Aliquota.Domain.Models;
using Aliquota.Domain.Repositories;
using Aliquota.Domain.WebApp.Views.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace Aliquota.Domain.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        // GET: ProdutoController
        public ActionResult Index()
        {
            var produtosList = produtoRepository.GetAll();
            return View(produtosList);
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var produtoNovo = GetProdutoByFormCollection(collection);
            
            if (ModelState.IsValid)
            {
                produtoRepository.Add(produtoNovo);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = this.produtoRepository.GetById(id);
            return View(produto);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Produto produtoNovo = GetProdutoByFormCollection(collection);

            if (ModelState.IsValid)
            {
                this.produtoRepository.Update(id, produtoNovo);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Edit), new { id });
        }

        //GET: ProdutoController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var produto = this.produtoRepository.GetById(id);
            var qtdInvestimento = produto.Investimentos.Count;

            var produtoDeleteViewModel = new ProdutoDeleteViewModel(produto, qtdInvestimento);

            return View(produtoDeleteViewModel);
        }

        //POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var produto = this.produtoRepository.GetById(id);
                this.produtoRepository.Delete(produto);
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Delete), new { id });
            }
        }

        private static Produto GetProdutoByFormCollection(IFormCollection collection)
        {
            var nome = collection[nameof(Produto.Nome)];
            var taxa = collection[nameof(Produto.TaxaRendimentoAnual)];

            var produtoNovo = new Produto(nome, double.Parse(taxa, CultureInfo.InvariantCulture));

            return produtoNovo;
        }
    }
}
