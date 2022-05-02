using Aliquota.Domain.Entities;
using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Factories
{
    class WalletFactory
    {
        public Wallet BuildNewWallet(Guid clientID, string amountMoney)
        {
            AmountMoney _amountMoney = new AmountMoney(double.Parse(amountMoney));
            Wallet wallet = new Wallet(clientID, _amountMoney);
            return wallet;
        }
    }
}
