using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.CrossCutting
{
    public class Rescue
    {
        public double rescue(double Capital, DateTime InvestmentDayZero)
        {
            CalculateMethods invTime = new CalculateMethods();
            double investedTimeInYears = invTime.calculateInvestedTime(InvestmentDayZero);
            double profits = invTime.calculateProfit(Capital, InvestmentDayZero);
            double capitalWithoutProfits = invTime.calculateContribution(Capital, InvestmentDayZero);
            double rescuedValue = 0;

            if (investedTimeInYears <= 1)
            {
                rescuedValue = (profits * 0.775) + capitalWithoutProfits;
            } 
            else if (investedTimeInYears > 1 && investedTimeInYears <= 2)
            {
                rescuedValue = (profits * 0.815) + capitalWithoutProfits;
            }
            else if (investedTimeInYears > 2)
            {
                rescuedValue = (profits * 0.85) + capitalWithoutProfits;
            }
            return rescuedValue;
        }
    }
}
