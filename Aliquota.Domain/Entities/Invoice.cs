using Aliquota.Domain.Entities.Exceptions;
using System;
using System.Globalization;

namespace Aliquota.Domain.Entities
{
    public class Invoice
    {

        public DateTime InitialDate { get; set; }
        public DateTime RedeemDate{ get; set; }
        public Investment Investment { get; set; }
        

        public Invoice(DateTime initialDate, DateTime redeemDate, Investment investment)
        {
            InitialDate = initialDate;
            RedeemDate = redeemDate;
            Investment = investment;
            if (redeemDate < initialDate)
            {
                throw new CalculateException("Final date cannot be earlier than the start date.");
            }
        }

        public double Redeem
        {
            get
            {
                return Investment.InitialAmount + (Investment.Profit - Investment.Interest);
            }
        }

        public override string ToString()
        {
            return "Initial Investment: "
                + Investment.InitialAmount.ToString("F2", CultureInfo.InvariantCulture)
                + "\nProfit: "
                + Investment.Profit.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: "
                + Investment.Interest.ToString("F2", CultureInfo.InvariantCulture)
                + "\nAmount Redeemed: "
                + Redeem.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}