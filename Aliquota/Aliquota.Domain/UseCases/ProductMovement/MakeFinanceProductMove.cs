using Aliquota.Domain.ControllersGatewaysAndPresenters.Adapters;
using Aliquota.Domain.Entities.Models;

using Aliquota.Domain.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.UseCases.ProductMovement
{
    public static class MakeFinanceProductMove
    {
        public static FinanceProduct GetFinanceProductByName(string name, IDatabaseAdapter databaseAdapter) =>
            databaseAdapter.GetFinanceProductByName(name);
        public static FinanceProductMove BuyFinanceProduct(User owner, decimal amount, FinanceProduct financeProduct, IDatabaseAdapter databaseAdapter)
        {
            return databaseAdapter.RestrictFinanceProductBuy(owner, financeProduct, amount);
        }
        public static Boolean DoesMoveHasEnoughtProduct(User user, decimal amount, FinanceProduct financeProduct, IDatabaseAdapter databaseAdapter)
        {
            var wallet = databaseAdapter.GetFinanceProductWallet(user, financeProduct);
            if (wallet == null) return false;
            Decimal UsersFPBalance = wallet.Amount;
            return (UsersFPBalance >= amount);
        }

        private static bool DoesMoveHasEnoughtProduct(FinanceProductMove fromA, decimal amount)
        {
            return fromA.CurrentAmount >= amount;
        }
        public static decimal ConvertAmountAToAmountB(decimal priceA, decimal amountA, decimal priceB)
        {
            return amountA * (priceA / priceB);
        }

       
        //private static decimal getProfit(decimal notTaxedAmount, decimal boughtPrice, decimal boughtPrice, decimal ) 
        //{
        //    return notTaxedAmount - ConvertAmountAToAmountB(boughtPrice, amountSold, otherPrice);
        //}
        private static bool CanTradeBeTaxed(FinanceProduct product, decimal boughtPrice, decimal soldPrice, IDatabaseAdapter databaseAdapter)
        {
            return databaseAdapter.GetBRL() == product && boughtPrice < soldPrice;
        }

        //public static bool TradeFinanceProductMove(FinanceProductMove fromA, decimal amount, FinanceProduct toB, IDatabaseAdapter databaseAdapter, IStockMarket stockMarketAdapter, ITaxer taxer)
        //{
        //    if (!DoesMoveHasEnoughtProduct(fromA, amount))
        //        return false;
        //    FinanceProduct financeProductA = databaseAdapter.GetFinanceProductFromFinanceProductMove(fromA);
        //    decimal priceA = stockMarketAdapter.GetProductValue(financeProductA);
        //    decimal priceB = stockMarketAdapter.GetProductValue(toB);
        //    decimal amountB = ConvertAmountAToAmountB(priceA, amount, priceB);
        //    if(CanTradeBeTaxed(toB, fromA.Price, priceA, databaseAdapter))
		//	{
        //        decimal d = amountB - ConvertAmountAToAmountB(fromA.Price, amount, priceB);
        //        amountB = (amountB-d) + taxer.Tax(d, fromA.DateTime);
		//	}
        //    var result = databaseAdapter.RestrictFinanceProductTrade(fromA, amount, priceA, toB, amountB, priceB);
        //    
        //    return result != null;
        //}
        private static decimal GetTaxedProfit(decimal profit, DateTime timeOfBuy, ITaxer taxer)
        {
            return taxer.Tax(profit, timeOfBuy);
        }
        private static decimal GetProfitOnTrade(decimal currentpriceOfA, decimal currentpriceOfB, decimal amountSelling, decimal oldPriceOfA)
        {
            return ConvertAmountAToAmountB(currentpriceOfA, amountSelling, currentpriceOfB) - ConvertAmountAToAmountB(oldPriceOfA, amountSelling, currentpriceOfB);
        }
        private static decimal GetAmountOfBAfterTaxed(decimal amountOfBToBeCreated, decimal profit, decimal taxedProfit)
        {

            return amountOfBToBeCreated - (profit + taxedProfit);
        }
        public static bool TradeFinanceProductMove(FinanceProductMove fromA, decimal amount, FinanceProduct toB, IDatabaseAdapter databaseAdapter, IStockMarket stockMarketAdapter, ITaxer taxer)
        {
            if (!DoesMoveHasEnoughtProduct(fromA, amount))
                return false;
            decimal oldPriceOfA = fromA.Price;
            FinanceProduct financeProductA = databaseAdapter.GetFinanceProductFromFinanceProductMove(fromA);
            decimal CurrentpriceOfA = stockMarketAdapter.GetProductValue(financeProductA);
            decimal CurrentpriceOfB = stockMarketAdapter.GetProductValue(toB);
            decimal amountOfBToBeCreated = ConvertAmountAToAmountB(CurrentpriceOfA, amount, CurrentpriceOfB);
            decimal tax = 0;
            if (CanTradeBeTaxed(toB, oldPriceOfA, CurrentpriceOfA, databaseAdapter))
            {
                decimal profit = GetProfitOnTrade(CurrentpriceOfA, CurrentpriceOfB, amount, oldPriceOfA);
                decimal taxedProfit = GetTaxedProfit(profit, fromA.DateTime, taxer);
                amountOfBToBeCreated = GetAmountOfBAfterTaxed(amountOfBToBeCreated, profit, taxedProfit);
                tax = taxer.GetTaxForDate(fromA.DateTime);
            }
            var result = databaseAdapter.RestrictFinanceProductTrade(fromA, amount, CurrentpriceOfA, toB, amountOfBToBeCreated, CurrentpriceOfB, tax);

            return result != null;
        }
        public static bool TradeFinanceProducts(User user, FinanceProduct fromA, decimal amount, FinanceProduct toB, 
                                                    IDatabaseAdapter databaseAdapter, IStockMarket stockMarketAdapter, ITaxer taxer)
        {
            FinanceProductWallet wallet = databaseAdapter.GetFinanceProductWallet(user, fromA);
            if (wallet.Amount < amount)
                return false;
            decimal remainingAmount = amount;
            List<FinanceProductMove> moves = databaseAdapter.GetFinanceProductMoveOrderedByDate(wallet.User, wallet.FinanceProduct, reverse:false);
            foreach (var move in moves)
            {
                if (remainingAmount <= 0)
                    return true;
                if (move.CurrentAmount > 0)
                {
                    var amountNeededFromThisMove = Math.Min(remainingAmount, move.CurrentAmount);
                    TradeFinanceProductMove(move, amountNeededFromThisMove, toB, databaseAdapter, stockMarketAdapter, taxer);
                    remainingAmount -= amountNeededFromThisMove;
                }
            }
            return true;
        }
    }
}