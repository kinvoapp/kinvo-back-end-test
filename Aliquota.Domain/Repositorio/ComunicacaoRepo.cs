using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio
{
    class ComunicacaoRepo
    {
        public void Menu()
        {
            Console.WriteLine("\n\n\tBem-vindo :D");
            Console.WriteLine("\n\tOque deseja fazer hoje?");
            Console.WriteLine("\n1 - Fazer nova aplicação");
            Console.WriteLine("\n2 - Fazer retirada");
            Console.WriteLine("\n3 - Ver movimentação");
            Console.WriteLine("\nq - Sair");
        }

        public void TabelaDeAplicacao(List<Aplicacoes> app)
        {
            Console.WriteLine("\n\n\t\t\t\t\t\tEssas sao suas aplicacoes\n");
            Console.WriteLine("\tID |\t\tValor\t\t|\tRentabilidade/Mes\t|\t Data de aplicacao");
            Console.WriteLine("________________________________________________________________________________________________________");
            if (app.Count > 0)
                foreach (Aplicacoes a in app)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t\t\t{2}%\t\t\t\t{3}", a.Id, a.Valor, a.Rentabilidade_Mes, a.Data.ToShortDateString());
                    Console.WriteLine("________________________________________________________________________________________________________");
                }
            else
                Console.WriteLine("Voce nao possui Aplicacoes");
        }

        public void DetalharAplicacao(Aplicacoes app)
        {
            Console.Clear();
            Console.WriteLine("\nSituacao atual:");
            Console.WriteLine("\n\n\tID: {0}", app.Id);
            Console.WriteLine("\tValor: {0}", app.Valor);
            Console.WriteLine("\tRentabilidade/mes: {0}", app.Rentabilidade_Mes);
            Console.WriteLine("\tData: {0}", app.Data.ToShortDateString());

            if(app.Hisotricos.Count > 0)
            {
                Console.WriteLine("\nHistorico de investimento:");
                Console.WriteLine("\n\n\tID: {0}", app.Id);
                Console.WriteLine("\tValor: {0}", app.Valor);
                Console.WriteLine("\tData: {0}\n\n", app.Data.ToShortDateString());
            }
        }

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

    }


}
