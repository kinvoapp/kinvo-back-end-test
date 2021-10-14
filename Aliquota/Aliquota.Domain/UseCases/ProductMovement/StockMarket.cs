using Aliquota.Domain.Entities.Models;

using Aliquota.Domain.UseCases.Plugin.Interfaces;
using System;

namespace Aliquota.Domain.UseCases.ProductMovement
{
    public class StockMarket : IStockMarket
    {
        //WEB SCRAPPER
        public StockMarket()
        {
            WebScrapper.Scrapper.LoadUrls("{ \"BTC\": \"https://dolarhoje.com/bitcoin-hoje/\","+
                                            "\"USD\": \"https://dolarhoje.com/\","+
                                            "\"EUR\": \"https://dolarhoje.com/euro-hoje/\","+
                                            "\"GLD\": \"https://dolarhoje.com/ouro-hoje/\","+
                                            "\"ASD\": \"https://dolarhoje.com/dolar-australiano-hoje/\","+
                                            "\"DOG\": \"https://dolarhoje.com/ethereum/\","+
                                            "\"FRS\": \"https://dolarhoje.com/franco-suico-hoje/\","+
                                            "\"PND\": \"https://dolarhoje.com/libra-hoje/\"}");
        }
        public decimal GetProductValue(FinanceProduct product)
        {
            if (product.Name == "BRL") return 1;
            return WebScrapper.Scrapper.GetCurrencyValue(product.Name);
        }
    }
}
