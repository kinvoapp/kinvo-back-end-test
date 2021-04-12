using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio.Comunicacao
{
    public class AplicacaoComunicacao
    {
        public double ColetarValidarValorAplicacao(string valor)
        {
            if (valor.Contains('.'))
                valor = valor.Replace('.', ',');

            try
            {
                double resultado = Convert.ToDouble(valor);

                if (resultado <= 0)
                {
                    Console.WriteLine("Valor invalido!\n");
                    Console.WriteLine("Tente novamente:");
                    return 0;
                }
                return resultado;
            }
            catch
            {
                Console.WriteLine("Formato invalido!\n");
                Console.WriteLine("Tente novamente:");
                return 0;
            }

           
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

        public DateTime ColetarValidarDataInvestimento (DateTime apl)
        {
            Console.WriteLine("\nQual a data da aplicacao?\n Ex: dd/MM/aaaa");
            string resposta = Console.ReadLine();

            if (resposta.Contains('.'))
                resposta = resposta.Replace('.', ',');

            while (true)
            {
                try
                {
                    DateTime inv = DateTime.Parse(resposta);

                    if(DateTime.Compare(inv, apl) < 0)
                    {
                        Console.WriteLine("A data do investimento tem que ser posterior a data de aplicacao, tente novamente");
                        resposta = Console.ReadLine();
                        continue;
                    }

                    return inv;
                }
                catch
                {
                    Console.WriteLine("Formato invalido!\n");
                    Console.WriteLine("Tento novamente:");
                    resposta = Console.ReadLine();
                }
            }

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
                foreach(Historicos h in app.Hisotricos)
                {
                    Console.WriteLine("\nHistorico de investimento:");
                    Console.WriteLine("\n\tID: {0}", h.Id);
                    Console.WriteLine("\tValor: {0}", h.Valor);
                    Console.WriteLine("\tData: {0}\n\n", h.Data.ToShortDateString());

                }
            }
        }

    }
}
