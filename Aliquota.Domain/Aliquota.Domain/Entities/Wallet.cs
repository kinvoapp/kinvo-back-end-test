using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities
{
    public class Wallet
    {
        public Guid ClientID { get; set; }
        public AmountMoney AmountMoney { get; set; }

        public Wallet(Guid client, AmountMoney amountMoney)
        {
            ClientID = client;
            AmountMoney = amountMoney;

        }

        public bool InsertClientMoney(double clientMoney)
        {

            if (clientMoney <= 0)
            {
                return false;
            }
            else
            {
                
                AmountMoney.Money = AmountMoney.Money + clientMoney;
                return true;
            }

        }

        public bool DrawClientMoney(string drawClientMoney)
        {
            double moneyValue = double.Parse(drawClientMoney);
            if (AmountMoney.Money < moneyValue)
            {
                return false;
            }
            else
            {
                
                AmountMoney.Money = AmountMoney.Money - moneyValue;
                return true;
            }
        }
    }
}
