using Aliquota.Domain.Data;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aliquota.Domain
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Aplicacoes aplicacao = new Aplicacoes();
                AplicacaoRepo _aplicacaoRepo = new AplicacaoRepo(new AliquotaContext());
                ComunicacaoRepo comunicacao = new ComunicacaoRepo();

                comunicacao.Menu();
                Console.WriteLine("Digite sua opcao:");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\tPreencha os dados abaixo");

                    aplicacao.Valor = comunicacao.ColetarValidarValorAplicacao(aplicacao.Valor);
                    aplicacao.Data = comunicacao.ColetarValidarDataAplicacao(aplicacao.Data);
                    aplicacao.Rentabilidade_Mes = comunicacao.ColetarValidarRentabilidadeAplicacao(aplicacao.Rentabilidade_Mes);
                    _aplicacaoRepo.CadastrarAplicacao(aplicacao);
                    continue;
                }
                else if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("De qual aplicação vc deseja resgatar?");
                }
                else if(opcao == "3")
                {
                    Console.Clear();
                    List<Aplicacoes> aps =_aplicacaoRepo.ListarAplicacoes();
                    Console.WriteLine(aps.Count);
                    Console.ReadLine();
                }
                else if (opcao == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha uma opcao valida por gentileza");
                    Console.WriteLine("Precione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }


                string data = "01/05/2021";

                DateTime dataa = DateTime.Parse(data);
                DateTime dataAtu = DateTime.Now;
                int result = DateTime.Compare(dataa, dataAtu);
                string relationship = "";
                if (result < 0)
                    relationship = "é mais cedo que";
                else if (result == 0)
                    relationship = "é o mesmo tempo que";
                else
                    relationship = "é mais tarde que";

                // Console.WriteLine(dataa.Date.ToString());
               // Console.WriteLine("{0} {1} {2}", dataa, relationship, dataAtu);
 
        }
    }
}
    

