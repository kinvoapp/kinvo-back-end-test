using Aliquota.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace ControllersGatewaysAndPresenters.Drivers
{
    public interface IDatabaseDriver
    {
        // get related data
        FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove fromA);
        FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct);
        User GetOwnerFromFinanceProductMove(FinanceProductMove move);

        // promisse operations
        FinanceProductWallet CreateWalletIfNotExists(User user, FinanceProduct financeproduct);
        FinanceProductMove PromisseCreateFinanceProductMove(User user, FinanceProduct financeproduct, decimal amount);
        ProductTradeMove PromisseCreateFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, FinanceProductMove createdMove, decimal addedToB);
        void PromisseDebitProductMove(FinanceProductMove fromA, decimal removedFromA);
        void FulfillAllPromisses();
        void ThrowBack();

        // Get List of data. In the current architecture things are stored in a dumb way, but the good thing is that this is modular.
        List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second);
        List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product);
        List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse);
        List<FinanceProduct> GetAllFinanceProducts();
        List<FinanceProductWallet> GetAllFinanceProductWallets(User user);
    }
}
