using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.ProductMovement
{
    public static class DataLists
    {
        public static List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second, IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetFinanceProductMoveListWithinTimeRange(user, financeProduct, first, second);
        public static List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product, IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetFinanceProductMoveList(user, product);
        public static List<FinanceProduct> GetAllFinanceProducts(IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetAllFinanceProducts();
        public static List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, IDatabaseAdapter databaseAdapter, bool reverse = false) => 
            databaseAdapter.GetFinanceProductMoveOrderedByDate(user, product, reverse);
        public static List<FinanceProductWallet> GetAllFinanceProductWallets(User user, IDatabaseAdapter databaseAdapter) => 
            databaseAdapter.GetAllFinanceProductWallets(user);

    }
}
