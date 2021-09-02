using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Web.Controllers
{
    public class SituacaoProdutosController : Controller
    {
        private readonly ISituacaoProdutoBusiness _situacaoProdutoBusiness;

        public SituacaoProdutosController(ISituacaoProdutoBusiness situacaoProdutoBusiness)
        {
            _situacaoProdutoBusiness = situacaoProdutoBusiness;
        }

        // GET: SituacaoProdutosController
        public async Task<ActionResult> Index()
        {
            return View(await _situacaoProdutoBusiness.GetListGrid());
        }

        // GET: SituacaoProdutosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _situacaoProdutoBusiness.GetItemById(id));
        }

        // GET: SituacaoProdutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SituacaoProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SituacaoProdutoDto item)
        {
            try
            {
                _situacaoProdutoBusiness.Criar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SituacaoProdutosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _situacaoProdutoBusiness.GetItemById(id));
        }

        // POST: SituacaoProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SituacaoProdutoDto item)
        {
            try
            {
                _situacaoProdutoBusiness.Editar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SituacaoProdutosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(_situacaoProdutoBusiness.GetItemById(id));
        }

        // POST: SituacaoProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SituacaoProdutoDto item)
        {
            try
            {
                _situacaoProdutoBusiness.DeleteById(item.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
