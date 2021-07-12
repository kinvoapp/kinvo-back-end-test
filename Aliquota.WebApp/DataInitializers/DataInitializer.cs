using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;

namespace Aliquota.WebApp.DataInitializers
{
    public class DataInitializer
    {
        private readonly FinancialProductInitializer financialProductInitializer;

        public DataInitializer(FinancialProductInitializer financialProductInitializer)
        {
            this.financialProductInitializer = financialProductInitializer;
        }

        public void EnsureDataExists()
        {
            var product = new FinancialProduct
            {
                Id = Guid.NewGuid(),
                Name = "CDB POS",
                EvaluatorsSpec = new List<InvestmentEvaluatorSpec>() {
                    new InvestmentEvaluatorSpec {
                        EvaluatorType = InvestmentEvaluatorTypes.ConstantMultiplier,
                        Config = new ConstantMultiplierEvaluatorParams {
                            Multiplier = 105/100, // 110%
                            PeriodMinutes = 30, // ~ 1 month
                        }
                    },
                    new InvestmentEvaluatorSpec {
                        EvaluatorType = InvestmentEvaluatorTypes.ImpostoDeRenda,
                        Config = new ImpostoDeRendaEvaluatorParams(),
                    },
                },
            };
            financialProductInitializer.EnsureFinancialProductsExist(new List<FinancialProduct>() { product });
        }
    }
}