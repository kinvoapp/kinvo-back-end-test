using Domain.Aliquiota;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Aliquiota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinvoProject.Controllers
{
    public class BancoController : Controller
    {
        public const string SessionKeyAdmin = "Admin";
        
        private readonly BancoDao _bancoDao;

        public BancoController(BancoDao bancoDao)
        {
            _bancoDao = bancoDao;
        }

        public IActionResult Index()
        {
            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                return View(_bancoDao.Listar());
            }
            else
            {
                return RedirectToRoute(new { controller = "Banco", action = "Login" });
            }
           
        }

        public IActionResult Cadastrar()
        {   
            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Banco", action = "Login" });
            }
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            if (login == "admin")
            {
                if (senha == "admin")
                {
                    HttpContext.Session.SetString(SessionKeyAdmin, "admin");
                    return RedirectToRoute(new { controller = "Banco", action = "Index" }); ;
                }
                else {
                    return View();
                }
            }
            else{ 
            return View();
            }

        }

        [HttpPost]
        public  IActionResult Cadastrar(Banco b)
        {
            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                _bancoDao.Cadastrar(b);
                return RedirectToRoute(new { controller = "Banco" }); ;
            }
            else
            {
                return RedirectToRoute(new { controller = "Banco", action = "Login" });
            }
            
        }

    }
}
