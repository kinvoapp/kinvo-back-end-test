using Aliquota.Domain.Entities;
using System;

namespace Aliquota.Domain.Services
{
    public class CalculateService
    {
        public double ProfitRate { get; set; }
        public double TaxRate { get; set; }

        public ITaxService _taxService;

        public CalculateService(double profitRate, ITaxService taxService)
        {
            ProfitRate = profitRate;
            _taxService = taxService;
        }

        public void ProcessInvoice(Invoice invoice)
        {
            TimeSpan duration = invoice.RedeemDate.Subtract(invoice.InitialDate);
            double finalAmount = invoice.Investment.InitialAmount;
            for (int i = 0; i < Math.Ceiling(duration.TotalDays) % 30; i++)
            {
                finalAmount+= (ProfitRate * finalAmount);
            }
            invoice.Investment.Profit = finalAmount - invoice.Investment.InitialAmount;
            TaxRate = _taxService.Tax(duration);
            invoice.Investment.Interest = (invoice.Investment.Profit * TaxRate);
            Console.WriteLine(invoice.ToString());
        }
    }
}
