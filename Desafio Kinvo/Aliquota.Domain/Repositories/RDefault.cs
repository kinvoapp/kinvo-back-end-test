using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

namespace Aliquota.Domain.Repository
{
    public class RDefault
    {
        Context context;

        public RDefault()
        {
            context = new Context();
        }

        public Investment Add(Investment investment)
        {

            context.Entry(investment);

            if (investment.period < 12)
            {
                investment.tax = (decimal)0.225;
            }
            else if ((investment.period >= 12) && (investment.period < 24))
            {
                investment.tax = (decimal)0.185;
            }
            else if (investment.period > 24)
            {
                investment.tax = (decimal)0.15;
            }

            for (int i = 0; i < investment.period; i++)
            {
                if (i == 0) investment.amount = investment.amountBegin;

                decimal gain = investment.amount * (decimal)0.005;
                investment.amount += (decimal)gain;
            }

            investment.gain = investment.amount - investment.amountBegin;
            investment.canRecover = investment.amount - (investment.gain * investment.tax);
            investment.tax *= 100;
            investment.started = DateTime.Now;

            context.Set<Investment>().Add(investment);
            context.SaveChanges();

            return investment;

        }

        public void Update(Investment investment)
        {
            var origin = context.Set<Investment>().Find(investment.id);

            context.Entry(origin).CurrentValues.SetValues(investment);

            context.SaveChanges();

        }

        public List<Investment> GetList()
        {
            return context.Set<Investment>().ToList();
        }

        public string ValInfo(Investment investment)
        {
            if ((investment.nickname == "" ) || 
                (investment.amountBegin <= 0) ||
                (investment.period <= 0))
            
                return "Investimento Inválido!";

            else

                return "Novo investimento adcicionado!";
        }

        public Investment Remove(int id)
        {

            Investment investment = context.Set<Investment>().Find(id);
            
            if (investment == null) return null;

            if(investment.started > DateTime.Now)
            context.Investments.Remove(investment);


            context.SaveChanges();
            return investment;
        }
    }
}
