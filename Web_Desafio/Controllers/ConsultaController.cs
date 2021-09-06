using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Desafio.Controllers
{
    public class ConsultaController : Controller
    {
        public readonly InterfaceConsultaApp _InterfaceConsultaApp;
        public ConsultaController(InterfaceConsultaApp InterfaceConsultaApp)
        {
            _InterfaceConsultaApp = InterfaceConsultaApp;
        }

        // GET: UserController
        public async Task<IActionResult> Consulta()
        {
            var list = await _InterfaceConsultaApp.List();
            ViewBag.IRGeradas = list.Count();
            ViewData["Consultas"] = list;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(Consulta consulta)
        {
            try
            {
                await _InterfaceConsultaApp.AddConsulta(consulta);
                if (consulta.Notificacoes.Any())
                {
                    foreach (var item in consulta.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    ViewData["Consultas"] = await _InterfaceConsultaApp.List();
                    return View("Consulta", consulta);
                }
            }
            catch
            {
                return View("Consulta", consulta);
            }
            return RedirectToAction(nameof(Consulta));
        }

       
        public async Task<IActionResult> Delete(int id, Consulta consulta)
        {
            try
            {
                var consultaDelete = await _InterfaceConsultaApp.GetEntityById(id);
                await _InterfaceConsultaApp.Delete(consultaDelete);
                return RedirectToAction(nameof(Consulta));
            }
            catch
            {
                return View("Consulta");
            }
        }
    }
}
