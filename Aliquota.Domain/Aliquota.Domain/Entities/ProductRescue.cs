using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities
{
    public class ProductRescue
    {
        public Guid ProductApplicationID { get; set; }
        public DateTime DateRescue { get; set; }

        public ProductRescue(Guid productApplicationID, DateTime dateRescue)
        {
            ProductApplicationID = productApplicationID;
            DateRescue = dateRescue;
        }

        public double RescueMoneyOnApplication(double money, double percentage, DateTime dateApplication)
        {
            var diferenceDaysOnApplicationAndRescue = (DateRescue - dateApplication).Days;
            double percentageByDay = percentage / 365;
            double moneyEarnedApplication = money * (percentageByDay * diferenceDaysOnApplicationAndRescue);
            double taxBeforeOneYear = (77.5 / 100);
            double taxAfterOneYear = (81.5 / 100);
            double taxAfterTwoYears = (85 / 100);


            if (diferenceDaysOnApplicationAndRescue < 365)
            {
                double profitMoneyApplication = moneyEarnedApplication - money;
                profitMoneyApplication = profitMoneyApplication * taxBeforeOneYear;
                money = money + profitMoneyApplication;
                return money;

            }
            else if(diferenceDaysOnApplicationAndRescue >= 365 || diferenceDaysOnApplicationAndRescue <= 730)
            {
                double profitMoneyApplication = moneyEarnedApplication - money;
                profitMoneyApplication = profitMoneyApplication * taxAfterOneYear;
                money = money + profitMoneyApplication;
                return money;

            }
            else
            {
                double profitMoneyApplication = moneyEarnedApplication - money;
                profitMoneyApplication = profitMoneyApplication * taxAfterTwoYears;
                money = money + profitMoneyApplication;
                return money;

            }

        }
    }
}
