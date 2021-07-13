using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.CrossCutting
{
    public class CalculateMethods
    {
        User user = new User();
        public double calculateInvestedTime(DateTime startInvestment)
        {
            var finishInvestment = DateTime.Now;
            TimeSpan investedTime = finishInvestment.Subtract(startInvestment);
            var investedTimeInYears = (investedTime.TotalDays) / 365;
            

            return investedTimeInYears;
        }

        public double calculateContribution(double capital, DateTime startInvestment)
        {
            
            var timeInvested = calculateInvestedTime(startInvestment);
            var inicialContribution = capital / ((1 + 1.18) * timeInvested); 

            return inicialContribution;
        }

        public double calculateProfit(double capital, DateTime startInvestment)
        {
            var inicialContribution = calculateContribution(capital, startInvestment);
            var profit = capital - inicialContribution;

            return profit;
        }
    }
}
