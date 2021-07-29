using Model.Domain.Entities;
using Model.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.Data.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(AliquotaDomainContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any() && context.Investments.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{Name="Carson",Cpf="984.461.546-84",Email="carson@gmail.com", Password="12345678", Capital=1200},
            new User{Name="Meredith",Cpf="156.485.189-41",Email="meredith@gmail.com", Password="12345678", Capital=1500.85},
            new User{Name="Arturo",Cpf="494.564.489-78",Email="arturo@gmail.com", Password="12345678", Capital=100004.3},
            new User{Name="Gytis",Cpf="456.158.451-15",Email="gytis@gmail.com", Password="12345678", Capital=10000.43 },
            new User{Name="Yan",Cpf="123.456.789-00",Email="yan@gmail.com", Password="12345678", Capital=1200000},
            new User{Name="Peggy",Cpf="987.654.321-00",Email="peggy@gmail.com", Password="12345678", Capital=120.00},
            new User{Name="Laura",Cpf="485.548.785-85",Email="laura@gmail.com", Password="12345678", Capital=1200.00},
            new User{Name="Nino",Cpf="456.123.789-00",Email="nino@gmail.com", Password="12345678", Capital=1.200}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var investments = new Investment[]
            {
            new Investment{Cpf="984.461.546-84", Capital=1200, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="156.485.189-41", Capital=1500.85, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="494.564.489-78", Capital=10000.43, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="456.158.451-15", Capital=10000.43, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="123.456.789-00", Capital=1200000, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="987.654.321-00", Capital=12000, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="485.548.785-85", Capital=1200.00, InvestmentDayZero=DateTime.Today},
            new Investment{Cpf="456.123.789-00", Capital=1.200, InvestmentDayZero=DateTime.Today}
            };
            foreach (Investment i in investments)
            {
                context.Investments.Add(i);
            }
            context.SaveChanges();
        }
    }
}
