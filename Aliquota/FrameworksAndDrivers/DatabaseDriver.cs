using Aliquota.BusinessLogic.Models;
using ControllersGatewaysAndPresenters.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworksAndDrivers
{
    public class DatabaseDriver: IDatabaseDriver
    {
        private DataBaseContext EntityFrameworkContext = new DataBaseContext();

        // get related data
        public FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct)
        {
            var wallets = EntityFrameworkContext.FinanceProductWallets.Where(wallet => wallet.User == user && wallet.FinanceProduct == financeProduct);
            if (wallets.Count() > 0)
                return wallets.First();
            return null;
        }
        public FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove financeProductmove) =>
            financeProductmove.FinanceProduct;
        public User GetOwnerFromFinanceProductMove(FinanceProductMove move) => move.User;
        public FinanceProduct GetFinanceProductByName(string name)
        {
            var financeProducts = EntityFrameworkContext.FinanceProducts.Where(element => element.Name == name);
            if (financeProducts.Count() > 0)
                return financeProducts.First();
            return null;
        }
        public User GetUserByProductMove(FinanceProductMove financeProductMove)
        {
            var users = EntityFrameworkContext.Users.Where(element => element == financeProductMove.User);
            if (users.Count() > 0)
                return users.First();
            return null;
        }
        public User GetUserById(int Id)
        {
            var users = EntityFrameworkContext.Users.Where(element => element.Id == Id);
            if (users.Count() > 0)
                return users.First();
            return null;
        }



        //Imediate data modification
        public FinanceProductWallet CreateWalletIfNotExists(User user, FinanceProduct financeproduct)
        {
            var w = EntityFrameworkContext.FinanceProductWallets.Where(o => o.FinanceProduct == financeproduct).ToList();
            if (w.Count > 0)
                return w[0];

            FinanceProductWallet wallet = new FinanceProductWallet();
            wallet.FinanceProduct = financeproduct;
            wallet.User = user;
            wallet.Amount = 0;
            EntityFrameworkContext.FinanceProductWallets.Add(wallet);
            EntityFrameworkContext.SaveChanges();
            return wallet;
        }
        public void AddFinanceProduct(FinanceProduct product)
        {
            EntityFrameworkContext.FinanceProducts.Add(product);
            EntityFrameworkContext.SaveChanges();
        }
        public void AddUser(User user)
        {
            EntityFrameworkContext.Users.Add(user);
            EntityFrameworkContext.SaveChanges();
        }


        // promisse operations
        private void PromisseAddFundsToWallet(FinanceProductWallet wallet, decimal amount)
        {
            wallet.Amount += amount;
        }
        public FinanceProductMove PromisseCreateFinanceProductMove(User user, FinanceProduct financeproduct, decimal amount)
        {
            FinanceProductMove fpm = new FinanceProductMove();
            fpm.User = user;
            fpm.FinanceProduct = financeproduct;
            fpm.Amount = amount;
            fpm.CurrentAmount = amount;
            fpm.DateTime = DateTime.Now;
            EntityFrameworkContext.FinanceProductMoves.Add(fpm);
            FinanceProductWallet wallet = CreateWalletIfNotExists(user, financeproduct);
            PromisseAddFundsToWallet(wallet, amount);
            return fpm;
        }
        public void PromisseDebitFundsToWallet(FinanceProductWallet wallet, decimal removedFromA)
        {
            wallet.Amount -= removedFromA;
        }
        public void PromisseDebitProductMove(FinanceProductMove move, decimal removedFromA)
        {
            move.CurrentAmount -= removedFromA;

            FinanceProductWallet wallet = GetFinanceProductWallet(move.User, move.FinanceProduct);
            PromisseDebitFundsToWallet(wallet, removedFromA);
        }
        public ProductTradeMove PromisseCreateFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, FinanceProductMove createdMove, decimal addedToB)
        {
            ProductTradeMove ptm= new ProductTradeMove();
            
            ptm.FistFinanceProductMove = fromA;
            ptm.SecondFinanceProductMove = createdMove;
            ptm.DateTime = DateTime.Now;

            EntityFrameworkContext.ProductTradeMoves.Add(ptm);
            return ptm;
        }
        public void FulfillAllPromisses()
        {
            EntityFrameworkContext.SaveChanges();
        }
        public void ThrowBack()
        {
            throw new NotImplementedException();
        }


        // Get List of data. 
        public List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second)
        {
            throw new NotImplementedException();
        }
        public List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product) => 
            EntityFrameworkContext.FinanceProductMoves.Where(f => f.User == user && f.FinanceProduct == product).ToList();

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
        FinanceProductWallet IDatabaseDriver.CreateWalletIfNotExists(User user, FinanceProduct financeproduct)
        {
            throw new NotImplementedException();
        }

    }
}
