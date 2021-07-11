using System;

namespace Aliquota.Domain.Services
{
    public class InvestmentService
    {
        public decimal CheckIncomeTaxPercentage(DateTime date)
        {
            var d = date.Date;
            var totalDays = CalculateDate(d);
            if(totalDays <= 365)
            {
                return 0.225M;
            }
            else if(totalDays > 365 && totalDays <= 730)
            {
                return 0.185M;
            }
            else
            {
                return 0.15M;
            }

        }

        public decimal CalculateIncomeTaxDiscount(decimal percentage, decimal value)
        {
            return value * percentage;
        }

        public decimal CalculateProfit(DateTime date, decimal value)
        {
            var days = CalculateDate(date);

            var profitByDay = 0.0113698630136986M;

            return (value * (profitByDay/100)) * days;
        }

        public int CalculateDate(DateTime date)
        {
            return (int)DateTime.Now.Date.Subtract(date).TotalDays;
        }
    }
}
