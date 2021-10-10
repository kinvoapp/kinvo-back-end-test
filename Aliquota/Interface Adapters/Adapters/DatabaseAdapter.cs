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

        DatabaseAdapter(IDatabaseDriver databaseDriver)
        {
            this.DatabaseDriver = databaseDriver;
        }
        // PELO AMOR DE DEUS RAFAEL DO FUTURO REMOVA ISSO. RAFAEL DO PRESENTE ESTÁ OCUPADO DEMAIS
        public decimal GetFinanceProductCurrentPrice(FinanceProduct product)
        {
            return 1;
        }

        public FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove move) =>
            DatabaseDriver.GetFinanceProductFromFinanceProductMove(move);

        public FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct product) => 
            DatabaseDriver.GetFinanceProductWallet(user, product);

        public User GetOwnerFromFinanceProductMove(FinanceProductMove move) =>
            DatabaseDriver.GetOwnerFromFinanceProductMove(move);

        public bool RestrictFinanceProductBuy(User user, FinanceProduct financeproduct, decimal amount)
        {
            try
            {
                
                this.RestrictFinanceProductCreateMove(user, financeproduct, amount);
                DatabaseDriver.FulfillAllPromisses();
                return true;
            }
            catch (Exception e)
            {
                // PELO AMOR DE DEUS RAFAEL DO FUTURO LOG EXCEPTION 
                return false;
            }
        }

        private void RestrictFinanceProductCreateMove(User user, FinanceProduct financeproduct, decimal amount)
        {
            DatabaseDriver.CreateWalletIfNotExists(user, financeproduct);
            FinanceProductWallet wallet = DatabaseDriver.GetFinanceProductWallet(user, financeproduct);
            
            DatabaseDriver.PromisseCreateFinanceProductMove(user, financeproduct, amount);
            DatabaseDriver.PromisseAddFundsToWallet(wallet, amount);
        }

        public bool RestrictFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, FinanceProduct toB, decimal addedToB)
        {
            try
            {
                User user = this.GetOwnerFromFinanceProductMove(fromA);
                this.PromisseDebitFromFinanceProductMove(user, fromA, removedFromA);
                this.RestrictFinanceProductCreateMove(user, toB, addedToB);

                DatabaseDriver.FulfillAllPromisses();
                return true;
            } 
            catch (Exception e)
            {
                return false;
            }
        }

        private void PromisseDebitFromFinanceProductMove(User user, FinanceProductMove fromA, decimal removedFromA)
        {
            FinanceProduct financeProductA = this.GetfinanceProductFromFinanceProductMove(fromA);
            DatabaseDriver.PromisseDebitProductMove(fromA, removedFromA);

            FinanceProductWallet wallet = DatabaseDriver.GetFinanceProductWallet(user, financeProductA);
            DatabaseDriver.PromisseDebitFundsToWallet(wallet, removedFromA);
        }

        private FinanceProduct GetfinanceProductFromFinanceProductMove(FinanceProductMove move) =>
            DatabaseDriver.GetFinanceProductFromFinanceProductMove(move);

        public List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second)
        {
            throw new NotImplementedException();
        }

        public List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product)
        {
            throw new NotImplementedException();
        }

        public List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse)
        {
            throw new NotImplementedException();
        }

        public List<FinanceProduct> GetAllFinanceProducts()
        {
            throw new NotImplementedException();
        }

        public List<FinanceProductWallet> GetAllFinanceProductWallets(User user)
        {
            throw new NotImplementedException();
        }
    }
}
