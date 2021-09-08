using System;

namespace Aliquota.Domain
{
    class Program
    {
        static void Main(string[] args)
        {        
            Usuario u = new Usuario();
            Investimento i = new Investimento();
            Controlador c = new Controlador();
            string escolha = "1";
            do
            {
            Console.WriteLine("Calculadora de IR");
            Console.WriteLine("Digite o nome do usuário");
            u.nome = Console.ReadLine();
            Console.WriteLine("Digite o saldo do usuário");
            u.saldo = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Digite o valor da Aplicação");
            i.aplicação = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Digite a data que foi realizada a aplicação no formato AAAA/MM/DD");
            i.dataEntrada = Console.ReadLine();
            Console.WriteLine("Digite a data que a aplicação foi retirada no formato AAAA/MM/DD");
            i.dataRetirada = Console.ReadLine();
            if(c.Autenticar(i) == 0){
                Console.WriteLine("Data e/ou Aplicação Invalida, a data de retirada precisa ser maior que a de entrada e o valor da aplicação precisa ser maior que 0");
                continue;
            }
            Console.WriteLine("Digite o rendimento por mês em %, ex: 1 para 1% ao mês");
            i.redimentoPorMes = Convert.ToSingle(Console.ReadLine());
            c.CalcularInvestimento(u,i);
            Console.WriteLine("O seu saldo é " + Math.Round(u.saldo, 2).ToString());
            Console.WriteLine("Você obteve um lucro de " + Math.Round(i.lucroTotal, 2).ToString());
            Console.WriteLine("O Imposto de Renda foi de "+ Math.Round(i.impostoDeRenda, 2).ToString());
            Console.WriteLine("Se vc deseja sair digite 0");
            escolha = Console.ReadLine();

            } while (escolha != "0");
        }
    }
}