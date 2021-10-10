using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;

namespace Aliquota.UseCases.ProductMovement
{
    public static class MakeFinanceProductMove
    {

        public static Boolean DoesMoveHasEnoughtProduct(User user, Decimal amount, FinanceProduct financeProduct, IDatabaseAdapter databaseAdapter)
        {
            var wallet = databaseAdapter.GetFinanceProductWallet(user, financeProduct);
            if (wallet == null) return false;
            Decimal UsersFPBalance = wallet.Amount;
            return (UsersFPBalance >= amount);
        }

        private static bool DoesMoveHasEnoughtProduct(FinanceProductMove fromA, decimal amount, IDatabaseAdapter databaseAdapter)
        {
            return fromA.Amount >= amount;
        }
        public static Decimal ConvertAmountAToAmountB(Decimal priceA, Decimal amountA, Decimal priceB)
        {
            return amountA * (priceA / priceB);
        }
        public static Boolean TradeFinanceProductMove(FinanceProductMove fromA, Decimal amount, FinanceProduct toB, IDatabaseAdapter databaseAdapter, IStockMarket stockMarketAdapter)
        {
            if (fromA.CurrentAmount < amount)
                return false;
            FinanceProduct financeProductA = databaseAdapter.GetFinanceProductFromFinanceProductMove(fromA);
            Decimal priceA = stockMarketAdapter.GetProductValue(financeProductA);
            Decimal priceB = stockMarketAdapter.GetProductValue(toB);
            Decimal amountB = ConvertAmountAToAmountB(priceA, amount, priceB);
            return databaseAdapter.RestrictFinanceProductTrade(fromA, amount, toB, amountB) != null;
        }

    }
}