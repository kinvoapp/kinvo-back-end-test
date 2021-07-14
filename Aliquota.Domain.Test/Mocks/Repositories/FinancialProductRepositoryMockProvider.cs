using System;
using System.Collections.Generic;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;
using Moq;

namespace Aliquota.Domain.Test.Mocks
{
    public static class FinancialProductRepositoryMockProvider
    {
        public static FinancialProduct SharedProduct { get; set; } = GetStandardFinancialProduct();
        public static FinancialProduct GetStandardFinancialProduct() 
        {
            var financialProduct = new FinancialProduct()
            {
                Name = "TELEX FREE", // Because its a fake
                EvaluatorsSpec = new List<InvestmentEvaluatorSpec>()
                {
                    new InvestmentEvaluatorSpec() 
                    {
                        EvaluatorType = InvestmentEvaluatorTypes.ConstantMultiplier,
                        Config = new ConstantMultiplierEvaluatorParams
                        {
                            Multiplier = 1.05,
                            PeriodMinutes = 10,
                        }
                    }
                }
            };

            return financialProduct;
        }

        public static Mock<IFinancialProductRepository> GetNewMock()
        {
            var mock = new Mock<IFinancialProductRepository>();

            mock.Setup(r => r.GetProductAsync(It.IsAny<Guid>())).ReturnsAsync(GetStandardFinancialProduct());
            mock.Setup(r => r.GetProductsAsync()).ReturnsAsync(new List<FinancialProduct>() { GetStandardFinancialProduct() });
            return mock;
        }   
    }
}