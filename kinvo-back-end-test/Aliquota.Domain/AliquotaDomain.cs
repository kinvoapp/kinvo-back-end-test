using System;

namespace Aliquota.Domain
{
    public class AliquotaDomain
    {
        public int Id { get; set; }
        public string Costumer { get; set; }
        public double TotalValueApplication { get; set; }
        public DateTime DateApplication { get; set; }
        public DateTime DateRetired { get; set; }
        public double Profit { get; set; }
        public double DiscountValueIR { get; set; }


        public static AliquotaDomain InsertData()
        {
            DateTime dateRandom = DateRandom();
            var qntMonthApplied = Convert.ToInt32((DateTime.Now.Date - dateRandom.Date).TotalDays / 30.417);
            AliquotaDomain aliquota = new AliquotaDomain
            {
                Id = new Random().Next(),
                Costumer = "Costumer Test",
                DateApplication = dateRandom,
                DateRetired = DateTime.Now.Date,
                TotalValueApplication = MonthlyContributionValue() * qntMonthApplied
            };
            return aliquota;
        }

        static DateTime DateRandom()
        {
            Random rndNum = new Random();
            var Day = new Random().Next(1, 31);
            var month = new Random().Next(1, 12);
            var year = new Random().Next(1990, 2025);
            return new DateTime(year, month, Day).ToLocalTime();
        }

        static double MonthlyContributionValue()
        {
            double MinWage = 1100.00;
            double rate = 0.09;
            double appliedValue = MinWage * rate;
            return appliedValue;
        }

        public static double FinancialProductCalculation(AliquotaDomain aliquota)
        {
            aliquota.Profit = aliquota.TotalValueApplication * 0;
            if(aliquota.TotalValueApplication <= 1000)
            {
                double rate = 0.010;
                aliquota.Profit = aliquota.TotalValueApplication * rate;
            }
            if (aliquota.TotalValueApplication > 1000 && aliquota.TotalValueApplication <= 10000)
            {
                double rate = 0.07;
                aliquota.Profit = aliquota.TotalValueApplication * rate;
            }
            if (aliquota.TotalValueApplication > 10000 && aliquota.TotalValueApplication <= 99999)
            {
                double rate = 0.05;
                aliquota.Profit = aliquota.TotalValueApplication * rate;
            }
            if (aliquota.TotalValueApplication > 99999)
            {
                double rate = 0.03;
                aliquota.Profit = aliquota.TotalValueApplication * rate;
            }
            return aliquota.Profit;
        } //Defines the rate applied to the total amount to obtain the profit

        public static double IRCalculation(AliquotaDomain aliquota)
        {
            var qntYearApplied = Convert.ToInt32((DateTime.Now.Date - aliquota.DateApplication).TotalDays / 30.417) / 12;
            if (qntYearApplied == 0 || qntYearApplied < 0)
            {
                Console.WriteLine("A aplicação não pode ser igual ou menor que zero");                
            }
            if (qntYearApplied <= 1) // Up to 1 year of application: 22.5% on profit
            {
                double rate = 0.225;
                aliquota.DiscountValueIR = aliquota.Profit * rate;
            }
            if (qntYearApplied > 1 && qntYearApplied <= 2) //From 1 to 2 years of application: 18.5 % on profit
            {
                double rate = 0.185;
                aliquota.DiscountValueIR = aliquota.Profit * rate;
            }
            if (qntYearApplied > 2) //Above 2 years of application: 15% on profit
            {
                double rate = 0.15;
                aliquota.DiscountValueIR = aliquota.Profit * rate;
            }
            return aliquota.DiscountValueIR;
        }
    }
}
