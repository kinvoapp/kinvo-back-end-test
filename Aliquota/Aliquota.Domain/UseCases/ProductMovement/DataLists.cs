using Aliquota.Domain.ControllersGatewaysAndPresenters.Adapters;
using Aliquota.Domain.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.UseCases.ProductMovement
{
    public static class DataLists
    {
        public static List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second, IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetFinanceProductMoveListWithinTimeRange(user, financeProduct, first, second);
        public static List<ProductTradeMove> GetLastProductTradeMovesRanged(FinanceProductMove move, int fromA, int toB, IDatabaseAdapter databaseAdapter) =>
            databaseAdapter.GetLastProductTradeMovesRanged(move, fromA, toB);
        public static List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product, IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetFinanceProductMoveList(user, product);
        public static List<FinanceProduct> GetAllFinanceProducts(IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetAllFinanceProducts();
        public static List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, IDatabaseAdapter databaseAdapter, bool reverse = false) => 
            databaseAdapter.GetFinanceProductMoveOrderedByDate(user, product, reverse);
        public static List<FinanceProductWallet> GetAllFinanceProductWallets(User user, IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetAllFinanceProductWallets(user);
        public static List<FinanceProductMove> SimulateSelling(User user, FinanceProduct product, decimal amount, IDatabaseAdapter database)
        {
            if (Verify.DoesUserHasEnoughtFunds(user, product, amount, database))
                return null;
            List<FinanceProductMove> financeproducts = DataLists.GetFinanceProductMoveOrderedByDate(user, product, database, reverse: true);
            List<FinanceProductMove> returnValue = new List<FinanceProductMove>();
            decimal remains = amount;
            for (int i = 0; i < financeproducts.Count; i++)
            {
                if(financeproducts[i].CurrentAmount < remains)
                {
                    remains -= financeproducts[i].CurrentAmount;
                    returnValue.Append(financeproducts[i]);
                    continue;
                }
                break;
            }
            return returnValue;
        }
    }
}
