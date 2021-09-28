using System;
using Aliquota.Domain;

namespace ResgateInvest 
{
    class Aliquota 
    { 
        static void Main(string[] args) 
        {
            var erroInvestimento = "ATENÇÃO! Investimento inferior ao requisito de R$ 1 - Execute Novamente!";
            var erroPeriodo = "ATENÇÃO! Periodo solicitado inferior ao requisito de 12 Meses - Execute Novamente!";
            // Sinalização de Erro caso não atenda aos requisitos
            AliquotaDomain obj = new AliquotaDomain();

            Console.WriteLine("-------------------------------RESGATE DE INVESTIMENTO-------------------------------");
            Console.WriteLine("IMPORTANTE!: ");
            Console.WriteLine("*Valor minimo para Investimento: R$ 1");
            Console.WriteLine("*Periodo minimo de Resgate: 12 Meses");
            Console.WriteLine("A taxa DI Hoje é 6,15%. Isso significa dizer que o CDI Hoje é 6,15%. 27/09/2021");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.Write("Digite o Valor do investimento: R$ ");
                obj.valor = double.Parse(Console.ReadLine());
            
            if (obj.valor <= 0) {
                Console.WriteLine(erroInvestimento);
                return;
            }

            Console.Write("Digite o rendimento Anual Proposto. (Ex: 100%, 150%, 200%): ");
                 obj.rentA = double.Parse(Console.ReadLine());
            
            Console.Write("Digite quantos meses: ");
                 obj.meses = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Rendimento Anual CDI Final: " + obj.rendimentoA().ToString("F2")+"%");

            Console.WriteLine("Rentabilidade ao mês: " + obj.rendimentoM().ToString("F2")+"%");

            obj.vlucro();

            double imposto = 0;

            if (obj.meses < 12) {
                Console.WriteLine(erroPeriodo);
                return;
            }
            else if (obj.meses == 12) {
                imposto = 22.5 * obj.vlucro() / 100;
            }
            else if (obj.meses >= 13 && obj.meses <= 23) {
                imposto = 18.5 * obj.vlucro() / 100;
            }
            else if (obj.meses >= 24) {
                imposto = 15 * obj.vlucro() / 100;
            }

            Console.WriteLine("-------------------------------------------------------------------------------------");

            Console.WriteLine("Rendimento sobre investimento: R$ " + obj.vlucro().ToString("F2"));

            double bruto = 0;
                bruto = obj.vlucro() + obj.valor;

            Console.WriteLine("Rendimento Bruto: R$ " + bruto);
            Console.WriteLine("Imposto sobre o Lucro: R$ " + imposto.ToString("F2"));

            double resultado = 0;
                resultado = obj.vlucro() - imposto + obj.valor;

            Console.WriteLine("Rendimento Liquido: R$ " + resultado.ToString("F2"));
            Console.WriteLine("");
            Console.ReadKey();

        }
    }
}
