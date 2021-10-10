using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.Plugin.Interfaces;
using ControllersGatewaysAndPresenters.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllersGatewaysAndPresenters.Adapters
{
    public class DatabaseAdapter : IDatabaseAdapter
    {

        private IDatabaseDriver DatabaseDriver;

        public DatabaseAdapter(IDatabaseDriver databaseDriver)
        {
            this.DatabaseDriver = databaseDriver;
        }
       
        public FinanceProductMove RestrictFinanceProductBuy(User user, FinanceProduct financeproduct, decimal amount)
        {
            try
            {
                FinanceProductMove move = DatabaseDriver.PromisseCreateFinanceProductMove(user, financeproduct, amount);
                DatabaseDriver.FulfillAllPromisses();
                return move;
            }
            catch
            {
                throw;
                DatabaseDriver.ThrowBack();
            }
        }

        public ProductTradeMove RestrictFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, FinanceProduct toB, decimal addedToB)
        {
            try
            {
                User user = this.GetOwnerFromFinanceProductMove(fromA);
                FinanceProductMove createdMove = DatabaseDriver.PromisseCreateFinanceProductMove(user, toB, addedToB);
                Console.WriteLine("created move");
                this.PromisseDebitFromFinanceProductMove(user, fromA, removedFromA);
                Console.WriteLine("debited move");
                ProductTradeMove tradeMove = DatabaseDriver.PromisseCreateFinanceProductTrade(fromA, removedFromA, createdMove, addedToB);
                Console.WriteLine("created trademove");

                DatabaseDriver.FulfillAllPromisses();
                Console.WriteLine("fufilled");
                return tradeMove;
            } 
            catch
            {
                DatabaseDriver.ThrowBack();
                throw;
            }
        }
        private void PromisseDebitFromFinanceProductMove(User user, FinanceProductMove fromA, decimal removedFromA)
        {
            FinanceProduct financeProductA = this.GetFinanceProductFromFinanceProductMove(fromA);
            DatabaseDriver.PromisseDebitProductMove(fromA, removedFromA);
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
    }
}
