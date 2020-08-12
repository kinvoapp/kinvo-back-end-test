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

            string Nome = cadastro.Nome;
            DateTime DtInicioAplicacao = cadastro.DataAplicacao;
            DateTime DtResgateAplicacao = cadastro.DataResgate;
            double ValorAplicado = cadastro.ValorAplicacao;

            return RedirectToAction("ResultadoFinanceiro", new { cadastro, DtInicioAplicacao, DtResgateAplicacao, Nome, ValorAplicado, ValorRendimento, ImpostoDevidoSobreLucro, TaxaIRAplicada });
        }

        public IActionResult ResultadoFinanceiro(CadastroInvestidor cadastro, DateTime dtInicioAplicacao, DateTime dtResgateAplicacao, string nome, double valorAplicado, double valorRendimento, double impostoDevidoSobreLucro, string taxaIRAplicada)
        {
            ResultadoFinanceiro resultadoFinanceiro = new ResultadoFinanceiro()
            {
                Nome = nome,
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
        public IActionResult Editar(ResultadoFinanceiro resultadoFinanceiro)
        {
            CadastroInvestidor cadastro = new CadastroInvestidor()
            {
                DataAplicacao = resultadoFinanceiro.DataAplicacao,
                DataResgate = resultadoFinanceiro.DataResgate,
                Nome = resultadoFinanceiro.Nome,
                TipoAplicacao = "Tesouro Direto",
                ValorAplicacao = Convert.ToDouble(resultadoFinanceiro.ValorAplicado)
            };

            return View(cadastro);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(bool valid)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
