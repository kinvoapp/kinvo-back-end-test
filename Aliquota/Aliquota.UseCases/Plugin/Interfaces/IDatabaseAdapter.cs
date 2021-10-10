using Aliquota.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.Plugin.Interfaces
{
    public interface IDatabaseAdapter
    {
        Decimal GetFinanceProductCurrentPrice(FinanceProduct product);
        FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct);
        Boolean RestrictFinanceProductTrade(FinanceProductMove fromA, decimal amountA, FinanceProduct toB, decimal amountB);
        Boolean RestrictFinanceProductBuy(User user, FinanceProduct financeproduct, decimal amountB);
        User GetOwnerFromFinanceProductMove(FinanceProductMove fromA);
        FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove fromA);
    }
}
