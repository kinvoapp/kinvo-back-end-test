using System;
using System.Linq;
using Aliquota.Domain.Controller;

namespace Aliquota.Domain
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ProgramController controller = new ProgramController();
            ConsoleFrontEnd frontEnd = new ConsoleFrontEnd();
            frontEnd.DoApplication += controller.Apply;
            frontEnd.DoWithdraw += controller.Withdraw;


            frontEnd.ExecutionLoop();
        }
    }


    public class ConsoleFrontEnd 
    {
        //public Func<string, string, bool> RegisterClient;
        public Func<string, string, string, float[]> DoApplication;
        public Func<string, string, float[]> DoWithdraw;
        string[] CommandList = new string[] { "fazer aplicação", "fazer resgate" };
        public void ExecutionLoop() 
        {
            Console.WriteLine("Bem-vindo!");

            while (true)
            {
                Start();

                string command = Console.ReadLine();

                switch (command)
                {
                    case "fazer aplicação":
                        Apply();
                        break;
                    case "fazer resgate":
                        Withdraw();
                        break;
                    case "encerrar":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("..........");
                        Console.WriteLine("Commando não reconhecido.");
                        Console.WriteLine(".");

                        break;
                }

            }
        }

        void Start()
        {

            Console.WriteLine(".");
            Console.WriteLine($"Para fazer uma aplicação como um cliente cadastrado digite '{CommandList[0]}';");
            Console.WriteLine(".");
            Console.WriteLine($"Para fazer um resgate como um cliente cadastrado digite '{CommandList[1]}';");
            Console.WriteLine(".");
            Console.WriteLine($"Para registrar um novo cliente digite 'encerrar';");
            Console.WriteLine(".");
            Console.WriteLine(".");

        }
        void Apply()
        {
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine($"Digite numero do seu CPF sem pontos e sem o traço (11 digitos):");
            string clientCPF = Console.ReadLine();
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine($"Digite o montante da sua aplicação (utilize virgula como separador):");
            string amount = Console.ReadLine();
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine($"Digite a data da sua aplicação (utilize o formato dd/mm/aaaa):");
            string dateTime = Console.ReadLine();
            float[] f = DoApplication.Invoke(clientCPF, amount, dateTime);


            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");

            if (f == null)
            {
                Console.WriteLine($"Algo deu errado, aplicação não realizada.");

            }
            else
            {
                Console.WriteLine($"Sua aplicação foi realizada no valor de {f[0]}.");
            }


        }
        void Withdraw()
        {
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine($"Digite numero do seu CPF sem pontos e sem o traço (11 digitos):");
            string clientCPF = Console.ReadLine();
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine($"Digite a data da sua aplicação (utilize o formato dd/mm/aaaa):");
            string dateTime = Console.ReadLine();
            float[] f = DoWithdraw.Invoke(clientCPF, dateTime);

            if (f == null)
            {
                Console.WriteLine($"Algo deu errado, o resgate não foi realizado.");

            }
            else
            {
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine($"Seu resgate foi realizado.");
                Console.WriteLine($"Lucro total: {Math.Round(f[2], 2)}.");
                Console.WriteLine($"Imposto de renda cobrado: {Math.Round(f[1], 2)}.");
                Console.WriteLine($"Lucro final: {Math.Round(f[0], 2)}.");
                Console.WriteLine($"Porcentagem do imposto: {Math.Round((f[1] / f[2]) * 100, 2)}.");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");

            }
        }
    }
}
