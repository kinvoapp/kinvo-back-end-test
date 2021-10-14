using Aliquota.Domain.Entities.Models;
using System;
using System.Collections.Generic;

namespace Aliquota.Domain.ControllersGatewaysAndPresenters.Adapters
{
    public interface IDatabaseAdapter
    {
        FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove product);
        FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct);
        
        ProductTradeMove RestrictFinanceProductTrade(FinanceProductMove fromA, decimal amountA, decimal priceA, FinanceProduct toB, decimal amountB, decimal priceB, decimal tax);
        FinanceProductMove RestrictFinanceProductBuy(User user, FinanceProduct financeproduct, decimal amount);
        User GetOwnerFromFinanceProductMove(FinanceProductMove move);
        List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product);
        List<ProductTradeMove> GetLastProductTradeMovesRanged(FinanceProductMove move, int fromA, int toB);
        List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse);
        List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second);
        List<FinanceProduct> GetAllFinanceProducts();
        List<FinanceProductWallet> GetAllFinanceProductWallets(User user);
		FinanceProduct GetBRL();

        FinanceProduct GetFinanceProductByName(string name);

    }
}
