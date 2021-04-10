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
