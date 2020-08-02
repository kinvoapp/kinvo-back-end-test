using System;
using System.Collections.Generic;
using System.Text;
using Service = Aliquota.Domain.Services.Aliquot;

namespace Aliquota.Desktop
{
    class Add
    {
        public string Entity { get; set; }
        public string[] Args { get; set; }

        public void Run()
        {
            switch (Entity)
            {
                case "investiment":
                    {
                        var investment = Service.Apply(Convert.ToDecimal(Args[0]), Convert.ToDateTime(Args[1]));
                        Console.WriteLine(String.Format("Invetment nº: {0}", investment.ID));
                    }break;
                case "profit":
                    {
                        Service.AddProfit(Convert.ToInt32(Args[0]), Convert.ToDecimal(Args[1]));
                    }
                    break;
            }
        }
    }
}
