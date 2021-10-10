using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;

namespace Aliquota.UseCases.ProductMovement
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
        Boolean TradeFinanceProductMove(FinanceProductMove FromA, Decimal Amount, FinanceProduct ToB, IDatabaseAdapter DatabaseAdapter, IStockMarket stockMarketAdapter)
        {
            User owner = DatabaseAdapter.GetOwnerFromFinanceProductMove(FromA);
            if (!DoesMoveHasEnoughtProduct(owner, Amount, ToB, DatabaseAdapter))
                return false;
            FinanceProduct financeProductA = DatabaseAdapter.GetFinanceProductFromFinanceProductMove(FromA);
            Decimal priceA = stockMarketAdapter.GetProductValue(financeProductA);
            Decimal priceB = stockMarketAdapter.GetProductValue(ToB);
            Decimal amountB = ConvertAmountAToAmountB(priceA, Amount, priceB);
            return DatabaseAdapter.RestrictFinanceProductTrade(FromA, Amount, ToB, amountB);
            
        }
    }
}