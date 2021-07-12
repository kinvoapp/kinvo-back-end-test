using System.Collections.Generic;

namespace Aliquota.WebApp.Models
{
    public class PortfolioModel
    {
        public double Balance { get; set; }
        
        public List<InvestmentModel> Investments { get; set; }
    }
}