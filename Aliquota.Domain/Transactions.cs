using System;

namespace Aliquota.Domain
{
    public static class Transactions
    {
        public static decimal CalculateIncomeTax(float yearsFromApplication)
        {
            if (0 < yearsFromApplication && yearsFromApplication <= 1)
                return 22.5m / 100;
            else if (1 < yearsFromApplication && yearsFromApplication <= 2)
                return 18.5m / 100;
            else if (2 < yearsFromApplication)
                return 15m / 100;

            else return 0;
        }

        public static decimal CalculateProfitability(int expectedMonthlyPeriod, double monthlyInterestRate)
        {
            var rentability = Math.Pow((1 + (monthlyInterestRate / 100)), expectedMonthlyPeriod);
            return (decimal)Math.Round(rentability, 2);
        }
    }
}
