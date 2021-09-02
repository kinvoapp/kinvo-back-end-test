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
    public class ClientesController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        // GET: ClientesController
        public async Task<ActionResult> Index()
        {
            return View(await _clienteBusiness.GetListGrid());
        }

        // GET: ClientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _clienteBusiness.GetItemById(id));
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteDto item)
        {
            try
            {
                _clienteBusiness.Criar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _clienteBusiness.GetItemById(id));
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteDto item)
        {
            try
            {
                _clienteBusiness.Editar(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public  async Task<ActionResult> Delete(int id)
        {
            return View(await _clienteBusiness.GetItemById(id));
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClienteDto item)
        {
            try
            {
                _clienteBusiness.DeleteById(item.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
