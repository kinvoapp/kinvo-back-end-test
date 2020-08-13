using Aliquota.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aliquota.Domain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //double valorRendimento = 0;
        //double valorImposto = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroInvestidor cadastro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ProcessaDados processaDados = new ProcessaDados();
            double ValorRendimento = processaDados.CalculaValorRendimento(cadastro.DataAplicacao, cadastro.DataResgate, cadastro.ValorAplicacao);
            double ImpostoDevidoSobreLucro = processaDados.CalculaImpostoDevido(cadastro.DataAplicacao, cadastro.DataResgate, ValorRendimento);
            string TaxaIRAplicada = processaDados.TaxaIRAplicada(cadastro.DataAplicacao, cadastro.DataResgate);

            
            DateTime DtInicioAplicacao = cadastro.DataAplicacao;
            DateTime DtResgateAplicacao = cadastro.DataResgate;
            double ValorAplicado = cadastro.ValorAplicacao;

            return RedirectToAction("ResultadoFinanceiro", new { cadastro, DtInicioAplicacao, DtResgateAplicacao, ValorAplicado, ValorRendimento, ImpostoDevidoSobreLucro, TaxaIRAplicada });
        }

        public IActionResult ResultadoFinanceiro(CadastroInvestidor cadastro, DateTime dtInicioAplicacao, DateTime dtResgateAplicacao, string nome, double valorAplicado, double valorRendimento, double impostoDevidoSobreLucro, string taxaIRAplicada)
        {
            ResultadoFinanceiro resultadoFinanceiro = new ResultadoFinanceiro()
            {
                DataAplicacao = dtInicioAplicacao,
                DataResgate = dtResgateAplicacao,
                ValorAplicado = valorAplicado.ToString(),
                ValorRendimento = valorRendimento.ToString(),
                ImpostoDevido = impostoDevidoSobreLucro.ToString(),
                LucroReal = ((valorAplicado + valorRendimento) - impostoDevidoSobreLucro).ToString(),
                TaxaIRAplicada = taxaIRAplicada
            };

            return View(resultadoFinanceiro);
        }

        [HttpPost]
        public IActionResult Editar()
        {
            return View();
        }

        public ActionResult Processar(CadastroInvestidor cadastro)
        {
            ProcessaDados processaDados = new ProcessaDados();
            double ValorRendimento = processaDados.CalculaValorRendimento(cadastro.DataAplicacao, cadastro.DataResgate, cadastro.ValorAplicacao);
            double ImpostoDevidoSobreLucro = processaDados.CalculaImpostoDevido(cadastro.DataAplicacao, cadastro.DataResgate, ValorRendimento);
            string TaxaIRAplicada = processaDados.TaxaIRAplicada(cadastro.DataAplicacao, cadastro.DataResgate);

            //string Nome = cadastro.Nome;
            DateTime DtInicioAplicacao = cadastro.DataAplicacao;
            DateTime DtResgateAplicacao = cadastro.DataResgate;
            double ValorAplicado = cadastro.ValorAplicacao;

            return RedirectToAction("ResultadoFinanceiro", new { cadastro, DtInicioAplicacao, DtResgateAplicacao, ValorAplicado, ValorRendimento, ImpostoDevidoSobreLucro, TaxaIRAplicada });
        }
    }
}
