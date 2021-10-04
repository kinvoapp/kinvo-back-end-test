using System;
using Database;
using Projeto_de_cálculo_de_IR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain
{
    internal class Resolução
    {
        public static void Main(string[] result)

        {

            decimal Imposto;

            Console.WriteLine("Informe o seu nome e sobrenome");
            string Nome = Console.ReadLine();

            Console.WriteLine("Informe o seu investimento");
            decimal Investimento = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Informe tempo de aplicação(utilize vírgula):");
            float Tempo_investido = float.Parse(Console.ReadLine());

            Console.WriteLine("Informe o seu rendimento:");
            decimal Rendimento = decimal.Parse(Console.ReadLine());


            if (Tempo_investido == 1f)
            {
                Imposto = Rendimento * 0.225m;
                Console.WriteLine(Nome + " o(a) Sr(a) investiu " + Investimento.ToString("C") + ", lucrou " + Rendimento.ToString("C") + ", então o(a) Sr(a) deverá pagar " + Imposto.ToString("C") + " de imposto.");
            }
            else if (Tempo_investido > 1f && Tempo_investido <= 2f)
            {
                Imposto = Rendimento * 0.185m;
                Console.WriteLine(Nome + " o(a) Sr(a) investiu " + Investimento.ToString("C") + ", lucrou " + Rendimento.ToString("C") + ", então o(a) Sr(a) deverá pagar " + Imposto.ToString("C") + " de imposto.");
            }
            else if (Tempo_investido > 2f)
            {
                Imposto = Rendimento * 0.15m;
                Console.WriteLine(Nome + " o(a) Sr(a) investiu " + Investimento.ToString("C") + ", lucrou " + Rendimento.ToString("C") + ", então o(a) Sr(a) deverá pagar " + Imposto.ToString("C") + " de imposto.");
            }
            else if (Rendimento <= 0 || Tempo_investido < 1f)
            {
                Console.WriteLine("Informação inválida");
            }
            else
            {
                Console.WriteLine("Informação inválida");
            }

            using (var db = new ClienteC())
            {
                var quantidade_clientes = db.Clientes.Count();
                db.Clientes.Add(new Cliente()
                {


                });
                db.SaveChanges();




            }
        }
    }
}
 