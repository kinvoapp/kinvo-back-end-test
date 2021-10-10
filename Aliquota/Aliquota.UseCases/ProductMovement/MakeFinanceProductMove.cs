using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.NewFolder
{
    public class MakeFinanceProductMove
    {

        Boolean DoesMoveHasEnoughtProduct(User User, Decimal Amount, FinanceProduct FinanceProduct, IDatabaseAdapter DatabaseAdapter)
        {
            Decimal UsersFPBalance = DatabaseAdapter.GetFinanceProductWallet(User, FinanceProduct).Amount;
            return (UsersFPBalance >= Amount);
        }
        Decimal ConvertAmountAToAmountB(Decimal PriceA, Decimal AmountA, Decimal PriceB)
        {
            return AmountA * (PriceA / PriceB);
        }
        Boolean TradeFinanceProductMove(Decimal Amount, FinanceProductMove FromA, FinanceProduct ToB, IDatabaseAdapter DatabaseAdapter)
        {
            User owner = DatabaseAdapter.GetOwnerFromFinanceProductMove(FromA);
            if (!DoesMoveHasEnoughtProduct(owner, Amount, ToB, DatabaseAdapter))
                return false;
            FinanceProduct financeProductA = DatabaseAdapter.GetFinanceProductFromFinanceProductMove(FromA);
            Decimal priceA = DatabaseAdapter.GetFinanceProductCurrentPrice(financeProductA);
            Decimal priceB = DatabaseAdapter.GetFinanceProductCurrentPrice(ToB);
            Decimal amountB = ConvertAmountAToAmountB(priceA, Amount, priceB);
            return DatabaseAdapter.RestrictFinanceProductTrade(FromA, -Amount, ToB, amountB);
            
        }
    }
}