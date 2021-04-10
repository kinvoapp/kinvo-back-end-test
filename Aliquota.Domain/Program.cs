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
            while (true)
            {
                Aplicacoes aplicacao = new Aplicacoes();
                AplicacaoController _aplicacaoController = new AplicacaoController();
                ResgateController _resgateController = new ResgateController();
                ComunicacaoGeral _comunicacao = new ComunicacaoGeral();

                _comunicacao.Menu();
                Console.WriteLine("Digite sua opcao:");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    _aplicacaoController.FluxoAdicionarAplicacao(aplicacao);
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

                        Aplicacoes selecionada = _aplicacaoController.FluxoSelecionarAplicacao(aps, acao);

                        string resultado = _resgateController.FluxoResgatarAplicacao(selecionada);
                        if(resultado == "r")
                        {
                            _aplicacaoController.ResgatarAplicacao(selecionada);
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
                        _aplicacaoController.FluxoSelecionarAplicacao(aps, acao);
                        Console.ReadKey();
                    }

                }
                else if(opcao == "4")
                {
                    _resgateController.FluxoSelecionarResgate();

                    continue;
                    
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
    

