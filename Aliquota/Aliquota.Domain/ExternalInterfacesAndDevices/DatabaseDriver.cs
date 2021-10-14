using Aliquota.Domain.ControllersGatewaysAndPresenters.Drivers;
using Aliquota.Domain.Entities.Models;

using Aliquota.Domain.UseCases.Plugin.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.FrameworksAndDrivers
{
    public class DatabaseDriver: IDatabaseDriver
    {
        private DataBaseContext EntityFrameworkContext = new DataBaseContext();

        // get related data
        public FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct)
        {
            CreateWalletIfNotExists(user, financeProduct);
            var wallets = EntityFrameworkContext.FinanceProductWallets.Include(wallet => wallet.User).Include(wallet => wallet.FinanceProduct)
                .Where(wallet => wallet.User == user && wallet.FinanceProduct == financeProduct);
            if (wallets.Count() > 0)
                return wallets.First();
            throw new Exception();
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
        public User GetUserById(int Id)
        {
            var users = EntityFrameworkContext.Users.Where(element => element.Id == Id);
            if (users.Count() > 0)
                return users.First();
            return null;
        }
        public User GetUserByName(string Name)
        {

            var users = EntityFrameworkContext.Users.Where(element => element.Name == Name);
            if (users.Count() > 0)
                return users.First();
            User user = new User();
            user.Name = Name;
            user.Email = Name;
            user.Password = "1231231";
            AddUser(user);
            return user;
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
        public FinanceProductMove PromisseCreateFinanceProductMove(User user, FinanceProduct financeproduct, decimal amount, decimal price, decimal tax = 0)
        {
            FinanceProductMove fpm = new FinanceProductMove();
            fpm.User = user;
            fpm.FinanceProduct = financeproduct;
            fpm.Amount = amount;
            fpm.CurrentAmount = amount;
            fpm.Price = price;
            fpm.TaxOver = tax;
            fpm.DateTime = DateTime.Now;
            EntityFrameworkContext.FinanceProductMoves.Add(fpm);
            FinanceProductWallet wallet = CreateWalletIfNotExists(user, financeproduct);
            if (amount > 0)
                PromisseAddFundsToWallet(wallet, amount);
            return fpm;
        }
        private void PromisseDebitFundsToWallet(FinanceProductWallet wallet, decimal removedFromA)
        {
            wallet.Amount -= removedFromA;

        }
        public void PromisseDebitProductMove(FinanceProductMove move, decimal removedFromA, decimal priceA)
        {
            this.PromisseCreateFinanceProductMove(move.User, move.FinanceProduct, -removedFromA, priceA);
            move.CurrentAmount -= removedFromA;
            FinanceProductWallet wallet = GetFinanceProductWallet(move.User, move.FinanceProduct);
            PromisseDebitFundsToWallet(wallet, removedFromA);
        }
        public ProductTradeMove PromisseCreateFinanceProductTrade(FinanceProductMove fromA, decimal removedFromA, FinanceProductMove createdMove, decimal addedToB)
        {
            ProductTradeMove ptm= new ProductTradeMove();
            
            ptm.FistFinanceProductMove = fromA;
            ptm.User = fromA.User;
            ptm.Amount = addedToB;
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
        public List<FinanceProductMove> GetFinanceProductMoveListWithinTimeRange(User user, FinanceProduct financeProduct, DateTime first, DateTime second) =>
            EntityFrameworkContext.FinanceProductMoves.Include(f => f.User).Include(f => f.FinanceProduct)
                .Where(f=>f.FinanceProduct == financeProduct && f.DateTime > first && f.DateTime < second && f.User == user).ToList();
 
        public List<FinanceProductMove> GetFinanceProductMoveList(User user, FinanceProduct product) => 
            EntityFrameworkContext.FinanceProductMoves.Include(f=> f.User).Include(f => f.FinanceProduct)
            .Where(f => f.User == user && f.FinanceProduct == product).ToList();

        public List<FinanceProductMove> GetFinanceProductMoveOrderedByDate(User user, FinanceProduct product, bool reverse)
        {
            var result = EntityFrameworkContext.FinanceProductMoves.Include(f => f.User).Include(f => f.FinanceProduct).
            Where(f => f.User == user && f.FinanceProduct == product).OrderBy(f=>f.DateTime).ToList();
            if (reverse)
                result.Reverse();
            return result;
        }
        public List<FinanceProduct> GetAllFinanceProducts() =>
            EntityFrameworkContext.FinanceProducts.ToList();
        
        public List<FinanceProductWallet> GetAllFinanceProductWallets(User user)
        {
            return EntityFrameworkContext.FinanceProductWallets.Include(f=> f.FinanceProduct).Include(f => f.User)
                .Where(f => f.User == user).OrderBy(f => f.Amount)
                .ToList();
        }

        public List<ProductTradeMove> GetLastProductTradeMovesRanged(FinanceProductMove financeProductMove, int fromA, int toB)
        {
            return EntityFrameworkContext.ProductTradeMoves
                .Include(f => f.FistFinanceProductMove).ThenInclude(productMove => productMove.User)
                .Include(f => f.FistFinanceProductMove).ThenInclude(productMove => productMove.FinanceProduct)
                .Include(f => f.SecondFinanceProductMove).ThenInclude(productMove => productMove.User)
                .Include(f => f.SecondFinanceProductMove).ThenInclude(productMove => productMove.FinanceProduct)
                .Where( f =>  f.Id >fromA && f.Id < toB &&
                (f.FistFinanceProductMove == financeProductMove || f.SecondFinanceProductMove == financeProductMove)).ToList();
        }
    }
}
