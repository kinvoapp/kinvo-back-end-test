using System;

namespace Aliquota.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ListarOpcoesEntidades();

                string l_Opcaostr = Console.ReadLine();

                int l_OpcaoEntidade, l_OpcaoAcao;

                if (!Int32.TryParse(l_Opcaostr, out l_OpcaoEntidade))
                {
                    Console.WriteLine("Opção Inválida.");
                    System.Threading.Thread.Sleep(5000);
                    continue;
                }

                ListarComandos(l_OpcaoEntidade);
                l_Opcaostr = Console.ReadLine();
                if (!Int32.TryParse(l_Opcaostr, out l_OpcaoAcao))
                {
                    Console.WriteLine("Opção Inválida.");
                    System.Threading.Thread.Sleep(5000);
                    continue;
                }

                ExecutarAcao(l_OpcaoEntidade, l_OpcaoAcao);
            }
        }

        public static void ExecutarAcao(int a_OpcaEntidade, int a_OpcaoAcao)
        {

        }

        public static void ListarOpcoesEntidades()
        {
            Console.Clear();
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Produto Financeiro:");
            Console.WriteLine("2 - Cliente");
            Console.WriteLine("3 - Aplicação");
            Console.WriteLine("4 - Calcular IR");
        }

        public static void ListarComandos(int a_OpcaoEntidade)
        {
            Console.Clear();
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Atualizar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Listar");
        }
    }
}
