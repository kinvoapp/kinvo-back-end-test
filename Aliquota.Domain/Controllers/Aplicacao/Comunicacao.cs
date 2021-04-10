using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Controllers.Aplicacao
{
    class Comunicacao
    {
        public double ColetarValidarValorAplicacao(double valor)
        {
            Console.WriteLine("\nQual o valor da aplicacao?\n Ex: 540.50");
            string resposta = Console.ReadLine();

            while (valor <= 0)
            {
                try
                {
                    return valor = double.Parse(resposta);
                }
                catch
                {
                    Console.WriteLine("Formato invalido!\n");
                    Console.WriteLine("Tento novamente:");
                    resposta = Console.ReadLine();
                }
            }

            return 0;
        }

        public DateTime ColetarValidarDataAplicacao(DateTime data)
        {
            Console.WriteLine("\nQual a data da aplicacao?\n Ex: dd/MM/aaaa");
            string resposta = Console.ReadLine();

            while (DateTime.Compare(data, new DateTime()) == 0)
            {
                try
                {
                    return data = DateTime.Parse(resposta);
                }
                catch
                {
                    Console.WriteLine("Formato invalido!\n");
                    Console.WriteLine("Tento novamente:");
                    resposta = Console.ReadLine();
                }
            }
            return new DateTime();
        }

        public double ColetarValidarRentabilidadeAplicacao(double rent)
        {
            Console.WriteLine("\nQual a rentabilidade por mes?\n Ps: Nao e necessario escrever o simbolo de %");
            string resposta = Console.ReadLine();

            while (rent == 0)
            {
                try
                {
                    return double.Parse(resposta);
                }
                catch
                {
                    Console.WriteLine("Formato invalido!\n");
                    Console.WriteLine("Tento novamente:");
                    resposta = Console.ReadLine();
                }
            }
            return 0;
        }

        public void DetalharAplicacao(Aplicacoes app)
        {
            Console.Clear();
            Console.WriteLine("\nSituacao atual:");
            Console.WriteLine("\n\n\tID: {0}", app.Id);
            Console.WriteLine("\tValor: {0}", app.Valor);
            Console.WriteLine("\tRentabilidade/mes: {0}%", app.Rentabilidade_Mes);
            Console.WriteLine("\tData: {0}", app.Data.ToShortDateString());

            if (app.Hisotricos.Count > 0)
            {
                Console.WriteLine("\nHistorico de investimento:");
                Console.WriteLine("\n\n\tID: {0}", app.Id);
                Console.WriteLine("\tValor: {0}", app.Valor);
                Console.WriteLine("\tData: {0}\n\n", app.Data.ToShortDateString());
            }
        }

    }
}
