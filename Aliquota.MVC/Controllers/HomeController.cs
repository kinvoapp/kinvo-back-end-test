using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aliquota.MVC.ViewModels;
using AutoMapper;
using Aliquota.Data.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Application.Interfaces;
using Aliquota.Application.Services;

namespace Aliquota.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAplicacaoRFAppService _aplicacaoRFAppService;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IAplicacaoRFAppService aplicacaoRFAppService)
        {
            _aplicacaoRFAppService = aplicacaoRFAppService;
            _logger = logger;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var viewModel =_mapper.Map<IEnumerable<AplicacaoRFViewModel>>(_aplicacaoRFAppService.GetAll());
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            var viewModel = _mapper.Map<AplicacaoRFViewModel>(_aplicacaoRFAppService.GetById(id));
            return View(viewModel);
        }

        public IActionResult Create(){
            return View();
        }    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AplicacaoRFViewModel viewModel)
        {
            try{
                var entity = _mapper.Map<AplicacaoRF>(viewModel);
                _aplicacaoRFAppService.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            catch(AutoMapperMappingException ex){                
                ModelState.AddModelError("", ex.InnerException.Message);
                return View();
            }
        }

        public IActionResult Edit(int id){
            var viewModel = _mapper.Map<AplicacaoRFViewModel>(_aplicacaoRFAppService.GetById(id));
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AplicacaoRFViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<AplicacaoRF>(viewModel);
                _aplicacaoRFAppService.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            catch (AutoMapperMappingException ex){
                ModelState.AddModelError("", ex.InnerException.Message);
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var viewModel = _mapper.Map<AplicacaoRFViewModel>(_aplicacaoRFAppService.GetById(id));
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, bool sobrecarga)
        {
            try
            {
                _aplicacaoRFAppService.Remove(_aplicacaoRFAppService.GetById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
