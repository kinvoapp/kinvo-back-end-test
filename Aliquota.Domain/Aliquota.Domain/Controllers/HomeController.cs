using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.WebEncoders.Testing;

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
            List<TipoAplicacao> tipoAplicacao = new List<TipoAplicacao>();
            tipoAplicacao.Add(new TipoAplicacao()
            {
                ID = 1,
                NomeAplicacao = "Tesouro Direto"
            });

            ViewBag.Aplicacao = tipoAplicacao;

            return View();
        }

        [HttpPost]
        public IActionResult CadastroInvestidor(CadastroInvestidor cadastro)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            ProcessaCalculo processaCalculo = new ProcessaCalculo();

            double valorRendimento = processaCalculo.CalculaValorRendimento(cadastro.DataAplicacao, cadastro.DataResgate, cadastro.ValorAplicacao);

            double valorImposto = processaCalculo.CalculaImposto(cadastro.DataAplicacao, cadastro.DataResgate, cadastro.ValorAplicacao);

            string dtInicioAplicacao = cadastro.DataAplicacao.ToString();
            string dtResgateAplicacao = cadastro.DataResgate.ToString();
            string nome = cadastro.Nome;
            double valorAplicado = cadastro.ValorAplicacao;

            return RedirectToAction("ResultadoFinanceiro", new { cadastro, dtInicioAplicacao, dtResgateAplicacao, nome, valorAplicado , valorRendimento, valorImposto});
        }

        public IActionResult ResultadoFinanceiro(CadastroInvestidor cadastro, string dtInicioAplicacao, string dtResgateAplicacao, string nome, double valorAplicado, double valorRendimento, double valorImposto)
        {
            ResultadoFinanceiro resultadoFinanceiro = new ResultadoFinanceiro()
            {
                Nome = nome,
                DataAplicacao = dtInicioAplicacao,
                DataResgate = dtResgateAplicacao,
                ValorAplicado = valorAplicado.ToString(),
                ValorRendimento = (valorRendimento).ToString(),
                TotalRendimento = (valorRendimento + valorAplicado).ToString(),
                ValorJuros = valorImposto.ToString(),
                LucroTotal = ((valorRendimento + valorAplicado) - valorImposto).ToString()
            };


            return View(resultadoFinanceiro);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
