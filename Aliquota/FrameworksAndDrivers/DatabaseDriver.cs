using Aliquota.BusinessLogic.Models;
using ControllersGatewaysAndPresenters.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworksAndDrivers
{
    internal class DatabaseDriver: IDatabaseDriver
    {
        private DataBaseContext EntityFrameworkContext = new DataBaseContext();
        DatabaseDriver()
        {

        }

        public void CreateWalletIfNotExists(User user, FinanceProduct financeproduct)
        {
            if (EntityFrameworkContext.FinanceProductWallets.Any(o => o.FinanceProduct == financeproduct))
                return;
            FinanceProductWallet wallet = new FinanceProductWallet();
            wallet.FinanceProduct = financeproduct;
            wallet.User = user;
            wallet.Amount = 0;
            EntityFrameworkContext.FinanceProductWallets.Add(wallet);
            EntityFrameworkContext.SaveChanges();
        }

        public void FulfillAllPromisses()
        {
            EntityFrameworkContext.SaveChanges();
        }

        public FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove financeProductmove) => 
            financeProductmove.FinanceProduct;

        public FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct)
        {
            return EntityFrameworkContext.FinanceProductWallets.Where(wallet => wallet.User == user && wallet.FinanceProduct == financeProduct).First();
        }

        public User GetOwnerFromFinanceProductMove(FinanceProductMove move) => move.User;

        public void PromisseAddFundsToWallet(FinanceProductWallet wallet, decimal amount)
        {
            wallet.Amount += amount;
        }

        public void PromisseCreateFinanceProductMove(User user, FinanceProduct financeproduct, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void PromisseDebitFundsToWallet(FinanceProductWallet wallet, decimal removedFromA)
        {
            throw new NotImplementedException();
        }

        public void PromisseDebitProductMove(FinanceProductMove fromA, decimal removedFromA)
        {
            throw new NotImplementedException();
        }
    }
}
