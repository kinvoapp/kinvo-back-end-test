using Aliquota.Business.Interfaces;
using Aliquota.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.WebMVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientManager clientManager;

        public ClientsController(IClientManager clientManager)
        {
            this.clientManager = clientManager;
        }


        //MÉTODOS
        public async Task<IActionResult> Index()
        {
            return View(await clientManager.GetClientsAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await clientManager.GetClientAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(error: client);
            }
            await clientManager.InsertClientAsync(client);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public  async Task<IActionResult> Edit(int id)
        {
            return View(await clientManager.GetClientAsync(id));
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Client client)
        {
            var attClient = await clientManager.UpdateClientAsync(client);
            if (attClient == null)
            {
                return NotFound(client);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await clientManager.DeleteClientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
