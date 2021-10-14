using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapper.Models;

namespace WebScrapper
{
    public static class Scrapper
    {
        public static Dictionary<string, string> URLs;
        private static Dictionary<string, Currency> CurrencyCache = new Dictionary<string, Currency>();
        private static DateTime ExpireTime { get { return DateTime.Now.AddMinutes(-10); } }


        public static void LoadUrls(string jsonstring)
        {
            URLs = JsonController.Readstring<Dictionary<string, string> >(jsonstring);
        }
        public static decimal GetCurrencyValue(string name)
        {
            
            if (!IsCached(name))
            {
                decimal value = SnatchCurrencyValue(name);
                AddToCache(name, value);
            }
            return CurrencyCache[name].Value;
        }

        private static void AddToCache(string name, decimal value)
        {
            Currency currency = new Currency(name, value, DateTime.Now);
            CurrencyCache.Add(name, currency);
        }
        private static bool IsCached(string name)
        {
            return CurrencyCache.ContainsKey(name) && CurrencyCache[name].LastUpdate > ExpireTime;
        }

        private static decimal SnatchCurrencyValue(string name)
        {
            if (!URLs.ContainsKey(name))
                throw new Exception();

            var html = URLs[name];

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            string valueString = htmlDoc.GetElementbyId("nacional").Attributes["value"].Value;
            decimal value;
            Console.WriteLine(valueString);
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            CultureInfo provider = new CultureInfo("fr-FR");
            value = Decimal.Parse(valueString, style, provider);
            return value;
        }
    }
}
