using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uncomment for debug
            //args = new[] { "2", "5"};
            try
            {
                var arg = args[0].Length == 0 ? string.Empty : args[0];
                var arg1 = args[1].Length == 0 ? string.Empty : args[1];//Nome Cliente
                var arg2= args[2].Length == 0 ? string.Empty : args[2];//Saldo Aplicacao
                //CaseInsesitive
                var command = string.IsNullOrWhiteSpace(arg) ? string.Empty : arg.ToLower();

                switch (command)
                {
                    case "?":
                    case "help":
                        ImprimirHelp();
                        break;
                    case "1":
                        var param1 = string.Format("{0}", args[1], args[2]);
                        DividedBy3(param1);
                        break;
                    case "2":
                        var param2 = string.Format("{0}", args[1]);
                        DrawReverseTree(param2);
                        break;
                    default:
                        Console.Write("Comando não reconhecido ou parâmetro inválido. Digite help para acessar ajuda.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Um ou mais parâmetros foram informados incorretamente.");
            }


        }


        private static void ImprimirHelp()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("KINVO, by Valnei Filho v_marinpietri@yahoo.com.br");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("Sintax: ");
            Console.WriteLine("appconsole {command} {parameters}");
            Console.WriteLine("");
            Console.WriteLine("Comandos suportados");
            Console.Write(
                    "-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("?                - Help ");
            Console.WriteLine("1 20             - Exercise 1, 20 a parameter, and press enter to search numbers divide by 3");
            Console.WriteLine("2 5              - Exercise 2, 5 a parameter (level of tree),and press enter to draw a reverse tree.");
            Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Example to access the first exercise");
            Console.WriteLine(@"D:wex_brazil_test\bin\Debug\wex_brazil_test 1 20");

            Console.Write("");
            Console.WriteLine(""); Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------");
        }

    }
}
