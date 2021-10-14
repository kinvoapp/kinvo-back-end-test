using Aliquota.Domain.Entities.Models;

using System;
using System.Collections.Generic;

namespace Aliquota.Domain.ControllersGatewaysAndPresenters.Drivers
{
    public interface IDatabaseDriver
    {
        // get related data
        FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove fromA);
        FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct);
        User GetOwnerFromFinanceProductMove(FinanceProductMove move);

        // promisse operations
        FinanceProductWallet CreateWalletIfNotExists(User user, FinanceProduct financeproduct);
        User GetUserById(int v);
        User GetUserByName(string name);

        FinanceProduct GetFinanceProductByName(string name);

        FinanceProductMove PromisseCreateFinanceProductMove(User user, FinanceProduct financeproduct, decimal amount, decimal price, decimal tax);
        ProductTradeMove PromisseCreateFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, FinanceProductMove createdMove, decimal addedToB);
        void AddUser(User b);
        void PromisseDebitProductMove(FinanceProductMove fromA, decimal removedFromA, decimal priceA);
        void FulfillAllPromisses();
        void ThrowBack();

        // Get List of data. In the current architecture things are stored in a dumb way, but the good thing is that this is modular.
        List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second);
        List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product);
        List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse);
        List<FinanceProduct> GetAllFinanceProducts();
        List<FinanceProductWallet> GetAllFinanceProductWallets(User user);
        List<ProductTradeMove> GetLastProductTradeMovesRanged(FinanceProductMove financeProductMove, int fromA, int toB);
    }
}
