using Aliquota.BusinessLogic.Models;
using Aliquota.UseCases.ProductMovement;
using ControllersGatewaysAndPresenters.Adapters;
using FrameworksAndDrivers;
using System;
using System.Collections.Generic;

namespace Console_Front_End
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Console.ForegroundColor = ConsoleColor.Gray;
            DatabaseDriver db = new DatabaseDriver();
            DatabaseAdapter dba = new DatabaseAdapter(db);
            User user = db.GetUserById(1);
            if (user == null)
            {
                var b = new User();
                b.Name = "Rafael";
                b.Email = "teste@teste.teste";
                db.AddUser(b);
            }

            FinanceProduct USD = db.GetFinanceProductByName("USD");
            FinanceProduct BRL = db.GetFinanceProductByName("BRL");
            if(USD == null)
            {
                USD = new FinanceProduct();
                USD.Name = "USD";
                db.AddFinanceProduct(USD);
            }
            if (BRL == null)
            {
                BRL = new FinanceProduct();
                BRL.Name = "BRL";
                db.AddFinanceProduct(BRL);
            }
            //BuyFinancialProduct.BuyFinanceProduct(user, 1000, BRL, dba);
            FinanceProductMove fp = DataLists.GetFinanceProductMoveList(user, BRL, dba)[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(fp.CurrentAmount);
            Console.ForegroundColor = ConsoleColor.Gray;
            StockMarket s = new StockMarket();
            MakeFinanceProductMove.TradeFinanceProductMove(fp, 1000, USD, dba, s);

        }
    }
}
