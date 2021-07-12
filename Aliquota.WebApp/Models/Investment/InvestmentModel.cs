using System;
using System.Collections.Generic;

namespace Aliquota.WebApp.Models
{
    public class InvestmentModel
    {
        public DateTimeOffset ApplicationDate { get; set; }

        public FinancialProductModel FinancialProduct { get; set; }

        public double InitialValue { get; set; }
    }

    public class InvestmentFullModel : InvestmentModel
    {
        public DateTimeOffset? RedemptionDate { get; set; }

        public List<InvestmentEvaluationModel> Evaluations { get; set; }
    }
}