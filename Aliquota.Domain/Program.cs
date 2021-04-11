using Aliquota.Domain.Controllers;
using Aliquota.Domain.Controllers.Resgate;
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
            AplicacaoController _aplicacaoController = new AplicacaoController();
            ResgateController _resgateController = new ResgateController();
            ComunicacaoGeral _comunicacao = new ComunicacaoGeral();
            while (true)
            {
                
                _comunicacao.Menu();
                Console.WriteLine("\n Digite sua opcao:");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Aplicacoes aplicacao = new Aplicacoes();
                    _aplicacaoController.AdicionarAplicacao(aplicacao);
                    continue;
                }
                else if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\tDe qual aplicação vc deseja resgatar?\n");
                    List<Aplicacoes> aps = _aplicacaoController.ListarAplicacoes();

                    _comunicacao.TabelaDeAplicacao(aps);

                    Console.WriteLine("\nDigite o ID da aplicacao\no 'c' para cancelar");
                    string acao = Console.ReadLine();

                    if (acao == "c")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Aplicacoes apli = _aplicacaoController.SelecionarAplicacao(aps, acao);

                        Resgates resgate = _resgateController.DetalharResgateNaoCriado(apli);

                        Console.WriteLine("Quer fazer a retirada desta aplicacao?");
                        Console.WriteLine("Para ver os dados do resgate digite 'r' para cancelar digite 'c'");

                        string confirmacao = Console.ReadLine();

                        while (confirmacao != "r" && confirmacao != "c")
                        {
                            Console.WriteLine("Opcao invalida, tente novamente");
                            confirmacao = Console.ReadLine();
                        }

                        if (confirmacao == "r")
                        {
                            _resgateController.CriarResgate(apli, resgate);
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                    }

                }
                else if(opcao == "3")
                {
                    Console.Clear();
                    List<Aplicacoes> aps = _aplicacaoController.ListarAplicacoes();
                    _comunicacao.TabelaDeAplicacao(aps);

                    Console.WriteLine("\n Para selecionar uma aplicacao digite o ID dela");
                    Console.WriteLine(" Caso queira voltar ao medo digite 'm'");
                    string acao = Console.ReadLine();

                    if(acao == "m")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Aplicacoes selecionada =_aplicacaoController.SelecionarAplicacao(aps, acao);

                        Console.WriteLine("\n Caso queira investir mais nesta aplicacao digite 'i'\n caso queria voltar ao menu digite 'm'");
                        acao = Console.ReadLine();

                        while (acao != "i" && acao != "m")
                        {
                            Console.WriteLine("Opcao invalida, tente novamente");
                            acao = Console.ReadLine();
                        }

                        if(acao == "i")
                        {
                            _aplicacaoController.RealizarInvestimento(selecionada);
                            continue;
                        }
                        else if(acao == "m")
                        {
                            Console.Clear();
                            continue;
                        }
                        
                        Console.ReadKey();
                    }

                }
                else if(opcao == "4")
                {
                    Resgates resgate = _resgateController.ListarSelecionarResgate();

                    if(resgate == null)
                    {
                        Console.Clear();
                        continue;
                    }

                    Aplicacoes app = _aplicacaoController.BuscarAplicacaoPorId(resgate.AplicacaoId);

                    _resgateController.DetalharResgate(resgate, app);
                    
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

        }
    }
}
    

