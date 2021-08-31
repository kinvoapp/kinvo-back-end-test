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
    public class ContaController : Controller
    {


        public const string SessionKeyConta = "Conta";
        private readonly ContaDAO _contaDAO;
        private readonly ClienteDao _clienteDao;
        private readonly BancoDao _bancoDao;
        
        public ContaController(ContaDAO contaDAO, ClienteDao clienteDao, BancoDao bancoDao)

        {
            _contaDAO = contaDAO;
            _clienteDao = clienteDao;
            _bancoDao = bancoDao;
        }

        public IActionResult Index()
        {
            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                return View(_contaDAO.Listar());
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

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Conta c)
        {
            bool acesso = _contaDAO.ValidarAcesso(c);
            if (acesso == true)
            {
                int nmr = c.NumeroConta;
                HttpContext.Session.SetString(SessionKeyConta, nmr.ToString());

                
                return RedirectToRoute(new { controller = "Produto", action = "ProdutoBanco"});
            }
            else
            {
                return View();
            }
        }


        

        

        [HttpPost]
        public IActionResult Cadastrar(Conta c,int drpBanco)
        {

            string acess = HttpContext.Session.GetString(BancoController.SessionKeyAdmin);
            if (acess != null)
            {
                ViewBag.Banco = new SelectList(_bancoDao.Listar(), "idBanco", "Nome");
                c.Banco = _bancoDao.BuscarPorId(drpBanco);

                int Cpf = c.Cliente.Cpf;

                if (_contaDAO.BuscarContaCpf(Cpf) == null)
                {
                    bool Cliente_BL = _clienteDao.Cadastrar(c.Cliente);
                    if (Cliente_BL)
                    {
                        bool Conta_BL = _contaDAO.Cadastrar(c);
                        return View();
                    }
                    else
                    {
                        return View();
                    }
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

        public IActionResult Saldo()
        {
            var conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null ) {
                return View(_contaDAO.BuscarContaNmr(Convert.ToInt32(conta)));
            } else {
                return Login();
              }
        }


    }
}
