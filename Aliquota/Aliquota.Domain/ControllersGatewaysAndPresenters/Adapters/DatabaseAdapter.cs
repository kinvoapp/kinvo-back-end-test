using System;
using Aliquota.Domain.Entities.Models;
using System.Collections.Generic;
using Aliquota.Domain.UseCases.Plugin.Interfaces;
using Aliquota.Domain.ControllersGatewaysAndPresenters.Drivers;

namespace Aliquota.Domain.ControllersGatewaysAndPresenters.Adapters
{
    public class DatabaseAdapter : IDatabaseAdapter
    {

        public IDatabaseDriver DatabaseDriver;

        public DatabaseAdapter(IDatabaseDriver databaseDriver)
        {
            this.DatabaseDriver = databaseDriver;
        }
       
        public FinanceProductMove RestrictFinanceProductBuy(User user, FinanceProduct financeproduct, decimal amount)
        {
            try
            {
                FinanceProductMove move = DatabaseDriver.PromisseCreateFinanceProductMove(user, financeproduct, amount, 1, 0);
                DatabaseDriver.FulfillAllPromisses();
                return move;
            }
            catch
            {
                DatabaseDriver.ThrowBack();
                throw;
            }
        }

        public ProductTradeMove RestrictFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, decimal priceA, FinanceProduct toB, decimal addedToB, decimal price, decimal tax)
        {
            try
            {
                User user = this.GetOwnerFromFinanceProductMove(fromA);
                FinanceProductMove createdMove = DatabaseDriver.PromisseCreateFinanceProductMove(user, toB, addedToB, price, tax);
                DatabaseDriver.PromisseDebitProductMove(fromA, removedFromA, priceA);
                ProductTradeMove tradeMove = DatabaseDriver.PromisseCreateFinanceProductTrade(fromA, removedFromA, createdMove, addedToB);

                DatabaseDriver.FulfillAllPromisses();
                return tradeMove;
            } 
            catch
            {
                DatabaseDriver.ThrowBack();
                throw;
            }
        }
        private void PromisseDebitFromFinanceProductMove(FinanceProductMove fromA, decimal removedFromA, decimal price)
        {
            DatabaseDriver.PromisseDebitProductMove(fromA, removedFromA, price);
        }





        public FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove move) =>
           DatabaseDriver.GetFinanceProductFromFinanceProductMove(move);

        public FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct product) =>
            DatabaseDriver.GetFinanceProductWallet(user, product);

        public User GetOwnerFromFinanceProductMove(FinanceProductMove move) =>
            DatabaseDriver.GetOwnerFromFinanceProductMove(move);

        public List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second) =>
            DatabaseDriver.GetFinanceProductMoveListWithinTimeRange(user, financeProduct, first, second);

        public List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product) =>
            DatabaseDriver.GetFinanceProductMoveList(user, product);

        public List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse) =>
            DatabaseDriver.GetFinanceProductMoveOrderedByDate(user, product, reverse);

        public List<FinanceProduct> GetAllFinanceProducts() =>
            DatabaseDriver.GetAllFinanceProducts();

        public List<FinanceProductWallet> GetAllFinanceProductWallets(User user) =>
            DatabaseDriver.GetAllFinanceProductWallets(user);

        public List<ProductTradeMove> GetLastProductTradeMovesRanged(FinanceProductMove move, int fromA, int toB) =>
           DatabaseDriver.GetLastProductTradeMovesRanged(move, fromA, toB);

		public FinanceProduct GetBRL()
		{
            var financeproducts = DatabaseDriver.GetAllFinanceProducts();
            foreach(var p in financeproducts)
			{
                if(p.Name == "BRL")
                    return p;
			}
            return null;
		}
        public FinanceProduct GetFinanceProductByName(string name) =>
            DatabaseDriver.GetFinanceProductByName(name);
    }
}
