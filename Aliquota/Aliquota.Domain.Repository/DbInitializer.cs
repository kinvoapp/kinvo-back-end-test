using Aliquota.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain.Repository
{
    public static class DbInitializer
    {

        public static void Initialize(AliquotaContext context)
        {
            context.Database.EnsureCreated();
           
            if (context.CLIENTES.Any())
            {
                return;   // DB has been seeded
            }

            var clientes = new Cliente[]
            {
            new Cliente{Nome="Carson",Cpf="605.004.728-66"},
            new Cliente{Nome="Meredith",Cpf="508.340.308-02"},
            new Cliente{Nome="Arturo",Cpf="686.080.088-74"},
            new Cliente{Nome="Gytis",Cpf="407.155.358-89"},
            new Cliente{Nome="Yan",Cpf="882.435.848-97"},
            new Cliente{Nome="Peggy",Cpf="899.166.408-31"},
            new Cliente{Nome="Laura",Cpf="122.795.518-96"},
            new Cliente{Nome="Nino",Cpf="971.696.118-99"}
            };
            foreach (Cliente c in clientes)
            {
                context.CLIENTES.Add(c);
            }
            context.SaveChanges();

            var investimentos = new Investimento[]
            {
            new Investimento{VlInvest=132,DataAplicacao=new DateTime(2020,12,02), ClienteID = 1, PercentLucro = 0.5M},
            new Investimento{VlInvest=2123,DataAplicacao=new DateTime(1999,10,03), ClienteID = 2, PercentLucro = 0.8M},
            new Investimento{VlInvest=4572,DataAplicacao=new DateTime(2000,03,12), ClienteID = 3, PercentLucro = 0.2M},
            new Investimento{VlInvest=9873,DataAplicacao=new DateTime(2015,01,15), ClienteID = 4, PercentLucro = 0.5M},
            new Investimento{VlInvest=15987,DataAplicacao=new DateTime(1996,04,19), ClienteID = 5, PercentLucro = 0.5M},
            new Investimento{VlInvest=100,DataAplicacao=new DateTime(2019,12,30), ClienteID = 6, PercentLucro = 0.9M},
            new Investimento{VlInvest=1765,DataAplicacao=new DateTime(2019,01,01), ClienteID = 7, PercentLucro = 0.4M},
            new Investimento{VlInvest=200,DataAplicacao=new DateTime(2018,09,01), ClienteID = 8, PercentLucro = 0.5M}
            };
            foreach (Investimento n in investimentos)
            {
                context.INVESTIMENTOS.Add(n);
            }
            context.SaveChanges();          
        }
    }
}

