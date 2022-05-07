using System;
using Aliquota.Application.DTO;
using Aliquota.Api.Commands;

namespace Aliquota.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            do{
                Console.Clear();
                Console.WriteLine(MostrarCabecalho());
                Console.WriteLine(MostrarMenu());
                opcao = LerOpcaoMenu();
                ProcessarOpcaoMenu(opcao);
            } while (opcao != "4");
        }

        static string LerOpcaoMenu()
        {
            string opcao;
            Console.Write("Opção desejada: ");
            opcao = Console.ReadLine();
            return opcao;
        }

        static string MostrarMenu()
        {
            string menu = "Escolha uma opção:\n\n" +
                          " 1 - Realizar aplicação\n" +
                          " 2 - Realizar resgate\n" +
                          " 3 - Ver histórico de movimentaçõesz\n" +
                          " 4 - Sair do Programa \n"; 
            return menu;
        }

        static string MostrarCabecalho()
        {
            return "[ ALIQUOTA ]\n";
        }

        static void ProcessarOpcaoMenu(string opcao)
        {
            switch(opcao)
            {
                case "1":
                    RealizarAplicacao();
                    break;
                case "2":
                    RealizarResgate();
                    break;
                case "3":
                    VerHistorico();
                    break;
                case "4":
                    Console.WriteLine("Até mais!");
                    break;
                default:
                    Console.WriteLine("Opção de menu inválida.");
                    break;
            }
        }

        private static void VerHistorico()
        {
            var comando = new MovimentacaoComando();
            var movimentacoes = comando.ListarTodas();
            
            if (movimentacoes!=null)
            {
                foreach (var movimentacao in movimentacoes )
                {
                    Console.WriteLine("\n"+movimentacao.ToString());
                }
            }
            else
            {
                Console.WriteLine("A consulta não retornou movimentações.");
            }

            Console.ReadKey();
        }

        private static void RealizarAplicacao()
        {
            var movimentacaoDTO = new MovimentacaoDTO();
            var comando = new MovimentacaoComando();
            char opcao;
            Console.Clear();
            Console.WriteLine("\n[APLICACAO]");
            Console.Write("Valor: ");
            movimentacaoDTO.Valor = double.Parse(Console.ReadLine());
            movimentacaoDTO.DataMovimentacao = DateTime.Now;
            movimentacaoDTO.Tipo = Tipo.Aquisicao;

            if(comando.Adicionar(movimentacaoDTO))
            {
                Console.WriteLine("Aplicação Realizada com sucesso!");
                Console.ReadKey();
            }

        }

        private static void RealizarResgate()
        {
            var movimentacaoDTO = new MovimentacaoDTO();
            var comando = new MovimentacaoComando();
            char opcao;
            Console.Clear();
            Console.WriteLine("\n[Resgate]");
            Console.Write("Valor: ");
            movimentacaoDTO.Valor = double.Parse(Console.ReadLine());
            movimentacaoDTO.DataMovimentacao = DateTime.Now;
            movimentacaoDTO.Tipo = Tipo.Resgate;

            if(comando.Adicionar(movimentacaoDTO))
            {
                Console.WriteLine("Aplicação Realizada com sucesso!");
                Console.ReadKey();
            }

        }
    }
}
