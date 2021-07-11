using Aliquota.Domain.Models;
using Aliquota.Domain.Repositories.Interfaces;
using Aliquota.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Aliquota.Domain.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly InvestmentService _investmentService;

        public InvestmentsController(IInvestmentRepository investmentRepository, InvestmentService investmentService)
        {
            _investmentRepository = investmentRepository;
            _investmentService = investmentService;
        }

        public IActionResult Index()
        {
            var investments = _investmentRepository.FindAll();
            return View(investments);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Investment investment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _investmentRepository.Insert(investment);

                    TempData["Message"] = "Depósito realizado com sucesso";
                    TempData["ColorMessage"] = "success";

                    return RedirectToAction("Index");
                }

                catch (Exception)
                {
                    return RedirectToAction("Error", new { message = "Ocorreu um erro ao tentar realizar essa ação" });
                }
            }


            return View(investment);
        }

        public ActionResult Rescue(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new { message = "Id não fornecido" });
            }

            var model = _investmentRepository.GetById(id.Value);

            if (model == null)
            {
                return RedirectToAction("Error", new { message = "Investimento não encontrado" });
            }

            var profit = _investmentService.CalculateProfit(model.InvestmentDate, model.Value);
            var percentage = _investmentService.CheckIncomeTaxPercentage(model.InvestmentDate);

            var valueDiscout = _investmentService.CalculateIncomeTaxDiscount(percentage, profit);

            ViewBag.Percentage = percentage * 100;
            ViewBag.Discout = valueDiscout;
            ViewBag.RescueTotal = (model.Value + profit) - valueDiscout;
            ViewBag.TotalProfit = profit;
            ViewBag.RescueDate = DateTime.Now.Date;
            ViewBag.Date = _investmentService.CalculateDate(model.InvestmentDate);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rescue(int id)
        {         
                try
                {
                    var investment = _investmentRepository.GetById(id);
                    investment.RescueDate = DateTime.Now.Date;
                    _investmentRepository.Update(investment);

                    TempData["Message"] = "Resgate realizado";
                    TempData["ColorMessage"] = "success";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", new { message = "Ocorreu um erro ao tentar realizar essa ação" });
                }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var model = _investmentRepository.GetById(id.Value);

            if (model == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Investimento não encontrado" });
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error(string message)
        {
            return View(new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
