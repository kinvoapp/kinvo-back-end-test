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
            } while (opcao != "5");
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
                          " 3 - Ver histórico de movimentações\n" +
                          " 4 - Ver saldo capitalizado\n" +
                          " 5 - Sair do Programa \n"; 
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
                    ObterSaldo();
                    break;
                case "5":
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
                Console.WriteLine(String.Format("| {0,17} | {1,6} | {2,8} |", "Data Movimentação", "Valor", "Tipo"));

                foreach (var movimentacao in movimentacoes )
                {
                    Console.WriteLine(String.Format("| {0,17} | {1,6} | {2,8} |", movimentacao.DataMovimentacao.ToString(), movimentacao.Valor.ToString(), movimentacao.Tipo.ToString()));
                   
                }
            }
            else
            {
                Console.WriteLine("A consulta não retornou movimentações.");
            }

            Console.ReadKey();
        }

         private static void ObterSaldo()
        {
            var comando = new MovimentacaoComando();
            var saldo = comando.ObterSaldo();
            
            Console.WriteLine("Saldo total: "+ String.Format("{0:0.00}", saldo));
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

           DateTime? dataMovimentacao = null;
            
            do {
                Console.Write("Informe a data no formato DD/MM/YYYY: ");

                 try{
                     dataMovimentacao = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                     Console.WriteLine("Data inválida");
                }
            } while (dataMovimentacao == null);

            movimentacaoDTO.DataMovimentacao = dataMovimentacao.GetValueOrDefault();
            movimentacaoDTO.Tipo = Tipo.Aplicacao;

            var retorno = comando.Adicionar(movimentacaoDTO);

            Console.WriteLine(retorno);
            Console.ReadKey();
            

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

            DateTime? dataMovimentacao = null;
            
            do {
                Console.Write("Informe a data no formato DD/MM/YYYY: ");

                 try{
                     dataMovimentacao = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                     Console.WriteLine("Data inválida");
                }
            } while (dataMovimentacao == null);
            
            movimentacaoDTO.DataMovimentacao = dataMovimentacao.GetValueOrDefault();
            movimentacaoDTO.Tipo = Tipo.Resgate;

            var retorno = comando.Adicionar(movimentacaoDTO);

            Console.WriteLine(retorno);
            Console.ReadKey();
            
        
        }

    }
}

