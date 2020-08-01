using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aliquota.MVC.Models;
using Aliquota.Infra.Data.Repositories;
using AutoMapper;
using Aliquota.MVC.ViewModels;
using Aliquota.Domain.Entities;

namespace Aliquota.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMapper _mapper;

        private readonly AplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;
           

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _mapper = mapper;
            _aplicacaoFinanceiraRepository = new AplicacaoFinanceiraRepository(serviceProvider);
        }

        public IActionResult Index()
        {
            IEnumerable<AplicacaoFinanceiraViewModel> aplicacoesVM =
                _mapper.Map<IEnumerable<AplicacaoFinanceiraViewModel>>(_aplicacaoFinanceiraRepository.GetAll());

            return View(aplicacoesVM);
        }
        public IActionResult Details(int id)
        {
            return View(_aplicacaoFinanceiraRepository.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "Nome", "DataAplicacao", "DataResgate", "ValorAplicacao", "RentabilidadeAnual")] AplicacaoFinanceiraViewModel aplicacaoVM)
        {
            try
            {
                aplicacaoVM.ValorAplicacao /= 100;
                AplicacaoFinanceira aplicacaoEntity =
                    _mapper.Map<AplicacaoFinanceira>(aplicacaoVM);


                _aplicacaoFinanceiraRepository.Add(aplicacaoEntity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            AplicacaoFinanceiraViewModel aplicacaoVM =
                _mapper.Map<AplicacaoFinanceiraViewModel>(_aplicacaoFinanceiraRepository.GetById(id));

            return View(aplicacaoVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id", "Nome", "DataAplicacao", "DataResgate", "ValorAplicacao", "RentabilidadeAnual")] AplicacaoFinanceiraViewModel aplicacaoVM)
        {
            try
            {
                aplicacaoVM.ValorAplicacao /= 100;
                aplicacaoVM.RentabilidadeAnual /= 100;  
                AplicacaoFinanceira aplicacaoEntity =
                    _mapper.Map<AplicacaoFinanceira>(aplicacaoVM);
                aplicacaoEntity.Id = id;

                _aplicacaoFinanceiraRepository.Update(aplicacaoEntity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            AplicacaoFinanceiraViewModel aplicacaoVM =
                _mapper.Map<AplicacaoFinanceiraViewModel>(_aplicacaoFinanceiraRepository.GetById(id));
            return View(aplicacaoVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool sobrecarga)
        {
            try
            {
                _aplicacaoFinanceiraRepository.Remove(_aplicacaoFinanceiraRepository.GetById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
