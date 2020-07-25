using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Aliquota.Application.Interface;
using Aliquota.Domain.Entity;
using Aliquota.Infrastructure.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;


namespace Aliquota.Presentation.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.RegisterServices();
            var serviceProvider = collection.BuildServiceProvider();
            var aplicacaoService = serviceProvider.GetService<IAplicacaoFinanceiraAppService>();
            var resgateService = serviceProvider.GetService<IResgateAppService>();
            var clienteService = serviceProvider.GetService<IClienteAppService>();

            //var resultado = await aplicacaoService.Handle(new Cliente("vitor",
            //    new List<AplicacaoFinanceira>(), "13123123"), 1000,
            //    new ProdutoFinanceiro() { Descricao = "Tesouro quebrado", TaxaRedendimento = 2.5M });
            //System.Console.WriteLine("Infome seu nome: ");
            //var nomeCliente = System.Console.ReadLine();
            // ValidarCliente(nomeCliente);
        }
  
    }
}
