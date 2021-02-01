using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aliquota.WEB.Controllers
{
    public class AplicacaoController : Controller
    {
        private readonly IAplicacaoService _aplicacaoService;
        public AplicacaoController(IAplicacaoService aplicacaoService)
        {
            _aplicacaoService = aplicacaoService;
        }
        public async Task<IActionResult> Index()
        {
            var oViewModel = await _aplicacaoService.ObterTodos();
            return View(oViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AplicacaoCreateViewModel oView)
        {
            if (ModelState.IsValid) 
            {
                var oResult = await _aplicacaoService.Adicionar(oView);
                if (oResult)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(oView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AplicacaoEditViewModel oView)
        {
            if (ModelState.IsValid)
            {
                var oResult = await _aplicacaoService.Atualizar(oView);
                if (oResult)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(oView);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var edit = await _aplicacaoService.ObterPorId(id);
            return View(edit);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var edit = await _aplicacaoService.ObterPorId(id);
            return View(edit);
        }
    }
}
