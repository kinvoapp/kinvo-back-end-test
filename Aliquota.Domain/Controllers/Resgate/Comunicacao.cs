using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Controllers.Resgate
{
    class Comunicacao
    {
        public void DetalharResgates(Aplicacoes app, Resgates resgate, int totalMeses)
        {
            Console.Clear();
            Console.WriteLine("\nDados importantes:");
            Console.WriteLine("\n\n\tID: {0}", app.Id);
            Console.WriteLine("\tValor atual da aplicacao: {0}", app.Valor.ToString("C"));
            Console.WriteLine("\tRentabilidade/mes: {0}%", app.Rentabilidade_Mes);
            Console.WriteLine("\tData da ultima aplicacao: {0}", app.Data.ToShortDateString());
            Console.WriteLine("\tData do resgate: {0}", resgate.Data.ToShortDateString());
            Console.WriteLine("\tPeriodo de aplicacao (em meses): {0}", totalMeses);
            Console.WriteLine("\tLucro: {0}", resgate.Lucro.ToString("N2"));
            Console.WriteLine("\tValor de IR pago: {0}", resgate.Valor_IR.ToString("C"));
            Console.WriteLine("\tValor a ser resgatado: {0}", (app.Valor + resgate.Lucro).ToString("C"));
        }

        public DateTime ColetarValidarDataResgate(DateTime data, DateTime dataAplicacao)
        {
            Console.WriteLine("\nQual a data do resgate?\n Ex: dd/MM/aaaa");
            string resposta = Console.ReadLine();

            while (DateTime.Compare(data, new DateTime()) == 0 && DateTime.Compare(data, dataAplicacao) < 0)
            {
                try
                {
                    data = DateTime.Parse(resposta);
                    if(DateTime.Compare(data, dataAplicacao) < 0)
                    {
                        Console.WriteLine("A data do resgate precisa ser posterior a aplicacao");
                        resposta = Console.ReadLine();
                        data = new DateTime();
                        continue;
                    }
                    return data;
                }
                catch
                {
                    Console.WriteLine("Formato ou data invalida\n");
                    Console.WriteLine("Tento novamente:");
                    resposta = Console.ReadLine();
                }
            }
            return new DateTime();
        }

        public void TabelaResgates(List<Resgates> resgates)
        {
            Console.WriteLine("\n\n\t\t\t\t\t\tEssas sao seus resgates\n");
            Console.WriteLine("\tID |\tValor Retirado\t|\tValor IR\t|\t Lucro\t\t|\tData de retirada");
            Console.WriteLine("________________________________________________________________________________________________________");
            if (resgates.Count > 0)
                foreach (Resgates r in resgates)
                {
                    Console.WriteLine("\t{0}\t{1}\t\t{2}\t\t\t{3}\t\t\t{4}", r.Id, r.Valor_Retirado.ToString("C"),r.Valor_IR.ToString("C"), r.Lucro.ToString("C"), r.Data.ToShortDateString());
                    Console.WriteLine("________________________________________________________________________________________________________");
                }
            else
                Console.WriteLine("Voce nao possui resgates");
        }
    }
}
