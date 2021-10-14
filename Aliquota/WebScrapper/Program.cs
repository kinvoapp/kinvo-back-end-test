using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebScrapper.Models;

namespace WebScrapper
{
    
   
    internal class Program
    {

        static void Main(string[] args)
        {
            string ExecutingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string ExecutingDirectoryPath = System.IO.Path.GetDirectoryName(ExecutingAssembly);
            string UrlFilePath = System.IO.Path.Combine(ExecutingDirectoryPath, "..\\..\\..\\Urls.json");
            Scrapper.LoadUrls(UrlFilePath);
            for (int i = 0; i < 10; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine(Scrapper.GetCurrencyValue("BTC"));
                sw.Stop();

                Console.WriteLine("Operation completed in: " + sw.ElapsedMilliseconds + " (ms)");
            }
        }
    }
}
