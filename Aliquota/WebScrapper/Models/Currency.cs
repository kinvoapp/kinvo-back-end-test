using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper.Models
{
    public class Currency
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime LastUpdate { get; set; }

        public Currency(string name, decimal value, DateTime lastUpdate)
        {
            Name = name;
            Value = value;
            LastUpdate = lastUpdate;
        }

    }
}
