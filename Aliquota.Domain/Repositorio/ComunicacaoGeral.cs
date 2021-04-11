using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio
{
    class ComunicacaoGeral
    {
        public void Menu()
        {
            Console.WriteLine("\n\n\tBem-vindo :D");
            Console.WriteLine("\n\tOque deseja fazer hoje?");
            Console.WriteLine("\n 1 - Fazer nova aplicação");
            Console.WriteLine("\n 2 - Fazer novo resgate");
            Console.WriteLine("\n 3 - Ver aplicacoes");
            Console.WriteLine("\n 4 - Ver resgates");
            Console.WriteLine("\n q - Sair");
        }

        public void TabelaDeAplicacao(List<Aplicacoes> app)
        {
            Console.WriteLine("\n\n\t\t\t\t\t\tEssas sao suas aplicacoes\n");
            Console.WriteLine("\tID |\t\tValor\t\t|\tRentabilidade/Mes\t|\t Data da ultima aplicacao");
            Console.WriteLine("________________________________________________________________________________________________________");
            if (app.Count > 0)
                foreach (Aplicacoes a in app)
                {
                    Console.WriteLine("\t{0}\t\t{1}\t\t\t{2}%\t\t\t\t{3}", a.Id, a.Valor.ToString("C"), a.Rentabilidade_Mes, a.Data.ToShortDateString());
                    Console.WriteLine("________________________________________________________________________________________________________");
                }
            else
                Console.WriteLine("Voce nao possui aplicacoes");
        }


    }


}
