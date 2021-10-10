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
        FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove product);
        FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct);
        
        ProductTradeMove RestrictFinanceProductTrade(FinanceProductMove fromA, decimal amountA, FinanceProduct toB, decimal amountB);
        FinanceProductMove RestrictFinanceProductBuy(User user, FinanceProduct financeproduct, decimal amount);
        User GetOwnerFromFinanceProductMove(FinanceProductMove move);
        
        List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product);
        List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse);
        List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second);
        List<FinanceProduct> GetAllFinanceProducts();
        List<FinanceProductWallet> GetAllFinanceProductWallets(User user);
    }
}
