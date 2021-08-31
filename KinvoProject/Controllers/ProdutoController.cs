using Domain.Aliquiota;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Aliquiota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinvoProject.Controllers
{
    public class ProdutoController : Controller
    {
        
        private readonly ProdutoDAO _produtoDAO;
        private readonly BancoDao _bancoDao;
        private readonly ContaDAO _contaDAO;
        
        public ProdutoController(ProdutoDAO produtoDAO, BancoDao bancoDao,ContaDAO contaDAO)

        {
            _produtoDAO = produtoDAO;
            _bancoDao = bancoDao;
            _contaDAO= contaDAO;
           
        }


        public IActionResult Index()
        {
            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                return View(_produtoDAO.Listar());
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
                ViewBag.Banco = new SelectList(_bancoDao.Listar(), "idBanco", "Nome");
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Banco", action = "Login" });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto p, int drpBanco, string txaF, string txaM, string txaI, string rend)
        {
            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                ViewBag.Banco = new SelectList(_bancoDao.Listar(), "idBanco", "Nome");
                if (txaF != null && txaM != null && txaI != null && rend != null)
                {
                    p.Banco = _bancoDao.BuscarPorId(drpBanco);
                    p.Taxa_Menor_IR = Convert.ToDecimal(txaI.Replace("%", ""));
                    p.Taxa_Entre_IR = Convert.ToDecimal(txaM.Replace("%", ""));
                    p.Taxa_Maior_IR = Convert.ToDecimal(txaF.Replace("%", ""));
                    p.Rendimento = Convert.ToDecimal(rend.Replace("%", ""));
                    _produtoDAO.Cadastrar(p);
                    return RedirectToRoute(new { controller = "Produto", action = "Index" });
                }
                else
                {

                    return View();
                }
            }
            else
            {
                return RedirectToRoute(new { controller = "Banco", action = "Login" });
            }
                                   
        }

        public IActionResult ProdutoBanco()
        {

            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {

                int banco = _contaDAO.RetornaBanco(Convert.ToInt32(conta));
                return View(_produtoDAO.ProdutoBanco(banco));
            }
            else
            {
                return RedirectToRoute(new { controller = "Conta", action = "Login" });
            }
        }

        public IActionResult Investir(int produto)
        {
            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {

                HttpContext.Session.SetInt32("Produto", produto);
                return RedirectToRoute(new { controller = "Investimento", action = "Investir" });
            }
            else
            {
                return RedirectToRoute(new { controller = "Conta", action = "Login" });
            }
           
        }
        
    }
}
