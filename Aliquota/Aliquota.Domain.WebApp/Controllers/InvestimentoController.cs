using Aliquota.Domain.Models;
using Aliquota.Domain.Repositories;
using Aliquota.Domain.WebApp.Views.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Aliquota.Domain.WebApp.Models;
using System.Diagnostics;

namespace Aliquota.Domain.WebApp.Controllers
{
    public class InvestimentoController : Controller
    {
        private readonly IInvestimentoRepository investimentoRepository;
        private readonly IProdutoRepository produtoRepository;

        public InvestimentoController(IInvestimentoRepository investimentoRepository,
            IProdutoRepository produtoRepository)
        {
            this.investimentoRepository = investimentoRepository;
            this.produtoRepository = produtoRepository;
        }

        // GET: InvestimentoController
        public ActionResult Index() => View(this.investimentoRepository.GetAll());

        // GET: InvestimentoController/Details/5
        public ActionResult Details(int id)
        {
            var investimento = this.investimentoRepository.GetById(id); 
            var rendimento = new RendimentoInvest(investimento);

            return View(new InvestimentoDetailsViewModel(investimento, rendimento));
        }

        // GET: InvestimentoController/Create
        public ActionResult Create()
        {
            var produtosList = this.produtoRepository.GetAll();

            if (produtosList.Count == 0)
            {
                return RedirectToAction(nameof(Create), "Produto");
            }

            var InvestimentoViewModel = new InvestimentoViewModel(produtosList);
            return View(InvestimentoViewModel);
        }

        // POST: InvestimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var investimentoNovo = GetInvestimentoByFormCollection(collection);

                    if (investimentoNovo.DataInvestimento >= DateTime.Today)
                    {
                        return RedirectToAction(nameof(Create));
                    }

                    this.investimentoRepository.Add(investimentoNovo);
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: InvestimentoController/Edit/5
        public ActionResult Edit(int id)
        {
            var produtosList = this.produtoRepository.GetAll();
            var investimento = this.investimentoRepository.GetById(id);

            InvestimentoViewModel investimentoViewModel = new InvestimentoViewModel(investimento, produtosList);

            return View(investimentoViewModel);
        }

        // POST: InvestimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Investimento invest = GetInvestimentoByFormCollection(collection);

                if (invest.DataInvestimento >= DateTime.Today)
                {
                    return RedirectToAction(nameof(Edit), new { id });
                }

                this.investimentoRepository.Update(id, invest);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return RedirectToAction(nameof(Edit), new { id });
            }
        }

        // POST: InvestimentoController/Rescue/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rescue(int id)
        {            
            this.investimentoRepository.Recue(id);
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: InvestimentoController/Delete/5
        public ActionResult Delete(int id)
        {
            var investimento = this.investimentoRepository.GetById(id);
            return View(investimento);
        }

        // POST: InvestimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this.investimentoRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete), new { id });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        private Investimento GetInvestimentoByFormCollection(IFormCollection collection)
        {
            var produtoId = int.Parse(collection["Investimento.Produto.Id"]);
            var dataInvestimento = DateTime.Parse(collection["Investimento.DataInvestimento"]);
            var valorInvestido = Double.Parse(collection["Investimento.ValorInvestido"]);

            var produto = this.produtoRepository.GetById(produtoId);

            var invest = new Investimento(produto, dataInvestimento, valorInvestido);

            return invest;
        }
    }
}
