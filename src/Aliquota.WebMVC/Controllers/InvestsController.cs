using Aliquota.Business.Interfaces;
using Aliquota.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebMVC.Controllers
{
    public class InvestsController : Controller
    {
        private readonly IInvestManager investManager;
        private readonly IClientManager clientManager;

        public InvestsController(IInvestManager investManager, IClientManager clientManager)
        {
            this.investManager = investManager;
            this.clientManager = clientManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await investManager.GetInvestsAsync()); 
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await investManager.GetInvestAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invest invest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(invest);
            }
            await investManager.InsertInvestAsync(invest);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Rescue(Invest invest)
        {
            await investManager.RescueInvestAsync(invest);
            return RedirectToAction(nameof(Index));
        }
    }
}
