using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities
{
    public class ProductApplication
    {
        public Guid ProductApplicantionID { get; set; }
        public Guid ClientID { get; set; }
        public Guid FinancialProductID { get; set; }
        public DateTime DateApplicantion { get; set; }
        public AmountMoney AmountMoney { get; set; }


        public ProductApplication(Guid productApplicationID, Guid clientID, Guid financialProductID, DateTime dateApplication, AmountMoney amountMoney)
        {
            ProductApplicantionID = productApplicationID;
            ClientID = clientID;
            FinancialProductID = financialProductID;
            DateApplicantion = dateApplication;
            AmountMoney = amountMoney;
        }


    }
}
