using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Aliquota.Domain.Services
{
    public static class AliquotaCalc
    {
        private static double _oneYear = 0.225f;
        private static double _oneToTwoYear = 0.185f;
        private static double _twoYear = 0.15f;
        public static int MonthQuantity(DateTime sample, DateTime investmentDay)
        {
            return (sample.Month - investmentDay.Month) + ((sample.Year - investmentDay.Year) * 12);
        }

        public static double CalculateProfit(int amountOfMonths, double startedAmount)
        {
            double actualProfit = startedAmount;
            for (int i = 0; i < amountOfMonths; i++)
            {
                actualProfit = actualProfit + actualProfit * 0.05;
            }
            actualProfit -= startedAmount;
            return actualProfit;
        }

        public static double ProfitOneYear(double profit)
        {
            return profit * _oneYear;
        }

        public static string ProfitOneYearString(double profit)
        {
            return ProfitOneYear(profit).ToString("F2", CultureInfo.InvariantCulture);
        }

        public static double ProfitOneToTwoYear(double profit)
        {
            return profit * _oneToTwoYear;
        }

        public static string ProfitOneToTwoYearString(double profit)
        {
            return ProfitOneToTwoYear(profit).ToString("F2", CultureInfo.InvariantCulture);
        }

        public static double ProfitTwoYear(double profit)
        {
            return profit * _twoYear;
        }

        public static string ProfitTwoYearString(double profit)
        {
            return ProfitTwoYear(profit).ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
