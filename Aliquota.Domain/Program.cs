
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            ResgatarUsandoEntity();
        }

        private static void ResgatarUsandoEntity()
        {
            using (var repo = new KinvoContext())
            {
                IList <Investimento> investimentos = repo.INVESTIMENTOS.ToList();
                foreach (var item in investimentos)
                {
                    Console.WriteLine (item.TempoEmAnos);
                    Console.WriteLine(item.Lucro);
                    if ((item.TempoEmAnos) <= 1)
                    {
                        Console.WriteLine ((item.Lucro)*0.225);
                    }
                    else if ((item.TempoEmAnos) > 1 && (item.TempoEmAnos) <= 2)
                    {
                        Console.WriteLine((item.Lucro) * 0.185);
                    }
                    else if ((item.TempoEmAnos) > 2)
                    {
                        Console.WriteLine((item.Lucro) * 0.15);
                    }


                    Console.ReadLine();
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Investimento a = new Investimento();
            a.Id = 1;
            a.Lucro = 1000;
            a.TempoEmAnos = 1;
            a.TempoEmDias = 365;
            //a.DataDeInicio = 2020 - 1 - 1;
            //a.DataDeResgate = 2021 - 1 - 1;

            Investimento b = new Investimento();
            b.Id = 2;
            b.Lucro = 1000;
            b.TempoEmAnos = 2;
            b.TempoEmDias = 730;
            //b.DataDeInicio = 2019 - 1 - 1;
            //b.DataDeResgate = 2021 - 1 - 1;

            Investimento c = new Investimento();
            c.Id = 3;
            c.Lucro = 1000;
            c.TempoEmAnos = 3;
            c.TempoEmDias = 1095;
            //c.DataDeInicio = 2018 - 1 - 1;
            //c.DataDeResgate = 2021 - 1 - 1;

            using (var contexto = new KinvoContext())
            {
                contexto.INVESTIMENTOS.Add(a);
                contexto.INVESTIMENTOS.Add(b);
                contexto.INVESTIMENTOS.Add(c);
                contexto.SaveChanges();
            }
        }
    }
}


