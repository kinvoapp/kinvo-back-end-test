using Aliquota.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.UseCases.NewFolder
{
    public class DataLists
    {
        public List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, DateTime first, DateTime second)
        {
            return null;
        }
        public List<FinanceProductMove> GetFinanceProductMoveListOfFinanceProduct(User user, FinanceProduct product)
        {
            return null;
        }
        public List<FinanceProduct> GetAllFinanceProducts()
        {
            return null;
        }
        public FinanceProductMove GetNewestFinanceProductMove(User user, FinanceProduct product)
        {
            return null;
        }
        public FinanceProductMove GetOldestFinanceProductMove(User user, FinanceProduct product)
        {
            return null;
        }
        public List<FinanceProductWallet> GetAllFinanceProductWallets(User user)
        {
            return null;
        }
        public List<ProductTradeMove> SimulateFinanceProductTrade()
        {
            return null;
        }

    }
}
