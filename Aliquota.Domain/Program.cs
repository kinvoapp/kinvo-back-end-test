using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Aliquota.Domian
{
    class Program
    {
        static void Main(string[] args)
        {
            GravarUsandoAdoNet();
        }

        private static void GravarUsandoAdoNet()
        {
            /*Investimento i = new Investimento();
            i.Lucro = 1000.0;
            i.Tempo = 200; // > 1 ano*/

            /*Investimento j = new Investimento();
            i.Lucro = 1000.0;
            i.Tempo = 400; //1 - 2 anos*/

            /*Investimento jk = new Investimento();
            i.Lucro = 1000.0;
            i.Tempo = 3650; //10 anos*/

            Investimento i = new Investimento();
            i.Lucro = 1000.0;
            i.TempoTotal = 800;


            using (var repo = new InvestimentoDOA()) 
            {
                repo.Adicionar(i);
            }
        }

        /*private static void RecuperaLucro()
        {
            using (var repo = IList < Investimento > Investimento())
            {
                IList<Dormian.Investimento> investimentos = Investimentos.ToList();

                foreach (var item in investimentos)
                {
                    Console.WriteLine(item.Lucro);
                }
            }
        }
        private static void RecuperaTempoTotal()
        {
            using (var repo = new Investimento())
            {
                IList<Dormian.Investimento> investimentos = Investimentos.ToList();

                foreach (var item in investimentos)
                {
                    Console.WriteLine(item.TempoTotal);
                }
            }
        }*/
    }
}


