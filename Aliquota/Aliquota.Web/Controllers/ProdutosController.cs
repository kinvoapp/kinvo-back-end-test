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
    public class ProdutosController : Controller
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutosController(IProdutoBusiness produtoBusiness)
        {
            _produtoBusiness = produtoBusiness;
        }

        // GET: ProdutosController1
        public async Task<ActionResult> Index()
        {
            return View(await _produtoBusiness.GetListGrid());
        }

        // GET: ProdutosController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _produtoBusiness.GetItemById(id));
        }

        // GET: ProdutosController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(ProdutoDto item)
        {
            try
            {
                _produtoBusiness.Criar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _produtoBusiness.GetItemById(id));
        }

        // POST: ProdutosController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProdutoDto item)
        {
            try
            {
                _produtoBusiness.Editar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _produtoBusiness.GetItemById(id));
        }

        // POST: ProdutosController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProdutoDto item)
        {
            try
            {
                _produtoBusiness.DeleteById(item.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
