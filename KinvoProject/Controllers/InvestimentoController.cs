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
    public class InvestimentoController : Controller
    {
        public const string SessionKeyConta = "Conta";
        private readonly InvestimentoDAO _investimentoDAO;
        private readonly ContaDAO _contaDAO;
        private readonly ProdutoDAO _produtoDAO;
        
        public InvestimentoController(InvestimentoDAO investimentoDAO, ContaDAO contaDAO, ProdutoDAO produtoDAO)
        {
            _investimentoDAO = investimentoDAO;
            _contaDAO = contaDAO;
            _produtoDAO = produtoDAO;
            
        }

        
        public IActionResult Carteira()
        {
            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {
                return View(_investimentoDAO.ListPorConta(Convert.ToInt32(conta)));
            }
            else
            {
                return RedirectToRoute(new { controller = "Conta", action = "Login" });
            }
        }

        public IActionResult Investir()
        {
            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {
                Investimento i = new Investimento();
                int produto = Convert.ToInt32(HttpContext.Session.GetInt32("Produto"));
                i.Produto = _produtoDAO.BuscarPorId(produto);
                return View(i);
            }
            else
            {
                return RedirectToRoute(new { controller = "Conta", action = "Login" });
            }
        }

        public IActionResult Visualizar(int id)
        {
            Investimento i = new Investimento();
            i = _investimentoDAO.BuscarPorId(id);

            if(i.DataResgate == DateTime.MinValue) { 
                int produto = Convert.ToInt32(HttpContext.Session.GetInt32("Produto"));
                i.Produto = _produtoDAO.BuscarPorId(produto);
            }
            return View(i);
        }

        [HttpPost]
        public IActionResult Investir(Investimento i, string investir)
        {
            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {
                investir = investir.Replace("R$", "");

                int produto = Convert.ToInt32(HttpContext.Session.GetInt32("Produto"));
                i.Produto = _produtoDAO.BuscarPorId(produto);
                i.Conta = _contaDAO.BuscarContaNmr(Convert.ToInt32(conta));
                i.ValorInvestido = Convert.ToDecimal(investir);
                bool Aux = _investimentoDAO.Cadastrar(i);

                if(Aux == false)
                {
                    return View(i);
                }
                else
                {
                    return RedirectToRoute(new { controller = "Investimento", action = "Carteira"});
                }
                
            }
            else
            {
                return RedirectToRoute(new { controller = "Conta", action = "Login" });
            }
        }

        [HttpPost]
        public IActionResult Resgatar(int id)
        {
            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {
                _investimentoDAO.Resgatar(id);
                return RedirectToRoute(new { controller = "Investimento", action = "Carteira" });
            }
            else{ 
                return RedirectToRoute(new { controller = "Conta", action = "Login" });
            }
            
            
        }

    }
}
